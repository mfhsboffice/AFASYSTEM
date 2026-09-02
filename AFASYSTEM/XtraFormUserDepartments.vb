Imports System.Text
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraFormUserDepartments

    Private ReadOnly _service As New UserDepartmentService()
    Private ReadOnly _general As New GeneralService()

    Private _dtList As DataTable
    Private _dtDepartment As DataTable
    Private _dtUsers As DataTable

    Private _selectedNik As String = String.Empty
    Private _isEditMode As Boolean = False

#Region "Form Lifecycle"

    Private Sub XtraFormUserDepartments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "User Department Mapping"
        SetupGrid()
        LoadEmployeeCombo()
        LoadDepartmentCombo()
        LoadList()
        SetMode(isEditing:=False)
    End Sub

#End Region

#Region "Grid & Control Setup"

    Private Sub SetupGrid()
        With GridViewUserDepartments
            .OptionsBehavior.Editable = False
            .FocusRectStyle = DrawFocusRectStyle.RowFocus
        End With
    End Sub


    Private Sub LoadEmployeeCombo()
        _dtUsers = _general.GetActiveUsers()

        ComboBoxEdit1.Properties.Items.Clear()

        If _dtUsers Is Nothing OrElse _dtUsers.Rows.Count = 0 Then
            XtraMessageBox.Show("The user list is empty or failed to load." & vbCrLf & _general.LastErrorMessage,
                                "User Department", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        For Each row As DataRow In _dtUsers.Rows
            ComboBoxEdit1.Properties.Items.Add(Convert.ToString(row("DISPLAY_NAME")))
        Next
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

    Private Sub UncheckAllDepartments()
        For i As Integer = 0 To CheckedComboDepartments.Properties.Items.Count - 1
            CheckedComboDepartments.Properties.Items(i).CheckState = CheckState.Unchecked
        Next
        CheckedComboDepartments.Refresh()
    End Sub

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

    ''' <summary>Selects the combo item matching a NIK, or clears the combo if none does.</summary>
    Private Sub SelectEmployeeByNik(ByVal nik As String)
        If _dtUsers Is Nothing Then Return

        Dim rows() As DataRow = _dtUsers.Select("NIK = '" & nik.Replace("'", "''") & "'")

        If rows.Length = 0 Then
            ComboBoxEdit1.SelectedIndex = -1
            Return
        End If

        Dim display As String = Convert.ToString(rows(0)("DISPLAY_NAME"))
        ComboBoxEdit1.SelectedIndex = ComboBoxEdit1.Properties.Items.IndexOf(display)
    End Sub

    ''' <summary>NIK behind whichever item is currently chosen in the combo.</summary>
    Private Function GetSelectedNik() As String
        If ComboBoxEdit1.SelectedIndex < 0 Then Return String.Empty
        If _dtUsers Is Nothing OrElse ComboBoxEdit1.SelectedIndex >= _dtUsers.Rows.Count Then Return String.Empty

        Return Convert.ToString(_dtUsers.Rows(ComboBoxEdit1.SelectedIndex)("NIK"))
    End Function

    Private Sub ClearInput()
        _selectedNik = String.Empty
        ComboBoxEdit1.SelectedIndex = -1
        UncheckAllDepartments()
        SetMode(isEditing:=False)
        ComboBoxEdit1.Focus()
    End Sub

    ''' <summary>
    ''' Switches the form between adding a new mapping and updating one
    ''' loaded by double-click. The button caption is the only visible
    ''' difference - Save performs the same upsert either way.
    ''' </summary>
    Private Sub SetMode(ByVal isEditing As Boolean)
        _isEditMode = isEditing
        BtnSaveUpdate.Text = If(isEditing, "Update", "Save")
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub GridViewUserDepartments_DoubleClick(sender As Object, e As EventArgs) _
            Handles GridViewUserDepartments.DoubleClick
        Dim rowHandle As Integer = GridViewUserDepartments.FocusedRowHandle
        If rowHandle < 0 Then Return

        Dim row As DataRowView = TryCast(GridViewUserDepartments.GetRow(rowHandle), DataRowView)
        If row Is Nothing Then Return

        _selectedNik = Convert.ToString(row("NIK")).Trim()

        SelectEmployeeByNik(_selectedNik)
        LoadUserDepartments(_selectedNik)
        SetMode(isEditing:=True)
    End Sub

    Private Sub BtnSaveUpdate_Click(sender As Object, e As EventArgs) Handles BtnSaveUpdate.Click
        Dim nik As String = GetSelectedNik()

        If String.IsNullOrEmpty(nik) Then
            XtraMessageBox.Show("Please choose an employee from the list.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboBoxEdit1.Focus()
            Return
        End If

        Dim deptIds As String = GetCheckedDeptIds()

        If String.IsNullOrEmpty(deptIds) Then
            XtraMessageBox.Show("At least one department must be selected.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            CheckedComboDepartments.Focus()
            Return
        End If

        Dim verb As String = If(_isEditMode, "Update", "Save")

        If XtraMessageBox.Show($"{verb} mapping for {ComboBoxEdit1.Text}?", "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
            Return
        End If

        Cursor.Current = Cursors.WaitCursor
        Try
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
        LoadEmployeeCombo()
        LoadDepartmentCombo()
        LoadList()
        ClearInput()
    End Sub

#End Region

End Class