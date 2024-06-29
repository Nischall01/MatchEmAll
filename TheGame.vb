Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox
Imports Newtonsoft.Json

Public Class TheGame

    Public noofplayers As Integer
    Private nomatches As Integer = 0
    Private Turn As Integer = 0

    Dim Player1Cards As List(Of String)
    Dim Player2Cards As List(Of String)
    Dim Player3Cards As List(Of String)
    Dim Player4Cards As List(Of String)

    Private Sub TheGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initialize_Game()
    End Sub

    Private Sub Initialize_Game()
        Try
            ClearJsonFile("draw_deck.json")
            ClearJsonFile("unmatched_cards.json")

            ' Initialize and shuffle the deck
            Dim deck As List(Of String) = initializedeck()
            deck = shuffledeck(deck)

            ' Distribute cards to players (5 cards each)
            Dim numberofplayers As Integer = noofplayers
            Dim cardsperplayer As Integer = 5
            Dim players As List(Of List(Of String)) = distributecards(deck, numberofplayers, cardsperplayer)

            ' Save each player's hand to a JSON file
            SavePlayerHands(players)

            ' Save remaining cards to draw_deck.json
            Dim playerhands As New List(Of String)()
            For Each player In players
                playerhands.AddRange(player)
            Next
            Dim remainingdeck As List(Of String) = deck.Except(playerhands).ToList()
            writeremainingcardstojsonfile(remainingdeck, "draw_deck.json")

            ' Hide unnecessary player controls based on the number of players
            If numberofplayers = 2 Then
                Player_2.Hide()
                Player_4.Hide()
            ElseIf numberofplayers = 3 Then
                Player_3.Hide()
            End If

            ' Load player cards into picture boxes
            LoadPlayerCardsIntoPictureBoxes()

            MsgBox("Game initialization completed. Players are ready to draw.")
        Catch ex As Exception
            MsgBox("An error occurred during game initialization: " & ex.Message)
        End Try
    End Sub


    Private Sub Draw_Click(sender As Object, e As EventArgs) Handles Draw.Click
        Try
            Turn = Turn + 1

            ' Random card from draw_deck.json
            Dim randomCard As String = GetRandomCardFromFile("draw_deck.json")

            ' Display the drawn card image
            DrawnCardImage(randomCard)

            ' Extract cards for all players
            Player1Cards = ExtractPlayerCards("players_hands.json", "Player1")
            Player2Cards = ExtractPlayerCards("players_hands.json", "Player2")
            Player3Cards = ExtractPlayerCards("players_hands.json", "Player3")
            Player4Cards = ExtractPlayerCards("players_hands.json", "Player4")

            ' Reset nomatches count
            nomatches = 0

            ' Check for matches based on the current turn
            Select Case Turn
                Case 1
                    CheckForMatch(Player1Cards, randomCard)
                Case 2
                    CheckForMatch(Player2Cards, randomCard)
                Case 3
                    CheckForMatch(Player3Cards, randomCard)
                Case 4
                    CheckForMatch(Player4Cards, randomCard)
                Case Else
                    MsgBox("Error in the turn logic.")
            End Select

            ' Reset turn if it exceeds the number of players
            If Turn >= noofplayers Then
                Turn = 0
            End If
        Catch ex As Exception
            MsgBox("An error occurred during card drawing: " & ex.Message)
        End Try

        Player1Cards = ExtractPlayerCards("players_hands.json", "Player1")
        Player2Cards = ExtractPlayerCards("players_hands.json", "Player2")
        Player3Cards = ExtractPlayerCards("players_hands.json", "Player3")
        Player4Cards = ExtractPlayerCards("players_hands.json", "Player4")

        If Player1Cards.Count = 0 Then
            GameFinished(1)
            Exit Sub
        ElseIf Player2Cards.Count = 0 Then
            GameFinished(2)
            Exit Sub
        ElseIf Player3Cards.Count = 0 Then
            GameFinished(3)
            Exit Sub
        ElseIf Player4Cards.Count = 0 Then
            GameFinished(4)
            Exit Sub
        End If

        LoadPlayerCardsIntoPictureBoxes()

    End Sub

    Private Sub CheckForMatch(playerCards As List(Of String), drawnCard As String)

        Dim cardsToRemove As New List(Of String)

        For i = 0 To playerCards.Count - 2
            Dim card1 = playerCards(i)

            ' Check for duplicates starting from the next card in the list
            For j = i + 1 To playerCards.Count - 1
                Dim card2 = playerCards(j)

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

        For Each card In playerCards

            If drawnCard.Substring(0, 1) = card.Substring(0, 1) Then
                MsgBox("Hit!!")
                RemoveCardFromFile("draw_deck.json", drawnCard)
                RemoveCardFromFile("players_hands.json", card)
                Exit Sub ' Exit sub once a match is found and removed
            Else
                nomatches += 1
            End If
        Next
        ' If no matches, add the card to unmatched_cards.json
        If nomatches = playerCards.Count Then
            RemoveCardFromFile("draw_deck.json", drawnCard)
            AddCardToFile("unmatched_cards.json", drawnCard)
        End If
    End Sub

    Sub DrawnCardImage(cardName As String)
        CardDrew.Show()
        Try
            Dim imagePath As String = Path.Combine(Application.StartupPath, "Deck_of_Cards", cardName & ".png")
            CardDrew.Image = Image.FromFile(imagePath)
            CardDrew.SizeMode = PictureBoxSizeMode.StretchImage
        Catch ex As FileNotFoundException
            MsgBox("Image file not found for " & cardName)
        End Try
    End Sub

    Sub ClearJsonFile(filePath As String)
        ' Serialize an empty array 
        Dim emptyJson As String = "[]"
        File.WriteAllText(filePath, emptyJson)
    End Sub

    Function initializedeck() As List(Of String)
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

    Function shuffledeck(deck As List(Of String)) As List(Of String)
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

    Function distributecards(deck As List(Of String), numberofplayers As Integer, cardsperplayer As Integer) As List(Of List(Of String))
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

    Sub writeremainingcardstojsonfile(remainingdeck As List(Of String), filepath As String)
        Dim json As String = JsonConvert.SerializeObject(remainingdeck, Formatting.Indented)
        File.WriteAllText(filepath, json)
        MsgBox("Remaining cards saved to " & filepath)
    End Sub

    Sub SavePlayerHands(players As List(Of List(Of String)))
        Dim playersHands As New Dictionary(Of String, List(Of String))()
        For i As Integer = 0 To players.Count - 1
            playersHands.Add("Player" & (i + 1), players(i))
        Next

        Dim json As String = JsonConvert.SerializeObject(playersHands, Formatting.Indented)
        File.WriteAllText("players_hands.json", json)
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

    Sub RemoveCardFromFile(filePath As String, cardToRemove As String)
        Dim json As String = File.ReadAllText(filePath)

        If filePath.Contains("players_hands.json") Then
            ' Deserialize the JSON into a dictionary
            Dim playersHands As Dictionary(Of String, List(Of String)) = JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of String)))(json)

            ' Remove the specific card from each player's hand if it exists
            For Each player In playersHands.Keys.ToList()
                If playersHands(player).Contains(cardToRemove) Then
                    playersHands(player).Remove(cardToRemove)
                End If
            Next

            ' Serialize the updated dictionary back to JSON
            Dim updatedJson As String = JsonConvert.SerializeObject(playersHands, Formatting.Indented)
            File.WriteAllText(filePath, updatedJson)
        Else
            ' Deserialize the JSON into a list
            Dim cards As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(json)

            ' Remove the specific card
            If cards.Contains(cardToRemove) Then
                cards.Remove(cardToRemove)
            Else
                MsgBox("Card not found in the file.")
                Return
            End If

            ' Serialize updated list back to JSON
            Dim updatedJson As String = JsonConvert.SerializeObject(cards, Formatting.Indented)
            File.WriteAllText(filePath, updatedJson)
        End If
    End Sub

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

        Dim updatedJson As String = JsonConvert.SerializeObject(shuffledeck(cards2), Formatting.Indented)

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

    Function ExtractPlayerCards(jsonFilePath As String, playerno As String) As List(Of String)
        Try
            ' Read the JSON file
            Dim json As String = File.ReadAllText(jsonFilePath)

            ' Deserialize the JSON into a dictionary
            Dim playersHands As Dictionary(Of String, List(Of String)) = JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of String)))(json)

            ' Check if the specified player exists in the dictionary
            If playersHands.ContainsKey(playerno) Then
                ' Return the specified player's hand
                Return playersHands(playerno)
            Else
                ' If the specified player is not found, return an empty list
                Return New List(Of String)()
            End If
        Catch ex As Exception
            ' Handle any errors that occur during the process
            MsgBox("An error occurred while extracting the player's cards: " & ex.Message)
            Return New List(Of String)()
        End Try
    End Function

    Private Sub LoadPlayerCardsIntoPictureBoxes()
        Try
            ' Read the player hands from JSON file
            Dim json As String = File.ReadAllText("players_hands.json")
            Dim playersHands As Dictionary(Of String, List(Of String)) = JsonConvert.DeserializeObject(Of Dictionary(Of String, List(Of String)))(json)

            ' Load Player 1 cards into picture boxes
            If playersHands.ContainsKey("Player1") Then
                Dim cards As List(Of String) = playersHands("Player1")
                For i As Integer = 0 To Math.Min(cards.Count - 1, 4) ' Ensure not to exceed 5 cards
                    Dim cardName As String = cards(i)
                    Dim pictureBoxName As String = "Player1Card" & (i + 1)
                    LoadCardIntoPictureBox(cardName, pictureBoxName)
                Next
            End If

            ' Load Player 2 cards into picture boxes
            If playersHands.ContainsKey("Player2") Then
                Dim cards As List(Of String) = playersHands("Player2")
                For i As Integer = 0 To Math.Min(cards.Count - 1, 4) ' Ensure not to exceed 5 cards
                    Dim cardName As String = cards(i)
                    Dim pictureBoxName As String = "Player2Card" & (i + 1)
                    LoadCardIntoPictureBox(cardName, pictureBoxName)
                Next
            End If

            ' Load Player 3 cards into picture boxes
            If playersHands.ContainsKey("Player3") Then
                Dim cards As List(Of String) = playersHands("Player3")
                For i As Integer = 0 To Math.Min(cards.Count - 1, 4) ' Ensure not to exceed 5 cards
                    Dim cardName As String = cards(i)
                    Dim pictureBoxName As String = "Player3Card" & (i + 1)
                    LoadCardIntoPictureBox(cardName, pictureBoxName)
                Next
            End If

            ' Load Player 4 cards into picture boxes
            If playersHands.ContainsKey("Player4") Then
                Dim cards As List(Of String) = playersHands("Player4")
                For i As Integer = 0 To Math.Min(cards.Count - 1, 4) ' Ensure not to exceed 5 cards
                    Dim cardName As String = cards(i)
                    Dim pictureBoxName As String = "Player4Card" & (i + 1)
                    LoadCardIntoPictureBox(cardName, pictureBoxName)
                Next
            End If

        Catch ex As Exception
            ' Handle any errors that occur during the process
            MsgBox("An error occurred while loading player cards into picture boxes: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadCardIntoPictureBox(cardName As String, pictureBoxName As String)
        Try
            Dim pictureBox As PictureBox = DirectCast(Me.Controls.Find(pictureBoxName, True).FirstOrDefault(), PictureBox)

            If pictureBox IsNot Nothing Then
                Dim imagePath As String = Path.Combine(Application.StartupPath, "Deck_of_Cards", cardName & ".png")
                pictureBox.Image = Image.FromFile(imagePath)
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                MsgBox("PictureBox " & pictureBoxName & " not found.")
            End If
        Catch ex As Exception
            MsgBox("Error loading card into PictureBox " & pictureBoxName & ": " & ex.Message)
        End Try
    End Sub

    Private Sub GameFinished(winner As String)
        MsgBox("Player " & winner & " is the Winner. W")
        If MessageBox.Show("Do you want to Play Again?", "Play Again or Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Initialize_Game()
        Else
            Me.Close()
        End If
    End Sub
End Class
