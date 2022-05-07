Public Class FormOptions
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
                'Options.enregistrer(CInt(textBoxTaille.Text), CInt(labelTemps.Text), CInt(textBoxMines.Text), CInt(checkBoxMinuteur.Checked), checkBoxPause.Checked)
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
            'Options.enregistrer(CInt(textBoxTaille.Text), CInt(labelTemps.Text), CInt(textBoxMines.Text), CInt(checkBoxMinuteur.Checked), checkBoxPause.Checked)
            Me.Hide()
            Form1.Show()
        End If
    End Sub

    Private Function verification() As Boolean
        Dim valide As Boolean = True
        If (Trim(textBoxMines.Text) = "" Or Trim(textBoxTaille.Text) = "") Then
            valide = False
            MsgBox("Un des TextBox n'a pas été saisie.", MsgBoxStyle.OkOnly, "Erreur")
            Return valide
        End If
        If (CInt(Trim(textBoxMines.Text)) > CInt(Trim(textBoxTaille.Text)) * CInt(Trim(textBoxTaille.Text)) - 1) Then
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
End Class