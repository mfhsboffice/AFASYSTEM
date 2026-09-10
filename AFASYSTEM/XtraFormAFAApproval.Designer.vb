<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormAFAApproval
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
        Me.BtnDisapprove = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCheckUncheck = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnViewAFA = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.MemoEditReason = New DevExpress.XtraEditors.MemoEdit()
        Me.BtnSkip = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnApproveSelected = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControlApproval = New DevExpress.XtraGrid.GridControl()
        Me.GridViewApproval = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciReason = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.MemoEditReason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlApproval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewApproval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciReason, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.BtnDisapprove)
        Me.LayoutControl1.Controls.Add(Me.BtnCheckUncheck)
        Me.LayoutControl1.Controls.Add(Me.BtnViewAFA)
        Me.LayoutControl1.Controls.Add(Me.BtnLoad)
        Me.LayoutControl1.Controls.Add(Me.BtnExit)
        Me.LayoutControl1.Controls.Add(Me.MemoEditReason)
        Me.LayoutControl1.Controls.Add(Me.BtnSkip)
        Me.LayoutControl1.Controls.Add(Me.BtnApproveSelected)
        Me.LayoutControl1.Controls.Add(Me.GridControlApproval)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(988, 723)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'BtnDisapprove
        '
        Me.BtnDisapprove.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.BtnDisapprove.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDisapprove.Appearance.Options.UseBackColor = True
        Me.BtnDisapprove.Appearance.Options.UseFont = True
        Me.BtnDisapprove.Location = New System.Drawing.Point(566, 687)
        Me.BtnDisapprove.Name = "BtnDisapprove"
        Me.BtnDisapprove.Size = New System.Drawing.Size(187, 24)
        Me.BtnDisapprove.StyleController = Me.LayoutControl1
        Me.BtnDisapprove.TabIndex = 13
        Me.BtnDisapprove.Text = "Disapprove"
        '
        'BtnCheckUncheck
        '
        Me.BtnCheckUncheck.Appearance.BackColor = System.Drawing.Color.Teal
        Me.BtnCheckUncheck.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCheckUncheck.Appearance.Options.UseBackColor = True
        Me.BtnCheckUncheck.Appearance.Options.UseFont = True
        Me.BtnCheckUncheck.Location = New System.Drawing.Point(377, 687)
        Me.BtnCheckUncheck.Name = "BtnCheckUncheck"
        Me.BtnCheckUncheck.Size = New System.Drawing.Size(185, 24)
        Me.BtnCheckUncheck.StyleController = Me.LayoutControl1
        Me.BtnCheckUncheck.TabIndex = 12
        Me.BtnCheckUncheck.Text = "Check"
        '
        'BtnViewAFA
        '
        Me.BtnViewAFA.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.BtnViewAFA.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnViewAFA.Appearance.Options.UseBackColor = True
        Me.BtnViewAFA.Appearance.Options.UseFont = True
        Me.BtnViewAFA.Location = New System.Drawing.Point(12, 12)
        Me.BtnViewAFA.Name = "BtnViewAFA"
        Me.BtnViewAFA.Size = New System.Drawing.Size(494, 24)
        Me.BtnViewAFA.StyleController = Me.LayoutControl1
        Me.BtnViewAFA.TabIndex = 11
        Me.BtnViewAFA.Text = "View AFA"
        '
        'BtnLoad
        '
        Me.BtnLoad.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        Me.BtnLoad.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLoad.Appearance.Options.UseBackColor = True
        Me.BtnLoad.Appearance.Options.UseFont = True
        Me.BtnLoad.Location = New System.Drawing.Point(510, 12)
        Me.BtnLoad.Name = "BtnLoad"
        Me.BtnLoad.Size = New System.Drawing.Size(466, 24)
        Me.BtnLoad.StyleController = Me.LayoutControl1
        Me.BtnLoad.TabIndex = 10
        Me.BtnLoad.Text = "Load"
        '
        'BtnExit
        '
        Me.BtnExit.Appearance.BackColor = System.Drawing.Color.Gray
        Me.BtnExit.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Appearance.Options.UseBackColor = True
        Me.BtnExit.Appearance.Options.UseFont = True
        Me.BtnExit.Location = New System.Drawing.Point(12, 687)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(140, 24)
        Me.BtnExit.StyleController = Me.LayoutControl1
        Me.BtnExit.TabIndex = 9
        Me.BtnExit.Text = "Exit"
        '
        'MemoEditReason
        '
        Me.MemoEditReason.Location = New System.Drawing.Point(12, 515)
        Me.MemoEditReason.Name = "MemoEditReason"
        Me.MemoEditReason.Size = New System.Drawing.Size(964, 168)
        Me.MemoEditReason.StyleController = Me.LayoutControl1
        Me.MemoEditReason.TabIndex = 8
        '
        'BtnSkip
        '
        Me.BtnSkip.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSkip.Appearance.Options.UseFont = True
        Me.BtnSkip.Location = New System.Drawing.Point(156, 687)
        Me.BtnSkip.Name = "BtnSkip"
        Me.BtnSkip.Size = New System.Drawing.Size(217, 24)
        Me.BtnSkip.StyleController = Me.LayoutControl1
        Me.BtnSkip.TabIndex = 7
        Me.BtnSkip.Text = "Skip Approval"
        '
        'BtnApproveSelected
        '
        Me.BtnApproveSelected.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success
        Me.BtnApproveSelected.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnApproveSelected.Appearance.Options.UseBackColor = True
        Me.BtnApproveSelected.Appearance.Options.UseFont = True
        Me.BtnApproveSelected.Location = New System.Drawing.Point(757, 687)
        Me.BtnApproveSelected.Name = "BtnApproveSelected"
        Me.BtnApproveSelected.Size = New System.Drawing.Size(219, 24)
        Me.BtnApproveSelected.StyleController = Me.LayoutControl1
        Me.BtnApproveSelected.TabIndex = 5
        Me.BtnApproveSelected.Text = "Approve Selected"
        '
        'GridControlApproval
        '
        Me.GridControlApproval.Location = New System.Drawing.Point(12, 40)
        Me.GridControlApproval.MainView = Me.GridViewApproval
        Me.GridControlApproval.Name = "GridControlApproval"
        Me.GridControlApproval.Size = New System.Drawing.Size(964, 455)
        Me.GridControlApproval.TabIndex = 4
        Me.GridControlApproval.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewApproval})
        '
        'GridViewApproval
        '
        Me.GridViewApproval.Appearance.HeaderPanel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridViewApproval.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridViewApproval.GridControl = Me.GridControlApproval
        Me.GridViewApproval.Name = "GridViewApproval"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LciReason, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem3})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(988, 723)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridControlApproval
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 28)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(968, 459)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.BtnApproveSelected
        Me.LayoutControlItem2.Location = New System.Drawing.Point(745, 675)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(223, 28)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.BtnSkip
        Me.LayoutControlItem4.Location = New System.Drawing.Point(144, 675)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(221, 28)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LciReason
        '
        Me.LciReason.Control = Me.MemoEditReason
        Me.LciReason.Location = New System.Drawing.Point(0, 487)
        Me.LciReason.Name = "LciReason"
        Me.LciReason.Size = New System.Drawing.Size(968, 188)
        Me.LciReason.Text = "Reason"
        Me.LciReason.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciReason.TextSize = New System.Drawing.Size(38, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.BtnExit
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 675)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(144, 28)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.BtnLoad
        Me.LayoutControlItem6.Location = New System.Drawing.Point(498, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(470, 28)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.BtnViewAFA
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(498, 28)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.BtnCheckUncheck
        Me.LayoutControlItem8.Location = New System.Drawing.Point(365, 675)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(189, 28)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.BtnDisapprove
        Me.LayoutControlItem3.Location = New System.Drawing.Point(554, 675)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(191, 28)
        Me.LayoutControlItem3.TextVisible = False
        '
        'XtraFormAFAApproval
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 723)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = Global.AFASYSTEM.My.Resources.Resources.icondunlop
        Me.Name = "XtraFormAFAApproval"
        Me.Text = "AFA Approval"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.MemoEditReason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlApproval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewApproval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciReason, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControlApproval As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewApproval As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnApproveSelected As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnSkip As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents MemoEditReason As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LciReason As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnViewAFA As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnCheckUncheck As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnDisapprove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
End Class
