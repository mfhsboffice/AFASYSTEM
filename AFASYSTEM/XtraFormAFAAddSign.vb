Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository


Public Class XtraFormAFAAddSign

    Private ReadOnly _signature As New AFASignatureService()
    Private ReadOnly _general As New GeneralService()

    Private _dtNodes As DataTable
    Private _dtAuth As DataTable
    Private _dtSupp As DataTable
    Private _dtDir As DataTable
    Private _dtPriority As DataTable

    Private _afaNo As String = String.Empty
    Private _headerStatus As String = String.Empty
    Private _sriStatus As String = String.Empty

    Private _attachment1Path As String = String.Empty
    Private _attachment2Path As String = String.Empty

    Private Const MaxSlot As Integer = 10

    Private ReadOnly _nik As String = Trim(FormFluMenu.btnuserid.Caption)
    Private ReadOnly _pc As String = System.Net.Dns.GetHostName()

#Region "Form"

    Private Sub XtraFormAFAAddSign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupEditors()
        SetupGrid()
        LoadApproverLists()
        LoadPriority()
        SetButtonState(False)
    End Sub


    Public Sub LoadDocument(ByVal afaNo As String)
        TextEditAfaNo.Text = afaNo
        LoadAll(afaNo)
    End Sub

#End Region

#Region "Setup"

    Private Sub SetupEditors()
        For Each editor As TextEdit In New TextEdit() {TextEditBudgetAmt, TextEditActualUp,
                                                       TextEditEstimation, TextEditShortage,
                                                       TextEditTotalAdditional}
            With editor.Properties
                .ReadOnly = True
                .Appearance.Options.UseTextOptions = True
                .Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
                .MaskSettings.Set("mask", "n0")
                .UseMaskAsDisplayFormat = True
            End With
        Next

        TextEditBudgetItem.Properties.ReadOnly = True

        ButtonEditAttachment1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        ButtonEditAttachment2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
    End Sub

    Private Sub LoadPriority()
        _dtPriority = _general.GetPriorities()

        SelectPriority.Properties.Items.Clear()
        For Each row As DataRow In _dtPriority.Rows
            SelectPriority.Properties.Items.Add(Convert.ToString(row("NAME")))
        Next
        SelectPriority.SelectedIndex = 0
    End Sub

    Private Sub SetupGrid()
        With GridViewSignature
            .OptionsView.ShowGroupPanel = False
            .OptionsBehavior.Editable = True
        End With
    End Sub

    Private Function BuildApproverLookup(ByVal source As DataTable) As RepositoryItemLookUpEdit
        Dim lookup As New RepositoryItemLookUpEdit()

        lookup.DataSource = source
        lookup.DisplayMember = "NAMA"
        lookup.ValueMember = "NIK"
        lookup.NullText = ""
        lookup.PopulateColumns()

        If lookup.Columns("NIK") IsNot Nothing Then lookup.Columns("NIK").Width = 60
        If lookup.Columns("JAB") IsNot Nothing Then lookup.Columns("JAB").Width = 130

        Return lookup
    End Function

    Private Sub LoadApproverLists()
        _dtAuth = _signature.GetApprovers("Auth")
        _dtSupp = _signature.GetApprovers("Supp")
        _dtDir = _signature.GetApprovers("Dir")

        If _dtAuth Is Nothing OrElse _dtSupp Is Nothing OrElse _dtDir Is Nothing Then
            XtraMessageBox.Show("The approver lists could not be loaded." & vbCrLf &
                                _signature.LastErrorMessage,
                                "Signature AFA Additional Budget",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ConfigureGridColumns()
        With GridViewSignature
            If .Columns.Count = 0 Then Return

            For Each hidden As String In New String() {"Authorized", "Supporting", "Direct",
                                                        "Sts_Auth", "Sts_Supp", "Sts_Dir",
                                                        "App_Auth", "App_Supp", "App_Dir"}
                If .Columns(hidden) IsNot Nothing Then .Columns(hidden).Visible = False
            Next

            If .Columns("Urut") IsNot Nothing Then
                .Columns("Urut").Caption = "No"
                .Columns("Urut").Width = 40
                .Columns("Urut").OptionsColumn.AllowEdit = False
            End If

            ConfigureApproverColumn("Auth_NIK", "Authorized", 200, _dtAuth)
            ConfigurePositionColumn("Auth_Jab", "Auth_Jab", 140)
            ConfigureApproverColumn("Supp_NIK", "Supporting", 200, _dtSupp)
            ConfigurePositionColumn("Supp_Jab", "Supp_Jab", 140)
            ConfigureApproverColumn("Dir_NIK", "Direct", 200, _dtDir)
            ConfigurePositionColumn("Dir_Jab", "Dir_Jab", 140)
        End With
    End Sub

    Private Sub ConfigureApproverColumn(ByVal fieldName As String,
                                        ByVal caption As String,
                                        ByVal width As Integer,
                                        ByVal source As DataTable)
        Dim col = GridViewSignature.Columns(fieldName)
        If col Is Nothing Then Return

        col.Caption = caption
        col.Width = width
        col.ColumnEdit = BuildApproverLookup(source)
    End Sub

    Private Sub ConfigurePositionColumn(ByVal fieldName As String,
                                        ByVal caption As String,
                                        ByVal width As Integer)
        Dim col = GridViewSignature.Columns(fieldName)
        If col Is Nothing Then Return

        col.Caption = caption
        col.Width = width
        col.OptionsColumn.AllowEdit = False
    End Sub

#End Region

#Region "Load"

    Private Sub LoadAll(ByVal afaNo As String)
        If afaNo.Trim() = "" Then Return

        Cursor.Current = Cursors.WaitCursor
        Try
            Dim dtHeader As DataTable = _signature.GetDocument(afaNo)

            If dtHeader Is Nothing OrElse dtHeader.Rows.Count = 0 Then
                XtraMessageBox.Show("AFA " & afaNo & " was not found in this module.",
                                    "Signature AFA Additional Budget",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ClearForm()
                Return
            End If

            Dim row As DataRow = dtHeader.Rows(0)

            If Convert.ToString(row("AFA_TYPE")) <> "ADD" Then
                XtraMessageBox.Show("AFA " & afaNo & " is not an Additional Budget document.",
                                    "Signature AFA Additional Budget",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ClearForm()
                Return
            End If

            _afaNo = Convert.ToString(row("AFA_NO"))
            _headerStatus = Convert.ToString(row("STS"))

            TextEditAfaNo.Text = _afaNo

            LoadFigures()

            Dim priority As Integer = If(IsDBNull(row("PRIORITY")), 0, Convert.ToInt32(row("PRIORITY")))
            SelectPriority.SelectedIndex = priority

            _sriStatus = If(IsDBNull(row("SRI_STS")), "", Convert.ToString(row("SRI_STS")))

            LoadNodes()
            LoadAttachments()
            SetButtonState(True)

            Me.Text = "Signature AFA Additional Budget - " & _afaNo &
                      " (" & _headerStatus & ")" &
                      If(_sriStatus = "", "", "  SRI: " & _sriStatus)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub LoadNodes()
        GridControlSignature.DataSource = Nothing

        _dtNodes = _signature.GetNodesGrid(_afaNo, MaxSlot)
        If _dtNodes Is Nothing OrElse _dtNodes.Rows.Count = 0 Then
            If _signature.InitNodes(_afaNo, MaxSlot, _nik, _pc) Then
                _dtNodes = _signature.GetNodesGrid(_afaNo, MaxSlot)
            Else
                XtraMessageBox.Show("The approval nodes could not be prepared:" & vbCrLf &
                                    _signature.LastErrorMessage,
                                    "Signature AFA Additional Budget",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        If _dtNodes Is Nothing Then Return

        GridControlSignature.DataSource = _dtNodes
        ConfigureGridColumns()
    End Sub

    Private Sub LoadFigures()
        Dim dt As DataTable = _signature.GetAdditionalFigures(_afaNo)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            ClearFigures()
            Return
        End If

        Dim row As DataRow = dt.Rows(0)

        TextEditBudgetItem.Text = Convert.ToString(row("BUDGET_ITEM_CODE"))
        TextEditBudgetAmt.Text = FormatAmount(row("BUDGET_AMOUNT"))
        TextEditActualUp.Text = FormatAmount(row("ACTUAL_UP"))
        TextEditEstimation.Text = FormatAmount(row("ESTIMATION"))
        TextEditShortage.Text = FormatAmount(row("SHORTAGE"))
        TextEditTotalAdditional.Text = FormatAmount(row("ESTIMATION"))
    End Sub

    Private Sub ClearFigures()
        TextEditBudgetItem.Text = ""
        TextEditBudgetAmt.Text = "0"
        TextEditActualUp.Text = "0"
        TextEditEstimation.Text = "0"
        TextEditShortage.Text = "0"
        TextEditTotalAdditional.Text = "0"
    End Sub

    Private Function FormatAmount(ByVal value As Object) As String
        If value Is Nothing OrElse IsDBNull(value) Then Return "0"
        Return Convert.ToDecimal(value).ToString("n0")
    End Function

    Private Sub LoadAttachments()
        _attachment1Path = String.Empty
        _attachment2Path = String.Empty
        ButtonEditAttachment1.Text = String.Empty
        ButtonEditAttachment2.Text = String.Empty

        Dim dt As DataTable = _signature.GetAttachments(_afaNo)
        If dt Is Nothing Then Return

        Dim slot As Integer = 0

        For Each row As DataRow In dt.Rows
            If Convert.ToString(row("TYPE")) = "Cover" Then Continue For

            slot += 1
            Dim label As String = Convert.ToString(row("FILE_PATH"))
            Dim caption As String = Convert.ToString(row("CAPTION")).Trim()
            If caption <> "" Then label = caption & "  [" & label & "]"

            If slot = 1 Then ButtonEditAttachment1.Text = label
            If slot = 2 Then ButtonEditAttachment2.Text = label
            If slot >= 2 Then Exit For
        Next
    End Sub

    Private Function BuildStoredFileName(ByVal slot As Integer, ByVal sourcePath As String) As String
        Dim safeAfa As String = _afaNo.Replace("/", "-").Replace("\", "-")
        Dim stamp As String = DateTime.Now.ToString("yyyyMMddHHmmssfff")

        Return String.Format("{0}_Lampiran{1}_{2}_{3}{4}",
                             safeAfa, slot, stamp, _nik, Path.GetExtension(sourcePath))
    End Function

    Private Function UploadAttachment(ByVal sourcePath As String, ByVal slot As Integer) As String
        Dim serverPath As String = Trim(FormFluMenu.btnlink.Caption)

        If serverPath = "" Then
            XtraMessageBox.Show("The document server path is not configured.",
                                "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return String.Empty
        End If

        Dim storedName As String = BuildStoredFileName(slot, sourcePath)

        Try
            File.Copy(sourcePath, Path.Combine(serverPath, storedName), True)
            Return storedName
        Catch ex As Exception
            XtraMessageBox.Show("The file could not be copied to the document server:" & vbCrLf & ex.Message,
                                "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return String.Empty
        End Try
    End Function

    Private Sub SaveAttachmentSlot(ByVal sourcePath As String, ByVal slot As Integer)
        If sourcePath = "" Then Return

        Dim storedName As String = UploadAttachment(sourcePath, slot)
        If storedName = "" Then Return

        If Not _signature.SaveAttachment(_afaNo, 0, "Lampiran", storedName, "", _nik) Then
            XtraMessageBox.Show("Attachment " & slot & " could not be recorded:" & vbCrLf &
                                _signature.LastErrorMessage,
                                "Attachment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub PickAttachment(ByRef target As String, ByVal editor As DevExpress.XtraEditors.ButtonEdit)
        If _afaNo = "" Then
            XtraMessageBox.Show("Please load a document first.", "Signature AFA Additional Budget",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If _headerStatus <> "Draft" Then
            XtraMessageBox.Show("Attachments can only be added while the document is a Draft.",
                                "Signature AFA Additional Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using ofd As New OpenFileDialog()
            ofd.Title = "Choose a supporting file"
            ofd.Filter = "PDF files|*.pdf"

            If ofd.ShowDialog() <> DialogResult.OK Then Return

            Dim ext As String = Path.GetExtension(ofd.FileName).ToLowerInvariant()
            If ext <> ".pdf" Then
                XtraMessageBox.Show("Attachment must be a PDF file.",
                                    "Signature AFA Additional Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            target = ofd.FileName
            editor.Text = Path.GetFileName(ofd.FileName)
        End Using
    End Sub

    Private Sub ButtonEditAttachment1_ButtonClick(sender As Object,
                                                  e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) _
                                                  Handles ButtonEditAttachment1.ButtonClick
        PickAttachment(_attachment1Path, ButtonEditAttachment1)
    End Sub

    Private Sub ButtonEditAttachment2_ButtonClick(sender As Object,
                                                  e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) _
                                                  Handles ButtonEditAttachment2.ButtonClick
        PickAttachment(_attachment2Path, ButtonEditAttachment2)
    End Sub

#End Region

#Region "Save"

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If _afaNo = "" Then
            XtraMessageBox.Show("Please load a document first.", "Signature AFA Additional Budget",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If _headerStatus <> "Draft" Then
            XtraMessageBox.Show("The approver list can no longer be changed. Current status: " & _headerStatus,
                                "Signature AFA Additional Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        GridViewSignature.CloseEditor()
        GridViewSignature.UpdateCurrentRow()

        If _dtNodes Is Nothing OrElse _dtNodes.Rows.Count = 0 Then
            XtraMessageBox.Show("There are no signature nodes to save.", "Signature AFA Additional Budget",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Cursor.Current = Cursors.WaitCursor
        Try
            Dim failed As Integer = 0
            Dim lastError As String = ""
            For Each row As DataRow In _dtNodes.Rows
                Dim slot As Integer = Convert.ToInt32(row("Urut"))

                SaveOneNode(row, slot, "Auth", "Auth_NIK", "Auth_Jab", "Sts_Auth", failed, lastError)
                SaveOneNode(row, slot, "Supp", "Supp_NIK", "Supp_Jab", "Sts_Supp", failed, lastError)
                SaveOneNode(row, slot, "Dir", "Dir_NIK", "Dir_Jab", "Sts_Dir", failed, lastError)
            Next

            If failed > 0 Then
                XtraMessageBox.Show(failed.ToString() & " node(s) could not be saved." & vbCrLf & lastError,
                                    "Signature AFA Additional Budget",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            SavePriority()

            SaveAttachmentSlot(_attachment1Path, 1)
            SaveAttachmentSlot(_attachment2Path, 2)

            XtraMessageBox.Show("Signature saved.", "Signature AFA Additional Budget",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadNodes()
            LoadAttachments()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub SaveOneNode(ByVal row As DataRow,
                            ByVal slot As Integer,
                            ByVal jenis As String,
                            ByVal nikField As String,
                            ByVal jabField As String,
                            ByVal stsField As String,
                            ByRef failed As Integer,
                            ByRef lastError As String)

        Dim status As String = Convert.ToString(row(stsField)).Trim()
        If status = "App" OrElse status = "Skip" Then Return

        Dim nikNode As String = Convert.ToString(row(nikField)).Trim()
        Dim jab As String = Convert.ToString(row(jabField)).Trim()

        If Not _signature.SaveNode(_afaNo, jenis, slot, nikNode, jab, _nik, _pc) Then
            failed += 1
            lastError = _signature.LastErrorMessage
        End If
    End Sub

    Private Sub SavePriority()
        Dim priority As Byte = CByte(Math.Max(0, SelectPriority.SelectedIndex))
        Dim reason As String = Nothing

        If priority > 0 Then
            reason = InputBox("Why does this AFA need the priority '" &
                              SelectPriority.Text & "'?",
                              "Priority Reason").Trim()

            If reason = "" Then
                XtraMessageBox.Show("No reason was given, so the priority stays at No Label.",
                                    "Priority", MessageBoxButtons.OK, MessageBoxIcon.Information)
                priority = 0
                SelectPriority.SelectedIndex = 0
            End If
        End If

        If Not _signature.UpdatePriority(_afaNo, priority, reason, _nik, _pc) Then
            XtraMessageBox.Show("Signature was saved, but the priority could not be updated:" & vbCrLf &
                                _signature.LastErrorMessage,
                                "Priority", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

#End Region

#Region "Send"

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        If _afaNo = "" Then
            XtraMessageBox.Show("Please load a document first.", "Signature AFA Additional Budget",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If _headerStatus <> "Draft" Then
            XtraMessageBox.Show("This document has already been sent. Current status: " & _headerStatus,
                                "Signature AFA Additional Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not HasApprover() Then
            XtraMessageBox.Show("No approver has been assigned yet." & vbCrLf &
                                "Fill in at least one node and press Save first.",
                                "Signature AFA Additional Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If XtraMessageBox.Show("Send AFA " & _afaNo & " for approval?" & vbCrLf &
                               "The approver list can no longer be changed afterwards.",
                               "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then Return

        Cursor.Current = Cursors.WaitCursor
        Try
            If _signature.Submit(_afaNo, _nik, _pc) Then
                XtraMessageBox.Show(_signature.LastErrorMessage, "Signature AFA Additional Budget",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadAll(_afaNo)
            Else
                XtraMessageBox.Show(_signature.LastErrorMessage, "Failed to send",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub TextEditAfaNo_Leave(sender As Object, e As EventArgs) Handles TextEditAfaNo.Leave
        Dim typed As String = TextEditAfaNo.Text.Trim()
        If typed = "" OrElse typed = _afaNo Then Return
        LoadAll(typed)
    End Sub

    Private Sub TextEditAfaNo_KeyDown(sender As Object, e As KeyEventArgs) Handles TextEditAfaNo.KeyDown
        If e.KeyCode = Keys.Enter Then LoadAll(TextEditAfaNo.Text.Trim())
    End Sub

    Private Sub GridViewSignature_CellValueChanged(sender As Object,
                                                   e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) _
                                                   Handles GridViewSignature.CellValueChanged
        If e.Column Is Nothing Then Return

        Dim jabField As String
        Dim source As DataTable

        Select Case e.Column.FieldName
            Case "Auth_NIK" : jabField = "Auth_Jab" : source = _dtAuth
            Case "Supp_NIK" : jabField = "Supp_Jab" : source = _dtSupp
            Case "Dir_NIK" : jabField = "Dir_Jab" : source = _dtDir
            Case Else : Return
        End Select

        Dim chosen As String = Convert.ToString(e.Value).Trim()

        If chosen = "" Then
            GridViewSignature.SetRowCellValue(e.RowHandle, jabField, "")
            Return
        End If

        If source Is Nothing Then Return

        Dim rows() As DataRow = source.Select("NIK = '" & chosen.Replace("'", "''") & "'")
        If rows.Length = 0 Then Return

        GridViewSignature.SetRowCellValue(e.RowHandle, jabField, Convert.ToString(rows(0)("JAB")))
    End Sub

    Private Sub GridViewSignature_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) _
            Handles GridViewSignature.ShowingEditor
        If _headerStatus <> "Draft" Then e.Cancel = True : Return

        Dim col = GridViewSignature.FocusedColumn
        If col Is Nothing Then Return

        Dim stsField As String

        Select Case col.FieldName
            Case "Auth_NIK" : stsField = "Sts_Auth"
            Case "Supp_NIK" : stsField = "Sts_Supp"
            Case "Dir_NIK" : stsField = "Sts_Dir"
            Case Else : Return
        End Select

        Dim status As String = Convert.ToString(GridViewSignature.GetFocusedRowCellValue(stsField)).Trim()
        If status = "App" OrElse status = "Skip" Then e.Cancel = True
    End Sub

    Private Sub GridViewSignature_RowCellStyle(sender As Object,
                                               e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) _
                                               Handles GridViewSignature.RowCellStyle
        If e.Column Is Nothing Then Return

        Dim stsField As String

        Select Case e.Column.FieldName
            Case "Auth_NIK", "Auth_Jab" : stsField = "Sts_Auth"
            Case "Supp_NIK", "Supp_Jab" : stsField = "Sts_Supp"
            Case "Dir_NIK", "Dir_Jab" : stsField = "Sts_Dir"
            Case Else : Return
        End Select

        Dim status As String = Convert.ToString(GridViewSignature.GetRowCellValue(e.RowHandle, stsField)).Trim()

        If status = "App" Then
            e.Appearance.BackColor = Color.FromArgb(226, 242, 226)
        ElseIf status = "Skip" Then
            e.Appearance.BackColor = Color.FromArgb(245, 245, 245)
            e.Appearance.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub BtnViewAFA_Click(sender As Object, e As EventArgs) Handles BtnViewAFA.Click
        If _afaNo = "" Then
            XtraMessageBox.Show("Please load a document first.", "Signature AFA Additional Budget",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        XtraMessageBox.Show("The document view is not available yet.", "Signature AFA Additional Budget",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

#Region "Helpers"

    Private Sub ClearForm()
        _afaNo = String.Empty
        _headerStatus = String.Empty

        ClearFigures()
        SelectPriority.SelectedIndex = 0
        GridControlSignature.DataSource = Nothing

        _sriStatus = String.Empty
        _attachment1Path = String.Empty
        _attachment2Path = String.Empty
        ButtonEditAttachment1.Text = String.Empty
        ButtonEditAttachment2.Text = String.Empty

        SetButtonState(False)
        Me.Text = "Signature AFA Additional Budget"
    End Sub

    Private Function HasApprover() As Boolean
        If _dtNodes Is Nothing Then Return False

        For Each row As DataRow In _dtNodes.Rows
            If Convert.ToString(row("Auth_NIK")).Trim() <> "" Then Return True
            If Convert.ToString(row("Supp_NIK")).Trim() <> "" Then Return True
            If Convert.ToString(row("Dir_NIK")).Trim() <> "" Then Return True
        Next

        Return False
    End Function

    Private Sub SetButtonState(ByVal loaded As Boolean)
        BtnSave.Enabled = loaded
        BtnSend.Enabled = loaded
        BtnViewAFA.Enabled = loaded
    End Sub

#End Region

End Class
