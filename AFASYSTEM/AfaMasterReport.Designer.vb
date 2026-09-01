<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class AfaMasterReport
    Inherits DevExpress.XtraReports.UI.XtraReport

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
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.AFA_NO_APPROVAL = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.DEPARTMENT_NAME = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LOCATION_NAME = New DevExpress.XtraReports.UI.XRTableCell()
        Me.AFA_DATE = New DevExpress.XtraReports.UI.XRTableCell()
        Me.AFA_TYPE_NAME = New DevExpress.XtraReports.UI.XRLabel()
        Me.AFA_TYPE_COMPANY = New DevExpress.XtraReports.UI.XRLabel()
        Me.DetailReport1 = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.Detail1 = New DevExpress.XtraReports.UI.DetailBand()
        Me.DetailReport2 = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.Detail2 = New DevExpress.XtraReports.UI.DetailBand()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 50.0!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 50.0!
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.Expanded = False
        Me.Detail.HeightF = 0!
        Me.Detail.Name = "Detail"
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.AFA_TYPE_NAME, Me.AFA_TYPE_COMPANY})
        Me.ReportHeader.HeightF = 105.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrTable1
        '
        Me.XrTable1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 46.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1, Me.XrTableRow2})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(726.7717!, 50.0!)
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UseTextAlignment = False
        Me.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.AFA_NO_APPROVAL, Me.XrTableCell3, Me.XrTableCell7})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Multiline = True
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Text = "Approval No"
        Me.XrTableCell1.Weight = 0.99999966399647044R
        '
        'AFA_NO_APPROVAL
        '
        Me.AFA_NO_APPROVAL.Multiline = True
        Me.AFA_NO_APPROVAL.Name = "AFA_NO_APPROVAL"
        Me.AFA_NO_APPROVAL.Text = "[AFA_NO_APPROVAL]"
        Me.AFA_NO_APPROVAL.Weight = 1.0000003360035294R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Multiline = True
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Text = ""
        Me.XrTableCell3.Weight = 1.0R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Multiline = True
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Text = "Approved Date:"
        Me.XrTableCell7.Weight = 1.0R
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.DEPARTMENT_NAME, Me.LOCATION_NAME, Me.AFA_DATE})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Multiline = True
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Text = "Submitted by"
        Me.XrTableCell4.Weight = 1.0R
        '
        'DEPARTMENT_NAME
        '
        Me.DEPARTMENT_NAME.Multiline = True
        Me.DEPARTMENT_NAME.Name = "DEPARTMENT_NAME"
        Me.DEPARTMENT_NAME.Text = "Required by [DEPARTMENT_NAME]"
        Me.DEPARTMENT_NAME.Weight = 1.0R
        '
        'LOCATION_NAME
        '
        Me.LOCATION_NAME.Multiline = True
        Me.LOCATION_NAME.Name = "LOCATION_NAME"
        Me.LOCATION_NAME.Text = "Location [LOCATION_NAME]"
        Me.LOCATION_NAME.Weight = 1.0R
        '
        'AFA_DATE
        '
        Me.AFA_DATE.Multiline = True
        Me.AFA_DATE.Name = "AFA_DATE"
        Me.AFA_DATE.Text = "Date [AFA_DATE]"
        Me.AFA_DATE.Weight = 1.0R
        '
        'AFA_TYPE_NAME
        '
        Me.AFA_TYPE_NAME.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, CType((DevExpress.Drawing.DXFontStyle.Bold Or DevExpress.Drawing.DXFontStyle.Underline), DevExpress.Drawing.DXFontStyle))
        Me.AFA_TYPE_NAME.LocationFloat = New DevExpress.Utils.PointFloat(283.3333!, 23.0!)
        Me.AFA_TYPE_NAME.Multiline = True
        Me.AFA_TYPE_NAME.Name = "AFA_TYPE_NAME"
        Me.AFA_TYPE_NAME.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.AFA_TYPE_NAME.SizeF = New System.Drawing.SizeF(152.0833!, 23.0!)
        Me.AFA_TYPE_NAME.StylePriority.UseFont = False
        Me.AFA_TYPE_NAME.StylePriority.UseTextAlignment = False
        Me.AFA_TYPE_NAME.Text = "[AFA_TYPE_NAME]"
        Me.AFA_TYPE_NAME.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'AFA_TYPE_COMPANY
        '
        Me.AFA_TYPE_COMPANY.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.AFA_TYPE_COMPANY.Multiline = True
        Me.AFA_TYPE_COMPANY.Name = "AFA_TYPE_COMPANY"
        Me.AFA_TYPE_COMPANY.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.AFA_TYPE_COMPANY.SizeF = New System.Drawing.SizeF(726.7717!, 23.0!)
        Me.AFA_TYPE_COMPANY.Text = "PT SUMI RUBBER INDONESIA"
        '
        'DetailReport1
        '
        Me.DetailReport1.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail1, Me.GroupHeader1})
        Me.DetailReport1.DataMember = "Signature"
        Me.DetailReport1.Level = 0
        Me.DetailReport1.Name = "DetailReport1"
        '
        'Detail1
        '
        Me.Detail1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable3})
        Me.Detail1.HeightF = 60.0!
        Me.Detail1.Name = "Detail1"
        '
        'DetailReport2
        '
        Me.DetailReport2.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail2})
        Me.DetailReport2.DataMember = "Detail"
        Me.DetailReport2.Level = 1
        Me.DetailReport2.Name = "DetailReport2"
        '
        'Detail2
        '
        Me.Detail2.Name = "Detail2"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.GroupHeader1.HeightF = 25.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'XrTable2
        '
        Me.XrTable2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(726.7718!, 25.0!)
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell2, Me.XrTableCell5, Me.XrTableCell6})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Multiline = True
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Text = "Authorized Signatures/Date"
        Me.XrTableCell2.Weight = 1.0R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Multiline = True
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Text = "Supporting Signatures/Date"
        Me.XrTableCell5.Weight = 1.0R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Multiline = True
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Text = "Direct Signatures/Date"
        Me.XrTableCell6.Weight = 1.0R
        '
        'XrTable3
        '
        Me.XrTable3.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Padding = New DevExpress.XtraPrinting.PaddingInfo(3.0!, 3.0!, 3.0!, 3.0!, 100.0!)
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(726.7718!, 60.0!)
        Me.XrTable3.StylePriority.UseBorders = False
        Me.XrTable3.StylePriority.UseTextAlignment = False
        Me.XrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell8, Me.XrTableCell9, Me.XrTableCell10})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 1.0R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Multiline = True
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.Text = "[JAB_AUTH]" & Global.Microsoft.VisualBasic.Chr(13) & Global.Microsoft.VisualBasic.Chr(10) & "[NAMA_AUTH]" & Global.Microsoft.VisualBasic.Chr(13) & Global.Microsoft.VisualBasic.Chr(10) & "[STS_AUTH] [DATE_AUTH]"
        Me.XrTableCell8.Weight = 1.0R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Multiline = True
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Text = "[JAB_SUPP]" & Global.Microsoft.VisualBasic.Chr(13) & Global.Microsoft.VisualBasic.Chr(10) & "[NAMA_SUPP]" & Global.Microsoft.VisualBasic.Chr(13) & Global.Microsoft.VisualBasic.Chr(10) & "[STS_SUPP] [DATE_SUPP]"
        Me.XrTableCell9.Weight = 1.0R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Multiline = True
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.Text = "[JAB_DIR]" & Global.Microsoft.VisualBasic.Chr(13) & Global.Microsoft.VisualBasic.Chr(10) & "[NAMA_DIR]" & Global.Microsoft.VisualBasic.Chr(13) & Global.Microsoft.VisualBasic.Chr(10) & "[STS_DIR] [DATE_DIR]"
        Me.XrTableCell10.Weight = 1.0R
        '
        'AfaMasterReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.ReportHeader, Me.DetailReport1, Me.DetailReport2})
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(50.0!, 50.0!, 50.0!, 50.0!)
        Me.PageHeightF = 1169.291!
        Me.PageWidthF = 826.7717!
        Me.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4
        Me.Version = "25.1"
        XrWatermark1.Id = "Watermark1"
        Me.Watermarks.AddRange(New DevExpress.XtraPrinting.Drawing.Watermark() {XrWatermark1})
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents DetailReport1 As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents Detail1 As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents DetailReport2 As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents Detail2 As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents AFA_TYPE_NAME As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents AFA_TYPE_COMPANY As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents AFA_NO_APPROVAL As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DEPARTMENT_NAME As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents LOCATION_NAME As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents AFA_DATE As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
End Class