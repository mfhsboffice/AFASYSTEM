Imports System.Data

Public Class GeneralService
    Inherits ClassKoneksi

    Private Shared _cacheLocation As DataTable
    Private Shared _cacheDepartment As DataTable
    Private Shared _cacheAfaType As DataTable
    Private Shared _cacheSubType As New Dictionary(Of String, DataTable)
    Private Shared _cacheBudgetYear As DataTable
    Private Shared _cacheCurrency As DataTable

    Private Shared ReadOnly NoParam As New List(Of Object)

    Public Shared Sub ClearCache()
        _cacheLocation = Nothing
        _cacheDepartment = Nothing
        _cacheAfaType = Nothing
        _cacheBudgetYear = Nothing
        _cacheCurrency = Nothing
        _cacheSubType.Clear()
    End Sub

#Region "Location"

    Public Function GetLocations(Optional ByVal useCache As Boolean = True) As DataTable
        If useCache AndAlso _cacheLocation IsNot Nothing Then Return _cacheLocation

        Dim sql As String =
            "SELECT CODE, NAME " &
            "FROM   dbo.AFA_LOCATION " &
            "WHERE  IS_ACTIVE = 1 " &
            "ORDER  BY NAME"

        Dim dt As DataTable = ExecuteQuery(sql, NoParam)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then _cacheLocation = dt
        Return dt
    End Function

#End Region

#Region "Department"

    Public Function GetDepartments(Optional ByVal useCache As Boolean = True) As DataTable
        If useCache AndAlso _cacheDepartment IsNot Nothing Then Return _cacheDepartment

        Dim sql As String =
            "SELECT DEPT_ID, DEPT_NAME, PREFIX, " &
            "       DEPT_NAME + ' (' + PREFIX + ')' AS DISPLAY_NAME " &
            "FROM   dbo.AFA_DEPARTMENT " &
            "WHERE  IS_ACTIVE = 1 " &
            "ORDER  BY DEPT_NAME ASC"

        Dim dt As DataTable = ExecuteQuery(sql, NoParam)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then _cacheDepartment = dt
        Return dt
    End Function
    Public Function GetDepartmentsByNik(ByVal nik As String) As DataTable
        Dim sql As String =
            "SELECT d.DEPT_ID, d.DEPT_NAME, d.PREFIX, " &
            "       d.DEPT_NAME + ' (' + d.PREFIX + ')' AS DISPLAY_NAME " &
            "FROM   dbo.AFA_DEPARTMENT d " &
            "JOIN   dbo.AFA_DEPARTMENT_USER u ON u.DEPT_ID = d.DEPT_ID " &
            "WHERE  d.IS_ACTIVE = 1 AND u.NIK = ? " &
            "ORDER  BY d.DEPT_NAME"

        Dim prm As New List(Of Object) From {nik}
        Return ExecuteQuery(sql, prm)
    End Function
    Public Function GetDepartmentPrefix(ByVal deptId As Integer) As String
        Dim sql As String = "SELECT PREFIX FROM dbo.AFA_DEPARTMENT WHERE DEPT_ID = ?"
        Dim prm As New List(Of Object) From {deptId}
        Dim dt As DataTable = ExecuteQuery(sql, prm)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return String.Empty
        Return Convert.ToString(dt.Rows(0)("PREFIX"))
    End Function

#End Region

#Region "AFA Type & Sub Type"
    Public Function GetAfaTypes(Optional ByVal useCache As Boolean = True) As DataTable
        If useCache AndAlso _cacheAfaType IsNot Nothing Then Return _cacheAfaType

        Dim sql As String =
            "SELECT CODE, NAME " &
            "FROM   dbo.AFA_TYPE " &
            "WHERE  IS_ACTIVE = 1 " &
            "ORDER  BY CODE"

        Dim dt As DataTable = ExecuteQuery(sql, NoParam)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then _cacheAfaType = dt
        Return dt
    End Function
    Public Function GetSubTypes(ByVal afaType As String,
                                Optional ByVal useCache As Boolean = True) As DataTable
        Dim key As String = If(afaType, String.Empty).ToUpperInvariant()

        If useCache AndAlso _cacheSubType.ContainsKey(key) Then Return _cacheSubType(key)

        Dim prm As New Dictionary(Of String, Object) From {{"@AfaType", afaType}}
        Dim dt As DataTable = ExecuteStoredProcedureQuery("AFA_NonIFS_GetSubType_Proc", prm)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then _cacheSubType(key) = dt
        Return dt
    End Function

#End Region

#Region "Budget Year & Currency"
    Public Function GetBudgetYears(Optional ByVal useCache As Boolean = True) As DataTable
        If useCache AndAlso _cacheBudgetYear IsNot Nothing Then Return _cacheBudgetYear

        Dim sql As String =
            "SELECT DISTINCT B_YEAR AS BUDGET_YEAR " &
            "FROM   dbo.BUDGET_CURR_RATE " &
            "WHERE  ISNULL(B_YEAR,'') <> '' " &
            "ORDER  BY B_YEAR DESC"

        Dim dt As DataTable = ExecuteQuery(sql, NoParam)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then _cacheBudgetYear = dt
        Return dt
    End Function

    Public Function GetBudgetRevisions(ByVal budgetYear As String) As DataTable
        Dim sql As String =
            "SELECT DISTINCT B_REV AS BUDGET_REV " &
            "FROM   dbo.BUDGET_CURR_RATE " &
            "WHERE  B_YEAR = ? AND ISNULL(B_REV,'') <> '' " &
            "ORDER  BY TRY_CAST(B_REV AS int) DESC"

        Dim prm As New List(Of Object) From {budgetYear}
        Return ExecuteQuery(sql, prm)
    End Function

    Public Function GetCurrencies(Optional ByVal useCache As Boolean = True) As DataTable
        If useCache AndAlso _cacheCurrency IsNot Nothing Then Return _cacheCurrency

        Dim sql As String =
            "SELECT DISTINCT CURCODE " &
            "FROM   dbo.BUDGET_CURR_RATE " &
            "WHERE  ISNULL(CURCODE,'') <> '' " &
            "ORDER  BY CURCODE"

        Dim dt As DataTable = ExecuteQuery(sql, NoParam)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then _cacheCurrency = dt
        Return dt
    End Function
    Public Function GetJpyFactor(ByVal budgetYear As String,
                                 ByVal budgetRev As String,
                                 ByVal curCode As String) As Decimal?
        If String.Equals(curCode, "JPY", StringComparison.OrdinalIgnoreCase) Then Return 1D

        Dim sql As String =
            "SELECT TOP 1 CUR_RATE " &
            "FROM   dbo.BUDGET_CURR_RATE " &
            "WHERE  B_YEAR = ? AND CURCODE = ? " &
            "  AND  (? IS NULL OR B_REV = ?) " &
            "ORDER  BY TRY_CAST(B_REV AS int) DESC"

        Dim prmCur As New List(Of Object) From {budgetYear, curCode, budgetRev, budgetRev}
        Dim dtCur As DataTable = ExecuteQuery(sql, prmCur)
        If dtCur Is Nothing OrElse dtCur.Rows.Count = 0 Then Return Nothing
        If IsDBNull(dtCur.Rows(0)("CUR_RATE")) Then Return Nothing

        Dim prmJpy As New List(Of Object) From {budgetYear, "JPY", budgetRev, budgetRev}
        Dim dtJpy As DataTable = ExecuteQuery(sql, prmJpy)
        If dtJpy Is Nothing OrElse dtJpy.Rows.Count = 0 Then Return Nothing
        If IsDBNull(dtJpy.Rows(0)("CUR_RATE")) Then Return Nothing

        Dim rateCur As Decimal = Convert.ToDecimal(dtCur.Rows(0)("CUR_RATE"))
        Dim rateJpy As Decimal = Convert.ToDecimal(dtJpy.Rows(0)("CUR_RATE"))
        If rateJpy = 0D Then Return Nothing

        Return rateCur / rateJpy
    End Function

#End Region

#Region "Priority"

    Public Function GetPriorities() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("PRIORITY", GetType(Byte))
        dt.Columns.Add("NAME", GetType(String))

        dt.Rows.Add(CByte(0), "No Label")
        dt.Rows.Add(CByte(1), "Important")
        dt.Rows.Add(CByte(2), "Urgent")
        dt.Rows.Add(CByte(3), "Top Priority")

        Return dt
    End Function

#End Region

#Region "Employee (GTAS)"

    Public Function SearchEmployee(ByVal keyword As String) As DataTable
        Dim prm As New Dictionary(Of String, Object) From {{"@Keyword", keyword}}
        Return ExecuteStoredProcedureQuery("AFA_NonIFS_SearchEmployee_Proc", prm)
    End Function

    Public Function GetEmployeeName(ByVal nik As String) As String
        Dim sql As String =
            "SELECT TOP 1 RTRIM(Nama) FROM dbo.AFA_Employee_GTAS WHERE RTRIM(NIK) = ? " &
            "UNION ALL " &
            "SELECT TOP 1 RTRIM(Name) FROM dbo.User_H WHERE UserID = ?"

        Dim prm As New List(Of Object) From {nik, nik}
        Dim dt As DataTable = ExecuteQuery(sql, prm)

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return String.Empty
        Return Convert.ToString(dt.Rows(0)(0))
    End Function

#End Region

#Region "Signature Type"

    Public Function GetSignatureTypes() As DataTable
        Dim sql As String =
            "SELECT Jenis, urut FROM dbo.AFA_Jenis_Urut ORDER BY urut"

        Return ExecuteQuery(sql, NoParam)
    End Function

#End Region

End Class