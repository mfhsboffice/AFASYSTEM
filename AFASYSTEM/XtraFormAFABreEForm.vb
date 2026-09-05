Imports System.Data
Imports DevExpress.XtraEditors

Public Class XtraFormAFABreEForm

    Private ReadOnly _service As New AFAReclassBudgetService()
    Private ReadOnly _general As New GeneralService()

    Private _dtDepartment As DataTable
    Private _dtLocation As DataTable

    Private _afaNo As String = String.Empty

    Private ReadOnly _nik As String = Trim(FormFluMenu.btnuserid.Caption)
    Private ReadOnly _pc As String = System.Net.Dns.GetHostName()

#Region "Form"

    Private Sub XtraFormAFABreEForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupEditors()
        LoadCombos()
        ClearForm()
    End Sub

    Private Sub SetupEditors()
        For Each editor As TextEdit In New TextEdit() {TextEditBudgetAmtSource, TextEditBudgetAmtTarget,
                                                       TextEditActualUpSource, TextEditActualUpTarget,
                                                       TextEditShortageSource, TextEditReclassAmount,
                                                       TextEditBalanceTarget, TextEditTotalReclass}
            With editor.Properties
                .ReadOnly = True
                .Appearance.Options.UseTextOptions = True
                .Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
                .MaskSettings.Set("mask", "n0")
                .UseMaskAsDisplayFormat = True
            End With
        Next

        With TextEditEstimationSource.Properties
            .Appearance.Options.UseTextOptions = True
            .Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
            .MaskSettings.Set("mask", "n0")
            .UseMaskAsDisplayFormat = True
        End With

        With TextEditBudgetYear.Properties
            .MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
            .MaskSettings.Set("mask", "d")
            .MaxLength = 4
        End With
    End Sub

#End Region

#Region "Combo"

    Private Sub LoadCombos()
        LoadDepartment()
        LoadLocation()

        TextEditBudgetYear.Text = Date.Today.Year.ToString()
    End Sub

    Private Sub LoadDepartment()
        _dtDepartment = _general.GetDepartmentsByNik(_nik)

        SelectDepartment.Properties.Items.Clear()

        If _dtDepartment Is Nothing OrElse _dtDepartment.Rows.Count = 0 Then
            XtraMessageBox.Show("NIK " & _nik & " is not mapped to any department." & vbCrLf &
                                "Please ask an administrator to set up the User Department Mapping.",
                                "E-Form AFA Reclass Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    Private Function GetSelectedValue(ByVal combo As ComboBoxEdit,
                                      ByVal dt As DataTable,
                                      ByVal columnName As String) As Object
        If dt Is Nothing Then Return Nothing
        If combo.SelectedIndex < 0 OrElse combo.SelectedIndex >= dt.Rows.Count Then Return Nothing
        Return dt.Rows(combo.SelectedIndex)(columnName)
    End Function

#End Region

#Region "Validation"

    Private Function IsValid() As Boolean
        If SelectDepartment.SelectedIndex < 0 Then
            Warn("Please select a Department.", SelectDepartment) : Return False
        End If

        If SelectLocation.SelectedIndex < 0 Then
            Warn("Please select a Location.", SelectLocation) : Return False
        End If

        Dim year As Integer
        If Not Integer.TryParse(TextEditBudgetYear.Text.Trim(), year) OrElse year < 2000 OrElse year > 2999 Then
            Warn("Budget Year must be a four-digit number.", TextEditBudgetYear) : Return False
        End If

        If TextEditSubject.Text.Trim() = "" Then
            Warn("Subject is required.", TextEditSubject) : Return False
        End If

        If MemoEditBgExp.Text.Trim() = "" Then
            Warn("Background & Explanation is required.", MemoEditBgExp) : Return False
        End If

        If DateEditScheduleFrom.EditValue IsNot Nothing AndAlso DateEditScheduleTo.EditValue IsNot Nothing Then
            If DateEditScheduleTo.DateTime < DateEditScheduleFrom.DateTime Then
                Warn("Schedule To cannot be earlier than Schedule From.", DateEditScheduleTo) : Return False
            End If
        End If

        Return True
    End Function

    Private Sub Warn(ByVal message As String, ByVal ctl As Control)
        XtraMessageBox.Show(message, "E-Form AFA Reclass Budget",
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

            ' BRE has no currency selector on this form: budget reclass figures
            ' come straight from IFS in USD, matching AFA_NON_IFS.CURCODE's
            ' default and BUDGET_CURR_RATE being USD-based.
            Dim curCode As String = "USD"

            Dim perFrom As Object = If(DateEditScheduleFrom.EditValue Is Nothing, Nothing, DateEditScheduleFrom.DateTime.Date)
            Dim perTo As Object = If(DateEditScheduleTo.EditValue Is Nothing, Nothing, DateEditScheduleTo.DateTime.Date)

            Dim savedNo As String = _service.SaveHeader(
                _afaNo, locCode, deptId,
                TextEditBudgetYear.Text.Trim(), TextEditBudgetRevision.Text.Trim(),
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

            ' The Source/Target budget-item lookup (LookupBudgetItemSource /
            ' LookupBudgetItemTarget) has no data source wired to it: there is
            ' no procedure in this module that can browse budget items from
            ' IFS (AFA_NonIFS_GetBudgetFromIFS_Proc needs an exact CC/Contract/
            ' Allocation key, which nothing on this form collects), and
            ' TextEditBudgetAmt(Source/Target) / TextEditActualUp(Source/Target)
            ' are locked ReadOnly with no way to populate them. Saving a
            ' Source/Target row here would mean writing BUDGET_AMOUNT = 0 and
            ' ACTUAL_UP = 0 into a financial document, so this step is refused
            ' rather than done silently. AFA_NonIFS_Submit_Proc already blocks
            ' Submit while the detail rows are empty, so the document is safe
            ' to leave as a Draft until the lookup is implemented.
            XtraMessageBox.Show(
                "Header saved as " & _afaNo & "." & vbCrLf & vbCrLf &
                "The Source/Target budget item lookup is not wired up yet, " &
                "so the budget item detail could not be saved. This document " &
                "will stay as Draft until that is implemented.",
                "E-Form AFA Reclass Budget", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Me.Text = "E-Form AFA Reclass Budget - " & _afaNo
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

#Region "Helpers"

    Private Sub ClearForm()
        _afaNo = String.Empty

        SelectLocation.SelectedIndex = -1
        TextEditSubject.Text = ""
        MemoEditPurpose.Text = ""
        MemoEditBgExp.Text = ""
        TextEditBudgetRevision.Text = ""

        TextEditEstimationSource.Text = "0"
        TextEditBudgetAmtSource.Text = "0"
        TextEditBudgetAmtTarget.Text = "0"
        TextEditActualUpSource.Text = "0"
        TextEditActualUpTarget.Text = "0"
        TextEditShortageSource.Text = "0"
        TextEditReclassAmount.Text = "0"
        TextEditBalanceTarget.Text = "0"
        TextEditTotalReclass.Text = "0"

        DateEditScheduleFrom.EditValue = Nothing
        DateEditScheduleTo.EditValue = Nothing

        Me.Text = "E-Form AFA Reclass Budget"
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

#End Region

End Class
