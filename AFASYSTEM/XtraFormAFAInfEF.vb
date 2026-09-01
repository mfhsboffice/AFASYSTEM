Imports System.Data
Imports System.IO
Imports DevExpress.XtraEditors

Public Class XtraFormAFAInfEF

    Private ReadOnly _service As New AFAInformationService()
    Private ReadOnly _general As New GeneralService()

    Private _dtDepartment As DataTable
    Private _dtLocation As DataTable
    Private _dtSubType As DataTable
    Private _dtCurrency As DataTable

    Private _afaNo As String = String.Empty
    Private _attachmentPath As String = String.Empty

    Private ReadOnly _nik As String = Trim(FormFluMenu.btnuserid.Caption)
    Private ReadOnly _pc As String = System.Net.Dns.GetHostName()

#Region "Form"

    Private Sub XtraFormAFAInfEF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupEditors()
        LoadCombos()
        ClearForm()
    End Sub

    Private Sub SetupEditors()
        With TextEditEstimateCost.Properties
            .Appearance.Options.UseTextOptions = True
            .Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
            .MaskSettings.Set("mask", "n0")
            .UseMaskAsDisplayFormat = True
        End With

        With TextEditBudgetYear.Properties
            .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
            .MaskSettings.Set("mask", "d")
            .MaxLength = 4
        End With

        PictureEditAttachmentCover.Properties.NullText = "Double-click to choose a file"
        PictureEditAttachmentCover.Properties.ShowMenu = False
    End Sub

#End Region

#Region "Combo"

    Private Sub LoadCombos()
        LoadDepartment()
        LoadLocation()
        LoadSubType()
        LoadCurrency()

        TextEditBudgetYear.Text = Date.Today.Year.ToString()
    End Sub

    Private Sub LoadDepartment()
        _dtDepartment = _general.GetDepartmentsByNik(_nik)

        SelectDepartment.Properties.Items.Clear()

        If _dtDepartment Is Nothing OrElse _dtDepartment.Rows.Count = 0 Then
            XtraMessageBox.Show("NIK " & _nik & " is not mapped to any department." & vbCrLf &
                                "Please ask an administrator to set up the User Department Mapping.",
                                "E-Form AFA Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    Private Sub LoadSubType()
        _dtSubType = _general.GetSubTypes("INF")
        SelectType.Properties.Items.Clear()

        If _dtSubType Is Nothing Then Return

        For Each row As DataRow In _dtSubType.Rows
            SelectType.Properties.Items.Add(Convert.ToString(row("NAME")))
        Next
    End Sub

    Private Sub LoadCurrency()
        _dtCurrency = _general.GetCurrencies()
        SelectCurrency.Properties.Items.Clear()

        If _dtCurrency Is Nothing Then Return

        For Each row As DataRow In _dtCurrency.Rows
            SelectCurrency.Properties.Items.Add(Convert.ToString(row("CURCODE")))
        Next

        Dim idx As Integer = SelectCurrency.Properties.Items.IndexOf("IDR")
        If idx >= 0 Then SelectCurrency.SelectedIndex = idx
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

        If SelectType.SelectedIndex < 0 Then
            Warn("Please select a Type.", SelectType) : Return False
        End If

        Dim tahun As Integer
        If Not Integer.TryParse(TextEditBudgetYear.Text.Trim(), tahun) OrElse tahun < 2000 OrElse tahun > 2999 Then
            Warn("Budget Year must be a four-digit number.", TextEditBudgetYear) : Return False
        End If

        If TextEditSubject.Text.Trim() = "" Then
            Warn("Subject is required.", TextEditSubject) : Return False
        End If

        If SelectCurrency.SelectedIndex < 0 Then
            Warn("Please select a Currency.", SelectCurrency) : Return False
        End If

        If DateEditScheduleFrom.EditValue IsNot Nothing AndAlso DateEditScheduleTo.EditValue IsNot Nothing Then
            If DateEditScheduleTo.DateTime < DateEditScheduleFrom.DateTime Then
                Warn("Schedule To cannot be earlier than Schedule From.", DateEditScheduleTo) : Return False
            End If
        End If

        Return True
    End Function

    Private Sub Warn(ByVal message As String, ByVal ctl As Control)
        XtraMessageBox.Show(message, "E-Form AFA Information",
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
            Dim curCode As String = SelectCurrency.Text.Trim()

            Dim perFrom As Object = If(DateEditScheduleFrom.EditValue Is Nothing, Nothing, DateEditScheduleFrom.DateTime.Date)
            Dim perTo As Object = If(DateEditScheduleTo.EditValue Is Nothing, Nothing, DateEditScheduleTo.DateTime.Date)

            Dim savedNo As String = _service.SaveHeader(
                _afaNo, locCode, deptId,
                TextEditBudgetYear.Text.Trim(), Nothing,
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

            Dim subType As String = Convert.ToString(GetSelectedValue(SelectType, _dtSubType, "CODE"))
            Dim estimate As Decimal = 0D
            Decimal.TryParse(TextEditEstimateCost.Text, estimate)

            Dim codeBudget As String = Nothing

            If Not _service.SaveDetail(_afaNo, subType, codeBudget, estimate, _nik, _pc) Then
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

            XtraMessageBox.Show("Document saved." & vbCrLf & "AFA No: " & _afaNo,
                                "E-Form AFA Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Text = "E-Form AFA Information - " & _afaNo
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
        Dim ext As String = Path.GetExtension(sourcePath)

        Return String.Format("{0}_{1}_{2}_{3}{4}", safeAfa, attachmentType, stamp, _nik, ext)
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

    Private Sub PictureEditAttachmentCover_DoubleClick(sender As Object, e As EventArgs) _
            Handles PictureEditAttachmentCover.DoubleClick
        Using ofd As New OpenFileDialog()
            ofd.Title = "Choose an attachment"
            ofd.Filter = "All supported files|*.jpg;*.jpeg;*.png;*.bmp;*.pdf;*.xlsx;*.xls;*.docx;*.doc|" &
                         "Images|*.jpg;*.jpeg;*.png;*.bmp|PDF|*.pdf|Excel|*.xlsx;*.xls|Word|*.docx;*.doc"

            If ofd.ShowDialog() <> DialogResult.OK Then Return

            _attachmentPath = ofd.FileName
            Dim ext As String = Path.GetExtension(ofd.FileName).ToLowerInvariant()
            If ext = ".jpg" OrElse ext = ".jpeg" OrElse ext = ".png" OrElse ext = ".bmp" Then
                PictureEditAttachmentCover.Image = Image.FromFile(ofd.FileName)
            Else
                PictureEditAttachmentCover.Image = Nothing
                PictureEditAttachmentCover.Properties.NullText = Path.GetFileName(ofd.FileName)
            End If

        End Using
    End Sub

#End Region

#Region "Helpers"

    Private Sub ClearForm()
        _afaNo = String.Empty
        _attachmentPath = String.Empty

        SelectLocation.SelectedIndex = -1
        SelectType.SelectedIndex = -1
        TextEditSubject.Text = ""
        MemoEditPurpose.Text = ""
        MemoEditBgExp.Text = ""
        TextEditEstimateCost.Text = "0"
        TextEditCaptionCover.Text = ""
        DateEditScheduleFrom.EditValue = Nothing
        DateEditScheduleTo.EditValue = Nothing
        PictureEditAttachmentCover.Image = Nothing
        PictureEditAttachmentCover.Properties.NullText = "Double-click to choose a file"

        Me.Text = "E-Form AFA Information"
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

End Class