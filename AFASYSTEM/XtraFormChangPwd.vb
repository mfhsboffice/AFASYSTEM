Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Public Class XtraFormChangPwd
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblLoginUser As DataTable
    Dim tblLogin As DataTable
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
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



    Private Sub TxtCurrpwd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCurrpwd.KeyPress
        If e.KeyChar = Chr(13) Then SendKeys.Send("{tab}")
    End Sub



    Private Sub TxtNewpwd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNewpwd.KeyPress
        If e.KeyChar = Chr(13) Then SendKeys.Send("{tab}")
    End Sub


    Private Sub TxtConfirpwd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtConfirpwd.KeyPress
        If e.KeyChar = Chr(13) Then SendKeys.Send("{tab}")
    End Sub
    Sub changed()
        If TxtCurrpwd.Text = "" Then TxtCurrpwd.Focus() : Exit Sub
        If TxtNewpwd.Text = "" Then TxtNewpwd.Focus() : Exit Sub
        If TxtConfirpwd.Text = "" Then TxtConfirpwd.Focus() : Exit Sub
        If Trim(TxtNewpwd.Text) <> Trim(TxtConfirpwd.Text) Then MsgBox("The new password you entered is not the same") : Exit Sub


        tblLogin = Proses.ExecuteQuery("SELECT  [UserID]      ,[Name]      ,[Type]      ,[Pwd]      ,[Aktif]      ,[DeptApp]      ,[Budget]  FROM [dbo].[User_H] where userid='" & Trim(FormFluMenu.btnuserid.Caption) & "' and Pwd='" & Encrypt(Trim(TxtCurrpwd.Text)) & "' ")

        If tblLogin.Rows.Count = 0 Then
            MessageBox.Show("Wrong Old Password !!", "Password Change Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else

            SQL = "Update [dbo].[User_H] Set Pwd='" & Encrypt(Trim(TxtNewpwd.Text)) & "' where [UserID]='" & Trim(FormFluMenu.btnuserid.Caption) & "' and Pwd='" & Encrypt(Trim(TxtCurrpwd.Text)) & "'  "
            Proses.ExecuteNonQuery(SQL)
            MessageBox.Show("Password Change Success !!", "Password Change Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub
    Private Sub Btnproses_Click(sender As Object, e As EventArgs) Handles Btnproses.Click
        changed()
    End Sub


End Class