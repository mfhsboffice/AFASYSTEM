Public Class AFAMonitoringService
    Inherits ClassKoneksi

    Private Shared ReadOnly ElevatedLevels As String() = {"FINANCE", "BUDGET ADMIN", "ADMIN"}

    Public Shared Function IsElevated(ByVal level As String) As Boolean
        Return Array.IndexOf(ElevatedLevels, If(level, "").Trim().ToUpperInvariant()) >= 0
    End Function

    Public Function GetList(ByVal afaType As String,
                            ByVal sts As String,
                            ByVal budgetSts As String,
                            ByVal priority As String,
                            ByVal nik As String,
                            ByVal scopeNik As String,
                            ByVal dateFrom As Object,
                            ByVal dateTo As Object) As DataTable

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaType", If(afaType, String.Empty)},
            {"@Sts", If(sts, String.Empty)},
            {"@BudgetSts", If(budgetSts, String.Empty)},
            {"@Priority", If(priority, String.Empty)},
            {"@Nik", If(nik, String.Empty)},
            {"@ScopeNik", If(scopeNik, String.Empty)},
            {"@DateFrom", dateFrom},
            {"@DateTo", dateTo}
        }

        Return ExecuteStoredProcedureQuery("AFA_NonIFS_Monitoring_Proc", prm)
    End Function

End Class