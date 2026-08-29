Imports System.IO
Imports System
Imports System.ComponentModel
Public Class XtraFormPdf
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2, tblgrid As DataTable
    Dim tblEmployee As DataTable



    Dim tblLog As DataTable
    Dim CM As CurrencyManager
    Public Property DetachStreamAfterLoadComplete As Boolean



    Private Sub XtraFormPdf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            tblLog = Proses.ExecuteQuery("SELECT  [Nodoc]  FROM [AFASYS].[dbo].[AFA_DocControlAFA]")

            If tblLog.Rows.Count > 0 Then
                Dim nama = Trim(tblLog.Rows(0).Item("Nodoc").ToString)

                'System.Diagnostics.Process.Start(Application.StartupPath & "\Rpt\Download_AFA.pdf")

                '  PdfViewerControl1.InputFile = nama
                If Me.WebBrowser1.IsBusy Then
                    Me.WebBrowser1.Stop()
                Else
                    WebBrowser1.Navigate(nama)

                End If




                '  CType(WebBrowser1, System.Windows.Forms.Control).Enabled = False


            End If

        Catch ex As Exception

        End Try
    End Sub
End Class