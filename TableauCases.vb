Module TableauCases
    Public Structure CaseDemineur
        Dim estMine As Boolean ' Si la case est une mine
        Dim estDemasquee As Boolean ' Si la case est démasquée
        Dim estMarquee As Boolean ' Si la case est marquée
        Dim mineAutour As Integer ' Le nombre de mines autour de la case
    End Structure

    Dim tabCases As CaseDemineur() ' Tableau de toutes les cases du jeu
    Dim taille As Integer() = {8, 8} ' Taille du jeu
    Dim nbMines As Integer = 10 ' Nombre de mines

    ' Initialise le démineur, ajoute toutes les cases et dipose des mines sur le jeu aléatoirement
    Public Sub creerDemineur(p As Panel)
        taille = Options.getTaille()
        nbMines = Options.getMines()
        Dim nbCases As Integer = taille(0) * taille(1)

        Dim Random As New Random()
        ReDim tabCases(nbCases - 1)
        Dim tabMines As Integer()
        ReDim tabMines(nbMines)

        Dim c As CaseDemineur
        With c
            .estDemasquee = False
            .estMine = False
            .estMarquee = False
            .mineAutour = 0
        End With

        For i As Integer = 0 To (nbCases - 1)
            tabCases(i) = c
        Next

        If (Not Options.getChoixPosMines) Then
            For i As Integer = 0 To nbMines - 1
                Dim pos As Integer = Random.Next(0, nbCases)

                While (tabCases(pos).estMine)
                    pos = Random.Next(0, nbCases)
                End While

                tabCases(pos).estMine = True
                compterMines(pos)
            Next
        Else
            Dim tab As Integer() = Options.getTabMines()
            For i As Integer = 0 To nbMines - 1
                tabCases(tab(i)).estMine = True
                compterMines(tab(i))
            Next
        End If

        'For i As Integer = 0 To taille * taille - 1
        'If (Not tabCases(i).estMine) Then
        'p.Controls(i).Text = tabCases(i).mineAutour
        'Else
        'p.Controls(i).Text = "x"
        'End If
        'Next
    End Sub

    ' Nombre le nombre de mines autour de la case à l'indice pos
    Public Sub compterMines(pos As Integer)
        Dim posDessus As Integer = pos - taille(0)
        If (posDessus >= 0) Then
            tabCases(posDessus).mineAutour += 1
            If (posDessus Mod taille(0) <> 0) Then
                tabCases(posDessus - 1).mineAutour += 1
            End If
            If ((posDessus + 1) Mod taille(0) <> 0) Then
                tabCases(posDessus + 1).mineAutour += 1
            End If
        End If

        If (pos Mod taille(0) <> 0) Then
            tabCases(pos - 1).mineAutour += 1
        End If
        If ((pos + 1) Mod taille(0) <> 0) Then
            tabCases(pos + 1).mineAutour += 1
        End If

        Dim posDessous As Integer = pos + taille(0)
        If (posDessous < taille(0) * taille(1)) Then
            tabCases(posDessous).mineAutour += 1
            If (posDessous Mod taille(0) <> 0) Then
                tabCases(posDessous - 1).mineAutour += 1
            End If
            If ((posDessous + 1) Mod taille(0) <> 0) Then
                tabCases(posDessous + 1).mineAutour += 1
            End If
        End If
    End Sub

    ' Marque la case à l'indice pose
    Public Sub marquerCase(pos As Integer, p As Panel)
        If (Not tabCases(pos).estDemasquee) Then
            tabCases(pos).estMarquee = Not tabCases(pos).estMarquee
            If (tabCases(pos).estMarquee) Then
                p.Controls(pos).BackgroundImage = Jeu.ResizeImage(Image.FromFile("..\..\images\flag.png"), 24)
            Else
                p.Controls(pos).BackgroundImage = Nothing
            End If
        End If
    End Sub

    ' Démasque la case à l'indice pos et l'écrit sur le formulaire, démasque aussi les cases alentours si possible
    Public Sub demasquerCase(pos As Integer, p As Panel)
        p.Controls(pos).Enabled = False
        If (Not tabCases(pos).estMarquee) Then
            tabCases(pos).estDemasquee = True
            p.Controls(pos).BackColor = Color.Transparent
            If (tabCases(pos).mineAutour <> 0) Then
                p.Controls(pos).Text = tabCases(pos).mineAutour
            End If
            If (tabCases(pos).estMine) Then
            End If
        End If

        If (tabCases(pos).mineAutour <> 0 Or tabCases(pos).estMine And Not tabCases(pos).estMarquee) Then
            Return
        Else
            ' Vérifie les cases en horizontale
            If (pos Mod taille(0) <> 0) Then
                If (Not tabCases(pos - 1).estDemasquee And Not tabCases(pos - 1).estMarquee) Then
                    demasquerCase(pos - 1, p)
                End If
            End If
            If ((pos + 1) Mod taille(0) <> 0) Then
                If (Not tabCases(pos + 1).estDemasquee And Not tabCases(pos + 1).estMarquee) Then
                    demasquerCase(pos + 1, p)
                End If
            End If

            ' Vérifie les cases en verticale
            If (pos - taille(0) >= 0) Then
                If (Not tabCases(pos - taille(0)).estDemasquee And Not tabCases(pos - taille(0)).estMarquee) Then
                    demasquerCase(pos - taille(0), p)
                End If
            End If

            If (pos + taille(0) < taille(0) * taille(1)) Then
                If (Not tabCases(pos + taille(0)).estDemasquee And Not tabCases(pos + taille(0)).estMarquee) Then
                    demasquerCase(pos + taille(0), p)
                End If
            End If

            'Vérifie les cases en diagonale
            If (pos Mod taille(0) <> 0 And pos - taille(0) >= 0) Then
                If (Not tabCases(pos - taille(0) - 1).estDemasquee And Not tabCases(pos - taille(0) - 1).estMarquee) Then
                    demasquerCase(pos - taille(0) - 1, p)
                End If
            End If

            If ((pos + 1) Mod taille(0) <> 0 And pos - taille(0) >= 0) Then
                If (Not tabCases(pos - taille(0) + 1).estDemasquee And Not tabCases(pos - taille(0) + 1).estMarquee) Then
                    demasquerCase(pos - taille(0) + 1, p)
                End If
            End If

            If (pos Mod taille(0) <> 0 And pos + taille(0) < taille(0) * taille(1)) Then
                If (Not tabCases(pos + taille(0) - 1).estDemasquee And Not tabCases(pos + taille(0) - 1).estMarquee) Then
                    demasquerCase(pos + taille(0) - 1, p)
                End If
            End If

            If ((pos + 1) Mod taille(0) <> 0 And pos + taille(0) < taille(0) * taille(1)) Then
                If (Not tabCases(pos + taille(0) + 1).estDemasquee And Not tabCases(pos + taille(0) + 1).estMarquee) Then
                    demasquerCase(pos + taille(0) + 1, p)
                End If
            End If
        End If
    End Sub

    ' Retourne la case à l'indice i
    Public Function getCase(i As Integer) As CaseDemineur
        Debug.Assert(i >= 0 And i < (taille(0) * taille(1)))

        Return tabCases(i)
    End Function

    Public Function toutesCasesMarquees() As Integer
        Dim nbMarque As Integer = 0
        For Each c As CaseDemineur In tabCases
            If (c.estMarquee) Then
                nbMarque += 1
            End If
        Next

        Return nbMarque
    End Function

    ' Retourne si la partie est perdue ou non
    Public Function estPartiePerdue() As Boolean
        For Each c As CaseDemineur In tabCases
            If c.estDemasquee = True And c.estMine = True Then
                Return True
            End If
        Next
        Return False
    End Function

    ' Retourne si la partie est gagnée ou non
    Public Function estGagneePartie() As Boolean
        Dim res As Boolean = True
        For Each c As CaseDemineur In tabCases
            If Not c.estDemasquee And Not c.estMine Then
                res = False
            End If
        Next
        Return res And Not estPartiePerdue()
    End Function

    Public Sub premierCoup(p As Panel)
        For i As Integer = 0 To tabCases.Length
            If (tabCases(i).mineAutour = 0 And Not tabCases(i).estMine) Then
                demasquerCase(i, p)
                Exit For
            End If
        Next
    End Sub
End Module
