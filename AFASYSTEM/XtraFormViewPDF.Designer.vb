<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormViewPDF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormViewPDF))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.lblatth2 = New DevExpress.XtraEditors.LabelControl()
        Me.lblatth = New DevExpress.XtraEditors.LabelControl()
        Me.lblappbod = New DevExpress.XtraEditors.LabelControl()
        Me.btnexit = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtAfa = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel1.SuspendLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel2.SuspendLayout()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.TxtAfa.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        '
        'SplitContainerControl1.Panel1
        '
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblatth2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblatth)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblappbod)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnexit)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.TxtAfa)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        '
        'SplitContainerControl1.Panel2
        '
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.WebBrowser1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1088, 670)
        Me.SplitContainerControl1.SplitterPosition = 44
        Me.SplitContainerControl1.TabIndex = 0
        '
        'lblatth2
        '
        Me.lblatth2.Location = New System.Drawing.Point(552, 47)
        Me.lblatth2.Name = "lblatth2"
        Me.lblatth2.Size = New System.Drawing.Size(0, 13)
        Me.lblatth2.TabIndex = 14
        Me.lblatth2.Visible = False
        '
        'lblatth
        '
        Me.lblatth.Location = New System.Drawing.Point(454, 47)
        Me.lblatth.Name = "lblatth"
        Me.lblatth.Size = New System.Drawing.Size(0, 13)
        Me.lblatth.TabIndex = 13
        Me.lblatth.Visible = False
        '
        'lblappbod
        '
        Me.lblappbod.Location = New System.Drawing.Point(351, 13)
        Me.lblappbod.Name = "lblappbod"
        Me.lblappbod.Size = New System.Drawing.Size(0, 13)
        Me.lblappbod.TabIndex = 12
        Me.lblappbod.Visible = False
        '
        'btnexit
        '
        Me.btnexit.ImageOptions.Image = CType(resources.GetObject("btnexit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnexit.Location = New System.Drawing.Point(313, 3)
        Me.btnexit.Name = "btnexit"
        Me.btnexit.Size = New System.Drawing.Size(92, 33)
        Me.btnexit.TabIndex = 5
        Me.btnexit.Text = "Exit"
        '
        'TxtAfa
        '
        Me.TxtAfa.Enabled = False
        Me.TxtAfa.Location = New System.Drawing.Point(65, 10)
        Me.TxtAfa.Name = "TxtAfa"
        Me.TxtAfa.Size = New System.Drawing.Size(231, 20)
        Me.TxtAfa.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(9, 10)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Afa No"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1088, 618)
        Me.WebBrowser1.TabIndex = 1
        '
        'XtraFormViewPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1088, 670)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.IconOptions.SvgImage = CType(resources.GetObject("XtraFormViewPDF.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.Name = "XtraFormViewPDF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View PDF"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel1.ResumeLayout(False)
        Me.SplitContainerControl1.Panel1.PerformLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.TxtAfa.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents btnexit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtAfa As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblatth2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblatth As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblappbod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents WebBrowser1 As WebBrowser
End Class
