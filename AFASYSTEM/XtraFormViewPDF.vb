Imports System.IO
Imports System
Imports System.ComponentModel
Public Class XtraFormViewPDF
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2, tblgrid As DataTable
    Dim tblEmployee As DataTable
    Dim tblLog As DataTable
    Dim CM As CurrencyManager
    Public Property DetachStreamAfterLoadComplete As Boolean
    Private Sub XtraFormViewPDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click
        Try
            WebBrowser1.Navigate("")
        Catch ex As Exception

        End Try

        Me.Dispose()
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


    Sub viewer()
        Try
            Dim Y = Trim(FormFluMenu.btnlink.Caption)
            Shell("net use " & Y & " /USER:surindo\missoft M1spassword!", AppWinStyle.Hide, True, 10000)

            If Trim(lblatth.Text) <> "" Then



                Dim curFile As String = "" & Y & "\" & Trim(lblatth.Text) & ""
                If File.Exists(curFile) Then
                    Dim x = "" & Y & "\" & Trim(lblatth.Text) & ""



                    Cursor = Cursors.WaitCursor
                    Try
                        ' PdfViewer1.LoadDocument(x)

                        'Dim stream As FileStream = New FileStream(x, FileMode.Open)
                        'PdfViewer1.LoadDocument(stream)
                        'PdfViewer1.DetachStreamAfterLoadComplete = True
                        WebBrowser1.Navigate(x)
                        WebBrowser1.Show()
                    Catch exception As Exception
                        MessageBox.Show(exception.Message)
                    Finally
                        Cursor = Cursors.[Default]
                    End Try

                Else
                    MsgBox("Document not found in Server")

                End If

            End If
        Catch ex As Exception

        End Try



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

                Dim Y = Trim(FormFluMenu.btnlink.Caption)
                Shell("net use " & Y & " /USER:surindo\missoft M1spassword!", AppWinStyle.Hide, True, 10000)
                Dim curFile As String = "" & Y & "\" & Trim(lblatth2.Text) & ""
                '  If File.Exists(curFile) Then
                Dim x As String = "" & Y & "\" & Trim(lblatth2.Text) & ""

                Try
                    ' AxAcroPDF2.src = x
                    Cursor = Cursors.WaitCursor
                    Try

                        'Dim stream As FileStream = New FileStream(x, FileMode.Open)
                        'PdfViewer1.LoadDocument(stream)
                        'PdfViewer1.DetachStreamAfterLoadComplete = True
                        WebBrowser1.Navigate(x)
                        WebBrowser1.Show()
                    Catch exception As Exception
                        MessageBox.Show(exception.Message)
                    Finally
                        Cursor = Cursors.[Default]
                    End Try


                Catch Exception As Exception
                    MessageBox.Show(Exception.Message)
                Finally
                    Cursor = Cursors.[Default]
                End Try



            End If
        Catch ex As Exception

        End Try



    End Sub


End Class