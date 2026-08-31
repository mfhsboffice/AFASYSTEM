<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class XtraFormAFAInfSign
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
        Me.components = New System.ComponentModel.Container()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TextEditScheduleTo = New DevExpress.XtraEditors.TextEdit()
        Me.TextEditScheduleFrom = New DevExpress.XtraEditors.TextEdit()
        Me.BtnViewAFA = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSend = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonEditAttachment2 = New DevExpress.XtraEditors.ButtonEdit()
        Me.ButtonEditAttachment1 = New DevExpress.XtraEditors.ButtonEdit()
        Me.GridControlSignature = New DevExpress.XtraGrid.GridControl()
        Me.GridViewSignature = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TextEditEstimateCost = New DevExpress.XtraEditors.TextEdit()
        Me.TextEditAfaNo = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LciAfaNo = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciEstimateCost = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciGridSignature = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciAttachment1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciAttachment2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciBtnSave = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciBtnExit = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciBtnSend = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciBtnViewAFA = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciScheduleFrom = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LciScheduleTo = New DevExpress.XtraLayout.LayoutControlItem()
        Me.XtraOpenFileDialogFile = New DevExpress.XtraEditors.XtraOpenFileDialog(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TextEditScheduleTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditScheduleFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonEditAttachment2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonEditAttachment1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditEstimateCost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEditAfaNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciAfaNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciEstimateCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciGridSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciAttachment1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciAttachment2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciBtnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciBtnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciBtnSend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciBtnViewAFA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciScheduleFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LciScheduleTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TextEditScheduleTo)
        Me.LayoutControl1.Controls.Add(Me.TextEditScheduleFrom)
        Me.LayoutControl1.Controls.Add(Me.BtnViewAFA)
        Me.LayoutControl1.Controls.Add(Me.BtnSend)
        Me.LayoutControl1.Controls.Add(Me.BtnExit)
        Me.LayoutControl1.Controls.Add(Me.BtnSave)
        Me.LayoutControl1.Controls.Add(Me.ButtonEditAttachment2)
        Me.LayoutControl1.Controls.Add(Me.ButtonEditAttachment1)
        Me.LayoutControl1.Controls.Add(Me.GridControlSignature)
        Me.LayoutControl1.Controls.Add(Me.TextEditEstimateCost)
        Me.LayoutControl1.Controls.Add(Me.TextEditAfaNo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(688, 435)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TextEditScheduleTo
        '
        Me.TextEditScheduleTo.Location = New System.Drawing.Point(346, 68)
        Me.TextEditScheduleTo.Name = "TextEditScheduleTo"
        Me.TextEditScheduleTo.Properties.ReadOnly = True
        Me.TextEditScheduleTo.Size = New System.Drawing.Size(330, 20)
        Me.TextEditScheduleTo.StyleController = Me.LayoutControl1
        Me.TextEditScheduleTo.TabIndex = 16
        '
        'TextEditScheduleFrom
        '
        Me.TextEditScheduleFrom.Location = New System.Drawing.Point(12, 68)
        Me.TextEditScheduleFrom.Name = "TextEditScheduleFrom"
        Me.TextEditScheduleFrom.Properties.ReadOnly = True
        Me.TextEditScheduleFrom.Size = New System.Drawing.Size(330, 20)
        Me.TextEditScheduleFrom.StyleController = Me.LayoutControl1
        Me.TextEditScheduleFrom.TabIndex = 15
        '
        'BtnViewAFA
        '
        Me.BtnViewAFA.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question
        Me.BtnViewAFA.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnViewAFA.Appearance.Options.UseBackColor = True
        Me.BtnViewAFA.Appearance.Options.UseFont = True
        Me.BtnViewAFA.Location = New System.Drawing.Point(12, 399)
        Me.BtnViewAFA.Name = "BtnViewAFA"
        Me.BtnViewAFA.Size = New System.Drawing.Size(170, 24)
        Me.BtnViewAFA.StyleController = Me.LayoutControl1
        Me.BtnViewAFA.TabIndex = 14
        Me.BtnViewAFA.Text = "View AFA"
        '
        'BtnSend
        '
        Me.BtnSend.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning
        Me.BtnSend.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSend.Appearance.Options.UseBackColor = True
        Me.BtnSend.Appearance.Options.UseFont = True
        Me.BtnSend.Location = New System.Drawing.Point(186, 399)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(151, 24)
        Me.BtnSend.StyleController = Me.LayoutControl1
        Me.BtnSend.TabIndex = 13
        Me.BtnSend.Text = "Send"
        '
        'BtnExit
        '
        Me.BtnExit.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger
        Me.BtnExit.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Appearance.Options.UseBackColor = True
        Me.BtnExit.Appearance.Options.UseFont = True
        Me.BtnExit.Location = New System.Drawing.Point(341, 399)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(163, 24)
        Me.BtnExit.StyleController = Me.LayoutControl1
        Me.BtnExit.TabIndex = 12
        Me.BtnExit.Text = "Exit"
        '
        'BtnSave
        '
        Me.BtnSave.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary
        Me.BtnSave.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Appearance.Options.UseBackColor = True
        Me.BtnSave.Appearance.Options.UseFont = True
        Me.BtnSave.Location = New System.Drawing.Point(508, 399)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(168, 24)
        Me.BtnSave.StyleController = Me.LayoutControl1
        Me.BtnSave.TabIndex = 11
        Me.BtnSave.Text = "Save"
        '
        'ButtonEditAttachment2
        '
        Me.ButtonEditAttachment2.Location = New System.Drawing.Point(341, 375)
        Me.ButtonEditAttachment2.Name = "ButtonEditAttachment2"
        Me.ButtonEditAttachment2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ButtonEditAttachment2.Size = New System.Drawing.Size(335, 20)
        Me.ButtonEditAttachment2.StyleController = Me.LayoutControl1
        Me.ButtonEditAttachment2.TabIndex = 10
        '
        'ButtonEditAttachment1
        '
        Me.ButtonEditAttachment1.Location = New System.Drawing.Point(12, 375)
        Me.ButtonEditAttachment1.Name = "ButtonEditAttachment1"
        Me.ButtonEditAttachment1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ButtonEditAttachment1.Size = New System.Drawing.Size(325, 20)
        Me.ButtonEditAttachment1.StyleController = Me.LayoutControl1
        Me.ButtonEditAttachment1.TabIndex = 9
        '
        'GridControlSignature
        '
        Me.GridControlSignature.Location = New System.Drawing.Point(12, 132)
        Me.GridControlSignature.MainView = Me.GridViewSignature
        Me.GridControlSignature.Name = "GridControlSignature"
        Me.GridControlSignature.Size = New System.Drawing.Size(664, 223)
        Me.GridControlSignature.TabIndex = 8
        Me.GridControlSignature.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewSignature})
        '
        'GridViewSignature
        '
        Me.GridViewSignature.GridControl = Me.GridControlSignature
        Me.GridViewSignature.Name = "GridViewSignature"
        '
        'TextEditEstimateCost
        '
        Me.TextEditEstimateCost.Location = New System.Drawing.Point(12, 108)
        Me.TextEditEstimateCost.Name = "TextEditEstimateCost"
        Me.TextEditEstimateCost.Properties.Appearance.Options.UseTextOptions = True
        Me.TextEditEstimateCost.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TextEditEstimateCost.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextEditEstimateCost.Properties.MaskSettings.Set("mask", "n0")
        Me.TextEditEstimateCost.Properties.ReadOnly = True
        Me.TextEditEstimateCost.Properties.UseMaskAsDisplayFormat = True
        Me.TextEditEstimateCost.Size = New System.Drawing.Size(664, 20)
        Me.TextEditEstimateCost.StyleController = Me.LayoutControl1
        Me.TextEditEstimateCost.TabIndex = 7
        '
        'TextEditAfaNo
        '
        Me.TextEditAfaNo.Location = New System.Drawing.Point(12, 28)
        Me.TextEditAfaNo.Name = "TextEditAfaNo"
        Me.TextEditAfaNo.Properties.ReadOnly = True
        Me.TextEditAfaNo.Size = New System.Drawing.Size(664, 20)
        Me.TextEditAfaNo.StyleController = Me.LayoutControl1
        Me.TextEditAfaNo.TabIndex = 4
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LciAfaNo, Me.LciEstimateCost, Me.LciGridSignature, Me.LciAttachment1, Me.LciAttachment2, Me.LciBtnSave, Me.LciBtnExit, Me.LciBtnSend, Me.LciBtnViewAFA, Me.LciScheduleFrom, Me.LciScheduleTo})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(688, 435)
        Me.Root.TextVisible = False
        '
        'LciAfaNo
        '
        Me.LciAfaNo.Control = Me.TextEditAfaNo
        Me.LciAfaNo.Location = New System.Drawing.Point(0, 0)
        Me.LciAfaNo.Name = "LciAfaNo"
        Me.LciAfaNo.Size = New System.Drawing.Size(668, 40)
        Me.LciAfaNo.Text = "No.AFA"
        Me.LciAfaNo.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciAfaNo.TextSize = New System.Drawing.Size(76, 13)
        '
        'LciEstimateCost
        '
        Me.LciEstimateCost.Control = Me.TextEditEstimateCost
        Me.LciEstimateCost.Location = New System.Drawing.Point(0, 80)
        Me.LciEstimateCost.Name = "LciEstimateCost"
        Me.LciEstimateCost.Size = New System.Drawing.Size(668, 40)
        Me.LciEstimateCost.Text = "Estimate Cost"
        Me.LciEstimateCost.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciEstimateCost.TextSize = New System.Drawing.Size(76, 13)
        '
        'LciGridSignature
        '
        Me.LciGridSignature.Control = Me.GridControlSignature
        Me.LciGridSignature.Location = New System.Drawing.Point(0, 120)
        Me.LciGridSignature.Name = "LciGridSignature"
        Me.LciGridSignature.Size = New System.Drawing.Size(668, 227)
        Me.LciGridSignature.TextVisible = False
        '
        'LciAttachment1
        '
        Me.LciAttachment1.Control = Me.ButtonEditAttachment1
        Me.LciAttachment1.Location = New System.Drawing.Point(0, 347)
        Me.LciAttachment1.Name = "LciAttachment1"
        Me.LciAttachment1.Size = New System.Drawing.Size(329, 40)
        Me.LciAttachment1.Text = "Attachment 1"
        Me.LciAttachment1.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciAttachment1.TextSize = New System.Drawing.Size(76, 13)
        '
        'LciAttachment2
        '
        Me.LciAttachment2.Control = Me.ButtonEditAttachment2
        Me.LciAttachment2.Location = New System.Drawing.Point(329, 347)
        Me.LciAttachment2.Name = "LciAttachment2"
        Me.LciAttachment2.Size = New System.Drawing.Size(339, 40)
        Me.LciAttachment2.Text = "Attachment 2"
        Me.LciAttachment2.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciAttachment2.TextSize = New System.Drawing.Size(76, 13)
        '
        'LciBtnSave
        '
        Me.LciBtnSave.Control = Me.BtnSave
        Me.LciBtnSave.Location = New System.Drawing.Point(496, 387)
        Me.LciBtnSave.Name = "LciBtnSave"
        Me.LciBtnSave.Size = New System.Drawing.Size(172, 28)
        Me.LciBtnSave.TextVisible = False
        '
        'LciBtnExit
        '
        Me.LciBtnExit.Control = Me.BtnExit
        Me.LciBtnExit.Location = New System.Drawing.Point(329, 387)
        Me.LciBtnExit.Name = "LciBtnExit"
        Me.LciBtnExit.Size = New System.Drawing.Size(167, 28)
        Me.LciBtnExit.TextVisible = False
        '
        'LciBtnSend
        '
        Me.LciBtnSend.Control = Me.BtnSend
        Me.LciBtnSend.Location = New System.Drawing.Point(174, 387)
        Me.LciBtnSend.Name = "LciBtnSend"
        Me.LciBtnSend.Size = New System.Drawing.Size(155, 28)
        Me.LciBtnSend.TextVisible = False
        '
        'LciBtnViewAFA
        '
        Me.LciBtnViewAFA.Control = Me.BtnViewAFA
        Me.LciBtnViewAFA.Location = New System.Drawing.Point(0, 387)
        Me.LciBtnViewAFA.Name = "LciBtnViewAFA"
        Me.LciBtnViewAFA.Size = New System.Drawing.Size(174, 28)
        Me.LciBtnViewAFA.TextVisible = False
        '
        'LciScheduleFrom
        '
        Me.LciScheduleFrom.Control = Me.TextEditScheduleFrom
        Me.LciScheduleFrom.Location = New System.Drawing.Point(0, 40)
        Me.LciScheduleFrom.Name = "LciScheduleFrom"
        Me.LciScheduleFrom.Size = New System.Drawing.Size(334, 40)
        Me.LciScheduleFrom.Text = "Schedule From"
        Me.LciScheduleFrom.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciScheduleFrom.TextSize = New System.Drawing.Size(76, 13)
        '
        'LciScheduleTo
        '
        Me.LciScheduleTo.Control = Me.TextEditScheduleTo
        Me.LciScheduleTo.Location = New System.Drawing.Point(334, 40)
        Me.LciScheduleTo.Name = "LciScheduleTo"
        Me.LciScheduleTo.Size = New System.Drawing.Size(334, 40)
        Me.LciScheduleTo.Text = "Schedule To"
        Me.LciScheduleTo.TextLocation = DevExpress.Utils.Locations.Top
        Me.LciScheduleTo.TextSize = New System.Drawing.Size(76, 13)
        '
        'XtraOpenFileDialogFile
        '
        Me.XtraOpenFileDialogFile.FileName = "XtraOpenFileDialog1"
        '
        'XtraFormAFAInfSign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 435)
        Me.Controls.Add(Me.LayoutControl1)
        Me.IconOptions.Image = Global.AFASYSTEM.My.Resources.Resources.icondunlop
        Me.Name = "XtraFormAFAInfSign"
        Me.Text = "Signature AFA Donation or Information"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TextEditScheduleTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditScheduleFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonEditAttachment2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonEditAttachment1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlSignature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewSignature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditEstimateCost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEditAfaNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciAfaNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciEstimateCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciGridSignature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciAttachment1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciAttachment2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciBtnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciBtnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciBtnSend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciBtnViewAFA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciScheduleFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LciScheduleTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TextEditAfaNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LciAfaNo As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TextEditEstimateCost As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LciEstimateCost As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridControlSignature As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewSignature As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LciGridSignature As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ButtonEditAttachment2 As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents ButtonEditAttachment1 As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LciAttachment1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LciAttachment2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LciBtnSave As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BtnViewAFA As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LciBtnExit As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LciBtnSend As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LciBtnViewAFA As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents XtraOpenFileDialogFile As DevExpress.XtraEditors.XtraOpenFileDialog
    Friend WithEvents TextEditScheduleTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEditScheduleFrom As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LciScheduleFrom As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LciScheduleTo As DevExpress.XtraLayout.LayoutControlItem
End Class