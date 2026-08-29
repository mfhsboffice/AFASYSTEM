
Imports System.Globalization
Imports System.IO
Public Class XtraFormAppOwner
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblgrid, tblDept, tblLog As DataTable
    Dim typee
    Private Sub XtraFormAppOwner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnSave.Enabled = False
        datacmbowner()

        Try
            SplitContainer1.SplitterDistance = 165
        Catch ex As Exception

        End Try
    End Sub
    Sub datacmbowner()

        tblDept = Proses.ExecuteQuery("Select  [UserID],[Name] FROM V_App_Owner order by Name asc")

        If tblDept.Rows.Count = 0 Then
            CmbApprover.Text = ""
            CmbApprover.Items.Clear()
        Else
            CmbApprover.Items.Clear()
            With tblDept.Columns(0)
                For a = 0 To tblDept.Rows.Count - 1
                    CmbApprover.Items.Add(.Table.Rows(a).Item(1)) ' + ":" + .Table.Rows(a).Item(1))
                Next a
            End With
        End If

    End Sub
    Sub isinik()
        tblDept = Proses.ExecuteQuery("Select  [UserID],[Name] FROM [AFASYS].[dbo].[User_H] where name='" & Trim(CmbApprover.Text) & "'")
        If tblDept.Rows.Count = 0 Then
            lblnik.Text = ""
        Else
            lblnik.Text = Trim(tblDept.Rows(0).Item("Userid").ToString)
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If RApp.Checked = True And RUnApp.Checked = False Then
            If BtnSave.Enabled = True Then
                Try
                    Dim Keluar As Int16
                    Keluar = MsgBox("Are you sure you want to approve this data ?", MsgBoxStyle.OkCancel, "Approval proccess")
                    Select Case Keluar
                        Case vbOK

                            typee = "APP"
                            prosess()
                        Case vbCancel
                            Exit Sub
                    End Select
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

        ElseIf RApp.Checked = False And RUnApp.Checked = True Then
            If BtnSave.Enabled = True Then
                Try
                    Dim Keluar As Int16
                    Keluar = MsgBox("Are you sure you want to Disapprove this data ?", MsgBoxStyle.OkCancel, "Disapproval proccess")
                    Select Case Keluar
                        Case vbOK
                            MsgBox("Disapp sementara di disable !")
                            'typee = "UNAPP"
                            'prosess()

                        Case vbCancel
                            Exit Sub
                    End Select
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If


        ElseIf RApp.Checked = False And RUnApp.Checked = False Then
            MsgBox("Please, Choice App or Disapp")
        End If
    End Sub
    Sub prosess()

        Dim P, S, DB As String
        P = Trim(FormFluMenu.TxtP.Caption)
        DB = Trim(FormFluMenu.TxtDB.Caption)
        S = Trim(FormFluMenu.TxtSer.Caption)



        Dim shostname, user As String
        shostname = System.Net.Dns.GetHostName
        user = SystemInformation.UserName
        For i As Integer = 0 To DgView.Rows.Count - 1

            Dim nik = Trim(lblnik.Text)

            Dim afa As String = Trim(Me.DgView.Item(1, i).Value)
            Dim Jenis = Trim(Me.DgView.Item(6, i).Value)
            Dim appal = Trim(Me.DgView.Item(7, i).Value).ToString


            If DgView.Item(0, i).Value = True Then

                Cursor.Current = Cursors.WaitCursor


                Dim connectionString As String = "Data Source= " & S & ";Initial Catalog=" & DB & "; Persist Security Info=True; User ID=sa; Password=" & P & ""
                Dim Database As New SqlClient.SqlConnection(connectionString)
                Database.Open()
                ' ----- Membuat command dasar
                Dim Commandku As New SqlClient.SqlCommand()
                Commandku.CommandType = CommandType.StoredProcedure
                Commandku.Connection = Database



                Commandku.CommandText = "AFA_App_Owner_Proc"
                Dim tgl = Format(DtApp.Value, "yyyyMMdd HH:mm")


                Commandku.Parameters.AddWithValue("@nik", nik)
                Commandku.Parameters.AddWithValue("@Afa", afa)
                Commandku.Parameters.AddWithValue("@Jenis", Jenis)

                Commandku.Parameters.AddWithValue("@PC", shostname)
                Commandku.Parameters.AddWithValue("@tglapp", tgl)

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

            End If
        Next
        showdate()
    End Sub
    Sub showdate()
        DgView.DataSource = Nothing
        Dim userid = Trim(lblnik.Text)
        If RApp.Checked = True And RUnApp.Checked = False Then
            tblgrid = Proses.ExecuteQuery("select aa.AFA_NO,aa.BUDGET_YEAR,aa.BUDGET_REV,aa.NOTETEXT Description,Atth,aa.Type,'App' Jenis from(SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No, a.[AFA_NO]      ,[TYPE]      ,[ID]      ,a.[NIK]      ,[NAMA]      ,[JAB]      ,a.[STS]    ,c.email	,d.BUDGET_YEAR	,d.BUDGET_REV	,d.NOTETEXT,isnull(d.atth,'') Atth  FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  left join afa_jenis_urut b on b.jenis=a.type  left join [dbo].[User_Email] c on c.nik=a.nik  left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO    where a.nik<>'' 	and a.STS='Send'	) as aa	 where aa.no='1'	and aa.NIK='" & userid & "' and aa.BUDGET_YEAR is not null")
            BtnSave.Text = "Approve"
        ElseIf RApp.Checked = False And RUnApp.Checked = True Then
            BtnSave.Text = "Disapprove"
            tblgrid = Proses.ExecuteQuery("select aa.AFA_NO,aa.BUDGET_YEAR,aa.BUDGET_REV,aa.NOTETEXT Description,aa.Atth,aa.Type,'UnApp' Jenis from(SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No, a.[AFA_NO]      ,[TYPE]      ,[ID]      ,a.[NIK]      ,[NAMA]      ,[JAB]      ,a.[STS]    ,c.email	,d.BUDGET_YEAR	,d.BUDGET_REV	,d.NOTETEXT	,d.atth  FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  left join afa_jenis_urut b on b.jenis=a.type  left join [dbo].[User_Email] c on c.nik=a.nik  left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO    where a.nik<>'' 	and a.STS  in ('App','Skip')) as aa	left join (select aa.AFA_NO,max(aa.No) No from(SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No, a.[AFA_NO]      ,[TYPE]      ,[ID]      ,a.[NIK]      ,[NAMA]      ,[JAB]      ,a.[STS]    ,c.email	,d.BUDGET_YEAR	,d.BUDGET_REV	,d.NOTETEXT	,d.atth	  FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  left join afa_jenis_urut b on b.jenis=a.type  left join [dbo].[User_Email] c on c.nik=a.nik  left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO    where a.nik<>'' 	and a.STS  in ('App','Skip')) as aa	group by aa.AFA_NO) bb on aa.AFA_NO=bb.AFA_NO	where aa.NIK='" & userid & "'	and  aa.no = bb.No and  aa.BUDGET_YEAR is not null ")
        ElseIf RApp.Checked = False And RUnApp.Checked = False Then
            MsgBox("Please choice Approve or Un Approve")
        End If

        If tblgrid.Rows.Count = 0 Then
            DgView.DataSource = Nothing
        Else
            DgView.ClearSelection()

            DgView.DataSource = tblgrid
            DgView.Columns(0).Width = 50
            DgView.Columns(1).Width = 200
            DgView.Columns(2).Width = 80
            DgView.Columns(3).Width = 80
            DgView.Columns(4).Width = 400

            DgView.Columns(5).Visible = False
            DgView.Columns(6).Visible = False
            DgView.Columns(7).Visible = False
        End If

    End Sub
    Sub cekall()


        For r = 0 To DgView.Rows.Count - 1
            If CkAll.Checked = True Then
                DgView.Rows(r).Cells(0).Value = True
            Else
                DgView.Rows(r).Cells(0).Value = False
            End If
        Next
        cekbtnsave()
    End Sub

    Sub cekbtnsave()
        Try
            For r = 0 To DgView.Rows.Count - 1
                If DgView.Rows(r).Cells(0).Value = True Then
                    BtnSave.Enabled = True
                Else
                    BtnSave.Enabled = True
                End If
            Next
        Catch ex As Exception

        End Try


    End Sub

    Private Sub CkAll_CheckedChanged(sender As Object, e As EventArgs) Handles CkAll.CheckedChanged
        cekall()
    End Sub

    Private Sub CmbApprover_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbApprover.SelectedIndexChanged
        isinik()
    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        showdate()
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


    Sub copy1()
        ' Try


        Dim filenama
        tblLog = Proses.ExecuteQuery("SELECT [AFA_NO],atth      FROM [AFASYS].[dbo].[AFA_H] where AFA_NO='" & Trim(lblAfa.Text) & "'")

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

                Dim afa = Trim(lblAfa.Text)
                Dim attch1nama As String = afa.Replace("/", "-") & "-3.pdf"

                Dim sSource = testFile.DirectoryName & "\" & testFile.Name
                Dim sTarget = "" & Y & "\" & attch1nama 'testFile.Name

                File.Copy(sSource, sTarget, True)
                Try
                    SQL = "Update [dbo].[AFA_H] Set [AccOwner]='" & attch1nama & "' where [AFA_NO]='" & Trim(lblAfa.Text) & "'   "
                    Proses.ExecuteNonQuery(SQL)




                    MsgBox("Upload  Succes")
                    lblAfa.Text = ""
                Catch ex As Exception
                    MsgBox("Cek file name tidak boleh ada special charakter !")
                End Try


            End If
        End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub BtnUpp1_Click(sender As Object, e As EventArgs) Handles BtnUpp1.Click
        If Trim(lblAfa.Text) = "" Then MsgBox("Pilih Afa dulu!!") : Exit Sub
        copy1()
    End Sub

    Private Sub DgView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgView.CellClick
        cekbtnsave()
    End Sub

    Private Sub DgView_Click(sender As Object, e As EventArgs) Handles DgView.Click
        lblAfa.Text = DgView.SelectedCells(1).Value
    End Sub
End Class