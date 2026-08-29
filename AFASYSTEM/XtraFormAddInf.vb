Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports System.Globalization
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils.Menu

Public Class XtraFormAddInf
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2, tblgrid As DataTable

    Private Sub XtraFormAddInf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbTo()
        Try
            SplitContainer1.SplitterDistance = 330
            TxtQuestA.Clear()
            txtfromA.Clear()
            TabControl1.SelectedTab = TabPage1
        Catch ex As Exception

        End Try
    End Sub

    Dim tblEmployee As DataTable
    Private Function GetNthIndex(s As String, t As Char, n As Integer) As Integer
        Dim count As Integer = 0
        For i = 0 To s.Length - 1
            If s(i) = t Then
                count += 1
                If count = n Then
                    Return i
                End If
            End If
        Next
        Return -1
    End Function
    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        SUBMITTANYA()
    End Sub
    Sub SUBMITTANYA()
        If Trim(txtquest.Text) = "" Then MsgBox("Question not found") : Exit Sub
        If Trim(cmbtoQ.Text) = "" Then MsgBox("Who are you asking?") : Exit Sub

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

        Commandku.CommandText = "AFA_ASKING_Proc"

        Dim afa = Trim(TxtAfa.Text)
        Dim nikp = Trim(FormFluMenu.btnuserid.Caption)
        Dim id = Val(lblidQ.Text)
        Dim pertanyaan = Trim(txtquest.Text)
        Dim nikditanya = Trim(lblnikQ.Text)
        Dim tipo = "I"
        Commandku.Parameters.AddWithValue("@AFA_NO", Trim(afa))
        Commandku.Parameters.AddWithValue("@nikP", Trim(nikp))
        Commandku.Parameters.AddWithValue("@ID", Trim(id))
        Commandku.Parameters.AddWithValue("@Pertanyaan", Trim(pertanyaan))
        Commandku.Parameters.AddWithValue("@nikditanya", Trim(nikditanya))
        Commandku.Parameters.AddWithValue("@PC", Trim(shostname))
        Commandku.Parameters.AddWithValue("@tYPE", Trim(tipo))



        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output

        Dim outParamSts As SqlClient.SqlParameter =
      Commandku.Parameters.Add("@STS_", SqlDbType.VarChar, 100)
        outParamSts.Direction = ParameterDirection.Output




        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If outParam.Value = "OK" Then
            data()
            MsgBox(outParamSts.Value.ToString)

        ElseIf outParam.Value = "NOTOK" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()


    End Sub
    Private edit As RepositoryItemMemoEdit
    Public Sub New()
        InitializeComponent()

        edit = New RepositoryItemMemoEdit()
        GridControl1.RepositoryItems.Add(edit)
    End Sub
    Private Sub gridView1_CustomRowCellEdit(ByVal sender As Object, ByVal e As CustomRowCellEditEventArgs) Handles GridView1.CustomRowCellEdit
        If e.Column.FieldName = "Question" Or e.Column.FieldName = "Answer" Then
            e.RepositoryItem = edit
        End If

        'AndAlso e.RowHandle = 0
    End Sub
    Private Sub gridView1_ShowGridMenu(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs) Handles GridView1.ShowGridMenu
        Dim view As GridView = TryCast(sender, GridView)
        e.Menu.Items.Clear()
        e.Menu.Items.Add(New DXMenuItem(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString()))

    End Sub
    Sub data()
        Dim shostname As String
        shostname = System.Net.Dns.GetHostName
        Dim user = Trim(FormFluMenu.btnuserid.Caption)
        Dim afa = Trim(TxtAfa.Text)

        tblDept = Proses.ExecuteQuery("SELECT a.[ID]          ,[Namapenanya] Question_From      ,[Pertanyaan] Question      ,convert(varchar(17),[TglTanya],113) [Time_Question]   ,a.NamaDitanya [Question_To]   ,isnull(NamaJawab,'') Answer_By      ,isnull([Jawaban],'') Answer      ,isnull(convert(varchar(17),[TglJawab],113),'')  Time_Answer  FROM [AFASYS].[dbo].[AFA_Asking] a  left join [dbo].[AFA_ANSWER] b on b.afa_no=a.AFA_NO and a.id=b.id where a.AFA_NO='" & afa & "'    order by a.id,b.[IDJAwab] asc")



        If tblDept.Rows.Count = 0 Then
            GridControl1.DataSource = Nothing

        Else

            GridControl1.DataSource = tblDept

            Dim gridView1 As GridView = TryCast(GridControl1.MainView, GridView)

            ' Obtain created columns.
            Dim ColID As GridColumn = gridView1.Columns("ID")
            Dim ColPenanya As GridColumn = gridView1.Columns("Question_From")
            Dim Colpertanyaan As GridColumn = gridView1.Columns("Question")
            Dim coltimetanya As GridColumn = gridView1.Columns("[Time_Question]")
            Dim coltanyake As GridColumn = gridView1.Columns("[Question_To]")
            Dim coljawab As GridColumn = gridView1.Columns("Answer_By")
            Dim coljawaban As GridColumn = gridView1.Columns("Answer")
            Dim colwktjawab As GridColumn = gridView1.Columns("Time_Answer")

            ColID.Visible = False
            ColPenanya.Width = 110
            Colpertanyaan.Width = 180
            coljawaban.Width = 180
            gridView1.Appearance.Row.Font = New Font("Tahoma", 12)

            gridView1.OptionsView.ColumnAutoWidth = True

            ' Make the grid read-only.
            gridView1.OptionsBehavior.Editable = False
            ' Prevent the focused cell from being highlighted.
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = True
            ' Draw a dotted focus rectangle around the entire row.
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

        End If

    End Sub

    Sub isinikditanya()
        Dim nm = Trim(cmbtoQ.Text)
        tblDept = Proses.ExecuteQuery("SELECT  [UserID]    ,[Name] FROM [AFASYS].[dbo].[User_H] where [Name]='" & nm & "'")
        If tblDept.Rows.Count > 0 Then
            lblnikQ.Text = Trim(tblDept.Rows(0).Item("Userid").ToString)
        End If
    End Sub
    Dim tblLog As DataTable

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        lblidpertanyaandijawaban.Text = GridView1.Columns.View.GetFocusedRowCellValue("ID").ToString
        txtfromA.Text = GridView1.Columns.View.GetFocusedRowCellValue("Question_From").ToString
        TxtQuestA.Text = GridView1.Columns.View.GetFocusedRowCellValue("Question").ToString
        TabControl1.SelectedTab = TabPage2
    End Sub
    Dim CM As CurrencyManager

    Private Sub btnSumAnswer_Click(sender As Object, e As EventArgs) Handles btnSumAnswer.Click
        submitjawab()
    End Sub
    Sub submitjawab()
        If Trim(txtAnswer.Text) = "" Then MsgBox("Answer not found") : Exit Sub

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

        Commandku.CommandText = "AFA_ANSWER_Proc"

        Dim afa = Trim(TxtAfa.Text)
        Dim nikjawab = Trim(FormFluMenu.btnuserid.Caption)
        Dim id = Val(lblidpertanyaandijawaban.Text)
        Dim jawaban = Trim(txtAnswer.Text)

        Dim tipo = "I"

        Dim idjawab = Trim(lblidjawab.Text)
        Commandku.Parameters.AddWithValue("@AFA_NO", Trim(afa))
        Commandku.Parameters.AddWithValue("@ID", Trim(id))
        Commandku.Parameters.AddWithValue("@IDJawab", Trim(idjawab))
        Commandku.Parameters.AddWithValue("@nikjawab", Trim(nikjawab))
        Commandku.Parameters.AddWithValue("@Jawaban", Trim(jawaban))
        Commandku.Parameters.AddWithValue("@PC", Trim(shostname))
        Commandku.Parameters.AddWithValue("@tYPE", Trim(tipo))



        '  MsgBox(Encrypt(Trim(TxtPassword.Text)))

        Dim outParam As SqlClient.SqlParameter =
        Commandku.Parameters.Add("@Message", SqlDbType.VarChar, 60)
        outParam.Direction = ParameterDirection.Output

        Dim outParamSts As SqlClient.SqlParameter =
      Commandku.Parameters.Add("@STS_", SqlDbType.VarChar, 100)
        outParamSts.Direction = ParameterDirection.Output




        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If outParam.Value = "OK" Then
            data()
            MsgBox(outParamSts.Value.ToString)

        ElseIf outParam.Value = "NOTOK" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()


    End Sub
    Sub cmbTo()
        Dim NIKME = Trim(FormFluMenu.btnuserid.Caption)
        Dim AFA = Trim(TxtAfa.Text)
        tblSect = Proses.ExecuteQuery("SELECT A.NIK,B.Name  FROM [AFASYS].[dbo].[AFA_SIGNATURE] A  LEFT JOIN [dbo].[User_H] B ON B.UserID=A.NIK   WHERE A.AFA_NO='" & AFA & "' AND B.Name IS NOT NULL AND A.NIK <>'" & NIKME & "'")

        If tblSect.Rows.Count = 0 Then
        Else
            cmbtoQ.Items.Clear()
            With tblSect.Columns(0)
                For a = 0 To tblSect.Rows.Count - 1
                    cmbtoQ.Items.Add(.Table.Rows(a).Item(1))
                Next a
            End With
        End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub txtAnswer_TextChanged(sender As Object, e As EventArgs)

        txtAnswer.SelectionStart = txtAnswer.Text.Length
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Dispose()
    End Sub

    Private Sub cmbtoQ_TextChanged(sender As Object, e As EventArgs) Handles cmbtoQ.TextChanged
        isinikditanya()
    End Sub



    Private Sub XtraFormAddInf_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            SplitContainer1.SplitterDistance = 330
        Catch ex As Exception

        End Try
    End Sub


End Class