Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox
Imports Newtonsoft.Json

Public Class TheGame

    Public noofplayers As Integer

    Public PName As New List(Of String)

    Private nomatches As Integer

    Private Sub TheGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initialize_Game()
    End Sub

    Private Sub Initialize_Game()
        Try
            ClearJsonFile("draw_deck.json")
            ClearJsonFile("unmatched_cards.json")

            ' initialize the deck
            Dim deck As List(Of String) = Initializedeck()

            ' shuffle the deck
            deck = Shuffledeck(deck)

            ' distribute cards to players (5 cards each)
            Dim cardsperplayer As Integer = 5
            Dim players As List(Of List(Of String)) = Distributecards(deck, noofplayers, cardsperplayer)

            ' Save each player's hand to a JSON file
            SavePlayerHands(players)

            Dim playerhands As New List(Of String)()
            For Each player In players
                playerhands.AddRange(player)
            Next

            Dim remainingdeck As List(Of String) = deck.Except(playerhands).ToList()

            Writeremainingcardstojsonfile(remainingdeck, "draw_deck.json")

            LoadPlayers(noofplayers)

            MsgBox("Game simulation completed. Check JSON files for results.")

        Catch ex As Exception
            MsgBox("An error occurred during game initialization: " & ex.Message)
        End Try
    End Sub

    Private Sub Draw_Click(sender As Object, e As EventArgs) Handles Draw.Click
        Try
            ' Random card from draw_deck.json
            Dim randomCard As String = GetRandomCardFromFile("draw_deck.json")

            ' Image for the drawn card
            DrawnCardImage(randomCard)

            CheckForMatch(randomCard)


            Dim currentPlayer As PlayerInfo = ReadPlayerInfoFromJson(1)
            If currentPlayer.Cards.Count = 0 Then
                GameFinished(currentPlayer.Name)
                Exit Sub
            End If

            ChangeTurn()

            LoadPlayers(noofplayers)

        Catch ex As Exception
            MsgBox("An error occurred during card drawing: " & ex.Message)
        End Try
    End Sub


    Private Sub LoadPlayers(noofplayers As Integer)
        If noofplayers = 2 Then
            PLayer2Name.Enabled = False
            PLayer2Name.Hide()
            Player_2.Enabled = False
            Player_2.Hide()

            Player4Name.Enabled = False
            Player4Name.Hide()
            Player_4.Enabled = False
            Player_4.Hide()

            LoadPlayer1CardsIntoPictureBoxes(1)
            LoadPlayer3CardsIntoPictureBoxes(2)
        ElseIf noofplayers = 3 Then
            Player3Name.Enabled = False
            Player3Name.Hide()

            Player_3.Enabled = False
            Player_3.Hide()

            LoadPlayer1CardsIntoPictureBoxes(1)
            LoadPlayer2CardsIntoPictureBoxes(2)
            LoadPlayer4CardsIntoPictureBoxes(3)
        ElseIf noofplayers = 4 Then
            LoadPlayer1CardsIntoPictureBoxes(1)
            LoadPlayer2CardsIntoPictureBoxes(2)
            LoadPlayer3CardsIntoPictureBoxes(3)
            LoadPlayer4CardsIntoPictureBoxes(4)
        Else
            MsgBox("Error in number of players")
        End If
    End Sub

    Private Sub ChangeTurn()
        Dim players As List(Of PlayerInfo) = ReadAllPlayersFromJson("players_hands.json")
        For Each player In players
            player.Position -= 1
            If noofplayers = 2 Then
                If player.Position = 0 Then
                    player.Position = 2
                End If
            ElseIf noofplayers = 3 Then
                If player.Position = 0 Then
                    player.Position = 3
                End If
            Else
                If player.Position = 0 Then
                    player.Position = 4
                End If
            End If
        Next
        Dim updatedTurn As String = JsonConvert.SerializeObject(players, Formatting.Indented)
        File.WriteAllText("players_hands.json", updatedTurn)
    End Sub

    Private Async Sub CheckForMatch(drawnCard As String)
        Dim currentPlayer As PlayerInfo = ReadPlayerInfoFromJson(1S)
        Dim currentPlayerCards As New List(Of String)()
        Dim cardsToRemove As New List(Of String)
        ' Reset nomatches count
        nomatches = 0

        If currentPlayer IsNot Nothing Then
            For Each card In currentPlayer.Cards
                currentPlayerCards.Add(card)
            Next

            For i = 0 To currentPlayerCards.Count - 2
                Dim card1 = currentPlayerCards(i)

                ' Check for duplicates starting from the next card in the list
                For j = i + 1 To currentPlayerCards.Count - 1
                    Dim card2 = currentPlayerCards(j)

                    If card1.Substring(0, 1) = card2.Substring(0, 1) Then
                        ' Found a duplicate, add both cards to remove list
                        cardsToRemove.Add(card1)
                        cardsToRemove.Add(card2)
                    End If
                Next
            Next

            ' Remove duplicate cards from player hands
            For Each cardToRemove In cardsToRemove
                RemoveCardFromFile("players_hands.json", cardToRemove)
            Next

            For Each card In currentPlayerCards

                If drawnCard.Substring(0, 1) = card.Substring(0, 1) Then
                    MsgBox("Hit!!")
                    RemoveCardFromFile("draw_deck.json", drawnCard)
                    RemoveCardFromFile("players_hands.json", card)

                    LoadPlayers(noofplayers)
                    ' Hold for 2 seconds
                    Await Task.Delay(1000)
                    Exit Sub ' Exit sub once a match is found and removed
                Else
                    nomatches += 1
                End If
            Next
            ' If no matches, add the card to unmatched_cards.json
            If nomatches = currentPlayerCards.Count Then
                RemoveCardFromFile("draw_deck.json", drawnCard)
                AddCardToFile("unmatched_cards.json", drawnCard)
            End If


        Else

            MsgBox("Error! Current player is empty.")

        End If
    End Sub

    Sub DrawnCardImage(cardName As String)
        CardDrew.Show()
        Try
            Dim imagePath As String = Path.Combine(Application.StartupPath, "Deck_of_Cards", cardName & ".png")
            CardDrew.Image = Image.FromFile(imagePath)
            CardDrew.SizeMode = PictureBoxSizeMode.StretchImage
        Catch ex As FileNotFoundException
            MsgBox("Image file Not found for " & cardName)
        End Try
    End Sub

    Sub ClearJsonFile(filePath As String)
        ' Serialize an empty array 
        Dim emptyJson As String = "[]"
        File.WriteAllText(filePath, emptyJson)
    End Sub

    Function Initializedeck() As List(Of String)
        Dim suits As String() = {"Hearts", "Diamonds", "Clubs", "Spades"}
        Dim values As String() = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace"}
        Dim deck As New List(Of String)()

        For Each suit In suits
            For Each value In values
                deck.Add(value & " of " & suit)
            Next
        Next

        Return deck
    End Function

    Function Shuffledeck(deck As List(Of String)) As List(Of String)
        Dim rand As New Random()
        Dim n As Integer = deck.Count

        While n > 1
            n -= 1
            Dim k As Integer = rand.Next(n + 1)
            Dim value As String = deck(k)
            deck(k) = deck(n)
            deck(n) = value
        End While

        Return deck
    End Function

    Function Distributecards(deck As List(Of String), numberofplayers As Integer, cardsperplayer As Integer) As List(Of List(Of String))
        Dim players As New List(Of List(Of String))()
        Dim totalCards As Integer = numberofplayers * cardsperplayer

        If totalCards > deck.Count Then
            Throw New ArgumentException("Not enough cards in the deck to distribute.")
        End If

        For i As Integer = 0 To numberofplayers - 1
            Dim playercards As New List(Of String)()

            For j As Integer = 0 To cardsperplayer - 1
                playercards.Add(deck(i * cardsperplayer + j))
            Next

            players.Add(playercards)
        Next

        ' Remove the distributed cards from the deck
        deck.RemoveRange(0, totalCards)

        Return players
    End Function

    Sub Writeremainingcardstojsonfile(remainingdeck As List(Of String), filepath As String)
        Dim json As String = JsonConvert.SerializeObject(remainingdeck, Formatting.Indented)
        File.WriteAllText(filepath, json)
        MsgBox("Remaining cards saved to " & filepath)
    End Sub

    Sub SavePlayerHands(players As List(Of List(Of String)))
        Try
            ' Convert list of lists of strings to list of Player objects
            Dim playersList As New List(Of PlayerInfo)
            For i As Integer = 0 To players.Count - 1
                playersList.Add(New PlayerInfo With {
                    .Position = (i + 1),
                    .Name = PName(i),
                    .Cards = players(i)
                })
            Next

            ' Serialize list of Player objects to JSON
            Dim json As String = JsonConvert.SerializeObject(playersList, Formatting.Indented)

            ' Write JSON to file
            File.WriteAllText("players_hands.json", json)

            MsgBox("Player hands saved successfully.")
        Catch ex As Exception
            MsgBox($"Error saving player hands:    {ex.Message}")
        End Try
    End Sub

    Function GetRandomCardFromFile(filePath As String) As String
        Try
            ' Check if the file exists
            If Not File.Exists(filePath) Then
                Throw New FileNotFoundException("The file was not found: " & filePath)
            End If

            ' Read all text from JSON file
            Dim json As String = File.ReadAllText(filePath)

            ' Check if the JSON is empty
            If String.IsNullOrWhiteSpace(json) Then
                Throw New Exception("The file is empty or contains only whitespace: " & filePath)
            End If

            ' Deserialize JSON array to List(Of String)
            Dim cards As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(json)

            If cards Is Nothing OrElse cards.Count = 4 Then
                DeckCard4.Hide()
            ElseIf cards Is Nothing OrElse cards.Count = 3 Then
                DeckCard3.Hide()
            ElseIf cards Is Nothing OrElse cards.Count = 2 Then
                DeckCard2.Hide()
            ElseIf cards Is Nothing OrElse cards.Count = 1 Then
                DeckCard1.Hide()
                Draw.Hide()
                Reshuffle.Show()
            End If

            ' Generate random index
            Dim rand As New Random()
            Dim randomIndex As Integer = rand.Next(0, cards.Count)

            ' Return random card
            Return cards(randomIndex)
        Catch ex As Exception
            ' Log the error message (you can replace this with proper logging)
            MsgBox("Error: " & ex.Message)
            Return String.Empty
        End Try
    End Function

    Sub AddCardToFile(filePath As String, cardToAdd As String)
        ' Read all text from JSON file
        Dim json As String = File.ReadAllText(filePath)

        ' Deserialize JSON array to List(Of String)
        Dim cards As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(json)

        ' Add the new card to the list
        cards.Add(cardToAdd)

        ' Serialize updated list back to JSON
        Dim updatedJson As String = JsonConvert.SerializeObject(cards, Formatting.Indented)

        ' Write updated JSON back to file
        File.WriteAllText(filePath, updatedJson)
    End Sub

    Private Sub Reshuffle_Click(sender As Object, e As EventArgs) Handles Reshuffle.Click
        Reshuffle.Hide()
        CardDrew.Hide()

        Dim unmatched_cards As String = File.ReadAllText("unmatched_cards.json")
        Dim draw_deck As String = File.ReadAllText("draw_deck.json")

        Dim cards1 As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(unmatched_cards)
        Dim cards2 As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(draw_deck)

        For Each card In cards1
            cards2.Add(card)
        Next

        Dim updatedJson As String = JsonConvert.SerializeObject(Shuffledeck(cards2), Formatting.Indented)

        File.WriteAllText("draw_deck.json", updatedJson)

        ClearJsonFile("unmatched_cards.json")
        DeckVisible()
        Draw.Show()
    End Sub

    Public Sub DeckVisible()
        DeckCard1.Show()
        DeckCard2.Show()
        DeckCard3.Show()
        DeckCard4.Show()
    End Sub

    Private Sub LoadPlayer1CardsIntoPictureBoxes(P1position As Integer)
        ' Read player information from JSON
        Dim p1 As PlayerInfo = ReadPlayerInfoFromJson(P1position)
        Dim noofcards As Integer = p1.Cards.Count

        If p1 IsNot Nothing Then
            Player1Name.Text = p1.Name
            ' Access player cards and load into picture boxes
            Dim pictureBoxIndex As Integer = 1
            For Each card In p1.Cards
                If pictureBoxIndex <= noofcards Then
                    Dim pictureBoxName As String = $"Player1Card{pictureBoxIndex}"
                    Dim pictureBox As PictureBox = Me.Controls.Find(pictureBoxName, True).FirstOrDefault()

                    If pictureBox IsNot Nothing Then
                        Dim imagePath As String = $"D:\_Programs\_Visual_Studio_Workspace\Game\bin\Debug\Deck_of_Cards\{card}.png" ' Adjust file extension as per your setup

                        If File.Exists(imagePath) Then
                            pictureBox.Image = Image.FromFile(imagePath)
                        Else
                            MsgBox($"Image file not found: {imagePath}")
                        End If
                    Else
                        MsgBox($"PictureBox not found: {pictureBoxName}")
                    End If

                    pictureBoxIndex += 1
                Else
                    Exit For
                End If
            Next

            ' Fill remaining picture boxes with default image
            Dim defaultImagePath As String = "D:\_Programs\_Visual_Studio_Workspace\Game\Resources\Vertical_Card.jpg"

            While pictureBoxIndex <= 5
                Dim pictureBoxName As String = $"Player1Card{pictureBoxIndex}"
                Dim pictureBox As PictureBox = Me.Controls.Find(pictureBoxName, True).FirstOrDefault()

                If pictureBox IsNot Nothing Then
                    If File.Exists(defaultImagePath) Then
                        pictureBox.Image = Image.FromFile(defaultImagePath)
                    Else
                        MsgBox($"Default image file not found: {defaultImagePath}")
                    End If
                Else
                    MsgBox($"PictureBox not found: {pictureBoxName}")
                End If

                pictureBoxIndex += 1
            End While
        Else
            MsgBox("Player information not found.")
        End If
    End Sub
    Private Sub LoadPlayer2CardsIntoPictureBoxes(P2position As Integer)
        Dim p2 As PlayerInfo = ReadPlayerInfoFromJson(P2position)
        Dim noofcards = p2.Cards.Count
        If p2 IsNot Nothing Then
            PLayer2Name.Text = p2.Name
            Dim pictureBoxIndex As Integer = 1
            For Each card In p2.Cards
                If pictureBoxIndex <= noofcards Then
                    Dim pictureBoxName As String = $"Player2Card{pictureBoxIndex}"
                    Dim pictureBox As PictureBox = Me.Controls.Find(pictureBoxName, True).FirstOrDefault()

                    If pictureBox IsNot Nothing Then
                        Dim imagePath As String = $"D:\_Programs\_Visual_Studio_Workspace\Game\bin\Debug\Deck_of_Cards\Horizontal\{card}.png"

                        If File.Exists(imagePath) Then
                            pictureBox.Image = Image.FromFile(imagePath)
                        Else
                            MsgBox($"Image file not found: {imagePath}")
                        End If
                    Else
                        MsgBox($"PictureBox not found: {pictureBoxName}")
                    End If

                    pictureBoxIndex += 1
                Else
                    Exit For
                End If
            Next

            Dim defaultImagePath As String = "D:\_Programs\_Visual_Studio_Workspace\Game\Resources\Horizontal_Card.jpg"

            While pictureBoxIndex <= 5
                Dim pictureBoxName As String = $"Player2Card{pictureBoxIndex}"
                Dim pictureBox As PictureBox = Me.Controls.Find(pictureBoxName, True).FirstOrDefault()

                If pictureBox IsNot Nothing Then
                    If File.Exists(defaultImagePath) Then
                        pictureBox.Image = Image.FromFile(defaultImagePath)
                    Else
                        MsgBox($"Default image file not found: {defaultImagePath}")
                    End If
                Else
                    MsgBox($"PictureBox not found: {pictureBoxName}")
                End If

                pictureBoxIndex += 1
            End While
        Else
            MsgBox("Player information not found.")
        End If
    End Sub
    Private Sub LoadPlayer3CardsIntoPictureBoxes(P3position As Integer)
        Dim p3 As PlayerInfo = ReadPlayerInfoFromJson(P3position)
        Dim noofcards = p3.Cards.Count
        If p3 IsNot Nothing Then
            Player3Name.Text = p3.Name
            Dim pictureBoxIndex As Integer = 1
            For Each card In p3.Cards
                If pictureBoxIndex <= noofcards Then
                    Dim pictureBoxName As String = $"Player3Card{pictureBoxIndex}"
                    Dim pictureBox As PictureBox = Me.Controls.Find(pictureBoxName, True).FirstOrDefault()

                    If pictureBox IsNot Nothing Then
                        Dim imagePath As String = $"D:\_Programs\_Visual_Studio_Workspace\Game\bin\Debug\Deck_of_Cards\{card}.png" ' Adjust file extension as per your setup

                        If File.Exists(imagePath) Then
                            pictureBox.Image = Image.FromFile(imagePath)
                        Else
                            MsgBox($"Image file not found: {imagePath}")
                        End If
                    Else
                        MsgBox($"PictureBox not found: {pictureBoxName}")
                    End If

                    pictureBoxIndex += 1
                Else
                    Exit For
                End If
            Next

            Dim defaultImagePath As String = "D:\_Programs\_Visual_Studio_Workspace\Game\Resources\Vertical_Card.jpg"

            While pictureBoxIndex <= 5
                Dim pictureBoxName As String = $"Player3Card{pictureBoxIndex}"
                Dim pictureBox As PictureBox = Me.Controls.Find(pictureBoxName, True).FirstOrDefault()

                If pictureBox IsNot Nothing Then
                    If File.Exists(defaultImagePath) Then
                        pictureBox.Image = Image.FromFile(defaultImagePath)
                    Else
                        MsgBox($"Default image file not found: {defaultImagePath}")
                    End If
                Else
                    MsgBox($"PictureBox not found: {pictureBoxName}")
                End If

                pictureBoxIndex += 1
            End While
        Else
            MsgBox("Player information not found.")
        End If
    End Sub
    Private Sub LoadPlayer4CardsIntoPictureBoxes(P4position As Integer)
        Dim p4 As PlayerInfo = ReadPlayerInfoFromJson(P4position)
        Dim noofcards = p4.Cards.Count
        If p4 IsNot Nothing Then
            Player4Name.Text = p4.Name
            Dim pictureBoxIndex As Integer = 1
            For Each card In p4.Cards
                If pictureBoxIndex <= noofcards Then
                    Dim pictureBoxName As String = $"Player4Card{pictureBoxIndex}"
                    Dim pictureBox As PictureBox = Me.Controls.Find(pictureBoxName, True).FirstOrDefault()

                    If pictureBox IsNot Nothing Then
                        Dim imagePath As String = $"D:\_Programs\_Visual_Studio_Workspace\Game\bin\Debug\Deck_of_Cards\Horizontal\{card}.png" ' Adjust file extension as per your setup

                        If File.Exists(imagePath) Then
                            pictureBox.Image = Image.FromFile(imagePath)
                        Else
                            MsgBox($"Image file not found: {imagePath}")
                        End If
                    Else
                        MsgBox($"PictureBox not found: {pictureBoxName}")
                    End If

                    pictureBoxIndex += 1
                Else
                    Exit For
                End If
            Next

            Dim defaultImagePath As String = "D:\_Programs\_Visual_Studio_Workspace\Game\Resources\Horizontal_Card.jpg"

            While pictureBoxIndex <= 5
                Dim pictureBoxName As String = $"Player4Card{pictureBoxIndex}"
                Dim pictureBox As PictureBox = Me.Controls.Find(pictureBoxName, True).FirstOrDefault()

                If pictureBox IsNot Nothing Then
                    If File.Exists(defaultImagePath) Then
                        pictureBox.Image = Image.FromFile(defaultImagePath)
                    Else
                        MsgBox($"Default image file not found: {defaultImagePath}")
                    End If
                Else
                    MsgBox($"PictureBox not found: {pictureBoxName}")
                End If

                pictureBoxIndex += 1
            End While
        Else
            MsgBox("Player information not found.")
        End If
    End Sub

    Private Sub GameFinished(winner As String)
        MsgBox("Player " & winner & " is the Winner. Big W !!!")
        If MessageBox.Show("Do you want to Play Again?", "Play Again or Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Initialize_Game()
        Else
            Me.Close()
        End If
    End Sub

    Sub RemoveCardFromFile(filePath As String, cardToRemove As String)
        If filePath = "players_hands.json" Then
            Dim currentPlayer As PlayerInfo = ReadPlayerInfoFromJson(1)
            Dim currentPlayerCards As New List(Of String)(currentPlayer.cards)

            If currentPlayerCards.Contains(cardToRemove) Then
                currentPlayerCards.Remove(cardToRemove)
            End If

            ' Update the player's cards
            currentPlayer.cards = currentPlayerCards

            ' Read the entire file to update the specific player
            Dim allPlayers As List(Of PlayerInfo) = ReadAllPlayersFromJson(filePath)
            Dim playerIndex As Integer = allPlayers.FindIndex(Function(p) p.Position = currentPlayer.Position)
            If playerIndex >= 0 Then
                allPlayers(playerIndex) = currentPlayer
            End If

            ' Serialize updated list back to JSON
            Dim updatedJson As String = JsonConvert.SerializeObject(allPlayers, Formatting.Indented)
            File.WriteAllText(filePath, updatedJson)
        Else
            Dim json As String = File.ReadAllText(filePath)
            Dim cards As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(json)

            cards.Remove(cardToRemove)

            Dim updatedJson As String = JsonConvert.SerializeObject(cards, Formatting.Indented)
            File.WriteAllText(filePath, updatedJson)
        End If
    End Sub

    ' Method to read player info from JSON file based on position
    Public Function ReadPlayerInfoFromJson(Pno As Integer) As PlayerInfo
        Dim players As List(Of PlayerInfo) = ReadAllPlayersFromJson("players_hands.json")
        Return players.Find(Function(p) p.Position = Pno)
    End Function

    ' Method to read all players from JSON file
    Private Function ReadAllPlayersFromJson(filePath As String) As List(Of PlayerInfo)
        Try
            Dim json As String = File.ReadAllText(filePath)
            Return JsonConvert.DeserializeObject(Of List(Of PlayerInfo))(json)
        Catch ex As Exception
            MsgBox($"Error reading JSON file: {ex.Message}")
            Return New List(Of PlayerInfo)
        End Try
    End Function
End Class

Public Class PlayerInfo
    Public Property Position As Integer
    Public Property Name As String
    Public Property Cards As List(Of String)
End Class