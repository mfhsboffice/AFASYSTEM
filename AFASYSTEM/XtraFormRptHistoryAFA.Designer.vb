<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormRptHistoryAFA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormRptHistoryAFA))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DTTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtmnViewDoc = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BtntoExcel = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtntoExcel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DTTo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DTFrom)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtmnViewDoc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnExit)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(930, 674)
        Me.SplitContainer1.SplitterDistance = 90
        Me.SplitContainer1.TabIndex = 0
        '
        'DTTo
        '
        Me.DTTo.CustomFormat = "dd MMM yyyy"
        Me.DTTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTTo.Location = New System.Drawing.Point(250, 25)
        Me.DTTo.Name = "DTTo"
        Me.DTTo.Size = New System.Drawing.Size(120, 22)
        Me.DTTo.TabIndex = 93
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(215, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 92
        Me.Label2.Text = "To"
        '
        'DTFrom
        '
        Me.DTFrom.CustomFormat = "dd MMM yyyy"
        Me.DTFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTFrom.Location = New System.Drawing.Point(89, 25)
        Me.DTFrom.Name = "DTFrom"
        Me.DTFrom.Size = New System.Drawing.Size(120, 22)
        Me.DTFrom.TabIndex = 91
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "Period"
        '
        'BtmnViewDoc
        '
        Me.BtmnViewDoc.ImageOptions.Image = CType(resources.GetObject("BtmnViewDoc.ImageOptions.Image"), System.Drawing.Image)
        Me.BtmnViewDoc.Location = New System.Drawing.Point(404, 22)
        Me.BtmnViewDoc.Name = "BtmnViewDoc"
        Me.BtmnViewDoc.Size = New System.Drawing.Size(116, 33)
        Me.BtmnViewDoc.TabIndex = 89
        Me.BtmnViewDoc.Text = "View AFA"
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(648, 22)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(89, 33)
        Me.BtnExit.TabIndex = 88
        Me.BtnExit.Text = "Exit"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(930, 580)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'BtntoExcel
        '
        Me.BtntoExcel.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.BtntoExcel.Location = New System.Drawing.Point(526, 22)
        Me.BtntoExcel.Name = "BtntoExcel"
        Me.BtntoExcel.Size = New System.Drawing.Size(116, 33)
        Me.BtntoExcel.TabIndex = 94
        Me.BtntoExcel.Text = "To Excel"
        '
        'XtraFormRptHistoryAFA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 674)
        Me.Controls.Add(Me.SplitContainer1)
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormRptHistoryAFA.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormRptHistoryAFA"
        Me.Text = "History AFA"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DTTo As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents DTFrom As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents BtmnViewDoc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtntoExcel As DevExpress.XtraEditors.SimpleButton
End Class
