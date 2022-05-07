Public Class Form1
    Private firstLoad As Boolean = True
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If firstLoad Then
            Deserialiser()
            firstLoad = False
        End If
        Me.Text = "Démineur"
        Button1.Enabled = False
        ComboBox1.Items.Clear()
        For index As Integer = 0 To Enregistrement.getMax - 1
            ComboBox1.Items.Add(getJoueur(index).prenom)
        Next
    End Sub

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Dim c As Integer() = Options.getCouleur()
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(c(0), Byte), Integer), CType(CType(c(1), Byte), Integer), CType(CType(c(2), Byte), Integer))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text.Length >= 3 Then
            Dim j As Joueur
            j.prenom = ComboBox1.Text
            Jeu.nomJoueur = ComboBox1.Text
            Enregistrement.ajouter(j)
            Jeu.labelNomJoueur.Text = "Nom du joueur : " & ComboBox1.Text
            ComboBox1.Text = ""
            Jeu.Show()
            Form1_Load(sender, e)
            Me.Hide()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim res As Integer = MsgBox("Êtes vous sûr de vouloir quitter ?", vbYesNo + vbDefaultButton2, "Confirmation")
        If res = vbYes Then
            Serialiser()
            e.Cancel = False
        ElseIf res = vbNo Then
            e.Cancel = True
        End If
    End Sub
    Sub txtNom_keypress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        If e.KeyChar >= "0" AndAlso e.KeyChar <= "9" Then
            e.KeyChar = Chr(0)
        End If
        If ComboBox1.Text.Length = 0 Then
            e.KeyChar = UCase(e.KeyChar)
        End If
        If ComboBox1.Text.Length > 0 Then
            e.KeyChar = LCase(e.KeyChar)
        End If
        If e.KeyChar = " " Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged, ComboBox1.SelectedIndexChanged
        If ComboBox1.Text.Length < 3 Then
            Button1.Enabled = False
        End If
        If ComboBox1.Text.Length >= 3 Then
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Enregistrement.getMax() = 0 Then
            MsgBox("Il n'y a aucun joueur d'enregistré.", vbOKOnly, "Scores")
        Else
            FormScore.Show()
        End If

    End Sub

    Private Sub buttonOption_Click(sender As Object, e As EventArgs) Handles buttonOption.Click
        Me.Hide()
        FormOptions.Show()
    End Sub
End Class
