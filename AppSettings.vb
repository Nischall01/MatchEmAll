Imports System.IO
Imports System.Diagnostics
Imports Microsoft.Win32

Public Class AppSettings
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.IsBackgroundAnImage_Entry = True Then

            If My.Settings.IsEntryBackgroundDefault = True Then
                EntryDefaultBackground.Checked = True

                BrowseButton1.Hide()
                PickAColorButton1.Hide()

            Else
                EntrySelectBackground.Checked = True

                BrowseButton1.Show()
                PickAColorButton1.Hide()

            End If
        Else
            EntryColorBackground.Checked = True

            PickAColorButton1.Show()
            BrowseButton1.Hide()

        End If


        If My.Settings.IsBackgroundAnImage_TheGame = True Then
            TheGameSelectBackground.Checked = True

            BrowseButton2.Show()
            PickAColorButton2.Hide()
        Else
            If My.Settings.IsTheGameBackgroundDefault = True Then
                TheGameDefaultBackground.Checked = True

                BrowseButton2.Hide()
                PickAColorButton2.Hide()
            Else
                TheGameColorBackground.Checked = True

                PickAColorButton2.Show()
                BrowseButton2.Hide()
            End If
        End If

    End Sub

    ' Handles Entry Default Background Checkbox CheckedChanged
    Private Sub EntryBackground_CheckedChanged(sender As Object, e As EventArgs) Handles EntryDefaultBackground.CheckedChanged, EntrySelectBackground.CheckedChanged, EntryColorBackground.CheckedChanged
        If EntryDefaultBackground.Checked Then

            BrowseButton1.Hide()
            PickAColorButton1.Hide()

            My.Settings.IsBackgroundAnImage_Entry = True
            My.Settings.IsEntryBackgroundDefault = True

        ElseIf EntrySelectBackground.Checked Then       ' Handles Entry Select Background Checkbox CheckedChanged

            BrowseButton1.Show()
            PickAColorButton1.Hide()

            My.Settings.IsBackgroundAnImage_Entry = True
            My.Settings.IsEntryBackgroundDefault = False

        Else ' Handles Entry Color Background Checkbox CheckedChanged

            BrowseButton1.Hide()
            PickAColorButton1.Show()


            My.Settings.IsBackgroundAnImage_Entry = False
            My.Settings.IsEntryBackgroundDefault = False

        End If
    End Sub

    ' Handles TheGame Default Background Checkbox CheckedChanged
    Private Sub TheGameDefaultBackground_CheckedChanged(sender As Object, e As EventArgs) Handles TheGameDefaultBackground.CheckedChanged, TheGameSelectBackground.CheckedChanged, TheGameColorBackground.CheckedChanged
        If TheGameDefaultBackground.Checked Then

            BrowseButton2.Hide()
            PickAColorButton2.Hide()

            My.Settings.IsBackgroundAnImage_TheGame = False
            My.Settings.IsTheGameBackgroundDefault = True

        ElseIf TheGameSelectBackground.Checked Then         ' Handles TheGame Select Background Checkbox CheckedChanged

            BrowseButton2.Show()
            PickAColorButton2.Hide()

            My.Settings.IsBackgroundAnImage_TheGame = True
            My.Settings.IsTheGameBackgroundDefault = False

        Else                                                ' Handles Entry Color Background Checkbox CheckedChanged

            PickAColorButton2.Show()
            BrowseButton2.Hide()

            My.Settings.IsBackgroundAnImage_TheGame = False
            My.Settings.IsTheGameBackgroundDefault = False

        End If
    End Sub

    ' Saves settings and refreshes Entry form
    Private Sub Save_Settings_Click(sender As Object, e As EventArgs) Handles Save_Settings.Click
        ' Save changes to settings
        My.Settings.Save()

        If My.Settings.IsBackgroundAnImage_Entry = True Then
            If My.Settings.IsEntryBackgroundDefault = True Then
                Entry.SetBackgroundImage("Default")
            Else
                Entry.SetBackgroundImage("Selected")
            End If
        Else
            Entry.SetBackgroundColor()
        End If

        If My.Settings.IsBackgroundAnImage_TheGame = True Then
            TheGame.SetBackgroundImage()
        Else
            If My.Settings.IsTheGameBackgroundDefault = True Then
                TheGame.SetBackgroundColor("Default")
            Else
                TheGame.SetBackgroundColor("Selected")
            End If
        End If

        Me.Close()
    End Sub


    ' Updates background setting with default path
    Private Sub UpdateBackgroundSetting(settingName As String, defaultPath As String)
        Dim imagePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, defaultPath)
        My.Settings(settingName) = imagePath
    End Sub

    ' Shows OpenFileDialog and updates setting
    Private Sub ShowOpenFileDialogAndUpdateSetting(settingName As String)

        If File.Exists(My.Settings(settingName)) Then
            Dim FilePath As String = My.Settings(settingName)
            OpenFileDialog.InitialDirectory = Path.GetDirectoryName(FilePath)
        Else
            OpenFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Others")
        End If

        OpenFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*"
        OpenFileDialog.FilterIndex = 1
        OpenFileDialog.RestoreDirectory = True

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = OpenFileDialog.FileName
            My.Settings(settingName) = selectedFilePath
        End If
    End Sub

    Private Sub ShowOpenColorDialogAndUpdateSetting(settingName As String)
        If ColorDialog.ShowDialog() = DialogResult.OK Then
            Dim SelectedColor As Color = ColorDialog.Color
            My.Settings(settingName) = SelectedColor
        End If
    End Sub


    Private Sub BrowseButton1_Click(sender As Object, e As EventArgs) Handles BrowseButton1.Click
        ShowOpenFileDialogAndUpdateSetting("Entry_BackgroundImage")
    End Sub

    Private Sub BrowseButton2_Click(sender As Object, e As EventArgs) Handles BrowseButton2.Click
        ShowOpenFileDialogAndUpdateSetting("TheGame_BackgroundImage")
    End Sub

    Private Sub PickAColorButton1_Click(sender As Object, e As EventArgs) Handles PickAColorButton1.Click
        ShowOpenColorDialogAndUpdateSetting("Entry_BackgroundColor")
    End Sub

    Private Sub PickAColorButton2_Click(sender As Object, e As EventArgs) Handles PickAColorButton2.Click
        ShowOpenColorDialogAndUpdateSetting("TheGame_BackgroundColor")
    End Sub

    Private Sub OpenLink(url As String)
        Try
            Process.Start(New ProcessStartInfo(url) With {.UseShellExecute = True})
        Catch ex As Exception
            MsgBox("Unable to open link: " & ex.Message)
        End Try
    End Sub

    Private Sub About_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles About.LinkClicked, Update.LinkClicked
        Dim url As String = "https://www.example.com"
        OpenLink(url)
    End Sub
End Class
