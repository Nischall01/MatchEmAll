<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Entry
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
        Me.Player1_TextBox = New System.Windows.Forms.TextBox()
        Me.Player2_TextBox = New System.Windows.Forms.TextBox()
        Me.Player3_TextBox = New System.Windows.Forms.TextBox()
        Me.Player1 = New System.Windows.Forms.Label()
        Me.Player2 = New System.Windows.Forms.Label()
        Me.Player3 = New System.Windows.Forms.Label()
        Me.Player4 = New System.Windows.Forms.Label()
        Me.EnterTheGame = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FourPlayers = New System.Windows.Forms.RadioButton()
        Me.ThreePlayers = New System.Windows.Forms.RadioButton()
        Me.TwoPlayers = New System.Windows.Forms.RadioButton()
        Me.Player4_TextBox = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Clear = New System.Windows.Forms.Button()
        Me.Test = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Player1_TextBox
        '
        Me.Player1_TextBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player1_TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Player1_TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Player1_TextBox.Location = New System.Drawing.Point(381, 192)
        Me.Player1_TextBox.Name = "Player1_TextBox"
        Me.Player1_TextBox.Size = New System.Drawing.Size(100, 20)
        Me.Player1_TextBox.TabIndex = 0
        '
        'Player2_TextBox
        '
        Me.Player2_TextBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player2_TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Player2_TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Player2_TextBox.Location = New System.Drawing.Point(381, 231)
        Me.Player2_TextBox.Name = "Player2_TextBox"
        Me.Player2_TextBox.Size = New System.Drawing.Size(100, 20)
        Me.Player2_TextBox.TabIndex = 1
        '
        'Player3_TextBox
        '
        Me.Player3_TextBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player3_TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Player3_TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Player3_TextBox.Location = New System.Drawing.Point(381, 269)
        Me.Player3_TextBox.Name = "Player3_TextBox"
        Me.Player3_TextBox.Size = New System.Drawing.Size(100, 20)
        Me.Player3_TextBox.TabIndex = 2
        '
        'Player1
        '
        Me.Player1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player1.AutoSize = True
        Me.Player1.Location = New System.Drawing.Point(315, 195)
        Me.Player1.Name = "Player1"
        Me.Player1.Size = New System.Drawing.Size(60, 13)
        Me.Player1.TabIndex = 4
        Me.Player1.Text = "Player no.1"
        '
        'Player2
        '
        Me.Player2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player2.AutoSize = True
        Me.Player2.Location = New System.Drawing.Point(315, 234)
        Me.Player2.Name = "Player2"
        Me.Player2.Size = New System.Drawing.Size(60, 13)
        Me.Player2.TabIndex = 12
        Me.Player2.Text = "Player no.2"
        '
        'Player3
        '
        Me.Player3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player3.AutoSize = True
        Me.Player3.Location = New System.Drawing.Point(315, 272)
        Me.Player3.Name = "Player3"
        Me.Player3.Size = New System.Drawing.Size(60, 13)
        Me.Player3.TabIndex = 13
        Me.Player3.Text = "Player no.3"
        '
        'Player4
        '
        Me.Player4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player4.AutoSize = True
        Me.Player4.Location = New System.Drawing.Point(315, 308)
        Me.Player4.Name = "Player4"
        Me.Player4.Size = New System.Drawing.Size(60, 13)
        Me.Player4.TabIndex = 14
        Me.Player4.Text = "Player no.4"
        '
        'EnterTheGame
        '
        Me.EnterTheGame.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.EnterTheGame.Location = New System.Drawing.Point(360, 342)
        Me.EnterTheGame.Name = "EnterTheGame"
        Me.EnterTheGame.Size = New System.Drawing.Size(75, 23)
        Me.EnterTheGame.TabIndex = 15
        Me.EnterTheGame.Text = "Enter"
        Me.EnterTheGame.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.FourPlayers)
        Me.GroupBox1.Controls.Add(Me.ThreePlayers)
        Me.GroupBox1.Controls.Add(Me.TwoPlayers)
        Me.GroupBox1.Location = New System.Drawing.Point(300, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 102)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Enter the Number of Players:"
        '
        'FourPlayers
        '
        Me.FourPlayers.AutoSize = True
        Me.FourPlayers.Location = New System.Drawing.Point(6, 67)
        Me.FourPlayers.Name = "FourPlayers"
        Me.FourPlayers.Size = New System.Drawing.Size(46, 17)
        Me.FourPlayers.TabIndex = 2
        Me.FourPlayers.Text = "Four"
        Me.FourPlayers.UseVisualStyleBackColor = True
        '
        'ThreePlayers
        '
        Me.ThreePlayers.AutoSize = True
        Me.ThreePlayers.Location = New System.Drawing.Point(6, 42)
        Me.ThreePlayers.Name = "ThreePlayers"
        Me.ThreePlayers.Size = New System.Drawing.Size(53, 17)
        Me.ThreePlayers.TabIndex = 1
        Me.ThreePlayers.Text = "Three"
        Me.ThreePlayers.UseVisualStyleBackColor = True
        '
        'TwoPlayers
        '
        Me.TwoPlayers.AutoSize = True
        Me.TwoPlayers.Checked = True
        Me.TwoPlayers.Location = New System.Drawing.Point(6, 19)
        Me.TwoPlayers.Name = "TwoPlayers"
        Me.TwoPlayers.Size = New System.Drawing.Size(46, 17)
        Me.TwoPlayers.TabIndex = 0
        Me.TwoPlayers.TabStop = True
        Me.TwoPlayers.Text = "Two"
        Me.TwoPlayers.UseVisualStyleBackColor = True
        '
        'Player4_TextBox
        '
        Me.Player4_TextBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player4_TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Player4_TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.Player4_TextBox.Location = New System.Drawing.Point(381, 305)
        Me.Player4_TextBox.Name = "Player4_TextBox"
        Me.Player4_TextBox.Size = New System.Drawing.Size(100, 20)
        Me.Player4_TextBox.TabIndex = 17
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(524, 53)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(264, 360)
        Me.DataGridView1.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(620, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Score Board"
        '
        'Clear
        '
        Me.Clear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Clear.Location = New System.Drawing.Point(620, 421)
        Me.Clear.Name = "Clear"
        Me.Clear.Size = New System.Drawing.Size(75, 23)
        Me.Clear.TabIndex = 20
        Me.Clear.Text = "Clear"
        Me.Clear.UseVisualStyleBackColor = True
        '
        'Test
        '
        Me.Test.Location = New System.Drawing.Point(360, 376)
        Me.Test.Name = "Test"
        Me.Test.Size = New System.Drawing.Size(75, 23)
        Me.Test.TabIndex = 21
        Me.Test.Text = "Test"
        Me.Test.UseVisualStyleBackColor = True
        '
        'Entry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Game.My.Resources.Resources.Entry_Background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(804, 461)
        Me.Controls.Add(Me.Test)
        Me.Controls.Add(Me.Clear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Player4_TextBox)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.EnterTheGame)
        Me.Controls.Add(Me.Player4)
        Me.Controls.Add(Me.Player3)
        Me.Controls.Add(Me.Player2)
        Me.Controls.Add(Me.Player1)
        Me.Controls.Add(Me.Player3_TextBox)
        Me.Controls.Add(Me.Player2_TextBox)
        Me.Controls.Add(Me.Player1_TextBox)
        Me.DoubleBuffered = True
        Me.MinimumSize = New System.Drawing.Size(820, 500)
        Me.Name = "Entry"
        Me.Text = "Entry"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Player1_TextBox As TextBox
    Friend WithEvents Player2_TextBox As TextBox
    Friend WithEvents Player3_TextBox As TextBox
    Friend WithEvents Player1 As Label
    Friend WithEvents Player2 As Label
    Friend WithEvents Player3 As Label
    Friend WithEvents Player4 As Label
    Friend WithEvents EnterTheGame As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents FourPlayers As RadioButton
    Friend WithEvents ThreePlayers As RadioButton
    Friend WithEvents TwoPlayers As RadioButton
    Friend WithEvents Player4_TextBox As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Clear As Button
    Friend WithEvents Test As Button
End Class
