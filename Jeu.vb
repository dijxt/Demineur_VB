Public Class Jeu
    Private tempsAlloue As Integer ' Le temps alloué pour le jeu
    Private tempsRestant As Integer ' Le temps restant calculé à partir du temps alloué
    Private pause As Boolean ' Présence ou non du bouton pause

    Private nbMineMAX As Integer = 10 ' Nombre max de mines
    Private score As Integer = 0 ' Le nombre de cases démasquées

    Private taille As Integer() = {8, 8} ' La taille de la grille, par défaut à 8x8

    Public nomJoueur As String ' Le nom du joueur
    Private minesRestantes As Integer = 0 ' le nombre de mines - le nombre de cases que le joueur a marqué 
    Private premiereCase As Boolean = True ' Lorsque le joueur démasque la première case

    'A chaque tick d'intervalle 1000ms, chrono_Tick est appelé
    Private Sub chrono_Tick(sender As Object, e As EventArgs) Handles chrono.Tick
        tempsRestant -= 1
        labelTempsRestant.Text = tempsRestant
        If (tempsRestant <= 0) Then
            chrono.Stop()
            MsgBox("Tout le temps s'est ecoulé", vbOKOnly, "Fin de la partie")
            partieFinie(nomJoueur, tempsAlloue - tempsRestant, score)
            Me.Close()
        End If
    End Sub

    ' Lors de l'activation du formulaire, change la couleur avec le thème sélectionné
    Private Sub FormJeu_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Dim c As Integer() = Options.getCouleur()
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(c(0), Byte), Integer), CType(CType(c(1), Byte), Integer), CType(CType(c(2), Byte), Integer))
    End Sub

    ' Lors de l'affichage du formulaire, créer dans un panel toutes les cases du jeu et met en place
    ' le chronomètre si il doit être présent
    Private Sub Jeu_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TableauCases.creerDemineur(Panel1)
        taille = Options.getTaille()
        nbMineMAX = Options.getMines()
        pause = False
        minesRestantes = nbMineMAX
        premiereCase = True

        Dim tailleBouton As Integer = 24
        Dim posPremiereCase As Integer() = {31, 19}
        Dim ecart As Integer = 24 + (taille.Max / 8)
        Dim ligne As Integer = -1
        For i As Integer = 0 To ((taille(0) * taille(1)) - 1)
            If (i Mod taille(0) = 0) Then
                ligne += 1
            End If
            Me.Panel1.Controls.Add(New System.Windows.Forms.Button())
            Panel1.Controls(i).Location = New System.Drawing.Point(posPremiereCase(0) + ecart * (i Mod taille(0)),
                posPremiereCase(1) + ecart * ligne)
            Panel1.Controls(i).Size = New System.Drawing.Size(tailleBouton, tailleBouton)
            Panel1.Controls(i).Name = "Button" & i
            Panel1.Controls(i).BackColor = Color.LightGray
            Panel1.Controls(i).TabIndex = 5 + i

        Next

        For Each ctrl As Control In Panel1.Controls
            AddHandler ctrl.MouseDown, AddressOf Button_Click
        Next

        If (taille(0) > 8 Or taille(1) > 8) Then
            'Me.Panel1.Size = New System.Drawing.Size(277 + agrandissement, 273 + agrandissement)
            'Me.ClientSize = New System.Drawing.Size(499 + agrandissement, 530 + agrandissement)
            Me.labelNomJoueur.Location = New System.Drawing.Point(19, 63 + Panel1.Height + Panel1.Location.Y)
            Me.labelMinesRestantes.Location = New System.Drawing.Point(19, 22 + Panel1.Height + Panel1.Location.Y)
            Me.buttonPause.Location = New System.Drawing.Point(Panel1.Height + Panel1.Location.X - 100, 40 + Panel1.Height + Panel1.Location.Y)
            Me.buttonPremierCoup.Location = New System.Drawing.Point(Panel1.Height + Panel1.Location.X - 100, Panel1.Height + Panel1.Location.Y + 15)
        End If

        If (Options.getChrono()) Then
            tempsAlloue = Options.getTemps()
            tempsRestant = tempsAlloue
            labelTempsRestant.Text = tempsRestant
            chrono.Interval = 1000
        Else
            labelTempsRestant.Hide()
        End If

        buttonPause.Visible = Options.getPause()
        labelMinesRestantes.Text = "Potentielles mines restantes : " & minesRestantes
    End Sub

    ' Lorsque l'utilisateur clique sur buttonQuitter, met en pause le chronomètre
    ' affiche une MsgBox et enregistre le score si il quitte
    Private Sub buttonQuitter_Click(sender As Object, e As EventArgs) Handles buttonQuitter.Click
        chrono.Stop()
        Dim res As MsgBoxResult = MsgBox("Êtes vous sûr de vouloir arrêter ?", vbYesNo + vbDefaultButton2, "Confirmation")

        If (res = MsgBoxResult.Yes) Then
            Enregistrement.partieFinie(nomJoueur, tempsAlloue - tempsRestant, score)
            Me.Close()
        Else
            chrono.Start()
        End If
    End Sub

    ' Lors de la fermeture du form, affiche le form1
    Private Sub FormJeu_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Form1.ComboBox1.Text = nomJoueur
        Form1.Show()
    End Sub

    ' Si le jeu est terminé et gagné, affiche une msgBox
    Private Sub finJeu()
        MsgBox("Félicitations! Le nombre de cases révélées : " & score & ", en " & tempsAlloue - tempsRestant & " secondes.", MsgBoxStyle.OkOnly, "Score")
    End Sub

    ' Lors du clique sur une des cases, clique gauche démasque la case sur le démineur et dans le module
    ' Clique droit, marque la case
    Private Sub Button_Click(sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (premiereCase) Then
            premiereCase = False
            buttonPremierCoup.Enabled = False
            If (Options.getChrono()) Then
                chrono.Start()
            End If
        End If

        If (e.Button = Windows.Forms.MouseButtons.Right) Then
            marquerCase(Panel1.Controls.IndexOf(sender), Panel1)
            Dim c As CaseDemineur = TableauCases.getCase(Panel1.Controls.IndexOf(sender))
            If (c.estMarquee) Then
                If (minesRestantes > 0) Then
                    minesRestantes -= 1
                End If
            Else
                If (TableauCases.toutesCasesMarquees() < nbMineMAX) Then
                    minesRestantes += 1
                End If
            End If
            labelMinesRestantes.Text = "Potentielles mines restantes : " & minesRestantes
        Else
            Dim c As CaseDemineur = TableauCases.getCase(Panel1.Controls.IndexOf(sender))
            demasquerCase(Panel1.Controls.IndexOf(sender), Panel1)
            If estGagneePartie() Then
                chrono.Stop()
                partieFinie(nomJoueur, tempsAlloue - tempsRestant, score, True)
                finJeu()
                Me.Close()
            ElseIf estPartiePerdue() Then
                sender.BackgroundImage = ResizeImage(Image.FromFile("..\..\images\mine.png"), 24)
                sender.BackColor = Color.Red
                For i As Integer = 0 To taille(0) * taille(1) - 1
                    If TableauCases.getCase(i).estMine And Not i = Panel1.Controls.IndexOf(sender) Then
                        Panel1.Controls(i).BackgroundImage = ResizeImage(Image.FromFile("..\..\images\mine.png"), 24)
                    End If
                Next
                chrono.Stop()
                MsgBox("Vous avez perdu.", vbOKOnly, "Fin de la partie")
                partieFinie(nomJoueur, tempsAlloue - tempsRestant, score)
                Me.Close()
            End If
        End If
    End Sub

    ' Lors du clique sur buttonPause, met en pause le chronomètre, et désactive les cases pour pas les démasquer
    Private Sub buttonPause_Click(sender As Object, e As EventArgs) Handles buttonPause.Click
        Panel1.Enabled = Not Panel1.Enabled

        If (pause) Then
            buttonPause.Text = "Pause"
            chrono.Start()
        Else
            buttonPause.Text = "Reprendre"
            chrono.Stop()
        End If

        pause = Not pause
    End Sub

    Public Function ResizeImage(ByVal InputImage As Image, x As Integer) As Image
        Return New Bitmap(InputImage, New Size(x, x))
    End Function

    Private Sub Jeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Démineur"
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
    End Sub

    Private Sub buttonPremierCoup_Click(sender As Object, e As EventArgs) Handles buttonPremierCoup.Click
        buttonPremierCoup.Enabled = False
        premierCoup(Panel1)
        If (Options.getChrono()) Then
            chrono.Start()
        End If
    End Sub

    Public Sub scoreInc()
        score += 1
    End Sub
End Class