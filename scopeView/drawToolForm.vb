Imports System.Windows.Forms
Imports System.Drawing
Public Class drawToolForm
    Dim colorPickerTool As New ColorDialog

    Private Sub ColorLeft_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub drawToolForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbTool.SelectedIndex = Form1.toolIndex
        nudSize.Value = Form1.toolSize
        ColorSelectL.BackColor = Form1.toolColorL
        ColorSelectR.BackColor = Form1.toolColorR
    End Sub

    Private Sub ColorSelectL_Click(sender As Object, e As EventArgs) Handles ColorSelectL.Click
        If colorPickerTool.ShowDialog() = DialogResult.OK Then
            ColorSelectL.BackColor = colorPickerTool.Color
            Form1.toolColorL = colorPickerTool.Color
        End If
    End Sub

    Private Sub ColorSelectR_Click(sender As Object, e As EventArgs) Handles ColorSelectR.Click
        If colorPickerTool.ShowDialog() = DialogResult.OK Then
            ColorSelectR.BackColor = colorPickerTool.Color
            Form1.toolColorR = colorPickerTool.Color
        End If
    End Sub

    Private Sub nudSize_ValueChanged(sender As Object, e As EventArgs) Handles nudSize.ValueChanged
        Form1.toolSize = nudSize.Value
    End Sub

    Private Sub cbTool_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTool.SelectedIndexChanged
        Form1.toolIndex = cbTool.SelectedIndex

    End Sub


    Private Sub tbText_TextChanged(sender As Object, e As EventArgs) Handles tbText.TextChanged
        Form1.drawtextinput = tbText.Text
        If tbText.Text = "" Then
            lbText.Text = "Beispiel"
        Else
            lbText.Text = tbText.Text
        End If
    End Sub

    Private Sub lbText_Click(sender As Object, e As EventArgs) Handles lbText.Click
        Dim fontdialog As New FontDialog
        If fontdialog.ShowDialog() = DialogResult.OK Then
            lbText.Font = fontdialog.Font
            Form1.drawtextFont = fontdialog.Font
        End If
    End Sub

    Private Sub rstButton_Click(sender As Object, e As EventArgs) Handles rstButton.Click
        cbTool.SelectedIndex = 0
        nudSize.Value = 5
        tbText.Text = "Text"
    End Sub

    Private Sub btnSnapshot_Click(sender As Object, e As EventArgs) Handles btnSnapshot.Click
        Form1.SaveScreenshotWithDrawings()
    End Sub
End Class