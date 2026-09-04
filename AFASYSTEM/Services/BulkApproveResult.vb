Imports System.Text

Public Class BulkApproveResult
    Public Property TotalAttempted As Integer
    Public Property TotalSucceeded As Integer
    Public Property Failures As New List(Of BulkApproveFailure)

    Public ReadOnly Property TotalFailed As Integer
        Get
            Return Failures.Count
        End Get
    End Property

    Public Function BuildSummary() As String
        Dim sb As New StringBuilder()

        sb.Append(TotalSucceeded).Append(" of ").Append(TotalAttempted).Append(" approved.")

        If TotalFailed > 0 Then
            sb.AppendLine()
            sb.AppendLine()
            sb.Append(TotalFailed).Append(If(TotalFailed = 1, " document could not be approved:", " documents could not be approved:"))

            For Each f As BulkApproveFailure In Failures
                sb.AppendLine()
                sb.Append("  ").Append(f.AfaNo).Append(" - ").Append(f.Reason)
            Next
        End If

        Return sb.ToString()
    End Function
End Class

Public Class BulkApproveFailure
    Public Property AfaNo As String
    Public Property Reason As String

    Public Sub New(ByVal afaNo As String, ByVal reason As String)
        Me.AfaNo = afaNo
        Me.Reason = reason
    End Sub
End Class