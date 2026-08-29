
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Drawing

Public Class FormSc
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2, tblgrid As DataTable

    Public Sub New()
        InitializeComponent()
    End Sub
    Public Class CustomAppointment
        Private m_Start As DateTime
        Private m_End As DateTime
        Private m_Subject As String
        Private m_Status As Integer
        Private m_Description As String
        Private m_Label As Integer
        Private m_Location As String
        Private m_Allday As Boolean
        Private m_EventType As Integer
        Private m_RecurrenceInfo As String
        Private m_ReminderInfo As String
        Private m_OwnerId As Object


        Public Property StartTime() As DateTime
            Get
                Return m_Start
            End Get
            Set(ByVal value As DateTime)
                m_Start = value
            End Set
        End Property
        Public Property EndTime() As DateTime
            Get
                Return m_End
            End Get
            Set(ByVal value As DateTime)
                m_End = value
            End Set
        End Property
        Public Property Subject() As String
            Get
                Return m_Subject
            End Get
            Set(ByVal value As String)
                m_Subject = value
            End Set
        End Property
        Public Property Status() As Integer
            Get
                Return m_Status
            End Get
            Set(ByVal value As Integer)
                m_Status = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set(ByVal value As String)
                m_Description = value
            End Set
        End Property
        Public Property Label() As Integer
            Get
                Return m_Label
            End Get
            Set(ByVal value As Integer)
                m_Label = value
            End Set
        End Property
        Public Property Location() As String
            Get
                Return m_Location
            End Get
            Set(ByVal value As String)
                m_Location = value
            End Set
        End Property
        Public Property AllDay() As Boolean
            Get
                Return m_Allday
            End Get
            Set(ByVal value As Boolean)
                m_Allday = value
            End Set
        End Property
        Public Property EventType() As Integer
            Get
                Return m_EventType
            End Get
            Set(ByVal value As Integer)
                m_EventType = value
            End Set
        End Property
        Public Property RecurrenceInfo() As String
            Get
                Return m_RecurrenceInfo
            End Get
            Set(ByVal value As String)
                m_RecurrenceInfo = value
            End Set
        End Property
        Public Property ReminderInfo() As String
            Get
                Return m_ReminderInfo
            End Get
            Set(ByVal value As String)
                m_ReminderInfo = value
            End Set
        End Property
        Public Property OwnerId() As Object
            Get
                Return m_OwnerId
            End Get
            Set(ByVal value As Object)
                m_OwnerId = value
            End Set
        End Property

        Public Sub New()
        End Sub
    End Class


#Region "#customresource"
    Public Class CustomResource
        Private m_name As String
        Private m_res_id As Integer

        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                m_name = value
            End Set
        End Property
        Public Property ResID() As Integer
            Get
                Return m_res_id
            End Get
            Set(ByVal value As Integer)
                m_res_id = value
            End Set
        End Property

        Public Sub New()
        End Sub
    End Class
#End Region ' #customresource

    Public Shared RandomInstance As New Random()

    Private CustomResourceCollection As New List(Of CustomResource)()
    Private CustomEventList As New List(Of CustomAppointment)()


    Private Sub InitResources()
        Dim mappings As ResourceMappingInfo = Me.SchedulerDataStorage1.Resources.Mappings

        mappings.Id = "ResID"
        mappings.Caption = "Name"

        tblDept = Proses.ExecuteQuery("SELECT [NAMA]      ,[DATEAPP]       FROM [AFASYS].[dbo].[AFA_SIGNATURE]  a  where a.[AFA_NO]='HRD/C/001/1/22/22' and [DATEAPP] is not null")

        For i As Integer = 0 To tblDept.Rows.Count - 1
            Dim nama = Trim(tblDept.Rows(i).Item("NAMA").ToString)
            CustomResourceCollection.Add(CreateCustomResource(i, nama, Color.PowderBlue))
            '  CustomResourceCollection.Add(CreateCustomResource(i, "Nancy Drewmore", Color.PaleVioletRed))
            ' CustomResourceCollection.Add(CreateCustomResource(i, "Pak Jang", Color.PeachPuff))
        Next




        SchedulerDataStorage1.Resources.DataSource = CustomResourceCollection
    End Sub

    Private Sub FormSc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitResources()
        InitAppointments()
        SchedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource

        SchedulerControl1.ActiveViewType = SchedulerViewType.Timeline
        SchedulerControl1.TimelineView.Scales.Clear()
        SchedulerControl1.TimelineView.Scales.Add(New DevExpress.XtraScheduler.TimeScaleMonth())
        SchedulerControl1.TimelineView.Scales.Add(New DevExpress.XtraScheduler.TimeScaleYear())
        SchedulerControl1.TimelineView.Scales.Add(New DevExpress.XtraScheduler.TimeScaleMonth() With {.Enabled = False})

        '  SchedulerControl1.Start = DateTime.Now

    End Sub

    Private Function CreateCustomResource(ByVal res_id As Integer, ByVal caption As String, ByVal ResColor As Color) As CustomResource
        Dim cr As New CustomResource()
        cr.ResID = res_id
        cr.Name = caption
        Return cr
    End Function



    Private Sub InitAppointments()
        Dim mappings As AppointmentMappingInfo = Me.SchedulerDataStorage1.Appointments.Mappings
        mappings.Start = "StartTime"
        mappings.End = "EndTime"
        mappings.Subject = "Subject"
        mappings.AllDay = "AllDay"
        mappings.Description = "Description"
        mappings.Label = "Label"
        mappings.Location = "Location"
        mappings.RecurrenceInfo = "RecurrenceInfo"
        mappings.ReminderInfo = "ReminderInfo"
        mappings.ResourceId = "OwnerId"
        mappings.Status = "Status"
        mappings.Type = "EventType"



        GenerateEvents(CustomEventList)
        Me.SchedulerDataStorage1.Appointments.DataSource = CustomEventList
    End Sub


    Private Sub GenerateEvents(ByVal eventList As List(Of CustomAppointment))


        'Dim count As Integer = SchedulerDataStorage1.Resources.Count
        tblDept = Proses.ExecuteQuery("SELECT [NAMA]      ,[DATEAPP]       FROM [AFASYS].[dbo].[AFA_SIGNATURE]  a  where a.[AFA_NO]='HRD/C/001/1/22/22' and [DATEAPP] is not null")

        For i As Integer = 0 To tblDept.Rows.Count - 1
            Dim tgl = tblDept.Rows(i).Item("DATEAPP")
            Dim nama = tblDept.Rows(i).Item("NAMA")

            Dim resource As Resource = SchedulerDataStorage1.Resources(i)
            Dim subjPrefix As String = resource.Caption & nama

            eventList.Add(CreateEvent(subjPrefix & nama, resource.Id, i, i, i))


        Next


    End Sub

    Private Function CreateEvent(ByVal subject As String, ByVal resourceId As Object, ByVal status As Integer, ByVal label As Integer, ByVal sHour As Integer) As CustomAppointment
        Dim apt As New CustomAppointment()


        tblDept = Proses.ExecuteQuery("SELECT [NAMA]      ,[DATEAPP] ,ID      FROM [AFASYS].[dbo].[AFA_SIGNATURE]  a  where a.[AFA_NO]='HRD/C/001/1/22/22' and [DATEAPP] is not null")
        Dim r = 0
        For i As Integer = 0 To tblDept.Rows.Count - 1

            Dim tgl = tblDept.Rows(i).Item("DATEAPP")
            Dim nama = tblDept.Rows(i).Item("ID")

            If resourceId <> r Then
                apt.Subject = subject
                apt.OwnerId = resourceId
                Dim rnd As Random = RandomInstance
                Dim rangeInMinutes As Integer = 60 * 24


                ' apt.StartTime = New DateTime(2022, 2, 1, 1, 2, 3)
                apt.StartTime = tgl
                apt.EndTime = apt.StartTime.AddHours(1)


                Dim interval As New TimeInterval(New Date(2018, 12, 24), TimeSpan.FromDays(1))
                Dim target As Appointment = SchedulerControl1.DataStorage.GetAppointments(interval).Find(Function(x) x.Subject.Contains("ID"))

            End If


            r = resourceId
        Next


        apt.Status = status
        apt.Label = label



        Return apt

    End Function


End Class