Imports System.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraFormAFAMonitoring

    Private ReadOnly _service As New AFAMonitoringService()
    Private ReadOnly _general As New GeneralService()

    Private _dtAfaType As DataTable

    Private ReadOnly _statusCodes As String() = {"", "Draft", "Planned", "Approved", "Cancelled"}
    Private ReadOnly _statusLabels As String() = {"All", "Draft", "Planned", "Approved", "Cancelled"}

    Private ReadOnly _nik As String = Trim(FormFluMenu.btnuserid.Caption)
    Private ReadOnly _level As String = Trim(FormFluMenu.btnlvl.Caption)

#Region "Form Lifecycle"

    Private Sub XtraFormAFAMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Monitoring AFA"
        SetupGrid()
        LoadStatusCombo()
        LoadTypeCombo()
        LoadList()
    End Sub

#End Region

#Region "Setup"

    Private Sub SetupGrid()
        With GridViewAFAMonitoring
            .OptionsBehavior.Editable = False
            .OptionsView.ColumnAutoWidth = False
            .OptionsFind.AlwaysVisible = True
            .OptionsFind.FindNullPrompt = "Search subject, AFA number..."
            .FocusRectStyle = DrawFocusRectStyle.RowFocus
        End With
    End Sub

    Private Sub LoadStatusCombo()
        SelectStatus.Properties.Items.Clear()
        For Each label As String In _statusLabels
            SelectStatus.Properties.Items.Add(label)
        Next
        SelectStatus.SelectedIndex = 0
    End Sub

    Private Sub LoadTypeCombo()
        Dim dtTypes As DataTable = _general.GetAfaTypes()

        _dtAfaType = New DataTable()
        _dtAfaType.Columns.Add("CODE", GetType(String))
        _dtAfaType.Columns.Add("NAME", GetType(String))
        _dtAfaType.Rows.Add("", "All")

        If dtTypes IsNot Nothing Then
            For Each row As DataRow In dtTypes.Rows
                _dtAfaType.Rows.Add(Convert.ToString(row("CODE")), Convert.ToString(row("NAME")))
            Next
        End If

        SelectType.Properties.Items.Clear()
        For Each row As DataRow In _dtAfaType.Rows
            SelectType.Properties.Items.Add(Convert.ToString(row("NAME")))
        Next
        SelectType.SelectedIndex = 0
    End Sub

#End Region

#Region "Data"

    Private Sub LoadList()
        Cursor.Current = Cursors.WaitCursor
        Try
            GridControlAFAMonitoring.DataSource = Nothing

            Dim afaType As String = If(SelectType.SelectedIndex >= 0, Convert.ToString(_dtAfaType.Rows(SelectType.SelectedIndex)("CODE")), "")
            Dim sts As String = If(SelectStatus.SelectedIndex >= 0, _statusCodes(SelectStatus.SelectedIndex), "")

            Dim scopeNik As String = If(AFAMonitoringService.IsElevated(_level), "", _nik)

            Dim dt As DataTable = _service.GetList(afaType, sts, "", "", "", scopeNik, Nothing, Nothing)

            If dt Is Nothing Then
                XtraMessageBox.Show("Failed to retrieve data." & vbCrLf & _service.LastErrorMessage,
                                    "Monitoring AFA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            GridControlAFAMonitoring.DataSource = dt
            ConfigureColumns()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ConfigureColumns()
        With GridViewAFAMonitoring
            If .Columns.Count = 0 Then Return

            For Each hidden As String In New String() {
                "AFA_TYPE", "SUB_TYPE", "DEPT_ID", "DEPT_PREFIX",
                "BUDGET_YEAR", "CURCODE", "AMT_JPY", "REF_REG",
                "PRIORITY", "PRIORITY_REASON",
                "BUDGET_CHECK_BY", "BUDGET_CHECK_DATE",
                "CREATED_NIK", "LATEST_APPROVED_JAB", "PENDING_AT_JAB",
                "TOTAL_NODE", "APPROVED_NODE"
            }
                If .Columns(hidden) IsNot Nothing Then .Columns(hidden).Visible = False
            Next

            SetColumn("AFA_NO", "No. AFA", 150)
            SetColumn("AFA_NO_APPROVAL", "No. Approval", 150)
            SetColumn("AFA_TYPE_NAME", "Type", 150)
            SetColumn("SUB_TYPE_NAME", "Sub Type", 180)
            SetColumn("DEPT_NAME", "Department", 200)
            SetColumn("SUBJECT", "Subject", 220)
            SetColumn("AMT", "Amount", 110)
            SetColumn("SRI_STS", "SRI", 80)
            SetColumn("PRIORITY_LABEL", "Priority", 90)
            SetColumn("STS", "Status", 90)
            SetColumn("BUDGET_STS", "Budget", 90)
            SetColumn("CREATED_BY", "Drafter", 150)
            SetColumn("CREATED_DATE", "Created", 90)
            SetColumn("LATEST_APPROVAL_DATE", "Last Approved On", 130)
            SetColumn("LATEST_APPROVED_BY", "Last Approved By", 150)
            SetColumn("PENDING_AT", "Pending At", 150)
        End With
    End Sub

    Private Sub SetColumn(ByVal fieldName As String, ByVal caption As String, ByVal width As Integer)
        Dim col = GridViewAFAMonitoring.Columns(fieldName)
        If col Is Nothing Then Return

        col.Caption = caption
        col.Width = width
        col.OptionsColumn.AllowEdit = False
    End Sub

#End Region

#Region "Events"

    Private Sub SelectStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectStatus.SelectedIndexChanged
        LoadList()
    End Sub

    Private Sub SelectType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectType.SelectedIndexChanged
        LoadList()
    End Sub

    Private Sub BtnReload_Click(sender As Object, e As EventArgs) Handles BtnReload.Click
        LoadList()
    End Sub

    Private Sub GridViewAFAMonitoring_DoubleClick(sender As Object, e As EventArgs) Handles GridViewAFAMonitoring.DoubleClick
        Dim rowHandle As Integer = GridViewAFAMonitoring.FocusedRowHandle
        If rowHandle < 0 Then Return

        Dim row As DataRowView = TryCast(GridViewAFAMonitoring.GetRow(rowHandle), DataRowView)
        If row Is Nothing Then Return

        Dim afaNo As String = Convert.ToString(row("AFA_NO")).Trim()
        If afaNo = "" Then Return

        Try
            Clipboard.SetText(afaNo)
        Catch
            Return
        End Try

        XtraMessageBox.Show("AFA No " & afaNo & " copied to clipboard.",
                            "Monitoring AFA", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

End Class