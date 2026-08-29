Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports System.Globalization


Imports System.IO
Imports System.Security.Cryptography
Imports System
Imports System.Text
Public Class XtraFromUser
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

    Public Overridable Property VisibleIndex As Integer

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        typee = "I"
        PROSESPROC()
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Dim ciUSA As CultureInfo = New CultureInfo("en-US")

    Private Sub XtraFromUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SplitContainer1.SplitterDistance = 244
        Catch ex As Exception

        End Try
        data()
    End Sub

    Dim ciEUR As CultureInfo = New CultureInfo("fr-FR", False)



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

        Commandku.CommandText = "User_H_Proc"
        Dim nik = Trim(TxtUserid.Text)
        Dim nama = Trim(TxtNama.Text)
        Dim lvl = Trim(CmbType.Text)
        Dim pwd = Encrypt(Txtpwd.Text)
        Dim activ = Trim(CmbActive.Text)
        Dim budget = Trim(cmbbudget.Text)
        Dim email = Trim(TxtEmail.Text)
        Dim jab = Trim(TxtJab.Text)
        Dim unapp = Trim(cmbUnApp.Text)
        Dim UserIfs = Trim(txtuserifs.Text)
        Dim DateFinance = Trim(CMbDirFinance.Text)
        Commandku.Parameters.AddWithValue("@nik", nik)
        Commandku.Parameters.AddWithValue("@nama", nama)
        Commandku.Parameters.AddWithValue("@lvl", lvl)
        Commandku.Parameters.AddWithValue("@pwd", pwd)
        Commandku.Parameters.AddWithValue("@aktif", activ)
        Commandku.Parameters.AddWithValue("@budget", budget)
        Commandku.Parameters.AddWithValue("@Email", email)
        Commandku.Parameters.AddWithValue("@Jab", jab)
        Commandku.Parameters.AddWithValue("@UnApp", unapp)
        Commandku.Parameters.AddWithValue("@UserIfs", UserIfs)
        Commandku.Parameters.AddWithValue("@DateFinance", DateFinance)
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

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        typee = "U"
        PROSESPROC()
    End Sub
    Sub clean()
        TxtUserid.Text = ""
        TxtNama.Text = ""
        Txtpwd.Text = ""
        CmbType.Text = ""
        CmbActive.Text = ""
        cmbbudget.Text = ""
        TxtEmail.Text = ""
        TxtJab.Text = ""
        CMbDirFinance.Text = ""
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If BtnDelete.Enabled = True Then
            Try
                Dim Keluar As Int16
                Keluar = MsgBox("Are you sure you want to delete this data?", MsgBoxStyle.OkCancel, "Proccess")
                Select Case Keluar
                    Case vbOK
                        typee = "D"
                        PROSESPROC()

                    Case vbCancel
                        Exit Sub
                End Select
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If


    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        clean()
    End Sub



    Private Sub TxtUserid_EditValueChanged(sender As Object, e As EventArgs) Handles TxtUserid.EditValueChanged
        CEKUSERIFS()
    End Sub

    Sub CEKUSERIFS()

        Dim NIK = Trim(TxtUserid.Text)
        tblEmployee = Proses.ExecuteQuery("select a.userid,a.Name,isnull(a.UserIfs ,'')  UserIfs from [dbo].[User_H]  a left join [Ser171_7].[MISTOOLS].[dbo].[MIS_IFS_VS_GTAS_EMPLOYEE] b on b.[IDENTITY]=a.UserID and b.active='TRUE' where a.userid='" & NIK & "' ")
        If tblEmployee.Rows.Count = 0 Then
            lbluserifs.Text = ""
            txtuserifs.Text = ""
        Else

            lbluserifs.Text = Trim(tblEmployee.Rows(0).Item("UserIfs"))
            txtuserifs.Text = Trim(tblEmployee.Rows(0).Item("UserIfs"))
        End If

    End Sub
    Sub data()
        Dim shostname As String
        shostname = System.Net.Dns.GetHostName
        Dim user = Trim(FormFluMenu.btnuserid.Caption)
        tblDept = Proses.ExecuteQuery("SELECT [UserID] ,[Name] ,[Type]   ,[Pwd]   ,[Aktif]     ,[Budget],isnull(b.Email,'') Email,Jab,UnApp,isnull(UserIfs,'') UserIfs,b.StsEmail Config,DateFinance  FROM [AFASYS].[dbo].[User_H] a  left join [AFASYS].[dbo].[User_Email] b on b.nik=a.UserID")



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
            Dim ColUnapp As GridColumn = gridView1.Columns("UnApp")
            Dim ColUserifs As GridColumn = gridView1.Columns("UserIfs")
            Dim ColConfig As GridColumn = gridView1.Columns("Config")


            coluserid.Width = 70
            colnama.Width = 100
            colpwd.Width = 100

            'colpwd.Visible = False



        End If

    End Sub

    Sub gridtotext()
        TxtUserid.Text = GridView1.Columns.View.GetFocusedRowCellValue("UserID").ToString
        TxtNama.Text = GridView1.Columns.View.GetFocusedRowCellValue("Name").ToString
        CmbType.Text = GridView1.Columns.View.GetFocusedRowCellValue("Type").ToString
        Txtpwd.Text = Decrypt(GridView1.Columns.View.GetFocusedRowCellValue("Pwd")).ToString
        CmbActive.Text = GridView1.Columns.View.GetFocusedRowCellValue("Aktif").ToString
        cmbbudget.Text = GridView1.Columns.View.GetFocusedRowCellValue("Budget").ToString
        TxtEmail.Text = GridView1.Columns.View.GetFocusedRowCellValue("Email").ToString
        TxtJab.Text = GridView1.Columns.View.GetFocusedRowCellValue("Jab").ToString
        cmbUnApp.Text = GridView1.Columns.View.GetFocusedRowCellValue("UnApp").ToString
        txtuserifs.Text = GridView1.Columns.View.GetFocusedRowCellValue("UserIfs").ToString
        CMbDirFinance.Text = GridView1.Columns.View.GetFocusedRowCellValue("DateFinance").ToString

    End Sub

    Private Sub btnexport_Click(sender As Object, e As EventArgs) Handles btnexport.Click
        Dim Y = Application.StartupPath & "\Temp\ListUser.xls"

        GridControl1.ExportToXlsx(Y)
        ' Open the created XLSX file with the default application.
        Process.Start(Y)
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        gridtotext()
    End Sub

    Private Sub XtraFromUser_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            SplitContainer1.SplitterDistance = 244
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtpwd_DoubleClick(sender As Object, e As EventArgs) Handles Txtpwd.DoubleClick
        MsgBox(Txtpwd.Text)
    End Sub
End Class