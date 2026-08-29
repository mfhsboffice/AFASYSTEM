Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports System.Globalization
Public Class XtraFormAFAEntry
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2 As DataTable
    Dim tblEmployee As DataTable
    Dim tblLog As DataTable
    Dim CM As CurrencyManager
    Public Overridable Property VisibleIndex As Integer
    Dim ciUSA As CultureInfo = New CultureInfo("en-US")
    Dim ciEUR As CultureInfo = New CultureInfo("fr-FR", False)



    Sub data()
        Dim shostname As String
        shostname = System.Net.Dns.GetHostName
        Dim user = Trim(FormFluMenu.btnuserid.Caption)
        If Trim(user) = "02945" Then
            tblDept = Proses.ExecuteQuery("SELECT   [AFA_TYPE]      ,a.[AFA_NO]      ,[BUDGET_YEAR]      ,[BUDGET_REV]      ,[COST_CENTER]      ,[CONTRACT]      ,isnull(convert(varchar(12),[AFA_DATE],113),'') AFA_DATE     ,[AMT]      ,isnull(convert(varchar(12),[FINANCE_DATE],113),'') FINANCE_DATE ,isnull([AFA_NO_APPROVAL],'') AFA_NO_APPROVAL,isnull(convert(varchar(12),[AFA_APPROVAL_DATE],113),'')  AFA_APPROVAL_DATE ,convert(varchar(12),[AFA_PER_FROM],113) AFA_PER_FROM,convert(varchar(12),[AFA_PER_TO],113) AFA_PER_TO      ,[ASSET]      ,isnull([NOTETEXT],'') [NOTETEXT],[SCHEDULE]     ,[DATECREATE]      ,[STS]        ,[PC]      ,[USERID]  FROM [AFASYS].[dbo].[AFA_H] a  left join [dbo].[AFA_HAK_AKSES] b on b.AFA_NO=a.AFA_NO where b.nik='01776'")

        Else

            tblDept = Proses.ExecuteQuery("SELECT   [AFA_TYPE]      ,a.[AFA_NO]      ,[BUDGET_YEAR]    ,[BUDGET_REV]      ,[COST_CENTER]      ,[CONTRACT]      ,isnull(convert(varchar(12),[AFA_DATE],113),'') AFA_DATE     ,[AMT]    ,isnull(convert(varchar(12),[FINANCE_DATE],113),'') FINANCE_DATE ,isnull([AFA_NO_APPROVAL],'') AFA_NO_APPROVAL,isnull(convert(varchar(12),[AFA_APPROVAL_DATE],113),'')  AFA_APPROVAL_DATE,convert(varchar(12),[AFA_PER_FROM],113) AFA_PER_FROM,convert(varchar(12),[AFA_PER_TO],113) AFA_PER_TO      ,[ASSET]   ,isnull([NOTETEXT],'') [NOTETEXT],[SCHEDULE]     ,[DATECREATE]    ,[STS]        ,[PC]      ,A.[USERID]  FROM [AFASYS].[dbo].[AFA_H] a  left join [dbo].[AFA_HAK_AKSES] b on b.AFA_NO=a.AFA_NO LEFT JOIN [AFASYS].[dbo].[User_H] C ON C.UserIfs=B.NIK where C.UserID='" & user & "'")

        End If

        If tblDept.Rows.Count = 0 Then
            GridControl1.DataSource = Nothing

        Else

            GridControl1.DataSource = tblDept

            Dim gridView1 As GridView = TryCast(GridControl1.MainView, GridView)

            ' Obtain created columns.
            Dim colAFA_TYPE As GridColumn = gridView1.Columns("AFA_TYPE")
            Dim colAFA_NO As GridColumn = gridView1.Columns("AFA_NO")
            Dim colBUDGET_YEAR As GridColumn = gridView1.Columns("BUDGET_YEAR")
            Dim colBUDGET_REV As GridColumn = gridView1.Columns("BUDGET_REV")
            Dim colCOST_CENTER As GridColumn = gridView1.Columns("COST_CENTER")
            Dim colCONTRACT As GridColumn = gridView1.Columns("CONTRACT")
            Dim colAFA_DATE As GridColumn = gridView1.Columns("AFA_DATE")
            Dim colAMT As GridColumn = gridView1.Columns("AMT")
            Dim colFINANCE_DATE As GridColumn = gridView1.Columns("FINANCE_DATE")
            Dim colAFA_NO_APPROVAL As GridColumn = gridView1.Columns("AFA_NO_APPROVAL")
            Dim colAFA_APPROVAL_DATE As GridColumn = gridView1.Columns("AFA_APPROVAL_DATE")
            Dim colAFA_PER_FROM As GridColumn = gridView1.Columns("AFA_PER_FROM")
            Dim colASSET As GridColumn = gridView1.Columns("ASSET")
            Dim colNOTETEXT As GridColumn = gridView1.Columns("NOTETEXT")
            Dim colDATECREATE As GridColumn = gridView1.Columns("DATECREATE")
            Dim colSTS As GridColumn = gridView1.Columns("STS")
            Dim colPC As GridColumn = gridView1.Columns("PC")
            Dim colUSERID As GridColumn = gridView1.Columns("USERID")

            colAFA_TYPE.Width = 70
            colAFA_NO.Width = 200

            'colpwd.Visible = False



        End If

    End Sub
    Private Sub XtraFormAFAEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data()

        Try
            SplitContainer1.SplitterDistance = 220
        Catch ex As Exception

        End Try
    End Sub




    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If Trim(TxtAfa.Text) <> "" Then
            AFA_Download()
        End If
    End Sub
    Sub clearrr()
        TxtBudgetYear.Text = ""
        TxtRev.Text = "" '
        TxtDept.Text = "" 'tblEmployee.Rows(0).Item("COST_CENTER").ToString
        TxtSite.Text = "" ' tblEmployee.Rows(0).Item("CONTRACT").ToString
        TXtState.Text = "" 'tblEmployee.Rows(0).Item("STS").ToString
        TXtAFAType.Text = "" 'tblEmployee.Rows(0).Item("AFA_TYPE").ToString
        TXtafaDate.Text = "" 'tblEmployee.Rows(0).Item("AFA_DATE").ToString
        TxtFinDate.Text = "" 'tblEmployee.Rows(0).Item("FINANCE_DATE").ToString
        TxtAfanoApp.Text = "" 'tblEmployee.Rows(0).Item("AFA_NO_APPROVAL").ToString
        TxtAFAAPPDate.Text = "" ' tblEmployee.Rows(0).Item("AFA_APPROVAL_DATE").ToString
        TxtAFAPerFrom.Text = "" 'tblEmployee.Rows(0).Item("AFA_PER_FROM").ToString
        TxtAFAPerTo.Text = "" 'tblEmployee.Rows(0).Item("AFA_PER_TO").ToString
        TxtTotAmt.Text = "" ' tblEmployee.Rows(0).Item("AMT").ToString
        TxtSchedule.Text = "" ' tblEmployee.Rows(0).Item("SCHEDULE").ToString
    End Sub
    Sub AFA_Download()


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

        Commandku.CommandText = "AFA_DOWNLOAD_New_Proc"
        Dim userid = FormFluMenu.btnuserid.Caption
        Dim afano = Trim(TxtAfa.Text)


        Commandku.Parameters.AddWithValue("@AFA_NO", afano)
        Commandku.Parameters.AddWithValue("@USERID", userid)
        Commandku.Parameters.AddWithValue("@PCNAME", shostname)


        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output

        Dim outpesan As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Pesan", SqlDbType.VarChar, 600)
        outpesan.Direction = ParameterDirection.Output

        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If outParam.Value = "OK" Then
            Cursor.Current = Cursors.Default
            clearrr()
            data()
            isitxt()
            MsgBox(outpesan.Value.ToString)
            '  MessageBox.Show("Download AFA Success", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf outParam.Value = "NOTOK" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()




    End Sub

    Sub gridtotext()
        Try
            TxtAfa.Text = GridView1.Columns.View.GetFocusedRowCellValue("AFA_NO").ToString
            TxtBudgetYear.Text = GridView1.Columns.View.GetFocusedRowCellValue("BUDGET_YEAR").ToString
            TxtRev.Text = GridView1.Columns.View.GetFocusedRowCellValue("BUDGET_REV").ToString
            TxtDept.Text = GridView1.Columns.View.GetFocusedRowCellValue("COST_CENTER").ToString
            TxtSite.Text = GridView1.Columns.View.GetFocusedRowCellValue("CONTRACT").ToString
            TXtState.Text = GridView1.Columns.View.GetFocusedRowCellValue("STS").ToString
            TXtAFAType.Text = GridView1.Columns.View.GetFocusedRowCellValue("AFA_TYPE").ToString
            TXtafaDate.Text = GridView1.Columns.View.GetFocusedRowCellValue("AFA_DATE").ToString
            TxtFinDate.Text = GridView1.Columns.View.GetFocusedRowCellValue("FINANCE_DATE").ToString
            TxtAfanoApp.Text = GridView1.Columns.View.GetFocusedRowCellValue("AFA_NO_APPROVAL").ToString
            TxtAFAAPPDate.Text = GridView1.Columns.View.GetFocusedRowCellValue("AFA_APPROVAL_DATE").ToString
            TxtAFAPerFrom.Text = GridView1.Columns.View.GetFocusedRowCellValue("AFA_PER_FROM").ToString
            TxtAFAPerTo.Text = GridView1.Columns.View.GetFocusedRowCellValue("AFA_PER_TO").ToString
            TxtTotAmt.Text = GridView1.Columns.View.GetFocusedRowCellValue("AMT").ToString
            TxtSchedule.Text = GridView1.Columns.View.GetFocusedRowCellValue("SCHEDULE").ToString
        Catch ex As Exception

        End Try

    End Sub
    Sub cekstatusapp()
        Try
            Dim nike = Trim(FormFluMenu.btnuserid.Caption)
            Dim afano = Trim(TxtAfa.Text)
            '
            tblDept = Proses.ExecuteQuery("SELECT distinct [AFA_NO],[TYPE] FROM [AFASYS].[dbo].[AFA_SIGNATURE] A  WHERE A.TYPE='Dir' and a.NIK<>''   and a.STS  in ('App') and a.AFA_NO='" & afano & "' AND A.JAB<>'Drafter'")
            If tblDept.Rows.Count = 0 Then
                btnDownload.Enabled = True
            Else
                btnDownload.Enabled = False
            End If
        Catch ex As Exception
            btnDownload.Enabled = True
        End Try


    End Sub
    Sub isitxt()
        Dim nike = Trim(FormFluMenu.btnuserid.Caption)
        Dim afano = Trim(TxtAfa.Text)
        tblEmployee = Proses.ExecuteQuery("SELECT   [AFA_TYPE]      ,a.[AFA_NO]      ,[BUDGET_YEAR]      ,[BUDGET_REV]      ,[COST_CENTER]      ,[CONTRACT]      ,isnull(convert(varchar(12),[AFA_DATE],113),'') AFA_DATE      ,[AMT]      ,isnull(convert(varchar(12),[FINANCE_DATE],113),'') FINANCE_DATE ,isnull([AFA_NO_APPROVAL],'') AFA_NO_APPROVAL,isnull(convert(varchar(12),[AFA_APPROVAL_DATE],113),'')  AFA_APPROVAL_DATE ,convert(varchar(12),[AFA_PER_FROM],113) AFA_PER_FROM,convert(varchar(12),[AFA_PER_TO],113) AFA_PER_TO ,convert(varchar(12),[AFA_PER_TO],113) AFA_PER_TO     ,[ASSET]      ,isnull([NOTETEXT],'') [NOTETEXT],[SCHEDULE]     ,[DATECREATE]      ,[STS]        ,[PC]      ,[USERID]  FROM [AFASYS].[dbo].[AFA_H] a  left join [dbo].[AFA_HAK_AKSES] b on b.AFA_NO=a.AFA_NO and b.NIK='" & nike & "' and a.AFA_NO='" & afano & "'")
        If tblEmployee.Rows.Count > 0 Then
            TxtBudgetYear.Text = tblEmployee.Rows(0).Item("BUDGET_YEAR").ToString
            TxtRev.Text = tblEmployee.Rows(0).Item("BUDGET_REV").ToString
            TxtDept.Text = tblEmployee.Rows(0).Item("COST_CENTER").ToString
            TxtSite.Text = tblEmployee.Rows(0).Item("CONTRACT").ToString
            TXtState.Text = tblEmployee.Rows(0).Item("STS").ToString
            TXtAFAType.Text = tblEmployee.Rows(0).Item("AFA_TYPE").ToString
            TXtafaDate.Text = tblEmployee.Rows(0).Item("AFA_DATE").ToString
            TxtFinDate.Text = tblEmployee.Rows(0).Item("FINANCE_DATE").ToString
            TxtAfanoApp.Text = tblEmployee.Rows(0).Item("AFA_NO_APPROVAL").ToString
            TxtAFAAPPDate.Text = tblEmployee.Rows(0).Item("AFA_APPROVAL_DATE").ToString
            TxtAFAPerFrom.Text = tblEmployee.Rows(0).Item("AFA_PER_FROM").ToString
            TxtAFAPerTo.Text = tblEmployee.Rows(0).Item("AFA_PER_TO").ToString
            TxtTotAmt.Text = tblEmployee.Rows(0).Item("AMT").ToString
            TxtSchedule.Text = tblEmployee.Rows(0).Item("SCHEDULE").ToString
        Else
            ' MsgBox("No Data Found !!")
        End If

    End Sub

    Sub bersih()
        TxtBudgetYear.Text = ""
        TxtRev.Text = ""
        TxtDept.Text = ""
        TxtSite.Text = ""
        TXtState.Text = ""
        TXtAFAType.Text = ""
        TXtafaDate.Text = ""
        TxtFinDate.Text = ""
        TxtAfanoApp.Text = ""


        TxtAFAAPPDate.Text = ""
        TxtAFAPerFrom.Text = ""
        TxtAFAPerTo.Text = ""
        TxtTotAmt.Text = ""
        TxtSchedule.Text = ""
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick

        gridtotext()
    End Sub

    Private Sub TxtAfa_TextChanged(sender As Object, e As EventArgs) Handles TxtAfa.TextChanged

    End Sub

    Sub exportexcel()
        Dim shostname As String
        shostname = System.Net.Dns.GetHostName
        Dim loc = Application.StartupPath & "\Rpt\RptUser_" & shostname & ".xls"
        Dim path As String = loc
        GridControl1.ExportToXlsx(path)
        ' Open the created XLSX file with the default application.
        Process.Start(path)
    End Sub





    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Dispose()

    End Sub

    Sub exportpdf()
        Dim shostname As String
        shostname = System.Net.Dns.GetHostName
        Dim loc = Application.StartupPath & "\Rpt\RptUser_" & shostname & ".csv"
        Dim path As String = loc
        GridControl1.ExportToCsv(path)

        Process.Start(path)
    End Sub

    Private Sub TxtAfa_LostFocus(sender As Object, e As EventArgs) Handles TxtAfa.LostFocus
        isitxt()
        cekstatusapp()
    End Sub
End Class