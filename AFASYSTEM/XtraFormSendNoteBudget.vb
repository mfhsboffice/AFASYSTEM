Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Public Class XtraFormSendNoteBudget
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2, tblgrid As DataTable
    Dim typee
    Private Sub XtraFormSendNoteBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SplitContainer1.SplitterDistance = 470
            cmboreason()
            btnupdate.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Dim tblEmployee As DataTable
    Dim tblLog As DataTable
    Sub cmboreason()
        tblSect = Proses.ExecuteQuery("SELECT [ReasonBudget]  FROM [AFASYS].[dbo].[AFA_ReasonFromBudget] order by ReasonBudget asc")

        If tblSect.Rows.Count = 0 Then
        Else
            cmbreason.Items.Clear()
            With tblSect.Columns(0)
                For a = 0 To tblSect.Rows.Count - 1
                    cmbreason.Items.Add(.Table.Rows(a).Item(0))
                Next a
            End With
        End If
    End Sub
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Dispose()
    End Sub
    Sub sape()

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

        Commandku.CommandText = "AFA_NOTE_BUDGET_Proc"



        Dim afa = Trim(TxtAfa.Text)
        Dim REASON = Trim(cmbreason.Text)
        Dim IDENTRY = Val(lblid.Text)
        Dim NOTE = Trim(txtnotebudget.Text)

        Dim id = Val(lblid.Text)

        Commandku.Parameters.AddWithValue("@Note", Trim(NOTE))
        Commandku.Parameters.AddWithValue("@AFA", Trim(afa))
        Commandku.Parameters.AddWithValue("@IDENTRY", id)
        Commandku.Parameters.AddWithValue("@Reason", Trim(REASON))
        Commandku.Parameters.AddWithValue("@PC", Trim(shostname))
        Commandku.Parameters.AddWithValue("@tYPE", Trim(typee))


        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output

        Dim outParamSts As SqlClient.SqlParameter =
      Commandku.Parameters.Add("@Sts_", SqlDbType.VarChar, 100)
        outParamSts.Direction = ParameterDirection.Output

        Dim idpesan As SqlClient.SqlParameter =
      Commandku.Parameters.Add("@idpesan", SqlDbType.VarChar, 100)
        idpesan.Direction = ParameterDirection.Output


        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If outParam.Value = "OK" Then
            showdata()
            MsgBox(outParamSts.Value.ToString)
            lblid.Text = Trim(idpesan.Value.ToString)
        ElseIf outParam.Value = "NOTOK" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        typee = "I"
        sape()
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        sendemail()
    End Sub
    Sub sendemail()
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

        Dim Commandku As New SqlClient.SqlCommand()
        Commandku.CommandType = CommandType.StoredProcedure
        Commandku.Connection = Database

        Commandku.CommandText = "MIS_SendEmail_FromBudget_Revisi_AFA"

        Dim afa = Trim(TxtAfa.Text)
        Dim id = Trim(lblid.Text)
        Commandku.Parameters.AddWithValue("@AFA", Trim(afa))
        Commandku.Parameters.AddWithValue("@id", Trim(id))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@STS", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output

        Dim outParamSts As SqlClient.SqlParameter =
      Commandku.Parameters.Add("@Pesan", SqlDbType.VarChar, 100)
        outParamSts.Direction = ParameterDirection.Output


        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()

        If outParam.Value = "OK" Then
            MsgBox(outParamSts.Value.ToString)

        ElseIf outParam.Value = "NOTOK" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()


    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Dim CM As CurrencyManager

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        typee = "U"
        sape()
    End Sub

    Sub isitxt()
        lblid.Text = ""
        Dim afa = Trim(TxtAfa.Text)
        tblEmployee = Proses.ExecuteQuery("SELECT  a.[AFA_NO] ,isnull(a.atth,'') Atth     ,isnull([NOTETEXT],'') [NOTETEXT],[SCHEDULE],[STS]   ,AMT  FROM [AFASYS].[dbo].[AFA_H] a  where  a.AFA_NO='" & afa & "'")
        If tblEmployee.Rows.Count = 0 Then

        Else

            TxtSubject.Text = tblEmployee.Rows(0).Item("NOTETEXT").ToString
            TxtSchedule.Text = tblEmployee.Rows(0).Item("SCHEDULE").ToString
            TxtEst_Cost.Text = tblEmployee.Rows(0).Item("AMT").ToString



        End If

    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        lblid.Text = GridView1.Columns.View.GetFocusedRowCellValue("ID").ToString
        cmbreason.Text = GridView1.Columns.View.GetFocusedRowCellValue("Reason").ToString
        txtnotebudget.Text = GridView1.Columns.View.GetFocusedRowCellValue("Note").ToString

        btnupdate.Enabled = True
        BtnSave.Enabled = False
    End Sub
    Sub showdata()
        Dim afa = Trim(TxtAfa.Text)
        tblDept = Proses.ExecuteQuery("SELECT [AFA_NO],[ID],[Reason],[Note],[PC]  ,convert(varchar(12),[DateCreate],113) DateCreate  FROM [AFASYS].[dbo].[AFA_NOTE_FROM_BUDGET] where afa_no='" & afa & "' order by AFA_NO,id desc")



        If tblDept.Rows.Count = 0 Then
            GridControl1.DataSource = Nothing

        Else

            GridControl1.DataSource = tblDept

            Dim gridView1 As GridView = TryCast(GridControl1.MainView, GridView)

            ' Obtain created columns.
            Dim colafa As GridColumn = gridView1.Columns("AFA_NO")
            Dim coldid As GridColumn = gridView1.Columns("ID")
            Dim colreason As GridColumn = gridView1.Columns("Reason")
            Dim colNote As GridColumn = gridView1.Columns("Note")
            Dim colPC As GridColumn = gridView1.Columns("PC")
            Dim colDateCreate As GridColumn = gridView1.Columns("DateCreate")





        End If
    End Sub
    Private Sub XtraFormSendNoteBudget_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            SplitContainer1.SplitterDistance = 470
        Catch ex As Exception

        End Try
    End Sub

End Class