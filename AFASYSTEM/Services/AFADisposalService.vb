Imports System.Data

Public Class AFADisposalService
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
            {"@AfaType", "DAA"},
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

    Public Function SaveDetail(ByVal afaNo As String,
                               ByVal subType As String,
                               ByVal acquisition As Decimal,
                               ByVal accumDep As Decimal,
                               ByVal resellValue As Decimal,
                               ByVal nik As String,
                               ByVal pc As String) As Boolean

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@SubType", subType},
            {"@Acquisition", acquisition},
            {"@AccumDep", accumDep},
            {"@ResellValue", resellValue},
            {"@Nik", nik},
            {"@Pc", pc}
        }

        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_SaveDetail_DAA_Proc", prm)
    End Function

    Public Function SaveAttachment(ByVal afaNo As String,
                                   ByVal seq As Integer,
                                   ByVal type As String,
                                   ByVal fileName As String,
                                   ByVal caption As String,
                                   ByVal nik As String) As Boolean

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@Seq", seq},
            {"@Type", type},
            {"@FilePath", fileName},
            {"@Caption", caption},
            {"@Nik", nik}
        }

        Dim status As String = ""
        Dim message As String = ""

        ExecuteStoredProcedureQueryWithStatus("AFA_NonIFS_SaveAttachment_Proc", prm, status, message)

        LastErrorMessage = message
        Return status = "SUCCESS"
    End Function

    Public Function ApplySRI(ByVal afaNo As String) As String
        Dim prm As New Dictionary(Of String, Object) From {{"@AfaNo", afaNo}}

        Dim status As String = ""
        Dim message As String = ""

        Dim dt As DataTable = ExecuteStoredProcedureQueryWithStatus(
            "AFA_NonIFS_ApplySRI_Proc", prm, status, message)

        LastErrorMessage = message

        If status <> "SUCCESS" Then Return String.Empty
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return String.Empty

        Return Convert.ToString(dt.Rows(0)("SRI_STS"))
    End Function

End Class