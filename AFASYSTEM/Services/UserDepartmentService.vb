Imports System.Data

Public Class UserDepartmentService
    Inherits ClassKoneksi

    Public Function GetList(ByVal keyword As String) As DataTable
        Dim prm As New Dictionary(Of String, Object) From {
            {"@Keyword", If(keyword, String.Empty)}
        }
        Return ExecuteStoredProcedureQuery("AFA_NonIFS_GetUserDepartmentList_Proc", prm)
    End Function

    Public Function GetByNik(ByVal nik As String) As DataTable
        Dim prm As New Dictionary(Of String, Object) From {
            {"@Nik", nik}
        }
        Return ExecuteStoredProcedureQuery("AFA_NonIFS_GetUserDepartment_Proc", prm)
    End Function

    Public Function Save(ByVal nik As String,
                         ByVal deptIds As String,
                         ByVal nikUpdate As String,
                         ByVal pc As String) As Boolean
        Dim prm As New Dictionary(Of String, Object) From {
            {"@Nik", nik},
            {"@DeptIds", deptIds},
            {"@NikUpdate", nikUpdate},
            {"@Pc", pc}
        }
        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_SaveUserDepartment_Proc", prm)
    End Function

    Public Function DeleteByNik(ByVal nik As String) As Boolean
        Dim prm As New Dictionary(Of String, Object) From {
            {"@Nik", nik}
        }
        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_DeleteUserDepartment_Proc", prm)
    End Function

End Class