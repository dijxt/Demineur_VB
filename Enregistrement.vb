Imports System.IO
Imports Newtonsoft.Json
Module Enregistrement
    Public Structure Joueur
        Dim prenom As String                ' Prénom du joueur
        Dim nbCasesDecouvertes As Integer   ' Nombre total de cases découvertes
        Dim nbPartiesJouees As Integer      ' Nombre total de parties jouées
        Dim tempsDeJeu As Integer           ' Temps total de jeu
    End Structure

    Private tabJoueurs(0) As Joueur ' Tableau de tous les joueurs enregistrés
    Private max As Integer = 0 ' Indice du dernier joueur dans le tableau
    Private Const PAS_EXTENSION As Integer = 5 ' Le pas d'extension
    Private Const TEMPS_DEFAUT As Integer = 60 ' Le temps par défaut alloué

    ' Ajoute un joueur dans le tableau
    Public Sub ajouter(j As Joueur)
        Dim joueurExiste As Boolean = False
        Dim pos As Integer = 0
        For Each player As Joueur In tabJoueurs
            If Equals(player.prenom, j.prenom) Then
                joueurExiste = True
                tabJoueurs(pos).nbPartiesJouees += 1
            End If
            pos += 1
        Next

        If Not joueurExiste Then
            If (max > UBound(tabJoueurs)) Then
                ReDim Preserve tabJoueurs(max + PAS_EXTENSION)
            End If
            j.nbPartiesJouees = 1
            j.nbCasesDecouvertes = 0
            j.tempsDeJeu = 0
            tabJoueurs(max) = j
            max += 1
        End If

    End Sub

    ' Retourne le joueur à l'indice i dans le tableau de joueurs
    Public Function getJoueur(i As Integer) As Joueur
        Debug.Assert(i >= 0 And i < max)
        Return tabJoueurs(i)
    End Function

    ' Retourne le dernier indice du tableau
    Public Function getMax() As Integer
        Return max
    End Function

    ' Augmente le temps et le nombre de cases à partir d'un prénom
    Public Sub partieFinie(joueur As String, tempsPartie As Integer, casesDecouvertes As Integer, Optional resultat As Boolean = False)
        For i As Integer = 0 To max - 1
            If tabJoueurs(i).prenom = joueur Then
                tabJoueurs(i).tempsDeJeu += tempsPartie
                tabJoueurs(i).nbCasesDecouvertes += casesDecouvertes
            End If
        Next
    End Sub

    ' Ecrit dans le fichier json les scores des joueurs et leur nom
    Public Sub Serialiser()
        Try
            Dim tab(max - 1) As Joueur
            For i = 0 To max - 1
                tab(i) = tabJoueurs(i)
            Next

            Dim sw As StreamWriter = New StreamWriter("..\..\Enregistrement.json", False)
            sw.WriteLine(JsonConvert.SerializeObject(tab, Formatting.Indented))
            sw.Close()
        Catch ex As FileNotFoundException
            MsgBox("Fichier Enregistrement introuvable", vbOKOnly, "Erreur")
        End Try
    End Sub

    ' Lit dans le fichier json les scores des joueurs et leur nom
    Public Sub Deserialiser()
        Try
            Dim sr As StreamReader = New StreamReader("..\..\Enregistrement.json")
            Dim str As String = ""
            While sr.Peek >= 0
                str += sr.ReadLine() + vbNewLine
            End While
            sr.Close()
            Dim joueurs As Joueur() = JsonConvert.DeserializeObject(Of Joueur())(str)
            max = joueurs.Length
            ReDim tabJoueurs(max - 1)
            For i As Integer = 0 To max - 1
                tabJoueurs(i) = joueurs(i)
            Next

        Catch ex As FileNotFoundException
            MsgBox("Fichier Enregistrement introuvable", vbOKOnly, "Erreur")
        End Try

    End Sub
End Module
