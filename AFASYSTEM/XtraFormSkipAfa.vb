Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports System.Globalization
Imports System.IO
Public Class XtraFormSkipAfa
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2, tblgrid As DataTable

    Private Sub XtraFormSkipAfa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SplitContainer1.SplitterDistance = 242
        Catch ex As Exception

        End Try
        kodenikk()
        datacmbreason()
    End Sub
    Sub datacmbreason()

        tblDept = Proses.ExecuteQuery("SELECT distinct [Reason_Skip] FROM [AFASYS].[dbo].[AFA_Reason_Skip] order by [Reason_Skip] asc")

        If tblDept.Rows.Count = 0 Then
            CmbReason.Text = ""
            CmbReason.Items.Clear()
        Else
            CmbReason.Items.Clear()
            With tblDept.Columns(0)
                For a = 0 To tblDept.Rows.Count - 1
                    CmbReason.Items.Add(.Table.Rows(a).Item(0)) ' + ":" + .Table.Rows(a).Item(1))
                Next a
            End With
        End If

    End Sub
    Dim tblEmployee As DataTable

    Private Sub TxtAfa_TextChanged(sender As Object, e As EventArgs) Handles TxtAfa.TextChanged

    End Sub

    Dim tblLog As DataTable
    Dim CM As CurrencyManager

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Dispose()
    End Sub

    Sub kodenikk()

        tblLog = Proses.ExecuteQuery("SELECT distinct  a.[AFA_NO]      FROM [AFASYS].[dbo].[AFA_H] a WHERE  A.STS='Planned'")

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

    Private Sub DgView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgView.CellContentClick

    End Sub

    Sub isitxt()
        Dim afa = Trim(TxtAfa.Text)
        tblEmployee = Proses.ExecuteQuery("SELECT  a.[AFA_NO] ,isnull(a.atth,'') Atth     ,isnull([NOTETEXT],'') [NOTETEXT],[SCHEDULE],[STS]   ,AMT   FROM [AFASYS].[dbo].[AFA_H] a  where  a.AFA_NO='" & afa & "'")
        If tblEmployee.Rows.Count > 0 Then
            TxtSubject.Text = tblEmployee.Rows(0).Item("NOTETEXT").ToString

        Else
            TxtSubject.Text = ""

        End If

    End Sub

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        If Trim(TxtAfa.Text) <> "" Then
            CmbReason.Text = ""
            isitxt()
            showdate()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If Trim(CmbReason.Text) = "" Then MsgBox("Please, Choice Reason first") : Exit Sub
        skip()


    End Sub
    Sub skip()


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

        Commandku.CommandText = "AFA_SKIP_Budget_Proc"

        Dim afa = Trim(TxtAfa.Text)
        Dim typee = "APPBUDGET"
        Dim nik = Trim(lblnik.Text)
        Dim alasan = Trim(CmbReason.Text)
        Dim jenis = Trim(TxtType.Text)

        Commandku.Parameters.AddWithValue("@nik", Trim(nik))
        Commandku.Parameters.AddWithValue("@AFA", Trim(afa))
        Commandku.Parameters.AddWithValue("@Jenis", Trim(jenis))
        Commandku.Parameters.AddWithValue("@Reason", Trim(alasan))
        Commandku.Parameters.AddWithValue("@PC", Trim(shostname))
        Commandku.Parameters.AddWithValue("@tYPE", Trim(typee))


        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output

        Dim outParamSts As SqlClient.SqlParameter =
      Commandku.Parameters.Add("@Sts_", SqlDbType.VarChar, 100)
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
    Sub showdate()
        Dim afa = Trim(TxtAfa.Text)
        tblgrid = Proses.ExecuteQuery("SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No,[TYPE],a.[NIK],[NAMA],[JAB],a.[STS],isnull(a.reason,'') Reason FROM [AFASYS].[dbo].[AFA_SIGNATURE] a left join afa_jenis_urut b on b.jenis=a.type  left join [dbo].[User_Email] c on c.nik=a.nik  left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO    where a.nik<>'' and b.Jenis<>'Budget'	and a.AFA_NO='" & afa & "'")


        If tblgrid.Rows.Count = 0 Then
            DgView.DataSource = Nothing
        Else
            DgView.ClearSelection()

            DgView.DataSource = tblgrid
            DgView.Columns(0).Width = 40
            DgView.Columns(1).Width = 80
            DgView.Columns(2).Width = 80
            DgView.Columns(3).Width = 200
            DgView.Columns(4).Width = 150
            DgView.Columns(5).Width = 100
            DgView.Columns(6).Width = 200
        End If


    End Sub
    Private Sub TxtAfa_LostFocus(sender As Object, e As EventArgs) Handles TxtAfa.LostFocus
        If Trim(TxtAfa.Text) <> "" Then
            isitxt()
            showdate()
        End If

    End Sub

    Private Sub XtraFormSkipAfa_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            SplitContainer1.SplitterDistance = 242
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DgView_DoubleClick(sender As Object, e As EventArgs) Handles DgView.DoubleClick
        TxtType.Text = DgView.SelectedCells(1).Value
        Txtniknama.Text = DgView.SelectedCells(2).Value.ToString + " / " + DgView.SelectedCells(3).Value.ToString
        lblnik.Text = DgView.SelectedCells(2).Value.ToString
    End Sub
End Class