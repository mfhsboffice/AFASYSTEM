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
        Me.BtnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSaveUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnClear = New DevExpress.XtraEditors.SimpleButton()
        Me.CheckedComboDepartments = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.GridControlUserDepartments = New DevExpress.XtraGrid.GridControl()
        Me.GridViewUserDepartments = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LciGrid = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciDepartments = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciBtnClear = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciBtnSave = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciBtnRefresh = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ComboBoxEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LciEmployee = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.CheckedComboDepartments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlUserDepartments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewUserDepartments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciDepartments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciBtnClear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciBtnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciBtnRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ComboBoxEdit1)
        Me.LayoutControl1.Controls.Add(Me.BtnRefresh)
        Me.LayoutControl1.Controls.Add(Me.BtnSaveUpdate)
        Me.LayoutControl1.Controls.Add(Me.BtnClear)
        Me.LayoutControl1.Controls.Add(Me.CheckedComboDepartments)
        Me.LayoutControl1.Controls.Add(Me.GridControlUserDepartments)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(758, 537)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
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
        'CheckedComboDepartments
        '
        Me.CheckedComboDepartments.Location = New System.Drawing.Point(12, 76)
        Me.CheckedComboDepartments.Name = "CheckedComboDepartments"
        Me.CheckedComboDepartments.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CheckedComboDepartments.Size = New System.Drawing.Size(734, 20)
        Me.CheckedComboDepartments.StyleController = Me.LayoutControl1
        Me.CheckedComboDepartments.TabIndex = 7
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
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LciGrid, Me.LciDepartments, Me.LciBtnClear, Me.LciBtnSave, Me.LciBtnRefresh, Me.LciEmployee})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(758, 537)
        Me.Root.TextVisible = False
        '
        'LciGrid
        '
        Me.LciGrid.Control = Me.GridControlUserDepartments
        Me.LciGrid.Location = New System.Drawing.Point(0, 116)
        Me.LciGrid.Name = "LciGrid"
        Me.LciGrid.Size = New System.Drawing.Size(738, 373)
        Me.LciGrid.TextVisible = False
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
        'LciBtnClear
        '
        Me.LciBtnClear.Control = Me.BtnClear
        Me.LciBtnClear.Location = New System.Drawing.Point(0, 88)
        Me.LciBtnClear.Name = "LciBtnClear"
        Me.LciBtnClear.Size = New System.Drawing.Size(369, 28)
        Me.LciBtnClear.TextVisible = False
        '
        'LciBtnSave
        '
        Me.LciBtnSave.Control = Me.BtnSaveUpdate
        Me.LciBtnSave.Location = New System.Drawing.Point(369, 88)
        Me.LciBtnSave.Name = "LciBtnSave"
        Me.LciBtnSave.Size = New System.Drawing.Size(369, 28)
        Me.LciBtnSave.TextVisible = False
        '
        'LciBtnRefresh
        '
        Me.LciBtnRefresh.Control = Me.BtnRefresh
        Me.LciBtnRefresh.Location = New System.Drawing.Point(0, 489)
        Me.LciBtnRefresh.Name = "LciBtnRefresh"
        Me.LciBtnRefresh.Size = New System.Drawing.Size(738, 28)
        Me.LciBtnRefresh.TextVisible = False
        '
        'ComboBoxEdit1
        '
        Me.ComboBoxEdit1.Location = New System.Drawing.Point(12, 32)
        Me.ComboBoxEdit1.Name = "ComboBoxEdit1"
        Me.ComboBoxEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComboBoxEdit1.Size = New System.Drawing.Size(734, 20)
        Me.ComboBoxEdit1.StyleController = Me.LayoutControl1
        Me.ComboBoxEdit1.TabIndex = 11
        '
        'LciEmployee
        '
        Me.LciEmployee.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LciEmployee.AppearanceItemCaption.Options.UseFont = True
        Me.LciEmployee.Control = Me.ComboBoxEdit1
        Me.LciEmployee.Location = New System.Drawing.Point(0, 0)
        Me.LciEmployee.Name = "LciEmployee"
        Me.LciEmployee.Size = New System.Drawing.Size(738, 44)
        Me.LciEmployee.Text = "Employee"
        Me.LciEmployee.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciEmployee.TextSize = New System.Drawing.Size(80, 17)
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
        CType(Me.CheckedComboDepartments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlUserDepartments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewUserDepartments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciDepartments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciBtnClear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciBtnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciBtnRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControlUserDepartments As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewUserDepartments As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LciGrid As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CheckedComboDepartments As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents LciDepartments As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnSaveUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnClear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LciBtnClear As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LciBtnSave As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LciBtnRefresh As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ComboBoxEdit1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LciEmployee As DevExpress.XtraLayout.LayoutControlItem
End Class