Public Class FormOptions
    Private idTheme As Integer = 0 ' Identifiant du thème actuel
    Private nbMinesChoisi As Integer = 0
    Private Const MAX_TAILLE_GRILLE As Integer = 15
    Private Const MIN_TAILLE_GRILLE As Integer = 4

    Private pasScrollBar As Integer = 5
    Private minScrollBar As Integer = 5
    Private maxScrollBar As Integer = 300

    ' Cache le formOption et affiche le Form1 lorsque l'utilisateur clique sur le bouton quitter
    Private Sub buttonQuitter_Click(sender As Object, e As EventArgs) Handles buttonQuitter.Click
        Me.Hide()
        Form1.Show()
    End Sub

    ' Lors de la fermeture du formulaire affiche une msgBox pour demander d'enregistrer
    Private Sub FormOptions_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim res As MsgBoxResult = MsgBox("Voulez-vous enregistrer ?", MsgBoxStyle.YesNoCancel)

        If (res = MsgBoxResult.No) Then
            Form1.Show()
        ElseIf (res = MsgBoxResult.Yes) Then
            Dim valide = verification()
            If (valide) Then
                Dim tab As Integer()
                ReDim tab(textBoxMines.Text)
                Dim idx As Integer = 0
                For i As Integer = 0 To groupBoxPosMines.Controls.Count - 1
                    If (groupBoxPosMines.Controls(i).Text = "X") Then
                        tab(idx) = i
                        idx += 1
                    End If
                Next

                Options.enregistrer({CInt(textBoxTailleX.Text), CInt(textBoxTailleY.Text)}, CInt(labelTemps.Text), CInt(textBoxMines.Text), CInt(checkBoxMinuteur.Checked), checkBoxPause.Checked, idTheme, checkBoxPosMines.Checked, tab)
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
        If (Not IsNumeric(e.KeyChar) Or e.KeyChar = "-") Then
            e.Handled = True
        End If
    End Sub

    ' Affiche ou cache le groupBoxMinuteur, lorsque l'utilisateur coche ou décoche checkBoxMinuteur
    Private Sub checkBoxMinuteur_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxMinuteur.CheckedChanged
        If (checkBoxMinuteur.Checked) Then
            groupBoxMinuteur.Show()
            checkBoxPause.Enabled = True
        Else
            groupBoxMinuteur.Hide()
            checkBoxPause.Checked = False
            checkBoxPause.Enabled = False
        End If
    End Sub

    ' Lors du clique sur le buttonEnregistrer, vérifie si les valeurs sont cohérentes puis
    ' enregistre les options dans le module
    Private Sub buttonEnregistrer_Click(sender As Object, e As EventArgs) Handles buttonEnregistrer.Click
        Dim valide As Boolean = verification()

        If (valide) Then
            Dim tab As Integer()
            ReDim tab(textBoxMines.Text)
            Dim idx As Integer = 0
            For i As Integer = 0 To groupBoxPosMines.Controls.Count - 1
                If (groupBoxPosMines.Controls(i).Text = "X") Then
                    tab(idx) = i
                    idx += 1
                End If
            Next

            Options.enregistrer({CInt(textBoxTailleX.Text), CInt(textBoxTailleY.Text)}, CInt(labelTemps.Text), CInt(textBoxMines.Text), CInt(checkBoxMinuteur.Checked), checkBoxPause.Checked, idTheme, checkBoxPosMines.Checked, tab)
            Me.Hide()
            Form1.Show()
        End If
    End Sub

    ' Verifie les valeurs dans les textBox, les checkbox pour avoir des valeurs cohérentes
    ' Retourne Vrai si la vérification s'est bien passé
    ' Retourne Faux si une valeur est incohérente
    Private Function verification() As Boolean
        Dim valide As Boolean = True
        If (Trim(textBoxMines.Text) = "" Or Trim(textBoxTailleX.Text) = "" Or Trim(textBoxTailleY.Text) = "") Then
            valide = False
            MsgBox("Un des TextBox n'a pas été saisie.", MsgBoxStyle.OkOnly, "Erreur")
            Return valide
        Else
            If ((CInt(textBoxTailleX.Text) > MAX_TAILLE_GRILLE Or CInt(textBoxTailleY.Text) > MAX_TAILLE_GRILLE) Or (CInt(textBoxTailleX.Text) < MIN_TAILLE_GRILLE Or CInt(textBoxTailleY.Text) < MIN_TAILLE_GRILLE)) Then
                valide = False
                MsgBox("La taille limite est 15x15.", MsgBoxStyle.OkOnly, "Erreur")
                Return valide
            End If
        End If

        If (CInt(Trim(textBoxMines.Text)) > CInt(Trim(textBoxTailleX.Text)) * CInt(Trim(textBoxTailleX.Text)) - 1) Then
            valide = False
            MsgBox("Le nombre de mines doit être strictement inférieur au nombre de cases du démineur", MsgBoxStyle.OkOnly, "Erreur")
        ElseIf (CInt(textBoxMines.Text) < 1) Then
            valide = False
            MsgBox("Il faut qu'il y ait au moins une mine dans le démineur", MsgBoxStyle.OkOnly, "Erreur")
        End If

        If (checkBoxPosMines.Checked) Then
            If (nbMinesChoisi <> textBoxMines.Text) Then
                MsgBox("Vous avez posé " & nbMinesChoisi & " mines au lieu de " & textBoxMines.Text & ".", MsgBoxStyle.OkOnly, "Erreur")
                valide = False
            End If
        End If

        Return valide
    End Function

    Private Sub HScrollBar1_ValueChanged(sender As Object, e As EventArgs) Handles hScrollBarMinuteur.ValueChanged
        labelTemps.Text = hScrollBarMinuteur.Value
    End Sub

    ' Lors du chargement, pose le min et max à 5 et 300 sur la scrollBar et le déplacement est posé à 5
    Private Sub FormOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Options"
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        hScrollBarMinuteur.SmallChange = pasScrollBar 'le pas
        hScrollBarMinuteur.LargeChange = pasScrollBar

        hScrollBarMinuteur.Minimum = minScrollBar
        hScrollBarMinuteur.Maximum = maxScrollBar
    End Sub

    ' Lorsque le form s'active, change la couleur du thème avec celui qui a été sélectionnée
    Private Sub FormOptions_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Dim c As Integer() = Options.getCouleur()
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(c(0), Byte), Integer), CType(CType(c(1), Byte), Integer), CType(CType(c(2), Byte), Integer))
    End Sub

    ' Change la valeur de l'identifiant du thème lors du clique sur les radioButton
    Private Sub radioButtonBlanc_CheckedChanged(sender As Object, e As EventArgs) Handles radioButtonBlanc.CheckedChanged, radioButtonRouge.CheckedChanged, radioButtonVert.CheckedChanged, radioButtonViolet.CheckedChanged
        Dim cpt As Integer = 0
        For Each i As RadioButton In groupBoxThemes.Controls
            If (i.Checked) Then
                idTheme = cpt
            End If
            cpt += 1
        Next
    End Sub

    ' Remet les valeurs des options au démarrage lors du clique sur le buttonDefaut
    Private Sub buttonDefaut_Click(sender As Object, e As EventArgs) Handles buttonDefaut.Click
        radioButtonViolet.Checked = True
        textBoxTailleX.Text = 8
        textBoxTailleY.Text = 8
        textBoxMines.Text = 10
        checkBoxPause.Checked = False
        checkBoxMinuteur.Checked = True
        checkBoxPosMines.Checked = False
        hScrollBarMinuteur.Value = 60
    End Sub

    ' Lorsque l'utilisateur écrit dans les textBox textBoxTailleX, textBoxTailleY, empêche l'écriture de lettres et
    ' des caractères de plus de longueur 2
    Private Sub textBoxTaille_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles textBoxTailleX.KeyPress, textBoxTailleY.KeyPress
        If (e.KeyChar = vbBack) Then Exit Sub
        If (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
        If (sender.Text.Length > 1) Then
            e.Handled = True
        End If
    End Sub

    ' Lorsque l'utilisateur écrit dans les textBox textBoxTailleX, textBoxTailleY, empêche l'écriture de lettres et
    ' des caractères de plus de longueur 2
    Private Sub textBoxMines_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles textBoxMines.KeyPress
        If (e.KeyChar = vbBack) Then Exit Sub
        If (Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
        If (sender.Text.Length > 2) Then
            e.Handled = True
        End If
    End Sub

    ' Lorsque la checkBoxPosMines est cochée ou non, change la visibilité de groupBoxPosMines
    Private Sub checkBoxPosMines_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxPosMines.CheckedChanged
        groupBoxPosMines.Visible = Not groupBoxPosMines.Visible
    End Sub

    ' Quand groupBoxPosMines change de visibilité, affiche ou supprime les checkBox pour choisir les positions des mines
    Private Sub groupBoxPosMines_Enter(sender As Object, e As EventArgs) Handles groupBoxPosMines.VisibleChanged
        If (groupBoxPosMines.Visible) Then
            Dim valide As Boolean = True
            If (CInt(Trim(textBoxMines.Text)) > CInt(Trim(textBoxTailleX.Text)) * CInt(Trim(textBoxTailleY.Text)) - 1) Then
                valide = False
                MsgBox("Le nombre de mines doit être strictement inférieur au nombre de cases du démineur", MsgBoxStyle.OkOnly, "Erreur")
            ElseIf (CInt(textBoxMines.Text) < 1) Then
                valide = False
                MsgBox("Il faut qu'il y ait au moins une mine dans le démineur", MsgBoxStyle.OkOnly, "Erreur")
            End If

            groupBoxPosMines.Visible = valide

            If (valide) Then
                Dim tailleButton As Integer = 17
                Dim posX As Integer = 10
                Dim posY As Integer = 20
                Dim lignes As Integer = -1

                For i As Integer = 0 To CInt(textBoxTailleX.Text) * CInt(textBoxTailleY.Text) - 1
                    If (i Mod CInt(textBoxTailleX.Text) = 0) Then
                        lignes += 1
                    End If
                    groupBoxPosMines.Controls.Add(New System.Windows.Forms.Button())
                    groupBoxPosMines.Controls(i).Location = New System.Drawing.Point(posX + (i Mod CInt(textBoxTailleX.Text)) * tailleButton, posY + lignes * tailleButton)
                    Console.WriteLine(i Mod CInt(textBoxTailleX.Text) * tailleButton & " " & posY + lignes * tailleButton)
                    groupBoxPosMines.Controls(i).Size = New System.Drawing.Size(tailleButton, tailleButton)
                    groupBoxPosMines.Controls(i).BackColor = Color.LightGray
                    groupBoxPosMines.Controls(i).Visible = True
                Next

                For Each ctrl As Control In groupBoxPosMines.Controls
                    AddHandler ctrl.MouseDown, AddressOf checkBoxPosMines_Click
                Next

                textBoxTailleX.Enabled = False
                textBoxTailleY.Enabled = False
            End If
        Else
            groupBoxPosMines.Controls.Clear()
            nbMinesChoisi = 0
            textBoxTailleX.Enabled = True
            textBoxTailleY.Enabled = True
        End If
    End Sub

    Private Sub checkBoxPosMines_Click(sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (sender.text = "") Then
            If (nbMinesChoisi >= textBoxMines.Text) Then
                MsgBox("Vous avez déjà posé toutes les mines.")
                sender.text = ""
            Else
                nbMinesChoisi += 1
                sender.text = "X"
            End If
        Else
            sender.text = ""
            nbMinesChoisi -= 1
        End If
    End Sub
End Class