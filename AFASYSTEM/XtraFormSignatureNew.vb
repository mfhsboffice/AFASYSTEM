Imports System.Globalization
Imports System.IO
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Public Class XtraFormSignatureNew
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblLogin, tblgrid As DataTable
    Dim tblauth, tblsupp, tbldirr, tblemployee As DataTable
    Dim tblLog As DataTable
    Dim CM As CurrencyManager
    Private Sub XtraFormSignatureNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        kodenikk()
        BtnSend.Enabled = False
        TxtSubject.ReadOnly = True
        TxtSchedule.ReadOnly = True
        TxtEst_Cost.ReadOnly = True
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
        tblemployee = Proses.ExecuteQuery("SELECT  a.[AFA_NO] ,isnull(a.atth,'') Atth,isnull(a.atth2,'') Atth2     ,isnull([NOTETEXT],'') [NOTETEXT],isnull([SCHEDULE],'') [SCHEDULE],[STS]   ,AMT  FROM [AFASYS].[dbo].[AFA_H] a  left join [dbo].[AFA_HAK_AKSES] b on b.AFA_NO=a.AFA_NO LEFT JOIN [AFASYS].[dbo].[User_H] D ON D.UserIfs=B.NIK where D.UserID='" & nikuser & "' and a.AFA_NO='" & afa & "'")
        If tblemployee.Rows.Count > 0 Then
            TxtSubject.Text = tblemployee.Rows(0).Item("NOTETEXT").ToString
            TxtSchedule.Text = tblemployee.Rows(0).Item("SCHEDULE").ToString
            TxtEst_Cost.Text = tblemployee.Rows(0).Item("AMT").ToString
            lblatth.Text = tblemployee.Rows(0).Item("Atth").ToString
            lblatth2.Text = tblemployee.Rows(0).Item("Atth2").ToString
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

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
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

    Private Sub BtnUpp2_Click(sender As Object, e As EventArgs) Handles BtnUpp2.Click
        copy2()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'For y As Integer = 0 To DgAuth.Rows.Count - 1
        '    If Trim(Me.DgAuth.Item(9, y).Value.ToString) <> "Drafter" Then MsgBox("Save Gagal Drafter tidak ada") : Exit Sub
        'Next
        saveproc()
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

        For i As Integer = 0 To GridView1.RowCount - 1





            '  For i As Integer = 0 To DgAuth.Rows.Count - 1

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

            Dim id = Trim(GridView1.GetRowCellValue(i, "Urut").ToString)



            If Trim(GridView1.GetRowCellValue(i, "Auth_NIK").ToString).Length = Nothing Then
                nik = ""
            Else
                nik = Trim(GridView1.GetRowCellValue(i, "Auth_NIK").ToString)
            End If

            If Trim(GridView1.GetRowCellValue(i, "Authorized").ToString).Length = Nothing Then
                nama = ""
            Else
                nama = Trim(GridView1.GetRowCellValue(i, "Authorized").ToString)
            End If

            If Trim(GridView1.GetRowCellValue(i, "Auth_Jab").ToString).Length = Nothing Then
                jab = ""
            Else
                jab = Trim(GridView1.GetRowCellValue(i, "Auth_Jab").ToString)
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

        For x As Integer = 0 To GridView1.RowCount - 1

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


            'seLECT  a.[Urut],isnull(b.NIK,'') Auth_NIK,isnull(b.NAMA,'') Authorized,isnull(b.JAB,'') Auth_Jab   ,isnull(c.NIK,'') Supp_NIK,isnull(c.NAMA,'') Supporting,isnull(c.JAB,'') Supp_Jab,isnull(d.NIK,'') Dir_NIK,isnull(d.NAMA,'') Direct,
            ''isnull(d.JAB,'') Dir_Jab,isnull(b.STS,'') Sts_Auth,isnull(c.STS,'') Sts_Supp,isnull(d.STS,'') Sts_Dir


            If Trim(GridView1.GetRowCellValue(x, "Supp_NIK").ToString).Length = Nothing Then
                nik = ""
            Else
                nik = Trim(GridView1.GetRowCellValue(x, "Supp_NIK").ToString)
            End If
            If Trim(GridView1.GetRowCellValue(x, "Supporting").ToString).Length = Nothing Then
                nama = ""
            Else
                nama = Trim(GridView1.GetRowCellValue(x, "Supporting").ToString)
            End If

            If Trim(GridView1.GetRowCellValue(x, "Supporting").ToString).Length = Nothing Then
                jab = ""
            Else
                jab = Trim(GridView1.GetRowCellValue(x, "Supp_Jab").ToString)
            End If
            Dim id = Trim(GridView1.GetRowCellValue(x, "Urut").ToString)


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
        For y As Integer = 0 To GridView1.RowCount - 1

            Cursor.Current = Cursors.WaitCursor


            Dim connectionString As String = "Data Source= " & S & ";Initial Catalog=" & DB & "; Persist Security Info=True; User ID=sa; Password=" & P & ""
            Dim Database As New SqlClient.SqlConnection(connectionString)
            Database.Open()
            ' ----- Membuat command dasar
            Dim Commandku As New SqlClient.SqlCommand()
            Commandku.CommandType = CommandType.StoredProcedure
            Commandku.Connection = Database

            Commandku.CommandText = "AFA_SIGNATURE_Proc"


            Dim id = Trim(GridView1.GetRowCellValue(y, "Urut").ToString)


            Dim nik, nama, jab As String

            'seLECT  a.[Urut],isnull(b.NIK,'') Auth_NIK,isnull(b.NAMA,'') Authorized,isnull(b.JAB,'') Auth_Jab   ,isnull(c.NIK,'') Supp_NIK,isnull(c.NAMA,'') Supporting,isnull(c.JAB,'') Supp_Jab,isnull(d.NIK,'') Dir_NIK,isnull(d.NAMA,'') Direct,
            ''isnull(d.JAB,'') Dir_Jab,isnull(b.STS,'') Sts_Auth,isnull(c.STS,'') Sts_Supp,isnull(d.STS,'') Sts_Dir


            If Trim(GridView1.GetRowCellValue(y, "Dir_NIK").ToString).Length = Nothing Then

                nik = ""
            Else
                nik = Trim(GridView1.GetRowCellValue(y, "Dir_NIK").ToString)
            End If
            If Trim(GridView1.GetRowCellValue(y, "Direct").ToString).Length = Nothing Then
                nama = ""
            Else
                nama = Trim(GridView1.GetRowCellValue(y, "Direct").ToString)
            End If
            If Trim(GridView1.GetRowCellValue(y, "Dir_Jab").ToString).Length = Nothing Then
                jab = ""
            Else
                jab = Trim(GridView1.GetRowCellValue(y, "Dir_Jab").ToString)
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

    Sub GridAuth()
        DgAuth.DataSource = Nothing
        Dim afa = Trim(TxtAfa.Text)

        tblDept = Proses.ExecuteQuery("seLECT  a.[Urut],isnull(b.NIK,'') Auth_NIK,isnull(b.NAMA,'') Authorized,isnull(b.JAB,'') Auth_Jab   ,isnull(c.NIK,'') Supp_NIK,isnull(c.NAMA,'') Supporting,isnull(c.JAB,'') Supp_Jab,isnull(d.NIK,'') Dir_NIK,isnull(d.NAMA,'') Direct,isnull(d.JAB,'') Dir_Jab,isnull(b.STS,'') Sts_Auth,isnull(c.STS,'') Sts_Supp,isnull(d.STS,'') Sts_Dir FROM [AFASYS].[dbo].[V_Urut] a  left join [AFASYS].[dbo].[AFA_SIGNATURE] b on b.ID=a.urut and b.TYPE='Auth' and b.AFA_NO='" & afa & "' left join [AFASYS].[dbo].[AFA_SIGNATURE] c on c.ID=a.urut and c.TYPE='Supp' and c.AFA_NO='" & afa & "' left join [AFASYS].[dbo].[AFA_SIGNATURE] d on d.ID=a.urut and d.TYPE='Dir' and d.AFA_NO='" & afa & "'")


        If tblDept.Rows.Count = 0 Then
            DgAuth.DataSource = Nothing

        Else

            DgAuth.DataSource = tblDept


            Dim gridView1 As GridView = TryCast(DgAuth.MainView, GridView)



            ' Obtain created columns.
            Dim COLURUT As GridColumn = gridView1.Columns("Urut")
            Dim colautnik As GridColumn = gridView1.Columns("Auth_NIK")
            Dim colauthnama As GridColumn = gridView1.Columns("Authorized")
            Dim colauthjab As GridColumn = gridView1.Columns("Auth_Jab")
            Dim colsuppnik As GridColumn = gridView1.Columns("Supp_NIK")
            Dim colsuppnama As GridColumn = gridView1.Columns("Supporting")
            Dim colsuppjab As GridColumn = gridView1.Columns("Supp_Jab")

            Dim coldirnik As GridColumn = gridView1.Columns("Dir_NIK")
            Dim coldirnama As GridColumn = gridView1.Columns("Direct")
            Dim coldirjab As GridColumn = gridView1.Columns("Dir_Jab")

            Dim colstsauth As GridColumn = gridView1.Columns("Sts_Auth")
            Dim colstssupp As GridColumn = gridView1.Columns("Sts_Supp")
            Dim colstsdir As GridColumn = gridView1.Columns("Sts_Dir")

            COLURUT.Visible = False
            colautnik.Visible = False
            colsuppnik.Visible = False
            coldirnik.Visible = False
            colstsauth.Visible = False
            colstssupp.Visible = False
            colstsdir.Visible = False


            colauthjab.OptionsColumn.ReadOnly = True
            colsuppjab.OptionsColumn.ReadOnly = True
            coldirjab.OptionsColumn.ReadOnly = True




            ' Make the grid read-only.
            gridView1.OptionsBehavior.Editable = True
            ' Prevent the focused cell from being highlighted.
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = True
            ' Draw a dotted focus rectangle around the entire row.
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

            gridView1.OptionsCustomization.AllowColumnMoving = False
            gridView1.OptionsCustomization.AllowSort = False
            gridView1.OptionsCustomization.AllowFilter = False


            SetupRepositoryLookUpAuth()
            SetupRepositoryLookUpsUPP()
            SetupRepositoryLookUpDir()
            SetupUnboundNama()


        End If

        tblLog = Proses.ExecuteQuery("select * from [AFA_SIGNATURE] where AFA_NO='" & afa & "'")
        If tblLog.Rows.Count > 0 Then
            BtnSend.Enabled = True
        Else
            BtnSend.Enabled = False
        End If

    End Sub
    Private Sub SetupUnboundNama()

        If GridView1.Columns("Authorized") Is Nothing Then
            Dim COLAUTHNAME As New GridColumn()
            With COLAUTHNAME
                .FieldName = "Authorized"
                .Caption = "Authorized"
                .UnboundType = DevExpress.Data.UnboundColumnType.String
                .Visible = True
                .OptionsColumn.AllowEdit = False ' Biar tidak bisa diketik manual
            End With

            GridView1.Columns.Add(COLAUTHNAME)
        End If

        If GridView1.Columns("Supporting") Is Nothing Then
            Dim colsupname As New GridColumn()
            With colsupname
                .FieldName = "Supporting"
                .Caption = "Supporting"
                .UnboundType = DevExpress.Data.UnboundColumnType.String
                .Visible = True
                .OptionsColumn.AllowEdit = False ' Biar tidak bisa diketik manual
            End With

            GridView1.Columns.Add(colsupname)
        End If

        If GridView1.Columns("Direct") Is Nothing Then
            Dim coldirectname As New GridColumn()
            With coldirectname
                .FieldName = "Direct"
                .Caption = "Direct"
                .UnboundType = DevExpress.Data.UnboundColumnType.String
                .Visible = True
                .OptionsColumn.AllowEdit = False ' Biar tidak bisa diketik manual
            End With

            GridView1.Columns.Add(coldirectname)
        End If
    End Sub
    Private Sub SetupRepositoryLookUpAuth()
        ' Ambil data master barang

        tblauth = Proses.ExecuteQuery("SELECT   Auth_NIK,  Authorized    , Auth_Jab FROM LIST_APPROVER_AUTH ORDER BY Authorized ASC")

        ' Buat repository
        Dim repoLookupaUTH As New RepositoryItemLookUpEdit()
        With repoLookupaUTH
            .DataSource = tblauth
            .DisplayMember = "Authorized"
            .ValueMember = "Authorized"
            .NullText = ""
            .SearchMode = SearchMode.AutoSearch
            .BestFitMode = BestFitMode.BestFit
            .HeaderClickMode = HeaderClickMode.AutoSearch
            .CaseSensitiveSearch = True


            .PopupFormMinSize = New Size(700, 300)


            .Columns.Add(New LookUpColumnInfo("Auth_NIK", 120, "Auth_NIK"))
            .Columns.Add(New LookUpColumnInfo("Authorized", 350, "Authorized"))
            .Columns.Add(New LookUpColumnInfo("Auth_Jab", 380, "Auth_Jab"))
        End With

        ' Tambah ke grid
        DgAuth.RepositoryItems.Add(repoLookupaUTH)

        ' Assign ke kolom
        Dim COLNMAUTH As GridColumn = GridView1.Columns("Authorized")
        COLNMAUTH.ColumnEdit = repoLookupaUTH
    End Sub

    Private Sub SetupRepositoryLookUpsUPP()
        ' Ambil data master barang

        tblsupp = Proses.ExecuteQuery("SELECT   Supp_NIK,  Supporting    , Supp_Jab FROM LIST_APPROVER_SUPP ORDER BY Supporting ASC")

        ' Buat repository
        Dim repoLookupSupp As New RepositoryItemLookUpEdit()
        With repoLookupSupp
            .DataSource = tblsupp
            .DisplayMember = "Supporting"
            .ValueMember = "Supporting"
            .NullText = ""
            .SearchMode = SearchMode.AutoSearch
            .BestFitMode = BestFitMode.BestFit
            .HeaderClickMode = HeaderClickMode.AutoSearch
            .CaseSensitiveSearch = True


            .PopupFormMinSize = New Size(700, 300)


            .Columns.Add(New LookUpColumnInfo("Supp_NIK", 120, "Supp_NIK"))
            .Columns.Add(New LookUpColumnInfo("Supporting", 350, "Supporting"))
            .Columns.Add(New LookUpColumnInfo("Supp_Jab", 380, "Supp_Jab"))
        End With

        ' Tambah ke grid
        DgAuth.RepositoryItems.Add(repoLookupSupp)

        ' Assign ke kolom
        Dim colnmSupp As GridColumn = GridView1.Columns("Supporting")
        colnmSupp.ColumnEdit = repoLookupSupp
    End Sub
    Private Sub SetupRepositoryLookUpDir()
        ' Ambil data master barang

        tbldirr = Proses.ExecuteQuery("SELECT   Dir_NIK,  Direct    , Dir_jab FROM LIST_APPROVER_DIR ORDER BY Direct ASC")

        ' Buat repository
        Dim repoLookupDirr As New RepositoryItemLookUpEdit()
        With repoLookupDirr
            .DataSource = tbldirr
            .DisplayMember = "Direct"
            .ValueMember = "Direct"
            .NullText = ""
            .SearchMode = SearchMode.AutoSearch
            .BestFitMode = BestFitMode.BestFit
            .HeaderClickMode = HeaderClickMode.AutoSearch
            .CaseSensitiveSearch = True


            .PopupFormMinSize = New Size(700, 300)


            .Columns.Add(New LookUpColumnInfo("Dir_NIK", 120, "Dir_NIK"))
            .Columns.Add(New LookUpColumnInfo("Direct", 350, "Direct"))
            .Columns.Add(New LookUpColumnInfo("Dir_jab", 380, "Dir_jab"))
        End With

        ' Tambah ke grid
        DgAuth.RepositoryItems.Add(repoLookupDirr)

        ' Assign ke kolom
        Dim colnmDir As GridColumn = GridView1.Columns("Direct")
        colnmDir.ColumnEdit = repoLookupDirr
    End Sub
    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged


        If e.Column.FieldName = "Authorized" Then
            Dim AUTHNAME As String = e.Value?.ToString().Trim()

            ' Try
            If Not String.IsNullOrEmpty(AUTHNAME) Then
                ' Cari NamaBarang dari dtBarang
                Dim found() As DataRow = tblauth.Select("Authorized = '" & AUTHNAME.Replace("'", "''") & "'")
                If found.Length > 0 Then
                    ' Update kolom NamaBarang pada baris yang sama
                    GridView1.SetRowCellValue(e.RowHandle, "Auth_NIK", found(0)("Auth_NIK").ToString())
                    GridView1.SetRowCellValue(e.RowHandle, "Auth_Jab", found(0)("Auth_Jab").ToString())

                Else
                    ' Jika PartNo ada tapi tidak ditemukan di dtBarang, kosongkan data terkait
                    GridView1.SetRowCellValue(e.RowHandle, "Auth_NIK", "")
                    GridView1.SetRowCellValue(e.RowHandle, "Auth_Jab", "")

                End If
            Else

            End If

            ' Catch ex As Exception
            ' Log error jika perlu
            '  MessageBox.Show(ex.Message)
            '  End Try
        End If

        If e.Column.FieldName = "Supporting" Then
            Dim supname As String = e.Value?.ToString().Trim()

            Try
                If Not String.IsNullOrEmpty(supname) Then
                    ' Cari NamaBarang dari dtBarang
                    Dim found() As DataRow = tblsupp.Select("Supporting = '" & supname.Replace("'", "''") & "'")
                    If found.Length > 0 Then
                        ' Update kolom NamaBarang pada baris yang sama
                        GridView1.SetRowCellValue(e.RowHandle, "Supp_NIK", found(0)("Supp_NIK").ToString())
                        GridView1.SetRowCellValue(e.RowHandle, "Supp_Jab", found(0)("Supp_Jab").ToString())

                    Else
                        ' Jika PartNo ada tapi tidak ditemukan di dtBarang, kosongkan data terkait
                        GridView1.SetRowCellValue(e.RowHandle, "Supp_NIK", "")
                        GridView1.SetRowCellValue(e.RowHandle, "Supp_Jab", "")

                    End If
                Else

                End If

            Catch ex As Exception
                ' Log error jika perlu
                MessageBox.Show(ex.Message)
            End Try
        End If

        If e.Column.FieldName = "Direct" Then
            Dim dirname As String = e.Value?.ToString().Trim()

            Try
                If Not String.IsNullOrEmpty(dirname) Then
                    ' Cari NamaBarang dari dtBarang
                    Dim found() As DataRow = tbldirr.Select("Direct = '" & dirname.Replace("'", "''") & "'")
                    If found.Length > 0 Then
                        ' Update kolom NamaBarang pada baris yang sama
                        GridView1.SetRowCellValue(e.RowHandle, "Dir_NIK", found(0)("Dir_NIK").ToString())
                        GridView1.SetRowCellValue(e.RowHandle, "Dir_Jab", found(0)("Dir_Jab").ToString())

                    Else
                        ' Jika PartNo ada tapi tidak ditemukan di dtBarang, kosongkan data terkait
                        GridView1.SetRowCellValue(e.RowHandle, "Dir_NIK", "")
                        GridView1.SetRowCellValue(e.RowHandle, "Dir_Jab", "")

                    End If
                Else

                End If

            Catch ex As Exception
                ' Log error jika perlu
                MessageBox.Show(ex.Message)
            End Try
        End If

    End Sub
    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle

        If e.Column.FieldName = "Authorized" Then

            Dim stsauth As String = Convert.ToString(GridView1.GetRowCellValue(e.RowHandle, "Sts_Auth"))

            If stsauth = "App" Then
                e.Appearance.ForeColor = Color.Red
            Else
                e.Appearance.ForeColor = Color.Black
            End If

        End If

        If e.Column.FieldName = "Supporting" Then

            Dim stssupp As String = Convert.ToString(GridView1.GetRowCellValue(e.RowHandle, "Sts_Supp"))

            If stssupp = "App" Then
                e.Appearance.ForeColor = Color.Red
            Else
                e.Appearance.ForeColor = Color.Black
            End If

        End If

        If e.Column.FieldName = "Direct" Then

            Dim stsdirect As String = Convert.ToString(GridView1.GetRowCellValue(e.RowHandle, "Sts_Dir"))

            If stsdirect = "App" Then
                e.Appearance.ForeColor = Color.Red
            Else
                e.Appearance.ForeColor = Color.Black
            End If

        End If
    End Sub
End Class