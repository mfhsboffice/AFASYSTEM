Imports System.Data
Imports DevExpress.XtraEditors

Public Class XtraFormAFAMyRecords

    Private ReadOnly _service As New AFAMyRecordsService()
    Private ReadOnly _signatureService As New AFASignatureService()

    Private ReadOnly _nik As String = Trim(FormFluMenu.btnuserid.Caption)
    Private ReadOnly _pc As String = Net.Dns.GetHostName()

#Region "Form Lifecycle"

    Private Sub XtraFormAFAMyRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "My AFA History"
        SetupGrids()
        LoadMyDocuments()
        LoadMyApprovalHistory()
    End Sub

    Private Sub SetupGrids()
        With GridViewMyDocuments
            .OptionsBehavior.Editable = False
            .OptionsView.ColumnAutoWidth = True
            .FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        End With

        With GridViewMyApprovals
            .OptionsBehavior.Editable = False
            .OptionsView.ColumnAutoWidth = True
            .FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        End With
    End Sub

    Private Sub SetColumnCaption(ByVal view As DevExpress.XtraGrid.Views.Grid.GridView,
                                 ByVal fieldName As String,
                                 ByVal caption As String,
                                 ByVal width As Integer)
        Dim col = view.Columns(fieldName)
        If col Is Nothing Then Return

        col.Caption = caption
        col.Width = width
        col.OptionsColumn.AllowEdit = False
    End Sub

#End Region

#Region "My Documents"

    Private Sub LoadMyDocuments()
        Cursor.Current = Cursors.WaitCursor
        Try
            GridControlMyDocuments.DataSource = Nothing
            Dim dt As DataTable = _service.GetMyDocuments(_nik)

            If dt Is Nothing Then
                XtraMessageBox.Show("Failed to retrieve documents." & vbCrLf & _service.LastErrorMessage,
                                    "My AFA History", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            GridControlMyDocuments.DataSource = dt
            ConfigureMyDocumentsColumns()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ConfigureMyDocumentsColumns()
        With GridViewMyDocuments
            If .Columns.Count = 0 Then Return
            If .Columns("AFA_TYPE") IsNot Nothing Then .Columns("AFA_TYPE").Visible = False
        End With

        SetColumnCaption(GridViewMyDocuments, "AFA_NO", "No. AFA", 150)
        SetColumnCaption(GridViewMyDocuments, "AFA_TYPE_NAME", "Type", 140)
        SetColumnCaption(GridViewMyDocuments, "DEPT_NAME", "Department", 190)
        SetColumnCaption(GridViewMyDocuments, "SUBJECT", "Subject", 220)
        SetColumnCaption(GridViewMyDocuments, "CURCODE", "Currency", 70)
        SetColumnCaption(GridViewMyDocuments, "AMT", "Amount", 110)
        SetColumnCaption(GridViewMyDocuments, "STS", "Status", 90)
        SetColumnCaption(GridViewMyDocuments, "DATECREATE", "Created", 90)
        SetColumnCaption(GridViewMyDocuments, "DATEUPDATE", "Updated", 90)
    End Sub

    Private Sub BtnLoadMyDocuments_Click(sender As Object, e As EventArgs) Handles BtnLoadMyDocuments.Click
        LoadMyDocuments()
    End Sub

    Private Function GetFocusedMyDocumentRow() As DataRowView
        Dim handle As Integer = GridViewMyDocuments.FocusedRowHandle
        If handle < 0 Then Return Nothing
        Return TryCast(GridViewMyDocuments.GetRow(handle), DataRowView)
    End Function

    Private Sub GridViewMyDocuments_DoubleClick(sender As Object, e As EventArgs) Handles GridViewMyDocuments.DoubleClick
        Dim row As DataRowView = GetFocusedMyDocumentRow()
        If row Is Nothing Then Return

        Dim afaNo As String = Convert.ToString(row("AFA_NO"))
        Dim afaType As String = Convert.ToString(row("AFA_TYPE"))

        OpenEditForm(afaType, afaNo)
    End Sub

    Private Sub OpenEditForm(ByVal afaType As String, ByVal afaNo As String)
        Select Case afaType
            Case "INF"
                Dim frm As New XtraFormAFAInfEF()
                frm.Show()
                frm.LoadDocument(afaNo)

            Case "DAA"
                Dim frm As New XtraFormAFADaaEForm()
                frm.Show()
                frm.LoadDocument(afaNo)

            Case "BRE"
                Dim frm As New XtraFormAFABreEForm()
                frm.Show()
                frm.LoadDocument(afaNo)

            Case "ADD"
                Dim frm As New XtraFormAFAAddEForm()
                frm.Show()
                frm.LoadDocument(afaNo)

            Case Else
                XtraMessageBox.Show("No edit form is defined for AFA type '" & afaType & "'.",
                                    "My AFA History", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Select
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Dim row As DataRowView = GetFocusedMyDocumentRow()

        If row Is Nothing Then
            XtraMessageBox.Show("Please select a document first.", "My AFA History",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim afaNo As String = Convert.ToString(row("AFA_NO"))
        Dim sts As String = Convert.ToString(row("STS"))

        If sts <> "Planned" Then
            XtraMessageBox.Show("Only a document currently in circulation (Planned) can be cancelled.",
                                "My AFA History", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim reason As String = XtraInputBox.Show("Please enter a reason for cancelling AFA " & afaNo & ":",
                                                 "Cancel AFA", "")
        If String.IsNullOrWhiteSpace(reason) Then Return

        If XtraMessageBox.Show("Cancel AFA " & afaNo & "? This cannot be undone.", "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then Return

        Cursor.Current = Cursors.WaitCursor
        Try
            If _service.Cancel(afaNo, _nik, _pc, reason) Then
                XtraMessageBox.Show(_service.LastErrorMessage, "My AFA History",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadMyDocuments()
            Else
                XtraMessageBox.Show(_service.LastErrorMessage, "Cancel Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

#Region "My Approval History"

    Private Sub LoadMyApprovalHistory()
        Cursor.Current = Cursors.WaitCursor
        Try
            GridControlMyApprovals.DataSource = Nothing
            Dim dt As DataTable = _service.GetMyApprovalHistory(_nik)

            If dt Is Nothing Then
                XtraMessageBox.Show("Failed to retrieve approval history." & vbCrLf & _service.LastErrorMessage,
                                    "My AFA History", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            GridControlMyApprovals.DataSource = dt
            ConfigureMyApprovalsColumns()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ConfigureMyApprovalsColumns()
        With GridViewMyApprovals
            If .Columns.Count = 0 Then Return
            If .Columns("AFA_TYPE") IsNot Nothing Then .Columns("AFA_TYPE").Visible = False
            If .Columns("ID") IsNot Nothing Then .Columns("ID").Visible = False
        End With

        SetColumnCaption(GridViewMyApprovals, "AFA_NO", "No. AFA", 150)
        SetColumnCaption(GridViewMyApprovals, "AFA_TYPE_NAME", "Type", 120)
        SetColumnCaption(GridViewMyApprovals, "JENIS", "Role", 80)
        SetColumnCaption(GridViewMyApprovals, "DEPT_NAME", "Department", 170)
        SetColumnCaption(GridViewMyApprovals, "SUBJECT", "Subject", 200)
        SetColumnCaption(GridViewMyApprovals, "STS", "My Decision", 90)
        SetColumnCaption(GridViewMyApprovals, "DATEAPP", "Decided On", 110)
        SetColumnCaption(GridViewMyApprovals, "DOC_STS", "Document Status", 110)
        SetColumnCaption(GridViewMyApprovals, "CREATED_BY", "Drafter", 140)
    End Sub

    Private Sub BtnLoadMyApprovals_Click(sender As Object, e As EventArgs) Handles BtnLoadMyApprovals.Click
        LoadMyApprovalHistory()
    End Sub

    Private Function GetFocusedApprovalRow() As DataRowView
        Dim handle As Integer = GridViewMyApprovals.FocusedRowHandle
        If handle < 0 Then Return Nothing
        Return TryCast(GridViewMyApprovals.GetRow(handle), DataRowView)
    End Function

    Private Sub BtnUnapprovedAFA_Click(sender As Object, e As EventArgs) Handles BtnUnapprovedAFA.Click
        Dim row As DataRowView = GetFocusedApprovalRow()

        If row Is Nothing Then
            XtraMessageBox.Show("Please select a document first.", "My AFA History",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim afaNo As String = Convert.ToString(row("AFA_NO"))
        Dim jenis As String = Convert.ToString(row("JENIS"))

        Dim reason As String = XtraInputBox.Show("Please enter a reason for un-approving AFA " & afaNo & " (optional):",
                                                 "Un-approve AFA", "")

        If XtraMessageBox.Show("Un-approve AFA " & afaNo & "?" & vbCrLf &
                               "This will reset ALL approvals on this document back to the beginning.",
                               "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then Return

        Cursor.Current = Cursors.WaitCursor
        Try
            If _signatureService.Approve(afaNo, jenis, _nik, _pc, "UNAPP",
                                         If(String.IsNullOrWhiteSpace(reason), Nothing, reason)) Then
                XtraMessageBox.Show(_signatureService.LastErrorMessage, "My AFA History",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadMyApprovalHistory()
            Else
                XtraMessageBox.Show(_signatureService.LastErrorMessage, "Un-approve Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

End Class