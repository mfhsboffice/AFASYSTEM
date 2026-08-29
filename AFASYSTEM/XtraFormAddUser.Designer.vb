<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XtraFormAddUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormAddUser))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtEmail = New DevExpress.XtraEditors.TextEdit()
        Me.Txtpwd = New System.Windows.Forms.TextBox()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.CmbType = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtNama = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtUserid = New DevExpress.XtraEditors.TextEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.TxtEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtUserid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtEmail)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Txtpwd)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnSave)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnDelete)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnExit)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbType)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtNama)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TxtUserid)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(759, 598)
        Me.SplitContainer1.SplitterDistance = 161
        Me.SplitContainer1.TabIndex = 0
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(19, 130)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl7.TabIndex = 43
        Me.LabelControl7.Text = "Email"
        Me.LabelControl7.UseMnemonic = False
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(77, 127)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(182, 20)
        Me.TxtEmail.TabIndex = 2
        '
        'Txtpwd
        '
        Me.Txtpwd.Location = New System.Drawing.Point(77, 99)
        Me.Txtpwd.Name = "Txtpwd"
        Me.Txtpwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtpwd.ReadOnly = True
        Me.Txtpwd.Size = New System.Drawing.Size(121, 22)
        Me.Txtpwd.TabIndex = 29
        '
        'BtnSave
        '
        Me.BtnSave.ImageOptions.Image = CType(resources.GetObject("BtnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(328, 12)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(89, 33)
        Me.BtnSave.TabIndex = 3
        Me.BtnSave.Text = "Save"
        '
        'BtnDelete
        '
        Me.BtnDelete.ImageOptions.Image = CType(resources.GetObject("BtnDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(328, 51)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(89, 33)
        Me.BtnDelete.TabIndex = 4
        Me.BtnDelete.Text = "Delete"
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(328, 92)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(89, 33)
        Me.BtnExit.TabIndex = 5
        Me.BtnExit.Text = "Exit"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(19, 102)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(49, 13)
        Me.LabelControl4.TabIndex = 40
        Me.LabelControl4.Text = "Password"
        Me.LabelControl4.UseMnemonic = False
        '
        'CmbType
        '
        Me.CmbType.FormattingEnabled = True
        Me.CmbType.Items.AddRange(New Object() {"APP", "ENTRY"})
        Me.CmbType.Location = New System.Drawing.Point(77, 72)
        Me.CmbType.Name = "CmbType"
        Me.CmbType.Size = New System.Drawing.Size(121, 21)
        Me.CmbType.TabIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(19, 72)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 39
        Me.LabelControl3.Text = "Type"
        Me.LabelControl3.UseMnemonic = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(19, 46)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl2.TabIndex = 38
        Me.LabelControl2.Text = "Name"
        Me.LabelControl2.UseMnemonic = False
        '
        'TxtNama
        '
        Me.TxtNama.Location = New System.Drawing.Point(77, 43)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Size = New System.Drawing.Size(182, 20)
        Me.TxtNama.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(19, 20)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl1.TabIndex = 35
        Me.LabelControl1.Text = "UserId"
        Me.LabelControl1.UseMnemonic = False
        '
        'TxtUserid
        '
        Me.TxtUserid.Location = New System.Drawing.Point(77, 17)
        Me.TxtUserid.Name = "TxtUserid"
        Me.TxtUserid.Size = New System.Drawing.Size(92, 20)
        Me.TxtUserid.TabIndex = 0
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(759, 433)
        Me.GridControl1.TabIndex = 6
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'XtraFormAddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 598)
        Me.Controls.Add(Me.SplitContainer1)
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormAddUser.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormAddUser"
        Me.Text = "Add Approver"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.TxtEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtUserid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Txtpwd As TextBox
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CmbType As ComboBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtUserid As DevExpress.XtraEditors.TextEdit
End Class
