<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormListAFAAO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormListAFAAO))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.lblafa = New DevExpress.XtraEditors.LabelControl()
        Me.DtyyyymmTo = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DtyyyymmFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtmnViewDoc = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnShow = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel1.SuspendLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel2.SuspendLayout()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.DtyyyymmTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtyyyymmTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtyyyymmFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtyyyymmFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        '
        'SplitContainerControl1.Panel1
        '
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.lblafa)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.DtyyyymmTo)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.DtyyyymmFrom)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.BtmnViewDoc)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.BtnExit)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.btnShow)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        '
        'SplitContainerControl1.Panel2
        '
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1145, 648)
        Me.SplitContainerControl1.SplitterPosition = 67
        Me.SplitContainerControl1.TabIndex = 0
        '
        'lblafa
        '
        Me.lblafa.Location = New System.Drawing.Point(833, 27)
        Me.lblafa.Name = "lblafa"
        Me.lblafa.Size = New System.Drawing.Size(0, 13)
        Me.lblafa.TabIndex = 95
        Me.lblafa.Visible = False
        '
        'DtyyyymmTo
        '
        Me.DtyyyymmTo.EditValue = Nothing
        Me.DtyyyymmTo.Location = New System.Drawing.Point(280, 20)
        Me.DtyyyymmTo.Name = "DtyyyymmTo"
        Me.DtyyyymmTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtyyyymmTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtyyyymmTo.Properties.DisplayFormat.FormatString = "yyyyMM"
        Me.DtyyyymmTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DtyyyymmTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DtyyyymmTo.Properties.MaskSettings.Set("mask", "yyyyMM")
        Me.DtyyyymmTo.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView
        Me.DtyyyymmTo.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView
        Me.DtyyyymmTo.Size = New System.Drawing.Size(100, 20)
        Me.DtyyyymmTo.TabIndex = 94
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(207, 27)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl2.TabIndex = 93
        Me.LabelControl2.Text = "YYYYMM To"
        '
        'DtyyyymmFrom
        '
        Me.DtyyyymmFrom.EditValue = Nothing
        Me.DtyyyymmFrom.Location = New System.Drawing.Point(101, 20)
        Me.DtyyyymmFrom.Name = "DtyyyymmFrom"
        Me.DtyyyymmFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtyyyymmFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtyyyymmFrom.Properties.DisplayFormat.FormatString = "yyyyMM"
        Me.DtyyyymmFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DtyyyymmFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.DtyyyymmFrom.Properties.MaskSettings.Set("mask", "yyyyMM")
        Me.DtyyyymmFrom.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView
        Me.DtyyyymmFrom.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView
        Me.DtyyyymmFrom.Size = New System.Drawing.Size(100, 20)
        Me.DtyyyymmFrom.TabIndex = 92
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 23)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl1.TabIndex = 91
        Me.LabelControl1.Text = "YYYYMM From"
        '
        'BtmnViewDoc
        '
        Me.BtmnViewDoc.ImageOptions.Image = CType(resources.GetObject("BtmnViewDoc.ImageOptions.Image"), System.Drawing.Image)
        Me.BtmnViewDoc.Location = New System.Drawing.Point(596, 13)
        Me.BtmnViewDoc.Name = "BtmnViewDoc"
        Me.BtmnViewDoc.Size = New System.Drawing.Size(96, 33)
        Me.BtmnViewDoc.TabIndex = 90
        Me.BtmnViewDoc.Text = "View AFA"
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(698, 13)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(73, 33)
        Me.BtnExit.TabIndex = 89
        Me.BtnExit.Text = "Exit"
        '
        'btnShow
        '
        Me.btnShow.ImageOptions.Image = CType(resources.GetObject("btnShow.ImageOptions.Image"), System.Drawing.Image)
        Me.btnShow.Location = New System.Drawing.Point(489, 13)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(101, 33)
        Me.btnShow.TabIndex = 88
        Me.btnShow.Text = "View Data"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1145, 573)
        Me.GridControl1.TabIndex = 2
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'XtraFormListAFAAO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 648)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.IconOptions.LargeImage = CType(resources.GetObject("XtraFormListAFAAO.IconOptions.LargeImage"), System.Drawing.Image)
        Me.Name = "XtraFormListAFAAO"
        Me.Text = "List AFA"
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel1.ResumeLayout(False)
        Me.SplitContainerControl1.Panel1.PerformLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.DtyyyymmTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtyyyymmTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtyyyymmFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtyyyymmFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BtmnViewDoc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnShow As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DtyyyymmTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DtyyyymmFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblafa As DevExpress.XtraEditors.LabelControl
End Class
