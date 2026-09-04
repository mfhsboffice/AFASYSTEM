<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormAFAMonitoring
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
        Me.BtnReload = New DevExpress.XtraEditors.SimpleButton()
        Me.SelectType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.SelectStatus = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.GridControlAFAMonitoring = New DevExpress.XtraGrid.GridControl()
        Me.GridViewAFAMonitoring = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciStatusAFA = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciType = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.SelectType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SelectStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlAFAMonitoring, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAFAMonitoring, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciStatusAFA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.BtnReload)
        Me.LayoutControl1.Controls.Add(Me.SelectType)
        Me.LayoutControl1.Controls.Add(Me.SelectStatus)
        Me.LayoutControl1.Controls.Add(Me.GridControlAFAMonitoring)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(899, 486)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'BtnReload
        '
        Me.BtnReload.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        Me.BtnReload.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReload.Appearance.Options.UseBackColor = True
        Me.BtnReload.Appearance.Options.UseFont = True
        Me.BtnReload.Location = New System.Drawing.Point(12, 450)
        Me.BtnReload.Name = "BtnReload"
        Me.BtnReload.Size = New System.Drawing.Size(875, 24)
        Me.BtnReload.StyleController = Me.LayoutControl1
        Me.BtnReload.TabIndex = 7
        Me.BtnReload.Text = "Load"
        '
        'SelectType
        '
        Me.SelectType.Location = New System.Drawing.Point(454, 35)
        Me.SelectType.Name = "SelectType"
        Me.SelectType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SelectType.Size = New System.Drawing.Size(430, 20)
        Me.SelectType.StyleController = Me.LayoutControl1
        Me.SelectType.TabIndex = 6
        '
        'SelectStatus
        '
        Me.SelectStatus.Location = New System.Drawing.Point(15, 35)
        Me.SelectStatus.Name = "SelectStatus"
        Me.SelectStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SelectStatus.Size = New System.Drawing.Size(429, 20)
        Me.SelectStatus.StyleController = Me.LayoutControl1
        Me.SelectStatus.TabIndex = 5
        '
        'GridControlAFAMonitoring
        '
        Me.GridControlAFAMonitoring.Location = New System.Drawing.Point(12, 62)
        Me.GridControlAFAMonitoring.MainView = Me.GridViewAFAMonitoring
        Me.GridControlAFAMonitoring.Name = "GridControlAFAMonitoring"
        Me.GridControlAFAMonitoring.Size = New System.Drawing.Size(875, 384)
        Me.GridControlAFAMonitoring.TabIndex = 4
        Me.GridControlAFAMonitoring.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAFAMonitoring})
        '
        'GridViewAFAMonitoring
        '
        Me.GridViewAFAMonitoring.Appearance.HeaderPanel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridViewAFAMonitoring.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridViewAFAMonitoring.GridControl = Me.GridControlAFAMonitoring
        Me.GridViewAFAMonitoring.Name = "GridViewAFAMonitoring"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LciStatusAFA, Me.LciType, Me.LayoutControlItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(899, 486)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControlAFAMonitoring
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(879, 388)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LciStatusAFA
        '
        Me.LciStatusAFA.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LciStatusAFA.AppearanceItemCaption.Options.UseFont = True
        Me.LciStatusAFA.Control = Me.SelectStatus
        Me.LciStatusAFA.Location = New System.Drawing.Point(0, 0)
        Me.LciStatusAFA.Name = "LciStatusAFA"
        Me.LciStatusAFA.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LciStatusAFA.Size = New System.Drawing.Size(439, 50)
        Me.LciStatusAFA.Text = "Status"
        Me.LciStatusAFA.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciStatusAFA.TextSize = New System.Drawing.Size(38, 17)
        '
        'LciType
        '
        Me.LciType.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LciType.AppearanceItemCaption.Options.UseFont = True
        Me.LciType.Control = Me.SelectType
        Me.LciType.Location = New System.Drawing.Point(439, 0)
        Me.LciType.Name = "LciType"
        Me.LciType.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5)
        Me.LciType.Size = New System.Drawing.Size(440, 50)
        Me.LciType.Text = "Type"
        Me.LciType.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciType.TextSize = New System.Drawing.Size(38, 17)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.BtnReload
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 438)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(879, 28)
        Me.LayoutControlItem2.TextVisible = False
        '
        'XtraFormAFAMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 486)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = Global.AFASYSTEM.My.Resources.Resources.icondunlop
        Me.Name = "XtraFormAFAMonitoring"
        Me.Text = "Monitoring AFA"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.SelectType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SelectStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlAFAMonitoring, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAFAMonitoring, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciStatusAFA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControlAFAMonitoring As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAFAMonitoring As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SelectStatus As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LciStatusAFA As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SelectType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LciType As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnReload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
