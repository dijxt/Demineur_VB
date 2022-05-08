Module TableauCases
    Public Structure CaseDemineur
        Dim estMine As Boolean
        Dim estDemasquee As Boolean
        Dim estMarquee As Boolean
        Dim mineAutour As Integer
    End Structure

    Dim tabCases As CaseDemineur()
    Dim taille As Integer() = {8, 8}
    Dim nbMines As Integer = 10

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


        For i As Integer = 0 To nbMines - 1
            Dim pos As Integer = Random.Next(0, nbCases - 1)

            While (tabCases(pos).estMine)
                pos = Random.Next(0, nbCases - 1)
            End While

            tabCases(pos).estMine = True
            compterMines(pos)
        Next

        'For i As Integer = 0 To taille * taille - 1
        'If (Not tabCases(i).estMine) Then
        'p.Controls(i).Text = tabCases(i).mineAutour
        'Else
        'p.Controls(i).Text = "x"
        'End If
        'Next
    End Sub

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

    Public Sub marquerCase(pos As Integer, p As Panel)
        If (Not tabCases(pos).estDemasquee) Then
            tabCases(pos).estMarquee = Not tabCases(pos).estMarquee
            If (tabCases(pos).estMarquee) Then
                p.Controls(pos).Text = "M"
            Else
                p.Controls(pos).Text = ""
            End If
        End If
    End Sub

    Public Sub demasquerCase(pos As Integer, p As Panel)
        If (Not tabCases(pos).estMarquee) Then
            tabCases(pos).estDemasquee = True
            p.Controls(pos).Text = "x"
            If (tabCases(pos).mineAutour <> 0) Then
                p.Controls(pos).Text = tabCases(pos).mineAutour
            End If
            If (tabCases(pos).estMine) Then
                p.Controls(pos).Text = "m"
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

    Public Function getCase(i As Integer) As CaseDemineur
        Debug.Assert(i >= 0 And i < (taille(0) * taille(1)))

        Return tabCases(i)
    End Function

    Public Function estPartiePerdue() As Boolean
        For Each c As CaseDemineur In tabCases
            If c.estDemasquee = True And c.estMine = True Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function estGagneePartie() As Boolean
        Dim res As Boolean = True
        For Each c As CaseDemineur In tabCases
            If Not c.estDemasquee And Not c.estMine Then
                res = False
            End If
        Next
        Return res And Not estPartiePerdue()
    End Function

End Module
