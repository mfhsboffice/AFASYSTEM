Imports System.Data

Public Class AFASignatureService
    Inherits ClassKoneksi

    Public Function GetDocument(ByVal afaNo As String) As DataTable
        Dim prm As New Dictionary(Of String, Object) From {{"@AfaNo", afaNo}}
        Return ExecuteStoredProcedureQuery("AFA_NonIFS_GetForSignature_Proc", prm)
    End Function

    Public Function GetNodes(ByVal afaNo As String) As DataTable
        Dim prm As New Dictionary(Of String, Object) From {{"@AfaNo", afaNo}}
        Return ExecuteStoredProcedureQuery("AFA_NonIFS_GetSignature_Proc", prm)
    End Function

    Public Function SaveNode(ByVal afaNo As String,
                             ByVal jenis As String,
                             ByVal id As Integer,
                             ByVal nik As String,
                             ByVal jab As String,
                             ByVal nikCreate As String,
                             ByVal pc As String) As Boolean

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@Jenis", jenis},
            {"@Id", id},
            {"@Nik", nik},
            {"@Jab", jab},
            {"@NikCreate", nikCreate},
            {"@Pc", pc}
        }

        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_Signature_Proc", prm)
    End Function

    Public Function UpdatePriority(ByVal afaNo As String,
                                   ByVal priority As Byte,
                                   ByVal reason As String,
                                   ByVal nik As String,
                                   ByVal pc As String) As Boolean

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@Priority", priority},
            {"@Reason", reason},
            {"@Nik", nik},
            {"@Pc", pc}
        }

        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_UpdatePriority_Proc", prm)
    End Function

    Public Function Submit(ByVal afaNo As String,
                           ByVal nik As String,
                           ByVal pc As String) As Boolean

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@Nik", nik},
            {"@Pc", pc}
        }

        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_Submit_Proc", prm)
    End Function

    Public Function Approve(ByVal afaNo As String,
                            ByVal jenis As String,
                            ByVal nik As String,
                            ByVal pc As String,
                            ByVal actionType As String,
                            ByVal reason As String) As Boolean

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@Jenis", jenis},
            {"@Nik", nik},
            {"@Pc", pc},
            {"@Type", actionType},
            {"@Reason", reason}
        }

        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_App_Proc", prm)
    End Function

    Public Function Skip(ByVal afaNo As String,
                         ByVal jenis As String,
                         ByVal id As Integer,
                         ByVal nik As String,
                         ByVal pc As String,
                         ByVal reason As String) As Boolean

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@Jenis", jenis},
            {"@Id", id},
            {"@Nik", nik},
            {"@Pc", pc},
            {"@Reason", reason}
        }

        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_Skip_Proc", prm)
    End Function

    Public Function InitNodes(ByVal afaNo As String,
                              ByVal maxRow As Integer,
                              ByVal nik As String,
                              ByVal pc As String) As Boolean

        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@MaxRow", maxRow},
            {"@Nik", nik},
            {"@Pc", pc}
        }

        Return ExecuteStoredProcedureWithStatus("AFA_NonIFS_InitSignature_Proc", prm)
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

    Public Function GetAttachments(ByVal afaNo As String) As DataTable
        Dim sql As String =
            "SELECT SEQ, TYPE, FILE_PATH, CAPTION " &
            "FROM   dbo.AFA_NON_IFS_ATTACHMENT " &
            "WHERE  AFA_NO = ? " &
            "ORDER  BY TYPE DESC, SEQ"

        Dim prm As New List(Of Object) From {afaNo}
        Return ExecuteQuery(sql, prm)
    End Function


    Public Function GetNodesGrid(ByVal afaNo As String, ByVal maxRow As Integer) As DataTable
        Dim prm As New Dictionary(Of String, Object) From {
            {"@AfaNo", afaNo},
            {"@MaxRow", maxRow}
        }
        Return ExecuteStoredProcedureQuery("AFA_NonIFS_GetSignatureGrid_Proc", prm)
    End Function

    Public Function GetApprovers(ByVal jenis As String) As DataTable
        Dim sql As String

        Select Case jenis
            Case "Auth"
                sql = "SELECT Auth_NIK AS NIK, Authorized AS NAMA, Auth_Jab AS JAB " &
                      "FROM dbo.LIST_APPROVER_AUTH_NEW ORDER BY Authorized"
            Case "Supp"
                sql = "SELECT Supp_NIK AS NIK, Supporting AS NAMA, Supp_Jab AS JAB " &
                      "FROM dbo.LIST_APPROVER_SUPP_NEW ORDER BY Supporting"
            Case "Dir"
                sql = "SELECT Dir_NIK AS NIK, Direct AS NAMA, Dir_Jab AS JAB " &
                      "FROM dbo.LIST_APPROVER_DIR_NEW ORDER BY Direct"
            Case Else
                Return Nothing
        End Select

        Return ExecuteQuery(sql, New List(Of Object))
    End Function
    Public Function GetDisposalFigures(ByVal afaNo As String) As DataTable
        Dim sql As String =
            "SELECT TOP 1 SUB_TYPE, ACQUISITION, ACCUM_DEPRECIATION, " &
            "       BOOK_VALUE, RESELL_VALUE, PROFIT_LOSS " &
            "FROM   dbo.AFA_NON_IFS_DAA " &
            "WHERE  AFA_NO = ? " &
            "ORDER  BY SEQ"

        Dim prm As New List(Of Object) From {afaNo}
        Return ExecuteQuery(sql, prm)
    End Function
End Class