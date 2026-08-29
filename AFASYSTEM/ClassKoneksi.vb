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



End Class
