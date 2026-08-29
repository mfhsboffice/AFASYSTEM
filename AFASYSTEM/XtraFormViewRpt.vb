Imports System
Imports System.Windows.Forms
Imports DevExpress.Snap
Imports DevExpress.Snap.Core.API

Imports System.IO

Public Class XtraFormViewRpt
    Private param1 As New Parameter()

    Sub showerrr()
        Dim afano = Trim(lblafa.Text)
        Try

            If Trim(lblafa.Text) <> "" Then

                Dim Y = Application.StartupPath & "\Rpt\afaRPT.repx"

                Dim curFile As String = Y
                If File.Exists(curFile) Then
                    ' Load a workbook from the stream.
                    'Dim stream As New FileStream(Application.StartupPath & "\Rpt\afaRPT.repx", FileMode.Open)
                    ''SpreadsheetControl1.LoadDocument(stream, DocumentFormat.Xlsx)
                    'DocumentViewer1.DocumentSource("" & stream & "")

                    'param1.Name = "afa"
                    'param1.Type = GetType(System.String)
                    'param1.Value = afano
                    'SnapControl1.Document.Parameters.Add(param1)
                    'SnapControl1.DataSource = Y

                Else
                    MsgBox("Document not found")

                End If

            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraFormViewRpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class