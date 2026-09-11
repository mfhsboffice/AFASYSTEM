Imports System.Data
Imports DevExpress.XtraEditors

Public Class XtraFormAfaType

    Private ReadOnly _service As New AfaTypeService()

    ' -- AFA Type tab state --
    Private _dtType As DataTable
    Private _selectedTypeCode As String = String.Empty

    ' -- AFA Sub-Type tab state --
    Private _dtTypeForFilter As DataTable
    Private _dtSubType As DataTable
    Private _selectedSubTypeCode As String = String.Empty

#Region "Form Lifecycle"

    Private Sub XtraFormAfaType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Master AFA Type"
        SetupGrids()

        LoadTypeList()
        ClearTypeInput()

        LoadSubTypeFilterCombo()
        ClearSubTypeInput()
    End Sub

#End Region

#Region "Grid Setup"

    Private Sub SetupGrids()
        With GridViewType
            .OptionsBehavior.Editable = False
            .OptionsSelection.EnableAppearanceFocusedCell = False
            .FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        End With

        With GridViewSubType
            .OptionsBehavior.Editable = False
            .OptionsSelection.EnableAppearanceFocusedCell = False
            .FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        End With
    End Sub

    Private Sub ConfigureTypeColumns()
        With GridViewType
            If .Columns.Count = 0 Then Return
            If .Columns("CODE") IsNot Nothing Then .Columns("CODE").Caption = "Code" : .Columns("CODE").Width = 80
            If .Columns("NAME") IsNot Nothing Then .Columns("NAME").Caption = "Name" : .Columns("NAME").Width = 220
            If .Columns("DESCR") IsNot Nothing Then .Columns("DESCR").Caption = "Description" : .Columns("DESCR").Width = 320
            If .Columns("IS_ACTIVE") IsNot Nothing Then .Columns("IS_ACTIVE").Caption = "Active" : .Columns("IS_ACTIVE").Width = 60
            If .Columns("DATECREATE") IsNot Nothing Then .Columns("DATECREATE").Visible = False
        End With
    End Sub

    Private Sub ConfigureSubTypeColumns()
        With GridViewSubType
            If .Columns.Count = 0 Then Return
            If .Columns("AFA_TYPE") IsNot Nothing Then .Columns("AFA_TYPE").Visible = False
            If .Columns("CODE") IsNot Nothing Then .Columns("CODE").Caption = "Code" : .Columns("CODE").Width = 80
            If .Columns("NAME") IsNot Nothing Then .Columns("NAME").Caption = "Name" : .Columns("NAME").Width = 320
            If .Columns("SEQ") IsNot Nothing Then .Columns("SEQ").Caption = "Seq" : .Columns("SEQ").Width = 60
            If .Columns("IS_ACTIVE") IsNot Nothing Then .Columns("IS_ACTIVE").Caption = "Active" : .Columns("IS_ACTIVE").Width = 60
            If .Columns("DATECREATE") IsNot Nothing Then .Columns("DATECREATE").Visible = False
        End With
    End Sub

#End Region

#Region "AFA Type Tab"

    Private Sub LoadTypeList()
        Cursor.Current = Cursors.WaitCursor
        Try
            GridControlType.DataSource = Nothing
            _dtType = _service.GetTypeList()

            If _dtType Is Nothing Then
                XtraMessageBox.Show("Failed to retrieve AFA type data." & vbCrLf & _service.LastErrorMessage,
                                    "Master AFA Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            GridControlType.DataSource = _dtType
            ConfigureTypeColumns()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ClearTypeInput()
        _selectedTypeCode = String.Empty
        TextEditTypeCode.Text = String.Empty
        TextEditTypeName.Text = String.Empty
        MemoEditTypeDescr.Text = String.Empty
        CheckEditTypeActive.Checked = True
        TextEditTypeCode.Properties.ReadOnly = False
        BtnTypeSaveUpdate.Text = "Save"
    End Sub

    Private Sub GridViewType_FocusedRowChanged(sender As Object,
            e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewType.FocusedRowChanged
        If e.FocusedRowHandle < 0 Then Return

        Dim row As DataRowView = TryCast(GridViewType.GetRow(e.FocusedRowHandle), DataRowView)
        If row Is Nothing Then Return

        _selectedTypeCode = Convert.ToString(row("CODE")).Trim()
        TextEditTypeCode.Text = _selectedTypeCode
        TextEditTypeName.Text = Convert.ToString(row("NAME"))
        MemoEditTypeDescr.Text = If(IsDBNull(row("DESCR")), String.Empty, Convert.ToString(row("DESCR")))
        CheckEditTypeActive.Checked = Convert.ToBoolean(row("IS_ACTIVE"))

        ' CODE is the key - locked once a row is loaded for edit
        TextEditTypeCode.Properties.ReadOnly = True
        BtnTypeSaveUpdate.Text = "Update"
    End Sub

    Private Sub BtnTypeSaveUpdate_Click(sender As Object, e As EventArgs) Handles BtnTypeSaveUpdate.Click
        Dim code As String = TextEditTypeCode.Text.Trim()
        Dim name As String = TextEditTypeName.Text.Trim()

        If String.IsNullOrEmpty(code) Then
            XtraMessageBox.Show("Type code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextEditTypeCode.Focus()
            Return
        End If

        If String.IsNullOrEmpty(name) Then
            XtraMessageBox.Show("Type name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextEditTypeName.Focus()
            Return
        End If

        Dim verb As String = If(String.IsNullOrEmpty(_selectedTypeCode), "Save", "Update")
        If XtraMessageBox.Show($"{verb} type {code}?", "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
            Return
        End If

        Cursor.Current = Cursors.WaitCursor
        Try
            Dim isSuccess As Boolean = _service.SaveType(code, name, MemoEditTypeDescr.Text.Trim(), CheckEditTypeActive.Checked)

            If isSuccess Then
                XtraMessageBox.Show(_service.LastErrorMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTypeList()
                ClearTypeInput()
                LoadSubTypeFilterCombo()
            Else
                XtraMessageBox.Show(_service.LastErrorMessage, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnTypeClear_Click(sender As Object, e As EventArgs) Handles BtnTypeClear.Click
        ClearTypeInput()
    End Sub

    Private Sub BtnTypeRefresh_Click(sender As Object, e As EventArgs) Handles BtnTypeRefresh.Click
        LoadTypeList()
        ClearTypeInput()
    End Sub

#End Region

#Region "AFA Sub-Type Tab"

    ''' <summary>Fills the parent-type combo with "CODE - NAME" entries.</summary>
    Private Sub LoadSubTypeFilterCombo()
        _dtTypeForFilter = _service.GetTypeList()

        Dim previouslySelected As String = GetSelectedFilterTypeCode()

        ComboBoxEditSubTypeFilter.Properties.Items.Clear()

        If _dtTypeForFilter Is Nothing OrElse _dtTypeForFilter.Rows.Count = 0 Then
            XtraMessageBox.Show("AFA type master data is empty or failed to load." & vbCrLf & _service.LastErrorMessage,
                                "Master AFA Sub-Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        For Each row As DataRow In _dtTypeForFilter.Rows
            ComboBoxEditSubTypeFilter.Properties.Items.Add(
                Convert.ToString(row("CODE")) & " - " & Convert.ToString(row("NAME")))
        Next

        If Not String.IsNullOrEmpty(previouslySelected) Then
            SelectFilterType(previouslySelected)
        End If
    End Sub

    ''' <summary>CODE behind whichever "CODE - NAME" item is chosen in the filter combo.</summary>
    Private Function GetSelectedFilterTypeCode() As String
        If ComboBoxEditSubTypeFilter.SelectedIndex < 0 Then Return String.Empty
        If _dtTypeForFilter Is Nothing OrElse ComboBoxEditSubTypeFilter.SelectedIndex >= _dtTypeForFilter.Rows.Count Then Return String.Empty

        Return Convert.ToString(_dtTypeForFilter.Rows(ComboBoxEditSubTypeFilter.SelectedIndex)("CODE"))
    End Function

    Private Sub SelectFilterType(ByVal code As String)
        If _dtTypeForFilter Is Nothing Then Return

        Dim rows() As DataRow = _dtTypeForFilter.Select("CODE = '" & code.Replace("'", "''") & "'")
        If rows.Length = 0 Then
            ComboBoxEditSubTypeFilter.SelectedIndex = -1
            Return
        End If

        Dim display As String = Convert.ToString(rows(0)("CODE")) & " - " & Convert.ToString(rows(0)("NAME"))
        ComboBoxEditSubTypeFilter.SelectedIndex = ComboBoxEditSubTypeFilter.Properties.Items.IndexOf(display)
    End Sub

    Private Sub ComboBoxEditSubTypeFilter_SelectedIndexChanged(sender As Object, e As EventArgs) _
            Handles ComboBoxEditSubTypeFilter.SelectedIndexChanged
        ClearSubTypeInput()
        LoadSubTypeList()
    End Sub

    Private Sub LoadSubTypeList()
        Dim afaType As String = GetSelectedFilterTypeCode()

        GridControlSubType.DataSource = Nothing
        If String.IsNullOrEmpty(afaType) Then Return

        Cursor.Current = Cursors.WaitCursor
        Try
            _dtSubType = _service.GetSubTypeList(afaType)

            If _dtSubType Is Nothing Then
                XtraMessageBox.Show("Failed to retrieve sub-type data." & vbCrLf & _service.LastErrorMessage,
                                    "Master AFA Sub-Type", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            GridControlSubType.DataSource = _dtSubType
            ConfigureSubTypeColumns()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ClearSubTypeInput()
        _selectedSubTypeCode = String.Empty
        TextEditSubTypeCode.Text = String.Empty
        TextEditSubTypeName.Text = String.Empty
        SpinEditSubTypeSeq.Value = 0
        CheckEditSubTypeActive.Checked = True
        TextEditSubTypeCode.Properties.ReadOnly = False
        BtnSubTypeSaveUpdate.Text = "Save"
    End Sub

    Private Sub GridViewSubType_FocusedRowChanged(sender As Object,
            e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewSubType.FocusedRowChanged
        If e.FocusedRowHandle < 0 Then Return

        Dim row As DataRowView = TryCast(GridViewSubType.GetRow(e.FocusedRowHandle), DataRowView)
        If row Is Nothing Then Return

        _selectedSubTypeCode = Convert.ToString(row("CODE")).Trim()
        TextEditSubTypeCode.Text = _selectedSubTypeCode
        TextEditSubTypeName.Text = Convert.ToString(row("NAME"))
        SpinEditSubTypeSeq.Value = Convert.ToDecimal(row("SEQ"))
        CheckEditSubTypeActive.Checked = Convert.ToBoolean(row("IS_ACTIVE"))

        TextEditSubTypeCode.Properties.ReadOnly = True
        BtnSubTypeSaveUpdate.Text = "Update"
    End Sub

    Private Sub BtnSubTypeSaveUpdate_Click(sender As Object, e As EventArgs) Handles BtnSubTypeSaveUpdate.Click
        Dim afaType As String = GetSelectedFilterTypeCode()

        If String.IsNullOrEmpty(afaType) Then
            XtraMessageBox.Show("Choose an AFA type first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboBoxEditSubTypeFilter.Focus()
            Return
        End If

        Dim code As String = TextEditSubTypeCode.Text.Trim()
        Dim name As String = TextEditSubTypeName.Text.Trim()

        If String.IsNullOrEmpty(code) Then
            XtraMessageBox.Show("Sub-type code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextEditSubTypeCode.Focus()
            Return
        End If

        If code = "*" Then
            XtraMessageBox.Show("""*"" is reserved for the default SRI rule and cannot be used as a sub-type code.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextEditSubTypeCode.Focus()
            Return
        End If

        If String.IsNullOrEmpty(name) Then
            XtraMessageBox.Show("Sub-type name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextEditSubTypeName.Focus()
            Return
        End If

        Dim verb As String = If(String.IsNullOrEmpty(_selectedSubTypeCode), "Save", "Update")
        If XtraMessageBox.Show($"{verb} sub-type {code} under {afaType}?", "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
            Return
        End If

        Cursor.Current = Cursors.WaitCursor
        Try
            Dim seq As Integer = Convert.ToInt32(SpinEditSubTypeSeq.Value)
            Dim isSuccess As Boolean = _service.SaveSubType(afaType, code, name, seq, CheckEditSubTypeActive.Checked)

            If isSuccess Then
                XtraMessageBox.Show(_service.LastErrorMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadSubTypeList()
                ClearSubTypeInput()
            Else
                XtraMessageBox.Show(_service.LastErrorMessage, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnSubTypeClear_Click(sender As Object, e As EventArgs) Handles BtnSubTypeClear.Click
        ClearSubTypeInput()
    End Sub

    Private Sub BtnSubTypeRefresh_Click(sender As Object, e As EventArgs) Handles BtnSubTypeRefresh.Click
        LoadSubTypeList()
        ClearSubTypeInput()
    End Sub

#End Region

End Class