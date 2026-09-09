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
    Private ReadOnly _pc As String = Net.Dns.GetHostName()

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

    Private Sub LoadDocument(ByVal afaNo As String)
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim ds As DataSet = _service.GetHeaderForEdit(afaNo)

            If ds Is Nothing Then
                XtraMessageBox.Show("AFA " & afaNo & " was not found.", "E-Form AFA Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextEditAFANo.Text = ""
                Return
            End If

            Dim header As DataRow = ds.Tables(0).Rows(0)

            If Convert.ToString(header("AFA_TYPE")) <> "INF" Then
                XtraMessageBox.Show("AFA " & afaNo & " is not an Information type document.",
                                    "E-Form AFA Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextEditAFANo.Text = ""
                Return
            End If

            Dim sts As String = Convert.ToString(header("STS"))
            If sts <> "Draft" AndAlso sts <> "Cancelled" Then
                XtraMessageBox.Show("This AFA is in circulation (" & sts & ") and cannot be edited directly." & vbCrLf &
                                    "Please cancel it first if it needs revision.",
                                    "E-Form AFA Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextEditAFANo.Text = ""
                Return
            End If

            Dim ownerNik As String = Convert.ToString(header("USERID"))
            If ownerNik <> _nik Then
                XtraMessageBox.Show("Only the drafter who created this AFA can edit it.",
                                    "E-Form AFA Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextEditAFANo.Text = ""
                Return
            End If

            _afaNo = afaNo

            SetComboByValue(SelectLocation, _dtLocation, "CODE", header("AFA_LOCATION"))
            SetComboByValue(SelectDepartment, _dtDepartment, "DEPT_ID", header("DEPT_ID"))

            TextEditSubject.Text = Convert.ToString(header("SUBJECT"))
            MemoEditPurpose.Text = Convert.ToString(header("PURPOSES"))
            MemoEditBgExp.Text = Convert.ToString(header("BG_EXPLANATION"))

            Dim curIdx As Integer = SelectCurrency.Properties.Items.IndexOf(Convert.ToString(header("CURCODE")))
            SelectCurrency.SelectedIndex = curIdx

            DateEditScheduleFrom.EditValue = If(header("AFA_PER_FROM") Is DBNull.Value, Nothing, header("AFA_PER_FROM"))
            DateEditScheduleTo.EditValue = If(header("AFA_PER_TO") Is DBNull.Value, Nothing, header("AFA_PER_TO"))

            TextEditAFADate.Text = If(header("AFA_DATE") Is DBNull.Value, "",
                                      Convert.ToDateTime(header("AFA_DATE")).ToString("dd MMM yyyy"))

            ' --- Attachment Cover existing (Table 1) ---
            PictureEditAttachmentCover.Image = Nothing
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
                                PictureEditAttachmentCover.Image = New Bitmap(tempImg)
                            End Using
                        Catch
                            ' abaikan - kalau file cover lama gagal dibuka, biarkan kosong
                        End Try
                    End If
                End If

                TextEditCaptionCover.Text = Convert.ToString(attRow("CAPTION"))
            End If

            ' --- Detail spesifik INF (Table 2) ---
            If ds.Tables.Count > 2 AndAlso ds.Tables(2).Rows.Count > 0 Then
                Dim detailRow As DataRow = ds.Tables(2).Rows(0)
                SetComboByValue(SelectType, _dtSubType, "CODE", detailRow("SUB_TYPE"))
                TextEditEstimateCost.Text = Convert.ToString(detailRow("ESTIMATE_COST"))
            End If

            Me.Text = "E-Form AFA Information - " & afaNo & " (Edit)"
            BtnSave.Text = "Update"
        Finally
            Cursor.Current = Cursors.Default
        End Try
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

        If SelectType.SelectedIndex < 0 Then
            Warn("Please select a Type.", SelectType) : Return False
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

            Dim sriStatus As String = _service.ApplySRI(_afaNo)

            Try
                Clipboard.SetText(_afaNo)
            Catch

            End Try

            Dim summary As String = "Document saved." & vbCrLf & "AFA No: " & _afaNo & vbCrLf
            If sriStatus <> "" Then summary &= "SRI: " & sriStatus & vbCrLf
            summary &= vbCrLf & "The AFA number has been copied to the clipboard."

            XtraMessageBox.Show(summary, "E-Form AFA Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Text = "E-Form AFA Information - " & _afaNo
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
            ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp"

            If ofd.ShowDialog() <> DialogResult.OK Then Return

            Dim ext As String = Path.GetExtension(ofd.FileName).ToLowerInvariant()
            If ext <> ".jpg" AndAlso ext <> ".jpeg" AndAlso ext <> ".png" AndAlso ext <> ".bmp" Then
                XtraMessageBox.Show("Cover must be an image file (JPG, PNG or BMP).",
                                    "E-Form AFA Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            _attachmentPath = ofd.FileName
            PictureEditAttachmentCover.Image = Image.FromFile(ofd.FileName)
        End Using
    End Sub

#End Region

#Region "Helpers"

    Private Sub ClearForm()
        _afaNo = String.Empty
        _attachmentPath = String.Empty

        TextEditAFANo.Text = ""
        TextEditAFADate.Text = ""
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

        BtnSave.Text = "Save"
        Me.Text = "E-Form AFA Information"
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

End Class