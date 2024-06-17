Imports Game.My.Resources
Imports Newtonsoft.Json
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox
Public Class TheGame

    Public noofplayers As Integer
    Dim nomatches As Integer = 0

    Private Sub TheGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ClearJsonFile("draw_deck.json")
        ClearJsonFile("unmatched_cards.json")

        ' initialize the deck
        Dim deck As List(Of String) = initializedeck()

        ' shuffle the deck
        deck = shuffledeck(deck)

        ' distribute cards to players (5 cards each)
        Dim numberofplayers As Integer = noofplayers
        Dim cardsperplayer As Integer = 5
        Dim players As List(Of List(Of String)) = distributecards(deck, numberofplayers, cardsperplayer)

        Dim playerhands As New List(Of String)()
        For Each player In players
            playerhands.AddRange(player)
        Next

        Dim remainingdeck As List(Of String) = deck.Except(playerhands).ToList()

        writeremainingcardstojsonfile(remainingdeck, "draw_deck.json")

        MsgBox("Game simulation completed. check json files for results.")

        If numberofplayers = 2 Then
            Player_2.Hide()
            Player_4.Hide()
        ElseIf numberofplayers = 3 Then
            Player_3.Hide()
        End If

    End Sub

    Private Sub Draw_Click(sender As Object, e As EventArgs) Handles Draw.Click
        ' random card from draw_deck.json
        Dim randomCard As String = GetRandomCardFromFile("draw_deck.json")

        ' image for the drawn card
        SetCardImage(randomCard)

        Dim cards As String() = {"Ace of Clubs", "Ace of Spades", "Ace of Diamonds", "Ace of Hearts"}

        ' Reset nomatches count
        nomatches = 0

        ' Check for matches and remove from draw_deck.json if matched
        For Each card In cards
            If randomCard = card Then
                RemoveCardFromFile("draw_deck.json", randomCard)
                Exit Sub ' Exit sub once a match is found and removed
            Else
                nomatches += 1
            End If
        Next

        ' If no matches, add the card to unmatched_cards.json
        If nomatches = cards.Length Then
            RemoveCardFromFile("draw_deck.json", randomCard)
            AddCardToFile("unmatched_cards.json", randomCard)
        End If
    End Sub


    Sub SetCardImage(cardName As String)
        Try
            Dim imagePath As String = Path.Combine(Application.StartupPath, "Deck_of_Cards", cardName & ".png")
            CardDrew.Image = Image.FromFile(imagePath)
            CardDrew.SizeMode = PictureBoxSizeMode.StretchImage
        Catch ex As FileNotFoundException
            MsgBox("Image file not found for " & cardName)
        End Try
    End Sub

    Sub ClearJsonFile(filePath As String)
        ' Serialize an empty array to JSON
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

        For i As Integer = 0 To numberofplayers - 1
            Dim playercards As New List(Of String)()

            For j As Integer = 0 To cardsperplayer - 1
                playercards.Add(deck(i * cardsperplayer + j))
            Next

            players.Add(playercards)
        Next

        Return players
    End Function

    Sub writeremainingcardstojsonfile(remainingdeck As List(Of String), filepath As String)
        Dim json As String = JsonConvert.SerializeObject(remainingdeck, Formatting.Indented)
        File.WriteAllText(filepath, json)
        MsgBox("Remaining cards saved to " & filepath)
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

        Dim cards As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(json)

        ' Remove the specific card
        If cards.Contains(cardToRemove) Then
            cards.Remove(cardToRemove)
        Else
            MsgBox("Card not found in the unmatched_cards.json file.")
            Return
        End If

        ' Serialize updated list back to JSON
        Dim updatedJson As String = JsonConvert.SerializeObject(cards, Formatting.Indented)

        File.WriteAllText(filePath, updatedJson)
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

End Class