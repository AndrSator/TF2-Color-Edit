Imports System.IO

Module Module1
    Public HexColor, Red, Green, Blue As String
    Public ResFile As String
End Module

Public Class MainMenu
    Private Sub MainMenu_Load() Handles MyBase.Load
        ItemThumbnail.BackColor = ColorTranslator.FromHtml("#3C352E")
        ItemNameLabel.BackColor = ColorTranslator.FromHtml("#2A2725")
        ItemNameLabel.ForeColor = ColorTranslator.FromHtml("#FFD700")
        LevelLabel.BackColor = ColorTranslator.FromHtml("#2A2725")
        LevelLabel.ForeColor = ColorTranslator.FromHtml("#756B5E")
        PositiveLabel.BackColor = ColorTranslator.FromHtml("#2A2725")
        PositiveLabel.ForeColor = ColorTranslator.FromHtml("#99CCFF")
        NeutralLabel.BackColor = ColorTranslator.FromHtml("#2A2725")
        NeutralLabel.ForeColor = ColorTranslator.FromHtml("#EBE2CA")
        NegativeLabel.BackColor = ColorTranslator.FromHtml("#2A2725")
        NegativeLabel.ForeColor = ColorTranslator.FromHtml("#FF4040")
        SetNLabel.BackColor = ColorTranslator.FromHtml("#2A2725")
        SetNLabel.ForeColor = ColorTranslator.FromHtml("#E1FF0F")
        SetLabel.BackColor = ColorTranslator.FromHtml("#2A2725")
        SetLabel.ForeColor = ColorTranslator.FromHtml("#95AF0C")
        UseLabel.BackColor = ColorTranslator.FromHtml("#2A2725")
        UseLabel.ForeColor = ColorTranslator.FromHtml("#00A000")
        CraftLabel.BackColor = ColorTranslator.FromHtml("#2A2725")
        CraftLabel.ForeColor = ColorTranslator.FromHtml("#756B5E")
    End Sub

    'Load file
    Private Sub FileOpenButton_Click() Handles FileOpenButton.Click, OpenToolStripMenuItem.Click, FilePathTextBox.Click
        OpenFileDialog1.Filter = "Resource File (*.res)|*.res"
        OpenFileDialog1.FileName = "ClientScheme"
        If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ResFile = OpenFileDialog1.FileName
            FilePathTextBox.Text = ResFile
            Tab.Enabled = True
            SaveButton.Enabled = True
            SaveButton2.Enabled = True
        End If
    End Sub

    Private Sub About_Click() Handles AboutToolStripMenuItem.Click
        AboutWindow.Show()
    End Sub

    'Exit
    Private Sub ExitToolStripMenuItem_Click() Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    'Name edit
    Private Sub ItemNameEdit_Type() Handles ItemNameEdit_TextBox.TextChanged
        ItemNameLabel.Text = ItemNameEdit_TextBox.Text
    End Sub

    'Color Edits

    'Normal Quality
    'Color from RGB values
    Private Sub RGB_Normal_ValueChanged() Handles RGB_R_Normal.ValueChanged, RGB_G_Normal.ValueChanged, RGB_B_Normal.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Normal.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Normal.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Normal.Text)
        HexNormal.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickNormal.BackColor = Color.FromArgb(R, G, B)
        ItemNameLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    'Color from pick
    Private Sub ColorPickNormal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickNormal.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickNormal.BackColor = ColorDialog1.Color
            ItemNameLabel.ForeColor = ColorDialog1.Color
            'RGB Values
            RGB_R_Normal.Text = ColorDialog1.Color.R
            RGB_G_Normal.Text = ColorDialog1.Color.G
            RGB_B_Normal.Text = ColorDialog1.Color.B
            'Hex Value
            HexNormal.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    'Color from Hex
    Private Sub HexNormal_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexNormal.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexNormal.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Normal.Text = Red
            RGB_G_Normal.Text = Green
            RGB_B_Normal.Text = Blue
            ColorPickNormal.BackColor = Color.FromArgb(Red, Green, Blue)
            ItemNameLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Unique quality
    Private Sub RGB_Unique_ValueChanged() Handles RGB_R_Unique.ValueChanged, RGB_G_Unique.ValueChanged, RGB_B_Unique.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Unique.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Unique.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Unique.Text)
        HexUnique.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickUnique.BackColor = Color.FromArgb(R, G, B)
        ItemNameLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickUnique_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickUnique.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickUnique.BackColor = ColorDialog1.Color
            ItemNameLabel.ForeColor = ColorDialog1.Color
            RGB_R_Unique.Text = ColorDialog1.Color.R
            RGB_G_Unique.Text = ColorDialog1.Color.G
            RGB_B_Unique.Text = ColorDialog1.Color.B
            HexUnique.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexUnique_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexUnique.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexUnique.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Unique.Text = Red
            RGB_G_Unique.Text = Green
            RGB_B_Unique.Text = Blue
            ColorPickUnique.BackColor = Color.FromArgb(Red, Green, Blue)
            ItemNameLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Vintage quality
    Private Sub RGB_Vintage_ValueChanged() Handles RGB_R_Vintage.ValueChanged, RGB_G_Vintage.ValueChanged, RGB_B_Vintage.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Vintage.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Vintage.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Vintage.Text)
        HexVintage.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickVintage.BackColor = Color.FromArgb(R, G, B)
        ItemNameLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickVintage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickVintage.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickVintage.BackColor = ColorDialog1.Color
            ItemNameLabel.ForeColor = ColorDialog1.Color
            RGB_R_Vintage.Text = ColorDialog1.Color.R
            RGB_G_Vintage.Text = ColorDialog1.Color.G
            RGB_B_Vintage.Text = ColorDialog1.Color.B
            HexVintage.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexVintage_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexVintage.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexVintage.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Vintage.Text = Red
            RGB_G_Vintage.Text = Green
            RGB_B_Vintage.Text = Blue
            ColorPickVintage.BackColor = Color.FromArgb(Red, Green, Blue)
            ItemNameLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Genuine quality
    Private Sub RGB_Genuine_ValueChanged() Handles RGB_R_Genuine.ValueChanged, RGB_G_Genuine.ValueChanged, RGB_B_Genuine.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Genuine.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Genuine.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Genuine.Text)
        HexGenuine.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickGenuine.BackColor = Color.FromArgb(R, G, B)
        ItemNameLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickGenuine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickGenuine.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickGenuine.BackColor = ColorDialog1.Color
            ItemNameLabel.ForeColor = ColorDialog1.Color
            RGB_R_Genuine.Text = ColorDialog1.Color.R
            RGB_G_Genuine.Text = ColorDialog1.Color.G
            RGB_B_Genuine.Text = ColorDialog1.Color.B
            HexGenuine.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexGenuine_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexGenuine.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexGenuine.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Genuine.Text = Red
            RGB_G_Genuine.Text = Green
            RGB_B_Genuine.Text = Blue
            ColorPickGenuine.BackColor = Color.FromArgb(Red, Green, Blue)
            ItemNameLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Strange quality
    Private Sub RGB_Strange_ValueChanged() Handles RGB_R_Strange.ValueChanged, RGB_G_Strange.ValueChanged, RGB_B_Strange.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Strange.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Strange.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Strange.Text)
        HexStrange.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickStrange.BackColor = Color.FromArgb(R, G, B)
        ItemNameLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickStrange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickStrange.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickStrange.BackColor = ColorDialog1.Color
            ItemNameLabel.ForeColor = ColorDialog1.Color
            RGB_R_Strange.Text = ColorDialog1.Color.R
            RGB_G_Strange.Text = ColorDialog1.Color.G
            RGB_B_Strange.Text = ColorDialog1.Color.B
            HexStrange.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexStrange_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexStrange.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexStrange.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Strange.Text = Red
            RGB_G_Strange.Text = Green
            RGB_B_Strange.Text = Blue
            ColorPickStrange.BackColor = Color.FromArgb(Red, Green, Blue)
            ItemNameLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Unusual quality
    Private Sub RGB_Unusual_ValueChanged() Handles RGB_R_Unusual.ValueChanged, RGB_G_Unusual.ValueChanged, RGB_B_Unusual.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Unusual.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Unusual.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Unusual.Text)
        HexUnusual.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickUnusual.BackColor = Color.FromArgb(R, G, B)
        ItemNameLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickUnusual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickUnusual.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickUnusual.BackColor = ColorDialog1.Color
            ItemNameLabel.ForeColor = ColorDialog1.Color
            RGB_R_Unusual.Text = ColorDialog1.Color.R
            RGB_G_Unusual.Text = ColorDialog1.Color.G
            RGB_B_Unusual.Text = ColorDialog1.Color.B
            HexUnusual.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexUnusual_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexUnusual.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexUnusual.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Unusual.Text = Red
            RGB_G_Unusual.Text = Green
            RGB_B_Unusual.Text = Blue
            ColorPickUnusual.BackColor = Color.FromArgb(Red, Green, Blue)
            ItemNameLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Haunted quality
    Private Sub RGB_Haunted_ValueChanged() Handles RGB_R_Haunted.ValueChanged, RGB_G_Haunted.ValueChanged, RGB_B_Haunted.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Haunted.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Haunted.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Haunted.Text)
        HexHaunted.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickHaunted.BackColor = Color.FromArgb(R, G, B)
        ItemNameLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickHaunted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickHaunted.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickHaunted.BackColor = ColorDialog1.Color
            ItemNameLabel.ForeColor = ColorDialog1.Color
            RGB_R_Haunted.Text = ColorDialog1.Color.R
            RGB_G_Haunted.Text = ColorDialog1.Color.G
            RGB_B_Haunted.Text = ColorDialog1.Color.B
            HexHaunted.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexHaunted_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexHaunted.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexHaunted.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Haunted.Text = Red
            RGB_G_Haunted.Text = Green
            RGB_B_Haunted.Text = Blue
            ColorPickHaunted.BackColor = Color.FromArgb(Red, Green, Blue)
            ItemNameLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Collector quality
    Private Sub RGB_Collector_ValueChanged() Handles RGB_R_Collector.ValueChanged, RGB_G_Collector.ValueChanged, RGB_B_Collector.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Collector.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Collector.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Collector.Text)
        HexCollector.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickCollector.BackColor = Color.FromArgb(R, G, B)
        ItemNameLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickCollector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickCollector.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickCollector.BackColor = ColorDialog1.Color
            ItemNameLabel.ForeColor = ColorDialog1.Color
            RGB_R_Collector.Text = ColorDialog1.Color.R
            RGB_G_Collector.Text = ColorDialog1.Color.G
            RGB_B_Collector.Text = ColorDialog1.Color.B
            HexCollector.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexCollector_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexCollector.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexCollector.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Collector.Text = Red
            RGB_G_Collector.Text = Green
            RGB_B_Collector.Text = Blue
            ColorPickCollector.BackColor = Color.FromArgb(Red, Green, Blue)
            ItemNameLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Community quality
    Private Sub RGB_Community_ValueChanged() Handles RGB_R_Community.ValueChanged, RGB_G_Community.ValueChanged, RGB_B_Community.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Community.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Community.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Community.Text)
        HexCommunity.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickCommunity.BackColor = Color.FromArgb(R, G, B)
        ItemNameLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickCommunity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickCommunity.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickCommunity.BackColor = ColorDialog1.Color
            ItemNameLabel.ForeColor = ColorDialog1.Color
            RGB_R_Community.Text = ColorDialog1.Color.R
            RGB_G_Community.Text = ColorDialog1.Color.G
            RGB_B_Community.Text = ColorDialog1.Color.B
            HexCommunity.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexCommunity_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexCommunity.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexCommunity.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Community.Text = Red
            RGB_G_Community.Text = Green
            RGB_B_Community.Text = Blue
            ColorPickCommunity.BackColor = Color.FromArgb(Red, Green, Blue)
            ItemNameLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Level
    Private Sub RGB_Level_ValueChanged() Handles RGB_R_Level.ValueChanged, RGB_G_Level.ValueChanged, RGB_B_Level.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Level.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Level.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Level.Text)
        HexLevel.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickLevel.BackColor = Color.FromArgb(R, G, B)
        LevelLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickLevel.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickLevel.BackColor = ColorDialog1.Color
            LevelLabel.ForeColor = ColorDialog1.Color
            RGB_R_Level.Text = ColorDialog1.Color.R
            RGB_G_Level.Text = ColorDialog1.Color.G
            RGB_B_Level.Text = ColorDialog1.Color.B
            HexLevel.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexLevel_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexLevel.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexLevel.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Level.Text = Red
            RGB_G_Level.Text = Green
            RGB_B_Level.Text = Blue
            ColorPickLevel.BackColor = Color.FromArgb(Red, Green, Blue)
            LevelLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Positive
    Private Sub RGB_Positive_ValueChanged() Handles RGB_R_Positive.ValueChanged, RGB_G_Positive.ValueChanged, RGB_B_Positive.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Positive.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Positive.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Positive.Text)
        HexPositive.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickPositive.BackColor = Color.FromArgb(R, G, B)
        PositiveLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickPositive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickPositive.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickPositive.BackColor = ColorDialog1.Color
            PositiveLabel.ForeColor = ColorDialog1.Color
            RGB_R_Positive.Text = ColorDialog1.Color.R
            RGB_G_Positive.Text = ColorDialog1.Color.G
            RGB_B_Positive.Text = ColorDialog1.Color.B
            HexPositive.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexPositive_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexPositive.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexPositive.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Positive.Text = Red
            RGB_G_Positive.Text = Green
            RGB_B_Positive.Text = Blue
            ColorPickPositive.BackColor = Color.FromArgb(Red, Green, Blue)
            PositiveLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Neutral
    Private Sub RGB_Neutral_ValueChanged() Handles RGB_R_Neutral.ValueChanged, RGB_G_Neutral.ValueChanged, RGB_B_Neutral.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Neutral.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Neutral.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Neutral.Text)
        HexNeutral.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickNeutral.BackColor = Color.FromArgb(R, G, B)
        NeutralLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickNeutral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickNeutral.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickNeutral.BackColor = ColorDialog1.Color
            NeutralLabel.ForeColor = ColorDialog1.Color
            RGB_R_Neutral.Text = ColorDialog1.Color.R
            RGB_G_Neutral.Text = ColorDialog1.Color.G
            RGB_B_Neutral.Text = ColorDialog1.Color.B
            HexNeutral.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexNeutral_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexNeutral.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexNeutral.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Neutral.Text = Red
            RGB_G_Neutral.Text = Green
            RGB_B_Neutral.Text = Blue
            ColorPickNeutral.BackColor = Color.FromArgb(Red, Green, Blue)
            NeutralLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Negative
    Private Sub RGB_Negative_ValueChanged() Handles RGB_R_Negative.ValueChanged, RGB_G_Negative.ValueChanged, RGB_B_Negative.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Negative.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Negative.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Negative.Text)
        HexNegative.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickNegative.BackColor = Color.FromArgb(R, G, B)
        NegativeLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickNegative_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickNegative.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickNegative.BackColor = ColorDialog1.Color
            NegativeLabel.ForeColor = ColorDialog1.Color
            RGB_R_Negative.Text = ColorDialog1.Color.R
            RGB_G_Negative.Text = ColorDialog1.Color.G
            RGB_B_Negative.Text = ColorDialog1.Color.B
            HexNegative.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexNegative_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexNegative.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexNegative.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Negative.Text = Red
            RGB_G_Negative.Text = Green
            RGB_B_Negative.Text = Blue
            ColorPickNegative.BackColor = Color.FromArgb(Red, Green, Blue)
            NegativeLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'SetN
    Private Sub RGB_SetN_ValueChanged() Handles RGB_R_SetN.ValueChanged, RGB_G_SetN.ValueChanged, RGB_B_SetN.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_SetN.Text)
        Dim G As Integer = Integer.Parse(RGB_G_SetN.Text)
        Dim B As Integer = Integer.Parse(RGB_B_SetN.Text)
        HexSetN.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickSetN.BackColor = Color.FromArgb(R, G, B)
        SetNLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickSetN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickSetN.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickSetN.BackColor = ColorDialog1.Color
            SetNLabel.ForeColor = ColorDialog1.Color
            RGB_R_SetN.Text = ColorDialog1.Color.R
            RGB_G_SetN.Text = ColorDialog1.Color.G
            RGB_B_SetN.Text = ColorDialog1.Color.B
            HexSetN.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexSetN_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexSetN.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexSetN.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_SetN.Text = Red
            RGB_G_SetN.Text = Green
            RGB_B_SetN.Text = Blue
            ColorPickSetN.BackColor = Color.FromArgb(Red, Green, Blue)
            SetNLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Set
    Private Sub RGB_Set_ValueChanged() Handles RGB_R_Set.ValueChanged, RGB_G_Set.ValueChanged, RGB_B_Set.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Set.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Set.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Set.Text)
        HexSet.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickSet.BackColor = Color.FromArgb(R, G, B)
        SetLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickSet.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickSet.BackColor = ColorDialog1.Color
            SetLabel.ForeColor = ColorDialog1.Color
            RGB_R_Set.Text = ColorDialog1.Color.R
            RGB_G_Set.Text = ColorDialog1.Color.G
            RGB_B_Set.Text = ColorDialog1.Color.B
            HexSet.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexSet_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexSet.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexSet.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Set.Text = Red
            RGB_G_Set.Text = Green
            RGB_B_Set.Text = Blue
            ColorPickSet.BackColor = Color.FromArgb(Red, Green, Blue)
            SetLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Use
    Private Sub RGB_Use_ValueChanged() Handles RGB_R_Use.ValueChanged, RGB_G_Use.ValueChanged, RGB_B_Use.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Use.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Use.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Use.Text)
        HexUse.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickUse.BackColor = Color.FromArgb(R, G, B)
        UseLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickUse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickUse.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickUse.BackColor = ColorDialog1.Color
            UseLabel.ForeColor = ColorDialog1.Color
            RGB_R_Use.Text = ColorDialog1.Color.R
            RGB_G_Use.Text = ColorDialog1.Color.G
            RGB_B_Use.Text = ColorDialog1.Color.B
            HexUse.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexUse_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexUse.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexUse.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Use.Text = Red
            RGB_G_Use.Text = Green
            RGB_B_Use.Text = Blue
            ColorPickUse.BackColor = Color.FromArgb(Red, Green, Blue)
            UseLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Craft
    Private Sub RGB_Craft_ValueChanged() Handles RGB_R_Craft.ValueChanged, RGB_G_Craft.ValueChanged, RGB_B_Craft.ValueChanged
        Dim R As Integer = Integer.Parse(RGB_R_Craft.Text)
        Dim G As Integer = Integer.Parse(RGB_G_Craft.Text)
        Dim B As Integer = Integer.Parse(RGB_B_Craft.Text)
        HexCraft.Text = String.Format("{0}{1}{2}", R.ToString("X").PadLeft(2, "0"), G.ToString("X").PadLeft(2, "0"), B.ToString("X").PadLeft(2, "0"))
        ColorPickCraft.BackColor = Color.FromArgb(R, G, B)
        CraftLabel.ForeColor = Color.FromArgb(R, G, B)
    End Sub

    Private Sub ColorPickCraft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorPickCraft.Click
        If (ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            ColorPickCraft.BackColor = ColorDialog1.Color
            CraftLabel.ForeColor = ColorDialog1.Color
            RGB_R_Craft.Text = ColorDialog1.Color.R
            RGB_G_Craft.Text = ColorDialog1.Color.G
            RGB_B_Craft.Text = ColorDialog1.Color.B
            HexCraft.Text = String.Format("{0:X2}{1:X2}{2:X2}", ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B)
        End If
    End Sub

    Private Sub HexCraft_KeyPress(ByVal sender As Object, ByVal e As Windows.Forms.KeyPressEventArgs) Handles HexCraft.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
            If InStr(1, "1234567890ABCDEF", e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            HexColor = HexCraft.Text
            Red = Val("&H" & Mid(HexColor, 1, 2))
            Green = Val("&H" & Mid(HexColor, 3, 2))
            Blue = Val("&H" & Mid(HexColor, 5, 2))
            RGB_R_Craft.Text = Red
            RGB_G_Craft.Text = Green
            RGB_B_Craft.Text = Blue
            ColorPickCraft.BackColor = Color.FromArgb(Red, Green, Blue)
            CraftLabel.ForeColor = Color.FromArgb(Red, Green, Blue)
        End If
    End Sub

    'Save file (Qualities)
    Private Sub SaveButton_Click() Handles SaveButton.Click, QualitiesToolStripMenuItem.Click
        If Not ResFile = Nothing Then
            Dim lines = File.ReadAllLines(ResFile)
            For x = 0 To lines.Count() - 1
                If lines(x).Trim().StartsWith(Chr(34) & "QualityColorNormal" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "QualityColorNormal" & Chr(34) & "					" & Chr(34) & RGB_R_Normal.Text & " " & RGB_G_Normal.Text & " " & RGB_B_Normal.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "QualityColorrarity1" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "QualityColorrarity1" & Chr(34) & "					" & Chr(34) & RGB_R_Genuine.Text & " " & RGB_G_Genuine.Text & " " & RGB_B_Genuine.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "QualityColorUnique" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "QualityColorUnique" & Chr(34) & "					" & Chr(34) & RGB_R_Unique.Text & " " & RGB_G_Unique.Text & " " & RGB_B_Unique.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "QualityColorVintage" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "QualityColorVintage" & Chr(34) & "					" & Chr(34) & RGB_R_Vintage.Text & " " & RGB_G_Vintage.Text & " " & RGB_B_Vintage.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "QualityColorStrange" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "QualityColorStrange" & Chr(34) & "					" & Chr(34) & RGB_R_Strange.Text & " " & RGB_G_Strange.Text & " " & RGB_B_Strange.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "QualityColorrarity4" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "QualityColorrarity4" & Chr(34) & "					" & Chr(34) & RGB_R_Unusual.Text & " " & RGB_G_Unusual.Text & " " & RGB_B_Unusual.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "QualityColorHaunted" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "QualityColorHaunted" & Chr(34) & "					" & Chr(34) & RGB_R_Haunted.Text & " " & RGB_G_Haunted.Text & " " & RGB_B_Haunted.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "QualityColorCollectors" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "QualityColorCollectors" & Chr(34) & "				" & Chr(34) & RGB_R_Collector.Text & " " & RGB_G_Collector.Text & " " & RGB_B_Collector.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "QualityColorCommunity" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "QualityColorCommunity" & Chr(34) & "					" & Chr(34) & RGB_R_Community.Text & " " & RGB_G_Community.Text & " " & RGB_B_Community.Text & " 255" & Chr(34)
                End If
            Next
            File.WriteAllLines(ResFile, lines)
            Status.Text = "Qualities saved!"
            Status.BackColor = Color.FromArgb(240, 240, 240)
        Else
            Status.Text = "Res file not found!"
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                Media.SystemSounds.Hand)
        End If
    End Sub

    'Save file (Attributes)
    Private Sub SaveButton2_Click() Handles SaveButton2.Click, AttributesToolStripMenuItem.Click
        If Not ResFile = Nothing Then
            Dim lines = File.ReadAllLines(ResFile)
            For x = 0 To lines.Count() - 1
                If lines(x).Trim().StartsWith(Chr(34) & "ItemAttribLevel" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "ItemAttribLevel" & Chr(34) & "						" & Chr(34) & RGB_R_Level.Text & " " & RGB_G_Level.Text & " " & RGB_B_Level.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "ItemAttribPositive" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "ItemAttribPositive" & Chr(34) & "					" & Chr(34) & RGB_R_Positive.Text & " " & RGB_G_Positive.Text & " " & RGB_B_Positive.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "ItemAttribNeutral" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "ItemAttribNeutral" & Chr(34) & "						" & Chr(34) & RGB_R_Neutral.Text & " " & RGB_G_Neutral.Text & " " & RGB_B_Neutral.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "ItemAttribNegative" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "ItemAttribNegative" & Chr(34) & "					" & Chr(34) & RGB_R_Negative.Text & " " & RGB_G_Negative.Text & " " & RGB_B_Negative.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "ItemSetName" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "ItemSetName" & Chr(34) & "							" & Chr(34) & RGB_R_SetN.Text & " " & RGB_G_SetN.Text & " " & RGB_B_SetN.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "ItemSetItemEquipped" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "ItemSetItemEquipped" & Chr(34) & "					" & Chr(34) & RGB_R_Set.Text & " " & RGB_G_Set.Text & " " & RGB_B_Set.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "ItemLimitedUse" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "ItemLimitedUse" & Chr(34) & "						" & Chr(34) & RGB_R_Use.Text & " " & RGB_G_Use.Text & " " & RGB_B_Use.Text & " 255" & Chr(34)
                End If
                If lines(x).Trim().StartsWith(Chr(34) & "ItemFlags" & Chr(34)) Then
                    lines(x) = "		" & Chr(34) & "ItemFlags" & Chr(34) & "								" & Chr(34) & RGB_R_Craft.Text & " " & RGB_G_Craft.Text & " " & RGB_B_Craft.Text & " 255" & Chr(34)
                End If
            Next
            File.WriteAllLines(ResFile, lines)
            Status.Text = "Attributes saved!"
            Status.BackColor = Color.FromArgb(240, 240, 240)
        Else
            Status.Text = "Res file not found!"
            Status.BackColor = Color.FromArgb(240, 200, 200)
            My.Computer.Audio.PlaySystemSound( _
                Media.SystemSounds.Hand)
        End If
    End Sub

    Private Sub DefaultColors() Handles DefaultToolStripMenuItem.Click
        'Qualities
        RGB_R_Normal.Text = "178"
        RGB_G_Normal.Text = "178"
        RGB_B_Normal.Text = "178"
        RGB_R_Genuine.Text = "77"
        RGB_G_Genuine.Text = "116"
        RGB_B_Genuine.Text = "85"
        RGB_R_Vintage.Text = "71"
        RGB_G_Vintage.Text = "98"
        RGB_B_Vintage.Text = "145"
        RGB_R_Strange.Text = "207"
        RGB_G_Strange.Text = "106"
        RGB_B_Strange.Text = "50"
        RGB_R_Unusual.Text = "134"
        RGB_G_Unusual.Text = "80"
        RGB_B_Unusual.Text = "172"
        RGB_R_Haunted.Text = "56"
        RGB_G_Haunted.Text = "243"
        RGB_B_Haunted.Text = "171"
        RGB_R_Collector.Text = "170"
        RGB_G_Collector.Text = "0"
        RGB_B_Collector.Text = "0"
        RGB_R_Community.Text = "112"
        RGB_G_Community.Text = "174"
        RGB_B_Community.Text = "74"
        RGB_R_Unique.Text = "225"
        RGB_G_Unique.Text = "215"
        RGB_B_Unique.Text = "0"
        'Attributes
        RGB_R_Level.Text = "117"
        RGB_G_Level.Text = "107"
        RGB_B_Level.Text = "94"
        RGB_R_Positive.Text = "153"
        RGB_G_Positive.Text = "204"
        RGB_B_Positive.Text = "255"
        RGB_R_Neutral.Text = "235"
        RGB_G_Neutral.Text = "226"
        RGB_B_Neutral.Text = "202"
        RGB_R_Negative.Text = "255"
        RGB_G_Negative.Text = "64"
        RGB_B_Negative.Text = "64"
        RGB_R_SetN.Text = "225"
        RGB_G_SetN.Text = "225"
        RGB_B_SetN.Text = "15"
        RGB_R_Set.Text = "149"
        RGB_G_Set.Text = "175"
        RGB_B_Set.Text = "12"
        RGB_R_Use.Text = "0"
        RGB_G_Use.Text = "160"
        RGB_B_Use.Text = "0"
        RGB_R_Craft.Text = "117"
        RGB_G_Craft.Text = "107"
        RGB_B_Craft.Text = "94"
    End Sub

    Private Sub RedPillColors() Handles RedPillsToolStripMenuItem.Click
        RGB_R_Normal.Text = "178"
        RGB_G_Normal.Text = "178"
        RGB_B_Normal.Text = "178"
        RGB_R_Genuine.Text = "79"
        RGB_G_Genuine.Text = "230"
        RGB_B_Genuine.Text = "79"
        RGB_R_Vintage.Text = "94"
        RGB_G_Vintage.Text = "152"
        RGB_B_Vintage.Text = "217"
        RGB_R_Strange.Text = "228"
        RGB_G_Strange.Text = "174"
        RGB_B_Strange.Text = "51"
        RGB_R_Unusual.Text = "211"
        RGB_G_Unusual.Text = "44"
        RGB_B_Unusual.Text = "230"
        RGB_R_Haunted.Text = "136"
        RGB_G_Haunted.Text = "71"
        RGB_B_Haunted.Text = "255"
        RGB_R_Collector.Text = "161"
        RGB_G_Collector.Text = "39"
        RGB_B_Collector.Text = "39"
        RGB_R_Community.Text = "173"
        RGB_G_Community.Text = "229"
        RGB_B_Community.Text = "92"
        RGB_R_Unique.Text = "178"
        RGB_G_Unique.Text = "178"
        RGB_B_Unique.Text = "178"
        'Attributes
        RGB_R_Level.Text = "128"
        RGB_G_Level.Text = "128"
        RGB_B_Level.Text = "128"
        RGB_R_Positive.Text = "128"
        RGB_G_Positive.Text = "255"
        RGB_B_Positive.Text = "128"
        RGB_R_Neutral.Text = "192"
        RGB_G_Neutral.Text = "192"
        RGB_B_Neutral.Text = "192"
        RGB_R_Negative.Text = "255"
        RGB_G_Negative.Text = "128"
        RGB_B_Negative.Text = "128"
        RGB_R_SetN.Text = "128"
        RGB_G_SetN.Text = "225"
        RGB_B_SetN.Text = "255"
        RGB_R_Set.Text = "0"
        RGB_G_Set.Text = "128"
        RGB_B_Set.Text = "255"
        RGB_R_Use.Text = "255"
        RGB_G_Use.Text = "255"
        RGB_B_Use.Text = "128"
        RGB_R_Craft.Text = "192"
        RGB_G_Craft.Text = "192"
        RGB_B_Craft.Text = "192"
    End Sub

    'Vertical tabs
    Private Sub TabControl1_Draw(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Tab.DrawItem
        Dim g As Graphics
        Dim sText As String
        Dim iX As Integer
        Dim iY As Integer
        Dim sizeText As SizeF
        Dim ctlTab As TabControl
        ctlTab = CType(sender, TabControl)
        g = e.Graphics
        sText = ctlTab.TabPages(e.Index).Text
        sizeText = g.MeasureString(sText, ctlTab.Font)
        iX = e.Bounds.Left + 6
        iY = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2
        g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY)
    End Sub

    Private Sub QualityTab_Enter() Handles QualityTab.Enter
        TypeLabel.Text = "Qualities"
        SaveButton2.Hide()
        SaveButton.Show()
    End Sub

    Private Sub AttributesTab_Enter() Handles AttributesTab.Enter
        TypeLabel.Text = "Attributtes"
        SaveButton.Hide()
        SaveButton2.Show()
    End Sub
End Class