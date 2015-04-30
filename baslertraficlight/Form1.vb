Imports System
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Form1

    Dim oCmd As SqlClient.SqlCommand
    Dim oDR As SqlClient.SqlDataReader

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        '        SELECT [SheetCode] ,[Judgement] ,[CreatedAt] ,[Type] FROM [SNet].[dbo].[SheetJudgementResult]
        '        WHERE [SheetCode] = (SELECT TOP 1 [SheetCode] FROM [SheetJudgementResult] ORDER BY [CreatedAt] DESC)


        '        Try
        ' oCmd = New SqlClient.SqlCommand()
        ' With oCmd
        ' .Connection = New SqlClient.SqlConnection(sConnectionString)
        ' .Connection.Open()
        ' .CommandText = sSelectQuery
        ' oDR = .ExecuteReader()
        ' End With

        '        lstProducts.Items.Clear()
        '        Do While oDR.Read()
        ' lstProducts.Items.Add(oDR.Item("RUN"))
        ' Loop
        '
        '        oDR.Close()
        '        oCmd.Connection.Close()
        '
        '        Catch oExcept As Exception
        ' MessageBox.Show(oExcept.Message)
        '
        '        End Try


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Try
            oDR = oCmd.ExecuteReader()
            Do While oDR.Read()
                'oDR.Item("RUN"))
            Loop
        Catch oExcept As Exception
            MessageBox.Show(oExcept.Message)
            Debug.Print(oExcept.Message)
        End Try

    End Sub

    Private Sub Form1_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        oDR.Close()
        oCmd.Connection.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sConnectionString As String ' = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RECIPE;Data Source=PROGRAMMING-PC;"
        Dim sSelectQuery = "SELECT [SheetCode] ,[Judgement] ,[CreatedAt] ,[Type] FROM [SNet].[dbo].[SheetJudgementResult] WHERE [SheetCode] = (SELECT TOP 1 [SheetCode] FROM [SheetJudgementResult] ORDER BY [CreatedAt] DESC)"
        Timer1.Enabled = False

        'sConnectionString = System.Configuration.ConfigurationManager.AppSettings("")

        'sConnectionString = System.Configuration.ConfigurationSettings.AppSettings("ConnectionString")
        'sConnectionString = ConfigurationSettings.ConnectionStrings("WingtipToys").ConnectionString

        'sConnectionString = ConfigurationSettings.AppSettings("connectionString").ConnectionString
        sConnectionString = ConfigurationSettings.GetConfig("connectionString").ConnectionString

        'ReadSetting(sConnectionString)

        Try
            oCmd = New SqlClient.SqlCommand()
            With oCmd
                .Connection = New SqlClient.SqlConnection(sConnectionString)
                .Connection.Open()
                .CommandText = sSelectQuery
            End With
            Timer1.Interval = 15000
            Timer1.Enabled = True

        Catch oExcept As Exception
            Debug.Print(oExcept.Message)
            MessageBox.Show(oExcept.Message)
            'End

        End Try




    End Sub

    Private Sub bSave_Click(sender As Object, e As EventArgs) Handles bSave.Click
        MessageBox.Show("SAVE")
    End Sub


    Sub AddUpdateAppSettings(key As String, value As String)

        'Try
        '    Dim configFile = ConfigurationSettings.OpenExeConfiguration() '(ConfigurationUserLevel.None)
        '    Dim settings = configFile.AppSettings.Settings
        '    If IsNothing(settings(key)) Then
        '        settings.Add(key, value)
        '    Else
        '        settings(key).Value = value
        '    End If
        '    configFile.Save(ConfigurationSaveMode.Modified)
        '    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name)
        'Catch e As ConfigurationErrorsException
        '    Console.WriteLine("Error writing app settings")
        'End Try

    End Sub

End Class
