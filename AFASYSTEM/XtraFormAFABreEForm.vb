Imports System.Data
Imports System.IO
Imports DevExpress.XtraEditors

Public Class XtraFormAFABreEForm

    Private ReadOnly _service As New AFAReclassBudgetService()
    Private ReadOnly _general As New GeneralService()

    Private _dtDepartment As DataTable
    Private _dtLocation As DataTable
    Private _dtBudgetAllocation As DataTable

    Private _afaNo As String = String.Empty
    Private _attachmentPath As String = String.Empty

    Private _sourceCc As String = String.Empty
    Private _sourceContract As String = String.Empty
    Private _sourceResolved As Boolean = False

    Private _targetCc As String = String.Empty
    Private _targetContract As String = String.Empty
    Private _targetResolved As Boolean = False

    Private ReadOnly _nik As String = Trim(FormFluMenu.btnuserid.Caption)
    Private ReadOnly _pc As String = System.Net.Dns.GetHostName()

#Region "Form"

    Private Sub XtraFormAFABreEForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupEditors()
        LoadCombos()
        ClearForm()
        LoadBudgetAllocation()
    End Sub

    Private Sub SetupEditors()
        For Each editor As TextEdit In New TextEdit() {TextEditBudgetAmtSource, TextEditBudgetAmtTarget,
                                                       TextEditActualUpSource, TextEditActualUpTarget,
                                                       TextEditShortageSource, TextEditReclassAmount,
                                                       TextEditBalanceTarget, TextEditTotalReclass}
            With editor.Properties
                .ReadOnly = True
                .Appearance.Options.UseTextOptions = True
                .Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
                .MaskSettings.Set("mask", "n2")
                .UseMaskAsDisplayFormat = True
            End With
        Next

        With TextEditEstimationSource.Properties
            .Appearance.Options.UseTextOptions = True
            .Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
            .MaskSettings.Set("mask", "n2")
            .UseMaskAsDisplayFormat = True
        End With

        With TextEditBudgetYear.Properties
            .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
            .MaskSettings.Set("mask", "d")
            .MaxLength = 4
        End With

        PictureEditAttachCover.Properties.NullText = "Double-click to choose a file"
        PictureEditAttachCover.Properties.ShowMenu = False
    End Sub

#End Region

#Region "Combo"

    Private Sub LoadCombos()
        LoadDepartment()
        LoadLocation()

        TextEditBudgetYear.Text = Date.Today.Year.ToString()
    End Sub

    Private Sub LoadDepartment()
        _dtDepartment = _general.GetDepartmentsByNik(_nik)

        SelectDepartment.Properties.Items.Clear()

        If _dtDepartment Is Nothing OrElse _dtDepartment.Rows.Count = 0 Then
            XtraMessageBox.Show("NIK " & _nik & " is not mapped to any department." & vbCrLf &
                                "Please ask an administrator to set up the User Department Mapping.",
                                "E-Form AFA Reclass Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            BtnSave.Enabled = False
            Return
        End If

        For Each row As DataRow In _dtDepartment.Rows
            SelectDepartment.Properties.Items.Add(Convert.ToString(row("DISPLAY_NAME")))
        Next

        If SelectDepartment.Properties.Items.Count = 1 Then SelectDepartment.SelectedIndex = 0
    End Sub

    Private Sub LoadLocation()
        _dtLocation = _general.GetLocations()
        SelectLocation.Properties.Items.Clear()

        If _dtLocation Is Nothing Then Return

        For Each row As DataRow In _dtLocation.Rows
            SelectLocation.Properties.Items.Add(Convert.ToString(row("NAME")))
        Next
    End Sub

    Private Function GetSelectedValue(ByVal combo As ComboBoxEdit,
                                      ByVal dt As DataTable,
                                      ByVal columnName As String) As Object
        If dt Is Nothing Then Return Nothing
        If combo.SelectedIndex < 0 OrElse combo.SelectedIndex >= dt.Rows.Count Then Return Nothing
        Return dt.Rows(combo.SelectedIndex)(columnName)
    End Function

    Private Sub SetComboByValue(ByVal combo As ComboBoxEdit,
                                ByVal dt As DataTable,
                                ByVal columnName As String,
                                ByVal value As Object)
        combo.SelectedIndex = -1

        If dt Is Nothing OrElse value Is Nothing OrElse value Is DBNull.Value Then Return

        For i As Integer = 0 To dt.Rows.Count - 1
            If Convert.ToString(dt.Rows(i)(columnName)) = Convert.ToString(value) Then
                combo.SelectedIndex = i
                Return
            End If
        Next
    End Sub

#End Region

#Region "Budget Item Lookup"

    Private Sub LoadBudgetAllocation()
        _dtBudgetAllocation = _service.GetBudgetAllocation(TextEditBudgetYear.Text.Trim(), TextEditBudgetRevision.Text.Trim())

        BindBudgetItemLookup(LookupBudgetItemSource)
        BindBudgetItemLookup(LookupBudgetItemTarget)
    End Sub

    Private Sub BindBudgetItemLookup(ByVal lookup As SearchLookUpEdit)
        lookup.Properties.DataSource = _dtBudgetAllocation
        lookup.Properties.ValueMember = "BUDGET_ITEM_CODE"
        lookup.Properties.DisplayMember = "BUDGET_ITEM_NAME"

        If _dtBudgetAllocation IsNot Nothing Then
            lookup.Properties.PopupView.PopulateColumns()
            ConfigureBudgetItemColumns(TryCast(lookup.Properties.PopupView, DevExpress.XtraGrid.Views.Grid.GridView))
        End If
    End Sub

    Private Sub ConfigureBudgetItemColumns(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView)
        If view Is Nothing OrElse view.Columns.Count = 0 Then Return

        If view.Columns("BUDGET_ITEM_NAME") IsNot Nothing Then
            view.Columns("BUDGET_ITEM_NAME").Visible = False
        End If

        SetLookupColumn(view, "BUDGET_ITEM_CODE", "Budget Item Code", 0, False)
        SetLookupColumn(view, "CC", "Cost Center", 1, False)
        SetLookupColumn(view, "CONTRACT", "Contract", 2, False)
        SetLookupColumn(view, "BUDGET_AMOUNT", "Budget Amount", 3, True)
        SetLookupColumn(view, "ACTUAL_UP", "Actual Up", 4, True)

        view.OptionsView.ShowGroupPanel = False
        view.BestFitColumns()
    End Sub

    Private Sub SetLookupColumn(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView,
                                ByVal fieldName As String,
                                ByVal caption As String,
                                ByVal visibleIndex As Integer,
                                ByVal isAmount As Boolean)
        Dim col = view.Columns(fieldName)
        If col Is Nothing Then Return

        col.Caption = caption
        col.VisibleIndex = visibleIndex
        col.OptionsColumn.AllowEdit = False

        If isAmount Then
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            col.DisplayFormat.FormatString = "n2"
            col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        End If
    End Sub

    Private Sub TextEditBudgetYear_Leave(sender As Object, e As EventArgs) Handles TextEditBudgetYear.Leave
        LoadBudgetAllocation()
    End Sub

    Private Sub TextEditBudgetRevision_Leave(sender As Object, e As EventArgs) Handles TextEditBudgetRevision.Leave
        LoadBudgetAllocation()
    End Sub

    Private Sub LookupBudgetItemSource_EditValueChanged(sender As Object, e As EventArgs) Handles LookupBudgetItemSource.EditValueChanged

        Dim row As DataRow = FindAllocationRow(LookupBudgetItemSource.EditValue)

        If row Is Nothing Then
            _sourceResolved = False
            TextEditBudgetAmtSource.Text = "0"
            TextEditActualUpSource.Text = "0"
            _sourceCc = String.Empty
            _sourceContract = String.Empty
        Else
            _sourceResolved = True
            TextEditBudgetAmtSource.Text = FormatAmount(row("BUDGET_AMOUNT"))
            TextEditActualUpSource.Text = FormatAmount(row("ACTUAL_UP"))
            _sourceCc = Convert.ToString(row("CC"))
            _sourceContract = Convert.ToString(row("CONTRACT"))
        End If

        Recalculate()
    End Sub

    Private Sub LookupBudgetItemTarget_EditValueChanged(sender As Object, e As EventArgs) Handles LookupBudgetItemTarget.EditValueChanged

        Dim row As DataRow = FindAllocationRow(LookupBudgetItemTarget.EditValue)

        If row Is Nothing Then
            _targetResolved = False
            TextEditBudgetAmtTarget.Text = "0"
            TextEditActualUpTarget.Text = "0"
            _targetCc = String.Empty
            _targetContract = String.Empty
        Else
            _targetResolved = True
            TextEditBudgetAmtTarget.Text = FormatAmount(row("BUDGET_AMOUNT"))
            TextEditActualUpTarget.Text = FormatAmount(row("ACTUAL_UP"))
            _targetCc = Convert.ToString(row("CC"))
            _targetContract = Convert.ToString(row("CONTRACT"))
        End If

        Recalculate()
    End Sub

    Private Function FindAllocationRow(ByVal code As Object) As DataRow
        If _dtBudgetAllocation Is Nothing Then Return Nothing
        Dim key As String = Convert.ToString(code)
        If key = "" Then Return Nothing

        Dim rows() As DataRow = _dtBudgetAllocation.Select("BUDGET_ITEM_CODE = '" & key.Replace("'", "''") & "'")
        If rows.Length = 0 Then Return Nothing
        Return rows(0)
    End Function

    Private Sub BtnSyncBudgetItemSource_Click(sender As Object, e As EventArgs) Handles BtnSyncBudgetItemSource.Click
        SyncOne(LookupBudgetItemSource.Text.Trim())
    End Sub

    Private Sub BtnSyncBudgetItemTarget_Click(sender As Object, e As EventArgs) Handles BtnSyncBudgetItemTarget.Click
        SyncOne(LookupBudgetItemTarget.Text.Trim())
    End Sub

    Private Sub SyncOne(ByVal allocation As String)
        If allocation = "" Then
            XtraMessageBox.Show("Type or pick an Allocation code first.", "E-Form AFA Reclass Budget",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Cursor.Current = Cursors.WaitCursor
        Try
            If _service.SyncBudget(TextEditBudgetYear.Text.Trim(), TextEditBudgetRevision.Text.Trim(), allocation) Then
                LoadBudgetAllocation()
                XtraMessageBox.Show("Sync placeholder ran (no real IFS pull yet - see AFA_NonIFS_SyncBudget_Proc).",
                                    "E-Form AFA Reclass Budget", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                XtraMessageBox.Show(_service.LastErrorMessage, "Sync Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Load For Edit"

    Private Sub TextEditAFANo_Leave(sender As Object, e As EventArgs) Handles TextEditAFANo.Leave
        Dim afaNo As String = TextEditAFANo.Text.Trim()

        If afaNo = "" Then
            If _afaNo <> "" Then ClearForm()
            Return
        End If

        If afaNo = _afaNo Then Return

        LoadDocument(afaNo)
    End Sub

    Public Sub LoadDocument(ByVal afaNo As String)
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim ds As DataSet = _service.GetHeaderForEdit(afaNo)

            If ds Is Nothing Then
                XtraMessageBox.Show("AFA " & afaNo & " was not found.", "E-Form AFA Reclass Budget",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextEditAFANo.Text = ""
                Return
            End If

            Dim header As DataRow = ds.Tables(0).Rows(0)

            If Convert.ToString(header("AFA_TYPE")) <> "BRE" Then
                XtraMessageBox.Show("AFA " & afaNo & " is not a Reclass Budget type document.",
                                    "E-Form AFA Reclass Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextEditAFANo.Text = ""
                Return
            End If

            Dim sts As String = Convert.ToString(header("STS"))
            If sts <> "Draft" AndAlso sts <> "Cancelled" Then
                XtraMessageBox.Show("This AFA is in circulation (" & sts & ") and cannot be edited directly." & vbCrLf &
                                    "Please cancel it first if it needs revision.",
                                    "E-Form AFA Reclass Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextEditAFANo.Text = ""
                Return
            End If

            Dim ownerNik As String = Convert.ToString(header("USERID"))
            If ownerNik <> _nik Then
                XtraMessageBox.Show("Only the drafter who created this AFA can edit it.",
                                    "E-Form AFA Reclass Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextEditAFANo.Text = ""
                Return
            End If

            _afaNo = afaNo
            TextEditAFANo.Text = afaNo

            SetComboByValue(SelectLocation, _dtLocation, "CODE", header("AFA_LOCATION"))
            SetComboByValue(SelectDepartment, _dtDepartment, "DEPT_ID", header("DEPT_ID"))

            TextEditSubject.Text = Convert.ToString(header("SUBJECT"))
            MemoEditPurpose.Text = Convert.ToString(header("PURPOSES"))
            MemoEditBgExp.Text = Convert.ToString(header("BG_EXPLANATION"))

            DateEditScheduleFrom.EditValue = If(header("AFA_PER_FROM") Is DBNull.Value, Nothing, header("AFA_PER_FROM"))
            DateEditScheduleTo.EditValue = If(header("AFA_PER_TO") Is DBNull.Value, Nothing, header("AFA_PER_TO"))

            TextEditAFADate.Text = If(header("AFA_DATE") Is DBNull.Value, "",
                                      Convert.ToDateTime(header("AFA_DATE")).ToString("dd MMM yyyy"))

            TextEditBudgetYear.Text = Convert.ToString(header("BUDGET_YEAR"))
            TextEditBudgetRevision.Text = Convert.ToString(header("BUDGET_REV"))
            LoadBudgetAllocation()

            PictureEditAttachCover.Image = Nothing
            TextEditCaptionCover.Text = ""
            _attachmentPath = String.Empty

            If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                Dim attRow As DataRow = ds.Tables(1).Rows(0)
                Dim existingPath As String = Convert.ToString(attRow("FILE_PATH"))
                Dim serverPath As String = Trim(FormFluMenu.btnlink.Caption)

                If Not String.IsNullOrEmpty(existingPath) AndAlso serverPath <> "" Then
                    Dim isFullPath As Boolean = existingPath.Length >= 2 AndAlso existingPath(1) = ":"c OrElse existingPath.StartsWith("\\")
                    Dim fullPath As String = If(isFullPath, existingPath, Path.Combine(serverPath, existingPath.TrimStart("\"c, "/"c)))

                    If File.Exists(fullPath) Then
                        Try
                            Using tempImg As Image = Image.FromFile(fullPath)
                                PictureEditAttachCover.Image = New Bitmap(tempImg)
                            End Using
                        Catch
                            ' abaikan - kalau file cover lama gagal dibuka, biarkan kosong
                        End Try
                    End If
                End If

                TextEditCaptionCover.Text = Convert.ToString(attRow("CAPTION"))
            End If

            ' --- Detail spesifik BRE (Table 2) - 1 baris Source, 1 baris Target ---
            If ds.Tables.Count > 2 Then
                For Each detailRow As DataRow In ds.Tables(2).Rows
                    Dim itemRole As String = Convert.ToString(detailRow("ITEM_ROLE"))
                    Dim estimation As Decimal = If(detailRow("ESTIMATION") Is DBNull.Value, 0D, Convert.ToDecimal(detailRow("ESTIMATION")))

                    If itemRole = "Source" Then
                        LookupBudgetItemSource.EditValue = Convert.ToString(detailRow("BUDGET_ITEM_CODE"))
                        TextEditEstimationSource.Text = estimation.ToString("n2")
                    ElseIf itemRole = "Target" Then
                        LookupBudgetItemTarget.EditValue = Convert.ToString(detailRow("BUDGET_ITEM_CODE"))
                    End If
                Next
            End If

            Me.Text = "E-Form AFA Reclass Budget - " & afaNo & " (Edit)"
            BtnSave.Text = "Update"
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Calculation"
    Private Sub Recalculate()
        Dim budgetSource As Decimal = ParseAmount(TextEditBudgetAmtSource.Text)
        Dim actualSource As Decimal = ParseAmount(TextEditActualUpSource.Text)
        Dim estimationSource As Decimal = ParseAmount(TextEditEstimationSource.Text)

        Dim shortage As Decimal = budgetSource - actualSource - estimationSource
        TextEditShortageSource.Text = shortage.ToString("n2")

        Dim reclassAmount As Decimal = Math.Abs(shortage)
        TextEditReclassAmount.Text = reclassAmount.ToString("n2")

        Dim budgetTarget As Decimal = ParseAmount(TextEditBudgetAmtTarget.Text)
        Dim actualTarget As Decimal = ParseAmount(TextEditActualUpTarget.Text)
        Dim balance As Decimal = budgetTarget - actualTarget - reclassAmount
        TextEditBalanceTarget.Text = balance.ToString("n2")

        TextEditTotalReclass.Text = reclassAmount.ToString("n2")
    End Sub

    Private Function ParseAmount(ByVal text As String) As Decimal
        Dim value As Decimal
        If Decimal.TryParse(text, value) Then Return value
        Return 0D
    End Function

    Private Sub TextEditEstimationSource_EditValueChanged(sender As Object, e As EventArgs) _
            Handles TextEditEstimationSource.EditValueChanged
        Recalculate()
    End Sub

#End Region

#Region "Validation"

    Private Function IsValid() As Boolean
        If SelectDepartment.SelectedIndex < 0 Then
            Warn("Please select a Department.", SelectDepartment) : Return False
        End If

        If SelectLocation.SelectedIndex < 0 Then
            Warn("Please select a Location.", SelectLocation) : Return False
        End If

        Dim year As Integer
        If Not Integer.TryParse(TextEditBudgetYear.Text.Trim(), year) OrElse year < 2000 OrElse year > 2999 Then
            Warn("Budget Year must be a four-digit number.", TextEditBudgetYear) : Return False
        End If

        If TextEditSubject.Text.Trim() = "" Then
            Warn("Subject is required.", TextEditSubject) : Return False
        End If

        If MemoEditBgExp.Text.Trim() = "" Then
            Warn("Background & Explanation is required.", MemoEditBgExp) : Return False
        End If

        If DateEditScheduleFrom.EditValue IsNot Nothing AndAlso DateEditScheduleTo.EditValue IsNot Nothing Then
            If DateEditScheduleTo.DateTime < DateEditScheduleFrom.DateTime Then
                Warn("Schedule To cannot be earlier than Schedule From.", DateEditScheduleTo) : Return False
            End If
        End If

        If LookupBudgetItemSource.Text.Trim() = "" OrElse Not _sourceResolved Then
            Warn("Please pick a valid Source budget item from the list.", LookupBudgetItemSource) : Return False
        End If

        If LookupBudgetItemTarget.Text.Trim() = "" OrElse Not _targetResolved Then
            Warn("Please pick a valid Target budget item from the list.", LookupBudgetItemTarget) : Return False
        End If

        If LookupBudgetItemSource.Text.Trim() = LookupBudgetItemTarget.Text.Trim() Then
            Warn("Source and Target must be different budget items.", LookupBudgetItemTarget) : Return False
        End If

        Return True
    End Function

    Private Sub Warn(ByVal message As String, ByVal ctl As Control)
        XtraMessageBox.Show(message, "E-Form AFA Reclass Budget",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ctl.Focus()
    End Sub

#End Region

#Region "Save"

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If Not IsValid() Then Return

        If XtraMessageBox.Show("Save this document?", "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then Return

        Cursor.Current = Cursors.WaitCursor
        Try
            Dim deptId As Integer = Convert.ToInt32(GetSelectedValue(SelectDepartment, _dtDepartment, "DEPT_ID"))
            Dim locCode As String = Convert.ToString(GetSelectedValue(SelectLocation, _dtLocation, "CODE"))

            Dim curCode As String = "USD"

            Dim perFrom As Object = If(DateEditScheduleFrom.EditValue Is Nothing, Nothing, DateEditScheduleFrom.DateTime.Date)
            Dim perTo As Object = If(DateEditScheduleTo.EditValue Is Nothing, Nothing, DateEditScheduleTo.DateTime.Date)

            Dim savedNo As String = _service.SaveHeader(
                _afaNo, locCode, deptId,
                TextEditBudgetYear.Text.Trim(), TextEditBudgetRevision.Text.Trim(),
                TextEditSubject.Text.Trim(),
                MemoEditPurpose.Text.Trim(),
                MemoEditBgExp.Text.Trim(),
                curCode, perFrom, perTo, _nik, _pc)

            If savedNo = "" Then
                XtraMessageBox.Show(_service.LastErrorMessage, "Failed to save header",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            _afaNo = savedNo

            Dim sourceCode As String = LookupBudgetItemSource.Text.Trim()
            Dim sourceSeq As Integer = 0

            If Not _service.SaveDetail(_afaNo, 0, "Source", sourceCode, sourceCode,
                                       _sourceCc, _sourceContract,
                                       ParseAmount(TextEditBudgetAmtSource.Text),
                                       ParseAmount(TextEditActualUpSource.Text),
                                       ParseAmount(TextEditEstimationSource.Text),
                                       Nothing, _nik, _pc, sourceSeq) Then
                XtraMessageBox.Show("The header was saved as " & _afaNo & "," & vbCrLf &
                                    "but the Source item could not be saved:" & vbCrLf & _service.LastErrorMessage,
                                    "Failed to save detail", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim targetCode As String = LookupBudgetItemTarget.Text.Trim()
            Dim targetSeq As Integer = 0

            If Not _service.SaveDetail(_afaNo, 0, "Target", targetCode, targetCode,
                                       _targetCc, _targetContract,
                                       ParseAmount(TextEditBudgetAmtTarget.Text),
                                       ParseAmount(TextEditActualUpTarget.Text),
                                       Nothing, sourceSeq, _nik, _pc, targetSeq) Then
                XtraMessageBox.Show("The header and Source item were saved as " & _afaNo & "," & vbCrLf &
                                    "but the Target item could not be saved:" & vbCrLf & _service.LastErrorMessage,
                                    "Failed to save detail", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If _attachmentPath <> "" Then
                Dim storedName As String = UploadAttachment(_attachmentPath, "Cover")

                If storedName <> "" Then
                    If Not _service.SaveAttachment(_afaNo, 0, "Cover", storedName,
                                                   TextEditCaptionCover.Text.Trim(), _nik) Then
                        XtraMessageBox.Show("The document was saved, but the attachment could not be recorded:" & vbCrLf &
                                            _service.LastErrorMessage,
                                            "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        _attachmentPath = String.Empty
                    End If
                End If
            End If

            Try
                Clipboard.SetText(_afaNo)
            Catch

            End Try

            XtraMessageBox.Show("Document saved." & vbCrLf & "AFA No: " & _afaNo & vbCrLf & vbCrLf &
                                "The AFA number has been copied to the clipboard.",
                                "E-Form AFA Reclass Budget", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Text = "E-Form AFA Reclass Budget - " & _afaNo
            TextEditAFANo.Text = _afaNo
            BtnSave.Text = "Update"
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Attachment"
    Private Function BuildStoredFileName(ByVal afaNo As String,
                                         ByVal attachmentType As String,
                                         ByVal sourcePath As String) As String
        Dim safeAfa As String = afaNo.Replace("/", "-").Replace("\", "-")
        Dim stamp As String = DateTime.Now.ToString("yyyyMMddHHmmssfff")

        Return String.Format("{0}_{1}_{2}_{3}{4}", safeAfa, attachmentType, stamp, _nik,
                             Path.GetExtension(sourcePath))
    End Function

    Private Function UploadAttachment(ByVal sourcePath As String,
                                      ByVal attachmentType As String) As String
        Dim serverPath As String = Trim(FormFluMenu.btnlink.Caption)

        If serverPath = "" Then
            XtraMessageBox.Show("The document server path is not configured.",
                                "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return String.Empty
        End If

        Dim storedName As String = BuildStoredFileName(_afaNo, attachmentType, sourcePath)

        Try
            File.Copy(sourcePath, Path.Combine(serverPath, storedName), True)
            Return storedName
        Catch ex As Exception
            XtraMessageBox.Show("The file could not be copied to the document server:" & vbCrLf &
                                ex.Message,
                                "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return String.Empty
        End Try
    End Function

    Private Sub PictureEditAttachCover_DoubleClick(sender As Object, e As EventArgs) _
            Handles PictureEditAttachCover.DoubleClick
        Using ofd As New OpenFileDialog()
            ofd.Title = "Choose an attachment"
            ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp"

            If ofd.ShowDialog() <> DialogResult.OK Then Return

            Dim ext As String = Path.GetExtension(ofd.FileName).ToLowerInvariant()
            If ext <> ".jpg" AndAlso ext <> ".jpeg" AndAlso ext <> ".png" AndAlso ext <> ".bmp" Then
                XtraMessageBox.Show("Cover must be an image file (JPG, PNG or BMP).",
                                    "E-Form AFA Reclass Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            _attachmentPath = ofd.FileName
            PictureEditAttachCover.Image = Image.FromFile(ofd.FileName)
        End Using
    End Sub

#End Region

#Region "Helpers"

    Private Function FormatAmount(ByVal value As Object) As String
        If value Is Nothing OrElse IsDBNull(value) Then Return "0"
        Return Convert.ToDecimal(value).ToString("n2")
    End Function

    Private Sub ClearForm()
        _afaNo = String.Empty
        _attachmentPath = String.Empty

        TextEditAFANo.Text = ""
        TextEditAFADate.Text = ""
        SelectLocation.SelectedIndex = -1
        TextEditSubject.Text = ""
        MemoEditPurpose.Text = ""
        MemoEditBgExp.Text = ""
        TextEditBudgetRevision.Text = ""
        TextEditCaptionCover.Text = ""

        LookupBudgetItemSource.EditValue = Nothing
        LookupBudgetItemTarget.EditValue = Nothing
        _sourceResolved = False
        _targetResolved = False
        _sourceCc = String.Empty
        _sourceContract = String.Empty
        _targetCc = String.Empty
        _targetContract = String.Empty

        TextEditEstimationSource.Text = "0"
        TextEditBudgetAmtSource.Text = "0"
        TextEditBudgetAmtTarget.Text = "0"
        TextEditActualUpSource.Text = "0"
        TextEditActualUpTarget.Text = "0"
        TextEditShortageSource.Text = "0"
        TextEditReclassAmount.Text = "0"
        TextEditBalanceTarget.Text = "0"
        TextEditTotalReclass.Text = "0"

        DateEditScheduleFrom.EditValue = Nothing
        DateEditScheduleTo.EditValue = Nothing

        PictureEditAttachCover.Image = Nothing
        PictureEditAttachCover.Properties.NullText = "Double-click to choose a file"

        BtnSave.Text = "Save"
        Me.Text = "E-Form AFA Reclass Budget"
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

End Class