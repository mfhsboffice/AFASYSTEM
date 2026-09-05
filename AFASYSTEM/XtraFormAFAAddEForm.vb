Imports System.Data
Imports System.IO
Imports DevExpress.XtraEditors

Public Class XtraFormAFAAddEForm

    Private ReadOnly _service As New AFAAdditionalBudgetService()
    Private ReadOnly _general As New GeneralService()

    Private _dtDepartment As DataTable
    Private _dtLocation As DataTable

    Private _afaNo As String = String.Empty
    Private _attachmentPath As String = String.Empty

    Private ReadOnly _nik As String = Trim(FormFluMenu.btnuserid.Caption)
    Private ReadOnly _pc As String = System.Net.Dns.GetHostName()

#Region "Form"

    Private Sub XtraFormAFAAddEForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupEditors()
        LoadCombos()
        ClearForm()
    End Sub

    Private Sub SetupEditors()
        For Each editor As TextEdit In New TextEdit() {TextEditBudgetAmt, TextEditActualUp,
                                                       TextEditShortage, TextEditTotalAdditional}
            With editor.Properties
                .ReadOnly = True
                .Appearance.Options.UseTextOptions = True
                .Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
                .MaskSettings.Set("mask", "n0")
                .UseMaskAsDisplayFormat = True
            End With
        Next

        With TextEditEstimation.Properties
            .Appearance.Options.UseTextOptions = True
            .Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
            .MaskSettings.Set("mask", "n0")
            .UseMaskAsDisplayFormat = True
        End With

        ' TextEdit1 = Budget Year, TextEdit2 = Budget Rev (confirmed by
        ' LciBudgetYear.Control / LciBudgetRev.Control in the Designer -
        ' both were left with their DevExpress-generated default names)
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

            ' The budget-item lookup (LookupBudgetItem) has no data source wired
            ' to it: there is no procedure in this module that can browse budget
            ' items from IFS (AFA_NonIFS_GetBudgetFromIFS_Proc needs an exact
            ' CC/Contract/Allocation key, which nothing on this form collects),
            ' and TextEditBudgetAmt / TextEditActualUp are locked ReadOnly with
            ' no way to populate them. Saving the detail row here would mean
            ' writing BUDGET_AMOUNT = 0 and ACTUAL_UP = 0 into a financial
            ' document, so this step is refused rather than done silently.
            ' AFA_NonIFS_Submit_Proc already blocks Submit while the detail
            ' rows are empty, so the document is safe to leave as a Draft
            ' until the lookup is implemented.
            XtraMessageBox.Show(
                "Header saved as " & _afaNo & "." & vbCrLf & vbCrLf &
                "The budget item lookup is not wired up yet, so the budget " &
                "item detail could not be saved. This document will stay as " &
                "Draft until that is implemented.",
                "E-Form AFA Additional Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)

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

    Private Sub ClearForm()
        _afaNo = String.Empty
        _attachmentPath = String.Empty

        SelectLocation.SelectedIndex = -1
        TextEditSubject.Text = ""
        MemoEditPurpose.Text = ""
        MemoEditBgExp.Text = ""
        TextEditCaptionCover.Text = ""
        TextEdit2.Text = ""

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
