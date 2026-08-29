<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormDownloadNote
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormDownloadNote))
        Me.TxtAFA = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnDownload = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.TxtAFA.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtAFA
        '
        Me.TxtAFA.Location = New System.Drawing.Point(84, 32)
        Me.TxtAFA.Name = "TxtAFA"
        Me.TxtAFA.Size = New System.Drawing.Size(251, 20)
        Me.TxtAFA.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 35)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "AFA NO"
        '
        'btnDownload
        '
        Me.btnDownload.ImageOptions.Image = CType(resources.GetObject("btnDownload.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDownload.Location = New System.Drawing.Point(341, 24)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(133, 36)
        Me.btnDownload.TabIndex = 5
        Me.btnDownload.Text = "Download"
        '
        'XtraFormDownloadNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 84)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.TxtAFA)
        Me.IconOptions.LargeImage = CType(resources.GetObject("XtraFormDownloadNote.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "XtraFormDownloadNote"
        Me.Text = "Download Note"
        CType(Me.TxtAFA.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtAFA As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnDownload As DevExpress.XtraEditors.SimpleButton
End Class
