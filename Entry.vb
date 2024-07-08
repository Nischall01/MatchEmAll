Imports System.Data.SqlClient
Imports System.IO

Public Class Entry

    ' Dim IconPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Icons", "Entry.ico")

    Dim DefaultBackgroundImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Others", "Entry_BackgroundImage.png")

    Private ReadOnly connectionString As String = DatabaseHelper.GetConnectionString()

    Private Sub Entry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.IsBackgroundAnImage_Entry = True Then
            If My.Settings.IsEntryBackgroundDefault = True Then
                SetBackgroundImage("Default")
            Else
                SetBackgroundImage("Selected")
            End If
        Else
            SetBackgroundColor()
        End If
        LoadScoreBoard()
        AutoCompletePlayerNames()
        Enable_DevMode() ' Enable test mode for development purposes
    End Sub

    Private Sub Enable_DevMode()
        Test.Enabled = True
        Test.Show()
    End Sub

    ' For Changeable/dynamic app icon

    'Private Sub SetIcon()
    '    If File.Exists(IconPath) Then
    '        Me.Icon = New Icon(IconPath)
    '    Else
    '        Me.Icon = Nothing
    '    End If
    'End Sub

    ' For Changeable/dynamic background
    Public Sub SetBackgroundImage(Type As String)
        Select Case Type
            Case "Default"
                If File.Exists(DefaultBackgroundImagePath) Then
                    Me.BackgroundImage = Image.FromFile(DefaultBackgroundImagePath)
                    Me.BackColor = SystemColors.Control
                Else
                    MsgBox($"DefaultBackgroundImage Is Missing:{DefaultBackgroundImagePath}")
                    Me.BackgroundImage = Nothing
                    Me.BackColor = Color.DarkGreen
                End If

            Case "Selected"
                If File.Exists(My.Settings.Entry_BackgroundImage) Then
                    Me.BackgroundImage = Image.FromFile(My.Settings.Entry_BackgroundImage)
                    Me.BackColor = SystemColors.Control
                Else
                    MsgBox($"BackgroundImage is Missing:{My.Settings.Entry_BackgroundImage}")
                    Me.BackgroundImage = Nothing
                    Me.BackColor = Color.DarkGreen
                End If
            Case Else
                MsgBox($"Invalid background type: {Type}. Please use 'Default' or 'Selected'.")
        End Select
    End Sub

    Public Sub SetBackgroundColor()
        Me.BackgroundImage = Nothing
        Me.BackColor = My.Settings.Entry_BackgroundColor
    End Sub

    Private Sub Test_Click(sender As Object, e As EventArgs) Handles Test.Click
        Select Case True
            Case TwoPlayers.Checked
                Player1_TextBox.Text = "p1"
                Player2_TextBox.Text = "p2"
            Case ThreePlayers.Checked
                Player1_TextBox.Text = "p1"
                Player2_TextBox.Text = "p2"
                Player3_TextBox.Text = "p3"
            Case FourPlayers.Checked
                Player1_TextBox.Text = "p1"
                Player2_TextBox.Text = "p2"
                Player3_TextBox.Text = "p3"
                Player4_TextBox.Text = "p4"
        End Select
        EnterTheGame.PerformClick()
    End Sub

    Private Sub EnterTheGame_Click(sender As Object, e As EventArgs) Handles EnterTheGame.Click
        Dim playerNames As New List(Of String)

        If String.IsNullOrEmpty(Player1_TextBox.Text) OrElse String.IsNullOrEmpty(Player2_TextBox.Text) Then
            MessageBox.Show("At least two players are required to play the game.")
            Return
        End If

        playerNames.Add(Player1_TextBox.Text)
        playerNames.Add(Player2_TextBox.Text)

        If ThreePlayers.Checked Then
            If String.IsNullOrEmpty(Player3_TextBox.Text) Then
                MessageBox.Show("All players' names are required.")
                Return
            End If
            playerNames.Add(Player3_TextBox.Text)
        ElseIf FourPlayers.Checked Then
            If String.IsNullOrEmpty(Player3_TextBox.Text) OrElse String.IsNullOrEmpty(Player4_TextBox.Text) Then
                MessageBox.Show("All players' names are required.")
                Return
            End If
            playerNames.Add(Player3_TextBox.Text)
            playerNames.Add(Player4_TextBox.Text)
        End If

        If playerNames.Distinct().Count() <> playerNames.Count() Then
            MessageBox.Show("Duplicate player names are not allowed.")
            ClearTextBoxes()
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                For Each playerName As String In playerNames
                    If Not IsDuplicate(playerName, conn) Then
                        InsertPlayer(playerName, conn)
                    End If
                Next

                TheGame.noofplayers = playerNames.Count
                TheGame.PName.AddRange(playerNames)
            End Using
        Catch ex As SqlException
            MessageBox.Show("An error occurred while adding data to the database: " & ex.Message)
        End Try

        LoadScoreBoard()
        AutoCompletePlayerNames()
        ClearTextBoxes()
        Clear.Enabled = False
        Clear.Hide()

        Me.Hide()
        TheGame.Show()
    End Sub

    Private Sub LoadScoreBoard()
        Dim query As String = "SELECT * FROM PlayersInfo"
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Using adapter As New SqlDataAdapter(query, conn)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    DataGridView1.DataSource = dt
                End Using
            End Using
        Catch ex As SqlException
            MessageBox.Show("An error occurred while connecting to the database: " & ex.Message)
        End Try
    End Sub

    Private Function GetNamesFromDatabase() As List(Of String)
        Dim names As New List(Of String)()
        Dim query As String = "SELECT Name FROM PlayersInfo"
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            names.Add(reader("Name").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As SqlException
            MessageBox.Show("An error occurred while fetching player names: " & ex.Message)
        End Try
        Return names
    End Function

    Private Sub SetupAutoCompleteTextBox(textBox As TextBox, names As List(Of String))
        Dim autoComplete As New AutoCompleteStringCollection()
        autoComplete.AddRange(names.ToArray())

        textBox.AutoCompleteCustomSource = autoComplete
        textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        textBox.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub AutoCompletePlayerNames()
        Dim names As List(Of String) = GetNamesFromDatabase()
        SetupAutoCompleteTextBox(Player1_TextBox, names)
        SetupAutoCompleteTextBox(Player2_TextBox, names)
        SetupAutoCompleteTextBox(Player3_TextBox, names)
        SetupAutoCompleteTextBox(Player4_TextBox, names)
    End Sub

    Private Sub ClearScoreBoard()
        Dim query As String = "DELETE FROM PlayersInfo"
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    cmd.ExecuteNonQuery()
                End Using
                DataGridView1.DataSource = Nothing
            End Using
        Catch ex As SqlException
            MessageBox.Show("An error occurred while clearing the scoreboard: " & ex.Message)
        End Try
    End Sub

    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        If MessageBox.Show("Are you sure you want to clear the scoreboard?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ClearScoreBoard()
            LoadScoreBoard()
            AutoCompletePlayerNames()
        End If
    End Sub

    Private Function IsDuplicate(name As String, conn As SqlConnection) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM PlayersInfo WHERE Name = @Name"
        Try
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Name", name)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        Catch ex As SqlException
            MessageBox.Show("An error occurred while checking for duplicate player names: " & ex.Message)
            Return True ' Assume duplicate to prevent unintended data modification
        End Try
    End Function

    Private Sub InsertPlayer(name As String, conn As SqlConnection)
        Dim query As String = "INSERT INTO PlayersInfo (Name, Score) VALUES (@Name, 0)"
        Try
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Name", name)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As SqlException
            MessageBox.Show("An error occurred while adding player to the database: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearTextBoxes()
        Player1_TextBox.Clear()
        Player2_TextBox.Clear()
        Player3_TextBox.Clear()
        Player4_TextBox.Clear()
    End Sub

    Private Sub SelectPlayerNumber_CheckedChanged(sender As Object, e As EventArgs) Handles TwoPlayers.CheckedChanged, ThreePlayers.CheckedChanged, FourPlayers.CheckedChanged
        If TwoPlayers.Checked Then
            Player3.Hide()
            Player3_TextBox.Hide()
            Player4.Hide()
            Player4_TextBox.Hide()
        ElseIf ThreePlayers.Checked Then
            Player3.Show()
            Player3_TextBox.Show()
            Player4.Hide()
            Player4_TextBox.Hide()
        Else
            Player3.Show()
            Player3_TextBox.Show()
            Player4.Show()
            Player4_TextBox.Show()
        End If

    End Sub

    Public Sub UpdateScore(Winner As String)
        Dim updateScore As String = "UPDATE PlayersInfo SET Score = Score + @ScoreToAdd WHERE Name = @Winner"

        Using conn As New SqlConnection(connectionString)
            Using Command As New SqlCommand(updateScore, conn)

                Command.Parameters.AddWithValue("@ScoreToAdd", 10)
                Command.Parameters.AddWithValue("@Winner", Winner)

                conn.Open()
                Dim rowsAffected As Integer = Command.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    ' MessageBox.Show("Score updated successfully.")
                Else
                    MessageBox.Show("Player not found.")
                End If

            End Using
        End Using
        LoadScoreBoard()
    End Sub

    Private Sub Settings_Click(sender As Object, e As EventArgs) Handles Settings.Click
        AppSettings.Show()
    End Sub
End Class

Public Class DatabaseHelper
    Public Shared Function GetConnectionString() As String
        Dim databaseFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "PlayersData", "Players.mdf")
        Return $"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={databaseFilePath};Integrated Security=True;Connect Timeout=25"
    End Function
End Class
