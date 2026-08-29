Imports System.IO
Imports System
Imports System.Drawing.Bitmap
Imports Excel = Microsoft.Office.Interop.Excel
Imports DevExpress.Spreadsheet
Imports System.ComponentModel

Public Class XtraFormViewAFANew
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblKaizen, tblOTControl2, tblgrid As DataTable
    Dim tblEmployee As DataTable



    Dim tblLog As DataTable
    Dim CM As CurrencyManager
    Private Sub XtraFormViewAFANew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnShowHide.Text = "Hide AFA"
        btnShowHide.Visible = False
        Try
            SplitContainer1.SplitterDistance = 45
            SplitContainer2.SplitterDistance = 900
            cekattch()
            cekuserbudget()

        Catch ex As Exception

        End Try
    End Sub
    Sub cekuserbudget()
        Try
            If Trim(FormFluMenu.btnuserid.Caption) = "11111" Then


                tblOTControl2 = Proses.ExecuteQuery("SELECT       [StsEmail]      ,[DateSendEmail]  FROM [AFASYS].[dbo].[AFA_H] where AFA_NO='" & Trim(TxtAfa.Text) & "' and isnull([StsEmail],'')=''")

                If tblOTControl2.Rows.Count = 0 Then
                    btncekbudget.Visible = False
                Else

                    btncekbudget.Visible = True
                End If
            Else
                btncekbudget.Visible = False
            End If
        Catch ex As Exception
            btncekbudget.Visible = False
        End Try

    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Try

        Catch ex As Exception

        End Try
        Me.Dispose()
    End Sub
    Sub cekattch()
        tblLog = Proses.ExecuteQuery("SELECT [AFA_NO],isnull(atth,'') Atth1,isnull(atth2,'') Atth2,isnull(AccOwner,'') AccOwner    FROM [AFASYS].[dbo].[AFA_H] where AFA_NO='" & Trim(TxtAfa.Text) & "'")

        If tblLog.Rows.Count > 0 Then
            If Trim(tblLog.Rows(0).Item(1).ToString) = "" Then
                btnView.Enabled = False
            Else
                btnView.Enabled = True
            End If

            If Trim(tblLog.Rows(0).Item(2).ToString) = "" Then
                btnView2.Enabled = False
            Else
                btnView2.Enabled = True
            End If
            If Trim(tblLog.Rows(0).Item(3).ToString) = "" Then
                BtnViewAccOwner.Enabled = False
            Else
                BtnViewAccOwner.Enabled = True
            End If
        End If
    End Sub
    Sub isiattch()
        tblLog = Proses.ExecuteQuery("SELECT [AFA_NO],atth      FROM [AFASYS].[dbo].[AFA_H] where AFA_NO='" & Trim(TxtAfa.Text) & "'")

        If tblLog.Rows.Count > 0 Then
            lblatth.Text = Trim(tblLog.Rows(0).Item(1).ToString)

            viewer()
        Else
            lblatth.Text = ""

        End If
    End Sub
    Sub isiattch2()
        tblLog = Proses.ExecuteQuery("SELECT [AFA_NO],atth2      FROM [AFASYS].[dbo].[AFA_H] where AFA_NO='" & Trim(TxtAfa.Text) & "'")

        If tblLog.Rows.Count > 0 Then
            lblatth2.Text = Trim(tblLog.Rows(0).Item(1).ToString)

            viewer2()
        Else
            lblatth2.Text = ""

        End If
    End Sub
    Sub viewer2()
        Try
            If Trim(lblatth2.Text) <> "" Then

                Dim Y = Trim(FormFluMenu.btnlink.Caption) + "\"
                Shell("net use " & Y & " /USER:surindo\missoft M1spassword!", AppWinStyle.Hide, True, 10000)
                Dim curFile As String = "" & Y & "" & Trim(lblatth2.Text) & ""
                '  If File.Exists(curFile) Then
                Dim x As String = "" & Y & "" & Trim(lblatth2.Text) & ""

                Try
                    'AxAcroPDF2.src = x

                    'Dim stream As New FileStream("" & x & "", FileMode.Open)
                    'PdfViewer1.LoadDocument(stream)
                    'PdfViewer1.DetachStreamAfterLoadComplete = True

                    Cursor = Cursors.WaitCursor
                    Try

                        '  PdfViewer1.LoadDocument(x)

                        AxAcroPDF1.Refresh()
                        AxAcroPDF1.src = x
                    Catch exception As Exception
                        MessageBox.Show(exception.Message)
                    Finally
                        Cursor = Cursors.[Default]
                    End Try


                    btnShowHide.Visible = True
                Catch Exception As Exception
                    MessageBox.Show(Exception.Message)
                Finally
                    Cursor = Cursors.[Default]
                End Try



            End If
        Catch ex As Exception

        End Try



    End Sub
    Sub viewer()
        Try
            If Trim(lblatth.Text) <> "" Then


                Dim xx = Trim(FormFluMenu.btnlink.Caption) + "\"
                Shell("net use " & xx & " /USER:surindo\missoft M1spassword!", AppWinStyle.Hide, True, 10000)
                Shell("net use " & xx & " /USER:surindo\misadmin mispusing", AppWinStyle.Hide, True, 10000)



                Dim Y = Trim(FormFluMenu.btnlink.Caption) + "\"
                Shell("net use " & Y & " /USER:surindo\missoft M1spassword!", AppWinStyle.Hide, True, 10000)
                Dim curFile As String = "" & Y & "" & Trim(lblatth.Text) & ""
                '  If File.Exists(curFile) Then
                Dim x As String = "" & Y & "" & Trim(lblatth.Text) & ""

                Try

                    'PdfViewerControl1.InputFile = x

                    'lblrotate.Text = "0"


                    Cursor = Cursors.WaitCursor
                    Try

                        '  PdfViewer1.LoadDocument(x)

                        AxAcroPDF1.Refresh()
                        AxAcroPDF1.src = x
                    Catch exception As Exception
                        MessageBox.Show(exception.Message)
                    Finally
                        Cursor = Cursors.[Default]
                    End Try






                    btnShowHide.Visible = True
                Catch Exception As Exception
                    MessageBox.Show(Exception.Message)
                Finally
                    Cursor = Cursors.[Default]
                End Try



            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub AFAPdf()


        Me.Cursor = Cursors.WaitCursor
        Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        ' Dim DT As DataTable
        Dim shostname As String
        shostname = System.Net.Dns.GetHostName

        Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        Try
            With xlApp

                .Workbooks.Open(Application.StartupPath & "\Template\AFA.xlt")

                Dim afa As String = Trim(TxtAfa.Text)

                tblDept = Proses.ExecuteQuery("select  AFA_NO	,ID	,Max(NIK_Auth)  NIK_Auth	,Max(Nama_Auth) Nama_Auth, " _
& " case when max(Nama_Auth)='' then Max(Jab_Auth) else Max(Jab_Auth) +': ' end  Jab_Auth	,case when Max(App_Auth)='' then '' when  Max(App_Auth)='App' then 'Approved'  else Max(App_Auth) end  App_Auth	, " _
& " isnull(Max(DateApp_Auth),'')  DateApp_Auth	,Max(NIK_Supp)  NIK_Supp	, Max(Nama_Supp)  Nama_Supp	,case when max(Nama_Supp)='' then Max(Jab_Supp) else Max(Jab_Supp) +': ' end  Jab_Supp	, " _
& " case when Max(App_Supp)='' then '' when  Max(App_Supp)='App' then 'Approved' else Max(App_Supp)end  App_Supp	,isnull(Max(DateApp_Supp),'')  DateApp_Supp	,Max(NIK_Dir)  NIK_Dir	, Max(Nama_Dir) Nama_Dir		,case when max(Nama_Dir)='' then Max(Jab_Dir) else Max(Jab_Dir) +': ' end  Jab_Dir		,case when Max(App_Dir)='' then '' when  Max(App_Dir)='App' then 'Approved'  else Max(App_Dir) end  App_Dir		,isnull(Max(DateApp_Dir),'')  DateApp_Dir	from(SELECT  [AFA_NO]      ,[TYPE]      ,[ID]	 	 ,Nik NIK_Auth	  ,Nama Nama_Auth	  ,JAB Jab_Auth			   ,case when a.STS='App' then 'App' when a.STS='Skip' then 'Skip: ' +a.Reason else '' End App_Auth	 		  ,isnull(convert(varchar(12),a.DATEAPP,113),'') + ' '+substring(convert(varchar(20),a.DATEAPP,100),12,8)  DateApp_Auth	   ,'' NIK_Supp	  ,'' Nama_Supp	 		   ,'' Jab_Supp	  ,'' App_Supp	  ,'' DateApp_Supp	    ,'' NIK_Dir	  ,'' Nama_Dir			     ,'' Jab_Dir	  ,'' App_Dir	  ,'' DateApp_Dir         			   FROM [AFASYS].[dbo].[AFA_SIGNATURE]			    a where  a.TYPE='Auth' and nik<>'' 	 union all  SELECT  [AFA_NO]      ,[TYPE]      ,[ID]	  ,'' NIK_Auth	  ,'' Nama_Auth	  ,'' Jab_Auth	  ,'' App_Auth	  ,'' DateApp_Auth	,Nik NIK_Supp	  ,Nama Nama_Supp	  ,Jab Jab_Supp	 ,case when a.STS='App' then 'App' when a.STS='Skip' then 'Skip: ' +a.Reason else '' End App_Supp ,isnull(convert(varchar(12),a.DATEAPP,113),'') + ' '+substring(convert(varchar(20),a.DATEAPP,100),12,8) DateApp_Supp	,'' NIK_Dir	  ,'' Nama_Dir	  ,'' Jab_Dir	  ,'' App_Dir	  ,'' DateApp_Dir        FROM [AFASYS].[dbo].[AFA_SIGNATURE] a where  a.TYPE='Supp' and nik<>'' union all  SELECT  [AFA_NO]      ,[TYPE]      ,[ID]	  ,'' NIK_Auth	  ,'' Nama_Auth	  ,'' Jab_Auth	,'' App_Auth	  ,'' DateApp_Auth	 	    ,'' NIK_Supp	  ,'' Nama_Supp	  ,'' Jab_Supp	  ,'' App_Supp	,'' DateApp_Supp	    ,Nik NIK_Dir	  ,Nama Nama_Dir	  ,Jab Jab_Dir	 ,case when a.STS='App' then 'App' when a.STS='Skip' then 'Skip: ' +a.Reason else '' End App_Dir	,isnull(convert(varchar(12),a.DATEAPP,113),'') + ' '+substring(convert(varchar(20),a.DATEAPP,100),12,8) DateApp_Dir    FROM [AFASYS].[dbo].[AFA_SIGNATURE] a where  a.TYPE='Dir' and nik<>'') as aa   where aa.AFA_NO='" & afa & "' group by AFA_NO	,ID")
                Dim i
                Dim nrow = 8, x = 0
                Dim idix = ""
                For i = 0 To tblDept.Rows.Count - 1
                    nrow = nrow + 1
                    x = x + 1

                    .Range("b" & CStr(nrow)).Value = tblDept.Rows(i)("Jab_Auth") + " " + tblDept.Rows(i)("Nama_Auth")
                    .Range("c" & CStr(nrow)).Value = tblDept.Rows(i)("Jab_Supp") + " " + tblDept.Rows(i)("Nama_Supp")
                    .Range("d" & CStr(nrow)).Value = tblDept.Rows(i)("Jab_Dir") + " " + tblDept.Rows(i)("Nama_Dir")

                    .Range("b" & CStr(nrow) & ":" & "b" & CStr(nrow)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("c" & CStr(nrow) & ":" & "c" & CStr(nrow)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("d" & CStr(nrow) & ":" & "d" & CStr(nrow)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("f" & CStr(nrow) & ":" & "f" & CStr(nrow)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    .Range("d" & CStr(nrow) & ":" & "e" & CStr(nrow)).MergeCells = True
                    .Range("b" & CStr(nrow) & ":" & "f" & CStr(nrow)).RowHeight = 22

                    nrow = nrow + 1
                    .Range("b" & CStr(nrow)).Value = tblDept.Rows(i)("App_Auth") + " " + tblDept.Rows(i)("DateApp_Auth")
                    .Range("c" & CStr(nrow)).Value = tblDept.Rows(i)("App_Supp") + " " + tblDept.Rows(i)("DateApp_Supp")
                    .Range("d" & CStr(nrow)).Value = tblDept.Rows(i)("App_Dir") + " " + tblDept.Rows(i)("DateApp_Dir")


                    .Range("d" & CStr(nrow) & ":" & "e" & CStr(nrow)).MergeCells = True

                    .Range("b" & CStr(nrow) & ":" & "b" & CStr(nrow)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("c" & CStr(nrow) & ":" & "c" & CStr(nrow)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("d" & CStr(nrow) & ":" & "d" & CStr(nrow)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("f" & CStr(nrow) & ":" & "f" & CStr(nrow)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    .Range("b" & CStr(nrow) & ":" & "f" & CStr(nrow)).RowHeight = 22


                    '.Range("c" & CStr(nrow) & ":" & "d" & CStr(nrow)).MergeCells = True




                    .Range("b" & CStr(nrow) & ":" & "b" & CStr(nrow)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("c" & CStr(nrow) & ":" & "c" & CStr(nrow)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("d" & CStr(nrow) & ":" & "d" & CStr(nrow)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
                    .Range("e" & CStr(nrow) & ":" & "e" & CStr(nrow)).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous

                    '    idix = Trim(tblDept.Rows(i)("NIK"))
                Next


                Dim sup
                sup = nrow + 2

                '   tblKaizen = Proses.ExecuteQuery("SELECT  A.SRS,[AFA_TYPE]      ,A.[AFA_NO]     ,[BUDGET_YEAR]      ,[BUDGET_REV]       ,[COST_CENTER]     ,[CONTRACT]  ,isnull(convert(varchar(12),[AFA_DATE],113),'') + ' ' +isnull(substring(convert(varchar(20),[AFA_DATE],100),12,8),'')	 [AFA_DATE]   	,FORMAT([AMT], '#,#.00') [AMT]      ,b.TglApp [FINANCE_DATE] ,isnull([AFA_NO_APPROVAL],'') [AFA_NO_APPROVAL] ,isnull(convert(varchar(12),A.AFA_APPROVAL_DATE,113),'') [AFA_APPROVAL_DATE]   ,[AFA_PER_FROM]      ,[AFA_PER_TO]      ,[ASSET]  ,[NOTETEXT]  ,[DATECREATE]      ,[STS]      ,[SUBJECT]      ,[PURPOSES]   	,[SCHEDULE]        ,[ESTI]   ,[PC]      ,[USERID] ,[Atth]      ,[CC_Desc]      ,[Site_lokasi] FROM [AFASYS].[dbo].[AFA_H] A			 	LEFT JOIN (SELECT  isnull(convert(varchar(12),DATEAPP,113),'')  TglApp,AFA_NO 				FROM [dbo].[AFA_SIGNATURE] WHERE JAB='Financial Director' ) AS B ON B.AFA_NO=A.AFA_NO 				LEFT JOIN (SELECT   isnull(convert(varchar(12),DATEAPP,113),'') + ' '+ isnull(substring(convert(varchar(20),DATEAPP,100),12,8),'')  TglApp,AFA_NO FROM [dbo].[AFA_SIGNATURE] 					WHERE JAB='President Director' ) AS c ON c.AFA_NO=A.AFA_NO where A.afa_no='" & afa & "'")

                tblKaizen = Proses.ExecuteQuery("SELECT  A.SRS,[AFA_TYPE]      ,A.[AFA_NO]     ,[BUDGET_YEAR]      ,[BUDGET_REV]       ,[COST_CENTER]     ,[CONTRACT] ,isnull(convert(varchar(12),[AFA_DATE],113),'') + ' ' +isnull(substring(convert(varchar(20),[AFA_DATE],100),12,8),'')	 [AFA_DATE]   ,FORMAT([AMT], '#,#.00') [AMT]      ,isnull(convert(varchar(12),a.[FINANCE_DATE],113),'')  [FINANCE_DATE] ,isnull([AFA_NO_APPROVAL],'') [AFA_NO_APPROVAL] ,isnull(convert(varchar(12),A.AFA_APPROVAL_DATE,113),'') [AFA_APPROVAL_DATE]   ,[AFA_PER_FROM]      ,[AFA_PER_TO]      ,[ASSET]  ,[NOTETEXT]  ,[DATECREATE]      ,[STS]      ,[SUBJECT]      ,[PURPOSES]   	,ISNULL(SCHEDULE,'') [SCHEDULE]    ,[ESTI]   ,[PC]      ,[USERID] ,[Atth]      ,[CC_Desc]      ,[Site_lokasi] FROM [AFASYS].[dbo].[AFA_H] A				where A.afa_no='" & afa & "'")

                If tblKaizen.Rows.Count > 0 Then
                    .Range("b" & CStr(2)).Value = "SRI AFA : " + tblKaizen.Rows(0)("SRS")
                    .Range("b" & CStr(4)).Value = tblKaizen.Rows(0)("AFA_NO")
                    .Range("c" & CStr(4)).Value = tblKaizen.Rows(0)("AFA_NO_APPROVAL")
                    .Range("d" & CStr(4)).Value = tblKaizen.Rows(0)("FINANCE_DATE")
                    .Range("e" & CStr(4)).Value = tblKaizen.Rows(0)("AFA_APPROVAL_DATE")
                    .Range("c" & CStr(6)).Value = tblKaizen.Rows(0)("CC_Desc")
                    .Range("d" & CStr(6)).Value = tblKaizen.Rows(0)("Site_lokasi")
                    .Range("e" & CStr(6)).Value = tblKaizen.Rows(0)("AFA_DATE")

                    .Range("b" & CStr(sup)).Value = tblKaizen.Rows(0)("NOTETEXT")
                    .Range("b" & CStr(sup) & ":" & "e" & CStr(sup + 18)).RowHeight = 20
                    .Range("b" & CStr(sup) & ":" & "e" & CStr(sup + 18)).MergeCells = True
                    '                    .Range("b" & CStr(sup) & ":" & "e" & CStr(sup + 10)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop
                    .Range("b" & CStr(sup) & ":" & "e" & CStr(sup + 18)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify
                    .Range("b" & CStr(sup)).Font.Size = 10
                    .Range("b" & CStr(sup + 19)).Value = "Schedule : " + tblKaizen.Rows(0)("SCHEDULE")
                    .Range("b" & CStr(sup + 20)).Value = "ESTIMATED COST :"
                    .Range("C" & CStr(sup + 20)).Value = tblKaizen.Rows(0)("AMT").ToString

                    '.Range("d" & CStr(sup + 12)).NumberFormat = "###,##0.00"
                    .Range("b" & CStr(sup + 20)).Font.Bold = True
                    .Range("c" & CStr(sup + 20)).Font.Bold = True
                    ' .Range("b" & CStr(sup + 12) & ":" & "D" & CStr(sup + 12)).MergeCells = True
                End If

                Dim xx

                xx = sup + 21
                Dim strCurrency As String = ""
                strCurrency = "USD"

                tblLog = Proses.ExecuteQuery("SELECT a.[AFA_NO]      ,[Budget_Year]      ,[Rev]      ,[CC]      ,[Contrac]      ,[Allocasi]      ,CONVERT(NUMERIC(18,3),[Budget_Amt]) Budget_Amt	  ,isnull([Act_This_App]  ,0) [Act_This_App] ,isnull([Act_This_App]-b.AMT,0) Act_This	  ,isnull(b.ALOKASI_DESC,'') ALOKASI_DESC	  ,isnull(b.AMT,0) AMT,case when isnull(c.STS,'')='Send' then ''  when isnull(c.STS,'')='App' then 'Approve' else '' end Sts,isnull(convert(varchar(12),c.DATEAPP,113),'') DateApp   FROM [AFASYS].[dbo].[AFA_Purch_Budget] a  left join [dbo].[AFA_ALOKASI] b on b.AFA_NO=a.AFA_NO and a.Allocasi=b.ALOKASI    left join [dbo].[AFA_SIGNATURE] c on c.AFA_NO=a.AFA_NO and c.TYPE='Budget'  where a.AFA_NO='" & afa & "'")

                For yy = 0 To tblLog.Rows.Count - 1
                    xx = xx + 1

                    .Range("b" & CStr(xx)).Value = "Budget Item : " + tblLog.Rows(yy)("ALOKASI_DESC")
                    .Range("b" & CStr(xx)).Font.Bold = True
                    .Range("b" & CStr(xx) & ":" & "c" & CStr(xx)).MergeCells = True


                    xx = xx + 1
                    .Range("b" & CStr(xx)).Value = "Yearly Budget"

                    xx = xx + 1
                    .Range("b" & CStr(xx)).Value = "Budget Amount"
                    ' .Range("c" & CStr(xx)).Value = "USD :"
                    .Range("C" & CStr(xx)).Value = Val(tblLog.Rows(yy)("Budget_Amt"))
                    ' .Range("C" & CStr(xx)).NumberFormat = "_($*#,##0.00_);_($*(#,##0.00);_($*""_""??_);_(@_)"

                    xx = xx + 1
                    .Range("b" & CStr(xx)).Value = "Actual Up This Application"
                    ' .Range("c" & CStr(xx)).Value = "USD :"
                    .Range("C" & CStr(xx)).Value = tblLog.Rows(yy)("Act_This_App")
                    ' .Range("C" & CStr(xx)).NumberFormat = "_($*#,##0.00_);_($*(#,##0.00);_($*""_""??_);_(@_)"


                    xx = xx + 1
                    .Range("b" & CStr(xx)).Value = "This Application"
                    ' .Range("c" & CStr(xx)).Value = "USD :"
                    .Range("C" & CStr(xx)).Value = tblLog.Rows(yy)("Amt")
                    ' .Range("C" & CStr(xx)).NumberFormat = "_($*#,##0.00_);_($*(#,##0.00);_($*""_""??_);_(@_)"


                    xx = xx + 1
                    .Range("b" & CStr(xx)).Value = "Balance"
                    ' .Range("c" & CStr(xx)).Value = "USD :"
                    .Range("C" & CStr(xx)).Value = Val(tblLog.Rows(yy)("Budget_Amt")) - (Val(tblLog.Rows(yy)("Act_This_App")) + Val(tblLog.Rows(yy)("Amt")))
                    ' .Range("C" & CStr(xx)).NumberFormat = "_($*#,##0.00_);_($*(#,##0.00);_($*""_""??_);_(@_)"

                    .Range("b" & CStr(xx)).Font.Bold = True
                    .Range("C" & CStr(xx)).Font.Bold = True
                Next


                .Range("b" & CStr(xx + 2)).Value = "Checked By,"
                .Range("b" & CStr(xx + 3)).Value = "Budget Control"
                .Range("b" & CStr(xx + 5)).Value = tblLog.Rows(0)("Sts")
                .Range("b" & CStr(xx + 6)).Value = Trim(lblkutip.Text) + tblLog.Rows(0)("DateApp").ToString

                .Range("b" & CStr(xx + 8)).Value = "( F&A )"

                Me.Cursor = Cursors.Default


                .Range("A1").Select()
                ' .Visible = True
            End With
            Dim id = Format(Now, "yyyyMMddHHss").ToString
            lblid.Text = id
            xlApp.ActiveWorkbook.SaveCopyAs(Application.StartupPath & "\Temp\" & id & ".xls")
            xlApp.ActiveWorkbook.Close(False)


        Catch ex As Exception
            MsgBox(ex.Message)
            xlApp.ActiveWorkbook.Close(False)
        End Try

        System.Threading.Thread.CurrentThread.CurrentCulture = oldCI


        ReleaseObject(xlApp)


    End Sub



    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            'Finally
            'GC.Collect()
        End Try
    End Sub
    Sub openfile()
        Try

            If Trim(TxtAfa.Text) <> "" Then

                Dim Y = Application.StartupPath & "\Temp\" & Trim(lblid.Text) & ".xls"

                Dim curFile As String = Y
                If File.Exists(curFile) Then
                    ' Load a workbook from the stream.
                    Dim stream As New FileStream(Application.StartupPath & "\Temp\" & Trim(lblid.Text) & ".xls", FileMode.Open)
                    'SpreadsheetControl1.LoadDocument(stream, DocumentFormat.Xlsx)
                    SpreadsheetControl1.LoadDocument("" & Y & "", DocumentFormat.Xls)

                Else
                    MsgBox("Document not found")

                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncekbudget_Click(sender As Object, e As EventArgs) Handles btncekbudget.Click
        sendemailtoindra()
    End Sub
    Sub sendemailtoindra()


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

        Commandku.CommandText = "MIS_SendEmail_APP_BudgetControl_To_Indra_AFA"
        Dim userid = Trim(XtraFormLogin.Txtuserid.Text)

        Dim afa = Trim(TxtAfa.Text)

        Commandku.Parameters.AddWithValue("@AFA2", Trim(afa))




        Dim outParamSts As SqlClient.SqlParameter =
      Commandku.Parameters.Add("@Sts2", SqlDbType.VarChar, 100)
        outParamSts.Direction = ParameterDirection.Output

        Dim pesansts As SqlClient.SqlParameter =
      Commandku.Parameters.Add("@Pesan2", SqlDbType.VarChar, 100)
        pesansts.Direction = ParameterDirection.Output

        Commandku.CommandTimeout = 1000
        Commandku.ExecuteNonQuery()



        If outParamSts.Value = "OK" Then

            MsgBox(pesansts.Value.ToString)

        ElseIf outParamSts.Value = "NOTOK" Then
            Cursor.Current = Cursors.Default
            MessageBox.Show("Network Error", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information)


        End If
        ' ----- Bersih - bersih.
        Commandku = Nothing
        Database.Close()
        Database.Dispose()

    End Sub

    Private Sub btnShowHide_Click(sender As Object, e As EventArgs) Handles btnShowHide.Click
        If Trim(btnShowHide.Text) = "Hide AFA" Then
            SplitContainer2.Panel1Collapsed = True
            btnShowHide.Text = "Show AFA"
        ElseIf Trim(btnShowHide.Text) = "Show AFA" Then
            SplitContainer2.Panel1Collapsed = False
            btnShowHide.Text = "Hide AFA"
        End If
    End Sub

    Private Sub XtraFormViewAFANew_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            SplitContainer1.SplitterDistance = 45
            SplitContainer2.SplitterDistance = 900
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        isiattch()
    End Sub

    Private Sub BtnViewAccOwner_Click(sender As Object, e As EventArgs) Handles BtnViewAccOwner.Click
        isiaccbod()
    End Sub

    Private Sub BtnAddInf_Click(sender As Object, e As EventArgs) Handles BtnAddInf.Click
        XtraFormAddInf.TxtAfa.Text = Trim(TxtAfa.Text)
        XtraFormAddInf.data()
        '   FormFluMenu.menuaddinf()
        XtraFormAddInf.ShowDialog()
        XtraFormAddInf.BringToFront()
    End Sub

    Private Sub btnView2_Click(sender As Object, e As EventArgs) Handles btnView2.Click
        isiattch2()
    End Sub
    Sub isiaccbod()
        tblDept = Proses.ExecuteQuery("SELECT [AFA_NO],isnull(AccOwner,'') AccOwner      FROM [AFASYS].[dbo].[AFA_H] where AFA_NO='" & Trim(TxtAfa.Text) & "'")

        If tblDept.Rows.Count > 0 Then
            lblappbod.Text = Trim(tblDept.Rows(0).Item(1).ToString)

            viewappbod()
        Else
            lblappbod.Text = ""

        End If
    End Sub
    Sub viewappbod()
        Try
            If Trim(lblappbod.Text) <> "" Then

                Dim Y = Trim(FormFluMenu.btnlink.Caption) + "\"
                Shell("net use " & Y & " /USER:surindo\missoft M1spassword!", AppWinStyle.Hide, True, 10000)
                Dim curFile As String = "" & Y & "" & Trim(lblatth2.Text) & ""
                '  If File.Exists(curFile) Then
                Dim x As String = "" & Y & "" & Trim(lblappbod.Text) & ""

                Cursor = Cursors.WaitCursor
                Try

                    '  PdfViewer1.LoadDocument(x)

                    AxAcroPDF1.Refresh()
                    AxAcroPDF1.src = x
                Catch exception As Exception
                    MessageBox.Show(exception.Message)
                Finally
                    Cursor = Cursors.[Default]
                End Try

            End If
        Catch ex As Exception

        End Try



    End Sub
End Class