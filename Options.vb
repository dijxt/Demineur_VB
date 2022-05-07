Module Options
    Private tempsAlloue As Integer = 60
    Private chronoActive As Boolean = True
    Private pause As Boolean = False

    Private tailleGrille As Integer = 8
    Private nbMines As Integer = 10

    Private couleur As Integer() = {192, 192, 255}

    Public Sub enregistrer(taille As Integer, temps As Integer, mines As Integer, chrono As Boolean, p As Boolean, theme As Integer)
        Dim couleurs As Integer()()
        ReDim couleurs(4)
        couleurs(0) = {192, 255, 192}
        couleurs(1) = {255, 255, 255}
        couleurs(2) = {255, 192, 192}
        couleurs(3) = {192, 192, 255}

        Debug.Assert(temps > 0 And taille > 0 And mines > 0)
        tempsAlloue = temps
        tailleGrille = taille
        nbMines = mines
        chronoActive = chrono
        pause = p

        couleur = couleurs(theme)
    End Sub

    Public Function getTemps() As Integer
        Return tempsAlloue
    End Function

    Public Function getChrono() As Boolean
        Return chronoActive
    End Function

    Public Function getTaille() As Integer
        Return tailleGrille
    End Function

    Public Function getMines() As Integer
        Return nbMines
    End Function

    Public Function getPause() As Boolean
        Return pause
    End Function

    Public Function getCouleur() As Integer()
        Return couleur
    End Function
End Module