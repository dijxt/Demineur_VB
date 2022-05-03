Module Options
    Private tempsAlloue As Integer = 60
    Private chronoActive As Boolean = True
    Private pause As Boolean = False

    Private tailleGrille As Integer = 8
    Private nbMines As Integer = 10

    Public Sub enregistrer(taille As Integer, temps As Integer, mines As Integer, chrono As Boolean, p As Boolean)
        Debug.Assert(temps > 0 And taille > 0 And mines > 0)
        tempsAlloue = temps
        tailleGrille = taille
        nbMines = mines
        chronoActive = chrono
        pause = p
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
End Module
