Imports System.Data

Public Class AfaTypeService
    Inherits ClassKoneksi

#Region "AFA Type"

    Public Function GetTypeList() As DataTable
        Return ExecuteStoredProcedureQuery("AFA_NonIFS_GetTypeList_Proc",
                                           New Dictionary(Of String, Object))
    End Function

    Public Function SaveType(ByVal code As String,
                             ByVal name As String,
                             ByVal descr As String,
                             ByVal isActive As Boolean) As Boolean
        Dim prm As New Dictionary(Of String, Object) From {
            {"@Code", code},
            {"@Name", name},
            {"@Descr", If(String.IsNullOrEmpty(descr), CObj(DBNull.Value), descr)},
            {"@IsActive", isActive}
        }
        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_SaveType_Proc", prm)
    End Function

#End Region

#Region "AFA Sub-Type"
    Public Function GetSubTypeList(ByVal afaType As String) As DataTable
        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaType", afaType}
        }
        Return ExecuteStoredProcedureQuery("AFA_NonIFS_GetSubTypeList_Proc", prm)
    End Function

    Public Function SaveSubType(ByVal afaType As String,
                                ByVal code As String,
                                ByVal name As String,
                                ByVal seq As Integer,
                                ByVal isActive As Boolean) As Boolean
        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaType", afaType},
            {"@Code", code},
            {"@Name", name},
            {"@Seq", seq},
            {"@IsActive", isActive}
        }
        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_SaveSubType_Proc", prm)
    End Function

#End Region

End Class