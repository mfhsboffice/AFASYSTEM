Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Public Class XtraFormRptHistoryAFA
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2 As DataTable
    Dim tblEmployee As DataTable
    Dim tblLog As DataTable

    Sub AFAHistoryy()


        Cursor.Current = Cursors.WaitCursor


        Dim shostname, user
        shostname = System.Net.Dns.GetHostName
        user = SystemInformation.UserName



        Dim P, S, DB As String
        P = Trim(FormFluMenu.TxtP.Caption)
        DB = Trim(FormFluMenu.TxtDB.Caption)
        S = Trim(FormFluMenu.TxtSer.Caption)

        Dim connectionString As String = "Data Source= " & S & ";Initial Catalog=" & DB & "; Persist Security Info=True; User ID=sa; Password=" & P & ""
        Dim Database As New SqlClient.SqlConnection(connectionString)
        Database.Open()
        ' ----- Membuat command dasar
        Dim Commandku As New SqlClient.SqlCommand()
        Commandku.CommandType = CommandType.StoredProcedure
        Commandku.Connection = Database

        Commandku.CommandText = "AFA_Rpt_History_Proc"
        Dim userid = FormFluMenu.btnuserid.Caption

        Dim fromdate = Format(DTFrom.Value, "yyyyMMdd")
        Dim todate = Format(DTTo.Value, "yyyyMMdd")


        Commandku.Parameters.AddWithValue("@Userid", userid)
        Commandku.Parameters.AddWithValue("@dtfrom", fromdate)
        Commandku.Parameters.AddWithValue("@dtto", todate)
        Commandku.Parameters.AddWithValue("@pc", shostname)


        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output


        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If outParam.Value = "OK" Then
            Cursor.Current = Cursors.Default
            data()

        ElseIf outParam.Value = "NOTOK" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()




    End Sub
    Sub data()
        Dim shostname As String
        shostname = System.Net.Dns.GetHostName
        Dim user = Trim(FormFluMenu.btnuserid.Caption)
        tblDept = Proses.ExecuteQuery("select s1	BUDGET_YEAR	,s2	BUDGET_REV	,s3	AFA_TYPE	,s4	AFA_NO	,s5	CC_Desc	,s6	COST_CENTER	,s7	CONTRACT	,s8	AFA_DATE	,convert(numeric(18,2),s9)	AMT	,s10	AFA_NO_APPROVAL	,T1	NOTETEXT	,s12	STS,convert(varchar(12),d1,113) DateApp	 from Tbl_Temp  where [PCName]='" & shostname & "' and [RptId]='RptHistoryAFA' ")



        If tblDept.Rows.Count = 0 Then
            GridControl1.DataSource = Nothing

        Else

            GridControl1.DataSource = tblDept

            Dim gridView1 As GridView = TryCast(GridControl1.MainView, GridView)

            ' Obtain created columns.

            Dim colBUDGET_YEAR As GridColumn = gridView1.Columns("BUDGET_YEAR")
            Dim colBUDGET_REV As GridColumn = gridView1.Columns("BUDGET_REV")
            Dim colAFA_TYPE As GridColumn = gridView1.Columns("AFA_TYPE")
            Dim colAFA_NO As GridColumn = gridView1.Columns("AFA_NO")
            Dim colCCDesc As GridColumn = gridView1.Columns("CC_Desc")
            Dim colCOST_CENTER As GridColumn = gridView1.Columns("COST_CENTER")
            Dim colCONTRACT As GridColumn = gridView1.Columns("CONTRACT")
            Dim colAFA_DATE As GridColumn = gridView1.Columns("AFA_DATE")
            Dim colAMT As GridColumn = gridView1.Columns("AMT")
            Dim colAFA_NO_APPROVAL As GridColumn = gridView1.Columns("AFA_NO_APPROVAL")
            Dim COlNotetext As GridColumn = gridView1.Columns("NOTETEXT")
            Dim ColSts As GridColumn = gridView1.Columns("STS")
            Dim colDateApp As GridColumn = gridView1.Columns("DateApp")


            'colpwd.Visible = False



        End If

    End Sub

    Private Sub BtmnViewDoc_Click(sender As Object, e As EventArgs) Handles BtmnViewDoc.Click
        AFAHistoryy()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Dispose()
    End Sub

    Private Sub BtntoExcel_Click(sender As Object, e As EventArgs) Handles BtntoExcel.Click
        Dim shostname As String
        shostname = System.Net.Dns.GetHostName
        Dim namafile = Format(Now, "yyyyMMddss")
        Dim loc = Application.StartupPath & "\Temp\Rpt_History_AFA_" & shostname & namafile & ".xls"
        Dim path As String = loc
        GridControl1.ExportToXlsx(path)
        ' Open the created XLSX file with the default application.
        Process.Start(path)
    End Sub

    Dim CM As CurrencyManager

    Private Sub XtraFormRptHistoryAFA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SplitContainer1.SplitterDistance = 90
        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraFormRptHistoryAFA_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            SplitContainer1.SplitterDistance = 90
        Catch ex As Exception

        End Try
    End Sub
End Class