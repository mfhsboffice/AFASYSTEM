Imports System.Data.SqlClient
Imports System.Reflection

Imports System.IO
Imports System.Security.Cryptography
Imports System
Imports System.Text
Public Class XtraFormLogin
    Dim Dbase As String
    Dim UserId As String
    Dim Pass As String
    Dim IPi As String
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        FormFluMenu.menustart()
        Me.Close()
    End Sub
    Private Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
             &H65, &H64, &H76, &H65, &H64, &H65,
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

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
    Sub LOGINNEW()


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

        Commandku.CommandText = "MIS_LOGIN_New_Proc"


        Dim versi = Trim(Label5.Text)

        Commandku.Parameters.AddWithValue("@Versi", Trim(versi))
        Commandku.Parameters.AddWithValue("@NIK", Trim(Txtuserid.Text))
        Commandku.Parameters.AddWithValue("@pWD", Encrypt(Trim(Txtpwd.Text)))


        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output

        Dim outParamSts As SqlClient.SqlParameter =
      Commandku.Parameters.Add("@Sts_", SqlDbType.VarChar, 100)
        outParamSts.Direction = ParameterDirection.Output


        Dim outParamlvl As SqlClient.SqlParameter =
     Commandku.Parameters.Add("@Lvl_", SqlDbType.VarChar, 100)
        outParamlvl.Direction = ParameterDirection.Output



        Dim outname As SqlClient.SqlParameter =
     Commandku.Parameters.Add("@Name", SqlDbType.VarChar, 100)
        outname.Direction = ParameterDirection.Output
        ' ----- Menjalankan stored procedure.


        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If outParam.Value = "OK" Then
            If Trim(outParamSts.Value) = "OK" Then
                Cursor.Current = Cursors.Default

                FormFluMenu.btnuserid.Caption = Txtuserid.Text
                FormFluMenu.btnlvl.Caption = Trim(outParamlvl.Value.ToString)
                FormFluMenu.BtnName.Caption = Trim(outname.Value.ToString)
                FormFluMenu.menuaktif()
                Me.Dispose()
            Else
                Cursor.Current = Cursors.Default
                If Trim(outParamSts.Value) = "Password anda salah !!" Then
                    MessageBox.Show("" & Trim(outParamSts.Value) & "", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Txtpwd.Focus()
                Else
                    MessageBox.Show("" & Trim(outParamSts.Value) & "", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If


        ElseIf outParam.Value = "NOTOK" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()




    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Txtuserid.Text.Length < 5 Then Me.ErrorProvider1.SetError(Me.Txtuserid, "Enter your UserId") : Txtuserid.Select() Else Me.ErrorProvider1.SetError(Me.Txtuserid, "")

        If CkHelp.Checked Then
            XtraFormSendPwd.lblnik.Text = Trim(Txtuserid.Text)
            XtraFormSendPwd.isi()
            XtraFormSendPwd.ShowDialog()

        Else
            If Trim(Txtuserid.Text) = "" Then Txtuserid.Focus() : Exit Sub
            If Trim(Txtpwd.Text) = "" Then Txtpwd.Focus() : Exit Sub
            LOGINNEW()
        End If
    End Sub

    Private Sub XtraFormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnOK.Enabled = False
        Txtuserid.TabIndex = 0
        Txtpwd.TabIndex = 1
        btnOK.TabIndex = 2
        btnCancel.TabIndex = 3


    End Sub
    Sub cekbtnok()
        If Trim(Txtuserid.Text) <> "" And Trim(Txtpwd.Text) <> "" Then

            btnOK.Enabled = True
        ElseIf Trim(Txtuserid.Text) <> "" Then
            If CkHelp.Checked = True Then
                btnOK.Enabled = True
            Else
                btnOK.Enabled = False
            End If
        Else
            btnOK.Enabled = False
        End If
    End Sub

    Private Sub Txtuserid_TextChanged(sender As Object, e As EventArgs) Handles Txtuserid.TextChanged
        cekbtnok()
    End Sub

    Private Sub Txtpwd_TextChanged(sender As Object, e As EventArgs) Handles Txtpwd.TextChanged
        cekbtnok()
    End Sub

    Private Sub Txtuserid_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtuserid.KeyPress
        If e.KeyChar = Chr(13) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub Txtpwd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtpwd.KeyPress
        If e.KeyChar = Chr(13) Then SendKeys.Send("{tab}")
    End Sub

    Private Sub CkHelp_CheckedChanged(sender As Object, e As EventArgs) Handles CkHelp.CheckedChanged
        If CkHelp.Checked = True Then
            btnOK.Enabled = True
        Else
            btnOK.Enabled = False
        End If
    End Sub
End Class