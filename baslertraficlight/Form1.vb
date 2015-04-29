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
            'MessageBox.Show(oExcept.Message)
            Debug.Print(oExcept.Message)
        End Try

    End Sub

    Private Sub Form1_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        oDR.Close()
        oCmd.Connection.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RECIPE;Data Source=PROGRAMMING-PC;"
        Dim sSelectQuery = "SELECT [SheetCode] ,[Judgement] ,[CreatedAt] ,[Type] FROM [SNet].[dbo].[SheetJudgementResult] WHERE [SheetCode] = (SELECT TOP 1 [SheetCode] FROM [SheetJudgementResult] ORDER BY [CreatedAt] DESC)"
        Timer1.Enabled = False

        Try
            oCmd = New SqlClient.SqlCommand()
            With oCmd
                .Connection = New SqlClient.SqlConnection(sConnectionString)
                .Connection.Open()
                .CommandText = sSelectQuery
            End With

        Catch oExcept As Exception
            MessageBox.Show(oExcept.Message)
            End

        End Try

        Timer1.Interval = 15
        Timer1.Enabled = True



    End Sub

    Private Sub bSave_Click(sender As Object, e As EventArgs) Handles bSave.Click

    End Sub

    Sub ReadSetting(key As String)
        Try
            Dim appSettings = ConfigurationManager.AppSettings
            Dim result As String = appSettings(key)
            If IsNothing(result) Then
                result = "Not found"
            End If
            Console.WriteLine(result)
        Catch e As ConfigurationErrorsException
            Console.WriteLine("Error reading app settings")
        End Try
    End Sub
End Class
