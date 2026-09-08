Imports System.IO
Imports DevExpress.XtraEditors
Public Class AfaMasterReport
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Private Sub PictureBoxAttachment_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PictureBoxAttachment.BeforePrint
        Try
            Dim pic As DevExpress.XtraReports.UI.XRPictureBox = DirectCast(sender, DevExpress.XtraReports.UI.XRPictureBox)
            Dim filePath As String = Convert.ToString(pic.Tag)
            If pic.Image IsNot Nothing Then
                pic.Image.Dispose()
                pic.Image = Nothing
            End If

            If Not String.IsNullOrEmpty(filePath) AndAlso System.IO.File.Exists(filePath) Then
                Using tempImg As Image = Image.FromFile(filePath)
                    pic.Image = New Bitmap(tempImg)
                End Using
            End If
        Catch ex As Exception
            PictureBoxAttachment.Image = Nothing
        End Try
    End Sub
End Class