<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormSendNoteBudget
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormSendNoteBudget))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblid = New System.Windows.Forms.Label()
        Me.txtnotebudget = New System.Windows.Forms.TextBox()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbreason = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnSend = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtAfa = New System.Windows.Forms.TextBox()
        Me.TxtEst_Cost = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSubject = New System.Windows.Forms.TextBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSchedule = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnupdate = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.TxtEst_Cost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSchedule.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnupdate)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblid)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtnotebudget)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnExit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbreason)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSend)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSave)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtAfa)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtEst_Cost)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtSubject)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtSchedule)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl12)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(902, 684)
        Me.SplitContainer1.SplitterDistance = 469
        Me.SplitContainer1.TabIndex = 0
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(654, 216)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(0, 13)
        Me.lblid.TabIndex = 111
        Me.lblid.Visible = False
        '
        'txtnotebudget
        '
        Me.txtnotebudget.Location = New System.Drawing.Point(107, 266)
        Me.txtnotebudget.MaxLength = 99999
        Me.txtnotebudget.Multiline = True
        Me.txtnotebudget.Name = "txtnotebudget"
        Me.txtnotebudget.Size = New System.Drawing.Size(745, 136)
        Me.txtnotebudget.TabIndex = 1
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(14, 266)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl5.TabIndex = 110
        Me.LabelControl5.Text = "Note Budget"
        Me.LabelControl5.UseMnemonic = False
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(499, 420)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(124, 33)
        Me.BtnExit.TabIndex = 4
        Me.BtnExit.Text = "Exit"
        '
        'cmbreason
        '
        Me.cmbreason.FormattingEnabled = True
        Me.cmbreason.Location = New System.Drawing.Point(105, 239)
        Me.cmbreason.Name = "cmbreason"
        Me.cmbreason.Size = New System.Drawing.Size(335, 21)
        Me.cmbreason.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 239)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl3.TabIndex = 107
        Me.LabelControl3.Text = "Reason Revision"
        Me.LabelControl3.UseMnemonic = False
        '
        'BtnSend
        '
        Me.BtnSend.ImageOptions.Image = CType(resources.GetObject("BtnSend.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSend.Location = New System.Drawing.Point(369, 420)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(124, 33)
        Me.BtnSend.TabIndex = 3
        Me.BtnSend.Text = "Send Email"
        '
        'BtnSave
        '
        Me.BtnSave.ImageOptions.Image = CType(resources.GetObject("BtnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(107, 420)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(124, 33)
        Me.BtnSave.TabIndex = 2
        Me.BtnSave.Text = "Save"
        '
        'TxtAfa
        '
        Me.TxtAfa.Location = New System.Drawing.Point(105, 19)
        Me.TxtAfa.Name = "TxtAfa"
        Me.TxtAfa.ReadOnly = True
        Me.TxtAfa.Size = New System.Drawing.Size(161, 22)
        Me.TxtAfa.TabIndex = 104
        '
        'TxtEst_Cost
        '
        Me.TxtEst_Cost.Enabled = False
        Me.TxtEst_Cost.Location = New System.Drawing.Point(105, 213)
        Me.TxtEst_Cost.Name = "TxtEst_Cost"
        Me.TxtEst_Cost.Size = New System.Drawing.Size(335, 20)
        Me.TxtEst_Cost.TabIndex = 103
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 216)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl4.TabIndex = 102
        Me.LabelControl4.Text = "Estimate Cost"
        Me.LabelControl4.UseMnemonic = False
        '
        'TxtSubject
        '
        Me.TxtSubject.Location = New System.Drawing.Point(105, 45)
        Me.TxtSubject.MaxLength = 99999
        Me.TxtSubject.Multiline = True
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(745, 136)
        Me.TxtSubject.TabIndex = 101
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 45)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl2.TabIndex = 100
        Me.LabelControl2.Text = "Note"
        Me.LabelControl2.UseMnemonic = False
        '
        'TxtSchedule
        '
        Me.TxtSchedule.Enabled = False
        Me.TxtSchedule.Location = New System.Drawing.Point(105, 187)
        Me.TxtSchedule.Name = "TxtSchedule"
        Me.TxtSchedule.Size = New System.Drawing.Size(335, 20)
        Me.TxtSchedule.TabIndex = 99
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(12, 190)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl12.TabIndex = 98
        Me.LabelControl12.Text = "Schedule"
        Me.LabelControl12.UseMnemonic = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 97
        Me.LabelControl1.Text = "Afa No"
        Me.LabelControl1.UseMnemonic = False
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(902, 211)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'btnupdate
        '
        Me.btnupdate.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.btnupdate.Location = New System.Drawing.Point(237, 420)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(124, 33)
        Me.btnupdate.TabIndex = 112
        Me.btnupdate.Text = "Update"
        '
        'XtraFormSendNoteBudget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 684)
        Me.Controls.Add(Me.SplitContainer1)
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormSendNoteBudget.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormSendNoteBudget"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Note Budget"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.TxtEst_Cost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSchedule.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbreason As ComboBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnSend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtAfa As TextBox
    Friend WithEvents TxtEst_Cost As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSubject As TextBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSchedule As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtnotebudget As TextBox
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblid As Label
    Friend WithEvents btnupdate As DevExpress.XtraEditors.SimpleButton
End Class
