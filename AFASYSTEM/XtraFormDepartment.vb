Imports System.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraFormDepartment

    Private ReadOnly _general As New GeneralService()
    Private _dtDepartment As DataTable
    Private _selectedDeptId As Integer = 0

#Region "Form"

    Private Sub XtraFormDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Master Department"
        SetupGrid()
        LoadData()
    End Sub

#End Region

#Region "Grid"

    Private Sub SetupGrid()
        With GridViewDepartment
            .OptionsBehavior.Editable = False
            .OptionsSelection.EnableAppearanceFocusedCell = False
            .FocusRectStyle = DrawFocusRectStyle.RowFocus
        End With
    End Sub

    Private Sub ConfigureColumns()
        With GridViewDepartment
            If .Columns.Count = 0 Then Return

            If .Columns("DEPT_ID") IsNot Nothing Then
                .Columns("DEPT_ID").Visible = False
            End If

            If .Columns("DEPT_NAME") IsNot Nothing Then
                .Columns("DEPT_NAME").Caption = "Department"
            End If

            If .Columns("PREFIX") IsNot Nothing Then
                .Columns("PREFIX").Caption = "Code"
            End If

            If .Columns("DISPLAY_NAME") IsNot Nothing Then
                .Columns("DISPLAY_NAME").Visible = False
            End If
        End With
    End Sub

#End Region

#Region "Data"

    Private Sub LoadData(Optional ByVal useCache As Boolean = True)
        Cursor.Current = Cursors.WaitCursor
        Try
            GridControlDepartment.DataSource = Nothing

            _dtDepartment = _general.GetDepartments(useCache)

            If _dtDepartment Is Nothing Then
                XtraMessageBox.Show("Gagal mengambil data department." & vbCrLf & _general.LastErrorMessage,
                                    "Master Department", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            GridControlDepartment.DataSource = _dtDepartment
            ConfigureColumns()

            If _dtDepartment.Rows.Count = 0 Then
                XtraMessageBox.Show("Data department masih kosong.",
                                    "Master Department", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ClearInput()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ClearInput()
        _selectedDeptId = 0
        TextEditDepartmentName.Text = String.Empty
        TextEditDepartmentCode.Text = String.Empty
    End Sub

#End Region

#Region "Events"
    Private Sub GridViewDepartment_FocusedRowChanged(sender As Object,
                                                     e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) _
                                                     Handles GridViewDepartment.FocusedRowChanged
        If e.FocusedRowHandle < 0 Then ClearInput() : Return

        Dim row As DataRowView = TryCast(GridViewDepartment.GetRow(e.FocusedRowHandle), DataRowView)
        If row Is Nothing Then Return

        _selectedDeptId = Convert.ToInt32(row("DEPT_ID"))
        TextEditDepartmentName.Text = Convert.ToString(row("DEPT_NAME"))
        TextEditDepartmentCode.Text = Convert.ToString(row("PREFIX"))
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        GeneralService.ClearCache()
        LoadData(useCache:=False)
    End Sub

    Private Sub BtnSaveUpdate_Click(sender As Object, e As EventArgs) Handles BtnSaveUpdate.Click
        XtraMessageBox.Show("Fitur simpan belum tersedia.",
                            "Master Department", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

End Class