<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class AfaReportADD
    Inherits AFASYSTEM.AfaMasterReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim XrWatermark1 As DevExpress.XtraReports.UI.XRWatermark = New DevExpress.XtraReports.UI.XRWatermark()
        Me.DetailReportSummary = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.DetailSummary = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTableSummary = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTableSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DetailHeader
        '
        Me.DetailHeader.HeightF = 205.8333!
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
        Me.XrTable2.StylePriority.UseFont = False
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
        'DetailAttachment
        '
        Me.DetailAttachment.HeightF = 116.2916!
        '
        'XrLabel3
        '
        Me.XrLabel3.StylePriority.UseFont = False
        '
        'SCHEDULE
        '
        Me.SCHEDULE.StylePriority.UseFont = False
        '
        'CAPTION
        '
        Me.CAPTION.StylePriority.UseFont = False
        Me.CAPTION.StylePriority.UseTextAlignment = False
        '
        'DetailReportSummary
        '
        Me.DetailReportSummary.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailSummary})
        Me.DetailReportSummary.Level = 3
        Me.DetailReportSummary.Name = "DetailReportSummary"
        '
        'DetailSummary
        '
        Me.DetailSummary.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTableSummary})
        Me.DetailSummary.HeightF = 20.0!
        Me.DetailSummary.Name = "DetailSummary"
        '
        'XrTableSummary
        '
        Me.XrTableSummary.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTableSummary.Name = "XrTableSummary"
        Me.XrTableSummary.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.XrTableSummary.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow5})
        Me.XrTableSummary.SizeF = New System.Drawing.SizeF(726.772!, 20.0!)
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell3})
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.CanGrow = False
        Me.XrTableCell1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[LABEL]")})
        Me.XrTableCell1.Multiline = True
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Weight = 1.0R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.CanGrow = False
        Me.XrTableCell3.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AMOUNT]")})
        Me.XrTableCell3.Multiline = True
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.TextFormatString = "{0:n2}"
        Me.XrTableCell3.Weight = 1.0R
        '
        'AfaReportADD
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
        CType(Me.XrTableSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents DetailReportSummary As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents DetailSummary As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrTableSummary As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
End Class