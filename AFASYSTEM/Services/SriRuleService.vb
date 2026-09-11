Imports System.Data
Public Class SriRuleService
    Inherits ClassKoneksi

    Public Function GetRuleList() As DataTable
        Return ExecuteStoredProcedureQuery("AFA_NonIFS_GetSriRuleList_Proc",
                                           New Dictionary(Of String, Object))
    End Function

    Public Function GetJabSignList() As DataTable
        Return ExecuteStoredProcedureQuery("AFA_NonIFS_GetJabSignList_Proc",
                                           New Dictionary(Of String, Object))
    End Function

    Public Function SaveRule(ByVal afaType As String,
                             ByVal subType As String,
                             ByVal sriAlways As Boolean,
                             ByVal sriThreshold As Decimal?,
                             ByVal refReg As String,
                             ByVal auth1Jab As String,
                             ByVal auth2Jab As String,
                             ByVal isActive As Boolean,
                             ByVal nikUpdate As String) As Boolean
        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaType", afaType},
            {"@SubType", subType},
            {"@SriAlways", sriAlways},
            {"@SriThreshold", If(sriThreshold.HasValue, CObj(sriThreshold.Value), DBNull.Value)},
            {"@RefReg", If(String.IsNullOrEmpty(refReg), CObj(DBNull.Value), refReg)},
            {"@Auth1Jab", If(String.IsNullOrEmpty(auth1Jab), CObj(DBNull.Value), auth1Jab)},
            {"@Auth2Jab", If(String.IsNullOrEmpty(auth2Jab), CObj(DBNull.Value), auth2Jab)},
            {"@IsActive", isActive},
            {"@NikUpdate", nikUpdate}
        }
        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_SaveSriRule_Proc", prm)
    End Function

End Class