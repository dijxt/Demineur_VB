Public Class FormScore
    Private listJoueurs(Enregistrement.getMax() - 1) As Joueur
    Private detail As Boolean

    ' Lorsque l'utilisateur clique sur buttonQuitter, ferme le formScore
    Private Sub buttonQuitter_Click(sender As Object, e As EventArgs) Handles buttonQuitter.Click
        Me.Close()
    End Sub

    ' Lors du chargement, ajoute dans les listeBoc les scores des joueurs
    Private Sub FormScore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Score"
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        detail = False
        Me.Size = New Drawing.Size(465, 683)

        For i As Integer = 0 To Enregistrement.getMax() - 1
            Dim j As Joueur = Enregistrement.getJoueur(i)
            listJoueurs(i) = j
        Next


        Dim tmp As Joueur

        For i As Integer = 0 To listJoueurs.Length - 1
            For j As Integer = 0 To listJoueurs.Length - 2
                If listJoueurs(j).meilleurScore > listJoueurs(j + 1).meilleurScore Then
                    tmp = listJoueurs(j)
                    listJoueurs(j) = listJoueurs(j + 1)
                    listJoueurs(j + 1) = tmp
                ElseIf listJoueurs(j).meilleurScore = listJoueurs(j + 1).meilleurScore Then
                    If listJoueurs(j).tempsMeilleurScore < listJoueurs(j + 1).tempsMeilleurScore Then
                        tmp = listJoueurs(j)
                        listJoueurs(j) = listJoueurs(j + 1)
                        listJoueurs(j + 1) = tmp
                    End If
                End If
            Next
        Next

        Array.Reverse(listJoueurs)

        For Each j As Joueur In listJoueurs
            ListBox1.Items.Add(j.prenom)
            ListBox2.Items.Add(j.meilleurScore)
            ListBox3.Items.Add(j.tempsMeilleurScore)
            ListBox4.Items.Add(j.nbCasesDecouvertesTotal)
            ListBox5.Items.Add(j.nbPartiesJouees)
            ListBox6.Items.Add(j.tempsDeJeu)

            ComboBox1.Items.Add(j.prenom)
        Next

    End Sub

    ' Synchronise toutes les listBox avec la ListBox1
    Private Sub ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged, ListBox2.SelectedIndexChanged, ListBox3.SelectedIndexChanged, ListBox4.SelectedIndexChanged, ListBox5.SelectedIndexChanged, ListBox6.SelectedIndexChanged
        ListBox1.SelectedIndex = sender.SelectedIndex
        ListBox2.SelectedIndex = sender.SelectedIndex
        ListBox3.SelectedIndex = sender.SelectedIndex
        ListBox4.SelectedIndex = sender.SelectedIndex
        ListBox5.SelectedIndex = sender.SelectedIndex
        ListBox6.SelectedIndex = sender.SelectedIndex

        ComboBox1.Text = ListBox1.SelectedItem
    End Sub


    ' Lors de l'activation du formulaire, change la couleur avec le thème sélectionné
    Private Sub FormScore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Dim c As Integer() = Options.getCouleur()
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(c(0), Byte), Integer), CType(CType(c(1), Byte), Integer), CType(CType(c(2), Byte), Integer))
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text.Length < 3 Then
            Valider.Enabled = False
        End If
        If ComboBox1.Text.Length >= 3 Then
            Valider.Enabled = True
        End If
    End Sub

    Private Sub Valider_Click(sender As Object, e As EventArgs) Handles Valider.Click

        If ListBox1.Items.Contains(ComboBox1.Text) Then
            ListBox1.SelectedIndex = ListBox1.Items.IndexOf(ComboBox1.Text)
        Else
            MsgBox("Joueur inconnu.", vbOKOnly, "Erreur")
        End If
    End Sub

    Private Sub Trier_Click(sender As Object, e As EventArgs) Handles Trier.Click
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()

        Array.Reverse(listJoueurs)

        For Each j As Joueur In listJoueurs
            ListBox1.Items.Add(j.prenom)
            ListBox2.Items.Add(j.meilleurScore)
            ListBox3.Items.Add(j.tempsMeilleurScore)
            ListBox4.Items.Add(j.nbCasesDecouvertesTotal)
            ListBox5.Items.Add(j.nbPartiesJouees)
            ListBox6.Items.Add(j.tempsDeJeu)
        Next
    End Sub

    Private Sub Details_Click(sender As Object, e As EventArgs) Handles Details.Click
        If detail Then
            Me.Size = New Drawing.Size(465, 683)
        Else
            Size = New Drawing.Size(900, 683)
        End If
        detail = Not detail
    End Sub

End Class