Public Class XtraFormEmailConfigure
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2 As DataTable
    Dim tblEmployee As DataTable
    Dim tblLog As DataTable

    Private Sub XtraFormEmailConfigure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isi()
    End Sub

    Dim CM As CurrencyManager

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        callemail()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Public Overridable Property VisibleIndex As Integer
    Sub isi()
        Dim userid = FormFluMenu.btnuserid.Caption
        tblDept = Proses.ExecuteQuery("SELECT  [NIK]    ,[Email]  ,[StsEmail]  FROM [AFASYS].[dbo].[User_Email] where nik='" & Trim(userid) & "'")
        If tblDept.Rows.Count > 0 Then
            Dim stsemail = Trim(tblDept.Rows(0).Item("StsEmail").ToString)
            If stsemail = "Y" Then
                RManual.Checked = False
                RAuto.Checked = True
            Else
                RManual.Checked = True
                RAuto.Checked = False
            End If
        End If

    End Sub
    Sub callemail()


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

        Commandku.CommandText = "User_Set_Email_Proc"
        Dim userid = FormFluMenu.btnuserid.Caption
        Dim setingg
        If RManual.Checked = True And RAuto.Checked = False Then
            setingg = "N"
            Commandku.Parameters.AddWithValue("@SET", setingg)
        ElseIf RManual.Checked = False And RAuto.Checked = True Then
            setingg = "Y"
            Commandku.Parameters.AddWithValue("@SET", setingg)
        End If

        Commandku.Parameters.AddWithValue("@nik", userid)
        Commandku.Parameters.AddWithValue("@tYPE", "U")


        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output

        Dim stsparam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Sts_", SqlDbType.VarChar, 60)
        stsparam.Direction = ParameterDirection.Output


        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If outParam.Value = "OK" Then
            Cursor.Current = Cursors.Default
            isi()
            MessageBox.Show("" & stsparam.Value.ToString & "", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf outParam.Value = "NOTOK" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()




    End Sub

End Class