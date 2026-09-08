Imports System.Data
Imports System.IO
Imports DevExpress.XtraEditors

Public Class XtraFormAfaPreview

    Private _lampiranPaths As List(Of String)
    Private _currentLampiranIndex As Integer = 0

    Public Sub LoadPreview(ByVal report As AfaMasterReport, ByVal lampiranPaths As List(Of String))
        report.CreateDocument()
        DocumentViewer1.DocumentSource = report

        _lampiranPaths = lampiranPaths

        If _lampiranPaths Is Nothing OrElse _lampiranPaths.Count = 0 Then
            SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1
            Return
        End If

        SplitContainerControl1.PanelVisibility = SplitPanelVisibility.Both
        PanelNav.Visible = _lampiranPaths.Count > 1

        _currentLampiranIndex = 0
        LoadCurrentLampiran()
    End Sub

    Private Sub LoadCurrentLampiran()
        Try
            Dim path As String = _lampiranPaths(_currentLampiranIndex)

            If Not File.Exists(path) Then
                Throw New FileNotFoundException("File PDF tidak ditemukan.", path)
            End If

            PdfViewer1.LoadDocument(path)

            LabelLampiranInfo.Text = String.Format("Lampiran {0} / {1}",
                                                   _currentLampiranIndex + 1, _lampiranPaths.Count)
            BtnPrevLampiran.Enabled = _currentLampiranIndex > 0
            BtnNextLampiran.Enabled = _currentLampiranIndex < _lampiranPaths.Count - 1
        Catch ex As Exception
            XtraMessageBox.Show("Lampiran PDF tidak dapat ditampilkan." & vbCrLf & vbCrLf & ex.Message,
                                "AFA Preview", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub BtnPrevLampiran_Click(sender As Object, e As EventArgs) Handles BtnPrevLampiran.Click
        If _currentLampiranIndex > 0 Then
            _currentLampiranIndex -= 1
            LoadCurrentLampiran()
        End If
    End Sub

    Private Sub BtnNextLampiran_Click(sender As Object, e As EventArgs) Handles BtnNextLampiran.Click
        If _currentLampiranIndex < _lampiranPaths.Count - 1 Then
            _currentLampiranIndex += 1
            LoadCurrentLampiran()
        End If
    End Sub

End Class