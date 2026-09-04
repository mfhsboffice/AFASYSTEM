Imports System.Data
Imports System.IO
Imports DevExpress.XtraEditors

Public Class XtraFormAFADaaEForm

    Private ReadOnly _service As New AFADisposalService()
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

    Private Sub XtraFormAFADaaEForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupEditors()
        LoadCombos()
        ClearForm()
    End Sub

    Private Sub SetupEditors()
        For Each editor As TextEdit In New TextEdit() {TextEditAcquisition, TextEditAccumDep,
                                                       TextEditBookValue, TextEditResellValue,
                                                       TextEditProfitLoss}
            With editor.Properties
                .Appearance.Options.UseTextOptions = True
                .Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
                .MaskSettings.Set("mask", "n0")
                .UseMaskAsDisplayFormat = True
            End With
        Next

        TextEditBookValue.Properties.ReadOnly = True
        TextEditProfitLoss.Properties.ReadOnly = True

        PictureEditAttachCover.Properties.NullText = "Double-click to choose a file"
        PictureEditAttachCover.Properties.ShowMenu = False
    End Sub

#End Region

#Region "Combo"

    Private Sub LoadCombos()
        LoadDepartment()
        LoadLocation()
        LoadSubType()
        LoadCurrency()
    End Sub

    Private Sub LoadDepartment()
        _dtDepartment = _general.GetDepartmentsByNik(_nik)

        SelectDepartment.Properties.Items.Clear()

        If _dtDepartment Is Nothing OrElse _dtDepartment.Rows.Count = 0 Then
            XtraMessageBox.Show("NIK " & _nik & " is not mapped to any department." & vbCrLf &
                                "Please ask an administrator to set up the User Department Mapping.",
                                "E-Form AFA Disposal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        _dtSubType = _general.GetSubTypes("DAA")
        SelectAssetFlag.Properties.Items.Clear()

        If _dtSubType Is Nothing Then Return

        For Each row As DataRow In _dtSubType.Rows
            SelectAssetFlag.Properties.Items.Add(Convert.ToString(row("NAME")))
        Next

        If SelectAssetFlag.Properties.Items.Count > 0 Then SelectAssetFlag.SelectedIndex = 0
    End Sub

    Private Sub LoadCurrency()
        _dtCurrency = _general.GetCurrencies()
        SelectCurrency.Properties.Items.Clear()

        If _dtCurrency Is Nothing Then Return

        For Each row As DataRow In _dtCurrency.Rows
            SelectCurrency.Properties.Items.Add(Convert.ToString(row("CURCODE")))
        Next

        SelectDefaultCurrency()
    End Sub

    Private Sub SelectDefaultCurrency()
        Dim idx As Integer = SelectCurrency.Properties.Items.IndexOf("USD")
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

#Region "Calculation"

    Private Sub Recalculate()
        Dim acquisition As Decimal = ParseAmount(TextEditAcquisition.Text)
        Dim accumDep As Decimal = ParseAmount(TextEditAccumDep.Text)
        Dim resell As Decimal = ParseAmount(TextEditResellValue.Text)

        Dim bookValue As Decimal = acquisition - accumDep
        Dim profitLoss As Decimal = bookValue - resell

        TextEditBookValue.Text = bookValue.ToString("n0")
        TextEditProfitLoss.Text = profitLoss.ToString("n0")
    End Sub

    Private Function ParseAmount(ByVal text As String) As Decimal
        Dim value As Decimal
        If Decimal.TryParse(text, value) Then Return value
        Return 0D
    End Function

    Private Sub Amount_EditValueChanged(sender As Object, e As EventArgs) _
            Handles TextEditAcquisition.EditValueChanged,
                    TextEditAccumDep.EditValueChanged,
                    TextEditResellValue.EditValueChanged
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

        If SelectAssetFlag.SelectedIndex < 0 Then
            Warn("Please select Asset or Non Asset.", SelectAssetFlag) : Return False
        End If

        If SelectCurrency.SelectedIndex < 0 Then
            Warn("Please select a Currency.", SelectCurrency) : Return False
        End If

        If TextEditSubject.Text.Trim() = "" Then
            Warn("Subject is required.", TextEditSubject) : Return False
        End If

        If MemoEditBgExp.Text.Trim() = "" Then
            Warn("Background & Explanation is required. Describe the asset being disposed of here.",
                 MemoEditBgExp)
            Return False
        End If

        If ParseAmount(TextEditAccumDep.Text) > ParseAmount(TextEditAcquisition.Text) Then
            Warn("Accumulation Depreciation cannot exceed Acquisition.", TextEditAccumDep) : Return False
        End If

        If DateEditScheduleFrom.EditValue IsNot Nothing AndAlso DateEditScheduleTo.EditValue IsNot Nothing Then
            If DateEditScheduleTo.DateTime < DateEditScheduleFrom.DateTime Then
                Warn("Schedule To cannot be earlier than Schedule From.", DateEditScheduleTo) : Return False
            End If
        End If

        Return True
    End Function

    Private Sub Warn(ByVal message As String, ByVal ctl As Control)
        XtraMessageBox.Show(message, "E-Form AFA Disposal",
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

            Dim perFrom As Object = If(DateEditScheduleFrom.EditValue Is Nothing, Nothing, DateEditScheduleFrom.DateTime.Date)
            Dim perTo As Object = If(DateEditScheduleTo.EditValue Is Nothing, Nothing, DateEditScheduleTo.DateTime.Date)

            Dim curCode As String = SelectCurrency.Text.Trim()

            Dim savedNo As String = _service.SaveHeader(
                _afaNo, locCode, deptId,
                Now.Year.ToString(), Nothing,
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

            Dim subType As String = Convert.ToString(GetSelectedValue(SelectAssetFlag, _dtSubType, "CODE"))

            If Not _service.SaveDetail(_afaNo, subType,
                                       ParseAmount(TextEditAcquisition.Text),
                                       ParseAmount(TextEditAccumDep.Text),
                                       ParseAmount(TextEditResellValue.Text),
                                       _nik, _pc) Then
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

            Dim sriStatus As String = _service.ApplySRI(_afaNo)

            Try
                Clipboard.SetText(_afaNo)
            Catch

            End Try

            Dim summary As String = "Document saved." & vbCrLf & "AFA No: " & _afaNo & vbCrLf
            If sriStatus <> "" Then summary &= "SRI: " & sriStatus & vbCrLf
            summary &= vbCrLf & "The AFA number has been copied to the clipboard."

            XtraMessageBox.Show(summary, "E-Form AFA Disposal",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Text = "E-Form AFA Disposal Asset / Non Asset - " & _afaNo
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
                                    "E-Form AFA Disposal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        SelectDefaultCurrency()
        TextEditSubject.Text = ""
        MemoEditPurpose.Text = ""
        MemoEditBgExp.Text = ""
        TextEditCaptionCover.Text = ""

        TextEditAcquisition.Text = "0"
        TextEditAccumDep.Text = "0"
        TextEditResellValue.Text = "0"
        Recalculate()

        DateEditScheduleFrom.EditValue = Nothing
        DateEditScheduleTo.EditValue = Nothing
        PictureEditAttachCover.Image = Nothing
        PictureEditAttachCover.Properties.NullText = "Double-click to choose a file"

        Me.Text = "E-Form AFA Disposal Asset / Non Asset"
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

End Class