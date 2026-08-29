<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XtraFormViewAFANew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormViewAFANew))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblappbod = New System.Windows.Forms.Label()
        Me.BtnViewAccOwner = New DevExpress.XtraEditors.SimpleButton()
        Me.btnShowHide = New DevExpress.XtraEditors.SimpleButton()
        Me.btncekbudget = New DevExpress.XtraEditors.SimpleButton()
        Me.lblatth2 = New System.Windows.Forms.Label()
        Me.btnView2 = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAddInf = New DevExpress.XtraEditors.SimpleButton()
        Me.lblid = New System.Windows.Forms.Label()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.lblkutip = New System.Windows.Forms.Label()
        Me.lblatth = New System.Windows.Forms.Label()
        Me.TxtAfa = New System.Windows.Forms.TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SpreadsheetControl1 = New DevExpress.XtraSpreadsheet.SpreadsheetControl()
        Me.SplitterControl1 = New DevExpress.XtraEditors.SplitterControl()
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblappbod)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnViewAccOwner)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnShowHide)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btncekbudget)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblatth2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnView2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnAddInf)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnView)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblkutip)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblatth)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtAfa)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnExit)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitterControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1310, 760)
        Me.SplitContainer1.SplitterDistance = 92
        Me.SplitContainer1.TabIndex = 1
        '
        'lblappbod
        '
        Me.lblappbod.AutoSize = True
        Me.lblappbod.Location = New System.Drawing.Point(989, 49)
        Me.lblappbod.Name = "lblappbod"
        Me.lblappbod.Size = New System.Drawing.Size(0, 13)
        Me.lblappbod.TabIndex = 99
        Me.lblappbod.Visible = False
        '
        'BtnViewAccOwner
        '
        Me.BtnViewAccOwner.ImageOptions.Image = CType(resources.GetObject("BtnViewAccOwner.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnViewAccOwner.Location = New System.Drawing.Point(769, 6)
        Me.BtnViewAccOwner.Name = "BtnViewAccOwner"
        Me.BtnViewAccOwner.Size = New System.Drawing.Size(142, 33)
        Me.BtnViewAccOwner.TabIndex = 98
        Me.BtnViewAccOwner.Text = "View App BOD"
        '
        'btnShowHide
        '
        Me.btnShowHide.ImageOptions.Image = CType(resources.GetObject("btnShowHide.ImageOptions.Image"), System.Drawing.Image)
        Me.btnShowHide.Location = New System.Drawing.Point(1083, 7)
        Me.btnShowHide.Name = "btnShowHide"
        Me.btnShowHide.Size = New System.Drawing.Size(97, 33)
        Me.btnShowHide.TabIndex = 97
        Me.btnShowHide.Text = "Hide AFA"
        '
        'btncekbudget
        '
        Me.btncekbudget.ImageOptions.Image = CType(resources.GetObject("btncekbudget.ImageOptions.Image"), System.Drawing.Image)
        Me.btncekbudget.Location = New System.Drawing.Point(918, 7)
        Me.btncekbudget.Name = "btncekbudget"
        Me.btncekbudget.Size = New System.Drawing.Size(159, 33)
        Me.btncekbudget.TabIndex = 96
        Me.btncekbudget.Text = "Check and Send Email"
        '
        'lblatth2
        '
        Me.lblatth2.AutoSize = True
        Me.lblatth2.Location = New System.Drawing.Point(926, 50)
        Me.lblatth2.Name = "lblatth2"
        Me.lblatth2.Size = New System.Drawing.Size(0, 13)
        Me.lblatth2.TabIndex = 95
        Me.lblatth2.Visible = False
        '
        'btnView2
        '
        Me.btnView2.ImageOptions.Image = CType(resources.GetObject("btnView2.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView2.Location = New System.Drawing.Point(493, 7)
        Me.btnView2.Name = "btnView2"
        Me.btnView2.Size = New System.Drawing.Size(116, 33)
        Me.btnView2.TabIndex = 94
        Me.btnView2.Text = "View Attch 2"
        '
        'BtnAddInf
        '
        Me.BtnAddInf.ImageOptions.Image = CType(resources.GetObject("BtnAddInf.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnAddInf.Location = New System.Drawing.Point(615, 7)
        Me.BtnAddInf.Name = "BtnAddInf"
        Me.BtnAddInf.Size = New System.Drawing.Size(148, 33)
        Me.BtnAddInf.TabIndex = 93
        Me.BtnAddInf.Text = "Add Information"
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(957, 7)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(0, 13)
        Me.lblid.TabIndex = 92
        Me.lblid.Visible = False
        '
        'btnView
        '
        Me.btnView.ImageOptions.Image = CType(resources.GetObject("btnView.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(371, 6)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(116, 33)
        Me.btnView.TabIndex = 91
        Me.btnView.Text = "View Attch 1"
        '
        'lblkutip
        '
        Me.lblkutip.AutoSize = True
        Me.lblkutip.Location = New System.Drawing.Point(703, 50)
        Me.lblkutip.Name = "lblkutip"
        Me.lblkutip.Size = New System.Drawing.Size(10, 13)
        Me.lblkutip.TabIndex = 90
        Me.lblkutip.Text = "'"
        Me.lblkutip.Visible = False
        '
        'lblatth
        '
        Me.lblatth.AutoSize = True
        Me.lblatth.Location = New System.Drawing.Point(960, 50)
        Me.lblatth.Name = "lblatth"
        Me.lblatth.Size = New System.Drawing.Size(0, 13)
        Me.lblatth.TabIndex = 89
        Me.lblatth.Visible = False
        '
        'TxtAfa
        '
        Me.TxtAfa.Location = New System.Drawing.Point(57, 17)
        Me.TxtAfa.Name = "TxtAfa"
        Me.TxtAfa.ReadOnly = True
        Me.TxtAfa.Size = New System.Drawing.Size(209, 22)
        Me.TxtAfa.TabIndex = 88
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(5, 20)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 87
        Me.LabelControl1.Text = "Afa No"
        Me.LabelControl1.UseMnemonic = False
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(270, 6)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(95, 33)
        Me.BtnExit.TabIndex = 86
        Me.BtnExit.Text = "Exit"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 8)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SpreadsheetControl1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.AxAcroPDF1)
        Me.SplitContainer2.Size = New System.Drawing.Size(1310, 656)
        Me.SplitContainer2.SplitterDistance = 700
        Me.SplitContainer2.TabIndex = 2
        '
        'SpreadsheetControl1
        '
        Me.SpreadsheetControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SpreadsheetControl1.Location = New System.Drawing.Point(0, 0)
        Me.SpreadsheetControl1.Name = "SpreadsheetControl1"
        Me.SpreadsheetControl1.ReadOnly = True
        Me.SpreadsheetControl1.Size = New System.Drawing.Size(700, 656)
        Me.SpreadsheetControl1.TabIndex = 0
        Me.SpreadsheetControl1.Text = "SpreadsheetControl1"
        '
        'SplitterControl1
        '
        Me.SplitterControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitterControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitterControl1.MinSize = 20
        Me.SplitterControl1.Name = "SplitterControl1"
        Me.SplitterControl1.Size = New System.Drawing.Size(1310, 8)
        Me.SplitterControl1.TabIndex = 1
        Me.SplitterControl1.TabStop = False
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(0, 0)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(606, 656)
        Me.AxAcroPDF1.TabIndex = 0
        '
        'XtraFormViewAFANew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1310, 760)
        Me.Controls.Add(Me.SplitContainer1)
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormViewAFANew.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormViewAFANew"
        Me.Text = "View AFA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents lblkutip As Label
    Friend WithEvents lblatth As Label
    Friend WithEvents TxtAfa As TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SpreadsheetControl1 As DevExpress.XtraSpreadsheet.SpreadsheetControl
    Friend WithEvents SplitterControl1 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblid As Label
    Friend WithEvents BtnAddInf As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnView2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblatth2 As Label
    Friend WithEvents btncekbudget As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnShowHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnViewAccOwner As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblappbod As Label
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
End Class
