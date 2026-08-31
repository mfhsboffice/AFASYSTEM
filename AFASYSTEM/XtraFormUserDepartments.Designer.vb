<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XtraFormUserDepartments
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.GridControlUserDepartments = New DevExpress.XtraGrid.GridControl()
        Me.GridViewUserDepartments = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LciGrid = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEditName = New DevExpress.XtraEditors.TextEdit()
        Me.LciUserName = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEditNik = New DevExpress.XtraEditors.TextEdit()
        Me.LciNik = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CheckedComboDepartments = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.LciDepartments = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BtnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.LciBtnClear = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BtnSaveUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.LciBtnSave = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BtnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.LciBtnRefresh = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlUserDepartments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewUserDepartments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciUserName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditNik.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciNik, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheckedComboDepartments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciDepartments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciBtnClear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciBtnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciBtnRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.BtnRefresh)
        Me.LayoutControl1.Controls.Add(Me.BtnSaveUpdate)
        Me.LayoutControl1.Controls.Add(Me.BtnClear)
        Me.LayoutControl1.Controls.Add(Me.CheckedComboDepartments)
        Me.LayoutControl1.Controls.Add(Me.TextEditNik)
        Me.LayoutControl1.Controls.Add(Me.TextEditName)
        Me.LayoutControl1.Controls.Add(Me.GridControlUserDepartments)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(758, 537)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LciGrid, Me.LciUserName, Me.LciNik, Me.LciDepartments, Me.LciBtnClear, Me.LciBtnSave, Me.LciBtnRefresh})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(758, 537)
        Me.Root.TextVisible = False
        '
        'GridControlUserDepartments
        '
        Me.GridControlUserDepartments.Location = New System.Drawing.Point(12, 128)
        Me.GridControlUserDepartments.MainView = Me.GridViewUserDepartments
        Me.GridControlUserDepartments.Name = "GridControlUserDepartments"
        Me.GridControlUserDepartments.Size = New System.Drawing.Size(734, 369)
        Me.GridControlUserDepartments.TabIndex = 4
        Me.GridControlUserDepartments.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewUserDepartments})
        '
        'GridViewUserDepartments
        '
        Me.GridViewUserDepartments.GridControl = Me.GridControlUserDepartments
        Me.GridViewUserDepartments.Name = "GridViewUserDepartments"
        '
        'LciGrid
        '
        Me.LciGrid.Control = Me.GridControlUserDepartments
        Me.LciGrid.Location = New System.Drawing.Point(0, 116)
        Me.LciGrid.Name = "LciGrid"
        Me.LciGrid.Size = New System.Drawing.Size(738, 373)
        Me.LciGrid.TextVisible = False
        '
        'TextEditName
        '
        Me.TextEditName.Location = New System.Drawing.Point(12, 32)
        Me.TextEditName.Name = "TextEditName"
        Me.TextEditName.Size = New System.Drawing.Size(365, 20)
        Me.TextEditName.StyleController = Me.LayoutControl1
        Me.TextEditName.TabIndex = 5
        '
        'LciUserName
        '
        Me.LciUserName.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LciUserName.AppearanceItemCaption.Options.UseFont = True
        Me.LciUserName.Control = Me.TextEditName
        Me.LciUserName.Location = New System.Drawing.Point(0, 0)
        Me.LciUserName.Name = "LciUserName"
        Me.LciUserName.Size = New System.Drawing.Size(369, 44)
        Me.LciUserName.Text = "Name"
        Me.LciUserName.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciUserName.TextSize = New System.Drawing.Size(80, 17)
        '
        'TextEditNik
        '
        Me.TextEditNik.Location = New System.Drawing.Point(381, 32)
        Me.TextEditNik.Name = "TextEditNik"
        Me.TextEditNik.Size = New System.Drawing.Size(365, 20)
        Me.TextEditNik.StyleController = Me.LayoutControl1
        Me.TextEditNik.TabIndex = 6
        '
        'LciNik
        '
        Me.LciNik.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LciNik.AppearanceItemCaption.Options.UseFont = True
        Me.LciNik.Control = Me.TextEditNik
        Me.LciNik.Location = New System.Drawing.Point(369, 0)
        Me.LciNik.Name = "LciNik"
        Me.LciNik.Size = New System.Drawing.Size(369, 44)
        Me.LciNik.Text = "NIK"
        Me.LciNik.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciNik.TextSize = New System.Drawing.Size(80, 17)
        '
        'CheckedComboDepartments
        '
        Me.CheckedComboDepartments.Location = New System.Drawing.Point(12, 76)
        Me.CheckedComboDepartments.Name = "CheckedComboDepartments"
        Me.CheckedComboDepartments.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CheckedComboDepartments.Size = New System.Drawing.Size(734, 20)
        Me.CheckedComboDepartments.StyleController = Me.LayoutControl1
        Me.CheckedComboDepartments.TabIndex = 7
        '
        'LciDepartments
        '
        Me.LciDepartments.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LciDepartments.AppearanceItemCaption.Options.UseFont = True
        Me.LciDepartments.Control = Me.CheckedComboDepartments
        Me.LciDepartments.Location = New System.Drawing.Point(0, 44)
        Me.LciDepartments.Name = "LciDepartments"
        Me.LciDepartments.Size = New System.Drawing.Size(738, 44)
        Me.LciDepartments.Text = "Departments"
        Me.LciDepartments.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciDepartments.TextSize = New System.Drawing.Size(80, 17)
        '
        'BtnClear
        '
        Me.BtnClear.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.BtnClear.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.Appearance.Options.UseBackColor = True
        Me.BtnClear.Appearance.Options.UseFont = True
        Me.BtnClear.Location = New System.Drawing.Point(12, 100)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(365, 24)
        Me.BtnClear.StyleController = Me.LayoutControl1
        Me.BtnClear.TabIndex = 8
        Me.BtnClear.Text = "Clear"
        '
        'LciBtnClear
        '
        Me.LciBtnClear.Control = Me.BtnClear
        Me.LciBtnClear.Location = New System.Drawing.Point(0, 88)
        Me.LciBtnClear.Name = "LciBtnClear"
        Me.LciBtnClear.Size = New System.Drawing.Size(369, 28)
        Me.LciBtnClear.TextVisible = False
        '
        'BtnSaveUpdate
        '
        Me.BtnSaveUpdate.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        Me.BtnSaveUpdate.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveUpdate.Appearance.Options.UseBackColor = True
        Me.BtnSaveUpdate.Appearance.Options.UseFont = True
        Me.BtnSaveUpdate.Location = New System.Drawing.Point(381, 100)
        Me.BtnSaveUpdate.Name = "BtnSaveUpdate"
        Me.BtnSaveUpdate.Size = New System.Drawing.Size(365, 24)
        Me.BtnSaveUpdate.StyleController = Me.LayoutControl1
        Me.BtnSaveUpdate.TabIndex = 9
        Me.BtnSaveUpdate.Text = "Save"
        '
        'LciBtnSave
        '
        Me.LciBtnSave.Control = Me.BtnSaveUpdate
        Me.LciBtnSave.Location = New System.Drawing.Point(369, 88)
        Me.LciBtnSave.Name = "LciBtnSave"
        Me.LciBtnSave.Size = New System.Drawing.Size(369, 28)
        Me.LciBtnSave.TextVisible = False
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnRefresh.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefresh.Appearance.Options.UseBackColor = True
        Me.BtnRefresh.Appearance.Options.UseFont = True
        Me.BtnRefresh.Location = New System.Drawing.Point(12, 501)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(734, 24)
        Me.BtnRefresh.StyleController = Me.LayoutControl1
        Me.BtnRefresh.TabIndex = 10
        Me.BtnRefresh.Text = "Reload"
        '
        'LciBtnRefresh
        '
        Me.LciBtnRefresh.Control = Me.BtnRefresh
        Me.LciBtnRefresh.Location = New System.Drawing.Point(0, 489)
        Me.LciBtnRefresh.Name = "LciBtnRefresh"
        Me.LciBtnRefresh.Size = New System.Drawing.Size(738, 28)
        Me.LciBtnRefresh.TextVisible = False
        '
        'XtraFormUserDepartments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 537)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = Global.AFASYSTEM.My.Resources.Resources.icondunlop
        Me.Name = "XtraFormUserDepartments"
        Me.Text = "User Department Mapping"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlUserDepartments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewUserDepartments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciUserName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditNik.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciNik, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheckedComboDepartments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciDepartments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciBtnClear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciBtnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciBtnRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControlUserDepartments As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewUserDepartments As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LciGrid As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEditName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LciUserName As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEditNik As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LciNik As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckedComboDepartments As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents LciDepartments As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnSaveUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LciBtnClear As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LciBtnSave As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LciBtnRefresh As DevExpress.XtraLayout.LayoutControlItem
End Class