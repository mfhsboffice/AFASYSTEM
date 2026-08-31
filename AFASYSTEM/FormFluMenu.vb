
'to encryp
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports DevExpress.XtraPrinting.Preview
Public Class FormFluMenu
    Dim SQL As String
    Dim Proses As New ClassKoneksi
    Dim tblDept, tblOTControl, tblSect, tblOTControl2 As DataTable
    Dim tblEmployee As DataTable
    Dim tblLog As DataTable
    Dim CM As CurrencyManager
    'to encryp
    Private enc As System.Text.UTF8Encoding
    Private encryptor As ICryptoTransform
    Private decryptor As ICryptoTransform
    Dim connStringP, connStringS, connStringDB As String
    Dim connStringhasilencryp As String
    Private Sub Sys_User_Click(sender As Object, e As EventArgs) Handles Sys_User.Click
        XtraFromUser.TopLevel = False
        XtraFromUser.Parent = PanelControl1
        XtraFromUser.Dock = DockStyle.Fill
        XtraFromUser.Show()
        XtraFromUser.BringToFront()

    End Sub
    Sub mnhistory()
        XtraFormAFAHistory.TopLevel = False
        XtraFormAFAHistory.Parent = PanelControl1
        XtraFormAFAHistory.Dock = DockStyle.Fill
        XtraFormAFAHistory.Show()
        XtraFormAFAHistory.BringToFront()
    End Sub


    Private Sub BarButtonItemExit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemExit.ItemClick
        Me.Close()
    End Sub

    Private Sub FormFluMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim KEY_128 As Byte() = {42, 1, 52, 67, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}
        Dim IV_128 As Byte() = {234, 12, 52, 44, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}
        Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC

        Me.enc = New System.Text.UTF8Encoding
        Me.encryptor = symmetricKey.CreateEncryptor(KEY_128, IV_128)
        Me.decryptor = symmetricKey.CreateDecryptor(KEY_128, IV_128)

        'callenc()
        'getConnStringSer()
        'getConnStringDB()
        getConnStringpLocal()


        menustart()
        isilink()
        XtraFormLogin.ShowDialog()


    End Sub
    Sub getConnStringpLocal()
        TxtSer.Caption = "SRD00PC26031\MSSQLSERVER123"
        TxtDB.Caption = "AFASYS"
        TxtP.Caption = "Surindo@2026"
    End Sub
    Sub getConnStringpASS()
        Try
            Dim readFile As IO.TextReader = New StreamReader(Application.StartupPath & "\configP.zip")
            connStringP = readFile.ReadToEnd()
            readFile.Close()
            readFile = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' connStringhasilencryp = Decrypt(connString)
    End Sub
    Sub getConnStringSer()
        Try
            Dim readFile As IO.TextReader = New StreamReader(Application.StartupPath & "\configS.zip")
            connStringS = readFile.ReadToEnd()
            readFile.Close()
            readFile = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' connStringhasilencryp = Decrypt(connString)
        TxtSer.Caption = connStringS
    End Sub
    Sub getConnStringDB()
        Try
            Dim readFile As IO.TextReader = New StreamReader(Application.StartupPath & "\configDB.zip")
            connStringDB = readFile.ReadToEnd()
            readFile.Close()
            readFile = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ' connStringhasilencryp = Decrypt(connString)
        TxtDB.Caption = connStringDB
    End Sub
    Sub callenc()
        getConnStringpASS()
        Dim cypherTextBytes As Byte() = Convert.FromBase64String(connStringP)
        Dim memoryStream As MemoryStream = New MemoryStream(cypherTextBytes)
        Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, Me.decryptor, CryptoStreamMode.Read)
        Dim plainTextBytes(cypherTextBytes.Length) As Byte
        Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
        memoryStream.Close()
        cryptoStream.Close()
        TxtP.Caption = Me.enc.GetString(plainTextBytes, 0, decryptedByteCount)

    End Sub
    Sub isilink()
        tblDept = Proses.ExecuteQuery("SELECT [Sett]  FROM [AFASYS].[dbo].[AFA_CONFIG] where [Type]='Server'")
        If tblDept.Rows.Count > 0 Then
            btnlink.Caption = Trim(tblDept.Rows(0).Item(0).ToString)

        End If


    End Sub
    Sub menustart()
        Sys.Visible = False
        Trans.Visible = False
        Report.Visible = False
        Others.Visible = False
        Others_AppOwner.Visible = False
        Btnlogon.Enabled = True
        BtnLogoff.Enabled = False
        Tools_Admin.Visible = False
        AOViewAFA.Visible = False

    End Sub

    Sub menuaktif()
        If Trim(btnlvl.Caption) = "ADMIN" Then
            Sys.Visible = True
            Trans.Visible = True
            Sys_User.Visible = True
            Sys_AddUser.Visible = True


            Report.Visible = True
            Others.Visible = True
            Trans_Monitoring.Visible = True

            Others_Skip.Visible = True
            Others_AppOwner.Visible = True
            Tools_Admin.Visible = True

        ElseIf Trim(btnlvl.Caption) = "APP" Then

            Sys.Visible = True
            Sys_User.Visible = False
            Sys_AddUser.Visible = False



            Trans.Visible = True
            Trans_AFAEntry.Visible = False
            Trans_App.Visible = True
            Trans_Monitoring.Visible = True


            Report.Visible = True
            Others.Visible = True
            Others_Skip.Visible = False
            Other_Guidance.Visible = True

            Others_AppOwner.Visible = False


            If Trim(btnuserid.Caption) = "02945" Then
                Tools_Admin.Visible = True
            Else
                Tools_Admin.Visible = False
            End If



        ElseIf Trim(btnlvl.Caption) = "ENTRY" Then

            Sys.Visible = True
            Sys_User.Visible = False
            Sys_AddUser.Visible = True


            Trans.Visible = True
            Trans_AFAEntry.Visible = True
            Trans_App.Visible = False
            Trans_Monitoring.Visible = True

            Report.Visible = True

            Others.Visible = True
            Others_Skip.Visible = False
            Other_Guidance.Visible = True
            Others_AppOwner.Visible = False
            Tools_Admin.Visible = False
        ElseIf Trim(btnlvl.Caption) = "FINANCE" Then

            Sys.Visible = True
            Sys_User.Visible = False
            Sys_AddUser.Visible = False


            Trans.Visible = True
            Trans_AFAEntry.Visible = False
            Trans_App.Visible = False
            Trans_Monitoring.Visible = True

            Report.Visible = True

            Others.Visible = True
            Others_Skip.Visible = False
            Other_Guidance.Visible = True
            Others_AppOwner.Visible = False
            Tools_Admin.Visible = False
        ElseIf Trim(btnlvl.Caption) = "BUDGET" Then

            Sys.Visible = True
            Sys_User.Visible = False
            Trans.Visible = True
            Trans_Monitoring.Visible = True
            Sys_AddUser.Visible = True

            Report.Visible = True
            Others.Visible = True
            Others_Skip.Visible = False
            Other_Guidance.Visible = True
            Others_AppOwner.Visible = False
            Tools_Admin.Visible = False
        ElseIf Trim(btnlvl.Caption) = "BUDGET ADMIN" Then

            Sys.Visible = True
            Sys_User.Visible = True
            Sys_AddUser.Visible = True


            Trans.Visible = True
            Trans_App.Visible = True
            Trans_AFAEntry.Visible = True
            Trans_Monitoring.Visible = True


            Report.Visible = True
            Others.Visible = True
            Others_Skip.Visible = True
            Other_Guidance.Visible = True
            Others_AppOwner.Visible = True
            Tools_Admin.Visible = False

        End If


        Btnlogon.Enabled = False
        BtnLogoff.Enabled = True
        cekmenuAO()
    End Sub
    Sub cekmenuAO()
        Dim nik = Trim(btnuserid.Caption)

        tblDept = Proses.ExecuteQuery("SELECT *  FROM [AFASYS].[dbo].[User_H]  where userid='" & nik & "' and AO='Y'")
        If tblDept.Rows.Count = 0 Then
            AOViewAFA.Visible = False
        Else
            AOViewAFA.Visible = True

        End If



    End Sub
    Private Sub Btnlogon_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Btnlogon.ItemClick
        XtraFormLogin.ShowDialog()
    End Sub

    Private Sub BtnLogoff_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnLogoff.ItemClick
        tuutpkabeh()
        menustart()
        XtraFormLogin.ShowDialog()
    End Sub
    Sub tuutpkabeh()
        For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
            If My.Application.OpenForms.Item(i) IsNot Me Then
                My.Application.OpenForms.Item(i).Close()

            End If
        Next i
    End Sub
    Sub closeall()
        Try
            XtraFormAddInf.Close()
            XtraFormAddUser.Close()
            XtraFormAFAEntry.Close()
            XtraFormApproval.Close()
            XtraFormChangPwd.Close()
            XtraFormMonitoring.Close()
            XtraFormRptHistoryAFA.Close()
            XtraFormSendNoteBudget.Close()
            XtraFormSignature.Close()
            XtraFormSkipAfa.Close()
            XtraFormViewAfa.Close()
            XtraFromUser.Close()
            XtraFormAppOwner.Close()
            XtraFormDownloadNote.Close()

        Catch ex As Exception
            MsgBox("Please Install PDf Reader")
        End Try



    End Sub
    Sub menuaddinf()
        XtraFormAddInf.TopLevel = False
        XtraFormAddInf.Parent = PanelControl1
        XtraFormAddInf.Show()
        XtraFormAddInf.BringToFront()
    End Sub
    Private Sub Trans_App_Click(sender As Object, e As EventArgs) Handles Trans_App.Click
        XtraFormApproval.TopLevel = False
        XtraFormApproval.Parent = PanelControl1
        ' XtraFormApproval.Dock = DockStyle.Fill
        XtraFormApproval.Show()
        XtraFormApproval.BringToFront()


    End Sub

    Private Sub Trans_Monitoring_Click(sender As Object, e As EventArgs) Handles Trans_Monitoring.Click
        XtraFormMonitoring.TopLevel = False
        XtraFormMonitoring.Parent = PanelControl1
        XtraFormMonitoring.Dock = DockStyle.Fill
        XtraFormMonitoring.Show()
        XtraFormMonitoring.BringToFront()

    End Sub

    Private Sub Sys_Changepwd_Click(sender As Object, e As EventArgs) Handles Sys_Changepwd.Click

        XtraFormChangPwd.ShowDialog()

    End Sub
    Sub closede()
        For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
            If My.Application.OpenForms.Item(i) IsNot Me Then
                My.Application.OpenForms.Item(i).Close()

            End If
        Next i
        XtraFormLogin.Close()
    End Sub

    Private Sub Others_Skip_Click(sender As Object, e As EventArgs) Handles Others_Skip.Click
        XtraFormSkipAfa.TopLevel = False
        XtraFormSkipAfa.Parent = PanelControl1
        XtraFormSkipAfa.Dock = DockStyle.Fill
        XtraFormSkipAfa.Show()
        XtraFormSkipAfa.BringToFront()
    End Sub

    Private Sub Rpt_HistoryAFA_Click(sender As Object, e As EventArgs) Handles Rpt_HistoryAFA.Click
        XtraFormRptHistoryAFA.TopLevel = False
        XtraFormRptHistoryAFA.Parent = PanelControl1
        XtraFormRptHistoryAFA.Dock = DockStyle.Fill
        XtraFormRptHistoryAFA.Show()
        XtraFormRptHistoryAFA.BringToFront()
    End Sub



    Private Sub others_Guiance_SettingSignature_Click(sender As Object, e As EventArgs) Handles others_Guiance_Drafter.Click
        Try
            System.Diagnostics.Process.Start(Application.StartupPath & "\Rpt\Drafter_AFA.pdf")
        Catch ex As Exception
            MsgBox("File do not exists")
        End Try
    End Sub

    Private Sub others_Guiance_Approval_Click(sender As Object, e As EventArgs) Handles others_Guiance_Approval.Click
        Try
            System.Diagnostics.Process.Start(Application.StartupPath & "\Rpt\Approval_AFA.pdf")
        Catch ex As Exception
            MsgBox("File do not exists")
        End Try
    End Sub

    Private Sub Sys_AddUser_Click(sender As Object, e As EventArgs) Handles Sys_AddUser.Click
        XtraFormAddUser.TopLevel = False
        XtraFormAddUser.Parent = PanelControl1
        XtraFormAddUser.Dock = DockStyle.Fill
        XtraFormAddUser.Show()
        XtraFormAddUser.BringToFront()
    End Sub

    Private Sub Sys_Configure_Click(sender As Object, e As EventArgs) Handles Sys_Configure.Click
        XtraFormEmailConfigure.TopLevel = False
        XtraFormEmailConfigure.Parent = PanelControl1
        XtraFormEmailConfigure.Dock = DockStyle.None
        XtraFormEmailConfigure.Show()
        XtraFormEmailConfigure.BringToFront()
    End Sub

    Private Sub Other_regulation_Click(sender As Object, e As EventArgs) Handles Other_regulation.Click

        'XtraFormPdf.TopLevel = False
        'XtraFormPdf.Parent = PanelControl1
        'XtraFormPdf.Dock = DockStyle.None
        'XtraFormPdf.Show()
        'XtraFormPdf.BringToFront()


        XtraFormvViewDocQA.TopLevel = False
        XtraFormvViewDocQA.Parent = PanelControl1
        XtraFormvViewDocQA.Dock = DockStyle.None
        XtraFormvViewDocQA.open()
        XtraFormvViewDocQA.Show()
        XtraFormvViewDocQA.BringToFront()
    End Sub



    Private Sub Others_AppOwner_Click(sender As Object, e As EventArgs) Handles Others_AppOwner.Click
        XtraFormAppOwner.TopLevel = False
        XtraFormAppOwner.Parent = PanelControl1
        XtraFormAppOwner.Dock = DockStyle.None
        XtraFormAppOwner.Show()
        XtraFormAppOwner.BringToFront()
    End Sub

    Private Sub Tools_Admin_Click(sender As Object, e As EventArgs) Handles Tools_Admin.Click
        XtraFormDownloadNote.TopLevel = False
        XtraFormDownloadNote.Parent = PanelControl1
        XtraFormDownloadNote.Dock = DockStyle.None
        XtraFormDownloadNote.Show()
        XtraFormDownloadNote.BringToFront()
    End Sub

    Private Sub AOViewAFA_Click(sender As Object, e As EventArgs) Handles AOViewAFA.Click
        XtraFormListAFAAO.TopLevel = False
        XtraFormListAFAAO.Parent = PanelControl1
        XtraFormListAFAAO.Dock = DockStyle.None
        XtraFormListAFAAO.Show()
        XtraFormListAFAAO.BringToFront()
    End Sub

    Private Sub AceDepartmentCode_Click(sender As Object, e As EventArgs) Handles AceDepartmentCode.Click
        XtraFormDepartment.TopLevel = False
        XtraFormDepartment.Parent = PanelControl1
        XtraFormDepartment.Dock = DockStyle.Fill
        XtraFormDepartment.Show()
        XtraFormDepartment.BringToFront()
    End Sub

    Private Sub AceUserDepartment_Click(sender As Object, e As EventArgs) Handles AceUserDepartment.Click
        XtraFormUserDepartments.TopLevel = False
        XtraFormUserDepartments.Parent = PanelControl1
        XtraFormUserDepartments.Dock = DockStyle.Fill
        XtraFormUserDepartments.Show()
        XtraFormUserDepartments.BringToFront()
    End Sub

    Private Sub AFAEformDonInf_Click(sender As Object, e As EventArgs) Handles AFAEformDonInf.Click
        XtraFormAFAInfEF.TopLevel = False
        XtraFormAFAInfEF.Parent = PanelControl1
        XtraFormAFAInfEF.Dock = DockStyle.Fill
        XtraFormAFAInfEF.Show()
        XtraFormAFAInfEF.BringToFront()
    End Sub

    Private Sub AFASignatureDonInf_Click(sender As Object, e As EventArgs) Handles AFASignatureDonInf.Click
        XtraFormAFAInfSign.TopLevel = False
        XtraFormAFAInfSign.Parent = PanelControl1
        XtraFormAFAInfSign.Dock = DockStyle.Fill
        XtraFormAFAInfSign.Show()
        XtraFormAFAInfSign.BringToFront()
    End Sub

    Private Sub AFAEformDisposal_Click(sender As Object, e As EventArgs) Handles AFAEformDisposal.Click
        XtraFormAFADaaEForm.TopLevel = False
        XtraFormAFADaaEForm.Parent = PanelControl1
        XtraFormAFADaaEForm.Dock = DockStyle.Fill
        XtraFormAFADaaEForm.Show()
        XtraFormAFADaaEForm.BringToFront()
    End Sub

    Private Sub AFASignatureDisposal_Click(sender As Object, e As EventArgs) Handles AFASignatureDisposal.Click
        XtraFormAFADaaSign.TopLevel = False
        XtraFormAFADaaSign.Parent = PanelControl1
        XtraFormAFADaaSign.Dock = DockStyle.Fill
        XtraFormAFADaaSign.Show()
        XtraFormAFADaaSign.BringToFront()
    End Sub

    Private Sub AFAEformReclassBudget_Click(sender As Object, e As EventArgs) Handles AFAEformReclassBudget.Click
        XtraFormAFABreEForm.TopLevel = False
        XtraFormAFABreEForm.Parent = PanelControl1
        XtraFormAFABreEForm.Dock = DockStyle.Fill
        XtraFormAFABreEForm.Show()
        XtraFormAFABreEForm.BringToFront()
    End Sub

    Private Sub AFASignatureReclassBudget_Click(sender As Object, e As EventArgs) Handles AFASignatureReclassBudget.Click
        XtraFormAFABreSign.TopLevel = False
        XtraFormAFABreSign.Parent = PanelControl1
        XtraFormAFABreSign.Dock = DockStyle.Fill
        XtraFormAFABreSign.Show()
        XtraFormAFABreSign.BringToFront()
    End Sub

    Private Sub AFAEformAddBudget_Click(sender As Object, e As EventArgs) Handles AFAEformAddBudget.Click
        XtraFormAFAAddEForm.TopLevel = False
        XtraFormAFAAddEForm.Parent = PanelControl1
        XtraFormAFAAddEForm.Dock = DockStyle.Fill
        XtraFormAFAAddEForm.Show()
        XtraFormAFAAddEForm.BringToFront()
    End Sub

    Private Sub AFASignatureAddBudget_Click(sender As Object, e As EventArgs) Handles AFASignatureAddBudget.Click
        XtraFormAFAAddSign.TopLevel = False
        XtraFormAFAAddSign.Parent = PanelControl1
        XtraFormAFAAddSign.Dock = DockStyle.Fill
        XtraFormAFAAddSign.Show()
        XtraFormAFAAddSign.BringToFront()
    End Sub

    Private Sub btnexit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnexit.ItemClick
        tuutpkabeh()
        Me.Close()
        deleexcel()
    End Sub
    Sub deleexcel()
        Try

            Dim path As String = "" & Application.StartupPath & "\Temp\"
            DeleteDirectory(path)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DeleteDirectory(path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
            ''Delete all child Directories
            'For Each dir As String In Directory.GetDirectories(path)
            '    DeleteDirectory(dir)
            'Next
            ''Delete a Directory
            'Directory.Delete(path)
        End If
    End Sub
    Private Sub Afa_Download_Click(sender As Object, e As EventArgs) Handles Afa_Download.Click
        XtraFormAFAEntry.TopLevel = False
        XtraFormAFAEntry.Parent = PanelControl1
        XtraFormAFAEntry.Dock = DockStyle.Fill
        XtraFormAFAEntry.Show()
        XtraFormAFAEntry.BringToFront()


    End Sub

    Private Sub Afa_Sett_Signature_Click(sender As Object, e As EventArgs) Handles Afa_Sett_Signature.Click
        'XtraFormSignature.TopLevel = False
        'XtraFormSignature.Parent = PanelControl1
        'XtraFormSignature.Dock = DockStyle.Fill
        'XtraFormSignature.Show()
        'XtraFormSignature.BringToFront()

        XtraFormSignatureNew.TopLevel = False
        XtraFormSignatureNew.Parent = PanelControl1
        XtraFormSignatureNew.Dock = DockStyle.Fill
        XtraFormSignatureNew.Show()
        XtraFormSignatureNew.BringToFront()
    End Sub
End Class
