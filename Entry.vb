Imports System.Data.SqlClient

Public Class Entry

    Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\_Programs\_Visual_Studio_Workspace\Game\Players.mdf;Integrated Security=True"

    Dim Player1Name As String
    Dim Player2Name As String
    Dim Player3Name As String
    Dim Player4Name As String

    Private Sub Entry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadScoreBoard()
        AutoCompletePlayerNames()
    End Sub

    Public Sub LoadScoreBoard()
        Dim PlayersTable As String = "SELECT * FROM PlayersInfo"
        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()

                ' Create a SqlDataAdapter to fetch data
                Dim adapter1 As New SqlDataAdapter(PlayersTable, conn)

                ' Create a DataTable to hold the fetched data
                Dim dt1 As New DataTable()

                ' Fill the DataTable with data
                adapter1.Fill(dt1)

                ' Bind the DataTable to the DataGridView
                DataGridView1.DataSource = dt1

            Catch ex As SqlException
                MessageBox.Show("An error occurred while connecting to the database: " & ex.Message)
            End Try
        End Using
    End Sub

    Public Function GetNamesFromDatabase(connectionString As String) As List(Of String)
        Dim names As New List(Of String)()
        Dim query As String = "SELECT Name FROM PlayersInfo"

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

        Return names
    End Function

    Public Sub SetupAutoCompleteTextBox(textBox As TextBox, names As List(Of String))
        Dim autoComplete As New AutoCompleteStringCollection()
        autoComplete.AddRange(names.ToArray())

        textBox.AutoCompleteCustomSource = autoComplete
        textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        textBox.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Public Sub AutoCompletePlayerNames()
        Dim names As List(Of String) = GetNamesFromDatabase(connectionString)
        SetupAutoCompleteTextBox(Player1_TextBox, names)
        SetupAutoCompleteTextBox(Player2_TextBox, names)
        SetupAutoCompleteTextBox(Player3_TextBox, names)
        SetupAutoCompleteTextBox(Player4_TextBox, names)
    End Sub

    Public Sub ClearScoreBoard()
        Dim clearPlayersTable As String = "DELETE FROM PlayersInfo"
        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()

                ' Execute the DELETE command
                Using cmd As New SqlCommand(clearPlayersTable, conn)
                    cmd.ExecuteNonQuery()
                End Using

                ' Clear the DataGridView
                DataGridView1.DataSource = Nothing
                DataGridView1.Rows.Clear()

            Catch ex As SqlException
                MessageBox.Show("An error occurred while clearing the scoreboard: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles TwoPlayers.CheckedChanged
        Player3.Hide()
        Player3_TextBox.Hide()
        Player4.Hide()
        Player4_TextBox.Hide()
    End Sub

    Private Sub ThreePlayers_CheckedChanged(sender As Object, e As EventArgs) Handles ThreePlayers.CheckedChanged
        Player3.Show()
        Player3_TextBox.Show()
        Player4.Hide()
        Player4_TextBox.Hide()
    End Sub

    Private Sub FourPlayers_CheckedChanged(sender As Object, e As EventArgs) Handles FourPlayers.CheckedChanged
        Player3.Show()
        Player3_TextBox.Show()
        Player4.Show()
        Player4_TextBox.Show()
    End Sub

    Private Function IsDuplicate(name As String, conn As SqlConnection) As Boolean
        Dim checkDuplicate As String = "SELECT COUNT(*) FROM PlayersInfo WHERE Name = @Name"
        Using cmd As New SqlCommand(checkDuplicate, conn)
            cmd.Parameters.AddWithValue("@Name", name)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return count > 0
        End Using
    End Function

    Private Sub InsertPlayer(name As String, conn As SqlConnection)
        Dim addPlayer As String = "INSERT INTO PlayersInfo (Name) VALUES (@Name)"
        Using cmd As New SqlCommand(addPlayer, conn)
            cmd.Parameters.AddWithValue("@Name", name)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub ClearTextBoxes()
        Player1_TextBox.Clear()
        Player2_TextBox.Clear()
        Player3_TextBox.Clear()
        Player4_TextBox.Clear()
    End Sub

    Private Sub EnterTheGame_Click(sender As Object, e As EventArgs) Handles EnterTheGame.Click

        Player1Name = Player1_TextBox.Text
        Player2Name = Player2_TextBox.Text

        Using conn As New SqlConnection(connectionString)
            Try
                conn.Open()

                ' Validate player names
                If TwoPlayers.Checked Then
                    If String.IsNullOrWhiteSpace(Player1Name) Or String.IsNullOrWhiteSpace(Player2Name) Then
                        MessageBox.Show("Atleast two players are requried to play the game.")
                        Return
                    End If
                    If Player1Name = Player2Name Then
                        MessageBox.Show("Duplicate player names are not allowed.")
                        ClearTextBoxes()
                        Return
                    End If

                    If IsDuplicate(Player1Name, conn) Then

                    Else
                        InsertPlayer(Player1Name, conn)
                    End If
                    If IsDuplicate(Player2Name, conn) Then

                    Else
                        InsertPlayer(Player2Name, conn)
                    End If
                    TheGame.noofplayers = 2

                ElseIf ThreePlayers.Checked Then
                    Player3Name = Player3_TextBox.Text
                    If String.IsNullOrWhiteSpace(Player1Name) Or String.IsNullOrWhiteSpace(Player2Name) Or String.IsNullOrWhiteSpace(Player3Name) Then
                        MessageBox.Show("All players' names are required.")
                        Return
                    End If
                    If Player1Name = Player2Name Or Player1Name = Player3Name Or Player2Name = Player3Name Then
                        MessageBox.Show("Duplicate player names are not allowed.")
                        ClearTextBoxes()
                        Return
                    End If

                    If IsDuplicate(Player1Name, conn) Then

                    Else
                        InsertPlayer(Player1Name, conn)
                    End If
                    If IsDuplicate(Player2Name, conn) Then

                    Else
                        InsertPlayer(Player2Name, conn)
                    End If
                    If IsDuplicate(Player3Name, conn) Then

                    Else
                        InsertPlayer(Player3Name, conn)
                    End If
                    TheGame.noofplayers = 3

                ElseIf FourPlayers.Checked Then

                    Player3Name = Player3_TextBox.Text
                    Player4Name = Player4_TextBox.Text

                    If String.IsNullOrWhiteSpace(Player1Name) Or String.IsNullOrWhiteSpace(Player2Name) Or String.IsNullOrWhiteSpace(Player3Name) Or String.IsNullOrWhiteSpace(Player4Name) Then
                        MessageBox.Show("All players' names are required.")
                        Return
                    End If
                    If Player1Name = Player2Name Or Player1Name = Player3Name Or Player1Name = Player4Name Or Player2Name = Player3Name Or Player2Name = Player4Name Or Player3Name = Player4Name Then
                        MessageBox.Show("Duplicate player names are not allowed.")
                        ClearTextBoxes()
                        Return
                    End If

                    If IsDuplicate(Player1Name, conn) Then

                    Else
                        InsertPlayer(Player1Name, conn)
                    End If
                    If IsDuplicate(Player2Name, conn) Then

                    Else
                        InsertPlayer(Player2Name, conn)
                    End If
                    If IsDuplicate(Player3Name, conn) Then

                    Else
                        InsertPlayer(Player3Name, conn)
                    End If
                    If IsDuplicate(Player4Name, conn) Then

                    Else
                        InsertPlayer(Player4Name, conn)
                    End If
                    TheGame.noofplayers = 4

                End If

                TheGame.PName.Add(Player1Name)
                TheGame.PName.Add(Player2Name)
                TheGame.PName.Add(Player3Name)
                TheGame.PName.Add(Player4Name)

            Catch ex As SqlException
                MessageBox.Show("An error occurred while adding data to the database: " & ex.Message)
            End Try
        End Using

        ' Load scoreboard and clear text boxes
        LoadScoreBoard()
        AutoCompletePlayerNames()
        ClearTextBoxes()
        TheGame.Show()
    End Sub

    Private Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        If MessageBox.Show("Are you sure you want to clear the scoreboard?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ClearScoreBoard()
            LoadScoreBoard()
            AutoCompletePlayerNames()
        End If
    End Sub

    Private Sub Test_Click(sender As Object, e As EventArgs) Handles Test.Click
        TheGame.noofplayers = 4
        TheGame.PName.Add("p1")
        TheGame.PName.Add("p2")
        TheGame.PName.Add("p3")
        TheGame.PName.Add("p4")
        TheGame.Show()
    End Sub
End Class
