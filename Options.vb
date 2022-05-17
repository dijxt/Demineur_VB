Module Options
    Private tempsAlloue As Integer = 60 ' Le temps auquel le joueur aura pour jouer
    Private chronoActive As Boolean = True ' Le chrono si il est actif ou non
    Private pause As Boolean = False ' L'option pause pour arrêter le chronomètre

    Private tailleGrille As Integer() = {8, 8} ' La taille de la grille
    Private nbMines As Integer = 10 ' Le nombre de mines dans le jeu

    Private couleur As Integer() = {192, 192, 255} ' La couleur du thème actuelle

    Private choisirPosMines As Boolean = False ' Choix des mines ou non
    Private posMines As Integer() = {} ' Position de toutes les mines choisies

    ' Enregistre dans ce module toutes les valeurs des options
    Public Sub enregistrer(taille As Integer(), temps As Integer, mines As Integer, chrono As Boolean, p As Boolean, theme As Integer, choixPosMines As Boolean, p_posMines As Integer())
        Dim couleurs As Integer()()
        ReDim couleurs(4)
        couleurs(0) = {192, 255, 192}
        couleurs(1) = {255, 255, 255}
        couleurs(2) = {255, 192, 192}
        couleurs(3) = {192, 192, 255}

        Debug.Assert(temps > 0 And taille(0) > 0 And taille(1) > 0 And mines > 0)
        tempsAlloue = temps
        tailleGrille = taille
        nbMines = mines
        chronoActive = chrono
        pause = p

        couleur = couleurs(theme)

        choisirPosMines = choixPosMines
        ReDim posMines(p_posMines.Length)
        posMines = p_posMines
    End Sub

    ' Retourn le temps alloué
    Public Function getTemps() As Integer
        Return tempsAlloue
    End Function

    ' Retourne le chronomètre
    Public Function getChrono() As Boolean
        Return chronoActive
    End Function

    ' Retourne la taille de la grille dans un tableau en 2d
    Public Function getTaille() As Integer()
        Return tailleGrille
    End Function

    ' Retourne le nombre de mines
    Public Function getMines() As Integer
        Return nbMines
    End Function

    ' Retourne l'option pause
    Public Function getPause() As Boolean
        Return pause
    End Function

    ' Retourne la couleur dans un tableau
    Public Function getCouleur() As Integer()
        Return couleur
    End Function

    Public Function getChoixPosMines() As Boolean
        Return choisirPosMines
    End Function

    Public Function getTabMines() As Integer()
        Return posMines
    End Function
End Module