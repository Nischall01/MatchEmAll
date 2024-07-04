<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TheGame
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TheGame))
        Me.Draw = New System.Windows.Forms.Button()
        Me.Player_4 = New System.Windows.Forms.Panel()
        Me.Player4Card1 = New System.Windows.Forms.PictureBox()
        Me.Player4Card3 = New System.Windows.Forms.PictureBox()
        Me.Player4Card5 = New System.Windows.Forms.PictureBox()
        Me.Player4Card4 = New System.Windows.Forms.PictureBox()
        Me.Player4Card2 = New System.Windows.Forms.PictureBox()
        Me.Player_1 = New System.Windows.Forms.Panel()
        Me.Player1Card1 = New System.Windows.Forms.PictureBox()
        Me.Player1Card2 = New System.Windows.Forms.PictureBox()
        Me.Player1Card5 = New System.Windows.Forms.PictureBox()
        Me.Player1Card4 = New System.Windows.Forms.PictureBox()
        Me.Player1Card3 = New System.Windows.Forms.PictureBox()
        Me.Player_2 = New System.Windows.Forms.Panel()
        Me.Player2Card1 = New System.Windows.Forms.PictureBox()
        Me.Player2Card5 = New System.Windows.Forms.PictureBox()
        Me.Player2Card2 = New System.Windows.Forms.PictureBox()
        Me.Player2Card4 = New System.Windows.Forms.PictureBox()
        Me.Player2Card3 = New System.Windows.Forms.PictureBox()
        Me.Player_3 = New System.Windows.Forms.Panel()
        Me.Player3Card5 = New System.Windows.Forms.PictureBox()
        Me.Player3Card1 = New System.Windows.Forms.PictureBox()
        Me.Player3Card4 = New System.Windows.Forms.PictureBox()
        Me.Player3Card2 = New System.Windows.Forms.PictureBox()
        Me.Player3Card3 = New System.Windows.Forms.PictureBox()
        Me.Reshuffle = New System.Windows.Forms.Button()
        Me.CardDrew = New System.Windows.Forms.PictureBox()
        Me.DeckCard4 = New System.Windows.Forms.PictureBox()
        Me.DeckCard3 = New System.Windows.Forms.PictureBox()
        Me.DeckCard2 = New System.Windows.Forms.PictureBox()
        Me.DeckCard1 = New System.Windows.Forms.PictureBox()
        Me.PLayer2Name = New System.Windows.Forms.RichTextBox()
        Me.Player3Name = New System.Windows.Forms.RichTextBox()
        Me.Player4Name = New System.Windows.Forms.RichTextBox()
        Me.Player1Name = New System.Windows.Forms.RichTextBox()
        Me.Turn = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Player_4.SuspendLayout()
        CType(Me.Player4Card1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player4Card3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player4Card5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player4Card4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player4Card2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Player_1.SuspendLayout()
        CType(Me.Player1Card1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player1Card2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player1Card5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player1Card4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player1Card3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Player_2.SuspendLayout()
        CType(Me.Player2Card1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player2Card5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player2Card2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player2Card4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player2Card3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Player_3.SuspendLayout()
        CType(Me.Player3Card5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player3Card1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player3Card4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player3Card2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player3Card3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardDrew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeckCard4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeckCard3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeckCard2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DeckCard1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Turn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Draw
        '
        Me.Draw.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Draw.Location = New System.Drawing.Point(351, 362)
        Me.Draw.Name = "Draw"
        Me.Draw.Size = New System.Drawing.Size(89, 32)
        Me.Draw.TabIndex = 1
        Me.Draw.Text = "Draw"
        Me.Draw.UseVisualStyleBackColor = True
        '
        'Player_4
        '
        Me.Player_4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Player_4.Controls.Add(Me.Player4Card1)
        Me.Player_4.Controls.Add(Me.Player4Card3)
        Me.Player_4.Controls.Add(Me.Player4Card5)
        Me.Player_4.Controls.Add(Me.Player4Card4)
        Me.Player_4.Controls.Add(Me.Player4Card2)
        Me.Player_4.Location = New System.Drawing.Point(608, 152)
        Me.Player_4.Name = "Player_4"
        Me.Player_4.Size = New System.Drawing.Size(112, 360)
        Me.Player_4.TabIndex = 42
        '
        'Player4Card1
        '
        Me.Player4Card1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player4Card1.Image = CType(resources.GetObject("Player4Card1.Image"), System.Drawing.Image)
        Me.Player4Card1.Location = New System.Drawing.Point(16, 280)
        Me.Player4Card1.Name = "Player4Card1"
        Me.Player4Card1.Size = New System.Drawing.Size(80, 56)
        Me.Player4Card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player4Card1.TabIndex = 26
        Me.Player4Card1.TabStop = False
        '
        'Player4Card3
        '
        Me.Player4Card3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player4Card3.Image = CType(resources.GetObject("Player4Card3.Image"), System.Drawing.Image)
        Me.Player4Card3.Location = New System.Drawing.Point(16, 152)
        Me.Player4Card3.Name = "Player4Card3"
        Me.Player4Card3.Size = New System.Drawing.Size(80, 56)
        Me.Player4Card3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player4Card3.TabIndex = 25
        Me.Player4Card3.TabStop = False
        '
        'Player4Card5
        '
        Me.Player4Card5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player4Card5.Image = CType(resources.GetObject("Player4Card5.Image"), System.Drawing.Image)
        Me.Player4Card5.Location = New System.Drawing.Point(16, 24)
        Me.Player4Card5.Name = "Player4Card5"
        Me.Player4Card5.Size = New System.Drawing.Size(80, 56)
        Me.Player4Card5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player4Card5.TabIndex = 27
        Me.Player4Card5.TabStop = False
        '
        'Player4Card4
        '
        Me.Player4Card4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player4Card4.Image = CType(resources.GetObject("Player4Card4.Image"), System.Drawing.Image)
        Me.Player4Card4.Location = New System.Drawing.Point(16, 88)
        Me.Player4Card4.Name = "Player4Card4"
        Me.Player4Card4.Size = New System.Drawing.Size(80, 56)
        Me.Player4Card4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player4Card4.TabIndex = 24
        Me.Player4Card4.TabStop = False
        '
        'Player4Card2
        '
        Me.Player4Card2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player4Card2.Image = CType(resources.GetObject("Player4Card2.Image"), System.Drawing.Image)
        Me.Player4Card2.Location = New System.Drawing.Point(16, 216)
        Me.Player4Card2.Name = "Player4Card2"
        Me.Player4Card2.Size = New System.Drawing.Size(80, 56)
        Me.Player4Card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player4Card2.TabIndex = 8
        Me.Player4Card2.TabStop = False
        '
        'Player_1
        '
        Me.Player_1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Player_1.Controls.Add(Me.Player1Card1)
        Me.Player_1.Controls.Add(Me.Player1Card2)
        Me.Player_1.Controls.Add(Me.Player1Card5)
        Me.Player_1.Controls.Add(Me.Player1Card4)
        Me.Player_1.Controls.Add(Me.Player1Card3)
        Me.Player_1.Location = New System.Drawing.Point(214, 494)
        Me.Player_1.Name = "Player_1"
        Me.Player_1.Size = New System.Drawing.Size(360, 112)
        Me.Player_1.TabIndex = 43
        '
        'Player1Card1
        '
        Me.Player1Card1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player1Card1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Player1Card1.Image = Global.Game.My.Resources.Resources.Vertical_Card
        Me.Player1Card1.Location = New System.Drawing.Point(24, 16)
        Me.Player1Card1.Name = "Player1Card1"
        Me.Player1Card1.Size = New System.Drawing.Size(56, 80)
        Me.Player1Card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player1Card1.TabIndex = 0
        Me.Player1Card1.TabStop = False
        Me.Player1Card1.WaitOnLoad = True
        '
        'Player1Card2
        '
        Me.Player1Card2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player1Card2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Player1Card2.Image = Global.Game.My.Resources.Resources.Vertical_Card
        Me.Player1Card2.Location = New System.Drawing.Point(88, 16)
        Me.Player1Card2.Name = "Player1Card2"
        Me.Player1Card2.Size = New System.Drawing.Size(56, 80)
        Me.Player1Card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player1Card2.TabIndex = 33
        Me.Player1Card2.TabStop = False
        Me.Player1Card2.WaitOnLoad = True
        '
        'Player1Card5
        '
        Me.Player1Card5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player1Card5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Player1Card5.Image = Global.Game.My.Resources.Resources.Vertical_Card
        Me.Player1Card5.Location = New System.Drawing.Point(280, 16)
        Me.Player1Card5.Name = "Player1Card5"
        Me.Player1Card5.Size = New System.Drawing.Size(56, 80)
        Me.Player1Card5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player1Card5.TabIndex = 35
        Me.Player1Card5.TabStop = False
        Me.Player1Card5.WaitOnLoad = True
        '
        'Player1Card4
        '
        Me.Player1Card4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player1Card4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Player1Card4.Image = Global.Game.My.Resources.Resources.Vertical_Card
        Me.Player1Card4.Location = New System.Drawing.Point(216, 16)
        Me.Player1Card4.Name = "Player1Card4"
        Me.Player1Card4.Size = New System.Drawing.Size(56, 80)
        Me.Player1Card4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player1Card4.TabIndex = 34
        Me.Player1Card4.TabStop = False
        Me.Player1Card4.WaitOnLoad = True
        '
        'Player1Card3
        '
        Me.Player1Card3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player1Card3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Player1Card3.Image = Global.Game.My.Resources.Resources.Vertical_Card
        Me.Player1Card3.Location = New System.Drawing.Point(152, 16)
        Me.Player1Card3.Name = "Player1Card3"
        Me.Player1Card3.Size = New System.Drawing.Size(56, 80)
        Me.Player1Card3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player1Card3.TabIndex = 32
        Me.Player1Card3.TabStop = False
        Me.Player1Card3.WaitOnLoad = True
        '
        'Player_2
        '
        Me.Player_2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Player_2.Controls.Add(Me.Player2Card1)
        Me.Player_2.Controls.Add(Me.Player2Card5)
        Me.Player_2.Controls.Add(Me.Player2Card2)
        Me.Player_2.Controls.Add(Me.Player2Card4)
        Me.Player_2.Controls.Add(Me.Player2Card3)
        Me.Player_2.Location = New System.Drawing.Point(64, 156)
        Me.Player_2.Name = "Player_2"
        Me.Player_2.Size = New System.Drawing.Size(112, 360)
        Me.Player_2.TabIndex = 42
        '
        'Player2Card1
        '
        Me.Player2Card1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player2Card1.Image = CType(resources.GetObject("Player2Card1.Image"), System.Drawing.Image)
        Me.Player2Card1.Location = New System.Drawing.Point(16, 280)
        Me.Player2Card1.Name = "Player2Card1"
        Me.Player2Card1.Size = New System.Drawing.Size(80, 56)
        Me.Player2Card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player2Card1.TabIndex = 26
        Me.Player2Card1.TabStop = False
        '
        'Player2Card5
        '
        Me.Player2Card5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player2Card5.Image = CType(resources.GetObject("Player2Card5.Image"), System.Drawing.Image)
        Me.Player2Card5.Location = New System.Drawing.Point(16, 24)
        Me.Player2Card5.Name = "Player2Card5"
        Me.Player2Card5.Size = New System.Drawing.Size(80, 56)
        Me.Player2Card5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player2Card5.TabIndex = 27
        Me.Player2Card5.TabStop = False
        '
        'Player2Card2
        '
        Me.Player2Card2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player2Card2.Image = CType(resources.GetObject("Player2Card2.Image"), System.Drawing.Image)
        Me.Player2Card2.Location = New System.Drawing.Point(16, 216)
        Me.Player2Card2.Name = "Player2Card2"
        Me.Player2Card2.Size = New System.Drawing.Size(80, 56)
        Me.Player2Card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player2Card2.TabIndex = 8
        Me.Player2Card2.TabStop = False
        '
        'Player2Card4
        '
        Me.Player2Card4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player2Card4.Image = CType(resources.GetObject("Player2Card4.Image"), System.Drawing.Image)
        Me.Player2Card4.Location = New System.Drawing.Point(16, 88)
        Me.Player2Card4.Name = "Player2Card4"
        Me.Player2Card4.Size = New System.Drawing.Size(80, 56)
        Me.Player2Card4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player2Card4.TabIndex = 24
        Me.Player2Card4.TabStop = False
        '
        'Player2Card3
        '
        Me.Player2Card3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player2Card3.Image = CType(resources.GetObject("Player2Card3.Image"), System.Drawing.Image)
        Me.Player2Card3.Location = New System.Drawing.Point(16, 152)
        Me.Player2Card3.Name = "Player2Card3"
        Me.Player2Card3.Size = New System.Drawing.Size(80, 56)
        Me.Player2Card3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player2Card3.TabIndex = 25
        Me.Player2Card3.TabStop = False
        '
        'Player_3
        '
        Me.Player_3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Player_3.Controls.Add(Me.Player3Card5)
        Me.Player_3.Controls.Add(Me.Player3Card1)
        Me.Player_3.Controls.Add(Me.Player3Card4)
        Me.Player_3.Controls.Add(Me.Player3Card2)
        Me.Player_3.Controls.Add(Me.Player3Card3)
        Me.Player_3.Location = New System.Drawing.Point(214, 64)
        Me.Player_3.Name = "Player_3"
        Me.Player_3.Size = New System.Drawing.Size(360, 112)
        Me.Player_3.TabIndex = 43
        '
        'Player3Card5
        '
        Me.Player3Card5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player3Card5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Player3Card5.Image = CType(resources.GetObject("Player3Card5.Image"), System.Drawing.Image)
        Me.Player3Card5.Location = New System.Drawing.Point(24, 16)
        Me.Player3Card5.Name = "Player3Card5"
        Me.Player3Card5.Size = New System.Drawing.Size(56, 80)
        Me.Player3Card5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player3Card5.TabIndex = 0
        Me.Player3Card5.TabStop = False
        '
        'Player3Card1
        '
        Me.Player3Card1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player3Card1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Player3Card1.Image = CType(resources.GetObject("Player3Card1.Image"), System.Drawing.Image)
        Me.Player3Card1.Location = New System.Drawing.Point(280, 16)
        Me.Player3Card1.Name = "Player3Card1"
        Me.Player3Card1.Size = New System.Drawing.Size(56, 80)
        Me.Player3Card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player3Card1.TabIndex = 35
        Me.Player3Card1.TabStop = False
        '
        'Player3Card4
        '
        Me.Player3Card4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player3Card4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Player3Card4.Image = CType(resources.GetObject("Player3Card4.Image"), System.Drawing.Image)
        Me.Player3Card4.Location = New System.Drawing.Point(88, 16)
        Me.Player3Card4.Name = "Player3Card4"
        Me.Player3Card4.Size = New System.Drawing.Size(56, 80)
        Me.Player3Card4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player3Card4.TabIndex = 33
        Me.Player3Card4.TabStop = False
        '
        'Player3Card2
        '
        Me.Player3Card2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player3Card2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Player3Card2.Image = CType(resources.GetObject("Player3Card2.Image"), System.Drawing.Image)
        Me.Player3Card2.Location = New System.Drawing.Point(216, 16)
        Me.Player3Card2.Name = "Player3Card2"
        Me.Player3Card2.Size = New System.Drawing.Size(56, 80)
        Me.Player3Card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player3Card2.TabIndex = 34
        Me.Player3Card2.TabStop = False
        '
        'Player3Card3
        '
        Me.Player3Card3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Player3Card3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Player3Card3.Image = CType(resources.GetObject("Player3Card3.Image"), System.Drawing.Image)
        Me.Player3Card3.Location = New System.Drawing.Point(152, 16)
        Me.Player3Card3.Name = "Player3Card3"
        Me.Player3Card3.Size = New System.Drawing.Size(56, 80)
        Me.Player3Card3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player3Card3.TabIndex = 32
        Me.Player3Card3.TabStop = False
        '
        'Reshuffle
        '
        Me.Reshuffle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Reshuffle.Location = New System.Drawing.Point(351, 290)
        Me.Reshuffle.Name = "Reshuffle"
        Me.Reshuffle.Size = New System.Drawing.Size(88, 32)
        Me.Reshuffle.TabIndex = 46
        Me.Reshuffle.Text = "Reshuffle"
        Me.Reshuffle.UseVisualStyleBackColor = True
        Me.Reshuffle.Visible = False
        '
        'CardDrew
        '
        Me.CardDrew.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CardDrew.Location = New System.Drawing.Point(368, 408)
        Me.CardDrew.Name = "CardDrew"
        Me.CardDrew.Size = New System.Drawing.Size(56, 80)
        Me.CardDrew.TabIndex = 45
        Me.CardDrew.TabStop = False
        '
        'DeckCard4
        '
        Me.DeckCard4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DeckCard4.Cursor = System.Windows.Forms.Cursors.Default
        Me.DeckCard4.Image = CType(resources.GetObject("DeckCard4.Image"), System.Drawing.Image)
        Me.DeckCard4.Location = New System.Drawing.Point(383, 266)
        Me.DeckCard4.Name = "DeckCard4"
        Me.DeckCard4.Size = New System.Drawing.Size(56, 80)
        Me.DeckCard4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.DeckCard4.TabIndex = 30
        Me.DeckCard4.TabStop = False
        '
        'DeckCard3
        '
        Me.DeckCard3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DeckCard3.Cursor = System.Windows.Forms.Cursors.Default
        Me.DeckCard3.Image = CType(resources.GetObject("DeckCard3.Image"), System.Drawing.Image)
        Me.DeckCard3.Location = New System.Drawing.Point(367, 266)
        Me.DeckCard3.Name = "DeckCard3"
        Me.DeckCard3.Size = New System.Drawing.Size(56, 80)
        Me.DeckCard3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.DeckCard3.TabIndex = 29
        Me.DeckCard3.TabStop = False
        '
        'DeckCard2
        '
        Me.DeckCard2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DeckCard2.Cursor = System.Windows.Forms.Cursors.Default
        Me.DeckCard2.Image = CType(resources.GetObject("DeckCard2.Image"), System.Drawing.Image)
        Me.DeckCard2.Location = New System.Drawing.Point(359, 266)
        Me.DeckCard2.Name = "DeckCard2"
        Me.DeckCard2.Size = New System.Drawing.Size(56, 80)
        Me.DeckCard2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.DeckCard2.TabIndex = 28
        Me.DeckCard2.TabStop = False
        '
        'DeckCard1
        '
        Me.DeckCard1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DeckCard1.Cursor = System.Windows.Forms.Cursors.Default
        Me.DeckCard1.Image = CType(resources.GetObject("DeckCard1.Image"), System.Drawing.Image)
        Me.DeckCard1.Location = New System.Drawing.Point(351, 266)
        Me.DeckCard1.Name = "DeckCard1"
        Me.DeckCard1.Size = New System.Drawing.Size(56, 80)
        Me.DeckCard1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.DeckCard1.TabIndex = 2
        Me.DeckCard1.TabStop = False
        '
        'PLayer2Name
        '
        Me.PLayer2Name.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.PLayer2Name.Location = New System.Drawing.Point(32, 279)
        Me.PLayer2Name.Name = "PLayer2Name"
        Me.PLayer2Name.ReadOnly = True
        Me.PLayer2Name.Size = New System.Drawing.Size(24, 120)
        Me.PLayer2Name.TabIndex = 47
        Me.PLayer2Name.Text = ""
        '
        'Player3Name
        '
        Me.Player3Name.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Player3Name.Location = New System.Drawing.Point(334, 32)
        Me.Player3Name.Name = "Player3Name"
        Me.Player3Name.ReadOnly = True
        Me.Player3Name.Size = New System.Drawing.Size(120, 24)
        Me.Player3Name.TabIndex = 48
        Me.Player3Name.Text = ""
        '
        'Player4Name
        '
        Me.Player4Name.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Player4Name.Location = New System.Drawing.Point(728, 276)
        Me.Player4Name.Name = "Player4Name"
        Me.Player4Name.ReadOnly = True
        Me.Player4Name.Size = New System.Drawing.Size(24, 120)
        Me.Player4Name.TabIndex = 49
        Me.Player4Name.Text = ""
        '
        'Player1Name
        '
        Me.Player1Name.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Player1Name.Location = New System.Drawing.Point(334, 608)
        Me.Player1Name.Name = "Player1Name"
        Me.Player1Name.ReadOnly = True
        Me.Player1Name.Size = New System.Drawing.Size(120, 24)
        Me.Player1Name.TabIndex = 50
        Me.Player1Name.Text = ""
        '
        'Turn
        '
        Me.Turn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Turn.Location = New System.Drawing.Point(352, 400)
        Me.Turn.Name = "Turn"
        Me.Turn.Size = New System.Drawing.Size(88, 96)
        Me.Turn.TabIndex = 51
        Me.Turn.TabStop = False
        '
        'Timer1
        '
        '
        'TheGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGreen
        Me.ClientSize = New System.Drawing.Size(784, 661)
        Me.Controls.Add(Me.Player1Name)
        Me.Controls.Add(Me.Player4Name)
        Me.Controls.Add(Me.Player3Name)
        Me.Controls.Add(Me.PLayer2Name)
        Me.Controls.Add(Me.Reshuffle)
        Me.Controls.Add(Me.CardDrew)
        Me.Controls.Add(Me.Player_3)
        Me.Controls.Add(Me.Player_1)
        Me.Controls.Add(Me.Player_2)
        Me.Controls.Add(Me.Player_4)
        Me.Controls.Add(Me.Draw)
        Me.Controls.Add(Me.DeckCard4)
        Me.Controls.Add(Me.DeckCard3)
        Me.Controls.Add(Me.DeckCard2)
        Me.Controls.Add(Me.DeckCard1)
        Me.Controls.Add(Me.Turn)
        Me.MinimumSize = New System.Drawing.Size(800, 700)
        Me.Name = "TheGame"
        Me.Text = "TheGame"
        Me.Player_4.ResumeLayout(False)
        CType(Me.Player4Card1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player4Card3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player4Card5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player4Card4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player4Card2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Player_1.ResumeLayout(False)
        CType(Me.Player1Card1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player1Card2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player1Card5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player1Card4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player1Card3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Player_2.ResumeLayout(False)
        CType(Me.Player2Card1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player2Card5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player2Card2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player2Card4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player2Card3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Player_3.ResumeLayout(False)
        CType(Me.Player3Card5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player3Card1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player3Card4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player3Card2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player3Card3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardDrew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeckCard4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeckCard3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeckCard2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DeckCard1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Turn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Player1Card1 As PictureBox
    Friend WithEvents DeckCard1 As PictureBox
    Friend WithEvents DeckCard2 As PictureBox
    Friend WithEvents DeckCard3 As PictureBox
    Friend WithEvents DeckCard4 As PictureBox
    Friend WithEvents Draw As Button
    Friend WithEvents Player1Card3 As PictureBox
    Friend WithEvents Player1Card2 As PictureBox
    Friend WithEvents Player1Card4 As PictureBox
    Friend WithEvents Player1Card5 As PictureBox
    Friend WithEvents Player_4 As Panel
    Friend WithEvents Player4Card1 As PictureBox
    Friend WithEvents Player4Card5 As PictureBox
    Friend WithEvents Player4Card2 As PictureBox
    Friend WithEvents Player4Card4 As PictureBox
    Friend WithEvents Player4Card3 As PictureBox
    Friend WithEvents Player_1 As Panel
    Friend WithEvents CardDrew As PictureBox
    Friend WithEvents Player_2 As Panel
    Friend WithEvents Player2Card1 As PictureBox
    Friend WithEvents Player2Card5 As PictureBox
    Friend WithEvents Player2Card2 As PictureBox
    Friend WithEvents Player2Card4 As PictureBox
    Friend WithEvents Player2Card3 As PictureBox
    Friend WithEvents Player_3 As Panel
    Friend WithEvents Player3Card5 As PictureBox
    Friend WithEvents Player3Card1 As PictureBox
    Friend WithEvents Player3Card3 As PictureBox
    Friend WithEvents Player3Card2 As PictureBox
    Friend WithEvents Player3Card4 As PictureBox
    Friend WithEvents Reshuffle As Button
    Friend WithEvents PLayer2Name As RichTextBox
    Friend WithEvents Player3Name As RichTextBox
    Friend WithEvents Player4Name As RichTextBox
    Friend WithEvents Player1Name As RichTextBox
    Friend WithEvents Turn As PictureBox
    Friend WithEvents Timer1 As Timer
End Class
