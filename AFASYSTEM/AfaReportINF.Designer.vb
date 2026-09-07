<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class AfaReportINF
    Inherits AFASYSTEM.AfaMasterReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim XrWatermark1 As DevExpress.XtraReports.UI.XRWatermark = New DevExpress.XtraReports.UI.XRWatermark()
        Me.ESTIMATE = New DevExpress.XtraReports.UI.XRLabel()
        Me.ESTIMATE_COST = New DevExpress.XtraReports.UI.XRLabel()
        Me.DetailReportSummary = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.DetailSummary = New DevExpress.XtraReports.UI.DetailBand()
        Me.LblEstimateCost = New DevExpress.XtraReports.UI.XRLabel()
        Me.EstimateCost = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'AFA_TYPE_NAME
        '
        Me.AFA_TYPE_NAME.StylePriority.UseFont = False
        Me.AFA_TYPE_NAME.StylePriority.UseTextAlignment = False
        '
        'XrTable1
        '
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UseTextAlignment = False
        '
        'AFA_NO
        '
        Me.AFA_NO.StylePriority.UseTextAlignment = False
        '
        'XrTable2
        '
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        '
        'XrTable3
        '
        Me.XrTable3.StylePriority.UseBorders = False
        Me.XrTable3.StylePriority.UseTextAlignment = False
        '
        'XrLabel1
        '
        Me.XrLabel1.StylePriority.UseFont = False
        '
        'XrLabel2
        '
        Me.XrLabel2.StylePriority.UseFont = False
        '
        'SUBJECT
        '
        Me.SUBJECT.StylePriority.UseFont = False
        '
        'PURPOSE
        '
        Me.PURPOSE.StylePriority.UseFont = False
        '
        'Background_AND_Explanation
        '
        Me.Background_AND_Explanation.StylePriority.UseFont = False
        '
        'XrLabel4
        '
        Me.XrLabel4.StylePriority.UseFont = False
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Expanded = False
        '
        'XrLabel3
        '
        Me.XrLabel3.StylePriority.UseFont = False
        '
        'SCHEDULE
        '
        Me.SCHEDULE.StylePriority.UseFont = False
        '
        'ESTIMATE
        '
        Me.ESTIMATE.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
        Me.ESTIMATE.Multiline = True
        Me.ESTIMATE.Name = "ESTIMATE"
        Me.ESTIMATE.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.ESTIMATE.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.ESTIMATE.Text = "Estimate Cost: "
        '
        'ESTIMATE_COST
        '
        Me.ESTIMATE_COST.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AMOUNT]")})
        Me.ESTIMATE_COST.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 10.00004!)
        Me.ESTIMATE_COST.Multiline = True
        Me.ESTIMATE_COST.Name = "ESTIMATE_COST"
        Me.ESTIMATE_COST.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.ESTIMATE_COST.SizeF = New System.Drawing.SizeF(166.6667!, 23.0!)
        Me.ESTIMATE_COST.TextFormatString = "{0:n0}"
        '
        'DetailReportSummary
        '
        Me.DetailReportSummary.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailSummary})
        Me.DetailReportSummary.Level = 3
        Me.DetailReportSummary.Name = "DetailReportSummary"
        '
        'DetailSummary
        '
        Me.DetailSummary.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.EstimateCost, Me.LblEstimateCost})
        Me.DetailSummary.HeightF = 38.54167!
        Me.DetailSummary.Name = "DetailSummary"
        '
        'LblEstimateCost
        '
        Me.LblEstimateCost.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.LblEstimateCost.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.LblEstimateCost.Multiline = True
        Me.LblEstimateCost.Name = "LblEstimateCost"
        Me.LblEstimateCost.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.LblEstimateCost.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.LblEstimateCost.StylePriority.UseFont = False
        Me.LblEstimateCost.StylePriority.UseTextAlignment = False
        Me.LblEstimateCost.Text = "Estimate Cost"
        Me.LblEstimateCost.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'EstimateCost
        '
        Me.EstimateCost.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.EstimateCost.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 0!)
        Me.EstimateCost.Multiline = True
        Me.EstimateCost.Name = "EstimateCost"
        Me.EstimateCost.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.EstimateCost.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.EstimateCost.StylePriority.UseFont = False
        Me.EstimateCost.StylePriority.UseTextAlignment = False
        Me.EstimateCost.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.EstimateCost.ExpressionBindings.Add(New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AMOUNT]"))
        Me.EstimateCost.TextFormatString = "{0:n0}"
        '
        'AfaReportINF
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.ReportHeader, Me.DetailReportSignature, Me.DetailReportHeader, Me.ReportFooter1, Me.DetailReportAttachment, Me.DetailReportSummary})
        Me.Version = "25.1"
        XrWatermark1.Id = "Watermark1"
        Me.Watermarks.AddRange(New DevExpress.XtraPrinting.Drawing.Watermark() {XrWatermark1})
        Me.Controls.SetChildIndex(Me.DetailReportSummary, 0)
        Me.Controls.SetChildIndex(Me.DetailReportAttachment, 0)
        Me.Controls.SetChildIndex(Me.ReportFooter1, 0)
        Me.Controls.SetChildIndex(Me.DetailReportHeader, 0)
        Me.Controls.SetChildIndex(Me.DetailReportSignature, 0)
        Me.Controls.SetChildIndex(Me.ReportHeader, 0)
        Me.Controls.SetChildIndex(Me.Detail, 0)
        Me.Controls.SetChildIndex(Me.BottomMargin, 0)
        Me.Controls.SetChildIndex(Me.TopMargin, 0)
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents ESTIMATE As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ESTIMATE_COST As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents DetailReportSummary As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents DetailSummary As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents LblEstimateCost As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents EstimateCost As DevExpress.XtraReports.UI.XRLabel
End Class
