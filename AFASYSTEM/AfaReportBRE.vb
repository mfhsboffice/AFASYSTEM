Imports DevExpress.Drawing

Public Class AfaReportBRE

    Public Sub New()
        InitializeComponent()
        AddHandler XrTableCell1.BeforePrint, AddressOf CellSummary_BeforePrint
        AddHandler XrTableCell3.BeforePrint, AddressOf CellSummary_BeforePrint
    End Sub

    Private Sub CellSummary_BeforePrint(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim cell As DevExpress.XtraReports.UI.XRTableCell = CType(sender, DevExpress.XtraReports.UI.XRTableCell)

        Dim isBold As Boolean = Convert.ToBoolean(DetailReportSummary.GetCurrentColumnValue("IS_BOLD"))

        cell.Font = New DXFont(cell.Font, If(isBold, DXFontStyle.Bold, DXFontStyle.Regular))
    End Sub

End Class