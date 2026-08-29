<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormAddInf
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormAddInf))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtquest = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblidQ = New System.Windows.Forms.Label()
        Me.BtnSend = New DevExpress.XtraEditors.SimpleButton()
        Me.lblnikQ = New DevExpress.XtraEditors.LabelControl()
        Me.cmbtoQ = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtAnswer = New System.Windows.Forms.RichTextBox()
        Me.lblidpertanyaandijawaban = New System.Windows.Forms.Label()
        Me.lblidjawab = New System.Windows.Forms.Label()
        Me.btnSumAnswer = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtQuestA = New System.Windows.Forms.TextBox()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtfromA = New System.Windows.Forms.TextBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtAfa = New System.Windows.Forms.TextBox()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1155, 661)
        Me.SplitContainer1.SplitterDistance = 331
        Me.SplitContainer1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 46)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1155, 285)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtquest)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.lblidQ)
        Me.TabPage1.Controls.Add(Me.BtnSend)
        Me.TabPage1.Controls.Add(Me.lblnikQ)
        Me.TabPage1.Controls.Add(Me.cmbtoQ)
        Me.TabPage1.Controls.Add(Me.LabelControl3)
        Me.TabPage1.Controls.Add(Me.LabelControl2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1147, 259)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Question"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtquest
        '
        Me.txtquest.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtquest.Location = New System.Drawing.Point(10, 43)
        Me.txtquest.Name = "txtquest"
        Me.txtquest.Size = New System.Drawing.Size(464, 195)
        Me.txtquest.TabIndex = 97
        Me.txtquest.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(760, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 96
        Me.Label1.Visible = False
        '
        'lblidQ
        '
        Me.lblidQ.AutoSize = True
        Me.lblidQ.Location = New System.Drawing.Point(646, 127)
        Me.lblidQ.Name = "lblidQ"
        Me.lblidQ.Size = New System.Drawing.Size(13, 13)
        Me.lblidQ.TabIndex = 95
        Me.lblidQ.Text = "0"
        Me.lblidQ.Visible = False
        '
        'BtnSend
        '
        Me.BtnSend.ImageOptions.Image = CType(resources.GetObject("BtnSend.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSend.Location = New System.Drawing.Point(547, 143)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(124, 33)
        Me.BtnSend.TabIndex = 94
        Me.BtnSend.Text = "Submit"
        '
        'lblnikQ
        '
        Me.lblnikQ.Location = New System.Drawing.Point(800, 29)
        Me.lblnikQ.Name = "lblnikQ"
        Me.lblnikQ.Size = New System.Drawing.Size(0, 13)
        Me.lblnikQ.TabIndex = 92
        Me.lblnikQ.UseMnemonic = False
        Me.lblnikQ.Visible = False
        '
        'cmbtoQ
        '
        Me.cmbtoQ.FormattingEnabled = True
        Me.cmbtoQ.Location = New System.Drawing.Point(547, 21)
        Me.cmbtoQ.Name = "cmbtoQ"
        Me.cmbtoQ.Size = New System.Drawing.Size(348, 21)
        Me.cmbtoQ.TabIndex = 91
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(508, 24)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(13, 13)
        Me.LabelControl3.TabIndex = 90
        Me.LabelControl3.Text = "To"
        Me.LabelControl3.UseMnemonic = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(10, 24)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl2.TabIndex = 88
        Me.LabelControl2.Text = "Question"
        Me.LabelControl2.UseMnemonic = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtAnswer)
        Me.TabPage2.Controls.Add(Me.lblidpertanyaandijawaban)
        Me.TabPage2.Controls.Add(Me.lblidjawab)
        Me.TabPage2.Controls.Add(Me.btnSumAnswer)
        Me.TabPage2.Controls.Add(Me.LabelControl6)
        Me.TabPage2.Controls.Add(Me.TxtQuestA)
        Me.TabPage2.Controls.Add(Me.LabelControl5)
        Me.TabPage2.Controls.Add(Me.txtfromA)
        Me.TabPage2.Controls.Add(Me.LabelControl4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1147, 259)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Answer"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtAnswer
        '
        Me.txtAnswer.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnswer.Location = New System.Drawing.Point(474, 44)
        Me.txtAnswer.Name = "txtAnswer"
        Me.txtAnswer.Size = New System.Drawing.Size(461, 169)
        Me.txtAnswer.TabIndex = 101
        Me.txtAnswer.Text = ""
        '
        'lblidpertanyaandijawaban
        '
        Me.lblidpertanyaandijawaban.AutoSize = True
        Me.lblidpertanyaandijawaban.Location = New System.Drawing.Point(554, 7)
        Me.lblidpertanyaandijawaban.Name = "lblidpertanyaandijawaban"
        Me.lblidpertanyaandijawaban.Size = New System.Drawing.Size(13, 13)
        Me.lblidpertanyaandijawaban.TabIndex = 100
        Me.lblidpertanyaandijawaban.Text = "0"
        Me.lblidpertanyaandijawaban.Visible = False
        '
        'lblidjawab
        '
        Me.lblidjawab.AutoSize = True
        Me.lblidjawab.Location = New System.Drawing.Point(414, 7)
        Me.lblidjawab.Name = "lblidjawab"
        Me.lblidjawab.Size = New System.Drawing.Size(13, 13)
        Me.lblidjawab.TabIndex = 99
        Me.lblidjawab.Text = "0"
        Me.lblidjawab.Visible = False
        '
        'btnSumAnswer
        '
        Me.btnSumAnswer.ImageOptions.Image = CType(resources.GetObject("btnSumAnswer.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSumAnswer.Location = New System.Drawing.Point(474, 219)
        Me.btnSumAnswer.Name = "btnSumAnswer"
        Me.btnSumAnswer.Size = New System.Drawing.Size(124, 33)
        Me.btnSumAnswer.TabIndex = 98
        Me.btnSumAnswer.Text = "Submit"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(474, 22)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl6.TabIndex = 96
        Me.LabelControl6.Text = "Answer"
        Me.LabelControl6.UseMnemonic = False
        '
        'TxtQuestA
        '
        Me.TxtQuestA.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtQuestA.Location = New System.Drawing.Point(61, 41)
        Me.TxtQuestA.MaxLength = 500
        Me.TxtQuestA.Multiline = True
        Me.TxtQuestA.Name = "TxtQuestA"
        Me.TxtQuestA.ReadOnly = True
        Me.TxtQuestA.Size = New System.Drawing.Size(404, 172)
        Me.TxtQuestA.TabIndex = 95
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(8, 44)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl5.TabIndex = 94
        Me.LabelControl5.Text = "Question"
        Me.LabelControl5.UseMnemonic = False
        '
        'txtfromA
        '
        Me.txtfromA.Location = New System.Drawing.Point(61, 13)
        Me.txtfromA.Name = "txtfromA"
        Me.txtfromA.ReadOnly = True
        Me.txtfromA.Size = New System.Drawing.Size(240, 22)
        Me.txtfromA.TabIndex = 93
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(10, 16)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl4.TabIndex = 92
        Me.LabelControl4.Text = "From"
        Me.LabelControl4.UseMnemonic = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtAfa)
        Me.Panel1.Controls.Add(Me.BtnExit)
        Me.Panel1.Controls.Add(Me.LabelControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1155, 46)
        Me.Panel1.TabIndex = 0
        '
        'TxtAfa
        '
        Me.TxtAfa.Location = New System.Drawing.Point(89, 12)
        Me.TxtAfa.Name = "TxtAfa"
        Me.TxtAfa.ReadOnly = True
        Me.TxtAfa.Size = New System.Drawing.Size(161, 22)
        Me.TxtAfa.TabIndex = 87
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(867, 5)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(124, 33)
        Me.BtnExit.TabIndex = 93
        Me.BtnExit.Text = "Exit"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(14, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 86
        Me.LabelControl1.Text = "Afa No"
        Me.LabelControl1.UseMnemonic = False
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseTextOptions = True
        Me.GridControl1.EmbeddedNavigator.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridControl1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1155, 326)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.AllowCellMerge = True
        Me.GridView1.OptionsView.RowAutoHeight = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'XtraFormAddInf
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1155, 661)
        Me.Controls.Add(Me.SplitContainer1)
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormAddInf.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormAddInf"
        Me.Text = "Add Information"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents lblnikQ As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbtoQ As ComboBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtAfa As TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnSend As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSumAnswer As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtQuestA As TextBox
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtfromA As TextBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblidQ As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblidjawab As Label
    Friend WithEvents lblidpertanyaandijawaban As Label
    Friend WithEvents txtAnswer As RichTextBox
    Friend WithEvents txtquest As RichTextBox
End Class
