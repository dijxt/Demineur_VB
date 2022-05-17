Public Class FormScore
    ' Lorsque l'utilisateur clique sur buttonQuitter, ferme le formScore
    Private Sub buttonQuitter_Click(sender As Object, e As EventArgs) Handles buttonQuitter.Click
        Me.Close()
    End Sub

    ' Lors du chargement, ajoute dans les listeBoc les scores des joueurs
    Private Sub FormScore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Score"
        For i As Integer = 0 To Enregistrement.getMax() - 1
            Dim j As Joueur = Enregistrement.getJoueur(i)
            ListBox1.Items.Add(j.prenom)
            ListBox2.Items.Add(j.nbCasesDecouvertes)
            ListBox3.Items.Add(j.tempsDeJeu)
            ListBox4.Items.Add(j.nbPartiesJouees)
        Next
    End Sub

    ' Synchronise toutes les listBox avec la ListBox1
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox2.SelectedIndex = ListBox1.SelectedIndex
        ListBox3.SelectedIndex = ListBox1.SelectedIndex
        ListBox4.SelectedIndex = ListBox1.SelectedIndex
    End Sub

    ' Synchronise toutes les listBox avec la ListBox2
    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
        ListBox3.SelectedIndex = ListBox2.SelectedIndex
        ListBox4.SelectedIndex = ListBox2.SelectedIndex
    End Sub

    ' Synchronise toutes les listBox avec la ListBox3
    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox3.SelectedIndex
        ListBox2.SelectedIndex = ListBox3.SelectedIndex
        ListBox4.SelectedIndex = ListBox3.SelectedIndex
    End Sub

    ' Synchronise toutes les listBox avec la ListBox4
    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox4.SelectedIndex
        ListBox2.SelectedIndex = ListBox4.SelectedIndex
        ListBox3.SelectedIndex = ListBox4.SelectedIndex
    End Sub

    ' Lors de l'activation du formulaire, change la couleur avec le thème sélectionné
    Private Sub FormScore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Dim c As Integer() = Options.getCouleur()
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(c(0), Byte), Integer), CType(CType(c(1), Byte), Integer), CType(CType(c(2), Byte), Integer))
    End Sub
End Class