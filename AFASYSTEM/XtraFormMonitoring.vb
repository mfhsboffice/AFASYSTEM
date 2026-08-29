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

Public Class XtraFormMonitoring
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2 As DataTable
    Dim tblEmployee As DataTable

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        If ROnprog.Checked = True And RApp.Checked = False And RAppIFS.Checked = False And RCancel.Checked = False Then
            showdata()
        ElseIf ROnprog.Checked = False And RApp.Checked = True And RAppIFS.Checked = False And RCancel.Checked = False Then
            showdataDone()
        ElseIf ROnprog.Checked = False And RApp.Checked = False And RAppIFS.Checked = True And RCancel.Checked = False Then
            showdataDoneIFS()
        ElseIf ROnprog.Checked = False And RApp.Checked = False And RAppIFS.Checked = False And RCancel.Checked = True Then
            showdataCancelIFS()
        End If

    End Sub

    Private Sub XtraFormMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Trim(FormFluMenu.btnlvl.Caption) = "FINANCE" Then
            ROnprog.Visible = False
            RApp.Visible = False
            RAppIFS.Visible = True
            RAppIFS.Checked = True
            lblapaa.Visible = True
            TXTAFANO.Visible = True
        Else
            ROnprog.Visible = True
            RApp.Visible = True
            RAppIFS.Visible = True
            lblapaa.Visible = False
            TXTAFANO.Visible = False
            showdata()
        End If


        BtmnViewDoc.Enabled = False
        Try
            SplitContainer1.SplitterDistance = 52
        Catch ex As Exception

        End Try
    End Sub

    Dim tblLog As DataTable

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Sub cek()
        If ROnprog.Checked = True And RApp.Checked = False And RAppIFS.Checked = False Then
            lblapaa.Visible = False
            TXTAFANO.Visible = False
            GridControl1.DataSource = Nothing
        ElseIf ROnprog.Checked = False And RApp.Checked = True And RAppIFS.Checked = False Then
            lblapaa.Visible = False
            TXTAFANO.Visible = False
            GridControl1.DataSource = Nothing
        ElseIf ROnprog.Checked = False And RApp.Checked = False And RAppIFS.Checked = True Then
            lblapaa.Visible = True
            TXTAFANO.Visible = True
            kodenikk()
            GridControl1.DataSource = Nothing
        End If
    End Sub
    Sub kodenikk()
        Dim USERID = Trim(FormFluMenu.btnuserid.Caption)

        If Trim(FormFluMenu.btnlvl.Caption) = "FINANCE" Then
            tblLog = Proses.ExecuteQuery("SELECT distinct a.[AFA_NO] FROM [AFASYS].[dbo].[AFA_H] a left join  [dbo].[AFA_SIGNATURE] b on b.AFA_NO=a.AFA_NO where A.STS='Approved' order by a.AFA_NO asc")
        ElseIf Trim(FormFluMenu.btnlvl.Caption) = "BUDGET ADMIN" Then
            tblLog = Proses.ExecuteQuery("SELECT distinct a.[AFA_NO] FROM [AFASYS].[dbo].[AFA_H] a left join  [dbo].[AFA_SIGNATURE] b on b.AFA_NO=a.AFA_NO where A.STS='Approved' order by a.AFA_NO asc")

        Else
            tblLog = Proses.ExecuteQuery("SELECT distinct a.[AFA_NO] FROM [AFASYS].[dbo].[AFA_H] a left join  [dbo].[AFA_SIGNATURE] b on b.AFA_NO=a.AFA_NO where A.STS='Approved' and b.nik='" & USERID & "' order by a.AFA_NO asc")

        End If


        If tblLog.Rows.Count = 0 Then

        Else

            Dim col As New AutoCompleteStringCollection
            Dim i As Integer
            For i = 0 To tblLog.Rows.Count - 1
                col.Add(tblLog.Rows(i).Item(0).ToString())
            Next
            TXTAFANO.AutoCompleteSource = AutoCompleteSource.CustomSource
            TXTAFANO.AutoCompleteCustomSource = col
            TXTAFANO.AutoCompleteMode = AutoCompleteMode.Suggest

        End If
    End Sub
    Dim CM As CurrencyManager
    Sub showdata()
        Dim nik = Trim(FormFluMenu.btnuserid.Caption)
        ' tblDept = Proses.ExecuteQuery("select aa.AFA_NO,aa.NOTETEXT Description,'Not yet Approve by '+aa.NAMA Progress ,isnull(convert(varchar(12),cc.DATEAPP,113),'') + ' '+substring(convert(varchar(20),cc.DATEAPP,100),12,8) DateApp from( SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No, a.[AFA_NO],[TYPE],[ID] ,a.[NIK],[NAMA],[JAB],a.[STS],c.email,d.BUDGET_YEAR	,d.BUDGET_REV	,d.NOTETEXT  FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  left join afa_jenis_urut b on b.jenis=a.type    left join [dbo].[User_Email] c on c.nik=a.nik  left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO      where a.nik<>'' 	and a.STS='Send' and d.STS<>'Cancelled'	) as aa		left join [AFASYS].[dbo].[AFA_SIGNATURE] bb on bb.AFA_NO=aa.AFA_NO		left join [AFASYS].[dbo].[AFA_SIGNATURE] cc on cc.AFA_NO=aa.AFA_NO and cc.NIK='" & nik & "'	 where aa.no='1'	 and bb.NIK='" & nik & "' order by aa.NAMA asc")

        tblDept = Proses.ExecuteQuery("select aa.AFA_NO, substring(REPLACE(REPLACE(REPLACE(substring(aa.NOTETEXT,1,500), CHAR(10), ''), CHAR(13), ''), CHAR(13) + CHAR(10), ''),1,500)   Description,'Not yet Approve by '+aa.NAMA Progress ,isnull(t.Remark,'') Remark,isnull(convert(varchar(12),cc.DATEAPP,113),'') + ' '+isnull(substring(convert(varchar(20),cc.DATEAPP,100),12,8),'') DateApp,CASE WHEN StsEmail='Send' then 'Checked' else '' end Status_Budget from( SELECT ROW_NUMBER() OVER(PARTITION BY a.[AFA_NO] order by b.urut asc,id desc ) AS No, a.[AFA_NO],[TYPE],[ID] ,a.[NIK],[NAMA],[JAB],a.[STS],c.email,d.BUDGET_YEAR	,d.BUDGET_REV	,d.NOTETEXT,D.StsEmail  FROM [AFASYS].[dbo].[AFA_SIGNATURE] a  left join afa_jenis_urut b on b.jenis=a.type    left join [dbo].[User_Email] c on c.nik=a.nik  left join [dbo].[AFA_H] d on d.AFA_NO=a.AFA_NO    where a.nik<>'' 	and a.STS='Send' and d.STS<>'Cancelled'	) as aa		left join [AFASYS].[dbo].[AFA_SIGNATURE] bb on bb.AFA_NO=aa.AFA_NO		left join [AFASYS].[dbo].[AFA_SIGNATURE] cc on cc.AFA_NO=aa.AFA_NO and cc.NIK='" & nik & "'	left join (select a.AFA_NO,a.NIKPenanya,max(a.remark) remark from V_Tanya a group by a.AFA_NO,a.NIKPenanya) t on t.afa_no=aa.AFA_NO and t.nikpenanya=aa.NIK where aa.no='1'	 and bb.NIK='" & nik & "' order by aa.NAMA asc")


        If tblDept.Rows.Count = 0 Then
            GridControl1.DataSource = Nothing

        Else

            GridControl1.DataSource = tblDept


            Dim gridView1 As GridView = TryCast(GridControl1.MainView, GridView)

            'gridView1.OptionsSelection.MultiSelect = True
            'gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect



            ' Obtain created columns.
            Dim colafa As GridColumn = gridView1.Columns("AFA_NO")
            Dim coldes As GridColumn = gridView1.Columns("Description")
            Dim colprog As GridColumn = gridView1.Columns("Progress")
            Dim colrem As GridColumn = gridView1.Columns("Remark")
            Dim coldateapp As GridColumn = gridView1.Columns("DateApp")



            colafa.Width = 150
            coldes.Width = 300
            colprog.Width = 150
            colrem.Width = 200
            coldateapp.Width = 150

            ' Make the grid read-only.
            gridView1.OptionsBehavior.Editable = False
            ' Prevent the focused cell from being highlighted.
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            ' Draw a dotted focus rectangle around the entire row.
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

        End If
    End Sub



    Private Sub HistoryAFA_Click(sender As Object, e As EventArgs)
        FormFluMenu.mnhistory()
    End Sub
    Private Sub gridView1_ShowGridMenu(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs) Handles GridView1.ShowGridMenu
        Dim view As GridView = TryCast(sender, GridView)
        e.Menu.Items.Clear()
        e.Menu.Items.Add(New DXMenuItem(view.GetRowCellValue(view.FocusedRowHandle, view.FocusedColumn).ToString()))

    End Sub


    Sub isitext()
        lblafa.Text = GridView1.Columns.View.GetFocusedRowCellValue("AFA_NO").ToString

        BtmnViewDoc.Enabled = True
    End Sub

    Sub showdataCancelIFS()
        GridControl1.DataSource = Nothing

        Dim nik = Trim(FormFluMenu.btnuserid.Caption)
        tblDept = Proses.ExecuteQuery("SELECT a.[AFA_NO] , substring(REPLACE(REPLACE(REPLACE(substring(NOTETEXT,1,500), CHAR(10), ''), CHAR(13), ''), CHAR(13) + CHAR(10), ''),1,500) Description,'Cancelled' Progress FROM [AFASYS].[dbo].[AFA_H] a left join [dbo].[AFA_SIGNATURE] b on b.AFA_NO=a.AFA_NO WHERE  a.STS='Cancelled' and b.NIK='" & nik & "'")






        If tblDept.Rows.Count = 0 Then
            GridControl1.DataSource = Nothing

        Else

            GridControl1.DataSource = tblDept

            Dim gridView1 As GridView = TryCast(GridControl1.MainView, GridView)

            ' Obtain created columns.
            Dim colafa As GridColumn = gridView1.Columns("AFA_NO")
            Dim coldes As GridColumn = gridView1.Columns("Description")
            Dim colprog As GridColumn = gridView1.Columns("Progress")
            '  Dim coldateapp As GridColumn = gridView1.Columns("DateApp")






            colafa.Width = 150
            coldes.Width = 300
            '  colprog.Width = 150



        End If
    End Sub

    Sub showdataDoneIFS()
        Dim nik = Trim(FormFluMenu.btnuserid.Caption)
        If Trim(FormFluMenu.btnlvl.Caption) = "FINANCE" Then
            tblDept = Proses.ExecuteQuery("SELECT a.[AFA_NO] , substring(REPLACE(REPLACE(REPLACE(substring(NOTETEXT,1,500), CHAR(10), ''), CHAR(13), ''), CHAR(13) + CHAR(10), ''),1,500)Description,'Approved' Progress,isnull(isnull(convert(varchar(12),a.AFA_APPROVAL_DATE,113),'') + ' '+substring(convert(varchar(20),a.AFA_APPROVAL_DATE,100),12,8),'') DateApp FROM [AFASYS].[dbo].[AFA_H] a WHERE  a.STS='Approved' and a.AFA_NO like '" & Trim(TXTAFANO.Text) & "'")
        ElseIf Trim(FormFluMenu.btnlvl.Caption) = "BUDGET ADMIN" Then
            tblDept = Proses.ExecuteQuery("SELECT a.[AFA_NO] , substring(REPLACE(REPLACE(REPLACE(substring(NOTETEXT,1,500), CHAR(10), ''), CHAR(13), ''), CHAR(13) + CHAR(10), ''),1,500) Description,'Approved' Progress,isnull(isnull(convert(varchar(12),a.AFA_APPROVAL_DATE,113),'') + ' '+substring(convert(varchar(20),a.AFA_APPROVAL_DATE,100),12,8),'') DateApp FROM [AFASYS].[dbo].[AFA_H] a WHERE  a.STS='Approved' and a.AFA_NO like '" & Trim(TXTAFANO.Text) & "'")

        Else
            tblDept = Proses.ExecuteQuery("SELECT a.[AFA_NO] , substring(REPLACE(REPLACE(REPLACE(substring(NOTETEXT,1,500), CHAR(10), ''), CHAR(13), ''), CHAR(13) + CHAR(10), ''),1,500) Description,'Approved' Progress, isnull(isnull(convert(varchar(12),a.AFA_APPROVAL_DATE,113),'') + ' '+substring(convert(varchar(20),a.AFA_APPROVAL_DATE,100),12,8),'') DateApp FROM [AFASYS].[dbo].[AFA_H] a left join  [dbo].[AFA_SIGNATURE] b on b.AFA_NO=a.AFA_NO  left join [AFASYS].[dbo].[AFA_SIGNATURE] cc on cc.AFA_NO=a.AFA_NO and cc.NIK='" & nik & "' where a.AFA_NO not in (select distinct  AFA_No from [dbo].[AFA_SIGNATURE] a where a.sts='Send')  and b.nik='" & nik & "'  and a.AFA_NO like '" & Trim(TXTAFANO.Text) & "' ")

        End If



        If tblDept.Rows.Count = 0 Then
            GridControl1.DataSource = Nothing

        Else

            GridControl1.DataSource = tblDept

            Dim gridView1 As GridView = TryCast(GridControl1.MainView, GridView)

            ' Obtain created columns.
            Dim colafa As GridColumn = gridView1.Columns("AFA_NO")
            Dim coldes As GridColumn = gridView1.Columns("Description")
            Dim colprog As GridColumn = gridView1.Columns("Progress")
            Dim coldateapp As GridColumn = gridView1.Columns("DateApp")
            '   Dim COLAPPNEW As GridColumn = gridView1.Columns("AFA_APPROVAL_DATE")


            colafa.Width = 150
            coldes.Width = 500
            colprog.Width = 150
            coldateapp.Width = 150

            '  coldes.CellStyle.Wrap = DefaultBoolean.False


        End If
    End Sub

    Sub showdataDone()
        Dim nik = Trim(FormFluMenu.btnuserid.Caption)
        tblDept = Proses.ExecuteQuery("SELECT a.[AFA_NO] , substring(REPLACE(REPLACE(REPLACE(substring(NOTETEXT,1,500), CHAR(10), ''), CHAR(13), ''), CHAR(13) + CHAR(10), ''),1,500) Description,'Approved' Progress  ,isnull(convert(varchar(12),cc.DATEAPP,113),'') + ' '+substring(convert(varchar(20),cc.DATEAPP,100),12,8) DateApp FROM [AFASYS].[dbo].[AFA_H] a left join  [dbo].[AFA_SIGNATURE] b on b.AFA_NO=a.AFA_NO left join [AFASYS].[dbo].[AFA_SIGNATURE] cc on cc.AFA_NO=a.AFA_NO and cc.NIK='" & nik & "'	 where a.AFA_NO not in (select distinct  AFA_No from [dbo].[AFA_SIGNATURE] a where a.sts='Send')    and b.nik='" & nik & "' and a.sts='Planned'")



        If tblDept.Rows.Count = 0 Then
            GridControl1.DataSource = Nothing

        Else

            GridControl1.DataSource = tblDept

            Dim gridView1 As GridView = TryCast(GridControl1.MainView, GridView)

            ' Obtain created columns.
            Dim colafa As GridColumn = gridView1.Columns("AFA_NO")
            Dim coldes As GridColumn = gridView1.Columns("Description")
            Dim colprog As GridColumn = gridView1.Columns("Progress")
            Dim coldateapp As GridColumn = gridView1.Columns("DateApp")



            colafa.Width = 150
            coldes.Width = 500
            colprog.Width = 150
            coldateapp.Width = 150

            '  coldes.CellStyle.Wrap = DefaultBoolean.False


        End If
    End Sub

    Private Sub BtmnViewDoc_Click(sender As Object, e As EventArgs) Handles BtmnViewDoc.Click
        If Trim(lblafa.Text) = "" Then MsgBox("Please Double Click Afa first") : Exit Sub



        If Trim(FormFluMenu.btnlvl.Caption) = "APP" Then
            XtraFormAttch.TxtAfa.Text = Trim(lblafa.Text)
            ' XtraFormAttch.lblatth.Text = Trim(lbllink.Text)
            XtraFormAttch.AFAPdf()
            XtraFormAttch.openfile()
            XtraFormAttch.ShowDialog()
        Else
            XtraFormViewAfa.TxtAfa.Text = Trim(lblafa.Text)
            ''XtraFormViewAFA.lblatth.Text = Trim(lbllink.Text)
            XtraFormViewAfa.AFAPdf()
            XtraFormViewAfa.openfile()



            'XtraFormViewAFANew.TopLevel = False
            'XtraFormViewAFANew.Parent = FormFluMenu.PanelControl1
            'XtraFormViewAFANew.Dock = DockStyle.Fill
            '
            XtraFormViewAfa.ShowDialog()
            XtraFormViewAfa.BringToFront()
            'XtraFormViewAFANew.BringToFront()
        End If
    End Sub

    Private Sub ROnprog_CheckedChanged(sender As Object, e As EventArgs) Handles ROnprog.CheckedChanged
        cek()
    End Sub

    Private Sub RApp_CheckedChanged(sender As Object, e As EventArgs) Handles RApp.CheckedChanged
        cek()
    End Sub

    Private Sub RAppIFS_CheckedChanged(sender As Object, e As EventArgs) Handles RAppIFS.CheckedChanged
        cek()
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click
        isitext()
    End Sub

    Private Sub XtraFormMonitoring_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            SplitContainer1.SplitterDistance = 52
        Catch ex As Exception

        End Try
    End Sub


    Private Sub GridView1_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)

        ' Dim view As GridView = TryCast(sender, GridView)
        'Dim _mark As Boolean = CBool(view.GetRowCellValue(e.RowHandle, "Mark"))
        'If e.Column.FieldName = "Name" Then
        '    e.Appearance.BackColor = If(_mark, Color.LightGreen, Color.LightSalmon)
        '    e.Appearance.TextOptions.HAlignment = If(_mark, HorzAlignment.Far, HorzAlignment.Near)
        'End If


        'Dim category As String = view.GetRowCellDisplayText(e.RowHandle, view.Columns("App1"))

        'If (e.RowHandle >= 0) Then

        '    If Microsoft.VisualBasic.Right(category, 3) = "App" Then
        '        e.Appearance.BackColor = Color.Salmon
        '        e.Appearance.BackColor2 = Color.SeaShell
        '        e.HighPriority = True


        '    End If
        'End If



    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        isitext()
    End Sub


End Class