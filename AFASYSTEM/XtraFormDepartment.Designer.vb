<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormDepartment
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.GridControlDepartment = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDepartment = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEditDepartmentName = New DevExpress.XtraEditors.TextEdit()
        Me.LciDepartmentName = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TextEditDepartmentCode = New DevExpress.XtraEditors.TextEdit()
        Me.LciDepartmentCode = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BtnSaveUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BtnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditDepartmentName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciDepartmentName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditDepartmentCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciDepartmentCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.BtnRefresh)
        Me.LayoutControl1.Controls.Add(Me.BtnSaveUpdate)
        Me.LayoutControl1.Controls.Add(Me.BtnExit)
        Me.LayoutControl1.Controls.Add(Me.TextEditDepartmentCode)
        Me.LayoutControl1.Controls.Add(Me.TextEditDepartmentName)
        Me.LayoutControl1.Controls.Add(Me.GridControlDepartment)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(777, 420)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LciDepartmentName, Me.LciDepartmentCode, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(777, 420)
        Me.Root.TextVisible = False
        '
        'GridControlDepartment
        '
        Me.GridControlDepartment.Location = New System.Drawing.Point(12, 84)
        Me.GridControlDepartment.MainView = Me.GridViewDepartment
        Me.GridControlDepartment.Name = "GridControlDepartment"
        Me.GridControlDepartment.Size = New System.Drawing.Size(753, 296)
        Me.GridControlDepartment.TabIndex = 4
        Me.GridControlDepartment.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDepartment})
        '
        'GridViewDepartment
        '
        Me.GridViewDepartment.GridControl = Me.GridControlDepartment
        Me.GridViewDepartment.Name = "GridViewDepartment"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControlDepartment
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(757, 300)
        Me.LayoutControlItem1.TextVisible = False
        '
        'TextEditDepartmentName
        '
        Me.TextEditDepartmentName.Location = New System.Drawing.Point(12, 32)
        Me.TextEditDepartmentName.Name = "TextEditDepartmentName"
        Me.TextEditDepartmentName.Size = New System.Drawing.Size(374, 20)
        Me.TextEditDepartmentName.StyleController = Me.LayoutControl1
        Me.TextEditDepartmentName.TabIndex = 5
        '
        'LciDepartmentName
        '
        Me.LciDepartmentName.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LciDepartmentName.AppearanceItemCaption.Options.UseFont = True
        Me.LciDepartmentName.Control = Me.TextEditDepartmentName
        Me.LciDepartmentName.Location = New System.Drawing.Point(0, 0)
        Me.LciDepartmentName.Name = "LciDepartmentName"
        Me.LciDepartmentName.Size = New System.Drawing.Size(378, 44)
        Me.LciDepartmentName.Text = "Department"
        Me.LciDepartmentName.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciDepartmentName.TextSize = New System.Drawing.Size(74, 17)
        '
        'TextEditDepartmentCode
        '
        Me.TextEditDepartmentCode.Location = New System.Drawing.Point(390, 32)
        Me.TextEditDepartmentCode.Name = "TextEditDepartmentCode"
        Me.TextEditDepartmentCode.Size = New System.Drawing.Size(375, 20)
        Me.TextEditDepartmentCode.StyleController = Me.LayoutControl1
        Me.TextEditDepartmentCode.TabIndex = 6
        '
        'LciDepartmentCode
        '
        Me.LciDepartmentCode.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LciDepartmentCode.AppearanceItemCaption.Options.UseFont = True
        Me.LciDepartmentCode.Control = Me.TextEditDepartmentCode
        Me.LciDepartmentCode.Location = New System.Drawing.Point(378, 0)
        Me.LciDepartmentCode.Name = "LciDepartmentCode"
        Me.LciDepartmentCode.Size = New System.Drawing.Size(379, 44)
        Me.LciDepartmentCode.Text = "Code"
        Me.LciDepartmentCode.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciDepartmentCode.TextSize = New System.Drawing.Size(74, 17)
        '
        'BtnExit
        '
        Me.BtnExit.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.BtnExit.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Appearance.Options.UseBackColor = True
        Me.BtnExit.Appearance.Options.UseFont = True
        Me.BtnExit.Location = New System.Drawing.Point(12, 56)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(374, 24)
        Me.BtnExit.StyleController = Me.LayoutControl1
        Me.BtnExit.TabIndex = 7
        Me.BtnExit.Text = "Exit"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.BtnExit
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 44)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(378, 28)
        Me.LayoutControlItem2.TextVisible = False
        '
        'BtnSaveUpdate
        '
        Me.BtnSaveUpdate.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        Me.BtnSaveUpdate.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSaveUpdate.Appearance.Options.UseBackColor = True
        Me.BtnSaveUpdate.Appearance.Options.UseFont = True
        Me.BtnSaveUpdate.Location = New System.Drawing.Point(390, 56)
        Me.BtnSaveUpdate.Name = "BtnSaveUpdate"
        Me.BtnSaveUpdate.Size = New System.Drawing.Size(375, 24)
        Me.BtnSaveUpdate.StyleController = Me.LayoutControl1
        Me.BtnSaveUpdate.TabIndex = 8
        Me.BtnSaveUpdate.Text = "Save"
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.BtnSaveUpdate
        Me.LayoutControlItem3.Location = New System.Drawing.Point(378, 44)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(379, 28)
        Me.LayoutControlItem3.TextVisible = False
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnRefresh.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefresh.Appearance.Options.UseBackColor = True
        Me.BtnRefresh.Appearance.Options.UseFont = True
        Me.BtnRefresh.Location = New System.Drawing.Point(12, 384)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(753, 24)
        Me.BtnRefresh.StyleController = Me.LayoutControl1
        Me.BtnRefresh.TabIndex = 9
        Me.BtnRefresh.Text = "Reload"
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.BtnRefresh
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 372)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(757, 28)
        Me.LayoutControlItem4.TextVisible = False
        '
        'XtraFormDepartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 420)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = Global.AFASYSTEM.My.Resources.Resources.icondunlop
        Me.Name = "XtraFormDepartment"
        Me.Text = "XtraFormDepartment"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditDepartmentName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciDepartmentName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditDepartmentCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciDepartmentCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControlDepartment As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDepartment As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEditDepartmentCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEditDepartmentName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LciDepartmentName As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LciDepartmentCode As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnSaveUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
End Class
