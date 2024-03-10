<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class drawToolForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ColorDialog2 = New System.Windows.Forms.ColorDialog()
        Me.ColorDialog3 = New System.Windows.Forms.ColorDialog()
        Me.ColorDialog4 = New System.Windows.Forms.ColorDialog()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.ColorDialog5 = New System.Windows.Forms.ColorDialog()
        Me.ColorSelectL = New System.Windows.Forms.Button()
        Me.ColorSelectR = New System.Windows.Forms.Button()
        Me.nudSize = New System.Windows.Forms.NumericUpDown()
        Me.cbTool = New System.Windows.Forms.ComboBox()
        Me.btnSnapshot = New System.Windows.Forms.Button()
        Me.tbText = New System.Windows.Forms.TextBox()
        Me.lbText = New System.Windows.Forms.Label()
        Me.rstButton = New System.Windows.Forms.Button()
        CType(Me.nudSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 3)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Size = New System.Drawing.Size(723, 82)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'ColorSelectL
        '
        Me.ColorSelectL.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ColorSelectL.Location = New System.Drawing.Point(12, 12)
        Me.ColorSelectL.Name = "ColorSelectL"
        Me.ColorSelectL.Size = New System.Drawing.Size(34, 57)
        Me.ColorSelectL.TabIndex = 23
        Me.ColorSelectL.UseVisualStyleBackColor = False
        '
        'ColorSelectR
        '
        Me.ColorSelectR.BackColor = System.Drawing.Color.Red
        Me.ColorSelectR.Location = New System.Drawing.Point(44, 12)
        Me.ColorSelectR.Name = "ColorSelectR"
        Me.ColorSelectR.Size = New System.Drawing.Size(34, 57)
        Me.ColorSelectR.TabIndex = 24
        Me.ColorSelectR.UseVisualStyleBackColor = False
        '
        'nudSize
        '
        Me.nudSize.Location = New System.Drawing.Point(12, 102)
        Me.nudSize.Name = "nudSize"
        Me.nudSize.Size = New System.Drawing.Size(192, 20)
        Me.nudSize.TabIndex = 26
        Me.nudSize.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'cbTool
        '
        Me.cbTool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTool.FormattingEnabled = True
        Me.cbTool.Items.AddRange(New Object() {"Rectangle", "Circle", "Line", "Brush", "Pfeil", "Text"})
        Me.cbTool.Location = New System.Drawing.Point(12, 75)
        Me.cbTool.Name = "cbTool"
        Me.cbTool.Size = New System.Drawing.Size(192, 21)
        Me.cbTool.TabIndex = 27
        '
        'btnSnapshot
        '
        Me.btnSnapshot.Enabled = False
        Me.btnSnapshot.Location = New System.Drawing.Point(84, 12)
        Me.btnSnapshot.Name = "btnSnapshot"
        Me.btnSnapshot.Size = New System.Drawing.Size(120, 57)
        Me.btnSnapshot.TabIndex = 28
        Me.btnSnapshot.Text = "Snapshot"
        Me.btnSnapshot.UseVisualStyleBackColor = True
        '
        'tbText
        '
        Me.tbText.Location = New System.Drawing.Point(12, 128)
        Me.tbText.Name = "tbText"
        Me.tbText.Size = New System.Drawing.Size(192, 20)
        Me.tbText.TabIndex = 30
        Me.tbText.Text = "Beispieltext"
        '
        'lbText
        '
        Me.lbText.AutoSize = True
        Me.lbText.Location = New System.Drawing.Point(12, 151)
        Me.lbText.Name = "lbText"
        Me.lbText.Size = New System.Drawing.Size(43, 13)
        Me.lbText.TabIndex = 31
        Me.lbText.Text = "Beispiel"
        '
        'rstButton
        '
        Me.rstButton.Location = New System.Drawing.Point(161, 154)
        Me.rstButton.Name = "rstButton"
        Me.rstButton.Size = New System.Drawing.Size(43, 23)
        Me.rstButton.TabIndex = 32
        Me.rstButton.Text = "RST"
        Me.rstButton.UseVisualStyleBackColor = True
        '
        'drawToolForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(216, 189)
        Me.Controls.Add(Me.rstButton)
        Me.Controls.Add(Me.lbText)
        Me.Controls.Add(Me.tbText)
        Me.Controls.Add(Me.btnSnapshot)
        Me.Controls.Add(Me.cbTool)
        Me.Controls.Add(Me.nudSize)
        Me.Controls.Add(Me.ColorSelectR)
        Me.Controls.Add(Me.ColorSelectL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "drawToolForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "drawToolForm"
        CType(Me.nudSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents ColorDialog2 As ColorDialog
    Friend WithEvents ColorDialog3 As ColorDialog
    Friend WithEvents ColorDialog4 As ColorDialog
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents ColorDialog5 As ColorDialog
    Friend WithEvents ColorSelectL As Button
    Friend WithEvents ColorSelectR As Button
    Friend WithEvents nudSize As NumericUpDown
    Friend WithEvents cbTool As ComboBox
    Friend WithEvents btnSnapshot As Button
    Friend WithEvents tbText As TextBox
    Friend WithEvents lbText As Label
    Friend WithEvents rstButton As Button
End Class
