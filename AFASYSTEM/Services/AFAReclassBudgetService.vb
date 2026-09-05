Imports System.Data

Public Class AFAReclassBudgetService
    Inherits ClassKoneksi

    Public Function SaveHeader(ByVal afaNo As String,
                               ByVal afaLocation As String,
                               ByVal deptId As Integer,
                               ByVal budgetYear As String,
                               ByVal budgetRev As String,
                               ByVal subject As String,
                               ByVal purposes As String,
                               ByVal bgExplanation As String,
                               ByVal curcode As String,
                               ByVal perFrom As Object,
                               ByVal perTo As Object,
                               ByVal nik As String,
                               ByVal pc As String) As String

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", If(afaNo, String.Empty)},
            {"@AfaType", "BRE"},
            {"@AfaLocation", afaLocation},
            {"@DeptId", deptId},
            {"@BudgetYear", budgetYear},
            {"@BudgetRev", budgetRev},
            {"@Subject", subject},
            {"@Purposes", purposes},
            {"@BgExplanation", bgExplanation},
            {"@Notetext", Nothing},
            {"@Curcode", curcode},
            {"@Priority", CByte(0)},
            {"@PriorityReason", Nothing},
            {"@PerFrom", perFrom},
            {"@PerTo", perTo},
            {"@Nik", nik},
            {"@Pc", pc}
        }

        Dim status As String = ""
        Dim message As String = ""

        Dim dt As DataTable = ExecuteStoredProcedureQueryWithStatus(
            "AFA_NonIFS_SaveHeader_Proc", prm, status, message)

        LastErrorMessage = message

        If status <> "SUCCESS" Then Return String.Empty
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return String.Empty

        Return Convert.ToString(dt.Rows(0)("AFA_NO"))
    End Function

    ''' <summary>
    ''' Saves one Source or Target budget item row. Pass seq = 0 for a new
    ''' row (the procedure assigns the next SEQ and returns it); pass an
    ''' existing SEQ to update that row. reclassFromSeq is required (and
    ''' must reference an existing Source row) when itemRole = "Target",
    ''' and must be Nothing when itemRole = "Source".
    ''' </summary>
    Public Function SaveDetail(ByVal afaNo As String,
                               ByVal seq As Integer,
                               ByVal itemRole As String,
                               ByVal budgetItemCode As String,
                               ByVal budgetItemName As String,
                               ByVal cc As String,
                               ByVal contract As String,
                               ByVal budgetAmount As Decimal,
                               ByVal actualUp As Decimal,
                               ByVal estimation As Object,
                               ByVal reclassFromSeq As Object,
                               ByVal nik As String,
                               ByVal pc As String,
                               ByRef savedSeq As Integer) As Boolean

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@Seq", seq},
            {"@ItemRole", itemRole},
            {"@BudgetItemCode", budgetItemCode},
            {"@BudgetItemName", budgetItemName},
            {"@Cc", cc},
            {"@Contract", contract},
            {"@BudgetAmount", budgetAmount},
            {"@ActualUp", actualUp},
            {"@Estimation", estimation},
            {"@ReclassFromSeq", reclassFromSeq},
            {"@Nik", nik},
            {"@Pc", pc}
        }

        Dim status As String = ""
        Dim message As String = ""

        Dim dt As DataTable = ExecuteStoredProcedureQueryWithStatus(
            "AFA_NonIFS_SaveDetail_BRE_Proc", prm, status, message)

        LastErrorMessage = message

        If status <> "SUCCESS" Then Return False

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            savedSeq = Convert.ToInt32(dt.Rows(0)("SEQ"))
        End If

        Return True
    End Function

End Class
