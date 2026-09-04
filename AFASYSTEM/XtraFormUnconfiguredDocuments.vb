Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class XtraFormUnconfiguredDocuments

    Private ReadOnly _service As New UnconfiguredDocumentsService()

    Private _dtList As DataTable

    Private ReadOnly _nik As String = Trim(FormFluMenu.btnuserid.Caption)

#Region "Form Lifecycle"

    Private Sub XtraFormUnconfiguredDocuments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGrid()
        LoadList()
    End Sub

#End Region

#Region "Setup"

    Private Sub SetupGrid()
        With GridViewUnconfiguredDocuments
            .OptionsBehavior.Editable = False
            .OptionsFind.AlwaysVisible = True
            .OptionsFind.FindNullPrompt = "Search subject, AFA number..."
            .FocusRectStyle = DrawFocusRectStyle.RowFocus

            .OptionsView.ShowGroupPanel = False
            .OptionsCustomization.AllowColumnResizing = True
        End With
    End Sub

#End Region

#Region "Data"

    Private Sub LoadList()
        Cursor.Current = Cursors.WaitCursor
        Try
            GridControlUnconfiguredDocuments.DataSource = Nothing

            _dtList = _service.GetList(_nik, "")

            If _dtList Is Nothing Then
                XtraMessageBox.Show("Failed to retrieve data." & vbCrLf & _service.LastErrorMessage,
                                    "Unconfigured Documents", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            GridControlUnconfiguredDocuments.DataSource = _dtList
            ConfigureColumns()
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ConfigureColumns()
        With GridViewUnconfiguredDocuments
            If .Columns.Count = 0 Then Return
            HideColumn("AFA_TYPE")
            HideColumn("DEPT_ID")
            HideColumn("DEPT_PREFIX")
            HideColumn("PRIORITY")
            HideColumn("CREATED_NIK")
            HideColumn("CREATED_BY")
            HideColumn("DAYS_IN_DRAFT")
            HideColumn("FILLED_NODES")
            HideColumn("HAS_SUPP")
            HideColumn("HAS_DIR")

            SetColumn("AFA_NO", "No. AFA")
            SetColumn("AFA_TYPE_NAME", "Type")
            SetColumn("SUB_TYPE_NAME", "Sub Type")
            SetColumn("DEPT_NAME", "Department")
            SetColumn("SUBJECT", "Subject")
            SetColumn("PRIORITY_LABEL", "Priority")
            SetColumn("CREATED_DATE", "Draft At")
            .BestFitColumns()
        End With
    End Sub

    Private Sub HideColumn(ByVal fieldName As String)
        If GridViewUnconfiguredDocuments.Columns(fieldName) IsNot Nothing Then
            GridViewUnconfiguredDocuments.Columns(fieldName).Visible = False
        End If
    End Sub

    Private Sub SetColumn(ByVal fieldName As String, ByVal caption As String)
        Dim col = GridViewUnconfiguredDocuments.Columns(fieldName)
        If col Is Nothing Then Return

        col.Caption = caption
        col.Visible = True ' Pastikan kolom tampil
        col.OptionsColumn.AllowEdit = False
    End Sub

#End Region

#Region "Events"

    Private Sub GridViewUnconfiguredDocuments_DoubleClick(sender As Object, e As EventArgs) Handles GridViewUnconfiguredDocuments.DoubleClick

        Dim rowHandle As Integer = GridViewUnconfiguredDocuments.FocusedRowHandle
        If rowHandle < 0 Then Return

        Dim row As DataRowView = TryCast(GridViewUnconfiguredDocuments.GetRow(rowHandle), DataRowView)
        If row Is Nothing Then Return

        Dim afaNo As String = Convert.ToString(row("AFA_NO")).Trim()
        If afaNo = "" Then Return

        Try
            Clipboard.SetText(afaNo)
        Catch
            Return
        End Try

        XtraMessageBox.Show("AFA No " & afaNo & " copied to clipboard.",
                            "Unconfigured Documents", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BtnReload_Click(sender As Object, e As EventArgs) Handles BtnReload.Click
        SetupGrid()
        LoadList()
    End Sub

#End Region

End Class