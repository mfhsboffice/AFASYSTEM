Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports System.Globalization
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Public Class XtraFormAFAHistory
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2, tblgrid As DataTable
    Private Sub XtraFormAFAHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub data()
        Dim shostname As String
        shostname = System.Net.Dns.GetHostName
        Dim user = Trim(FormFluMenu.btnuserid.Caption)
        Dim afa = Trim(lblafa.Text)

        tblDept = Proses.ExecuteQuery("SELECT isnull(convert(varchar(12), [DATEAPP], 13),'') +' ' + isnull(substring(convert(varchar, [DATEAPP], 9),13,15),'')  Logtime   ,[NAMA]  + ' , Position = '+ Jab Approver    ,case when [STS]='Send' then 'Not Yet' when [STS]='App' then 'Approved' else a.sts end +' ' +isnull([Reason],'') State FROM [AFASYS].[dbo].[AFA_SIGNATURE]  a  left join [dbo].[AFA_Jenis_Urut] b on b.Jenis=a.TYPE  where a.AFA_NO='" & afa & "' and   a.nik<>''  order by b.urut asc,a.ID desc")



        If tblDept.Rows.Count = 0 Then
            GridControl1.DataSource = Nothing

        Else

            GridControl1.DataSource = tblDept

            Dim gridView1 As GridView = TryCast(GridControl1.MainView, GridView)

            ' Obtain created columns.
            Dim collogtime As GridColumn = gridView1.Columns("Logtime")
            Dim colapp As GridColumn = gridView1.Columns("Approver")
            Dim colstate As GridColumn = gridView1.Columns("State")


            collogtime.Width = 110
            colapp.Width = 180
            colstate.Width = 180
            gridView1.Appearance.Row.Font = New Font("Tahoma", 12)



        End If

    End Sub
End Class