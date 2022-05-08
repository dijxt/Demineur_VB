<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOptions
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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.buttonQuitter = New System.Windows.Forms.Button()
        Me.groupBoxThemes = New System.Windows.Forms.GroupBox()
        Me.radioButtonVert = New System.Windows.Forms.RadioButton()
        Me.radioButtonBlanc = New System.Windows.Forms.RadioButton()
        Me.radioButtonRouge = New System.Windows.Forms.RadioButton()
        Me.radioButtonViolet = New System.Windows.Forms.RadioButton()
        Me.groupBoxMinuteur = New System.Windows.Forms.GroupBox()
        Me.labelTemps = New System.Windows.Forms.Label()
        Me.hScrollBarMinuteur = New System.Windows.Forms.HScrollBar()
        Me.labelMinuteur = New System.Windows.Forms.Label()
        Me.checkBoxMinuteur = New System.Windows.Forms.CheckBox()
        Me.groupBoxDemineur = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.textBoxTailleY = New System.Windows.Forms.TextBox()
        Me.checkBoxPause = New System.Windows.Forms.CheckBox()
        Me.textBoxTailleX = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textBoxMines = New System.Windows.Forms.TextBox()
        Me.buttonEnregistrer = New System.Windows.Forms.Button()
        Me.buttonDefaut = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.groupBoxTailleGrille = New System.Windows.Forms.GroupBox()
        Me.groupBoxThemes.SuspendLayout()
        Me.groupBoxMinuteur.SuspendLayout()
        Me.groupBoxDemineur.SuspendLayout()
        Me.groupBoxTailleGrille.SuspendLayout()
        Me.SuspendLayout()
        '
        'buttonQuitter
        '
        Me.buttonQuitter.Location = New System.Drawing.Point(12, 12)
        Me.buttonQuitter.Name = "buttonQuitter"
        Me.buttonQuitter.Size = New System.Drawing.Size(88, 37)
        Me.buttonQuitter.TabIndex = 0
        Me.buttonQuitter.Text = "Quitter"
        Me.buttonQuitter.UseVisualStyleBackColor = True
        '
        'groupBoxThemes
        '
        Me.groupBoxThemes.Controls.Add(Me.radioButtonVert)
        Me.groupBoxThemes.Controls.Add(Me.radioButtonBlanc)
        Me.groupBoxThemes.Controls.Add(Me.radioButtonRouge)
        Me.groupBoxThemes.Controls.Add(Me.radioButtonViolet)
        Me.groupBoxThemes.Location = New System.Drawing.Point(588, 12)
        Me.groupBoxThemes.Name = "groupBoxThemes"
        Me.groupBoxThemes.Size = New System.Drawing.Size(200, 116)
        Me.groupBoxThemes.TabIndex = 1
        Me.groupBoxThemes.TabStop = False
        Me.groupBoxThemes.Text = "Thèmes"
        '
        'radioButtonVert
        '
        Me.radioButtonVert.AutoSize = True
        Me.radioButtonVert.Location = New System.Drawing.Point(115, 41)
        Me.radioButtonVert.Name = "radioButtonVert"
        Me.radioButtonVert.Size = New System.Drawing.Size(44, 17)
        Me.radioButtonVert.TabIndex = 3
        Me.radioButtonVert.TabStop = True
        Me.radioButtonVert.Text = "Vert"
        Me.radioButtonVert.UseVisualStyleBackColor = True
        '
        'radioButtonBlanc
        '
        Me.radioButtonBlanc.AutoSize = True
        Me.radioButtonBlanc.Location = New System.Drawing.Point(115, 64)
        Me.radioButtonBlanc.Name = "radioButtonBlanc"
        Me.radioButtonBlanc.Size = New System.Drawing.Size(52, 17)
        Me.radioButtonBlanc.TabIndex = 2
        Me.radioButtonBlanc.TabStop = True
        Me.radioButtonBlanc.Text = "Blanc"
        Me.radioButtonBlanc.UseVisualStyleBackColor = True
        '
        'radioButtonRouge
        '
        Me.radioButtonRouge.AutoSize = True
        Me.radioButtonRouge.Location = New System.Drawing.Point(41, 64)
        Me.radioButtonRouge.Name = "radioButtonRouge"
        Me.radioButtonRouge.Size = New System.Drawing.Size(57, 17)
        Me.radioButtonRouge.TabIndex = 1
        Me.radioButtonRouge.Text = "Rouge"
        Me.radioButtonRouge.UseVisualStyleBackColor = True
        '
        'radioButtonViolet
        '
        Me.radioButtonViolet.AutoSize = True
        Me.radioButtonViolet.Checked = True
        Me.radioButtonViolet.Location = New System.Drawing.Point(41, 41)
        Me.radioButtonViolet.Name = "radioButtonViolet"
        Me.radioButtonViolet.Size = New System.Drawing.Size(51, 17)
        Me.radioButtonViolet.TabIndex = 0
        Me.radioButtonViolet.TabStop = True
        Me.radioButtonViolet.Text = "Violet"
        Me.radioButtonViolet.UseVisualStyleBackColor = True
        '
        'groupBoxMinuteur
        '
        Me.groupBoxMinuteur.Controls.Add(Me.labelTemps)
        Me.groupBoxMinuteur.Controls.Add(Me.hScrollBarMinuteur)
        Me.groupBoxMinuteur.Controls.Add(Me.labelMinuteur)
        Me.groupBoxMinuteur.Location = New System.Drawing.Point(588, 332)
        Me.groupBoxMinuteur.Name = "groupBoxMinuteur"
        Me.groupBoxMinuteur.Size = New System.Drawing.Size(200, 106)
        Me.groupBoxMinuteur.TabIndex = 2
        Me.groupBoxMinuteur.TabStop = False
        Me.groupBoxMinuteur.Text = "Minuteur"
        '
        'labelTemps
        '
        Me.labelTemps.AutoSize = True
        Me.labelTemps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTemps.Location = New System.Drawing.Point(88, 52)
        Me.labelTemps.Name = "labelTemps"
        Me.labelTemps.Size = New System.Drawing.Size(21, 16)
        Me.labelTemps.TabIndex = 6
        Me.labelTemps.Text = "60"
        '
        'hScrollBarMinuteur
        '
        Me.hScrollBarMinuteur.Location = New System.Drawing.Point(17, 74)
        Me.hScrollBarMinuteur.Name = "hScrollBarMinuteur"
        Me.hScrollBarMinuteur.Size = New System.Drawing.Size(168, 17)
        Me.hScrollBarMinuteur.TabIndex = 5
        '
        'labelMinuteur
        '
        Me.labelMinuteur.AutoSize = True
        Me.labelMinuteur.Location = New System.Drawing.Point(26, 29)
        Me.labelMinuteur.Name = "labelMinuteur"
        Me.labelMinuteur.Size = New System.Drawing.Size(147, 13)
        Me.labelMinuteur.TabIndex = 2
        Me.labelMinuteur.Text = "Entrez en temps en secondes"
        '
        'checkBoxMinuteur
        '
        Me.checkBoxMinuteur.AutoSize = True
        Me.checkBoxMinuteur.Checked = True
        Me.checkBoxMinuteur.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkBoxMinuteur.Location = New System.Drawing.Point(629, 309)
        Me.checkBoxMinuteur.Name = "checkBoxMinuteur"
        Me.checkBoxMinuteur.Size = New System.Drawing.Size(113, 17)
        Me.checkBoxMinuteur.TabIndex = 0
        Me.checkBoxMinuteur.Text = "Activer le minuteur"
        Me.checkBoxMinuteur.UseVisualStyleBackColor = True
        '
        'groupBoxDemineur
        '
        Me.groupBoxDemineur.Controls.Add(Me.groupBoxTailleGrille)
        Me.groupBoxDemineur.Controls.Add(Me.checkBoxPause)
        Me.groupBoxDemineur.Controls.Add(Me.Label1)
        Me.groupBoxDemineur.Controls.Add(Me.textBoxMines)
        Me.groupBoxDemineur.Location = New System.Drawing.Point(147, 12)
        Me.groupBoxDemineur.Name = "groupBoxDemineur"
        Me.groupBoxDemineur.Size = New System.Drawing.Size(393, 274)
        Me.groupBoxDemineur.TabIndex = 3
        Me.groupBoxDemineur.TabStop = False
        Me.groupBoxDemineur.Text = "Démineur"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "X"
        '
        'textBoxTailleY
        '
        Me.textBoxTailleY.Location = New System.Drawing.Point(54, 50)
        Me.textBoxTailleY.Name = "textBoxTailleY"
        Me.textBoxTailleY.Size = New System.Drawing.Size(23, 20)
        Me.textBoxTailleY.TabIndex = 7
        Me.textBoxTailleY.Text = "8"
        Me.textBoxTailleY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'checkBoxPause
        '
        Me.checkBoxPause.AutoSize = True
        Me.checkBoxPause.Location = New System.Drawing.Point(157, 25)
        Me.checkBoxPause.Name = "checkBoxPause"
        Me.checkBoxPause.Size = New System.Drawing.Size(138, 17)
        Me.checkBoxPause.TabIndex = 5
        Me.checkBoxPause.Text = "Activer le bouton pause"
        Me.checkBoxPause.UseVisualStyleBackColor = True
        '
        'textBoxTailleX
        '
        Me.textBoxTailleX.Location = New System.Drawing.Point(25, 50)
        Me.textBoxTailleX.Name = "textBoxTailleX"
        Me.textBoxTailleX.Size = New System.Drawing.Size(23, 20)
        Me.textBoxTailleX.TabIndex = 6
        Me.textBoxTailleX.Text = "8"
        Me.textBoxTailleX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nombre de mines"
        '
        'textBoxMines
        '
        Me.textBoxMines.Location = New System.Drawing.Point(41, 160)
        Me.textBoxMines.Name = "textBoxMines"
        Me.textBoxMines.Size = New System.Drawing.Size(39, 20)
        Me.textBoxMines.TabIndex = 4
        Me.textBoxMines.Text = "10"
        Me.textBoxMines.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'buttonEnregistrer
        '
        Me.buttonEnregistrer.Location = New System.Drawing.Point(12, 64)
        Me.buttonEnregistrer.Name = "buttonEnregistrer"
        Me.buttonEnregistrer.Size = New System.Drawing.Size(88, 37)
        Me.buttonEnregistrer.TabIndex = 4
        Me.buttonEnregistrer.Text = "Enregistrer"
        Me.buttonEnregistrer.UseVisualStyleBackColor = True
        '
        'buttonDefaut
        '
        Me.buttonDefaut.Location = New System.Drawing.Point(12, 116)
        Me.buttonDefaut.Name = "buttonDefaut"
        Me.buttonDefaut.Size = New System.Drawing.Size(88, 35)
        Me.buttonDefaut.TabIndex = 5
        Me.buttonDefaut.Text = "Par défaut"
        Me.buttonDefaut.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(55, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Y"
        '
        'groupBoxTailleGrille
        '
        Me.groupBoxTailleGrille.Controls.Add(Me.Label3)
        Me.groupBoxTailleGrille.Controls.Add(Me.Label4)
        Me.groupBoxTailleGrille.Controls.Add(Me.textBoxTailleX)
        Me.groupBoxTailleGrille.Controls.Add(Me.textBoxTailleY)
        Me.groupBoxTailleGrille.Location = New System.Drawing.Point(22, 25)
        Me.groupBoxTailleGrille.Name = "groupBoxTailleGrille"
        Me.groupBoxTailleGrille.Size = New System.Drawing.Size(102, 91)
        Me.groupBoxTailleGrille.TabIndex = 10
        Me.groupBoxTailleGrille.TabStop = False
        Me.groupBoxTailleGrille.Text = "Taille de la grille"
        '
        'FormOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.buttonDefaut)
        Me.Controls.Add(Me.buttonEnregistrer)
        Me.Controls.Add(Me.groupBoxDemineur)
        Me.Controls.Add(Me.groupBoxMinuteur)
        Me.Controls.Add(Me.groupBoxThemes)
        Me.Controls.Add(Me.checkBoxMinuteur)
        Me.Controls.Add(Me.buttonQuitter)
        Me.Name = "FormOptions"
        Me.Text = "FormOptions"
        Me.groupBoxThemes.ResumeLayout(False)
        Me.groupBoxThemes.PerformLayout()
        Me.groupBoxMinuteur.ResumeLayout(False)
        Me.groupBoxMinuteur.PerformLayout()
        Me.groupBoxDemineur.ResumeLayout(False)
        Me.groupBoxDemineur.PerformLayout()
        Me.groupBoxTailleGrille.ResumeLayout(False)
        Me.groupBoxTailleGrille.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents buttonQuitter As Button
    Friend WithEvents groupBoxThemes As GroupBox
    Friend WithEvents groupBoxMinuteur As GroupBox
    Friend WithEvents labelMinuteur As Label
    Friend WithEvents checkBoxMinuteur As CheckBox
    Friend WithEvents groupBoxDemineur As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents textBoxMines As TextBox
    Friend WithEvents buttonEnregistrer As Button
    Friend WithEvents textBoxTailleX As TextBox
    Friend WithEvents checkBoxPause As CheckBox
    Friend WithEvents labelTemps As Label
    Friend WithEvents hScrollBarMinuteur As HScrollBar
    Friend WithEvents radioButtonVert As RadioButton
    Friend WithEvents radioButtonBlanc As RadioButton
    Friend WithEvents radioButtonRouge As RadioButton
    Friend WithEvents radioButtonViolet As RadioButton
    Friend WithEvents buttonDefaut As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents textBoxTailleY As TextBox
    Friend WithEvents groupBoxTailleGrille As GroupBox
    Friend WithEvents Label4 As Label
End Class
