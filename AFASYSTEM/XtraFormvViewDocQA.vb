Imports System.IO
Imports Bytescout.PDFViewer
Imports DevExpress.XtraBars
Imports DevExpress.XtraPdfViewer
Imports DevExpress.XtraPdfViewer.Bars
Imports DevExpress.XtraPdfViewer.Commands
Imports DevExpress.XtraPdfViewer.Extensions



Public Class XtraFormvViewDocQA
    Private stream As FileStream
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2, tblgrid As DataTable
    Dim tblEmployee As DataTable



    Dim tblLog As DataTable
    Dim CM As CurrencyManager



    Private Sub PdfViewer1_Load(sender As Object, e As EventArgs)
        open()
    End Sub


    Sub open()

        '   Try
        Shell("net use \\192.168.171.5 /USER:surindo\missoft M1spassword!", AppWinStyle.Hide, True, 10000)
            tblLog = Proses.ExecuteQuery("SELECT  [Nodoc]  FROM [AFASYS].[dbo].[AFA_DocControlAFA]")

            If tblLog.Rows.Count > 0 Then
                Dim nama = Trim(tblLog.Rows(0).Item("Nodoc").ToString)

                '  If stream Is Nothing Then stream = New FileStream(nama, FileMode.Open)
                '  PdfViewer1.LoadDocument(stream)


                Dim rpt As New PDFRPT()
                rpt.pdfsource.SourceUrl = nama

            DocumentViewer1.IsMetric = False

            DocumentViewer1.Dock = DockStyle.Fill
                DocumentViewer1.DocumentSource = rpt
                rpt.CreateDocument()


            End If

        '  Catch ex As Exception
        '  End Try


    End Sub

    Private Sub XtraFormvViewDocQA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.KeyPreview = True
        open()
    End Sub

    Private Sub XtraFormvViewDocQA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub PdfViewer1_PopupMenuShowing(sender As Object, e As PdfPopupMenuShowingEventArgs)
        Try
            Dim printtt = e.ItemLinks.GetPdfViewerBarItemLink(PdfViewerCommandId.PrintFile)
            e.ItemLinks.Remove(printtt)


        Catch ex As Exception

        End Try


    End Sub

    Private Sub XtraFormvViewDocQA_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.P Then
            e.SuppressKeyPress = True ' Mencegah key dikirim ke kontrol aktif
            e.Handled = True ' Tandai event sebagai sudah ditangani

            ' (Opsional) Tampilkan pesan atau log
            MessageBox.Show("Ctrl + P telah dinonaktifkan.")
        End If
    End Sub
End Class