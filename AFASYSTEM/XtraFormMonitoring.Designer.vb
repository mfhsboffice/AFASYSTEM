<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XtraFormMonitoring
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormMonitoring))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.RCancel = New System.Windows.Forms.RadioButton()
        Me.lblapaa = New System.Windows.Forms.Label()
        Me.TXTAFANO = New System.Windows.Forms.TextBox()
        Me.RAppIFS = New System.Windows.Forms.RadioButton()
        Me.lblafa = New System.Windows.Forms.Label()
        Me.BtmnViewDoc = New DevExpress.XtraEditors.SimpleButton()
        Me.RApp = New System.Windows.Forms.RadioButton()
        Me.ROnprog = New System.Windows.Forms.RadioButton()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnShow = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.RCancel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblapaa)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TXTAFANO)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RAppIFS)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblafa)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtmnViewDoc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RApp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ROnprog)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnExit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnShow)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1183, 642)
        Me.SplitContainer1.SplitterDistance = 60
        Me.SplitContainer1.TabIndex = 0
        '
        'RCancel
        '
        Me.RCancel.AutoSize = True
        Me.RCancel.Location = New System.Drawing.Point(196, 20)
        Me.RCancel.Name = "RCancel"
        Me.RCancel.Size = New System.Drawing.Size(75, 17)
        Me.RCancel.TabIndex = 92
        Me.RCancel.TabStop = True
        Me.RCancel.Text = "Cancelled"
        Me.RCancel.UseVisualStyleBackColor = True
        '
        'lblapaa
        '
        Me.lblapaa.AutoSize = True
        Me.lblapaa.Location = New System.Drawing.Point(396, 22)
        Me.lblapaa.Name = "lblapaa"
        Me.lblapaa.Size = New System.Drawing.Size(80, 13)
        Me.lblapaa.TabIndex = 91
        Me.lblapaa.Text = "INPUT AFA NO"
        '
        'TXTAFANO
        '
        Me.TXTAFANO.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TXTAFANO.Location = New System.Drawing.Point(482, 18)
        Me.TXTAFANO.Name = "TXTAFANO"
        Me.TXTAFANO.Size = New System.Drawing.Size(192, 22)
        Me.TXTAFANO.TabIndex = 90
        '
        'RAppIFS
        '
        Me.RAppIFS.AutoSize = True
        Me.RAppIFS.Location = New System.Drawing.Point(287, 20)
        Me.RAppIFS.Name = "RAppIFS"
        Me.RAppIFS.Size = New System.Drawing.Size(93, 17)
        Me.RAppIFS.TabIndex = 89
        Me.RAppIFS.Text = "Approved IFS"
        Me.RAppIFS.UseVisualStyleBackColor = True
        '
        'lblafa
        '
        Me.lblafa.AutoSize = True
        Me.lblafa.Location = New System.Drawing.Point(638, 13)
        Me.lblafa.Name = "lblafa"
        Me.lblafa.Size = New System.Drawing.Size(0, 13)
        Me.lblafa.TabIndex = 88
        Me.lblafa.Visible = False
        '
        'BtmnViewDoc
        '
        Me.BtmnViewDoc.ImageOptions.Image = CType(resources.GetObject("BtmnViewDoc.ImageOptions.Image"), System.Drawing.Image)
        Me.BtmnViewDoc.Location = New System.Drawing.Point(794, 7)
        Me.BtmnViewDoc.Name = "BtmnViewDoc"
        Me.BtmnViewDoc.Size = New System.Drawing.Size(96, 33)
        Me.BtmnViewDoc.TabIndex = 87
        Me.BtmnViewDoc.Text = "View AFA"
        '
        'RApp
        '
        Me.RApp.AutoSize = True
        Me.RApp.Location = New System.Drawing.Point(106, 18)
        Me.RApp.Name = "RApp"
        Me.RApp.Size = New System.Drawing.Size(75, 17)
        Me.RApp.TabIndex = 86
        Me.RApp.Text = "Approved"
        Me.RApp.UseVisualStyleBackColor = True
        '
        'ROnprog
        '
        Me.ROnprog.AutoSize = True
        Me.ROnprog.Checked = True
        Me.ROnprog.Location = New System.Drawing.Point(12, 20)
        Me.ROnprog.Name = "ROnprog"
        Me.ROnprog.Size = New System.Drawing.Size(88, 17)
        Me.ROnprog.TabIndex = 85
        Me.ROnprog.TabStop = True
        Me.ROnprog.Text = "On Progress"
        Me.ROnprog.UseVisualStyleBackColor = True
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(896, 7)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(73, 33)
        Me.BtnExit.TabIndex = 84
        Me.BtnExit.Text = "Exit"
        '
        'btnShow
        '
        Me.btnShow.ImageOptions.Image = CType(resources.GetObject("btnShow.ImageOptions.Image"), System.Drawing.Image)
        Me.btnShow.Location = New System.Drawing.Point(687, 7)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(101, 33)
        Me.btnShow.TabIndex = 83
        Me.btnShow.Text = "View Data"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1183, 578)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'XtraFormMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1183, 642)
        Me.Controls.Add(Me.SplitContainer1)
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormMonitoring.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormMonitoring"
        Me.Text = "Monitoring"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents btnShow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RApp As RadioButton
    Friend WithEvents ROnprog As RadioButton
    Friend WithEvents lblafa As Label
    Friend WithEvents BtmnViewDoc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RAppIFS As RadioButton
    Friend WithEvents lblapaa As Label
    Friend WithEvents TXTAFANO As TextBox
    Friend WithEvents RCancel As RadioButton
End Class
