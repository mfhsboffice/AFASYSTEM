Imports System.Data
Imports System.IO
Imports DevExpress.XtraEditors

Public Class XtraFormAFAAddEForm

    Private ReadOnly _service As New AFAAdditionalBudgetService()
    Private ReadOnly _general As New GeneralService()

    Private _dtDepartment As DataTable
    Private _dtLocation As DataTable
    Private _dtBudgetAllocation As DataTable

    Private _afaNo As String = String.Empty
    Private _attachmentPath As String = String.Empty

    Private _itemCc As String = String.Empty
    Private _itemContract As String = String.Empty
    Private _itemResolved As Boolean = False

    Private ReadOnly _nik As String = Trim(FormFluMenu.btnuserid.Caption)
    Private ReadOnly _pc As String = System.Net.Dns.GetHostName()

#Region "Form"

    Private Sub XtraFormAFAAddEForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupEditors()
        LoadCombos()
        ClearForm()
        LoadBudgetAllocation()
    End Sub

    Private Sub SetupEditors()
        For Each editor As TextEdit In New TextEdit() {TextEditBudgetAmt, TextEditActualUp,
                                                       TextEditShortage, TextEditTotalAdditional}
            With editor.Properties
                .ReadOnly = True
                .Appearance.Options.UseTextOptions = True
                .Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
                .MaskSettings.Set("mask", "n2")
                .UseMaskAsDisplayFormat = True
            End With
        Next

        With TextEditEstimation.Properties
            .Appearance.Options.UseTextOptions = True
            .Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
            .MaskSettings.Set("mask", "n2")
            .UseMaskAsDisplayFormat = True
        End With

        With TextEdit1.Properties
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

        TextEdit1.Text = Date.Today.Year.ToString()
    End Sub

    Private Sub LoadDepartment()
        _dtDepartment = _general.GetDepartmentsByNik(_nik)

        SelectDepartment.Properties.Items.Clear()

        If _dtDepartment Is Nothing OrElse _dtDepartment.Rows.Count = 0 Then
            XtraMessageBox.Show("NIK " & _nik & " is not mapped to any department." & vbCrLf &
                                "Please ask an administrator to set up the User Department Mapping.",
                                "E-Form AFA Additional Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

#End Region

#Region "Budget Item Lookup"

    Private Sub LoadBudgetAllocation()
        _dtBudgetAllocation = _service.GetBudgetAllocation(TextEdit1.Text.Trim(), TextEdit2.Text.Trim())

        BindBudgetItemLookup(LookupBudgetItem)
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

    Private Sub TextEdit1_Leave(sender As Object, e As EventArgs) Handles TextEdit1.Leave
        LoadBudgetAllocation()
    End Sub

    Private Sub TextEdit2_Leave(sender As Object, e As EventArgs) Handles TextEdit2.Leave
        LoadBudgetAllocation()
    End Sub

    Private Sub LookupBudgetItem_EditValueChanged(sender As Object, e As EventArgs) Handles LookupBudgetItem.EditValueChanged
        Dim row As DataRow = FindAllocationRow(LookupBudgetItem.EditValue)

        If row Is Nothing Then
            _itemResolved = False
            TextEditBudgetAmt.Text = "0"
            TextEditActualUp.Text = "0"
            _itemCc = String.Empty
            _itemContract = String.Empty
        Else
            _itemResolved = True
            TextEditBudgetAmt.Text = FormatAmount(row("BUDGET_AMOUNT"))
            TextEditActualUp.Text = FormatAmount(row("ACTUAL_UP"))
            _itemCc = Convert.ToString(row("CC"))
            _itemContract = Convert.ToString(row("CONTRACT"))
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

    ''' <summary>
    ''' Instructions for the Designer (not done here - see report): add a
    ''' SimpleButton named BtnSyncBudgetItem next to LookupBudgetItem. It
    ''' calls the placeholder sync procedure.
    ''' </summary>
    Private Sub BtnSyncBudgetItem_Click(sender As Object, e As EventArgs) Handles BtnSyncBudgetItem.Click
        Dim allocation As String = LookupBudgetItem.Text.Trim()

        If allocation = "" Then
            XtraMessageBox.Show("Type or pick an Allocation code first.", "E-Form AFA Additional Budget",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Cursor.Current = Cursors.WaitCursor
        Try
            If _service.SyncBudget(TextEdit1.Text.Trim(), TextEdit2.Text.Trim(), allocation) Then
                LoadBudgetAllocation()
                XtraMessageBox.Show("Sync placeholder ran (no real IFS pull yet - see AFA_NonIFS_SyncBudget_Proc).",
                                    "E-Form AFA Additional Budget", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                XtraMessageBox.Show(_service.LastErrorMessage, "Sync Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Calculation"

    ''' <summary>Mirrors AFA_NonIFS_Recalc_Proc's ADD branch, for an immediate preview.</summary>
    Private Sub Recalculate()
        Dim budget As Decimal = ParseAmount(TextEditBudgetAmt.Text)
        Dim actual As Decimal = ParseAmount(TextEditActualUp.Text)
        Dim estimation As Decimal = ParseAmount(TextEditEstimation.Text)

        Dim shortage As Decimal = budget - actual - estimation
        TextEditShortage.Text = shortage.ToString("n2")
        TextEditTotalAdditional.Text = Math.Abs(shortage).ToString("n2")
    End Sub

    Private Function ParseAmount(ByVal text As String) As Decimal
        Dim value As Decimal
        If Decimal.TryParse(text, value) Then Return value
        Return 0D
    End Function

    Private Sub TextEditEstimation_EditValueChanged(sender As Object, e As EventArgs) Handles TextEditEstimation.EditValueChanged
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
        If Not Integer.TryParse(TextEdit1.Text.Trim(), year) OrElse year < 2000 OrElse year > 2999 Then
            Warn("Budget Year must be a four-digit number.", TextEdit1) : Return False
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

        If LookupBudgetItem.Text.Trim() = "" OrElse Not _itemResolved Then
            Warn("Please pick a valid budget item from the list.", LookupBudgetItem) : Return False
        End If

        If ParseAmount(TextEditEstimation.Text) <= 0 Then
            Warn("Estimation must be greater than zero.", TextEditEstimation) : Return False
        End If

        Return True
    End Function

    Private Sub Warn(ByVal message As String, ByVal ctl As Control)
        XtraMessageBox.Show(message, "E-Form AFA Additional Budget",
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

            ' ADD has no currency selector on this form either: additional
            ' budget figures come from IFS in USD, matching AFA_NON_IFS.CURCODE's
            ' default and BUDGET_CURR_RATE being USD-based.
            Dim curCode As String = "USD"

            Dim perFrom As Object = If(DateEditScheduleFrom.EditValue Is Nothing, Nothing, DateEditScheduleFrom.DateTime.Date)
            Dim perTo As Object = If(DateEditScheduleTo.EditValue Is Nothing, Nothing, DateEditScheduleTo.DateTime.Date)

            Dim savedNo As String = _service.SaveHeader(
                _afaNo, locCode, deptId,
                TextEdit1.Text.Trim(), TextEdit2.Text.Trim(),
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

            Dim itemCode As String = LookupBudgetItem.Text.Trim()
            Dim savedSeq As Integer = 0

            If Not _service.SaveDetail(_afaNo, 0, itemCode, itemCode, _itemCc, _itemContract,
                                       ParseAmount(TextEditBudgetAmt.Text),
                                       ParseAmount(TextEditActualUp.Text),
                                       ParseAmount(TextEditEstimation.Text),
                                       _nik, _pc, savedSeq) Then
                XtraMessageBox.Show("The header was saved as " & _afaNo & "," & vbCrLf &
                                    "but the detail could not be saved:" & vbCrLf & _service.LastErrorMessage,
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
                                "E-Form AFA Additional Budget", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Text = "E-Form AFA Additional Budget - " & _afaNo
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
                                    "E-Form AFA Additional Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        SelectLocation.SelectedIndex = -1
        TextEditSubject.Text = ""
        MemoEditPurpose.Text = ""
        MemoEditBgExp.Text = ""
        TextEditCaptionCover.Text = ""
        TextEdit2.Text = ""

        LookupBudgetItem.EditValue = Nothing
        _itemResolved = False
        _itemCc = String.Empty
        _itemContract = String.Empty

        TextEditEstimation.Text = "0"
        TextEditBudgetAmt.Text = "0"
        TextEditActualUp.Text = "0"
        TextEditShortage.Text = "0"
        TextEditTotalAdditional.Text = "0"

        DateEditScheduleFrom.EditValue = Nothing
        DateEditScheduleTo.EditValue = Nothing
        PictureEditAttachCover.Image = Nothing
        PictureEditAttachCover.Properties.NullText = "Double-click to choose a file"

        Me.Text = "E-Form AFA Additional Budget"
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

End Class
