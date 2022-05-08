Public Class FormOptions
    Private idTheme As Integer = 0
    Private Sub buttonQuitter_Click(sender As Object, e As EventArgs) Handles buttonQuitter.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub FormOptions_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim res As MsgBoxResult = MsgBox("Voulez-vous enregistrer ?", MsgBoxStyle.YesNoCancel)

        If (res = MsgBoxResult.No) Then
            Form1.Show()
        ElseIf (res = MsgBoxResult.Yes) Then
            Dim valide = verification()
            If (valide) Then
                Options.enregistrer({CInt(textBoxTailleX.Text), CInt(textBoxTailleY.Text)}, CInt(labelTemps.Text), CInt(textBoxMines.Text), CInt(checkBoxMinuteur.Checked), checkBoxPause.Checked, idTheme)
                Form1.Show()
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub txtNom_keypress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar = vbBack) Then Exit Sub
        If (Not IsNumeric(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub checkBoxMinuteur_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxMinuteur.CheckedChanged
        If (checkBoxMinuteur.Checked) Then
            groupBoxMinuteur.Show()
        Else
            groupBoxMinuteur.Hide()
        End If
    End Sub

    Private Sub buttonEnregistrer_Click(sender As Object, e As EventArgs) Handles buttonEnregistrer.Click
        Dim valide As Boolean = verification()

        If (valide) Then
            Options.enregistrer({CInt(textBoxTailleX.Text), CInt(textBoxTailleY.Text)}, CInt(labelTemps.Text), CInt(textBoxMines.Text), CInt(checkBoxMinuteur.Checked), checkBoxPause.Checked, idTheme)
            Me.Hide()
            Form1.Show()
        End If
    End Sub

    Private Function verification() As Boolean
        Dim valide As Boolean = True
        If (Trim(textBoxMines.Text) = "" Or Trim(textBoxTailleX.Text) = "" Or Trim(textBoxTailleY.Text) = "") Then
            valide = False
            MsgBox("Un des TextBox n'a pas été saisie.", MsgBoxStyle.OkOnly, "Erreur")
            Return valide
        Else
            If (CInt(textBoxTailleX.Text) > 20 Or CInt(textBoxTailleY.Text) > 20) Then
                valide = False
                MsgBox("La taille limite est 20x20.", MsgBoxStyle.OkOnly, "Erreur")
                Return valide
            ElseIf (CInt(textBoxTailleX.Text) < 2 Or CInt(textBoxTailleY.Text) < 2) Then
                valide = False
                MsgBox("La taille de la grille doit être supérieur à 2.", MsgBoxStyle.OkOnly, "Erreur")
                Return valide
            End If
        End If
        If (CInt(Trim(textBoxMines.Text)) > CInt(Trim(textBoxTailleX.Text)) * CInt(Trim(textBoxTailleX.Text)) - 1) Then
            valide = False
            MsgBox("Le nombre de mines doit être strictement inférieur au nombre de cases du démineur", MsgBoxStyle.OkOnly, "Erreur")
        End If
        Return valide
    End Function

    Private Sub HScrollBar1_ValueChanged(sender As Object, e As EventArgs) Handles hScrollBarMinuteur.ValueChanged
        labelTemps.Text = hScrollBarMinuteur.Value
    End Sub

    Private Sub FormOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        hScrollBarMinuteur.SmallChange = 5 'le pas
        hScrollBarMinuteur.LargeChange = 5

        hScrollBarMinuteur.Minimum = 5
        hScrollBarMinuteur.Maximum = 300
    End Sub

    Private Sub FormOptions_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Dim c As Integer() = Options.getCouleur()
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(c(0), Byte), Integer), CType(CType(c(1), Byte), Integer), CType(CType(c(2), Byte), Integer))
    End Sub

    Private Sub radioButtonBlanc_CheckedChanged(sender As Object, e As EventArgs) Handles radioButtonBlanc.CheckedChanged, radioButtonRouge.CheckedChanged, radioButtonVert.CheckedChanged, radioButtonViolet.CheckedChanged
        Dim cpt As Integer = 0
        For Each i As RadioButton In groupBoxThemes.Controls
            If (i.Checked) Then
                idTheme = cpt
            End If
            cpt += 1
        Next
    End Sub

    Private Sub buttonDefaut_Click(sender As Object, e As EventArgs) Handles buttonDefaut.Click
        radioButtonViolet.Checked = True
        textBoxTailleX.Text = 8
        textBoxMines.Text = 10
        checkBoxPause.Checked = False
        checkBoxMinuteur.Checked = True
        hScrollBarMinuteur.Value = 60
    End Sub

    Private Sub textBoxTaille_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles textBoxTailleX.KeyPress, textBoxTailleY.KeyPress
        If (e.KeyChar = vbBack) Then Exit Sub
        If (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
        If (textBoxTailleX.Text.Length > 1) Then
            e.Handled = True
        End If
    End Sub
End Class