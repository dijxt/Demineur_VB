Public Class FormScore
    Private Sub buttonQuitter_Click(sender As Object, e As EventArgs) Handles buttonQuitter.Click
        Me.Close()
    End Sub

    Private Sub FormScore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i As Integer = 0 To Enregistrement.getMax() - 1
            Dim j As Joueur = Enregistrement.getJoueur(i)
            ListBox1.Items.Add(j.prenom)
            ListBox2.Items.Add(j.nbCasesDecouvertes)
            ListBox3.Items.Add(j.tempsDeJeu)
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox2.SelectedIndex = ListBox1.SelectedIndex
        ListBox3.SelectedIndex = ListBox1.SelectedIndex
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
        ListBox3.SelectedIndex = ListBox2.SelectedIndex
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox3.SelectedIndex
        ListBox2.SelectedIndex = ListBox3.SelectedIndex
    End Sub

    Private Sub FormScore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Dim c As Integer() = Options.getCouleur()
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(c(0), Byte), Integer), CType(CType(c(1), Byte), Integer), CType(CType(c(2), Byte), Integer))
    End Sub
End Class