﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Jeu
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.labelTempsRestant = New System.Windows.Forms.Label()
        Me.chrono = New System.Windows.Forms.Timer(Me.components)
        Me.buttonQuitter = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.labelNomJoueur = New System.Windows.Forms.Label()
        Me.buttonPause = New System.Windows.Forms.Button()
        Me.labelMinesRestantes = New System.Windows.Forms.Label()
        Me.buttonPremierCoup = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'labelTempsRestant
        '
        Me.labelTempsRestant.AutoSize = True
        Me.labelTempsRestant.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTempsRestant.Location = New System.Drawing.Point(213, 37)
        Me.labelTempsRestant.Name = "labelTempsRestant"
        Me.labelTempsRestant.Size = New System.Drawing.Size(0, 55)
        Me.labelTempsRestant.TabIndex = 64
        '
        'chrono
        '
        '
        'buttonQuitter
        '
        Me.buttonQuitter.Location = New System.Drawing.Point(23, 23)
        Me.buttonQuitter.Name = "buttonQuitter"
        Me.buttonQuitter.Size = New System.Drawing.Size(84, 32)
        Me.buttonQuitter.TabIndex = 65
        Me.buttonQuitter.Text = "Quitter"
        Me.buttonQuitter.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoSize = True
        Me.Panel1.Location = New System.Drawing.Point(110, 95)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(277, 273)
        Me.Panel1.TabIndex = 68
        '
        'labelNomJoueur
        '
        Me.labelNomJoueur.AutoSize = True
        Me.labelNomJoueur.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelNomJoueur.Location = New System.Drawing.Point(19, 431)
        Me.labelNomJoueur.Name = "labelNomJoueur"
        Me.labelNomJoueur.Size = New System.Drawing.Size(147, 24)
        Me.labelNomJoueur.TabIndex = 67
        Me.labelNomJoueur.Text = "Nom du joueur :"
        '
        'buttonPause
        '
        Me.buttonPause.Location = New System.Drawing.Point(412, 431)
        Me.buttonPause.Name = "buttonPause"
        Me.buttonPause.Size = New System.Drawing.Size(75, 26)
        Me.buttonPause.TabIndex = 68
        Me.buttonPause.Text = "Pause"
        Me.buttonPause.UseVisualStyleBackColor = True
        Me.buttonPause.Visible = False
        '
        'labelMinesRestantes
        '
        Me.labelMinesRestantes.AutoSize = True
        Me.labelMinesRestantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelMinesRestantes.Location = New System.Drawing.Point(19, 390)
        Me.labelMinesRestantes.Name = "labelMinesRestantes"
        Me.labelMinesRestantes.Size = New System.Drawing.Size(216, 20)
        Me.labelMinesRestantes.TabIndex = 69
        Me.labelMinesRestantes.Text = "Potentielles mines restantes :"
        '
        'buttonPremierCoup
        '
        Me.buttonPremierCoup.Location = New System.Drawing.Point(398, 402)
        Me.buttonPremierCoup.Name = "buttonPremierCoup"
        Me.buttonPremierCoup.Size = New System.Drawing.Size(89, 23)
        Me.buttonPremierCoup.TabIndex = 70
        Me.buttonPremierCoup.Text = "Premier coup"
        Me.buttonPremierCoup.UseVisualStyleBackColor = True
        '
        'Jeu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(499, 530)
        Me.Controls.Add(Me.buttonPremierCoup)
        Me.Controls.Add(Me.labelMinesRestantes)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.buttonPause)
        Me.Controls.Add(Me.labelNomJoueur)
        Me.Controls.Add(Me.buttonQuitter)
        Me.Controls.Add(Me.labelTempsRestant)
        Me.Name = "Jeu"
        Me.Text = "Jeu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelTempsRestant As Label
    Friend WithEvents chrono As Timer
    Friend WithEvents buttonQuitter As Button
    Friend WithEvents labelNomJoueur As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents buttonPause As Button
    Friend WithEvents labelMinesRestantes As Label
    Friend WithEvents buttonPremierCoup As Button
End Class