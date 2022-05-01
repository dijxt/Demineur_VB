Module Enregistrement
    Public Structure Joueur
        Dim prenom As String
        Dim nbCasesDecouvertes As Integer
        Dim nbPartiesJouees As Integer
        Dim tempsDeJeu As Integer
    End Structure

    Private tabJoueurs(0) As Joueur
    Private max As Integer = 0
    Private Const PAS_EXTENSION As Integer = 5

    Public Sub ajouter(j As Joueur)
        Dim joueurExiste As Boolean = False
        For Each player As Joueur In tabJoueurs
            If Equals(player.prenom, j.prenom) Then
                joueurExiste = True
                player.nbPartiesJouees += 1
            End If
        Next

        If Not joueurExiste Then
            If (max > UBound(tabJoueurs)) Then
                ReDim Preserve tabJoueurs(max + PAS_EXTENSION)
            End If
            j.nbPartiesJouees = 1
            tabJoueurs(max) = j
            max += 1
        End If

    End Sub

    Public Function getJoueur(i As Integer) As Joueur
        Debug.Assert(i >= 0 And i < max)
        Return tabJoueurs(i)
    End Function

    Public Function getMax() As Integer
        Return max
    End Function

    Public Sub partieFinie(joueur As String, tempsPartie As Integer, casesDecouvertes As Integer)
        For Each player As Joueur In tabJoueurs
            If Equals(player.prenom, joueur) Then
                player.tempsDeJeu += tempsPartie
                player.nbCasesDecouvertes = casesDecouvertes
            End If
        Next
    End Sub
End Module
