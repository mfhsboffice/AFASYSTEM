<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormAfaType
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
        Me.XtraTabControlType = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.XtraTabControlType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControlType.SuspendLayout()
        Me.SuspendLayout()
        '
        'XtraTabControlType
        '
        Me.XtraTabControlType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControlType.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControlType.Name = "XtraTabControlType"
        Me.XtraTabControlType.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControlType.Size = New System.Drawing.Size(752, 546)
        Me.XtraTabControlType.TabIndex = 0
        Me.XtraTabControlType.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Name = "XtraTabPageAFAType"
        Me.XtraTabPage1.Size = New System.Drawing.Size(744, 517)
        Me.XtraTabPage1.Text = "AFA Type"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Name = "XtraTabPageAFASubType"
        Me.XtraTabPage2.Size = New System.Drawing.Size(292, 271)
        Me.XtraTabPage2.Text = "AFA SUB-Type"
        '
        'XtraFormAfaType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 546)
        Me.Controls.Add(Me.XtraTabControlType)
        Me.IconOptions.Image = Global.AFASYSTEM.My.Resources.Resources.icondunlop
        Me.Name = "XtraFormAfaType"
        Me.Text = "Master AFA Type"
        CType(Me.XtraTabControlType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControlType.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XtraTabControlType As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
End Class
