Imports System.Data

Public Class UnconfiguredDocumentsService
    Inherits ClassKoneksi

    Public Function GetList(ByVal nik As String, ByVal afaType As String) As DataTable
        Dim prm As New Dictionary(Of String, Object) From {
            {"@Nik", nik},
            {"@AfaType", If(afaType, String.Empty)}
        }

        Return ExecuteStoredProcedureQuery("AFA_NonIFS_GetUnconfigured_Proc", prm)
    End Function

End Class