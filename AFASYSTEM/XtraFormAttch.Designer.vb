<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XtraFormAttch
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormAttch))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblatth2 = New System.Windows.Forms.Label()
        Me.lblatth = New System.Windows.Forms.Label()
        Me.lblkutip = New System.Windows.Forms.Label()
        Me.lblid = New System.Windows.Forms.Label()
        Me.btnView2 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtAfa = New System.Windows.Forms.TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.SpreadsheetControl1 = New DevExpress.XtraSpreadsheet.SpreadsheetControl()
        Me.BtnAddInf = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnAddInf)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblatth2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblatth)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblkutip)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnView2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnView)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtAfa)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnExit)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SpreadsheetControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1049, 638)
        Me.SplitContainer1.SplitterDistance = 59
        Me.SplitContainer1.TabIndex = 0
        '
        'lblatth2
        '
        Me.lblatth2.AutoSize = True
        Me.lblatth2.Location = New System.Drawing.Point(814, 28)
        Me.lblatth2.Name = "lblatth2"
        Me.lblatth2.Size = New System.Drawing.Size(0, 13)
        Me.lblatth2.TabIndex = 100
        Me.lblatth2.Visible = False
        '
        'lblatth
        '
        Me.lblatth.AutoSize = True
        Me.lblatth.Location = New System.Drawing.Point(696, 22)
        Me.lblatth.Name = "lblatth"
        Me.lblatth.Size = New System.Drawing.Size(0, 13)
        Me.lblatth.TabIndex = 99
        Me.lblatth.Visible = False
        '
        'lblkutip
        '
        Me.lblkutip.AutoSize = True
        Me.lblkutip.Location = New System.Drawing.Point(763, 31)
        Me.lblkutip.Name = "lblkutip"
        Me.lblkutip.Size = New System.Drawing.Size(10, 13)
        Me.lblkutip.TabIndex = 98
        Me.lblkutip.Text = "'"
        Me.lblkutip.Visible = False
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(731, 12)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(0, 13)
        Me.lblid.TabIndex = 97
        Me.lblid.Visible = False
        '
        'btnView2
        '
        Me.btnView2.ImageOptions.Image = CType(resources.GetObject("btnView2.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView2.Location = New System.Drawing.Point(550, 12)
        Me.btnView2.Name = "btnView2"
        Me.btnView2.Size = New System.Drawing.Size(116, 33)
        Me.btnView2.TabIndex = 96
        Me.btnView2.Text = "View Attch 2"
        '
        'btnView
        '
        Me.btnView.ImageOptions.Image = CType(resources.GetObject("btnView.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(428, 11)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(116, 33)
        Me.btnView.TabIndex = 95
        Me.btnView.Text = "View Attch 1"
        '
        'TxtAfa
        '
        Me.TxtAfa.Location = New System.Drawing.Point(67, 19)
        Me.TxtAfa.Name = "TxtAfa"
        Me.TxtAfa.ReadOnly = True
        Me.TxtAfa.Size = New System.Drawing.Size(209, 22)
        Me.TxtAfa.TabIndex = 90
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(15, 22)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 89
        Me.LabelControl1.Text = "Afa No"
        Me.LabelControl1.UseMnemonic = False
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(297, 12)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(124, 33)
        Me.BtnExit.TabIndex = 87
        Me.BtnExit.Text = "Exit"
        '
        'SpreadsheetControl1
        '
        Me.SpreadsheetControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SpreadsheetControl1.Location = New System.Drawing.Point(0, 0)
        Me.SpreadsheetControl1.Name = "SpreadsheetControl1"
        Me.SpreadsheetControl1.ReadOnly = True
        Me.SpreadsheetControl1.Size = New System.Drawing.Size(1049, 575)
        Me.SpreadsheetControl1.TabIndex = 1
        Me.SpreadsheetControl1.Text = "SpreadsheetControl1"
        '
        'BtnAddInf
        '
        Me.BtnAddInf.ImageOptions.Image = CType(resources.GetObject("BtnAddInf.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnAddInf.Location = New System.Drawing.Point(672, 12)
        Me.BtnAddInf.Name = "BtnAddInf"
        Me.BtnAddInf.Size = New System.Drawing.Size(148, 33)
        Me.BtnAddInf.TabIndex = 101
        Me.BtnAddInf.Text = "Add Information"
        '
        'XtraFormAttch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 638)
        Me.Controls.Add(Me.SplitContainer1)
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormAttch.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormAttch"
        Me.Text = "View Attachment"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtAfa As TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SpreadsheetControl1 As DevExpress.XtraSpreadsheet.SpreadsheetControl
    Friend WithEvents btnView2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblid As Label
    Friend WithEvents lblkutip As Label
    Friend WithEvents lblatth As Label
    Friend WithEvents lblatth2 As Label
    Friend WithEvents BtnAddInf As DevExpress.XtraEditors.SimpleButton
End Class
