<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XtraFormApproval
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormApproval))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.btnNote = New DevExpress.XtraEditors.SimpleButton()
        Me.CkAll = New System.Windows.Forms.CheckBox()
        Me.btnShow = New DevExpress.XtraEditors.SimpleButton()
        Me.lblafa = New System.Windows.Forms.Label()
        Me.lbllink = New System.Windows.Forms.Label()
        Me.RUnApp = New System.Windows.Forms.RadioButton()
        Me.RApp = New System.Windows.Forms.RadioButton()
        Me.DgView = New System.Windows.Forms.DataGridView()
        Me.Chek = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtmnViewDoc = New DevExpress.XtraEditors.SimpleButton()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnNote)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CkAll)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnShow)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblafa)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbllink)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RUnApp)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RApp)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DgView)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(823, 519)
        Me.SplitContainer1.SplitterDistance = 113
        Me.SplitContainer1.TabIndex = 0
        '
        'btnNote
        '
        Me.btnNote.ImageOptions.Image = CType(resources.GetObject("btnNote.ImageOptions.Image"), System.Drawing.Image)
        Me.btnNote.Location = New System.Drawing.Point(371, 24)
        Me.btnNote.Name = "btnNote"
        Me.btnNote.Size = New System.Drawing.Size(116, 33)
        Me.btnNote.TabIndex = 86
        Me.btnNote.Text = "Note Budget"
        '
        'CkAll
        '
        Me.CkAll.AutoSize = True
        Me.CkAll.Location = New System.Drawing.Point(13, 68)
        Me.CkAll.Name = "CkAll"
        Me.CkAll.Size = New System.Drawing.Size(72, 17)
        Me.CkAll.TabIndex = 83
        Me.CkAll.Text = "Select All"
        Me.CkAll.UseVisualStyleBackColor = True
        '
        'btnShow
        '
        Me.btnShow.ImageOptions.Image = CType(resources.GetObject("btnShow.ImageOptions.Image"), System.Drawing.Image)
        Me.btnShow.Location = New System.Drawing.Point(228, 24)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(124, 33)
        Me.btnShow.TabIndex = 82
        Me.btnShow.Text = "View Data"
        '
        'lblafa
        '
        Me.lblafa.AutoSize = True
        Me.lblafa.Location = New System.Drawing.Point(580, 52)
        Me.lblafa.Name = "lblafa"
        Me.lblafa.Size = New System.Drawing.Size(0, 13)
        Me.lblafa.TabIndex = 3
        Me.lblafa.Visible = False
        '
        'lbllink
        '
        Me.lbllink.AutoSize = True
        Me.lbllink.Location = New System.Drawing.Point(493, 52)
        Me.lbllink.Name = "lbllink"
        Me.lbllink.Size = New System.Drawing.Size(0, 13)
        Me.lbllink.TabIndex = 2
        Me.lbllink.Visible = False
        '
        'RUnApp
        '
        Me.RUnApp.AutoSize = True
        Me.RUnApp.Location = New System.Drawing.Point(136, 32)
        Me.RUnApp.Name = "RUnApp"
        Me.RUnApp.Size = New System.Drawing.Size(83, 17)
        Me.RUnApp.TabIndex = 1
        Me.RUnApp.Text = "Disapprove"
        Me.RUnApp.UseVisualStyleBackColor = True
        '
        'RApp
        '
        Me.RApp.AutoSize = True
        Me.RApp.Checked = True
        Me.RApp.Location = New System.Drawing.Point(22, 32)
        Me.RApp.Name = "RApp"
        Me.RApp.Size = New System.Drawing.Size(68, 17)
        Me.RApp.TabIndex = 0
        Me.RApp.TabStop = True
        Me.RApp.Text = "Approve"
        Me.RApp.UseVisualStyleBackColor = True
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
        Me.DgView.Size = New System.Drawing.Size(823, 300)
        Me.DgView.TabIndex = 11
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
        Me.Panel1.Controls.Add(Me.BtmnViewDoc)
        Me.Panel1.Controls.Add(Me.lblPesan)
        Me.Panel1.Controls.Add(Me.BtnSave)
        Me.Panel1.Controls.Add(Me.BtnExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 300)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(823, 102)
        Me.Panel1.TabIndex = 0
        '
        'BtmnViewDoc
        '
        Me.BtmnViewDoc.ImageOptions.Image = CType(resources.GetObject("BtmnViewDoc.ImageOptions.Image"), System.Drawing.Image)
        Me.BtmnViewDoc.Location = New System.Drawing.Point(145, 57)
        Me.BtmnViewDoc.Name = "BtmnViewDoc"
        Me.BtmnViewDoc.Size = New System.Drawing.Size(116, 33)
        Me.BtmnViewDoc.TabIndex = 85
        Me.BtmnViewDoc.Text = "View AFA"
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
        Me.BtnSave.Text = "Save"
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(267, 57)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(124, 33)
        Me.BtnExit.TabIndex = 82
        Me.BtnExit.Text = "Exit"
        '
        'XtraFormApproval
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 519)
        Me.Controls.Add(Me.SplitContainer1)
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormApproval.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormApproval"
        Me.Text = "Approval"
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
    Friend WithEvents RUnApp As RadioButton
    Friend WithEvents RApp As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblPesan As Label
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbllink As Label
    Friend WithEvents lblafa As Label
    Friend WithEvents DgView As DataGridView
    Friend WithEvents Chek As DataGridViewCheckBoxColumn
    Friend WithEvents btnShow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CkAll As CheckBox
    Friend WithEvents BtmnViewDoc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNote As DevExpress.XtraEditors.SimpleButton
End Class
