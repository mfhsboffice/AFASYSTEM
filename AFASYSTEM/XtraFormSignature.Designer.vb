<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XtraFormSignature
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormSignature))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblatth2 = New System.Windows.Forms.Label()
        Me.lblatth = New System.Windows.Forms.Label()
        Me.TxtAfa = New System.Windows.Forms.TextBox()
        Me.TxtEst_Cost = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSubject = New System.Windows.Forms.TextBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtSchedule = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DgAuth = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnUpp2 = New System.Windows.Forms.Button()
        Me.TxtAtt2 = New System.Windows.Forms.TextBox()
        Me.BtnAtt2 = New System.Windows.Forms.Button()
        Me.BtnUpp1 = New System.Windows.Forms.Button()
        Me.TxtAtt1 = New System.Windows.Forms.TextBox()
        Me.BtnAtt1 = New System.Windows.Forms.Button()
        Me.btnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSend = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPesan = New System.Windows.Forms.Label()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.TxtEst_Cost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSchedule.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgAuth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblatth2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblatth)
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgAuth)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(841, 627)
        Me.SplitContainer1.SplitterDistance = 237
        Me.SplitContainer1.TabIndex = 0
        '
        'lblatth2
        '
        Me.lblatth2.AutoSize = True
        Me.lblatth2.Location = New System.Drawing.Point(484, 209)
        Me.lblatth2.Name = "lblatth2"
        Me.lblatth2.Size = New System.Drawing.Size(0, 13)
        Me.lblatth2.TabIndex = 85
        Me.lblatth2.Visible = False
        '
        'lblatth
        '
        Me.lblatth.AutoSize = True
        Me.lblatth.Location = New System.Drawing.Point(349, 25)
        Me.lblatth.Name = "lblatth"
        Me.lblatth.Size = New System.Drawing.Size(0, 13)
        Me.lblatth.TabIndex = 84
        Me.lblatth.Visible = False
        '
        'TxtAfa
        '
        Me.TxtAfa.Location = New System.Drawing.Point(96, 25)
        Me.TxtAfa.Name = "TxtAfa"
        Me.TxtAfa.Size = New System.Drawing.Size(161, 22)
        Me.TxtAfa.TabIndex = 83
        '
        'TxtEst_Cost
        '
        Me.TxtEst_Cost.Location = New System.Drawing.Point(96, 207)
        Me.TxtEst_Cost.Name = "TxtEst_Cost"
        Me.TxtEst_Cost.Size = New System.Drawing.Size(335, 20)
        Me.TxtEst_Cost.TabIndex = 82
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(17, 210)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl4.TabIndex = 81
        Me.LabelControl4.Text = "Estimate Cost"
        Me.LabelControl4.UseMnemonic = False
        '
        'TxtSubject
        '
        Me.TxtSubject.Location = New System.Drawing.Point(96, 51)
        Me.TxtSubject.MaxLength = 99999
        Me.TxtSubject.Multiline = True
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtSubject.Size = New System.Drawing.Size(745, 120)
        Me.TxtSubject.TabIndex = 71
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(17, 51)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl2.TabIndex = 68
        Me.LabelControl2.Text = "Note"
        Me.LabelControl2.UseMnemonic = False
        '
        'TxtSchedule
        '
        Me.TxtSchedule.Location = New System.Drawing.Point(96, 181)
        Me.TxtSchedule.Name = "TxtSchedule"
        Me.TxtSchedule.Size = New System.Drawing.Size(335, 20)
        Me.TxtSchedule.TabIndex = 66
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(17, 184)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl12.TabIndex = 65
        Me.LabelControl12.Text = "Schedule"
        Me.LabelControl12.UseMnemonic = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 25)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 36
        Me.LabelControl1.Text = "Afa No"
        Me.LabelControl1.UseMnemonic = False
        '
        'DgAuth
        '
        Me.DgAuth.AllowUserToAddRows = False
        Me.DgAuth.AllowUserToDeleteRows = False
        Me.DgAuth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgAuth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgAuth.Location = New System.Drawing.Point(0, 0)
        Me.DgAuth.Name = "DgAuth"
        Me.DgAuth.RowHeadersVisible = False
        Me.DgAuth.Size = New System.Drawing.Size(841, 264)
        Me.DgAuth.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnUpp2)
        Me.Panel1.Controls.Add(Me.TxtAtt2)
        Me.Panel1.Controls.Add(Me.BtnAtt2)
        Me.Panel1.Controls.Add(Me.BtnUpp1)
        Me.Panel1.Controls.Add(Me.TxtAtt1)
        Me.Panel1.Controls.Add(Me.BtnAtt1)
        Me.Panel1.Controls.Add(Me.btnView)
        Me.Panel1.Controls.Add(Me.BtnSend)
        Me.Panel1.Controls.Add(Me.lblPesan)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.BtnExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 264)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(841, 122)
        Me.Panel1.TabIndex = 0
        '
        'BtnUpp2
        '
        Me.BtnUpp2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.BtnUpp2.FlatAppearance.BorderSize = 0
        Me.BtnUpp2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpp2.Location = New System.Drawing.Point(530, 45)
        Me.BtnUpp2.Name = "BtnUpp2"
        Me.BtnUpp2.Size = New System.Drawing.Size(75, 23)
        Me.BtnUpp2.TabIndex = 100078
        Me.BtnUpp2.Text = "Upload 2"
        Me.BtnUpp2.UseVisualStyleBackColor = False
        '
        'TxtAtt2
        '
        Me.TxtAtt2.BackColor = System.Drawing.Color.White
        Me.TxtAtt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAtt2.Location = New System.Drawing.Point(123, 48)
        Me.TxtAtt2.MaxLength = 100
        Me.TxtAtt2.Name = "TxtAtt2"
        Me.TxtAtt2.ReadOnly = True
        Me.TxtAtt2.Size = New System.Drawing.Size(401, 20)
        Me.TxtAtt2.TabIndex = 100077
        '
        'BtnAtt2
        '
        Me.BtnAtt2.Location = New System.Drawing.Point(11, 43)
        Me.BtnAtt2.Name = "BtnAtt2"
        Me.BtnAtt2.Size = New System.Drawing.Size(106, 23)
        Me.BtnAtt2.TabIndex = 100076
        Me.BtnAtt2.Text = "Attachment 2"
        Me.BtnAtt2.UseVisualStyleBackColor = True
        '
        'BtnUpp1
        '
        Me.BtnUpp1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.BtnUpp1.FlatAppearance.BorderSize = 0
        Me.BtnUpp1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpp1.Location = New System.Drawing.Point(530, 16)
        Me.BtnUpp1.Name = "BtnUpp1"
        Me.BtnUpp1.Size = New System.Drawing.Size(75, 23)
        Me.BtnUpp1.TabIndex = 100075
        Me.BtnUpp1.Text = "Upload 1"
        Me.BtnUpp1.UseVisualStyleBackColor = False
        '
        'TxtAtt1
        '
        Me.TxtAtt1.BackColor = System.Drawing.Color.White
        Me.TxtAtt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAtt1.Location = New System.Drawing.Point(123, 19)
        Me.TxtAtt1.MaxLength = 100
        Me.TxtAtt1.Name = "TxtAtt1"
        Me.TxtAtt1.ReadOnly = True
        Me.TxtAtt1.Size = New System.Drawing.Size(401, 20)
        Me.TxtAtt1.TabIndex = 100074
        '
        'BtnAtt1
        '
        Me.BtnAtt1.Location = New System.Drawing.Point(11, 14)
        Me.BtnAtt1.Name = "BtnAtt1"
        Me.BtnAtt1.Size = New System.Drawing.Size(106, 23)
        Me.BtnAtt1.TabIndex = 100073
        Me.BtnAtt1.Text = "Attachment 1"
        Me.BtnAtt1.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.ImageOptions.Image = CType(resources.GetObject("btnView.ImageOptions.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(16, 77)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(116, 33)
        Me.btnView.TabIndex = 83
        Me.btnView.Text = "View AFA"
        '
        'BtnSend
        '
        Me.BtnSend.ImageOptions.Image = CType(resources.GetObject("BtnSend.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSend.Location = New System.Drawing.Point(138, 77)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(124, 33)
        Me.BtnSend.TabIndex = 82
        Me.BtnSend.Text = "Send Req App"
        '
        'lblPesan
        '
        Me.lblPesan.AutoSize = True
        Me.lblPesan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesan.ForeColor = System.Drawing.Color.Blue
        Me.lblPesan.Location = New System.Drawing.Point(398, 71)
        Me.lblPesan.Name = "lblPesan"
        Me.lblPesan.Size = New System.Drawing.Size(0, 17)
        Me.lblPesan.TabIndex = 81
        '
        'BtnSave
        '
        Me.BtnSave.ImageOptions.Image = CType(resources.GetObject("BtnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(630, 11)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(124, 33)
        Me.BtnSave.TabIndex = 77
        Me.BtnSave.Text = "Save"
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(268, 77)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(124, 33)
        Me.BtnExit.TabIndex = 80
        Me.BtnExit.Text = "Exit"
        '
        'XtraFormSignature
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 627)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormSignature.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormSignature"
        Me.Text = "Signature AFA"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.TxtEst_Cost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSchedule.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgAuth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TxtSubject As TextBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtSchedule As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TxtEst_Cost As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DgAuth As DataGridView
    Friend WithEvents TxtAfa As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblPesan As Label
    Friend WithEvents BtnSend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnUpp1 As Button
    Friend WithEvents TxtAtt1 As TextBox
    Friend WithEvents BtnAtt1 As Button
    Friend WithEvents lblatth As Label
    Friend WithEvents BtnUpp2 As Button
    Friend WithEvents TxtAtt2 As TextBox
    Friend WithEvents BtnAtt2 As Button
    Friend WithEvents lblatth2 As Label
End Class
