Imports System.Data
Imports DevExpress.XtraEditors

Public Class XtraFormSriRule

    Private Const NoneItem As String = "(none)"
    Private Const NoSubTypeCode As String = "*"
    Private Const NoSubTypeDisplay As String = "* (default / belum pilih sub-type)"

    Private ReadOnly _service As New SriRuleService()
    Private ReadOnly _typeService As New AfaTypeService()

    Private ReadOnly _nik As String = Trim(FormFluMenu.btnuserid.Caption)

    Private _dtType As DataTable
    Private _dtSubType As DataTable
    Private _dtJabSign As DataTable
    Private _dtRule As DataTable

    Private _selectedAfaType As String = String.Empty
    Private _selectedSubType As String = String.Empty

#Region "Form Lifecycle"

    Private Sub XtraFormSriRule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Master SRI Rule"
        SetupGrid()

        LoadTypeCombo()
        LoadAuthCombos()
        LoadRuleList()
        ClearInput()
    End Sub

#End Region

#Region "Setup"

    Private Sub SetupGrid()
        With GridViewRule
            .OptionsBehavior.Editable = False
            .OptionsSelection.EnableAppearanceFocusedCell = False
            .FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        End With
    End Sub

    Private Sub ConfigureColumns()
        With GridViewRule
            If .Columns.Count = 0 Then Return
            If .Columns("AFA_TYPE") IsNot Nothing Then .Columns("AFA_TYPE").Visible = False
            If .Columns("AFA_TYPE_NAME") IsNot Nothing Then .Columns("AFA_TYPE_NAME").Caption = "Type" : .Columns("AFA_TYPE_NAME").Width = 140
            If .Columns("SUB_TYPE") IsNot Nothing Then .Columns("SUB_TYPE").Visible = False
            If .Columns("SUB_TYPE_NAME") IsNot Nothing Then .Columns("SUB_TYPE_NAME").Caption = "Sub-Type" : .Columns("SUB_TYPE_NAME").Width = 160
            If .Columns("SRI_ALWAYS") IsNot Nothing Then .Columns("SRI_ALWAYS").Caption = "Always" : .Columns("SRI_ALWAYS").Width = 60
            If .Columns("SRI_THRESHOLD") IsNot Nothing Then .Columns("SRI_THRESHOLD").Caption = "Threshold (JPY)" : .Columns("SRI_THRESHOLD").Width = 110
            If .Columns("REF_REG") IsNot Nothing Then .Columns("REF_REG").Caption = "Reference" : .Columns("REF_REG").Width = 160
            If .Columns("AUTH1_JAB") IsNot Nothing Then .Columns("AUTH1_JAB").Caption = "Authorizer 1" : .Columns("AUTH1_JAB").Width = 140
            If .Columns("AUTH2_JAB") IsNot Nothing Then .Columns("AUTH2_JAB").Caption = "Authorizer 2" : .Columns("AUTH2_JAB").Width = 140
            If .Columns("IS_ACTIVE") IsNot Nothing Then .Columns("IS_ACTIVE").Caption = "Active" : .Columns("IS_ACTIVE").Width = 60
            If .Columns("DATECREATE") IsNot Nothing Then .Columns("DATECREATE").Visible = False
            If .Columns("USERUPDATE") IsNot Nothing Then .Columns("USERUPDATE").Visible = False
            If .Columns("DATEUPDATE") IsNot Nothing Then .Columns("DATEUPDATE").Visible = False
        End With
    End Sub

#End Region

#Region "Combo Loading"

    Private Sub LoadTypeCombo()
        _dtType = _typeService.GetTypeList()

        ComboBoxEditRuleType.Properties.Items.Clear()

        If _dtType Is Nothing OrElse _dtType.Rows.Count = 0 Then
            XtraMessageBox.Show("AFA type master data is empty or failed to load." & vbCrLf & _typeService.LastErrorMessage,
                                "Master SRI Rule", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        For Each row As DataRow In _dtType.Rows
            ComboBoxEditRuleType.Properties.Items.Add(
                Convert.ToString(row("CODE")) & " - " & Convert.ToString(row("NAME")))
        Next
    End Sub

    Private Function GetSelectedRuleTypeCode() As String
        If ComboBoxEditRuleType.SelectedIndex < 0 Then Return String.Empty
        If _dtType Is Nothing OrElse ComboBoxEditRuleType.SelectedIndex >= _dtType.Rows.Count Then Return String.Empty

        Return Convert.ToString(_dtType.Rows(ComboBoxEditRuleType.SelectedIndex)("CODE"))
    End Function

    Private Sub SelectRuleType(ByVal code As String)
        If _dtType Is Nothing Then Return

        Dim rows() As DataRow = _dtType.Select("CODE = '" & code.Replace("'", "''") & "'")
        If rows.Length = 0 Then
            ComboBoxEditRuleType.SelectedIndex = -1
            Return
        End If

        Dim display As String = Convert.ToString(rows(0)("CODE")) & " - " & Convert.ToString(rows(0)("NAME"))
        ComboBoxEditRuleType.SelectedIndex = ComboBoxEditRuleType.Properties.Items.IndexOf(display)
    End Sub

    ''' <summary>Sub-type combo for the currently selected AFA type; entry 0 is always the "*" default row.</summary>
    Private Sub LoadSubTypeCombo()
        Dim afaType As String = GetSelectedRuleTypeCode()

        ComboBoxEditRuleSubType.Properties.Items.Clear()
        ComboBoxEditRuleSubType.Properties.Items.Add(NoSubTypeDisplay)
        _dtSubType = Nothing

        If String.IsNullOrEmpty(afaType) Then
            ComboBoxEditRuleSubType.SelectedIndex = 0
            Return
        End If

        _dtSubType = _typeService.GetSubTypeList(afaType)

        If _dtSubType IsNot Nothing Then
            For Each row As DataRow In _dtSubType.Rows
                ComboBoxEditRuleSubType.Properties.Items.Add(
                    Convert.ToString(row("CODE")) & " - " & Convert.ToString(row("NAME")))
            Next
        End If

        ComboBoxEditRuleSubType.SelectedIndex = 0
    End Sub

    ''' <summary>"*" for the default entry, otherwise the CODE behind the chosen "CODE - NAME" item.</summary>
    Private Function GetSelectedRuleSubTypeCode() As String
        If ComboBoxEditRuleSubType.SelectedIndex <= 0 Then Return NoSubTypeCode
        If _dtSubType Is Nothing Then Return NoSubTypeCode

        Dim rowIndex As Integer = ComboBoxEditRuleSubType.SelectedIndex - 1
        If rowIndex >= _dtSubType.Rows.Count Then Return NoSubTypeCode

        Return Convert.ToString(_dtSubType.Rows(rowIndex)("CODE"))
    End Function

    Private Sub SelectRuleSubType(ByVal code As String)
        If code = NoSubTypeCode OrElse String.IsNullOrEmpty(code) Then
            ComboBoxEditRuleSubType.SelectedIndex = 0
            Return
        End If

        If _dtSubType Is Nothing Then
            ComboBoxEditRuleSubType.SelectedIndex = 0
            Return
        End If

        Dim rows() As DataRow = _dtSubType.Select("CODE = '" & code.Replace("'", "''") & "'")
        If rows.Length = 0 Then
            ComboBoxEditRuleSubType.SelectedIndex = 0
            Return
        End If

        Dim display As String = Convert.ToString(rows(0)("CODE")) & " - " & Convert.ToString(rows(0)("NAME"))
        Dim idx As Integer = ComboBoxEditRuleSubType.Properties.Items.IndexOf(display)
        ComboBoxEditRuleSubType.SelectedIndex = If(idx < 0, 0, idx)
    End Sub

    ''' <summary>Authorizer combos: entry 0 is "(none)", the rest are AFA_JAB_SIGN.Jabatan values directly.</summary>
    Private Sub LoadAuthCombos()
        _dtJabSign = _service.GetJabSignList()

        For Each combo As ComboBoxEdit In New ComboBoxEdit() {ComboBoxEditAuth1, ComboBoxEditAuth2}
            combo.Properties.Items.Clear()
            combo.Properties.Items.Add(NoneItem)

            If _dtJabSign IsNot Nothing Then
                For Each row As DataRow In _dtJabSign.Rows
                    combo.Properties.Items.Add(Convert.ToString(row("Jabatan")))
                Next
            End If

            combo.SelectedIndex = 0
        Next
    End Sub

    Private Function GetSelectedAuth(ByVal combo As ComboBoxEdit) As String
        If combo.SelectedIndex <= 0 Then Return String.Empty
        Return Convert.ToString(combo.Properties.Items(combo.SelectedIndex))
    End Function

    Private Sub SelectAuth(ByVal combo As ComboBoxEdit, ByVal jabatan As String)
        If String.IsNullOrEmpty(jabatan) Then
            combo.SelectedIndex = 0
            Return
        End If

        Dim idx As Integer = combo.Properties.Items.IndexOf(jabatan)
        combo.SelectedIndex = If(idx < 0, 0, idx)
    End Sub

#End Region

#Region "Rule List"

    Private Sub LoadRuleList()
        Cursor.Current = Cursors.WaitCursor
        Try
            GridControlRule.DataSource = Nothing
            _dtRule = _service.GetRuleList()

            If _dtRule Is Nothing Then
                XtraMessageBox.Show("Failed to retrieve SRI rule data." & vbCrLf & _service.LastErrorMessage,
                                    "Master SRI Rule", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            GridControlRule.DataSource = _dtRule
            ConfigureColumns()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ClearInput()
        _selectedAfaType = String.Empty
        _selectedSubType = String.Empty

        ComboBoxEditRuleType.SelectedIndex = -1
        LoadSubTypeCombo()
        CheckEditSriAlways.Checked = False
        SpinEditSriThreshold.Value = 0
        SpinEditSriThreshold.Enabled = True
        TextEditRefReg.Text = String.Empty
        ComboBoxEditAuth1.SelectedIndex = 0
        ComboBoxEditAuth2.SelectedIndex = 0
        CheckEditRuleActive.Checked = True

        ComboBoxEditRuleType.Enabled = True
        ComboBoxEditRuleSubType.Enabled = True
        BtnRuleSaveUpdate.Text = "Save"

        ComboBoxEditRuleType.Focus()
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub ComboBoxEditRuleType_SelectedIndexChanged(sender As Object, e As EventArgs) _
            Handles ComboBoxEditRuleType.SelectedIndexChanged
        LoadSubTypeCombo()
    End Sub

    Private Sub CheckEditSriAlways_CheckedChanged(sender As Object, e As EventArgs) _
            Handles CheckEditSriAlways.CheckedChanged
        SpinEditSriThreshold.Enabled = Not CheckEditSriAlways.Checked
        If CheckEditSriAlways.Checked Then SpinEditSriThreshold.Value = 0
    End Sub

    Private Sub GridViewRule_FocusedRowChanged(sender As Object,
            e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewRule.FocusedRowChanged
        If e.FocusedRowHandle < 0 Then Return

        Dim row As DataRowView = TryCast(GridViewRule.GetRow(e.FocusedRowHandle), DataRowView)
        If row Is Nothing Then Return

        _selectedAfaType = Convert.ToString(row("AFA_TYPE")).Trim()
        _selectedSubType = Convert.ToString(row("SUB_TYPE")).Trim()

        SelectRuleType(_selectedAfaType)
        LoadSubTypeCombo()
        SelectRuleSubType(_selectedSubType)

        CheckEditSriAlways.Checked = Convert.ToBoolean(row("SRI_ALWAYS"))
        SpinEditSriThreshold.Value = If(IsDBNull(row("SRI_THRESHOLD")), 0D, Convert.ToDecimal(row("SRI_THRESHOLD")))
        SpinEditSriThreshold.Enabled = Not CheckEditSriAlways.Checked
        TextEditRefReg.Text = If(IsDBNull(row("REF_REG")), String.Empty, Convert.ToString(row("REF_REG")))
        SelectAuth(ComboBoxEditAuth1, If(IsDBNull(row("AUTH1_JAB")), String.Empty, Convert.ToString(row("AUTH1_JAB"))))
        SelectAuth(ComboBoxEditAuth2, If(IsDBNull(row("AUTH2_JAB")), String.Empty, Convert.ToString(row("AUTH2_JAB"))))
        CheckEditRuleActive.Checked = Convert.ToBoolean(row("IS_ACTIVE"))

        ' AFA_TYPE / SUB_TYPE form the key - locked once a row is loaded for edit
        ComboBoxEditRuleType.Enabled = False
        ComboBoxEditRuleSubType.Enabled = False
        BtnRuleSaveUpdate.Text = "Update"
    End Sub

    Private Sub BtnRuleSaveUpdate_Click(sender As Object, e As EventArgs) Handles BtnRuleSaveUpdate.Click
        Dim afaType As String = GetSelectedRuleTypeCode()

        If String.IsNullOrEmpty(afaType) Then
            XtraMessageBox.Show("Choose an AFA type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboBoxEditRuleType.Focus()
            Return
        End If

        Dim subType As String = GetSelectedRuleSubTypeCode()

        Dim auth1 As String = GetSelectedAuth(ComboBoxEditAuth1)
        Dim auth2 As String = GetSelectedAuth(ComboBoxEditAuth2)

        Dim threshold As Decimal? = Nothing
        If Not CheckEditSriAlways.Checked AndAlso SpinEditSriThreshold.Value > 0 Then
            threshold = SpinEditSriThreshold.Value
        End If

        Dim verb As String = If(String.IsNullOrEmpty(_selectedAfaType), "Save", "Update")
        If XtraMessageBox.Show($"{verb} SRI rule for {afaType} / {subType}?", "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
            Return
        End If

        Cursor.Current = Cursors.WaitCursor
        Try
            Dim isSuccess As Boolean = _service.SaveRule(
                afaType, subType, CheckEditSriAlways.Checked, threshold,
                TextEditRefReg.Text.Trim(), auth1, auth2, CheckEditRuleActive.Checked, _nik)

            If isSuccess Then
                XtraMessageBox.Show(_service.LastErrorMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadRuleList()
                ClearInput()
            Else
                XtraMessageBox.Show(_service.LastErrorMessage, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnRuleClear_Click(sender As Object, e As EventArgs) Handles BtnRuleClear.Click
        ClearInput()
    End Sub

    Private Sub BtnRuleRefresh_Click(sender As Object, e As EventArgs) Handles BtnRuleRefresh.Click
        LoadTypeCombo()
        LoadAuthCombos()
        LoadRuleList()
        ClearInput()
    End Sub

#End Region

End Class