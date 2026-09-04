Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraFormAFAApproval

    Private ReadOnly _service As New AFASignatureService()

    Private _dtList As DataTable

    Private ReadOnly _nik As String = Trim(FormFluMenu.btnuserid.Caption)
    Private ReadOnly _pc As String = System.Net.Dns.GetHostName()

#Region "Form Lifecycle"

    Private Sub XtraFormAFAApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Approval AFA"
        SetupGrid()
        LoadList()
    End Sub

#End Region

#Region "Setup"
    Private Sub SetupGrid()
        With GridViewApproval
            .OptionsBehavior.Editable = False
            .OptionsView.ColumnAutoWidth = False
            .OptionsSelection.MultiSelect = True
            .OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
            .OptionsFind.AlwaysVisible = True
            .OptionsFind.FindNullPrompt = "Search subject, AFA number..."
            .FocusRectStyle = DrawFocusRectStyle.RowFocus
        End With
    End Sub

#End Region

#Region "Data"

    Private Sub LoadList()
        Cursor.Current = Cursors.WaitCursor
        Try
            GridControlApproval.DataSource = Nothing

            _dtList = _service.GetPendingApproval(_nik)

            If _dtList Is Nothing Then
                XtraMessageBox.Show("Failed to retrieve data." & vbCrLf & _service.LastErrorMessage,
                                    "Approval AFA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            GridControlApproval.DataSource = _dtList
            ConfigureColumns()
            MemoEditReason.Text = String.Empty
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ConfigureColumns()
        With GridViewApproval
            If .Columns.Count = 0 Then Return

            For Each hidden As String In New String() {"JENIS", "ID", "AFA_TYPE", "AMT_JPY",
                                                       "PRIORITY", "CREATED_NIK"}
                If .Columns(hidden) IsNot Nothing Then .Columns(hidden).Visible = False
            Next

            SetColumn("AFA_NO", "No. AFA", 150)
            SetColumn("AFA_TYPE_NAME", "Type", 140)
            SetColumn("SUB_TYPE_NAME", "Sub Type", 170)
            SetColumn("DEPT_NAME", "Department", 190)
            SetColumn("SUBJECT", "Subject", 220)
            SetColumn("CURCODE", "Currency", 70)
            SetColumn("AMT", "Amount", 110)
            SetColumn("SRI_STS", "SRI", 80)
            SetColumn("PRIORITY_LABEL", "Priority", 90)
            SetColumn("CREATED_BY", "Drafter", 150)
            SetColumn("CREATED_DATE", "Created", 90)
            SetColumn("DAYS_WAITING", "Days Waiting", 90)
        End With
    End Sub

    Private Sub SetColumn(ByVal fieldName As String, ByVal caption As String, ByVal width As Integer)
        Dim col = GridViewApproval.Columns(fieldName)
        If col Is Nothing Then Return

        col.Caption = caption
        col.Width = width
        col.OptionsColumn.AllowEdit = False
    End Sub

#End Region

#Region "Row Helpers"
    Private Function GetCheckedRows() As List(Of (AfaNo As String, Jenis As String))
        Dim result As New List(Of (AfaNo As String, Jenis As String))

        For Each handle As Integer In GridViewApproval.GetSelectedRows()
            If handle < 0 Then Continue For

            Dim row As DataRowView = TryCast(GridViewApproval.GetRow(handle), DataRowView)
            If row Is Nothing Then Continue For

            result.Add((Convert.ToString(row("AFA_NO")), Convert.ToString(row("JENIS"))))
        Next

        Return result
    End Function

    Private Function GetFocusedRow() As DataRowView
        Dim handle As Integer = GridViewApproval.FocusedRowHandle
        If handle < 0 Then Return Nothing

        Return TryCast(GridViewApproval.GetRow(handle), DataRowView)
    End Function

#End Region

#Region "Events"

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        LoadList()
    End Sub
    Private Sub BtnApproveSelected_Click(sender As Object, e As EventArgs) Handles BtnApproveSelected.Click
        Dim rows = GetCheckedRows()

        If rows.Count = 0 Then
            XtraMessageBox.Show("Please check at least one document.", "Approval AFA",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If XtraMessageBox.Show($"Approve {rows.Count} document(s)?", "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then Return

        Cursor.Current = Cursors.WaitCursor
        Try
            Dim result As BulkApproveResult = _service.ApproveMany(rows, _nik, _pc)

            XtraMessageBox.Show(result.BuildSummary(), "Approval AFA",
                                MessageBoxButtons.OK,
                                If(result.TotalFailed = 0, MessageBoxIcon.Information, MessageBoxIcon.Warning))

            LoadList()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub BtnUnapprove_Click(sender As Object, e As EventArgs) Handles BtnUnapprove.Click
        Dim row As DataRowView = GetFocusedRow()

        If row Is Nothing Then
            XtraMessageBox.Show("Please select a document first.", "Approval AFA",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim afaNo As String = Convert.ToString(row("AFA_NO"))
        Dim jenis As String = Convert.ToString(row("JENIS"))
        Dim reason As String = MemoEditReason.Text.Trim()

        If XtraMessageBox.Show("Un-approve AFA " & afaNo & "?", "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then Return

        Cursor.Current = Cursors.WaitCursor
        Try
            If _service.Approve(afaNo, jenis, _nik, _pc, "UNAPP", If(reason = "", Nothing, reason)) Then
                XtraMessageBox.Show(_service.LastErrorMessage, "Approval AFA",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadList()
            Else
                XtraMessageBox.Show(_service.LastErrorMessage, "Un-approve Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnSkip_Click(sender As Object, e As EventArgs) Handles BtnSkip.Click
        Dim row As DataRowView = GetFocusedRow()

        If row Is Nothing Then
            XtraMessageBox.Show("Please select a document first.", "Approval AFA",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim reason As String = MemoEditReason.Text.Trim()

        If reason = "" Then
            XtraMessageBox.Show("A reason is required to skip an approver.", "Approval AFA",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MemoEditReason.Focus()
            Return
        End If

        Dim afaNo As String = Convert.ToString(row("AFA_NO"))
        Dim jenis As String = Convert.ToString(row("JENIS"))
        Dim id As Integer = Convert.ToInt32(row("ID"))

        If XtraMessageBox.Show("Skip this approval step for AFA " & afaNo & "?", "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then Return

        Cursor.Current = Cursors.WaitCursor
        Try
            If _service.Skip(afaNo, jenis, id, _nik, _pc, reason) Then
                XtraMessageBox.Show(_service.LastErrorMessage, "Approval AFA",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadList()
            Else
                XtraMessageBox.Show(_service.LastErrorMessage, "Skip Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnViewAFA_Click(sender As Object, e As EventArgs) Handles BtnViewAFA.Click
        Dim row As DataRowView = GetFocusedRow()

        If row Is Nothing Then
            XtraMessageBox.Show("Please select a document first.", "Approval AFA",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        XtraMessageBox.Show("The document view is not available yet. AFA No: " & Convert.ToString(row("AFA_NO")),
                            "Approval AFA", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

End Class