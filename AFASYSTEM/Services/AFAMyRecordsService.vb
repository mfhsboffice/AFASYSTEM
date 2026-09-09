Imports System.Data

Public Class AFAMyRecordsService
    Inherits ClassKoneksi

    Public Function GetMyDocuments(ByVal nik As String) As DataTable
        Dim prm As New Dictionary(Of String, Object) From {{"@Nik", nik}}
        Return ExecuteStoredProcedureQuery("AFA_NonIFS_GetMyDocuments_Proc", prm)
    End Function

    Public Function GetMyApprovalHistory(ByVal nik As String) As DataTable
        Dim prm As New Dictionary(Of String, Object) From {{"@Nik", nik}}
        Return ExecuteStoredProcedureQuery("AFA_NonIFS_GetMyApprovalHistory_Proc", prm)
    End Function

    Public Function Cancel(ByVal afaNo As String,
                           ByVal nik As String,
                           ByVal pc As String,
                           ByVal reason As String) As Boolean

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@Nik", nik},
            {"@Pc", pc},
            {"@Reason", reason}
        }

        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_Cancel_Proc", prm)
    End Function

End Class