<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class XtraFormAfaPreview
    Inherits DevExpress.XtraEditors.XtraForm

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.DocumentViewer1 = New DevExpress.XtraPrinting.Preview.DocumentViewer()
        Me.PanelReportActions = New DevExpress.XtraEditors.PanelControl()
        Me.BtnExportPdf = New DevExpress.XtraEditors.SimpleButton()
        Me.PdfViewer1 = New DevExpress.XtraPdfViewer.PdfViewer()
        Me.PanelNav = New DevExpress.XtraEditors.PanelControl()
        Me.LabelLampiranInfo = New DevExpress.XtraEditors.LabelControl()
        Me.BtnNextLampiran = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnPrevLampiran = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel1.SuspendLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel2.SuspendLayout()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.PanelReportActions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelReportActions.SuspendLayout()
        CType(Me.PanelNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelNav.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        '
        'SplitContainerControl1.Panel1
        '
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.DocumentViewer1)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.PanelReportActions)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        '
        'SplitContainerControl1.Panel2
        '
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.PdfViewer1)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.PanelNav)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1300, 750)
        Me.SplitContainerControl1.SplitterPosition = 708
        Me.SplitContainerControl1.TabIndex = 0
        '
        'DocumentViewer1
        '
        Me.DocumentViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DocumentViewer1.IsMetric = False
        Me.DocumentViewer1.Location = New System.Drawing.Point(0, 40)
        Me.DocumentViewer1.Name = "DocumentViewer1"
        Me.DocumentViewer1.Size = New System.Drawing.Size(708, 710)
        Me.DocumentViewer1.TabIndex = 0
        '
        'PanelReportActions
        '
        Me.PanelReportActions.Controls.Add(Me.BtnExportPdf)
        Me.PanelReportActions.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelReportActions.Location = New System.Drawing.Point(0, 0)
        Me.PanelReportActions.Name = "PanelReportActions"
        Me.PanelReportActions.Size = New System.Drawing.Size(708, 40)
        Me.PanelReportActions.TabIndex = 1
        '
        'BtnExportPdf
        '
        Me.BtnExportPdf.Location = New System.Drawing.Point(14, 7)
        Me.BtnExportPdf.Name = "BtnExportPdf"
        Me.BtnExportPdf.Size = New System.Drawing.Size(140, 24)
        Me.BtnExportPdf.TabIndex = 0
        Me.BtnExportPdf.Text = "Export to PDF"
        '
        'PdfViewer1
        '
        Me.PdfViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PdfViewer1.Location = New System.Drawing.Point(0, 40)
        Me.PdfViewer1.Name = "PdfViewer1"
        Me.PdfViewer1.Size = New System.Drawing.Size(584, 710)
        Me.PdfViewer1.TabIndex = 0
        '
        'PanelNav
        '
        Me.PanelNav.Controls.Add(Me.LabelLampiranInfo)
        Me.PanelNav.Controls.Add(Me.BtnNextLampiran)
        Me.PanelNav.Controls.Add(Me.BtnPrevLampiran)
        Me.PanelNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelNav.Name = "PanelNav"
        Me.PanelNav.Size = New System.Drawing.Size(584, 40)
        Me.PanelNav.TabIndex = 1
        Me.PanelNav.Visible = False
        '
        'LabelLampiranInfo
        '
        Me.LabelLampiranInfo.Appearance.Options.UseTextOptions = True
        Me.LabelLampiranInfo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelLampiranInfo.Location = New System.Drawing.Point(241, 18)
        Me.LabelLampiranInfo.Name = "LabelLampiranInfo"
        Me.LabelLampiranInfo.Size = New System.Drawing.Size(72, 13)
        Me.LabelLampiranInfo.TabIndex = 2
        Me.LabelLampiranInfo.Text = "Lampiran 1 / 1"
        '
        'BtnNextLampiran
        '
        Me.BtnNextLampiran.Location = New System.Drawing.Point(440, 7)
        Me.BtnNextLampiran.Name = "BtnNextLampiran"
        Me.BtnNextLampiran.Size = New System.Drawing.Size(90, 24)
        Me.BtnNextLampiran.TabIndex = 1
        Me.BtnNextLampiran.Text = "Next >"
        '
        'BtnPrevLampiran
        '
        Me.BtnPrevLampiran.Location = New System.Drawing.Point(14, 7)
        Me.BtnPrevLampiran.Name = "BtnPrevLampiran"
        Me.BtnPrevLampiran.Size = New System.Drawing.Size(90, 24)
        Me.BtnPrevLampiran.TabIndex = 0
        Me.BtnPrevLampiran.Text = "< Previous"
        '
        'XtraFormAfaPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1300, 750)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.IconOptions.Image = Global.AFASYSTEM.My.Resources.Resources.icondunlop
        Me.Name = "XtraFormAfaPreview"
        Me.Text = "AFA Preview"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.PanelReportActions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelReportActions.ResumeLayout(False)
        CType(Me.PanelNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelNav.ResumeLayout(False)
        Me.PanelNav.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents DocumentViewer1 As DevExpress.XtraPrinting.Preview.DocumentViewer
    Friend WithEvents PanelReportActions As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnExportPdf As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PdfViewer1 As DevExpress.XtraPdfViewer.PdfViewer
    Friend WithEvents PanelNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelLampiranInfo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnNextLampiran As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrevLampiran As DevExpress.XtraEditors.SimpleButton
End Class