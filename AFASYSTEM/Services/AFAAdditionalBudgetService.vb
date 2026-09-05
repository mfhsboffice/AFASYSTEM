Imports System.Data

Public Class AFAAdditionalBudgetService
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
            {"@AfaType", "ADD"},
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
    ''' Saves the (single) budget item row for an Additional Budget document.
    ''' Pass seq = 0 for a new row; the procedure assigns the next SEQ and
    ''' returns it.
    ''' </summary>
    Public Function SaveDetail(ByVal afaNo As String,
                               ByVal seq As Integer,
                               ByVal budgetItemCode As String,
                               ByVal budgetItemName As String,
                               ByVal cc As String,
                               ByVal contract As String,
                               ByVal budgetAmount As Decimal,
                               ByVal actualUp As Decimal,
                               ByVal estimation As Decimal,
                               ByVal nik As String,
                               ByVal pc As String,
                               ByRef savedSeq As Integer) As Boolean

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@Seq", seq},
            {"@BudgetItemCode", budgetItemCode},
            {"@BudgetItemName", budgetItemName},
            {"@Cc", cc},
            {"@Contract", contract},
            {"@BudgetAmount", budgetAmount},
            {"@ActualUp", actualUp},
            {"@Estimation", estimation},
            {"@Nik", nik},
            {"@Pc", pc}
        }

        Dim status As String = ""
        Dim message As String = ""

        Dim dt As DataTable = ExecuteStoredProcedureQueryWithStatus(
            "AFA_NonIFS_SaveDetail_ADD_Proc", prm, status, message)

        LastErrorMessage = message

        If status <> "SUCCESS" Then Return False

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            savedSeq = Convert.ToInt32(dt.Rows(0)("SEQ"))
        End If

        Return True
    End Function

    Public Function SaveAttachment(ByVal afaNo As String,
                                   ByVal seq As Integer,
                                   ByVal type As String,
                                   ByVal filePath As String,
                                   ByVal caption As String,
                                   ByVal nik As String) As Boolean

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@Seq", seq},
            {"@Type", type},
            {"@FilePath", filePath},
            {"@Caption", caption},
            {"@Nik", nik}
        }

        Dim status As String = ""
        Dim message As String = ""

        ExecuteStoredProcedureQueryWithStatus("AFA_NonIFS_SaveAttachment_Proc", prm, status, message)

        LastErrorMessage = message
        Return status = "SUCCESS"
    End Function

End Class
