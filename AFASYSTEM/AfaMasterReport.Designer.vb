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
        Me.components = New System.ComponentModel.Container()
        Dim XrWatermark1 As DevExpress.XtraReports.UI.XRWatermark = New DevExpress.XtraReports.UI.XRWatermark()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.AFA_NO = New DevExpress.XtraReports.UI.XRTableCell()
        Me.AFA_NO_APPROVAL = New DevExpress.XtraReports.UI.XRTableCell()
        Me.FINANCE_DEPT_DATE = New DevExpress.XtraReports.UI.XRTableCell()
        Me.APPROVED_DATE = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.DEPARTMENT_NAME = New DevExpress.XtraReports.UI.XRTableCell()
        Me.LOCATION_NAME = New DevExpress.XtraReports.UI.XRTableCell()
        Me.AFA_DATE = New DevExpress.XtraReports.UI.XRTableCell()
        Me.AFA_TYPE_NAME = New DevExpress.XtraReports.UI.XRLabel()
        Me.AFA_TYPE_COMPANY = New DevExpress.XtraReports.UI.XRLabel()
        Me.DetailReportSignature = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.DetailSignature = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.DetailReportHeader = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.DetailHeader = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.SUBJECT = New DevExpress.XtraReports.UI.XRLabel()
        Me.PURPOSE = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Background_AND_Explanation = New DevExpress.XtraReports.UI.XRLabel()
        Me.XtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter1 = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.DetailReportAttachment = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.DetailAttachment = New DevExpress.XtraReports.UI.DetailBand()
        Me.DetailReportSummary = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.DetailSummary = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 50.0!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 101.9096!
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
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.AFA_NO, Me.AFA_NO_APPROVAL, Me.FINANCE_DEPT_DATE, Me.APPROVED_DATE})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'AFA_NO
        '
        Me.AFA_NO.Multiline = True
        Me.AFA_NO.Name = "AFA_NO"
        Me.AFA_NO.StylePriority.UseTextAlignment = False
        Me.AFA_NO.Text = "[AFA_NO]"
        Me.AFA_NO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.AFA_NO.Weight = 0.99999966399647044R
        '
        'AFA_NO_APPROVAL
        '
        Me.AFA_NO_APPROVAL.Multiline = True
        Me.AFA_NO_APPROVAL.Name = "AFA_NO_APPROVAL"
        Me.AFA_NO_APPROVAL.Text = "[AFA_NO_APPROVAL]"
        Me.AFA_NO_APPROVAL.Weight = 1.0000003360035294R
        '
        'FINANCE_DEPT_DATE
        '
        Me.FINANCE_DEPT_DATE.Multiline = True
        Me.FINANCE_DEPT_DATE.Name = "FINANCE_DEPT_DATE"
        Me.FINANCE_DEPT_DATE.Text = "[FINANCE_DEPT_DATE]"
        Me.FINANCE_DEPT_DATE.Weight = 1.0R
        '
        'APPROVED_DATE
        '
        Me.APPROVED_DATE.Multiline = True
        Me.APPROVED_DATE.Name = "APPROVED_DATE"
        Me.APPROVED_DATE.Text = "[APPROVED_DATE]"
        Me.APPROVED_DATE.Weight = 1.0R
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
        Me.DEPARTMENT_NAME.Text = "[DEPARTMENT_NAME]"
        Me.DEPARTMENT_NAME.Weight = 1.0R
        '
        'LOCATION_NAME
        '
        Me.LOCATION_NAME.Multiline = True
        Me.LOCATION_NAME.Name = "LOCATION_NAME"
        Me.LOCATION_NAME.Text = "[LOCATION_NAME]"
        Me.LOCATION_NAME.Weight = 1.0R
        '
        'AFA_DATE
        '
        Me.AFA_DATE.Multiline = True
        Me.AFA_DATE.Name = "AFA_DATE"
        Me.AFA_DATE.Text = "[AFA_DATE]"
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
        'DetailReportSignature
        '
        Me.DetailReportSignature.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailSignature, Me.GroupHeader1})
        Me.DetailReportSignature.DataMember = "Signature"
        Me.DetailReportSignature.Level = 0
        Me.DetailReportSignature.Name = "DetailReportSignature"
        '
        'DetailSignature
        '
        Me.DetailSignature.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable3})
        Me.DetailSignature.HeightF = 60.0!
        Me.DetailSignature.Name = "DetailSignature"
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
        Me.XrTableCell8.Text = "[JAB_AUTH]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[NAMA_AUTH]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[STS_AUTH] [DATE_AUTH]"
        Me.XrTableCell8.Weight = 1.0R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Multiline = True
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Text = "[JAB_SUPP]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[NAMA_SUPP]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[STS_SUPP] [DATE_SUPP]"
        Me.XrTableCell9.Weight = 1.0R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Multiline = True
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.Text = "[JAB_DIR]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[NAMA_DIR]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[STS_DIR] [DATE_DIR]"
        Me.XrTableCell10.Weight = 1.0R
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
        'DetailReportHeader
        '
        Me.DetailReportHeader.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailHeader})
        Me.DetailReportHeader.DataMember = "Detail"
        Me.DetailReportHeader.Level = 1
        Me.DetailReportHeader.Name = "DetailReportHeader"
        '
        'DetailHeader
        '
        Me.DetailHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5, Me.XrLabel3, Me.Background_AND_Explanation, Me.XrLabel4, Me.PURPOSE, Me.SUBJECT, Me.XrLabel2, Me.XrLabel1})
        Me.DetailHeader.HeightF = 187.4931!
        Me.DetailHeader.Name = "DetailHeader"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(726.7717!, 18.65977!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.Text = "Subject:"
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.0001854367!, 37.3195!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(726.7717!, 16.92361!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.Text = "Purpose:"
        '
        'SUBJECT
        '
        Me.SUBJECT.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.SUBJECT.LocationFloat = New DevExpress.Utils.PointFloat(0!, 18.65975!)
        Me.SUBJECT.Multiline = True
        Me.SUBJECT.Name = "SUBJECT"
        Me.SUBJECT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.SUBJECT.SizeF = New System.Drawing.SizeF(726.7717!, 18.65977!)
        Me.SUBJECT.StylePriority.UseFont = False
        Me.SUBJECT.Text = "[SUBJECT]"
        '
        'PURPOSE
        '
        Me.PURPOSE.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.PURPOSE.LocationFloat = New DevExpress.Utils.PointFloat(0!, 54.24308!)
        Me.PURPOSE.Multiline = True
        Me.PURPOSE.Name = "PURPOSE"
        Me.PURPOSE.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.PURPOSE.SizeF = New System.Drawing.SizeF(726.7716!, 43.83334!)
        Me.PURPOSE.StylePriority.UseFont = False
        Me.PURPOSE.Text = "[PURPOSE]"
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0.0001854367!, 98.07639!)
        Me.XrLabel4.Multiline = True
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(726.7719!, 16.92361!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.Text = "Background & Explanation:"
        '
        'Background_AND_Explanation
        '
        Me.Background_AND_Explanation.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.Background_AND_Explanation.LocationFloat = New DevExpress.Utils.PointFloat(0.0004238552!, 115.0!)
        Me.Background_AND_Explanation.Multiline = True
        Me.Background_AND_Explanation.Name = "Background_AND_Explanation"
        Me.Background_AND_Explanation.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.Background_AND_Explanation.SizeF = New System.Drawing.SizeF(726.7716!, 53.83334!)
        Me.Background_AND_Explanation.StylePriority.UseFont = False
        Me.Background_AND_Explanation.Text = "[Background_AND_Explanation]"
        '
        'XrLabel6
        '
        Me.XrLabel6.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel6.Multiline = True
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(217.1876!, 101.5417!)
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.Text = "Checked By," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Budget Control" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[BUDGET_STS]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[BUDGET_CHECK_DATE]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[BUDGET_CHECK_B" &
    "Y]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(F & A)"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel6})
        Me.ReportFooter1.HeightF = 101.5417!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'DetailReportAttachment
        '
        Me.DetailReportAttachment.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailAttachment, Me.DetailReportSummary})
        Me.DetailReportAttachment.Level = 2
        Me.DetailReportAttachment.Name = "DetailReportAttachment"
        '
        'DetailAttachment
        '
        Me.DetailAttachment.HeightF = 106.4583!
        Me.DetailAttachment.Name = "DetailAttachment"
        '
        'DetailReportSummary
        '
        Me.DetailReportSummary.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailSummary})
        Me.DetailReportSummary.Level = 0
        Me.DetailReportSummary.Name = "DetailReportSummary"
        '
        'DetailSummary
        '
        Me.DetailSummary.Name = "DetailSummary"
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.0004238552!, 168.8333!)
        Me.XrLabel3.Multiline = True
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(73.99402!, 18.65977!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "Schedule:"
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New DevExpress.Drawing.DXFont("Arial", 10.0!, DevExpress.Drawing.DXFontStyle.Bold)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(73.99445!, 168.8333!)
        Me.XrLabel5.Multiline = True
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2.0!, 2.0!, 0!, 0!, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(652.7772!, 18.65977!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.Text = "Schedule:"
        '
        'AfaMasterReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.ReportHeader, Me.DetailReportSignature, Me.DetailReportHeader, Me.ReportFooter1, Me.DetailReportAttachment})
        Me.Font = New DevExpress.Drawing.DXFont("Arial", 9.75!)
        Me.Margins = New DevExpress.Drawing.DXMargins(50.0!, 50.0!, 50.0!, 101.9096!)
        Me.PageHeightF = 1169.291!
        Me.PageWidthF = 826.7717!
        Me.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4
        Me.Version = "25.1"
        XrWatermark1.Id = "Watermark1"
        Me.Watermarks.AddRange(New DevExpress.XtraPrinting.Drawing.Watermark() {XrWatermark1})
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents DetailReportSignature As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents DetailSignature As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents DetailReportHeader As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents DetailHeader As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents AFA_TYPE_NAME As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents AFA_TYPE_COMPANY As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents AFA_NO As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents AFA_NO_APPROVAL As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents FINANCE_DEPT_DATE As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents APPROVED_DATE As DevExpress.XtraReports.UI.XRTableCell
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
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents SUBJECT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PURPOSE As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Background_AND_Explanation As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents ReportFooter1 As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents DetailReportAttachment As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents DetailAttachment As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents DetailReportSummary As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents DetailSummary As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
End Class