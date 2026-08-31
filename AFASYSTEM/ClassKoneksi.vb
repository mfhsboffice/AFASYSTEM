Imports Microsoft.VisualBasic
Imports System.Data.Sql
Imports System.IO
Public Class ClassKoneksi
    Protected tblEmployeUser = New DataTable
    Protected SQL As String
    Protected Cn As OleDb.OleDbConnection
    Protected Cmd As OleDb.OleDbCommand
    Protected Da As OleDb.OleDbDataAdapter
    Protected Ds As DataSet
    Public LastErrorMessage As String = ""
    Protected Dt As DataTable
    Dim connString As String
    Dim connStringhasilencryp As String
    Dim P, S, DB As String

    Public Function OpenConn() As Boolean
        P = Trim(FormFluMenu.TxtP.Caption)
        DB = Trim(FormFluMenu.TxtDB.Caption)
        S = Trim(FormFluMenu.TxtSer.Caption)
        Cn = New OleDb.OleDbConnection("Provider=SQLOLEDB;Data Source=" & S & ";Persist Security Info=True;Password=" & P & ";User ID=sa;Initial Catalog=" & DB & ";")

        'Cn = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DbPenjualan.mdb")
        Cn.Open()
        If Cn.State <> ConnectionState.Open Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub CloseConn()
        If Not IsNothing(Cn) Then
            Cn.Close()
            Cn = Nothing
        End If
    End Sub
    Public Function ExecuteQuery(ByVal Query As String) As DataTable
        If Not OpenConn() Then
            MsgBox("Connection failed..!!", MsgBoxStyle.Critical, "Access Failed")
            Return Nothing
            Exit Function
        End If

        Cmd = New OleDb.OleDbCommand(Query, Cn)
        Cmd.CommandTimeout = 10000 ' number of seconds
        Da = New OleDb.OleDbDataAdapter
        Da.SelectCommand = Cmd

        Ds = New Data.DataSet
        Da.Fill(Ds)

        Dt = Ds.Tables(0)
        Return Dt
        Dt = Nothing
        Ds = Nothing
        Da = Nothing
        Cmd = Nothing
        CloseConn()


    End Function

    Public Function ExecuteQuery(ByVal Query As String, ByVal Parameters As List(Of Object)) As DataTable
        Dim dt As New DataTable()
        LastErrorMessage = ""
        If Not OpenConn() Then
            LastErrorMessage = "Connection failed."
            Return dt
        End If

        Try
            Cmd = New OleDb.OleDbCommand(Query, Cn)
            Cmd.CommandTimeout = 10000
            Cmd.CommandType = CommandType.Text

            For Each value In Parameters
                If value Is Nothing Then
                    Cmd.Parameters.AddWithValue("?", DBNull.Value)
                Else
                    Cmd.Parameters.AddWithValue("?", value)
                End If
            Next

            Dim adapter As New OleDb.OleDbDataAdapter(Cmd)
            adapter.Fill(dt)
            Return dt
        Catch ex As Exception
            LastErrorMessage = ex.Message
            Return dt
        Finally
            Cmd = Nothing
            CloseConn()
        End Try
    End Function


    Public Sub ExecuteNonQuery(ByVal Query As String)
        If Not OpenConn() Then
            MsgBox("Koneksi Gagal..!!", MsgBoxStyle.Critical, "Access Failed..!!")
            Exit Sub
        End If

        Cmd = New OleDb.OleDbCommand
        Cmd.Connection = Cn
        Cmd.CommandTimeout = 10000 ' number of seconds
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Query

        Cmd.ExecuteNonQuery()
        Cmd = Nothing
        CloseConn()
    End Sub


    Public Function ExecuteStoredProcedure(ByVal ProcName As String, ByVal Parameters As Dictionary(Of String, Object)) As Boolean
        LastErrorMessage = ""
        If Not OpenConn() Then
            LastErrorMessage = "Connection failed."
            Return False
        End If
        Try
            Cmd = New OleDb.OleDbCommand()
            Cmd.Connection = Cn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = ProcName
            Cmd.CommandTimeout = 1000
            For Each Param In Parameters
                If Param.Value Is Nothing Then
                    Cmd.Parameters.AddWithValue(Param.Key, DBNull.Value)
                Else
                    Cmd.Parameters.AddWithValue(Param.Key, Param.Value)
                End If
            Next
            Cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            LastErrorMessage = ex.Message
            Return False
        Finally
            Cmd = Nothing
            CloseConn()
        End Try
    End Function

    Public Function ExecuteStoredProcedureQuery(ByVal ProcName As String, ByVal Parameters As Dictionary(Of String, Object)) As DataTable
        Dim dt As New DataTable()
        LastErrorMessage = ""
        If Not OpenConn() Then
            LastErrorMessage = "Connection failed."
            Return dt
        End If
        Try
            Cmd = New OleDb.OleDbCommand()
            Cmd.Connection = Cn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = ProcName
            Cmd.CommandTimeout = 1000

            For Each Param In Parameters
                If Param.Value Is Nothing Then
                    Cmd.Parameters.AddWithValue(Param.Key, DBNull.Value)
                Else
                    Cmd.Parameters.AddWithValue(Param.Key, Param.Value)
                End If
            Next
            Dim adapter As New OleDb.OleDbDataAdapter(Cmd)
            adapter.Fill(dt)
            Return dt
        Catch ex As Exception
            LastErrorMessage = ex.Message
            Return dt
        Finally
            Cmd = Nothing
            CloseConn()
        End Try
    End Function

    Public Function ExecuteStoredProcedureQueryWithStatus(
        ByVal ProcName As String,
        ByVal Parameters As Dictionary(Of String, Object),
        ByRef Status As String,
        ByRef Message As String
    ) As DataTable

        Dim dt As New DataTable()
        Status = ""
        Message = ""
        LastErrorMessage = ""

        If Not OpenConn() Then
            LastErrorMessage = "Connection failed."
            Status = "FAILED"
            Return dt
        End If

        Try
            Cmd = New OleDb.OleDbCommand()
            Cmd.Connection = Cn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = ProcName
            Cmd.CommandTimeout = 1000

            For Each Param In Parameters
                If Param.Value Is Nothing Then
                    Cmd.Parameters.AddWithValue(Param.Key, DBNull.Value)
                Else
                    Cmd.Parameters.AddWithValue(Param.Key, Param.Value)
                End If
            Next

            Dim statusParam As New OleDb.OleDbParameter("@Status", OleDb.OleDbType.VarChar, 10)
            statusParam.Direction = ParameterDirection.Output
            Cmd.Parameters.Add(statusParam)

            Dim messageParam As New OleDb.OleDbParameter("@Message", OleDb.OleDbType.VarChar, 255)
            messageParam.Direction = ParameterDirection.Output
            Cmd.Parameters.Add(messageParam)

            Dim adapter As New OleDb.OleDbDataAdapter(Cmd)
            adapter.Fill(dt)

            Status = If(statusParam.Value IsNot Nothing, statusParam.Value.ToString(), "")
            Message = If(messageParam.Value IsNot Nothing, messageParam.Value.ToString(), "")

            Return dt
        Catch ex As OleDb.OleDbException
            Dim errorMessages As New List(Of String)
            For Each err As OleDb.OleDbError In ex.Errors
                errorMessages.Add(err.Message)
            Next
            LastErrorMessage = String.Join(" | ", errorMessages)
            Status = "FAILED"
            Return dt
        Catch ex As Exception
            LastErrorMessage = ex.Message
            Status = "FAILED"
            Return dt
        Finally
            Cmd = Nothing
            CloseConn()
        End Try
    End Function

    Public Function ExecuteStoredProcedureMessageFirst(
        ByVal ProcName As String,
        ByVal Parameters As List(Of Object),
        ByRef Message As String
    ) As Boolean

        Message = ""
        LastErrorMessage = ""

        If Not OpenConn() Then
            LastErrorMessage = "Connection failed."
            Message = LastErrorMessage
            Return False
        End If

        Try
            Cmd = New OleDb.OleDbCommand()
            Cmd.Connection = Cn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = ProcName
            Cmd.CommandTimeout = 1000

            Dim messageParam As New OleDb.OleDbParameter("@Message", OleDb.OleDbType.VarChar, 255)
            messageParam.Direction = ParameterDirection.Output
            Cmd.Parameters.Add(messageParam)

            If Parameters IsNot Nothing Then
                For Each value In Parameters
                    If value Is Nothing Then
                        Cmd.Parameters.AddWithValue("?", DBNull.Value)
                    Else
                        Cmd.Parameters.AddWithValue("?", value)
                    End If
                Next
            End If

            Cmd.ExecuteNonQuery()

            Message = If(messageParam.Value IsNot Nothing AndAlso Not IsDBNull(messageParam.Value),
                         messageParam.Value.ToString().Trim(), "")
            LastErrorMessage = Message

            Return String.Equals(Message, "OK", StringComparison.OrdinalIgnoreCase)

        Catch ex As OleDb.OleDbException
            Dim errorMessages As New List(Of String)
            For Each err As OleDb.OleDbError In ex.Errors
                errorMessages.Add(err.Message)
            Next
            LastErrorMessage = String.Join(" | ", errorMessages)
            Message = LastErrorMessage
            Return False
        Catch ex As Exception
            LastErrorMessage = ex.Message
            Message = LastErrorMessage
            Return False
        Finally
            Cmd = Nothing
            CloseConn()
        End Try
    End Function

    Public Function ExecuteStoredProcedureWithStatus(ByVal ProcName As String, ByVal Parameters As Dictionary(Of String, Object)) As Boolean

        Dim status As String = ""
        LastErrorMessage = ""

        If Not OpenConn() Then
            LastErrorMessage = "Connection failed."
            Return False
        End If

        Try
            Cmd = New OleDb.OleDbCommand()
            Cmd.Connection = Cn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = ProcName
            Cmd.CommandTimeout = 1000

            For Each Param In Parameters
                If Param.Value Is Nothing Then
                    Cmd.Parameters.AddWithValue(Param.Key, DBNull.Value)
                Else
                    Cmd.Parameters.AddWithValue(Param.Key, Param.Value)
                End If
            Next

            Dim statusParam As New OleDb.OleDbParameter("@Status", OleDb.OleDbType.VarChar, 10)
            statusParam.Direction = ParameterDirection.Output
            Cmd.Parameters.Add(statusParam)

            Dim messageParam As New OleDb.OleDbParameter("@Message", OleDb.OleDbType.VarChar, 255)
            messageParam.Direction = ParameterDirection.Output
            Cmd.Parameters.Add(messageParam)

            Cmd.ExecuteNonQuery()

            status = If(statusParam.Value IsNot Nothing, statusParam.Value.ToString(), "")
            LastErrorMessage = If(messageParam.Value IsNot Nothing, messageParam.Value.ToString(), "")

            Return status = "SUCCESS"

        Catch ex As OleDb.OleDbException
            Dim errorMessages As New List(Of String)
            For Each err As OleDb.OleDbError In ex.Errors
                errorMessages.Add(err.Message)
            Next
            LastErrorMessage = String.Join(" | ", errorMessages)
            Return False
        Catch ex As Exception
            LastErrorMessage = ex.Message
            Return False
        Finally
            Cmd = Nothing
            CloseConn()
        End Try
    End Function
    Public Function ExecuteStoredProcedureCreateWithStatus(
        ByVal ProcName As String,
        ByVal Parameters As Dictionary(Of String, Object),
        ByRef Status As String,
        ByRef Message As String,
        ByRef NewId As Decimal?
    ) As Boolean

        Status = ""
        Message = ""
        NewId = Nothing
        LastErrorMessage = ""

        If Not OpenConn() Then
            LastErrorMessage = "Connection failed."
            Status = "FAILED"
            Return False
        End If

        Try
            Cmd = New OleDb.OleDbCommand()
            Cmd.Connection = Cn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = ProcName
            Cmd.CommandTimeout = 1000

            For Each Param In Parameters
                If Param.Value Is Nothing Then
                    Cmd.Parameters.AddWithValue(Param.Key, DBNull.Value)
                Else
                    Cmd.Parameters.AddWithValue(Param.Key, Param.Value)
                End If
            Next

            Dim statusParam As New OleDb.OleDbParameter("@Status", OleDb.OleDbType.VarChar, 10)
            statusParam.Direction = ParameterDirection.Output
            Cmd.Parameters.Add(statusParam)

            Dim messageParam As New OleDb.OleDbParameter("@Message", OleDb.OleDbType.VarChar, 255)
            messageParam.Direction = ParameterDirection.Output
            Cmd.Parameters.Add(messageParam)

            Dim newIdParam As New OleDb.OleDbParameter("@NewUserID", OleDb.OleDbType.Numeric)
            newIdParam.Direction = ParameterDirection.Output
            newIdParam.Precision = 18
            newIdParam.Scale = 0
            Cmd.Parameters.Add(newIdParam)

            Cmd.ExecuteNonQuery()

            Status = If(statusParam.Value IsNot Nothing, statusParam.Value.ToString(), "")
            Message = If(messageParam.Value IsNot Nothing, messageParam.Value.ToString(), "")
            NewId = If(newIdParam.Value IsNot Nothing AndAlso Not IsDBNull(newIdParam.Value), Convert.ToDecimal(newIdParam.Value), CType(Nothing, Decimal?))

            Return Status = "SUCCESS"

        Catch ex As OleDb.OleDbException
            Dim errorMessages As New List(Of String)
            For Each err As OleDb.OleDbError In ex.Errors
                errorMessages.Add(err.Message)
            Next
            LastErrorMessage = String.Join(" | ", errorMessages)
            Status = "FAILED"
            Return False
        Catch ex As Exception
            LastErrorMessage = ex.Message
            Status = "FAILED"
            Return False
        Finally
            Cmd = Nothing
            CloseConn()
        End Try
    End Function
    Public Function ExecuteStoredProcedureCreateWithStatus(
        ByVal ProcName As String,
        ByVal Parameters As Dictionary(Of String, Object),
        ByVal OutputIdParamName As String,
        ByRef Status As String,
        ByRef Message As String,
        ByRef NewId As Decimal?
    ) As Boolean

        Status = ""
        Message = ""
        NewId = Nothing
        LastErrorMessage = ""

        If Not OpenConn() Then
            LastErrorMessage = "Connection failed."
            Status = "FAILED"
            Return False
        End If

        Try
            Cmd = New OleDb.OleDbCommand()
            Cmd.Connection = Cn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = ProcName
            Cmd.CommandTimeout = 1000

            For Each Param In Parameters
                If Param.Value Is Nothing Then
                    Cmd.Parameters.AddWithValue(Param.Key, DBNull.Value)
                Else
                    Cmd.Parameters.AddWithValue(Param.Key, Param.Value)
                End If
            Next

            Dim statusParam As New OleDb.OleDbParameter("@Status", OleDb.OleDbType.VarChar, 10)
            statusParam.Direction = ParameterDirection.Output
            Cmd.Parameters.Add(statusParam)

            Dim messageParam As New OleDb.OleDbParameter("@Message", OleDb.OleDbType.VarChar, 255)
            messageParam.Direction = ParameterDirection.Output
            Cmd.Parameters.Add(messageParam)

            Dim newIdParam As New OleDb.OleDbParameter(OutputIdParamName, OleDb.OleDbType.Numeric)
            newIdParam.Direction = ParameterDirection.Output
            newIdParam.Precision = 18
            newIdParam.Scale = 0
            Cmd.Parameters.Add(newIdParam)

            Cmd.ExecuteNonQuery()

            Status = If(statusParam.Value IsNot Nothing, statusParam.Value.ToString(), "")
            Message = If(messageParam.Value IsNot Nothing, messageParam.Value.ToString(), "")
            NewId = If(newIdParam.Value IsNot Nothing AndAlso Not IsDBNull(newIdParam.Value), Convert.ToDecimal(newIdParam.Value), CType(Nothing, Decimal?))

            Return Status = "SUCCESS"

        Catch ex As OleDb.OleDbException
            Dim errorMessages As New List(Of String)
            For Each err As OleDb.OleDbError In ex.Errors
                errorMessages.Add(err.Message)
            Next
            LastErrorMessage = String.Join(" | ", errorMessages)
            Status = "FAILED"
            Return False
        Catch ex As Exception
            LastErrorMessage = ex.Message
            Status = "FAILED"
            Return False
        Finally
            Cmd = Nothing
            CloseConn()
        End Try
    End Function
    Public Function ExecuteStoredProcedureWithStatusOrdered(ByVal ProcName As String, ByVal Parameters As List(Of KeyValuePair(Of String, Object))) As Boolean
        Dim status As String = ""
        LastErrorMessage = ""

        If Not OpenConn() Then
            LastErrorMessage = "Connection failed."
            Return False
        End If

        Try
            Cmd = New OleDb.OleDbCommand()
            Cmd.Connection = Cn
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = ProcName
            Cmd.CommandTimeout = 1000

            For Each Param In Parameters
                If Param.Value Is Nothing Then
                    Cmd.Parameters.AddWithValue(Param.Key, DBNull.Value)
                Else
                    Cmd.Parameters.AddWithValue(Param.Key, Param.Value)
                End If
            Next

            Dim statusParam As New OleDb.OleDbParameter("@Status", OleDb.OleDbType.VarChar, 10)
            statusParam.Direction = ParameterDirection.Output
            Cmd.Parameters.Add(statusParam)

            Dim messageParam As New OleDb.OleDbParameter("@Message", OleDb.OleDbType.VarChar, 255)
            messageParam.Direction = ParameterDirection.Output
            Cmd.Parameters.Add(messageParam)

            Cmd.ExecuteNonQuery()

            status = If(statusParam.Value IsNot Nothing, statusParam.Value.ToString(), "")
            LastErrorMessage = If(messageParam.Value IsNot Nothing, messageParam.Value.ToString(), "")

            Return status = "SUCCESS"

        Catch ex As OleDb.OleDbException
            Dim errorMessages As New List(Of String)
            For Each err As OleDb.OleDbError In ex.Errors
                errorMessages.Add(err.Message)
            Next
            LastErrorMessage = String.Join(" | ", errorMessages)
            Return False
        Catch ex As Exception
            LastErrorMessage = ex.Message
            Return False
        Finally
            Cmd = Nothing
            CloseConn()
        End Try
    End Function
End Class
