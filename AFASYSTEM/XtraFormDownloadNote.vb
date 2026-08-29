Public Class XtraFormDownloadNote
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2 As DataTable
    Dim tblEmployee As DataTable

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        AFA_Download()
    End Sub

    Dim tblLog As DataTable
    Dim CM As CurrencyManager
    Sub AFA_Download()
        If Trim(TxtAFA.Text) = "" Then MsgBox("Isi AFA dulu !!") : Exit Sub

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

        Commandku.CommandText = "AFA_UPDATE_NOTE_AFA_Proc"
        Dim userid = FormFluMenu.btnuserid.Caption
        Dim afano = Trim(TxtAFA.Text)


        Commandku.Parameters.AddWithValue("@AFA", afano)



        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output



        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If outParam.Value = "OK" Then
            Cursor.Current = Cursors.Default


            MessageBox.Show("Download AFA NOTE Success", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

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