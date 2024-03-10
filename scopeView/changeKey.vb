Public Class changeKey
    Public Property PressedKey As Keys = Keys.None


    Private Sub changeKey_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        ' Überprüfe, ob eine Taste gedrückt wurde.
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
        PressedKey = e.KeyCode
        Me.Close()
    End Sub

End Class