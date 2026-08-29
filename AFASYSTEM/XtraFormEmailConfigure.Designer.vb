<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormEmailConfigure
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormEmailConfigure))
        Me.RManual = New System.Windows.Forms.RadioButton()
        Me.RAuto = New System.Windows.Forms.RadioButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'RManual
        '
        Me.RManual.AutoSize = True
        Me.RManual.Location = New System.Drawing.Point(33, 36)
        Me.RManual.Name = "RManual"
        Me.RManual.Size = New System.Drawing.Size(96, 17)
        Me.RManual.TabIndex = 0
        Me.RManual.TabStop = True
        Me.RManual.Text = "Manual check"
        Me.RManual.UseVisualStyleBackColor = True
        '
        'RAuto
        '
        Me.RAuto.AutoSize = True
        Me.RAuto.Location = New System.Drawing.Point(181, 36)
        Me.RAuto.Name = "RAuto"
        Me.RAuto.Size = New System.Drawing.Size(188, 17)
        Me.RAuto.TabIndex = 1
        Me.RAuto.TabStop = True
        Me.RAuto.Text = "Automatic approval notification"
        Me.RAuto.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.ImageOptions.Image = CType(resources.GetObject("BtnSave.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnSave.Location = New System.Drawing.Point(33, 89)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(124, 33)
        Me.BtnSave.TabIndex = 82
        Me.BtnSave.Text = "Configure"
        '
        'BtnExit
        '
        Me.BtnExit.ImageOptions.Image = CType(resources.GetObject("BtnExit.ImageOptions.Image"), System.Drawing.Image)
        Me.BtnExit.Location = New System.Drawing.Point(181, 89)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(124, 33)
        Me.BtnExit.TabIndex = 83
        Me.BtnExit.Text = "Exit"
        '
        'XtraFormEmailConfigure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 144)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.RAuto)
        Me.Controls.Add(Me.RManual)
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormEmailConfigure.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormEmailConfigure"
        Me.Text = "Configure Notification Email"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RManual As RadioButton
    Friend WithEvents RAuto As RadioButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
End Class
