Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports System.Globalization
Imports System.IO
Public Class XtraFormSignature
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2, tblgrid As DataTable
    Dim tblEmployee As DataTable
    Dim tblLog As DataTable
    Dim CM As CurrencyManager

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Dispose()
    End Sub

    Public Overridable Property VisibleIndex As Integer

    Private Sub XtraFormSignature_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SplitContainer1.SplitterDistance = 237
            kodenikk()
            BtnSend.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Sub kodenikk()
        Dim USERID = Trim(FormFluMenu.btnuserid.Caption)
        tblLog = Proses.ExecuteQuery("SELECT distinct  a.[AFA_NO]     FROM [AFASYS].[dbo].[AFA_H] a   left join [dbo].[AFA_HAK_AKSES] b on b.AFA_NO=a.AFA_NO  LEFT JOIN [AFASYS].[dbo].[User_H] D ON D.UserIfs=B.NIK where A.STS='Planned' AND D.UserID='" & USERID & "'")

        If tblLog.Rows.Count = 0 Then
            ' cmbcode.Text = ""
        Else



            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To tblLog.Rows.Count - 1
                col.Add(tblLog.Rows(i).Item(0).ToString())
            Next
            TxtAfa.AutoCompleteSource = AutoCompleteSource.CustomSource
            TxtAfa.AutoCompleteCustomSource = col
            TxtAfa.AutoCompleteMode = AutoCompleteMode.Suggest

        End If
    End Sub


    Dim ciUSA As CultureInfo = New CultureInfo("en-US")



    Dim ciEUR As CultureInfo = New CultureInfo("fr-FR", False)

    Sub isitxt()
        Dim afa = Trim(TxtAfa.Text)
        Dim nikuser = Trim(FormFluMenu.btnuserid.Caption)
        tblEmployee = Proses.ExecuteQuery("SELECT  a.[AFA_NO] ,isnull(a.atth,'') Atth,isnull(a.atth2,'') Atth2     ,isnull([NOTETEXT],'') [NOTETEXT],isnull([SCHEDULE],'') [SCHEDULE],[STS]   ,AMT  FROM [AFASYS].[dbo].[AFA_H] a  left join [dbo].[AFA_HAK_AKSES] b on b.AFA_NO=a.AFA_NO LEFT JOIN [AFASYS].[dbo].[User_H] D ON D.UserIfs=B.NIK where D.UserID='" & nikuser & "' and a.AFA_NO='" & afa & "'")
        If tblEmployee.Rows.Count > 0 Then
            TxtSubject.Text = tblEmployee.Rows(0).Item("NOTETEXT").ToString
            TxtSchedule.Text = tblEmployee.Rows(0).Item("SCHEDULE").ToString
            TxtEst_Cost.Text = tblEmployee.Rows(0).Item("AMT").ToString
            lblatth.Text = tblEmployee.Rows(0).Item("Atth").ToString
            lblatth2.Text = tblEmployee.Rows(0).Item("Atth2").ToString
        Else
            ' MsgBox("No Data Found !!")
        End If

    End Sub

    Private Sub TxtAfa_LostFocus(sender As Object, e As EventArgs) Handles TxtAfa.LostFocus
        If Len(TxtAfa.Text) > 0 Then
            isitxt()
            GridAuth()
            TxtAtt1.Text = ""
            TxtAtt2.Text = ""
        End If
    End Sub


    Sub AuthNIK()
        tblSect = Proses.ExecuteQuery("select * from (SELECT  [UserID] ,[Name] ,[Jab]  FROM [AFASYS].[dbo].[User_H] a left join [dbo].[User_Email] b on b.NIK=a.UserID where b.Email is not null and a.Aktif='Y' AND A.[TYPE]<>'ENTRY' union all select '' Userid,'' name,'' Jab) as a where a.UserID<>'11111' order by a.NAME asc")

        Dim comboBoxColumn As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        Dim comboBoxColumnvalue As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        comboBoxColumn.HeaderText = "Authorized"
        comboBoxColumn.DataPropertyName = "Auth_NIK"
        comboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        comboBoxColumn.FlatStyle = FlatStyle.Flat
        comboBoxColumn.DataSource = tblSect
        comboBoxColumn.ValueMember = tblSect.Columns(0).ColumnName.ToString
        comboBoxColumn.DisplayMember = tblSect.Columns(1).ColumnName.ToString
        comboBoxColumn.Width = 250


        DgAuth.Columns.RemoveAt(2)
        DgAuth.Columns.Insert(2, comboBoxColumn)

    End Sub

    Sub SuppNIK()
        tblSect = Proses.ExecuteQuery("select * from (SELECT  [UserID] ,[Name] ,[Jab]  FROM [AFASYS].[dbo].[User_H] a left join [dbo].[User_Email] b on b.NIK=a.UserID where b.Email is not null and a.Aktif='Y' AND A.[TYPE]<>'ENTRY' union all select '' Userid,'' name,'' Jab) as a where a.UserID<>'11111' order by a.NAME asc")

        Dim comboBoxColumn As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        Dim comboBoxColumnvalue As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        comboBoxColumn.HeaderText = "Supporting"
        comboBoxColumn.DataPropertyName = "Supp_NIK"
        comboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        comboBoxColumn.FlatStyle = FlatStyle.Flat
        comboBoxColumn.DataSource = tblSect
        comboBoxColumn.ValueMember = tblSect.Columns(0).ColumnName.ToString
        comboBoxColumn.DisplayMember = tblSect.Columns(1).ColumnName.ToString
        comboBoxColumn.Width = 250


        DgAuth.Columns.RemoveAt(5)
        DgAuth.Columns.Insert(5, comboBoxColumn)

    End Sub
    Sub DirNIK()
        tblSect = Proses.ExecuteQuery("select * from (SELECT  [UserID] ,[Name] ,[Jab]  FROM [AFASYS].[dbo].[User_H] a left join [dbo].[User_Email] b on b.NIK=a.UserID where b.Email is not null and a.Aktif='Y' union all select '' Userid,'' name,'' Jab) as a where a.UserID<>'11111' order by a.NAME asc")


        Dim comboBoxColumn As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        Dim comboBoxColumnvalue As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        comboBoxColumn.HeaderText = "Direct"
        comboBoxColumn.DataPropertyName = "Dir_NIK"
        comboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        comboBoxColumn.FlatStyle = FlatStyle.Flat
        comboBoxColumn.DataSource = tblSect
        comboBoxColumn.ValueMember = tblSect.Columns(0).ColumnName.ToString
        comboBoxColumn.DisplayMember = tblSect.Columns(1).ColumnName.ToString
        comboBoxColumn.Width = 250

        DgAuth.Columns.RemoveAt(8)
        DgAuth.Columns.Insert(8, comboBoxColumn)

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'For y As Integer = 0 To DgAuth.Rows.Count - 1
        '    If Trim(Me.DgAuth.Item(9, y).Value.ToString) <> "Drafter" Then MsgBox("Save Gagal Drafter tidak ada") : Exit Sub
        'Next
        saveproc()
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
        ' ----- Membuat command dasar
        Dim Commandku As New SqlClient.SqlCommand()
        Commandku.CommandType = CommandType.StoredProcedure
        Commandku.Connection = Database

        Commandku.CommandText = "MIS_SendEmail_APP_AFA"

        Dim afa = Trim(TxtAfa.Text)

        Commandku.Parameters.AddWithValue("@AFA", Trim(afa))



        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@STS", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output

        Dim outParamSts As SqlClient.SqlParameter =
      Commandku.Parameters.Add("@Pesan", SqlDbType.VarChar, 100)
        outParamSts.Direction = ParameterDirection.Output




        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If outParam.Value = "OK" Then
            lblPesan.Text = Trim(outParamSts.Value.ToString)

        ElseIf outParam.Value = "NOTOK" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()


    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If Trim(TxtAfa.Text) = "" Then MsgBox("Please Double Click Afa first") : Exit Sub

        XtraFormViewAfa.TxtAfa.Text = Trim(TxtAfa.Text)
        ''XtraFormViewAFA.lblatth.Text = Trim(lbllink.Text)
        XtraFormViewAfa.AFAPdf()
        XtraFormViewAfa.openfile()



        XtraFormViewAfa.TopLevel = False
        XtraFormViewAfa.Parent = FormFluMenu.PanelControl1
        XtraFormViewAfa.Dock = DockStyle.Fill
        XtraFormViewAfa.Show()
        XtraFormViewAfa.BringToFront()

        'If Trim(lblatth.Text) <> "" Then

        '    Dim Y = Trim(FormFluMenu.btnlink.Caption) + "\"

        '    '   Dim curFile As String = "" & Y & "" & Trim(lblatth.Text) & ""
        '    ' If File.Exists(curFile) Then

        '    XtraFormViewPDF.TxtAfa.Text = Trim(TxtAfa.Text)
        '        XtraFormViewPDF.isiattch()


        '        XtraFormViewPDF.TopLevel = False
        '        XtraFormViewPDF.Parent = FormFluMenu.PanelControl1
        '        XtraFormViewPDF.Dock = DockStyle.Fill
        '        XtraFormViewPDF.Show()
        '        XtraFormViewPDF.BringToFront()


        '    ' Else
        '    'MsgBox("Document not found in Server")

        '    'End If

        'End If


    End Sub

    Private Sub BtnAtt1_Click(sender As Object, e As EventArgs) Handles BtnAtt1.Click
        TxtAtt1.Text = ""

        Dim opendialog As New OpenFileDialog

        '   opendialog.InitialDirectory = "C:\"
        opendialog.Title = "Open a Pdf File"
        opendialog.Filter = "Pdf Files|*.pdf"



        If opendialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtAtt1.Text = opendialog.FileName
            BtnUpp1.Enabled = True

        End If


    End Sub

    Private Sub BtnUpp1_Click(sender As Object, e As EventArgs) Handles BtnUpp1.Click
        copy1()
    End Sub
    Sub copy1()
        ' Try


        Dim filenama
            tblLog = Proses.ExecuteQuery("SELECT [AFA_NO],atth      FROM [AFASYS].[dbo].[AFA_H] where AFA_NO='" & Trim(TxtAfa.Text) & "'")

            If tblLog.Rows.Count > 0 Then
                filenama = Trim(tblLog.Rows(0).Item(1).ToString)



                Dim Y = Trim(FormFluMenu.btnlink.Caption)
                Shell("net use " & Y & " /USER:surindo\missoft M1spassword!", AppWinStyle.Hide, True, 10000)
                If Trim(TxtAtt1.Text) = "" Then
                MsgBox("FIle Attachment  masih kosong !!")
            Else

                    Dim testFile As System.IO.FileInfo
                    testFile = My.Computer.FileSystem.GetFileInfo("" & Trim(TxtAtt1.Text) & "")

                    Dim filename = testFile.Name

                Dim afa = Trim(TxtAfa.Text)

                Dim attch1nama As String = afa.Replace("/", "-") & "-1.pdf"

                Dim sSource = testFile.DirectoryName & "\" & testFile.Name
                Dim sTarget = "" & Y & "\" & attch1nama 'testFile.Name

                File.Copy(sSource, sTarget, True)
                Try
                    SQL = "Update [dbo].[AFA_H] Set [Atth]='" & attch1nama & "' where [AFA_NO]='" & Trim(TxtAfa.Text) & "'   "
                    Proses.ExecuteNonQuery(SQL)

                    SQL = "update a set a.[StsEmail]=null,[DateSendEmail]= null FROM [AFASYS].[dbo].[AFA_H] a left join [AFASYS].[dbo].[AFA_SIGNATURE] b on b.AFA_NO=a.AFA_NO and b.TYPE='Budget' and b.NIK='11111' where a.AFA_NO='" & Trim(TxtAfa.Text) & "' and b.STS<>'App'  "
                    Proses.ExecuteNonQuery(SQL)


                    isitxt()

                    MsgBox("Upload Attachment Succes")
                Catch ex As Exception
                    MsgBox("Cek file name tidak boleh ada special charakter !")
                End Try


            End If
            End If
        'Catch ex As Exception

        'End Try
    End Sub

    Sub copy2()
        ' Try


        Dim filenama
        tblLog = Proses.ExecuteQuery("SELECT [AFA_NO],isnull(atth2,'') Atth2      FROM [AFASYS].[dbo].[AFA_H] where AFA_NO='" & Trim(TxtAfa.Text) & "'")

        If tblLog.Rows.Count > 0 Then
            filenama = Trim(tblLog.Rows(0).Item(1).ToString)



            Dim Y = Trim(FormFluMenu.btnlink.Caption)
            Shell("net use " & Y & " /USER:surindo\missoft M1spassword!", AppWinStyle.Hide, True, 10000)
            If Trim(TxtAtt2.Text) = "" Then
                MsgBox("FIle Attachment  masih kosong !!")
            Else

                Dim testFile As System.IO.FileInfo
                testFile = My.Computer.FileSystem.GetFileInfo("" & Trim(TxtAtt2.Text) & "")

                Dim filename = testFile.Name

                Dim afa = Trim(TxtAfa.Text)
                Dim attch1nama As String = afa.Replace("/", "-") & "-2.pdf"

                Dim sSource = testFile.DirectoryName & "\" & testFile.Name
                Dim sTarget = "" & Y & "\" & attch1nama

                File.Copy(sSource, sTarget, True)
                Try
                    SQL = "Update [dbo].[AFA_H] Set [Atth2]='" & attch1nama & "' where [AFA_NO]='" & Trim(TxtAfa.Text) & "'   "
                    Proses.ExecuteNonQuery(SQL)

                    SQL = "update a set a.[StsEmail]=null,[DateSendEmail]= null FROM [AFASYS].[dbo].[AFA_H] a left join [AFASYS].[dbo].[AFA_SIGNATURE] b on b.AFA_NO=a.AFA_NO and b.TYPE='Budget' and b.NIK='11111' where a.AFA_NO='" & Trim(TxtAfa.Text) & "' and b.STS<>'App'  "
                    Proses.ExecuteNonQuery(SQL)


                    MsgBox("Upload Attachment Succes")
                    isitxt()
                Catch ex As Exception
                    MsgBox("Cek file name tidak boleh ada special charakter !")
                End Try




            End If
        End If
        'Catch ex As Exception

        'End Try
    End Sub
    Sub jabaAuth()
        tblSect = Proses.ExecuteQuery("SELECT  [Jabatan]     ,[urut]  FROM [AFASYS].[dbo].[AFA_JAB_SIGN] where Jabatan NOT IN ('Drafter','Chief Staff','Spv')  order by urut desc")

        Dim comboBoxColumn As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        Dim comboBoxColumnvalue As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        comboBoxColumn.HeaderText = "Auth_Jab"
        comboBoxColumn.DataPropertyName = "Auth_Jab"
        comboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        comboBoxColumn.FlatStyle = FlatStyle.Flat
        comboBoxColumn.DataSource = tblSect
        comboBoxColumn.ValueMember = tblSect.Columns(0).ColumnName.ToString
        comboBoxColumn.DisplayMember = tblSect.Columns(0).ColumnName.ToString
        comboBoxColumn.Width = 130


        DgAuth.Columns.RemoveAt(3)
        DgAuth.Columns.Insert(3, comboBoxColumn)

    End Sub
    Sub JabDir()
        tblSect = Proses.ExecuteQuery("SELECT  [Jabatan]     ,[urut]  FROM [AFASYS].[dbo].[AFA_JAB_SIGN] order by urut desc")

        Dim comboBoxColumn As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        Dim comboBoxColumnvalue As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        comboBoxColumn.HeaderText = "Dir_Jab"
        comboBoxColumn.DataPropertyName = "Dir_Jab"
        comboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        comboBoxColumn.FlatStyle = FlatStyle.Flat
        comboBoxColumn.DataSource = tblSect
        comboBoxColumn.ValueMember = tblSect.Columns(0).ColumnName.ToString
        comboBoxColumn.DisplayMember = tblSect.Columns(0).ColumnName.ToString
        comboBoxColumn.Width = 130


        DgAuth.Columns.RemoveAt(9)
        DgAuth.Columns.Insert(9, comboBoxColumn)

    End Sub



    Private Sub BtnAtt2_Click(sender As Object, e As EventArgs) Handles BtnAtt2.Click
        TxtAtt2.Text = ""

        Dim opendialog As New OpenFileDialog

        '   opendialog.InitialDirectory = "C:\"
        opendialog.Title = "Open a Pdf File"
        opendialog.Filter = "Pdf Files|*.pdf"



        If opendialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtAtt2.Text = opendialog.FileName
            BtnUpp2.Enabled = True

        End If
    End Sub

    Private Sub BtnUpp2_Click(sender As Object, e As EventArgs) Handles BtnUpp2.Click
        copy2()
    End Sub



    Sub jabSupp()
        tblSect = Proses.ExecuteQuery("SELECT  [Jabatan]     ,[urut]  FROM [AFASYS].[dbo].[AFA_JAB_SIGN] where Jabatan NOT IN ('Drafter','Chief Staff','Spv')  order by urut desc")

        Dim comboBoxColumn As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        Dim comboBoxColumnvalue As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
        comboBoxColumn.HeaderText = "Supp_Jab"
        comboBoxColumn.DataPropertyName = "Supp_Jab"
        comboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
        comboBoxColumn.FlatStyle = FlatStyle.Flat
        comboBoxColumn.DataSource = tblSect
        comboBoxColumn.ValueMember = tblSect.Columns(0).ColumnName.ToString
        comboBoxColumn.DisplayMember = tblSect.Columns(0).ColumnName.ToString
        comboBoxColumn.Width = 130


        DgAuth.Columns.RemoveAt(6)
        DgAuth.Columns.Insert(6, comboBoxColumn)

    End Sub
    Sub GridAuth()
        DgAuth.DataSource = Nothing
        Dim afa = Trim(TxtAfa.Text)
        tblgrid = Proses.ExecuteQuery("seLECT  a.[Urut],isnull(b.NIK,'') Auth_NIK,isnull(b.NAMA,'') Authorized,isnull(b.JAB,'') Auth_Jab   ,isnull(c.NIK,'') Supp_NIK,isnull(c.NAMA,'') Supporting,isnull(c.JAB,'') Supp_Jab,isnull(d.NIK,'') Dir_NIK,isnull(d.NAMA,'') Direct,isnull(d.JAB,'') Dir_Jab,isnull(b.STS,'') Sts_Auth,isnull(c.STS,'') Sts_Supp,isnull(d.STS,'') Sts_Dir FROM [AFASYS].[dbo].[V_Urut] a  left join [AFASYS].[dbo].[AFA_SIGNATURE] b on b.ID=a.urut and b.TYPE='Auth' and b.AFA_NO='" & afa & "' left join [AFASYS].[dbo].[AFA_SIGNATURE] c on c.ID=a.urut and c.TYPE='Supp' and c.AFA_NO='" & afa & "' left join [AFASYS].[dbo].[AFA_SIGNATURE] d on d.ID=a.urut and d.TYPE='Dir' and d.AFA_NO='" & afa & "'")

        If tblgrid.Rows.Count = 0 Then
            DgAuth.DataSource = Nothing
        Else
            DgAuth.ClearSelection()

            DgAuth.DataSource = tblgrid
            DgAuth.Columns(0).Width = 50

            DgAuth.Columns(1).Width = 90

            DgAuth.Columns(3).Width = 100

            DgAuth.Columns(2).Width = 250
            DgAuth.Columns(5).Width = 250
            DgAuth.Columns(8).Width = 250

            '  disabel sort header
            For i = 0 To DgAuth.Columns.Count - 1
                DgAuth.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
            Next i



            DgAuth.Columns(0).ReadOnly = True
            DgAuth.Columns(1).ReadOnly = True
            DgAuth.Columns(4).ReadOnly = True
            DgAuth.Columns(7).ReadOnly = True





            DgAuth.Columns(1).Visible = False
            DgAuth.Columns(4).Visible = False
            DgAuth.Columns(7).Visible = False

            DgAuth.Columns(10).Visible = False
            DgAuth.Columns(11).Visible = False
            DgAuth.Columns(12).Visible = False

            AuthNIK()
            SuppNIK()
            DirNIK()
            jabaAuth()
            jabSupp()
            JabDir()

            DgAuth.Columns(3).Width = 130
            DgAuth.Columns(3).Width = 130
            DgAuth.Columns(3).Width = 130

            Dim mm As New DataGridViewCellStyle()
            mm.BackColor = Color.Red
            Dim pp As New DataGridViewCellStyle()
            pp.BackColor = Color.White


        End If
        tblLog = Proses.ExecuteQuery("select * from [AFA_SIGNATURE] where AFA_NO='" & afa & "'")
        If tblLog.Rows.Count > 0 Then
            BtnSend.Enabled = True
        Else
            BtnSend.Enabled = False
        End If

    End Sub



    Sub saveproc()
        If TxtAfa.Text.Trim = "" Then MsgBox("Please, Choice AFA") : Exit Sub
        Dim P, S, DB As String
        P = Trim(FormFluMenu.TxtP.Caption)
        DB = Trim(FormFluMenu.TxtDB.Caption)
        S = Trim(FormFluMenu.TxtSer.Caption)
        Dim shostname, user As String
        shostname = System.Net.Dns.GetHostName
        user = SystemInformation.UserName

        For i As Integer = 0 To DgAuth.Rows.Count - 1

            Cursor.Current = Cursors.WaitCursor


            Dim connectionString As String = "Data Source= " & S & ";Initial Catalog=" & DB & "; Persist Security Info=True; User ID=sa; Password=" & P & ""
                Dim Database As New SqlClient.SqlConnection(connectionString)
                Database.Open()
                ' ----- Membuat command dasar
                Dim Commandku As New SqlClient.SqlCommand()
                Commandku.CommandType = CommandType.StoredProcedure
                Commandku.Connection = Database

            Commandku.CommandText = "AFA_SIGNATURE_Proc"

            Dim nik As String
            Dim nama As String
            Dim jab As String

            Dim id As String = Trim(Me.DgAuth.Item(0, i).Value)
            If Me.DgAuth.Item(1, i).Value.ToString.Length = Nothing Then
                nik = ""
            Else
                nik = Trim(Me.DgAuth.Item(1, i).Value)
            End If

            If Me.DgAuth.Item(2, i).Value.ToString.Length = Nothing Then
                nama = ""
            Else
                nama = Trim(Me.DgAuth.Item(2, i).Value)
            End If

            If Me.DgAuth.Item(3, i).Value.ToString.Length = Nothing Then
                jab = ""
            Else
                jab = Trim(Me.DgAuth.Item(3, i).Value)
            End If


            Dim userid = Trim(FormFluMenu.btnuserid.Caption)
            Dim jenis = "Auth"
            Dim AFA = Trim(TxtAfa.Text)



            Dim typee = "I"

            Commandku.Parameters.AddWithValue("@AFA", AFA)
            Commandku.Parameters.AddWithValue("@id", id)
            Commandku.Parameters.AddWithValue("@nik", nik)
            Commandku.Parameters.AddWithValue("@nama", nama)
            Commandku.Parameters.AddWithValue("@jab", jab)
            Commandku.Parameters.AddWithValue("@Jenis", jenis)
            Commandku.Parameters.AddWithValue("@PC", shostname)
            Commandku.Parameters.AddWithValue("@Userid", userid)
            Commandku.Parameters.AddWithValue("@tYPE", typee)


            Dim outParam As SqlClient.SqlParameter =
                Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
                outParam.Direction = ParameterDirection.Output

                Dim outParamSts As SqlClient.SqlParameter =
                Commandku.Parameters.Add("@Sts_", SqlDbType.VarChar, 630)
                outParamSts.Direction = ParameterDirection.Output


                Commandku.CommandTimeout = 1000
                Commandku.ExecuteNonQuery()



                If outParam.Value = "OK" Then

                    lblpesan.Text = Trim(outParamSts.Value).ToString


                ElseIf outParam.Value = "NOTOK" Then
                    Cursor.Current = Cursors.Default
                    MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


                End If
                ' ----- Bersih - bersih.
                Commandku = Nothing
                Database.Close()
                Database.Dispose()



        Next

        For x As Integer = 0 To DgAuth.Rows.Count - 1

            Cursor.Current = Cursors.WaitCursor


            Dim connectionString As String = "Data Source= " & S & ";Initial Catalog=" & DB & "; Persist Security Info=True; User ID=sa; Password=" & P & ""
            Dim Database As New SqlClient.SqlConnection(connectionString)
            Database.Open()
            ' ----- Membuat command dasar
            Dim Commandku As New SqlClient.SqlCommand()
            Commandku.CommandType = CommandType.StoredProcedure
            Commandku.Connection = Database

            Commandku.CommandText = "AFA_SIGNATURE_Proc"
            Dim nik As String
            Dim nama As String
            Dim jab As String
            If Me.DgAuth.Item(4, x).Value.ToString.Length = Nothing Then
                nik = ""
            Else
                nik = Trim(Me.DgAuth.Item(4, x).Value)
            End If
            If Me.DgAuth.Item(5, x).Value.ToString.Length = Nothing Then
                nama = ""
            Else
                nama = Trim(Me.DgAuth.Item(5, x).Value)
            End If

            If Me.DgAuth.Item(6, x).Value.ToString.Length = Nothing Then
                jab = ""
            Else
                jab = Trim(Me.DgAuth.Item(6, x).Value)
            End If
            Dim id As String = Trim(Me.DgAuth.Item(0, x).Value)

            Dim userid = Trim(FormFluMenu.btnuserid.Caption)
            Dim jenis = "Supp"
            Dim AFA = Trim(TxtAfa.Text)



            Dim typee = "I"

            Commandku.Parameters.AddWithValue("@AFA", AFA)
            Commandku.Parameters.AddWithValue("@id", id)
            Commandku.Parameters.AddWithValue("@nik", nik)
            Commandku.Parameters.AddWithValue("@nama", nama)
            Commandku.Parameters.AddWithValue("@jab", jab)
            Commandku.Parameters.AddWithValue("@Jenis", jenis)
            Commandku.Parameters.AddWithValue("@PC", shostname)
            Commandku.Parameters.AddWithValue("@Userid", userid)
            Commandku.Parameters.AddWithValue("@tYPE", typee)


            Dim outParam As SqlClient.SqlParameter =
                Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
            outParam.Direction = ParameterDirection.Output

            Dim outParamSts As SqlClient.SqlParameter =
                Commandku.Parameters.Add("@Sts_", SqlDbType.VarChar, 630)
            outParamSts.Direction = ParameterDirection.Output


            Commandku.CommandTimeout = 1000
            Commandku.ExecuteNonQuery()



            If outParam.Value = "OK" Then

                lblPesan.Text = Trim(outParamSts.Value).ToString


            ElseIf outParam.Value = "NOTOK" Then
                Cursor.Current = Cursors.Default
                MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If
            ' ----- Bersih - bersih.
            Commandku = Nothing
            Database.Close()
            Database.Dispose()



        Next
        For y As Integer = 0 To DgAuth.Rows.Count - 1

            Cursor.Current = Cursors.WaitCursor


            Dim connectionString As String = "Data Source= " & S & ";Initial Catalog=" & DB & "; Persist Security Info=True; User ID=sa; Password=" & P & ""
            Dim Database As New SqlClient.SqlConnection(connectionString)
            Database.Open()
            ' ----- Membuat command dasar
            Dim Commandku As New SqlClient.SqlCommand()
            Commandku.CommandType = CommandType.StoredProcedure
            Commandku.Connection = Database

            Commandku.CommandText = "AFA_SIGNATURE_Proc"


            Dim id As String = Trim(Me.DgAuth.Item(0, y).Value)

            Dim nik, nama, jab As String
            If Me.DgAuth.Item(7, y).Value.ToString.Length = Nothing Then
                nik = ""
            Else
                nik = Trim(Me.DgAuth.Item(7, y).Value)
            End If
            If Me.DgAuth.Item(8, y).Value.ToString.Length = Nothing Then
                nama = ""
            Else
                nama = Trim(Me.DgAuth.Item(8, y).Value)
            End If
            If Me.DgAuth.Item(9, y).Value.ToString.Length = Nothing Then
                jab = ""
            Else
                jab = Trim(Me.DgAuth.Item(9, y).Value)
            End If
            Dim userid = Trim(FormFluMenu.btnuserid.Caption)
            Dim jenis = "Dir"
            Dim AFA = Trim(TxtAfa.Text)



            Dim typee = "I"

            Commandku.Parameters.AddWithValue("@AFA", AFA)
            Commandku.Parameters.AddWithValue("@id", id)
            Commandku.Parameters.AddWithValue("@nik", nik)
            Commandku.Parameters.AddWithValue("@nama", nama)
            Commandku.Parameters.AddWithValue("@jab", jab)
            Commandku.Parameters.AddWithValue("@Jenis", jenis)
            Commandku.Parameters.AddWithValue("@PC", shostname)
            Commandku.Parameters.AddWithValue("@Userid", userid)
            Commandku.Parameters.AddWithValue("@tYPE", typee)


            Dim outParam As SqlClient.SqlParameter =
                Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
            outParam.Direction = ParameterDirection.Output

            Dim outParamSts As SqlClient.SqlParameter =
                Commandku.Parameters.Add("@Sts_", SqlDbType.VarChar, 630)
            outParamSts.Direction = ParameterDirection.Output


            Commandku.CommandTimeout = 1000
            Commandku.ExecuteNonQuery()



            If outParam.Value = "OK" Then

                lblPesan.Text = Trim(outParamSts.Value).ToString


            ElseIf outParam.Value = "NOTOK" Then
                Cursor.Current = Cursors.Default
                MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If
            ' ----- Bersih - bersih.
            Commandku = Nothing
            Database.Close()
            Database.Dispose()



        Next

        GridAuth()
        isitxt()
    End Sub

    Private Sub XtraFormSignature_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            SplitContainer1.SplitterDistance = 237

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub DgAuth_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DgAuth.CellValueChanged

    '    For y = 0 To DgAuth.Rows.Count - 1

    '        If e.ColumnIndex = 9 Then
    '            Dim JABDIR = Trim(DgAuth.Rows(e.RowIndex).Cells(y).Value.ToString)

    '            If JABDIR = "Drafter" Then
    '                BtnSave.Enabled = True
    '                BtnSend.Enabled = True
    '            Else
    '                BtnSave.Enabled = False
    '                BtnSend.Enabled = False
    '            End If
    '        End If
    '    Next


    'End Sub
End Class