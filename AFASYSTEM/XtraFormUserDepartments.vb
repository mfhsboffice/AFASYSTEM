Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraFormUserDepartments

    Private ReadOnly _service As New UserDepartmentService()
    Private ReadOnly _general As New GeneralService()

    Private _dtList As DataTable
    Private _dtDepartment As DataTable
    Private _selectedNik As String = String.Empty

#Region "Form Lifecycle"

    Private Sub XtraFormUserDepartments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "User Department Mapping"
        SetupGrid()
        LoadDepartmentCombo()
        LoadList()
    End Sub

#End Region

#Region "Grid & Control Setup"

    Private Sub SetupGrid()
        With GridViewUserDepartments
            .OptionsBehavior.Editable = False
            .FocusRectStyle = DrawFocusRectStyle.RowFocus
        End With
    End Sub

    Private Sub LoadDepartmentCombo()
        _dtDepartment = _general.GetDepartments()

        CheckedComboDepartments.Properties.Items.Clear()

        If _dtDepartment Is Nothing OrElse _dtDepartment.Rows.Count = 0 Then
            XtraMessageBox.Show("Department master data is empty or failed to load." & vbCrLf & _general.LastErrorMessage,
                                "User Department", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        For Each row As DataRow In _dtDepartment.Rows
            CheckedComboDepartments.Properties.Items.Add(
                New CheckedListBoxItem(Convert.ToInt32(row("DEPT_ID")),
                                       Convert.ToString(row("DISPLAY_NAME")),
                                       CheckState.Unchecked))
        Next

        CheckedComboDepartments.Properties.SelectAllItemCaption = "Select All"
        CheckedComboDepartments.Properties.SeparatorChar = ","c
    End Sub

#End Region

#Region "Data Operations"

    Private Sub LoadList(Optional ByVal keyword As String = "")
        Cursor.Current = Cursors.WaitCursor
        Try
            GridControlUserDepartments.DataSource = Nothing

            _dtList = _service.GetList(keyword)

            If _dtList Is Nothing Then
                XtraMessageBox.Show("Failed to retrieve data." & vbCrLf & _service.LastErrorMessage,
                                    "User Department", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            GridControlUserDepartments.DataSource = _dtList
            ConfigureColumns()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ConfigureColumns()
        With GridViewUserDepartments
            If .Columns.Count = 0 Then Return

            If .Columns("NIK") IsNot Nothing Then
                .Columns("NIK").Caption = "NIK"
                .Columns("NIK").Width = 80
            End If

            If .Columns("NAMA") IsNot Nothing Then
                .Columns("NAMA").Caption = "Name"
                .Columns("NAMA").Width = 220
            End If

            If .Columns("TOTAL_DEPT") IsNot Nothing Then
                .Columns("TOTAL_DEPT").Caption = "Total"
                .Columns("TOTAL_DEPT").Width = 60
            End If

            If .Columns("DEPARTMENTS") IsNot Nothing Then
                .Columns("DEPARTMENTS").Caption = "Departments"
                .Columns("DEPARTMENTS").Width = 500
            End If
        End With
    End Sub

    ''' <summary>Clears all checked items in the combo box.</summary>
    Private Sub UncheckAllDepartments()
        For i As Integer = 0 To CheckedComboDepartments.Properties.Items.Count - 1
            CheckedComboDepartments.Properties.Items(i).CheckState = CheckState.Unchecked
        Next
        CheckedComboDepartments.Refresh()
    End Sub

    ''' <summary>Checks the departments associated with the selected user.</summary>
    Private Sub LoadUserDepartments(ByVal nik As String)
        UncheckAllDepartments()

        Dim dt As DataTable = _service.GetByNik(nik)
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return

        For Each row As DataRow In dt.Rows
            Dim deptId As Integer = Convert.ToInt32(row("DEPT_ID"))

            For i As Integer = 0 To CheckedComboDepartments.Properties.Items.Count - 1
                Dim item As CheckedListBoxItem = CheckedComboDepartments.Properties.Items(i)
                If item.Value IsNot Nothing AndAlso Convert.ToInt32(item.Value) = deptId Then
                    item.CheckState = CheckState.Checked
                    Exit For
                End If
            Next
        Next

        CheckedComboDepartments.Refresh()
    End Sub

    ''' <summary>Returns checked DEPT_IDs as a comma-separated string for SP parameters.</summary>
    Private Function GetCheckedDeptIds() As String
        Dim sb As New StringBuilder()

        For i As Integer = 0 To CheckedComboDepartments.Properties.Items.Count - 1
            Dim item As CheckedListBoxItem = CheckedComboDepartments.Properties.Items(i)
            If item.CheckState = CheckState.Checked Then
                If sb.Length > 0 Then sb.Append(",")
                sb.Append(Convert.ToString(item.Value))
            End If
        Next

        Return sb.ToString()
    End Function

    Private Sub ClearInput()
        _selectedNik = String.Empty
        TextEditNik.Text = String.Empty
        TextEditName.Text = String.Empty
        UncheckAllDepartments()
        TextEditNik.Focus()
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub GridViewUserDepartments_FocusedRowChanged(sender As Object,
                                                          e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) _
                                                          Handles GridViewUserDepartments.FocusedRowChanged
        If e.FocusedRowHandle < 0 Then Return

        Dim row As DataRowView = TryCast(GridViewUserDepartments.GetRow(e.FocusedRowHandle), DataRowView)
        If row Is Nothing Then Return

        _selectedNik = Convert.ToString(row("NIK")).Trim()
        TextEditNik.Text = _selectedNik
        TextEditName.Text = Convert.ToString(row("NAMA"))

        LoadUserDepartments(_selectedNik)
    End Sub

    ''' <summary>Automatically fills the Name field after NIK is entered.</summary>
    Private Sub TextEditNik_Leave(sender As Object, e As EventArgs) Handles TextEditNik.Leave
        Dim nik As String = TextEditNik.Text.Trim()

        ' Penggunaan String.IsNullOrEmpty lebih aman dan bersih dibanding = ""
        If String.IsNullOrEmpty(nik) Then
            TextEditName.Text = String.Empty
            Return
        End If

        Dim employeeName As String = _general.GetEmployeeName(nik)

        If String.IsNullOrEmpty(employeeName) Then
            TextEditName.Text = String.Empty
            ' Menggunakan String Interpolation ($"") agar lebih mudah dibaca
            XtraMessageBox.Show($"NIK '{nik}' was not found in the employee master data.",
                                "User Department", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextEditNik.Focus()
            Return
        End If

        TextEditName.Text = employeeName
        _selectedNik = nik
        LoadUserDepartments(nik)
    End Sub

    Private Sub BtnSaveUpdate_Click(sender As Object, e As EventArgs) Handles BtnSaveUpdate.Click
        Dim nik As String = TextEditNik.Text.Trim()

        If String.IsNullOrEmpty(nik) Then
            XtraMessageBox.Show("NIK is required.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextEditNik.Focus()
            Return
        End If

        Dim deptIds As String = GetCheckedDeptIds()

        If String.IsNullOrEmpty(deptIds) Then
            XtraMessageBox.Show("At least one department must be selected.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CheckedComboDepartments.Focus()
            Return
        End If

        If XtraMessageBox.Show($"Save mapping for NIK '{nik}'?", "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
            Return
        End If

        Cursor.Current = Cursors.WaitCursor
        Try
            ' Catatan Migrasi: Jika Anda sudah menerapkan class UserSession, 
            ' ubah baris di bawah ini menjadi: Dim nikUser As String = UserSession.UserId
            Dim nikUser As String = Trim(FormFluMenu.btnuserid.Caption)
            Dim pcName As String = System.Net.Dns.GetHostName()

            Dim isSuccess As Boolean = _service.Save(nik, deptIds, nikUser, pcName)

            If isSuccess Then
                XtraMessageBox.Show(_service.LastErrorMessage, "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadList()
                ClearInput()
            Else
                XtraMessageBox.Show(_service.LastErrorMessage, "Save Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ClearInput()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        GeneralService.ClearCache()
        LoadDepartmentCombo()
        LoadList()
        ClearInput()
    End Sub

#End Region

End Class