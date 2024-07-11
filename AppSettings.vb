Imports System.IO
Imports System.Diagnostics
Imports Microsoft.Win32

Public Class AppSettings

    Public change As Boolean
    Public SaveClicked As Boolean

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.Entry_BackgroundImagePath
        TextBox2.Text = My.Settings.TheGame_BackgroundImagePath

        InitializeEntryBackgroundSettings()
        InitializeTheGameBackgroundSettings()

        change = False
        SaveClicked = False
    End Sub

    Private Sub Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If change = True Then
            If SaveClicked = False Then
                Dim result As DialogResult = MessageBox.Show("Save settings?", "Confirm Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                Select Case result
                    Case DialogResult.Yes
                        If SaveAndApplySettings() = "Cancel" Then
                            e.Cancel = True
                        End If
                    Case DialogResult.No
                ' Do nothing and allow the form to close without saving
                    Case DialogResult.Cancel
                        e.Cancel = True ' Cancel the form close event
                End Select
            Else
                If SaveAndApplySettings() = "Cancel" Then
                    e.Cancel = True
                    SaveClicked = False
                End If
            End If
        End If
    End Sub


    Private Sub InitializeEntryBackgroundSettings()
        If My.Settings.Entry_IsBackgroundAnImage Then
            If My.Settings.Entry_IsBackgroundDefault Then
                EntryDefaultBackgroundImage.Checked = True
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
    End Sub

    Private Sub InitializeTheGameBackgroundSettings()
        If My.Settings.TheGame_IsBackgroundAnImage Then
            TheGameSelectBackground.Checked = True
            BrowseButton2.Show()
            PickAColorButton2.Hide()
        Else
            If My.Settings.TheGame_IsBackgroundDefault Then
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

    Private Sub EntryBackground_CheckedChanged(sender As Object, e As EventArgs) Handles EntryDefaultBackgroundImage.CheckedChanged, EntrySelectBackground.CheckedChanged, EntryColorBackground.CheckedChanged
        change = True
        HandleEntryBackgroundSelection()
    End Sub

    Private Sub HandleEntryBackgroundSelection()
        If EntryDefaultBackgroundImage.Checked Then
            BrowseButton1.Hide()
            PickAColorButton1.Hide()
            TextBox1.Enabled = False
        ElseIf EntrySelectBackground.Checked Then
            BrowseButton1.Show()
            PickAColorButton1.Hide()
            TextBox1.Enabled = True
            TextBox1.Text = My.Settings.Entry_BackgroundImagePath
        Else
            BrowseButton1.Hide()
            PickAColorButton1.Show()
            TextBox1.Enabled = False
        End If
    End Sub

    Private Sub TheGameDefaultBackground_CheckedChanged(sender As Object, e As EventArgs) Handles TheGameDefaultBackground.CheckedChanged, TheGameSelectBackground.CheckedChanged, TheGameColorBackground.CheckedChanged
        change = True
        HandleTheGameBackgroundSelection()
    End Sub

    Private Sub HandleTheGameBackgroundSelection()
        If TheGameDefaultBackground.Checked Then
            BrowseButton2.Hide()
            PickAColorButton2.Hide()
            TextBox2.Enabled = False
            TextBox2.Text = My.Settings.TheGame_BackgroundImagePath
        ElseIf TheGameSelectBackground.Checked Then
            BrowseButton2.Show()
            PickAColorButton2.Hide()
            TextBox2.Enabled = True
        Else
            PickAColorButton2.Show()
            BrowseButton2.Hide()
            TextBox2.Enabled = False
        End If
    End Sub

    Private Sub Save_Settings_Click(sender As Object, e As EventArgs) Handles Save_Settings.Click
        SaveClicked = True
        Me.Close()
    End Sub

    Private Function SaveAndApplySettings() As String
        ' Appky changes
        My.Settings.Save()
        If ApplyEntryBackgroundSettings() = "Invalid" Then
            Return "Cancel"
        End If

        If ApplyTheGameBackgroundSettings() = "Invalid" Then
            Return "Cancel"
        End If
        Return "Proceed"
    End Function

    Private Function ApplyEntryBackgroundSettings() As String
        If EntryDefaultBackgroundImage.Checked Then
            My.Settings.Entry_IsBackgroundAnImage = True
            My.Settings.Entry_IsBackgroundDefault = True
        ElseIf EntrySelectBackground.Checked Then
            My.Settings.Entry_IsBackgroundAnImage = True
            My.Settings.Entry_IsBackgroundDefault = False
            If String.IsNullOrWhiteSpace(TextBox1.Text.Trim()) Then
                MsgBox("Please select an image before saving.")
                Return "Invalid"
            End If
        Else
            My.Settings.Entry_IsBackgroundAnImage = False
            My.Settings.Entry_IsBackgroundDefault = False
        End If

        My.Settings.Save()

        If My.Settings.Entry_IsBackgroundAnImage Then
            If My.Settings.Entry_IsBackgroundDefault Then
                Entry.SetBackgroundImage("Default")
            Else
                Entry.SetBackgroundImage("Selected")
            End If
        Else
            Entry.SetBackgroundColor()
        End If
        Return "Valid"
    End Function

    Private Function ApplyTheGameBackgroundSettings() As String
        If TheGameDefaultBackground.Checked Then
            My.Settings.TheGame_IsBackgroundAnImage = False
            My.Settings.TheGame_IsBackgroundDefault = True
        ElseIf TheGameSelectBackground.Checked Then
            My.Settings.TheGame_IsBackgroundAnImage = True
            My.Settings.TheGame_IsBackgroundDefault = False
            If String.IsNullOrWhiteSpace(TextBox2.Text.Trim()) Then
                MsgBox("Please select an image before saving.")
                Return "Invalid"
            End If
        Else
            My.Settings.TheGame_IsBackgroundAnImage = False
            My.Settings.TheGame_IsBackgroundDefault = False
        End If

        My.Settings.Save()

        If My.Settings.TheGame_IsBackgroundAnImage Then
            TheGame.SetBackgroundImage()
        Else
            If My.Settings.TheGame_IsBackgroundDefault Then
                TheGame.SetBackgroundColor("Default")
            Else
                TheGame.SetBackgroundColor("Selected")
            End If
        End If
        Return "Valid"
    End Function

    Private Sub ShowOpenFileDialogAndUpdateSetting(settingName As String)
        If File.Exists(My.Settings(settingName)) Then
            OpenFileDialog.InitialDirectory = Path.GetDirectoryName(My.Settings(settingName))
        Else
            OpenFileDialog.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Others")
        End If

        OpenFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*"
        OpenFileDialog.FilterIndex = 1
        OpenFileDialog.RestoreDirectory = True

        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = OpenFileDialog.FileName
            My.Settings(settingName) = selectedFilePath

            If settingName = "Entry_BackgroundImagePath" Then
                TextBox1.Text = selectedFilePath
            Else
                TextBox2.Text = selectedFilePath
            End If
        End If
    End Sub

    Private Sub ShowOpenColorDialogAndUpdateSetting(settingName As String)
        If ColorDialog.ShowDialog() = DialogResult.OK Then
            My.Settings(settingName) = ColorDialog.Color
        End If
    End Sub

    Private Sub BrowseButton1_Click(sender As Object, e As EventArgs) Handles BrowseButton1.Click
        ShowOpenFileDialogAndUpdateSetting("Entry_BackgroundImagePath")
    End Sub

    Private Sub BrowseButton2_Click(sender As Object, e As EventArgs) Handles BrowseButton2.Click
        ShowOpenFileDialogAndUpdateSetting("TheGame_BackgroundImagePath")
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

    Private Sub About_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles About_link.LinkClicked
        OpenLink("https://github.com/Nischall01/DGame?tab=readme-ov-file#readme")
    End Sub

    Private Sub Update_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Update_link.LinkClicked
        OpenLink("https://github.com/Nischall01/DGame/releases/")
    End Sub
End Class
