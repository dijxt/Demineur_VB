Public Class Jeu
    Private tempsAlloue As Integer = 60
    Private tempsRestant As Integer = tempsAlloue

    Private nbMineMAX As Integer = 10
    Private score As Integer = 0

    Private taille As Integer = 8

    'A chaque tick d'intervalle 1000ms, chrono_Tick est appelé
    Private Sub chrono_Tick(sender As Object, e As EventArgs) Handles chrono.Tick
        tempsRestant -= 1
        labelTempsRestant.Text = tempsRestant
        If (tempsRestant <= 0) Then
            chrono.Stop()
            MsgBox("Tout le temps s'est ecoulé", vbOKOnly, "Fin de la partie")
            Me.Close()
        End If
    End Sub

    Private Sub Jeu_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        TableauCases.creerDemineur(Panel1)
    End Sub

    Private Sub Jeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tailleTableau As Integer = 8
        Dim tailleBouton As Integer = 22
        Dim posPremiereCase As Integer() = {31, 19}
        Dim ecart As Integer = 28
        Dim ligne As Integer = -1
        For i As Integer = 0 To ((tailleTableau * tailleTableau) - 1)
            If (i Mod tailleTableau = 0) Then
                ligne += 1
            End If
            Me.Panel1.Controls.Add(New System.Windows.Forms.Button())
            Panel1.Controls(i).Location = New System.Drawing.Point(posPremiereCase(0) + ecart * (i Mod tailleTableau),
                posPremiereCase(1) + ecart * ligne)
            Panel1.Controls(i).Size = New System.Drawing.Size(tailleBouton, tailleBouton)
            Panel1.Controls(i).Name = "Button" & i
            Panel1.Controls(i).BackColor = Color.LightGray
            Panel1.Controls(i).TabIndex = 5 + i
        Next

        For Each ctrl As Control In Panel1.Controls
            AddHandler ctrl.MouseDown, AddressOf Button_Click
        Next

        chrono.Interval = 1000
        chrono.Start()
    End Sub

    Private Sub buttonQuitter_Click(sender As Object, e As EventArgs) Handles buttonQuitter.Click
        chrono.Stop()
        Dim res As MsgBoxResult = MsgBox("Êtes vous sûr de vouloir arrêter ?", vbYesNo + vbDefaultButton2, "Confirmation")

        If (res = MsgBoxResult.Yes) Then
            Me.Close()
        Else
            chrono.Start()
        End If
    End Sub

    Private Sub FormJeu_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Form1.Show()
    End Sub

    Private Sub finJeu()
        MsgBox("Félicitations! Le nombre de cases révélées : " & score & ", en " & tempsAlloue - tempsRestant & " secondes.", MsgBoxStyle.OkOnly, "Score")
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        labelNomJoueur.Text = Panel1.Controls.IndexOf(sender)
        Dim c As CaseDemineur = TableauCases.getCase(Panel1.Controls.IndexOf(sender))
        demarquerCase(Panel1.Controls.IndexOf(sender), Panel1)
        If estGagneePartie() Then
            chrono.Stop()
            finJeu()
        ElseIf estPartiePerdue() Then
            chrono.Stop()
            MsgBox("Vous avez perdu.", vbOKOnly, "Fin de la partie")
            Me.Close()
        End If
    End Sub
End Class