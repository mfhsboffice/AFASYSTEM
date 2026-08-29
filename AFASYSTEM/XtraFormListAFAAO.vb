Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports System.Globalization
Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils.Menu


Public Class XtraFormListAFAAO
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2 As DataTable
    Dim tblEmployee As DataTable

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        showdata()
    End Sub

    Private Sub BtmnViewDoc_Click(sender As Object, e As EventArgs) Handles BtmnViewDoc.Click
        If Trim(lblafa.Text) = "" Then MsgBox("Please Double Click Afa first") : Exit Sub




        XtraFormAttch.TxtAfa.Text = Trim(lblafa.Text)
        XtraFormAttch.BtnAddInf.Visible = False

        XtraFormAttch.AFAPdf()
            XtraFormAttch.openfile()
            XtraFormAttch.ShowDialog()

    End Sub
    Private Sub XtraFormListAFAAO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtmnViewDoc.Enabled = False
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Sub isitext()
        lblafa.Text = GridView1.Columns.View.GetFocusedRowCellValue("AFA_NO").ToString

        BtmnViewDoc.Enabled = True
    End Sub
    Sub showdata()
        If DtyyyymmFrom.Text = "" Then MsgBox("Isi Period") : Exit Sub
        If DtyyyymmTo.Text = "" Then MsgBox("Isi Period") : Exit Sub
        Dim yyyymma = DtyyyymmFrom.Text
        Dim yyyymmb = DtyyyymmTo.Text
        tblDept = Proses.ExecuteQuery("SELECT [AFA_NO],[NOTETEXT] DESCRIPTION,[AFA_DATE],    [SCHEDULE] ,[AMT]   ,[STS]    ,isnull([ASSET],'') Asset      ,[CC_Desc] Dept FROM [AFASYS].[dbo].[AFA_H] a where a.STS<>'Cancelled' and convert(varchar(6),a.AFA_DATE,112) between '" & yyyymma & "' and '" & yyyymmb & "' order by a.CC_Desc,a.AFA_NO asc")


        If tblDept.Rows.Count = 0 Then
            GridControl1.DataSource = Nothing

        Else

            GridControl1.DataSource = tblDept


            Dim gridView1 As GridView = TryCast(GridControl1.MainView, GridView)


            ' Obtain created columns.
            Dim colafa As GridColumn = gridView1.Columns("AFA_NO")
            Dim coldes As GridColumn = gridView1.Columns("DESCRIPTION")



            ' Make the grid read-only.
            gridView1.OptionsBehavior.Editable = False
            ' Prevent the focused cell from being highlighted.
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            ' Draw a dotted focus rectangle around the entire row.
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

        End If
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        isitext()
    End Sub
End Class