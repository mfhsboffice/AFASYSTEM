<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XtraFormChangPwd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraFormChangPwd))
        Me.TxtCurrpwd = New System.Windows.Forms.TextBox()
        Me.TxtNewpwd = New System.Windows.Forms.TextBox()
        Me.TxtConfirpwd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnExit = New DevExpress.XtraEditors.SimpleButton()
        Me.Btnproses = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'TxtCurrpwd
        '
        Me.TxtCurrpwd.Location = New System.Drawing.Point(174, 14)
        Me.TxtCurrpwd.Name = "TxtCurrpwd"
        Me.TxtCurrpwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtCurrpwd.Size = New System.Drawing.Size(214, 22)
        Me.TxtCurrpwd.TabIndex = 0
        '
        'TxtNewpwd
        '
        Me.TxtNewpwd.Location = New System.Drawing.Point(174, 44)
        Me.TxtNewpwd.Name = "TxtNewpwd"
        Me.TxtNewpwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtNewpwd.Size = New System.Drawing.Size(214, 22)
        Me.TxtNewpwd.TabIndex = 1
        '
        'TxtConfirpwd
        '
        Me.TxtConfirpwd.Location = New System.Drawing.Point(174, 72)
        Me.TxtConfirpwd.Name = "TxtConfirpwd"
        Me.TxtConfirpwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfirpwd.Size = New System.Drawing.Size(214, 22)
        Me.TxtConfirpwd.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Current Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Confirmation New Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "New Password"
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(260, 110)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 4
        Me.BtnExit.Text = "Exit"
        '
        'Btnproses
        '
        Me.Btnproses.Location = New System.Drawing.Point(176, 110)
        Me.Btnproses.Name = "Btnproses"
        Me.Btnproses.Size = New System.Drawing.Size(75, 23)
        Me.Btnproses.TabIndex = 3
        Me.Btnproses.Text = "OK"
        '
        'XtraFormChangPwd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 148)
        Me.ControlBox = False
        Me.Controls.Add(Me.Btnproses)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtConfirpwd)
        Me.Controls.Add(Me.TxtNewpwd)
        Me.Controls.Add(Me.TxtCurrpwd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.Image = CType(resources.GetObject("XtraFormChangPwd.IconOptions.Image"), System.Drawing.Image)
        Me.Name = "XtraFormChangPwd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtCurrpwd As TextBox
    Friend WithEvents TxtNewpwd As TextBox
    Friend WithEvents TxtConfirpwd As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BtnExit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Btnproses As DevExpress.XtraEditors.SimpleButton
End Class
