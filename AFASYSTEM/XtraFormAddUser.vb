Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports System.Globalization


Imports System.IO
Imports System.Security.Cryptography
Imports System
Imports System.Text
Public Class XtraFormAddUser
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2 As DataTable
    Dim tblEmployee As DataTable
    Dim tblLog As DataTable
    Dim CM As CurrencyManager
    Dim typee As String
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

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        typee = "I"
        PROSESPROC()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        typee = "D"
        PROSESPROC()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub TxtUserid_EditValueChanged(sender As Object, e As EventArgs) Handles TxtUserid.EditValueChanged
        Txtpwd.Text = Trim(TxtUserid.Text)
    End Sub

    Private Sub XtraFormAddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        data()

    End Sub

    Public Overridable Property VisibleIndex As Integer

    Sub PROSESPROC()
        If Len(TxtUserid.Text) < 5 Then MsgBox("Userid >= 5 Digit") : Exit Sub


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

        Commandku.CommandText = "User_H_User_Proc"
        Dim nik = Trim(TxtUserid.Text)
        Dim nama = Trim(TxtNama.Text)
        Dim lvl = Trim(CmbType.Text)
        Dim pwd = Encrypt(Txtpwd.Text)
        Dim activ = "T"
        Dim budget = "T"
        Dim email = Trim(TxtEmail.Text)
        Dim jab = ""
        Dim unapp = "T"
        Dim userid = Trim(FormFluMenu.btnuserid.Caption)

        Commandku.Parameters.AddWithValue("@nik", nik)
        Commandku.Parameters.AddWithValue("@nama", nama)
        Commandku.Parameters.AddWithValue("@lvl", lvl)
        Commandku.Parameters.AddWithValue("@pwd", pwd)
        Commandku.Parameters.AddWithValue("@aktif", activ)
        Commandku.Parameters.AddWithValue("@budget", budget)
        Commandku.Parameters.AddWithValue("@Email", email)
        Commandku.Parameters.AddWithValue("@Jab", jab)
        Commandku.Parameters.AddWithValue("@UnApp", jab)
        Commandku.Parameters.AddWithValue("@Userid", userid)
        Commandku.Parameters.AddWithValue("@pc", shostname)
        Commandku.Parameters.AddWithValue("@tYPE", typee)



        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output

        Dim OutSTS As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Sts_", SqlDbType.VarChar, 60)
        OutSTS.Direction = ParameterDirection.Output


        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If outParam.Value = "OK" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("" & OutSTS.Value & "", "Process Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


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



    Sub isinama()
        Dim nik = Trim(TxtUserid.Text)
        tblDept = Proses.ExecuteQuery("SELECT a.[NIK],a.[Nama] ,a.[SectCd],a.[Jab]  FROM [AFASYS].[dbo].[AFA_Employee_GTAS] a where a.nik='" & nik & "'")

        If tblDept.Rows.Count = 0 Then
            TxtNama.Text = ""
        Else

            TxtNama.Text = Trim(tblDept.Rows(0).Item("Nama").ToString)
        End If
    End Sub
    Sub data()
        Dim shostname As String
        shostname = System.Net.Dns.GetHostName
        Dim user = Trim(FormFluMenu.btnuserid.Caption)
        tblDept = Proses.ExecuteQuery("SELECT [UserID] ,[Name] ,[Type]   ,[Pwd]   ,[Aktif]     ,[Budget],isnull(b.Email,'') Email,Jab,UnApp  FROM [AFASYS].[dbo].[User_H] a  left join [AFASYS].[dbo].[User_Email] b on b.nik=a.UserID where  [UserEntry]='" & user & "' and Aktif='N'")



        If tblDept.Rows.Count = 0 Then
            GridControl1.DataSource = Nothing

        Else

            GridControl1.DataSource = tblDept

            Dim gridView1 As GridView = TryCast(GridControl1.MainView, GridView)

            ' Obtain created columns.
            Dim coluserid As GridColumn = gridView1.Columns("UserID")
            Dim colnama As GridColumn = gridView1.Columns("Name")
            Dim coltype As GridColumn = gridView1.Columns("Type")
            Dim colpwd As GridColumn = gridView1.Columns("Pwd")
            Dim colaktiv As GridColumn = gridView1.Columns("Aktif")
            Dim colbudget As GridColumn = gridView1.Columns("Budget")
            Dim colemail As GridColumn = gridView1.Columns("Email")
            Dim ColJab As GridColumn = gridView1.Columns("Jab")


            coluserid.Width = 70
            colnama.Width = 100
            colpwd.Width = 100

            'colpwd.Visible = False



        End If

    End Sub


    Private Sub TxtUserid_LostFocus(sender As Object, e As EventArgs) Handles TxtUserid.LostFocus
        isinama()
    End Sub
End Class