Imports Game.My.Resources
Imports Newtonsoft.Json
Imports System.IO
Public Class TheGame

    Public noofplayers As Integer
    Dim nomatches As Integer = 0

    Private Sub TheGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ClearJsonFile("draw_deck.json")
        ClearJsonFile("unmatched_cards.json")

        ' step 1: initialize the deck
        Dim deck As List(Of String) = initializedeck()

        ' step 2: shuffle the deck
        deck = shuffledeck(deck)

        ' step 3: distribute cards to players (5 cards each)
        Dim numberofplayers As Integer = noofplayers
        Dim cardsperplayer As Integer = 5
        Dim players As List(Of List(Of String)) = distributecards(deck, numberofplayers, cardsperplayer)

        ' step 4: flatten player hands and find remaining deck
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
        ' Get a random card from unmatched_cards.json
        Dim randomCard As String = GetRandomCardFromFile("draw_deck.json")

        SetCardImage(randomCard)

        'MsgBox("Random Card: " & randomCard)

        ' Example array of cards to check for matches
        Dim cards As String() = {"Ace of Clubs", "Ace of Spades", "Ace of Diamonds", "Ace of Hearts"}

        ' Check for matches and remove from unmatched_cards.json if matched
        For Each card In cards
            If randomCard = card Then
                MsgBox("Match: " & card)
                RemoveCardFromFile("draw_deck.json", card)
                Exit For ' Exit loop once a match is found and removed
            Else
                nomatches += 1
            End If
        Next
        If nomatches = 4 Then
            MsgBox("No Match for " & randomCard)
            RemoveCardFromFile("draw_deck.json", randomCard)
            AddCardToFile("unmatched_cards.json", randomCard)
            MsgBox(randomCard & " added to unmatched_cards.json")
            nomatches = 0
        End If
    End Sub

    Sub SetCardImage(cardName As String)
        Try
            ' Assuming images are stored in a "Deck_of_Cards" directory within the project directory
            Dim imagePath As String = Path.Combine(Application.StartupPath, "Deck_of_Cards", cardName & ".png")
            CardDrew.Image = Image.FromFile(imagePath)
            CardDrew.SizeMode = PictureBoxSizeMode.StretchImage ' Set the image to stretch mode
        Catch ex As FileNotFoundException
            MsgBox("Image file not found for " & cardName)
        End Try
    End Sub

    Sub ClearJsonFile(filePath As String)
        ' Serialize an empty array to JSON
        Dim emptyJson As String = "[]"

        ' Write empty JSON back to file
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
        ' Read all text from JSON file
        Dim json As String = File.ReadAllText(filePath)

        ' Deserialize JSON array to List(Of String)
        Dim cards As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(json)

        ' Generate random index
        Dim rand As New Random()
        Dim randomIndex As Integer = rand.Next(0, cards.Count)

        ' Return random card
        Return cards(randomIndex)
    End Function

    Sub RemoveCardFromFile(filePath As String, cardToRemove As String)
        ' Read all text from JSON file
        Dim json As String = File.ReadAllText(filePath)

        ' Deserialize JSON array to List(Of String)
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

        ' Write updated JSON back to file
        File.WriteAllText(filePath, updatedJson)
        MsgBox("Removed card: " & cardToRemove)
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

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click, PictureBox12.Click

    End Sub
End Class