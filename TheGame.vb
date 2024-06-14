Public Class TheGame

    Public noofplayers As Integer

    Private Function GenerateShuffledNumbers(min As Integer, max As Integer) As List(Of Integer)
        Dim numbers As New List(Of Integer)()
        For i As Integer = min To max
            numbers.Add(i)
        Next

        Dim rnd As New Random()
        For i As Integer = numbers.Count - 1 To 1 Step -1
            Dim j As Integer = rnd.Next(0, i + 1)
            ' Swap numbers(i) and numbers(j)
            Dim temp As Integer = numbers(i)
            numbers(i) = numbers(j)
            numbers(j) = temp
        Next

        Return numbers
    End Function
    Private Function GenerateSingleRandomNumber(min As Integer, max As Integer) As Integer
        Dim rnd As New Random()
        Return rnd.Next(min, max + 1) ' max + 1 because .Next is exclusive on the upper bound
    End Function

    Private Sub TheGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim randomNumbers As List(Of Integer) = GenerateShuffledNumbers(1, 52)
        Dim numbersString As String = String.Join(", ", randomNumbers)
        MsgBox(numbersString)
    End Sub
    Private Sub Draw_Click(sender As Object, e As EventArgs) Handles Draw.Click
        Dim randomNumber As Integer = GenerateSingleRandomNumber(1, 52)
        MsgBox(randomNumber.ToString())
    End Sub
End Class