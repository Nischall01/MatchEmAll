<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppSettings))
        Me.Entry_Background = New System.Windows.Forms.GroupBox()
        Me.EntryColorBackground = New System.Windows.Forms.RadioButton()
        Me.PickAColorButton1 = New System.Windows.Forms.Button()
        Me.BrowseButton1 = New System.Windows.Forms.Button()
        Me.EntrySelectBackground = New System.Windows.Forms.RadioButton()
        Me.EntryDefaultBackground = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TheGameColorBackground = New System.Windows.Forms.RadioButton()
        Me.BrowseButton2 = New System.Windows.Forms.Button()
        Me.PickAColorButton2 = New System.Windows.Forms.Button()
        Me.TheGameSelectBackground = New System.Windows.Forms.RadioButton()
        Me.TheGameDefaultBackground = New System.Windows.Forms.RadioButton()
        Me.Save_Settings = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ColorDialog = New System.Windows.Forms.ColorDialog()
        Me.About = New System.Windows.Forms.LinkLabel()
        Me.Update = New System.Windows.Forms.LinkLabel()
        Me.Entry_Background.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Entry_Background
        '
        Me.Entry_Background.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Entry_Background.Controls.Add(Me.EntryColorBackground)
        Me.Entry_Background.Controls.Add(Me.PickAColorButton1)
        Me.Entry_Background.Controls.Add(Me.BrowseButton1)
        Me.Entry_Background.Controls.Add(Me.EntrySelectBackground)
        Me.Entry_Background.Controls.Add(Me.EntryDefaultBackground)
        Me.Entry_Background.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Entry_Background.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Entry_Background.Location = New System.Drawing.Point(232, 40)
        Me.Entry_Background.Name = "Entry_Background"
        Me.Entry_Background.Size = New System.Drawing.Size(352, 152)
        Me.Entry_Background.TabIndex = 0
        Me.Entry_Background.TabStop = False
        Me.Entry_Background.Text = "Entry Background"
        '
        'EntryColorBackground
        '
        Me.EntryColorBackground.AutoSize = True
        Me.EntryColorBackground.Location = New System.Drawing.Point(200, 72)
        Me.EntryColorBackground.Name = "EntryColorBackground"
        Me.EntryColorBackground.Size = New System.Drawing.Size(49, 17)
        Me.EntryColorBackground.TabIndex = 9
        Me.EntryColorBackground.Text = "Color"
        Me.EntryColorBackground.UseVisualStyleBackColor = True
        '
        'PickAColorButton1
        '
        Me.PickAColorButton1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PickAColorButton1.Location = New System.Drawing.Point(264, 72)
        Me.PickAColorButton1.Name = "PickAColorButton1"
        Me.PickAColorButton1.Size = New System.Drawing.Size(72, 24)
        Me.PickAColorButton1.TabIndex = 8
        Me.PickAColorButton1.Text = "Pick a Color"
        Me.PickAColorButton1.UseVisualStyleBackColor = True
        '
        'BrowseButton1
        '
        Me.BrowseButton1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BrowseButton1.Location = New System.Drawing.Point(40, 120)
        Me.BrowseButton1.Name = "BrowseButton1"
        Me.BrowseButton1.Size = New System.Drawing.Size(75, 23)
        Me.BrowseButton1.TabIndex = 5
        Me.BrowseButton1.Text = "Browse"
        Me.BrowseButton1.UseVisualStyleBackColor = True
        '
        'EntrySelectBackground
        '
        Me.EntrySelectBackground.AutoSize = True
        Me.EntrySelectBackground.Location = New System.Drawing.Point(24, 88)
        Me.EntrySelectBackground.Name = "EntrySelectBackground"
        Me.EntrySelectBackground.Size = New System.Drawing.Size(111, 17)
        Me.EntrySelectBackground.TabIndex = 1
        Me.EntrySelectBackground.Text = "Select an Image..."
        Me.EntrySelectBackground.UseVisualStyleBackColor = True
        '
        'EntryDefaultBackground
        '
        Me.EntryDefaultBackground.AutoSize = True
        Me.EntryDefaultBackground.Location = New System.Drawing.Point(24, 48)
        Me.EntryDefaultBackground.Name = "EntryDefaultBackground"
        Me.EntryDefaultBackground.Size = New System.Drawing.Size(59, 17)
        Me.EntryDefaultBackground.TabIndex = 0
        Me.EntryDefaultBackground.Text = "Default"
        Me.EntryDefaultBackground.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.TheGameColorBackground)
        Me.GroupBox1.Controls.Add(Me.BrowseButton2)
        Me.GroupBox1.Controls.Add(Me.PickAColorButton2)
        Me.GroupBox1.Controls.Add(Me.TheGameSelectBackground)
        Me.GroupBox1.Controls.Add(Me.TheGameDefaultBackground)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Location = New System.Drawing.Point(232, 232)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 152)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TheGame Background"
        '
        'TheGameColorBackground
        '
        Me.TheGameColorBackground.AutoSize = True
        Me.TheGameColorBackground.Location = New System.Drawing.Point(200, 72)
        Me.TheGameColorBackground.Name = "TheGameColorBackground"
        Me.TheGameColorBackground.Size = New System.Drawing.Size(49, 17)
        Me.TheGameColorBackground.TabIndex = 9
        Me.TheGameColorBackground.Text = "Color"
        Me.TheGameColorBackground.UseVisualStyleBackColor = True
        '
        'BrowseButton2
        '
        Me.BrowseButton2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BrowseButton2.Location = New System.Drawing.Point(40, 120)
        Me.BrowseButton2.Name = "BrowseButton2"
        Me.BrowseButton2.Size = New System.Drawing.Size(75, 23)
        Me.BrowseButton2.TabIndex = 5
        Me.BrowseButton2.Text = "Browse"
        Me.BrowseButton2.UseVisualStyleBackColor = True
        '
        'PickAColorButton2
        '
        Me.PickAColorButton2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PickAColorButton2.Location = New System.Drawing.Point(256, 72)
        Me.PickAColorButton2.Name = "PickAColorButton2"
        Me.PickAColorButton2.Size = New System.Drawing.Size(72, 24)
        Me.PickAColorButton2.TabIndex = 8
        Me.PickAColorButton2.Text = "Pick a Color"
        Me.PickAColorButton2.UseVisualStyleBackColor = True
        '
        'TheGameSelectBackground
        '
        Me.TheGameSelectBackground.AutoSize = True
        Me.TheGameSelectBackground.Location = New System.Drawing.Point(24, 88)
        Me.TheGameSelectBackground.Name = "TheGameSelectBackground"
        Me.TheGameSelectBackground.Size = New System.Drawing.Size(111, 17)
        Me.TheGameSelectBackground.TabIndex = 1
        Me.TheGameSelectBackground.TabStop = True
        Me.TheGameSelectBackground.Text = "Select an Image..."
        Me.TheGameSelectBackground.UseVisualStyleBackColor = True
        '
        'TheGameDefaultBackground
        '
        Me.TheGameDefaultBackground.AutoSize = True
        Me.TheGameDefaultBackground.Location = New System.Drawing.Point(24, 48)
        Me.TheGameDefaultBackground.Name = "TheGameDefaultBackground"
        Me.TheGameDefaultBackground.Size = New System.Drawing.Size(59, 17)
        Me.TheGameDefaultBackground.TabIndex = 0
        Me.TheGameDefaultBackground.TabStop = True
        Me.TheGameDefaultBackground.Text = "Default"
        Me.TheGameDefaultBackground.UseVisualStyleBackColor = True
        '
        'Save_Settings
        '
        Me.Save_Settings.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Save_Settings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Save_Settings.Location = New System.Drawing.Point(368, 400)
        Me.Save_Settings.Name = "Save_Settings"
        Me.Save_Settings.Size = New System.Drawing.Size(75, 23)
        Me.Save_Settings.TabIndex = 3
        Me.Save_Settings.Text = "Save"
        Me.Save_Settings.UseVisualStyleBackColor = True
        '
        'About
        '
        Me.About.AutoSize = True
        Me.About.LinkColor = System.Drawing.Color.White
        Me.About.Location = New System.Drawing.Point(744, 424)
        Me.About.Name = "About"
        Me.About.Size = New System.Drawing.Size(35, 13)
        Me.About.TabIndex = 5
        Me.About.TabStop = True
        Me.About.Text = "About"
        '
        'Update
        '
        Me.Update.AutoSize = True
        Me.Update.LinkColor = System.Drawing.Color.White
        Me.Update.Location = New System.Drawing.Point(16, 424)
        Me.Update.Name = "Update"
        Me.Update.Size = New System.Drawing.Size(42, 13)
        Me.Update.TabIndex = 5
        Me.Update.TabStop = True
        Me.Update.Text = "Update"
        '
        'AppSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Update)
        Me.Controls.Add(Me.About)
        Me.Controls.Add(Me.Save_Settings)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Entry_Background)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AppSettings"
        Me.Text = "Settings"
        Me.Entry_Background.ResumeLayout(False)
        Me.Entry_Background.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Entry_Background As GroupBox
    Friend WithEvents EntrySelectBackground As RadioButton
    Friend WithEvents EntryDefaultBackground As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TheGameSelectBackground As RadioButton
    Friend WithEvents TheGameDefaultBackground As RadioButton
    Friend WithEvents Save_Settings As Button
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents BrowseButton1 As Button
    Friend WithEvents BrowseButton2 As Button
    Friend WithEvents ColorDialog As ColorDialog
    Friend WithEvents EntryColorBackground As RadioButton
    Friend WithEvents PickAColorButton1 As Button
    Friend WithEvents TheGameColorBackground As RadioButton
    Friend WithEvents PickAColorButton2 As Button
    Friend WithEvents About As LinkLabel
    Friend WithEvents Update As LinkLabel
End Class
