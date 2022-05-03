Module Enregistrement
    Public Structure Joueur
        Dim prenom As String
        Dim nbCasesDecouvertes As Integer
        Dim nbPartiesJouees As Integer
        Dim tempsDeJeu As Integer
        Dim meilleurScore As Integer
    End Structure

    Private tabJoueurs(0) As Joueur
    Private max As Integer = 0
    Private Const PAS_EXTENSION As Integer = 5
    Private Const TEMPS_DEFAUT As Integer = 60

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
            j.meilleurScore = TEMPS_DEFAUT
            j.nbCasesDecouvertes = 0
            j.tempsDeJeu = 0
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

    Public Sub partieFinie(joueur As String, tempsPartie As Integer, casesDecouvertes As Integer, Optional resultat As Boolean = False)
        For Each player As Joueur In tabJoueurs
            If Equals(player.prenom, joueur) Then
                player.tempsDeJeu += tempsPartie
                player.nbCasesDecouvertes += casesDecouvertes
                If player.meilleurScore > tempsPartie And resultat Then
                    player.meilleurScore = tempsPartie
                End If
            End If
        Next
    End Sub
End Module
