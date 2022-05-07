Imports System.IO
Imports Newtonsoft.Json
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

    Public Sub ajouter(j As Joueur, Optional init As Boolean = False)
        Dim joueurExiste As Boolean = False
        For Each player As Joueur In tabJoueurs
            If Equals(player.prenom, j.prenom) Then
                joueurExiste = True
                If Not init Then
                    player.nbPartiesJouees += 1
                End If

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

    Public Sub Serialiser()
        Try
            Dim tab(getMax() - 1) As Joueur
            For i = 0 To getMax() - 1
                tab(i) = tabJoueurs(i)
            Next

            Dim sw As StreamWriter = New StreamWriter("..\..\Enregistrement.json", False)
            sw.WriteLine(JsonConvert.SerializeObject(tab, Formatting.Indented))
            sw.Close()
        Catch ex As FileNotFoundException
            MsgBox("Fichier Enregistrement introuvable", vbOKOnly, "Erreur")
        End Try
    End Sub

    Public Sub Deserialiser()
        Try
            Dim sr As StreamReader = New StreamReader("..\..\Enregistrement.json")
            Dim str As String = ""
            While sr.Peek >= 0
                str += sr.ReadLine() + vbNewLine
            End While
            sr.Close()
            Dim joueurs As Joueur() = JsonConvert.DeserializeObject(Of Joueur())(str)
            For Each joueur As Joueur In joueurs
                ajouter(joueur, True)
            Next

        Catch ex As FileNotFoundException
            MsgBox("Fichier Enregistrement introuvable", vbOKOnly, "Erreur")
        End Try

    End Sub
End Module
