Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports System.Globalization
Imports System.ComponentModel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils.Menu
Public Class XtraFormApproval
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblgrid As DataTable
    Dim typee
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub



    Dim tblEmployee As DataTable



    Dim tblLog As DataTable
    Dim CM As CurrencyManager
    Sub showdate()
        DgView.DataSource = Nothing
        Dim userid = Trim(FormFluMenu.btnuserid.Caption)
        If RApp.Checked = True And RUnApp.Checked = False Then
            tblgrid = Proses.ExecuteQuery("select aa.AFA_NO,aa.BUDGET_YEAR,aa.BUDGET_REV,aa.NOTETEXT Description,Atth,aa.Type,'App' Jenis from(SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No, a.[AFA_NO]      ,[TYPE]      ,[ID]      ,a.[NIK]      ,[NAMA]      ,[JAB]      ,a.[STS]    ,c.email	,d.BUDGET_YEAR	,d.BUDGET_REV	,d.NOTETEXT,isnull(d.atth,'') Atth  FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  left join afa_jenis_urut b on b.jenis=a.type  left join [dbo].[User_Email] c on c.nik=a.nik  left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO    where a.nik<>'' 	and a.STS='Send'	AND D.STS<>'Cancelled') as aa	 where aa.no='1'	and aa.NIK='" & userid & "' and aa.BUDGET_YEAR is not null")
            BtnSave.Text = "Approve"
        ElseIf RApp.Checked = False And RUnApp.Checked = True Then
            BtnSave.Text = "Disapprove"
            ' tblgrid = Proses.ExecuteQuery("select aa.AFA_NO,aa.BUDGET_YEAR,aa.BUDGET_REV,aa.NOTETEXT Description,aa.Atth,aa.Type,'UnApp' Jenis from(SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No, a.[AFA_NO]      ,[TYPE]      ,[ID]      ,a.[NIK]      ,[NAMA]      ,[JAB]      ,a.[STS]    ,c.email	,d.BUDGET_YEAR	,d.BUDGET_REV	,d.NOTETEXT	,d.atth  FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  left join afa_jenis_urut b on b.jenis=a.type  left join [dbo].[User_Email] c on c.nik=a.nik  left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO    where a.nik<>'' 	and a.STS  in ('App','Skip')) as aa	left join (select aa.AFA_NO,max(aa.No) No from(SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No, a.[AFA_NO]      ,[TYPE]      ,[ID]      ,a.[NIK]      ,[NAMA]      ,[JAB]      ,a.[STS]    ,c.email	,d.BUDGET_YEAR	,d.BUDGET_REV	,d.NOTETEXT	,d.atth	  FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  left join afa_jenis_urut b on b.jenis=a.type  left join [dbo].[User_Email] c on c.nik=a.nik  left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO    where a.nik<>'' 	and a.STS  in ('App','Skip')) as aa	group by aa.AFA_NO) bb on aa.AFA_NO=bb.AFA_NO	where aa.NIK='" & userid & "'	and  aa.no = bb.No and  aa.BUDGET_YEAR is not null union all select distinct   aa.AFA_NO,aa.BUDGET_YEAR,aa.BUDGET_REV,CAST(aa.NOTETEXt  as varchar(8000)) Description,(aa.Atth) Atth,'Dir' TYPE,'UnAppAll' Jenis  from(SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No, a.[AFA_NO]  ,[TYPE]  ,[ID]  ,a.[NIK]  ,[NAMA]  ,[JAB]  ,a.[STS] ,c.email,d.BUDGET_YEAR,d.BUDGET_REV,d.NOTETEXT,d.Atth FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  left join afa_jenis_urut b on b.jenis=a.type    left join [dbo].[User_Email] c on c.nik=a.nik  left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO   where a.nik<>'' ) as aa left join (select aa.No,aa.AFA_NO,aa.TYPE,aa.NIK from(SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No, a.[AFA_NO] ,a.[TYPE]  ,[ID] ,a.[NIK] ,[NAMA] ,a.[STS],e.unApp	FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  left join afa_jenis_urut b on b.jenis=a.type  left join [dbo].[User_Email] c on c.nik=a.nik  left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO  left join  [dbo].[User_H] e on e.UserID=a.nik where a.nik<>'' ) as aa  where 	 aa.NIK='" & userid & "' and aa.sts in ('App','Skip') and  aa.unApp='Y'	   ) x on x.AFA_NO=aa.AFA_NO where aa.No>x.No and aa.STS<>'Send'")
            tblgrid = Proses.ExecuteQuery("select aa.AFA_NO,aa.BUDGET_YEAR,aa.BUDGET_REV,aa.NOTETEXT Description,aa.Atth,aa.Type,'UnApp' " _
& " Jenis from(Select ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) As No, a.[AFA_NO]      ,[TYPE]      ,[ID]      ,a.[NIK]      ,[NAMA]      ,[JAB]   " _
& " ,a.[STS]    ,c.email	,d.BUDGET_YEAR	,d.BUDGET_REV	,d.NOTETEXT	,d.atth  FROM [AFASYS].[dbo].[AFA_SIGNATURE] a " _
& " left join afa_jenis_urut b On b.jenis=a.type  " _
& " left join [dbo].[User_Email] c on c.nik=a.nik  " _
& " left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO    where a.nik<>'' " _
& " and a.STS  in ('App','Skip') AND D.STS<>'Cancelled' " _
& " ) as aa	" _
& " left join (select aa.AFA_NO,max(aa.No) No from(SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No, a.[AFA_NO]   " _
& " ,[TYPE]      ,[ID]      ,a.[NIK]      ,[NAMA]      ,[JAB]      ,a.[STS]    ,c.email	,d.BUDGET_YEAR	,d.BUDGET_REV	,d.NOTETEXT	,d.atth	 " _
& " FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  " _
& " left join afa_jenis_urut b on b.jenis=a.type   " _
& " left join [dbo].[User_Email] c on c.nik=a.nik  " _
& " left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO  " _
& " where a.nik<>'' 	and a.STS  in ('App','Skip') AND D.STS='Planned' " _
& " ) as aa	group by aa.AFA_NO) bb on aa.AFA_NO=bb.AFA_NO	 " _
& " where aa.NIK='" & userid & "'	 " _
& " And  aa.no = bb.No And  aa.BUDGET_YEAR Is Not null " _
& " union all  " _
& " select distinct   aa.AFA_NO,aa.BUDGET_YEAR,aa.BUDGET_REV,CAST(aa.NOTETEXt  as varchar(8000)) Description, " _
& " (aa.Atth) Atth,'Dir' TYPE,'UnAppAll' Jenis  from(SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No,  " _
& " a.[AFA_NO]  ,[TYPE]  ,[ID]  ,a.[NIK]  ,[NAMA]  ,[JAB]  ,a.[STS] ,c.email,d.BUDGET_YEAR,d.BUDGET_REV,d.NOTETEXT,d.Atth " _
& " FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  " _
& " left join afa_jenis_urut b on b.jenis=a.type    " _
& " left join [dbo].[User_Email] c on c.nik=a.nik  " _
& " left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO  " _
& " where a.nik<>'' AND D.STS='Planned' ) as aa  " _
& " Left Join(select aa.No, aa.AFA_NO, aa.TYPE, aa.NIK from(Select ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc, id desc ) AS No, " _
& " a.[AFA_NO] ,a.[TYPE]  ,[ID] ,a.[NIK] ,[NAMA] ,a.[STS],e.unApp	FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  " _
& " left join afa_jenis_urut b on b.jenis=a.type  left join [dbo].[User_Email] c on c.nik=a.nik " _
& " left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO  left join  [dbo].[User_H] e on e.UserID=a.nik where a.nik<>''  AND D.STS='Planned') as aa  " _
& " where 	 aa.NIK='" & userid & "' and aa.sts in ('App','Skip') and  aa.unApp='Y') x on x.AFA_NO=aa.AFA_NO " _
& " where aa.No > x.No And aa.STS <>'Send' ")


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

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        lblPesan.Text = ""
        showdate()

    End Sub

    Private Sub DgView_Click(sender As Object, e As EventArgs) Handles DgView.Click
        ' Try
        lblafa.Text = DgView.SelectedCells(1).Value
        ' lbllink.Text = DgView.SelectedCells(5).Value


        BtmnViewDoc.Enabled = True

            If Trim(FormFluMenu.btnuserid.Caption) = "11111" Then
                btnNote.Visible = True
            Else
                btnNote.Visible = False
            End If

            cekbtnsave()
        '  Catch ex As Exception

        ' End Try

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
    Private Sub XtraFormApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtmnViewDoc.Enabled = False

        btnNote.Visible = False
        BtnSave.Enabled = False
    End Sub

    Private Sub CkAll_CheckedChanged(sender As Object, e As EventArgs) Handles CkAll.CheckedChanged
        cekall()
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

                            typee = "UNAPP"
                            prosess()

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

            Dim nik = Trim(FormFluMenu.btnuserid.Caption)

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

                If typee = "APP" And nik = "11111" Then
                    Commandku.CommandText = "AFA_App_AdminBudget_New_Proc"
                    Commandku.Parameters.AddWithValue("@usernamepc", user)
                ElseIf typee = "UNAPP" And appal = "UnAppAll" Then
                    Commandku.CommandText = "AFA_UnApp_DivHead_Proc"
                Else

                    Commandku.CommandText = "AFA_App_Proc"
                End If



                Commandku.Parameters.AddWithValue("@nik", nik)
                Commandku.Parameters.AddWithValue("@Afa", afa)
                Commandku.Parameters.AddWithValue("@jenis", Jenis)
                Commandku.Parameters.AddWithValue("@PC", shostname)
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

    Private Sub BtmnViewDoc_Click(sender As Object, e As EventArgs) Handles BtmnViewDoc.Click
        If Trim(lblafa.Text) = "" Then MsgBox("Please Double Click Afa first") : Exit Sub




        ' If Trim(lbllink.Text) <> "" Then

        ' Dim Y = Trim(FormFluMenu.btnlink.Caption) + "\"

        ' Dim curFile As String = "" & Y & "" & Trim(lbllink.Text) & ""
        '  If File.Exists(curFile) Then


        If Trim(FormFluMenu.btnlvl.Caption) = "APP" Then
                XtraFormAttch.TxtAfa.Text = Trim(lblafa.Text)
                XtraFormAttch.lblatth.Text = Trim(lbllink.Text)
                XtraFormAttch.AFAPdf()
                XtraFormAttch.openfile()
                XtraFormAttch.ShowDialog()

            Else
            XtraFormViewAfa.TxtAfa.Text = Trim(lblafa.Text)
            XtraFormViewAfa.lblatth.Text = Trim(lbllink.Text)
            XtraFormViewAfa.AFAPdf()
            XtraFormViewAfa.openfile()


            'XtraFormViewAFANew.TopLevel = False
            'XtraFormViewAFANew.Parent = FormFluMenu.PanelControl1
            'XtraFormViewAFANew.Dock = DockStyle.Fill
            XtraFormViewAfa.ShowDialog()
            XtraFormViewAfa.BringToFront()
            'XtraFormViewAFANew.BringToFront()
        End If



        ' XtraFormViewAFANew.ShowDialog()

        'Else
        '    MsgBox("Document not found in Server")

        'End If


    End Sub



    Private Sub btnNote_Click(sender As Object, e As EventArgs) Handles btnNote.Click
        If Trim(lblafa.Text) = "" Then MsgBox("Please choice AFA first !") : Exit Sub

        XtraFormSendNoteBudget.TxtAfa.Text = Trim(lblafa.Text)
        XtraFormSendNoteBudget.isitxt()
        XtraFormSendNoteBudget.showdata()
        XtraFormSendNoteBudget.ShowDialog()
    End Sub

    Private Sub DgView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgView.CellContentClick

    End Sub
End Class