<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormUnconfiguredDocuments
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
        Me.GridControlUnconfiguredDocuments = New DevExpress.XtraGrid.GridControl()
        Me.GridViewUnconfiguredDocuments = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControlUnconfiguredDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewUnconfiguredDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.BtnReload)
        Me.LayoutControl1.Controls.Add(Me.GridControlUnconfiguredDocuments)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(986, 514)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'BtnReload
        '
        Me.BtnReload.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnReload.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReload.Appearance.Options.UseBackColor = True
        Me.BtnReload.Appearance.Options.UseFont = True
        Me.BtnReload.Location = New System.Drawing.Point(12, 478)
        Me.BtnReload.Name = "BtnReload"
        Me.BtnReload.Size = New System.Drawing.Size(962, 24)
        Me.BtnReload.StyleController = Me.LayoutControl1
        Me.BtnReload.TabIndex = 5
        Me.BtnReload.Text = "Reload"
        '
        'GridControlUnconfiguredDocuments
        '
        Me.GridControlUnconfiguredDocuments.Location = New System.Drawing.Point(12, 12)
        Me.GridControlUnconfiguredDocuments.MainView = Me.GridViewUnconfiguredDocuments
        Me.GridControlUnconfiguredDocuments.Name = "GridControlUnconfiguredDocuments"
        Me.GridControlUnconfiguredDocuments.Size = New System.Drawing.Size(962, 462)
        Me.GridControlUnconfiguredDocuments.TabIndex = 4
        Me.GridControlUnconfiguredDocuments.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewUnconfiguredDocuments})
        '
        'GridViewUnconfiguredDocuments
        '
        Me.GridViewUnconfiguredDocuments.Appearance.HeaderPanel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridViewUnconfiguredDocuments.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridViewUnconfiguredDocuments.GridControl = Me.GridControlUnconfiguredDocuments
        Me.GridViewUnconfiguredDocuments.Name = "GridViewUnconfiguredDocuments"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(986, 514)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControlUnconfiguredDocuments
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(966, 466)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.BtnReload
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 466)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(966, 28)
        Me.LayoutControlItem2.TextVisible = False
        '
        'XtraFormUnconfiguredDocuments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 514)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = Global.AFASYSTEM.My.Resources.Resources.icondunlop
        Me.Name = "XtraFormUnconfiguredDocuments"
        Me.Text = "Unconfigured Documents"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControlUnconfiguredDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewUnconfiguredDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControlUnconfiguredDocuments As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewUnconfiguredDocuments As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnReload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
