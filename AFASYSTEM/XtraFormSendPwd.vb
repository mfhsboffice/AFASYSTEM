Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Public Class XtraFormSendPwd
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblLoginUser As DataTable
    Dim tblLogin As DataTable
    Dim pwd As String
    Private Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function

    Sub isi()
        Try
            tblLogin = Proses.ExecuteQuery("SELECT  a.[NIK]  ,a.[Email],b.Name,b.Pwd  FROM [AFASYS].[dbo].[User_Email] a left join [dbo].[User_H] b on b.UserID=a.nik where a.nik='" & Trim(lblnik.Text) & "' ")

            If tblLogin.Rows.Count = 0 Then
                lblname.Text = Trim(tblLogin.Rows(0).Item("Name")).ToString.ToUpper
                lblemail.Text = ""
            Else
                lblname.Text = Trim(tblLogin.Rows(0).Item("Name")).ToString.ToUpper
                lblemail.Text = Trim(tblLogin.Rows(0).Item("Email")).ToString
                pwd = Decrypt(tblLogin.Rows(0).Item("Pwd"))
            End If
        Catch ex As Exception
            lblname.Text = ""
        End Try

    End Sub
    Sub sendpwd()
        If Trim(lblemail.Text) = "" Then MsgBox("Your email is still empty, please contact the Cost & Budget Dept") : Exit Sub


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

        Commandku.CommandText = "MIS_SendEmail_Password"
        Dim userid = Trim(XtraFormLogin.Txtuserid.Text)


        Commandku.Parameters.AddWithValue("@PC_", Trim(shostname))
        Commandku.Parameters.AddWithValue("@Userid_", Trim(userid))
        Commandku.Parameters.AddWithValue("@pWD_", (Trim(pwd)))



        Dim outParamSts As SqlClient.SqlParameter =
      Commandku.Parameters.Add("@Sts", SqlDbType.VarChar, 100)
        outParamSts.Direction = ParameterDirection.Output



        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If outParamSts.Value = "OK" Then
            MessageBox.Show("Please check your email inbox, keep your password secret!", "Send Email Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            XtraFormLogin.CkHelp.Checked = False
            XtraFormLogin.btnOK.Enabled = True
            Me.Close()

        ElseIf outParamSts.Value = "NOTOK" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()

    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        sendpwd()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class