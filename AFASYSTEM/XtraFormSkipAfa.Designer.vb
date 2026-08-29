<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XtraFormSkipAfa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormSkipAfa))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblPesan = New System.Windows.Forms.Label()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblnik = New DevExpress.XtraEditors.LabelControl()
        Me.Txtniknama = New System.Windows.Forms.TextBox()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtType = New System.Windows.Forms.TextBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtAfa = New System.Windows.Forms.TextBox()
        Me.TxtSubject = New System.Windows.Forms.TextBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.btnShow = New DevExpress.XtraEditors.SimpleButton()
        Me.CmbReason = New System.Windows.Forms.ComboBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DgView = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblPesan)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.BtnExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 534)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(962, 102)
        Me.Panel1.TabIndex = 1
        '
        'lblPesan
        '
        Me.lblPesan.AutoSize = True
        Me.lblPesan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesan.ForeColor = System.Drawing.Color.Blue
        Me.lblPesan.Location = New System.Drawing.Point(19, 20)
        Me.lblPesan.Name = "lblPesan"
        Me.lblPesan.Size = New System.Drawing.Size(0, 17)
        Me.lblPesan.TabIndex = 83
        '
        'BtnSave
        '
        Me.BtnSave.ImageOptions.Image = CType(resources.GetObject("BtnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(15, 57)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(124, 33)
        Me.BtnSave.TabIndex = 81
        Me.BtnSave.Text = "Skip"
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(145, 57)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(124, 33)
        Me.BtnExit.TabIndex = 82
        Me.BtnExit.Text = "Exit"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblnik)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Txtniknama)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtAfa)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtSubject)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnShow)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbReason)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgView)
        Me.SplitContainer1.Size = New System.Drawing.Size(962, 534)
        Me.SplitContainer1.SplitterDistance = 242
        Me.SplitContainer1.TabIndex = 2
        '
        'lblnik
        '
        Me.lblnik.Location = New System.Drawing.Point(510, 200)
        Me.lblnik.Name = "lblnik"
        Me.lblnik.Size = New System.Drawing.Size(0, 13)
        Me.lblnik.TabIndex = 91
        Me.lblnik.UseMnemonic = False
        Me.lblnik.Visible = False
        '
        'Txtniknama
        '
        Me.Txtniknama.Location = New System.Drawing.Point(87, 197)
        Me.Txtniknama.Name = "Txtniknama"
        Me.Txtniknama.ReadOnly = True
        Me.Txtniknama.Size = New System.Drawing.Size(348, 22)
        Me.Txtniknama.TabIndex = 90
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(16, 200)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl5.TabIndex = 89
        Me.LabelControl5.Text = "NIK / Nama"
        Me.LabelControl5.UseMnemonic = False
        '
        'TxtType
        '
        Me.TxtType.Location = New System.Drawing.Point(87, 169)
        Me.TxtType.Name = "TxtType"
        Me.TxtType.ReadOnly = True
        Me.TxtType.Size = New System.Drawing.Size(114, 22)
        Me.TxtType.TabIndex = 88
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(16, 172)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl4.TabIndex = 87
        Me.LabelControl4.Text = "Type"
        Me.LabelControl4.UseMnemonic = False
        '
        'TxtAfa
        '
        Me.TxtAfa.Location = New System.Drawing.Point(87, 12)
        Me.TxtAfa.Name = "TxtAfa"
        Me.TxtAfa.Size = New System.Drawing.Size(161, 22)
        Me.TxtAfa.TabIndex = 86
        '
        'TxtSubject
        '
        Me.TxtSubject.Location = New System.Drawing.Point(87, 44)
        Me.TxtSubject.MaxLength = 99999
        Me.TxtSubject.Multiline = True
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtSubject.Size = New System.Drawing.Size(745, 83)
        Me.TxtSubject.TabIndex = 85
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(16, 38)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl3.TabIndex = 84
        Me.LabelControl3.Text = "Note"
        Me.LabelControl3.UseMnemonic = False
        '
        'btnShow
        '
        Me.btnShow.ImageOptions.Image = CType(resources.GetObject("btnShow.ImageOptions.Image"), System.Drawing.Image)
        Me.btnShow.Location = New System.Drawing.Point(337, 5)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(124, 33)
        Me.btnShow.TabIndex = 83
        Me.btnShow.Text = "View Data"
        '
        'CmbReason
        '
        Me.CmbReason.FormattingEnabled = True
        Me.CmbReason.Location = New System.Drawing.Point(87, 133)
        Me.CmbReason.Name = "CmbReason"
        Me.CmbReason.Size = New System.Drawing.Size(232, 21)
        Me.CmbReason.TabIndex = 7
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(15, 141)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Reason"
        Me.LabelControl2.UseMnemonic = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Afa No"
        Me.LabelControl1.UseMnemonic = False
        '
        'DgView
        '
        Me.DgView.AllowUserToAddRows = False
        Me.DgView.AllowUserToDeleteRows = False
        Me.DgView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DgView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgView.Location = New System.Drawing.Point(0, 0)
        Me.DgView.Name = "DgView"
        Me.DgView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DgView.RowHeadersVisible = False
        Me.DgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgView.Size = New System.Drawing.Size(962, 288)
        Me.DgView.TabIndex = 12
        '
        'XtraFormSkipAfa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(962, 636)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel1)
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormSkipAfa.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormSkipAfa"
        Me.Text = "Skip Afa"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblPesan As Label
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DgView As DataGridView
    Friend WithEvents CmbReason As ComboBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnShow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtSubject As TextBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtAfa As TextBox
    Friend WithEvents Txtniknama As TextBox
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtType As TextBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblnik As DevExpress.XtraEditors.LabelControl
End Class
