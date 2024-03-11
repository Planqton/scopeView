<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenüToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SnapshotToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SnapshotWSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OrdnerÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbStreamDevices = New System.Windows.Forms.ToolStripComboBox()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnToolgeStream = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbFPS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbDrawOverlay = New System.Windows.Forms.PictureBox()
        Me.pbStreamView = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.pbDrawOverlay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbStreamView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenüToolStripMenuItem, Me.cbStreamDevices, Me.RefreshToolStripMenuItem, Me.btnToolgeStream, Me.btnReset, Me.ResetToolStripMenuItem, Me.RecordToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1499, 32)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenüToolStripMenuItem
        '
        Me.MenüToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SnapshotToolStripMenuItem, Me.SnapshotWSToolStripMenuItem, Me.ToolStripMenuItem1, Me.OrdnerÖffnenToolStripMenuItem})
        Me.MenüToolStripMenuItem.Name = "MenüToolStripMenuItem"
        Me.MenüToolStripMenuItem.Size = New System.Drawing.Size(75, 28)
        Me.MenüToolStripMenuItem.Text = "Capture"
        '
        'SnapshotToolStripMenuItem
        '
        Me.SnapshotToolStripMenuItem.Name = "SnapshotToolStripMenuItem"
        Me.SnapshotToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.SnapshotToolStripMenuItem.Size = New System.Drawing.Size(264, 26)
        Me.SnapshotToolStripMenuItem.Text = "Snapshot"
        '
        'SnapshotWSToolStripMenuItem
        '
        Me.SnapshotWSToolStripMenuItem.Name = "SnapshotWSToolStripMenuItem"
        Me.SnapshotWSToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.SnapshotWSToolStripMenuItem.Size = New System.Drawing.Size(264, 26)
        Me.SnapshotWSToolStripMenuItem.Text = "Snapshot (with Shape)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(261, 6)
        '
        'OrdnerÖffnenToolStripMenuItem
        '
        Me.OrdnerÖffnenToolStripMenuItem.Name = "OrdnerÖffnenToolStripMenuItem"
        Me.OrdnerÖffnenToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.OrdnerÖffnenToolStripMenuItem.Size = New System.Drawing.Size(264, 26)
        Me.OrdnerÖffnenToolStripMenuItem.Text = "Open Folder"
        '
        'cbStreamDevices
        '
        Me.cbStreamDevices.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cbStreamDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStreamDevices.Name = "cbStreamDevices"
        Me.cbStreamDevices.Size = New System.Drawing.Size(265, 28)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(72, 28)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'btnToolgeStream
        '
        Me.btnToolgeStream.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnToolgeStream.Name = "btnToolgeStream"
        Me.btnToolgeStream.Size = New System.Drawing.Size(64, 28)
        Me.btnToolgeStream.Text = "[Start]"
        '
        'btnReset
        '
        Me.btnReset.Name = "btnReset"
        Me.btnReset.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.btnReset.Size = New System.Drawing.Size(52, 28)
        Me.btnReset.Text = "Tool"
        '
        'ResetToolStripMenuItem
        '
        Me.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem"
        Me.ResetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.ResetToolStripMenuItem.Size = New System.Drawing.Size(59, 28)
        Me.ResetToolStripMenuItem.Text = "Reset"
        '
        'RecordToolStripMenuItem
        '
        Me.RecordToolStripMenuItem.Enabled = False
        Me.RecordToolStripMenuItem.Name = "RecordToolStripMenuItem"
        Me.RecordToolStripMenuItem.Size = New System.Drawing.Size(70, 28)
        Me.RecordToolStripMenuItem.Text = "Record"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbFPS, Me.lbStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 577)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1499, 30)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbFPS
        '
        Me.lbFPS.BackColor = System.Drawing.SystemColors.ControlDark
        Me.lbFPS.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lbFPS.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lbFPS.Name = "lbFPS"
        Me.lbFPS.Size = New System.Drawing.Size(51, 24)
        Me.lbFPS.Text = "FPS: 0"
        '
        'lbStatus
        '
        Me.lbStatus.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.lbStatus.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lbStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(70, 24)
        Me.lbStatus.Text = "Stopped"
        '
        'pbDrawOverlay
        '
        Me.pbDrawOverlay.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.pbDrawOverlay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbDrawOverlay.Location = New System.Drawing.Point(0, 32)
        Me.pbDrawOverlay.Margin = New System.Windows.Forms.Padding(4)
        Me.pbDrawOverlay.Name = "pbDrawOverlay"
        Me.pbDrawOverlay.Size = New System.Drawing.Size(1499, 545)
        Me.pbDrawOverlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbDrawOverlay.TabIndex = 3
        Me.pbDrawOverlay.TabStop = False
        '
        'pbStreamView
        '
        Me.pbStreamView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbStreamView.Location = New System.Drawing.Point(0, 32)
        Me.pbStreamView.Margin = New System.Windows.Forms.Padding(4)
        Me.pbStreamView.Name = "pbStreamView"
        Me.pbStreamView.Size = New System.Drawing.Size(1499, 575)
        Me.pbStreamView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbStreamView.TabIndex = 0
        Me.pbStreamView.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1499, 607)
        Me.Controls.Add(Me.pbDrawOverlay)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.pbStreamView)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "scopeView by Vanillaboard"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.pbDrawOverlay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbStreamView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbStreamView As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenüToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cbStreamDevices As ToolStripComboBox
    Friend WithEvents btnToolgeStream As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lbFPS As ToolStripStatusLabel
    Friend WithEvents lbStatus As ToolStripStatusLabel
    Friend WithEvents SnapshotToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pbDrawOverlay As PictureBox
    Friend WithEvents SnapshotWSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents OrdnerÖffnenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnReset As ToolStripMenuItem
    Friend WithEvents ResetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RecordToolStripMenuItem As ToolStripMenuItem
End Class
