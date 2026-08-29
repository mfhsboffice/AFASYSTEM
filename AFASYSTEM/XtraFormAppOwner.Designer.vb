<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormAppOwner
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormAppOwner))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DtApp = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CkAll = New System.Windows.Forms.CheckBox()
        Me.RApp = New System.Windows.Forms.RadioButton()
        Me.btnShow = New DevExpress.XtraEditors.SimpleButton()
        Me.RUnApp = New System.Windows.Forms.RadioButton()
        Me.lblnik = New System.Windows.Forms.Label()
        Me.CmbApprover = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgView = New System.Windows.Forms.DataGridView()
        Me.Chek = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblAfa = New System.Windows.Forms.Label()
        Me.BtnUpp1 = New System.Windows.Forms.Button()
        Me.TxtAtt1 = New System.Windows.Forms.TextBox()
        Me.BtnAtt1 = New System.Windows.Forms.Button()
        Me.lblPesan = New System.Windows.Forms.Label()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DgView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.DtApp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CkAll)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RApp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnShow)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RUnApp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblnik)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbApprover)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgView)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(777, 569)
        Me.SplitContainer1.SplitterDistance = 165
        Me.SplitContainer1.TabIndex = 0
        '
        'DtApp
        '
        Me.DtApp.CustomFormat = "dd MMM yyyy HH:mm"
        Me.DtApp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtApp.Location = New System.Drawing.Point(119, 42)
        Me.DtApp.Name = "DtApp"
        Me.DtApp.Size = New System.Drawing.Size(200, 22)
        Me.DtApp.TabIndex = 89
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Date Approve"
        '
        'CkAll
        '
        Me.CkAll.AutoSize = True
        Me.CkAll.Location = New System.Drawing.Point(9, 145)
        Me.CkAll.Name = "CkAll"
        Me.CkAll.Size = New System.Drawing.Size(72, 17)
        Me.CkAll.TabIndex = 87
        Me.CkAll.Text = "Select All"
        Me.CkAll.UseVisualStyleBackColor = True
        '
        'RApp
        '
        Me.RApp.AutoSize = True
        Me.RApp.Checked = True
        Me.RApp.Location = New System.Drawing.Point(121, 92)
        Me.RApp.Name = "RApp"
        Me.RApp.Size = New System.Drawing.Size(68, 17)
        Me.RApp.TabIndex = 86
        Me.RApp.TabStop = True
        Me.RApp.Text = "Approve"
        Me.RApp.UseVisualStyleBackColor = True
        '
        'btnShow
        '
        Me.btnShow.ImageOptions.Image = CType(resources.GetObject("btnShow.ImageOptions.Image"), System.Drawing.Image)
        Me.btnShow.Location = New System.Drawing.Point(319, 84)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(124, 33)
        Me.btnShow.TabIndex = 85
        Me.btnShow.Text = "View Data"
        '
        'RUnApp
        '
        Me.RUnApp.AutoSize = True
        Me.RUnApp.Location = New System.Drawing.Point(214, 92)
        Me.RUnApp.Name = "RUnApp"
        Me.RUnApp.Size = New System.Drawing.Size(83, 17)
        Me.RUnApp.TabIndex = 83
        Me.RUnApp.Text = "Disapprove"
        Me.RUnApp.UseVisualStyleBackColor = True
        '
        'lblnik
        '
        Me.lblnik.AutoSize = True
        Me.lblnik.Location = New System.Drawing.Point(365, 18)
        Me.lblnik.Name = "lblnik"
        Me.lblnik.Size = New System.Drawing.Size(0, 13)
        Me.lblnik.TabIndex = 2
        Me.lblnik.Visible = False
        '
        'CmbApprover
        '
        Me.CmbApprover.FormattingEnabled = True
        Me.CmbApprover.Location = New System.Drawing.Point(119, 10)
        Me.CmbApprover.Name = "CmbApprover"
        Me.CmbApprover.Size = New System.Drawing.Size(240, 21)
        Me.CmbApprover.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Approver as"
        '
        'DgView
        '
        Me.DgView.AllowUserToAddRows = False
        Me.DgView.AllowUserToDeleteRows = False
        Me.DgView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DgView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Chek})
        Me.DgView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgView.Location = New System.Drawing.Point(0, 0)
        Me.DgView.Name = "DgView"
        Me.DgView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DgView.RowHeadersVisible = False
        Me.DgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgView.Size = New System.Drawing.Size(777, 280)
        Me.DgView.TabIndex = 12
        '
        'Chek
        '
        Me.Chek.FalseValue = "False"
        Me.Chek.HeaderText = "Ok"
        Me.Chek.Name = "Chek"
        Me.Chek.Width = 28
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblAfa)
        Me.Panel1.Controls.Add(Me.BtnUpp1)
        Me.Panel1.Controls.Add(Me.TxtAtt1)
        Me.Panel1.Controls.Add(Me.BtnAtt1)
        Me.Panel1.Controls.Add(Me.lblPesan)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.BtnExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 280)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(777, 120)
        Me.Panel1.TabIndex = 0
        '
        'lblAfa
        '
        Me.lblAfa.AutoSize = True
        Me.lblAfa.Location = New System.Drawing.Point(130, 23)
        Me.lblAfa.Name = "lblAfa"
        Me.lblAfa.Size = New System.Drawing.Size(0, 13)
        Me.lblAfa.TabIndex = 90
        '
        'BtnUpp1
        '
        Me.BtnUpp1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.BtnUpp1.FlatAppearance.BorderSize = 0
        Me.BtnUpp1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpp1.Location = New System.Drawing.Point(537, 20)
        Me.BtnUpp1.Name = "BtnUpp1"
        Me.BtnUpp1.Size = New System.Drawing.Size(75, 23)
        Me.BtnUpp1.TabIndex = 100078
        Me.BtnUpp1.Text = "Upload"
        Me.BtnUpp1.UseVisualStyleBackColor = False
        '
        'TxtAtt1
        '
        Me.TxtAtt1.BackColor = System.Drawing.Color.White
        Me.TxtAtt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAtt1.Location = New System.Drawing.Point(319, 20)
        Me.TxtAtt1.MaxLength = 100
        Me.TxtAtt1.Name = "TxtAtt1"
        Me.TxtAtt1.ReadOnly = True
        Me.TxtAtt1.Size = New System.Drawing.Size(212, 20)
        Me.TxtAtt1.TabIndex = 100077
        '
        'BtnAtt1
        '
        Me.BtnAtt1.Location = New System.Drawing.Point(18, 18)
        Me.BtnAtt1.Name = "BtnAtt1"
        Me.BtnAtt1.Size = New System.Drawing.Size(106, 23)
        Me.BtnAtt1.TabIndex = 100076
        Me.BtnAtt1.Text = "Attachment"
        Me.BtnAtt1.UseVisualStyleBackColor = True
        '
        'lblPesan
        '
        Me.lblPesan.AutoSize = True
        Me.lblPesan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesan.ForeColor = System.Drawing.Color.Blue
        Me.lblPesan.Location = New System.Drawing.Point(15, 44)
        Me.lblPesan.Name = "lblPesan"
        Me.lblPesan.Size = New System.Drawing.Size(0, 17)
        Me.lblPesan.TabIndex = 85
        '
        'BtnSave
        '
        Me.BtnSave.ImageOptions.Image = CType(resources.GetObject("BtnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(16, 75)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(124, 33)
        Me.BtnSave.TabIndex = 83
        Me.BtnSave.Text = "Save"
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(146, 75)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(124, 33)
        Me.BtnExit.TabIndex = 84
        Me.BtnExit.Text = "Exit"
        '
        'XtraFormAppOwner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 569)
        Me.Controls.Add(Me.SplitContainer1)
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormAppOwner.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormAppOwner"
        Me.Text = "Approver Owner"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents lblnik As Label
    Friend WithEvents CmbApprover As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnShow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RUnApp As RadioButton
    Friend WithEvents RApp As RadioButton
    Friend WithEvents CkAll As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DgView As DataGridView
    Friend WithEvents Chek As DataGridViewCheckBoxColumn
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPesan As Label
    Friend WithEvents DtApp As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents BtnUpp1 As Button
    Friend WithEvents TxtAtt1 As TextBox
    Friend WithEvents BtnAtt1 As Button
    Friend WithEvents lblAfa As Label
End Class
