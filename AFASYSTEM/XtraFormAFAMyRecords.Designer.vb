<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormAFAMyRecords
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
        Me.TabControlAFARecords = New DevExpress.XtraTab.XtraTabControl()
        Me.TabPageMyDocuments = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControlMyDocuments = New DevExpress.XtraLayout.LayoutControl()
        Me.BtnLoadMyDocuments = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControlMyDocuments = New DevExpress.XtraGrid.GridControl()
        Me.GridViewMyDocuments = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutItemGridMyDocuments = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutItemBtnCancel = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutItemBtnLoadMyDocuments = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TabPageMyApprovalHistory = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.BtnLoadMyApprovals = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnUnapprovedAFA = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControlMyApprovals = New DevExpress.XtraGrid.GridControl()
        Me.GridViewMyApprovals = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutItemGridMyApprovals = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutItemBtnUnapprovedAFA = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutItemBtnLoadMyApprovals = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.TabControlAFARecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlAFARecords.SuspendLayout()
        Me.TabPageMyDocuments.SuspendLayout()
        CType(Me.LayoutControlMyDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControlMyDocuments.SuspendLayout()
        CType(Me.GridControlMyDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewMyDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutItemGridMyDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutItemBtnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutItemBtnLoadMyDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageMyApprovalHistory.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.GridControlMyApprovals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewMyApprovals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutItemGridMyApprovals, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutItemBtnUnapprovedAFA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutItemBtnLoadMyApprovals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControlAFARecords
        '
        Me.TabControlAFARecords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlAFARecords.Location = New System.Drawing.Point(0, 0)
        Me.TabControlAFARecords.Name = "TabControlAFARecords"
        Me.TabControlAFARecords.SelectedTabPage = Me.TabPageMyDocuments
        Me.TabControlAFARecords.Size = New System.Drawing.Size(950, 625)
        Me.TabControlAFARecords.TabIndex = 0
        Me.TabControlAFARecords.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.TabPageMyDocuments, Me.TabPageMyApprovalHistory})
        '
        'TabPageMyDocuments
        '
        Me.TabPageMyDocuments.Controls.Add(Me.LayoutControlMyDocuments)
        Me.TabPageMyDocuments.Name = "TabPageMyDocuments"
        Me.TabPageMyDocuments.Size = New System.Drawing.Size(942, 596)
        Me.TabPageMyDocuments.Text = "My Documents"
        '
        'LayoutControlMyDocuments
        '
        Me.LayoutControlMyDocuments.Controls.Add(Me.BtnLoadMyDocuments)
        Me.LayoutControlMyDocuments.Controls.Add(Me.BtnCancel)
        Me.LayoutControlMyDocuments.Controls.Add(Me.GridControlMyDocuments)
        Me.LayoutControlMyDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControlMyDocuments.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlMyDocuments.Name = "LayoutControlMyDocuments"
        Me.LayoutControlMyDocuments.Root = Me.Root
        Me.LayoutControlMyDocuments.Size = New System.Drawing.Size(942, 596)
        Me.LayoutControlMyDocuments.TabIndex = 0
        Me.LayoutControlMyDocuments.Text = "LayoutControlMyDocuments"
        '
        'BtnLoadMyDocuments
        '
        Me.BtnLoadMyDocuments.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnLoadMyDocuments.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoadMyDocuments.Appearance.Options.UseBackColor = True
        Me.BtnLoadMyDocuments.Appearance.Options.UseFont = True
        Me.BtnLoadMyDocuments.Location = New System.Drawing.Point(12, 560)
        Me.BtnLoadMyDocuments.Name = "BtnLoadMyDocuments"
        Me.BtnLoadMyDocuments.Size = New System.Drawing.Size(516, 24)
        Me.BtnLoadMyDocuments.StyleController = Me.LayoutControlMyDocuments
        Me.BtnLoadMyDocuments.TabIndex = 6
        Me.BtnLoadMyDocuments.Text = "Load"
        '
        'BtnCancel
        '
        Me.BtnCancel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.BtnCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Appearance.Options.UseBackColor = True
        Me.BtnCancel.Appearance.Options.UseFont = True
        Me.BtnCancel.Location = New System.Drawing.Point(532, 560)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(398, 24)
        Me.BtnCancel.StyleController = Me.LayoutControlMyDocuments
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel AFA"
        '
        'GridControlMyDocuments
        '
        Me.GridControlMyDocuments.Location = New System.Drawing.Point(12, 12)
        Me.GridControlMyDocuments.MainView = Me.GridViewMyDocuments
        Me.GridControlMyDocuments.Name = "GridControlMyDocuments"
        Me.GridControlMyDocuments.Size = New System.Drawing.Size(918, 544)
        Me.GridControlMyDocuments.TabIndex = 4
        Me.GridControlMyDocuments.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewMyDocuments})
        '
        'GridViewMyDocuments
        '
        Me.GridViewMyDocuments.GridControl = Me.GridControlMyDocuments
        Me.GridViewMyDocuments.Name = "GridViewMyDocuments"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutItemGridMyDocuments, Me.LayoutItemBtnCancel, Me.LayoutItemBtnLoadMyDocuments})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(942, 596)
        Me.Root.TextVisible = False
        '
        'LayoutItemGridMyDocuments
        '
        Me.LayoutItemGridMyDocuments.Control = Me.GridControlMyDocuments
        Me.LayoutItemGridMyDocuments.Location = New System.Drawing.Point(0, 0)
        Me.LayoutItemGridMyDocuments.Name = "LayoutItemGridMyDocuments"
        Me.LayoutItemGridMyDocuments.Size = New System.Drawing.Size(922, 548)
        Me.LayoutItemGridMyDocuments.TextVisible = False
        '
        'LayoutItemBtnCancel
        '
        Me.LayoutItemBtnCancel.Control = Me.BtnCancel
        Me.LayoutItemBtnCancel.Location = New System.Drawing.Point(520, 548)
        Me.LayoutItemBtnCancel.Name = "LayoutItemBtnCancel"
        Me.LayoutItemBtnCancel.Size = New System.Drawing.Size(402, 28)
        Me.LayoutItemBtnCancel.TextVisible = False
        '
        'LayoutItemBtnLoadMyDocuments
        '
        Me.LayoutItemBtnLoadMyDocuments.Control = Me.BtnLoadMyDocuments
        Me.LayoutItemBtnLoadMyDocuments.Location = New System.Drawing.Point(0, 548)
        Me.LayoutItemBtnLoadMyDocuments.Name = "LayoutItemBtnLoadMyDocuments"
        Me.LayoutItemBtnLoadMyDocuments.Size = New System.Drawing.Size(520, 28)
        Me.LayoutItemBtnLoadMyDocuments.TextVisible = False
        '
        'TabPageMyApprovalHistory
        '
        Me.TabPageMyApprovalHistory.Controls.Add(Me.LayoutControl2)
        Me.TabPageMyApprovalHistory.Name = "TabPageMyApprovalHistory"
        Me.TabPageMyApprovalHistory.Size = New System.Drawing.Size(942, 596)
        Me.TabPageMyApprovalHistory.Text = "My Approval History"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.BtnLoadMyApprovals)
        Me.LayoutControl2.Controls.Add(Me.BtnUnapprovedAFA)
        Me.LayoutControl2.Controls.Add(Me.GridControlMyApprovals)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(942, 596)
        Me.LayoutControl2.TabIndex = 0
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'BtnLoadMyApprovals
        '
        Me.BtnLoadMyApprovals.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnLoadMyApprovals.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoadMyApprovals.Appearance.Options.UseBackColor = True
        Me.BtnLoadMyApprovals.Appearance.Options.UseFont = True
        Me.BtnLoadMyApprovals.Location = New System.Drawing.Point(12, 560)
        Me.BtnLoadMyApprovals.Name = "BtnLoadMyApprovals"
        Me.BtnLoadMyApprovals.Size = New System.Drawing.Size(496, 24)
        Me.BtnLoadMyApprovals.StyleController = Me.LayoutControl2
        Me.BtnLoadMyApprovals.TabIndex = 6
        Me.BtnLoadMyApprovals.Text = "Load"
        '
        'BtnUnapprovedAFA
        '
        Me.BtnUnapprovedAFA.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.BtnUnapprovedAFA.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnapprovedAFA.Appearance.Options.UseBackColor = True
        Me.BtnUnapprovedAFA.Appearance.Options.UseFont = True
        Me.BtnUnapprovedAFA.Location = New System.Drawing.Point(512, 560)
        Me.BtnUnapprovedAFA.Name = "BtnUnapprovedAFA"
        Me.BtnUnapprovedAFA.Size = New System.Drawing.Size(418, 24)
        Me.BtnUnapprovedAFA.StyleController = Me.LayoutControl2
        Me.BtnUnapprovedAFA.TabIndex = 5
        Me.BtnUnapprovedAFA.Text = "Unapproved"
        '
        'GridControlMyApprovals
        '
        Me.GridControlMyApprovals.Location = New System.Drawing.Point(12, 12)
        Me.GridControlMyApprovals.MainView = Me.GridViewMyApprovals
        Me.GridControlMyApprovals.Name = "GridControlMyApprovals"
        Me.GridControlMyApprovals.Size = New System.Drawing.Size(918, 544)
        Me.GridControlMyApprovals.TabIndex = 4
        Me.GridControlMyApprovals.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewMyApprovals})
        '
        'GridViewMyApprovals
        '
        Me.GridViewMyApprovals.GridControl = Me.GridControlMyApprovals
        Me.GridViewMyApprovals.Name = "GridViewMyApprovals"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutItemGridMyApprovals, Me.LayoutItemBtnUnapprovedAFA, Me.LayoutItemBtnLoadMyApprovals})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(942, 596)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutItemGridMyApprovals
        '
        Me.LayoutItemGridMyApprovals.Control = Me.GridControlMyApprovals
        Me.LayoutItemGridMyApprovals.Location = New System.Drawing.Point(0, 0)
        Me.LayoutItemGridMyApprovals.Name = "LayoutItemGridMyApprovals"
        Me.LayoutItemGridMyApprovals.Size = New System.Drawing.Size(922, 548)
        Me.LayoutItemGridMyApprovals.TextVisible = False
        '
        'LayoutItemBtnUnapprovedAFA
        '
        Me.LayoutItemBtnUnapprovedAFA.Control = Me.BtnUnapprovedAFA
        Me.LayoutItemBtnUnapprovedAFA.Location = New System.Drawing.Point(500, 548)
        Me.LayoutItemBtnUnapprovedAFA.Name = "LayoutItemBtnUnapprovedAFA"
        Me.LayoutItemBtnUnapprovedAFA.Size = New System.Drawing.Size(422, 28)
        Me.LayoutItemBtnUnapprovedAFA.TextVisible = False
        '
        'LayoutItemBtnLoadMyApprovals
        '
        Me.LayoutItemBtnLoadMyApprovals.Control = Me.BtnLoadMyApprovals
        Me.LayoutItemBtnLoadMyApprovals.Location = New System.Drawing.Point(0, 548)
        Me.LayoutItemBtnLoadMyApprovals.Name = "LayoutItemBtnLoadMyApprovals"
        Me.LayoutItemBtnLoadMyApprovals.Size = New System.Drawing.Size(500, 28)
        Me.LayoutItemBtnLoadMyApprovals.TextVisible = False
        '
        'XtraFormAFAMyRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 625)
        Me.Controls.Add(Me.TabControlAFARecords)
        Me.IconOptions.Image = Global.AFASYSTEM.My.Resources.Resources.icondunlop
        Me.Name = "XtraFormAFAMyRecords"
        Me.Text = "My AFA History"
        CType(Me.TabControlAFARecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlAFARecords.ResumeLayout(False)
        Me.TabPageMyDocuments.ResumeLayout(False)
        CType(Me.LayoutControlMyDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControlMyDocuments.ResumeLayout(False)
        CType(Me.GridControlMyDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewMyDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutItemGridMyDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutItemBtnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutItemBtnLoadMyDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageMyApprovalHistory.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.GridControlMyApprovals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewMyApprovals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutItemGridMyApprovals, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutItemBtnUnapprovedAFA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutItemBtnLoadMyApprovals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControlAFARecords As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents TabPageMyDocuments As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TabPageMyApprovalHistory As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControlMyDocuments As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridControlMyDocuments As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewMyDocuments As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutItemGridMyDocuments As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControlMyApprovals As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewMyApprovals As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutItemGridMyApprovals As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnLoadMyDocuments As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutItemBtnCancel As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutItemBtnLoadMyDocuments As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnLoadMyApprovals As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnUnapprovedAFA As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutItemBtnUnapprovedAFA As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutItemBtnLoadMyApprovals As DevExpress.XtraLayout.LayoutControlItem
End Class
