Imports System.Data.SqlTypes
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Threading
Imports AForge
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports System.Runtime.InteropServices
Imports System.Net.WebClient
Imports System.Net
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.Devices
Imports System.Net.Mime.MediaTypeNames


Public Class Form1
    ''Streaming
    Private videoDevices As FilterInfoCollection
    Private streamSource As VideoCaptureDevice
    Private lastFrameTime As DateTime
    Private streamState As Boolean = False
    Private pauseState As Boolean = False
    Private directoryPath As String = Environment.CurrentDirectory & "\screenshots"
    'Painting

    Dim nUDToolSize As New NumericUpDownToolStripItem()


    Private drawingTool As Integer = 0 ' Aktuelles Zeichenwerkzeug (0: Rechteck, 1: Kreis, 2: Linie, 3: Pinsel)
    Private drawingColor As Color = Color.Black ' Aktuelle Zeichenfarbe
    Private drawingThickness As Integer = 1 ' Aktuelle Linienstärke



    'Drawing Variables
    Private rectList As New List(Of Tuple(Of Rectangle, Pen))()
    Private circleList As New List(Of Tuple(Of Rectangle, Pen))()
    Private lineList As New List(Of Tuple(Of List(Of System.Drawing.Point), Pen))()
    Private arrowList As New List(Of Tuple(Of System.Drawing.Point, System.Drawing.Point, Pen))()
    Private brushList As New List(Of Tuple(Of List(Of System.Drawing.Point), Pen))()
    Private textStamps As New List(Of Tuple(Of String, Font, System.Drawing.Point, Color))()
    Public tempBitmap As Bitmap
    Private isDrawing As Boolean = False
    Private startPoint As System.Drawing.Point
    Private endPoint As System.Drawing.Point
    Public toolIndex As Integer = 0 ' Annahme: 0 für Rechteck, 1 für Kreis, 2 für Linie, 3 für Pinseltool, 4 für Pfeil
    Public toolSize As Integer = 5 ' Standardwert für die Strichstärke
    Private toolColor As Color = Color.Black ' Standardfarbe
    Public toolColorL As Color = Color.Red
    Public toolColorR As Color = Color.Blue
    Private lastPoint As System.Drawing.Point
    Public drawtext As Boolean = False
    Public drawtextInput As String
    Public drawtextFont As Font


    Public Sub New()
        InitializeComponent()
        InitializePictureBox()
    End Sub

    Private Sub InitializePictureBox()



        ' Ereignishandler für Mausereignisse hinzufügen
        AddHandler pbDrawOverlay.MouseDown, AddressOf pbDrawOverlay_MouseDown
        AddHandler pbDrawOverlay.MouseMove, AddressOf pbDrawOverlay_MouseMove
        AddHandler pbDrawOverlay.MouseUp, AddressOf pbDrawOverlay_MouseUp
    End Sub

    Public Class NumericUpDownToolStripItem
        Inherits ToolStripControlHost

        Public Sub New()
            MyBase.New(New NumericUpDown())
        End Sub

        Public ReadOnly Property NumericUpDownControl As NumericUpDown
            Get
                Return CType(Control, NumericUpDown)
            End Get
        End Property
    End Class


    ''''''''''''''''''''''''''


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        drawtextFont = MenuStrip1.Font


        refreshVideoStreams()
        btnToolgeStream.ForeColor = Color.Green
        pbDrawOverlay.BackColor = Color.Transparent
        pbStreamView.Controls.Add(pbDrawOverlay)
        ''Numeric
        toolIndex = 0

        tempBitmap = New Bitmap(pbDrawOverlay.Width, pbDrawOverlay.Height)
    End Sub

    Sub refreshVideoStreams()
        videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        cbStreamDevices.Items.Clear()
        For Each device As FilterInfo In videoDevices
            cbStreamDevices.Items.Add(device.Name)
        Next
        If cbStreamDevices.Items.Count > 0 Then
            cbStreamDevices.SelectedIndex = 0
        End If

    End Sub

    Private Sub ToggleStream()
        If streamState = False Then
            startStream(cbStreamDevices.SelectedIndex)

        Else
            stopStream()
        End If
    End Sub

    Private Sub TogglePause()
        If pauseState = False Then
            pauseState = True
            lbFPS.Text = "FPS: 0"
            lbStatus.Text = "Pause"
        Else
            pauseState = False
            lbStatus.Text = "Streaming"
        End If
    End Sub

    Private Sub SnapShot()
        ' Überprüfen, ob das PictureBox-Steuerelement ein Bild enthält
        If pbStreamView.Image IsNot Nothing Then
            ' Verzeichnis erstellen, wenn es nicht existiert

            If Not Directory.Exists(directoryPath) Then
                Directory.CreateDirectory(directoryPath)
            End If

            ' Dateipfad erstellen
            Dim fileName As String = $"snapshot_{DateTime.Now:yyyyMMdd_HHmmss}.png"
            Dim filePath As String = Path.Combine(directoryPath, fileName)

            ' Bild als PNG speichern
            pbStreamView.Image.Save(filePath, ImageFormat.Png)

            MessageBox.Show("Snapshot saved!:" & vbCrLf & filePath)
        Else
            MessageBox.Show("No Picture to Capture.")
        End If
    End Sub

    Private Sub FrameCounter()
        ' Calculate the time elapsed since the last frame
        Dim timeSinceLastFrame As TimeSpan = DateTime.Now - lastFrameTime

        ' Calculate FPS
        Dim fps As Double = 1000.0 / timeSinceLastFrame.TotalMilliseconds

        ' Update the time of the last frame
        lastFrameTime = DateTime.Now

        ' Update the display for FPS in the title of the form in the main thread
        Me.Invoke(Sub()
                      lbFPS.Text = $"FPS: {fps:F2}"
                  End Sub)
    End Sub


    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        refreshVideoStreams()
    End Sub

    Private Sub btnToolgeStream_Click(sender As Object, e As EventArgs) Handles btnToolgeStream.Click
        ToggleStream()
    End Sub
    Private Sub startStream(streamIndex)
        If cbStreamDevices.SelectedIndex <> -1 Then
            ' Erstelle eine Videoquelle basierend auf dem ausgewählten Gerät
            streamSource = New VideoCaptureDevice(videoDevices(streamIndex).MonikerString)

            ' Füge den Eventhandler für das neue Bild hinzu
            AddHandler streamSource.NewFrame, AddressOf Video_NewFrameReceived

            ' Starte die Aufnahme
            streamSource.Start()
            streamState = True
            btnToolgeStream.Text = "[Stop]"
            btnToolgeStream.ForeColor = Color.Red
        Else
            MessageBox.Show("Please select Streaming Device.")
        End If
    End Sub
    Private Sub Video_NewFrameReceived(sender As Object, eventArgs As NewFrameEventArgs)
        ' Zeige das neue Bild in der PictureBox an
        pbStreamView.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)
        ThreadPool.QueueUserWorkItem(Sub(state)
                                         FrameCounter()
                                     End Sub)
        lbStatus.Text = "Viewing"
    End Sub


    Private Sub stopStream()
        ' Stopp die Videoquelle, wenn das Formular geschlossen wird
        If streamSource IsNot Nothing AndAlso streamSource.IsRunning Then
            streamSource.SignalToStop()
            streamSource.WaitForStop()
            streamState = False
            btnToolgeStream.Text = "[Start]"
            btnToolgeStream.ForeColor = Color.Green
            lbFPS.Text = "FPS: 0"
            lbStatus.Text = "Stopped"
            pbStreamView.Image = Nothing
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        stopStream()
    End Sub



    Private Sub OrdnerÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdnerÖffnenToolStripMenuItem.Click
        If Not Directory.Exists(directoryPath) Then
            MessageBox.Show("This Directory doesnt Exist." & directoryPath)
            Return
        End If
        ' Das Verzeichnis öffnen
        Process.Start("explorer.exe", directoryPath)
    End Sub


    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click

        drawToolForm.Show()
        drawToolForm.TopMost = True
    End Sub





    '' Paint Function!
    Private Sub pbDrawOverlay_MouseDown(sender As Object, e As MouseEventArgs) Handles pbDrawOverlay.MouseDown
        If e.Button = MouseButtons.Left Then
            toolColor = toolColorL
        ElseIf e.Button = MouseButtons.Right Then
            toolColor = toolColorR
        ElseIf e.Button = MouseButtons.Middle Then

        End If


        isDrawing = True
        startPoint = e.Location
        startPoint.Offset(-pbDrawOverlay.Location.X, -pbDrawOverlay.Location.Y) ' Offset für die Position des Zeichenbereichs
        startPoint = New System.Drawing.Point(Math.Max(0, startPoint.X), Math.Max(0, startPoint.Y)) ' Sicherstellen, dass die Startposition innerhalb des Bildbereichs liegt


        If toolIndex = 3 Then ' Pinseltool
            Dim brushLine As New List(Of System.Drawing.Point)()
            brushLine.Add(startPoint)
            Dim currentPen As New Pen(toolColor, toolSize)
            brushList.Add(Tuple.Create(brushLine, currentPen))
            lastPoint = startPoint
        ElseIf toolIndex = 5 Then
            Dim font As Font = drawtextFont
            textStamps.Add(Tuple.Create(drawtextInput, font, e.Location, toolColor)) ' Farbe des Textes speichern
            pbDrawOverlay.Invalidate() ' PictureBox aktualisieren, um den Textstempel zu zeichnen

        End If
    End Sub

    Private Sub pbDrawOverlay_MouseMove(sender As Object, e As MouseEventArgs) Handles pbDrawOverlay.MouseMove
        Dim g As Graphics = Graphics.FromImage(tempBitmap)

        If isDrawing Then

            ' Offset für die Position des Zeichenbereichs
            Dim currentPoint As New System.Drawing.Point(e.X - pbDrawOverlay.Location.X, e.Y - pbDrawOverlay.Location.Y)
            currentPoint = New System.Drawing.Point(Math.Max(0, currentPoint.X), Math.Max(0, currentPoint.Y)) ' Sicherstellen, dass die Position innerhalb des Bildbereichs liegt

            If toolIndex = 0 Then ' Rechteck zeichnen
                g.Clear(Color.Transparent)
                DrawRectangle(g, startPoint, currentPoint, New Pen(toolColor, toolSize))
                pbDrawOverlay.Image = tempBitmap

            ElseIf toolIndex = 1 Then ' Kreis zeichnen
                g.Clear(Color.Transparent)
                DrawEllipse(g, startPoint, currentPoint, New Pen(toolColor, toolSize))
                pbDrawOverlay.Image = tempBitmap
            ElseIf toolIndex = 2 Then ' Linie zeichnen
                g.Clear(Color.Transparent)
                DrawLine(g, startPoint, currentPoint, New Pen(toolColor, toolSize))
                pbDrawOverlay.Image = tempBitmap
            ElseIf toolIndex = 3 Then ' Pinseltool
                Dim paintBrush As New Pen(toolColor, CSng(toolSize * 2))
                g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                paintBrush.StartCap = Drawing2D.LineCap.Round
                paintBrush.EndCap = Drawing2D.LineCap.Round
                g.DrawLine(paintBrush, lastPoint, currentPoint)
                lastPoint = currentPoint
                paintBrush.Dispose()
                pbDrawOverlay.Image = tempBitmap
            ElseIf toolIndex = 4 Then ' Pfeil zeichnen
                g.Clear(Color.Transparent)
                DrawArrow(g, startPoint, currentPoint, New Pen(toolColor, toolSize))
                pbDrawOverlay.Image = tempBitmap
            End If
        End If

        If toolIndex = 5 Then
            g.Clear(Color.Transparent)
            Dim font As Font = drawtextFont
            Dim brush As New SolidBrush(toolColor)
            g.DrawString(drawtextInput, font, brush, e.Location)
            brush.Dispose()
            g.Dispose()
            pbDrawOverlay.Image = tempBitmap

        End If
    End Sub

    Private Sub pbDrawOverlay_MouseUp(sender As Object, e As MouseEventArgs) Handles pbDrawOverlay.MouseUp
        isDrawing = False

        ' Offset für die Position des Zeichenbereichs
        Dim endPoint As New System.Drawing.Point(e.X - pbDrawOverlay.Location.X, e.Y - pbDrawOverlay.Location.Y)
        endPoint = New System.Drawing.Point(Math.Max(0, endPoint.X), Math.Max(0, endPoint.Y)) ' Sicherstellen, dass die Position innerhalb des Bildbereichs liegt

        If toolIndex = 0 Then ' Rechteck hinzufügen
            Dim currentRect As New Rectangle(startPoint, New Size(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y))
            rectList.Add(Tuple.Create(currentRect, New Pen(toolColor, toolSize)))
        ElseIf toolIndex = 1 Then ' Kreis hinzufügen
            Dim currentRect As New Rectangle(startPoint, New Size(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y))
            circleList.Add(Tuple.Create(currentRect, New Pen(toolColor, toolSize)))
        ElseIf toolIndex = 2 Then ' Linie hinzufügen
            Dim linePoints As New List(Of System.Drawing.Point)()
            linePoints.Add(startPoint)
            linePoints.Add(endPoint)
            lineList.Add(Tuple.Create(linePoints, New Pen(toolColor, toolSize)))
        ElseIf toolIndex = 4 Then ' Pfeil hinzufügen
            arrowList.Add(Tuple.Create(startPoint, endPoint, New Pen(toolColor, toolSize)))

        ElseIf toolIndex = 5 Then

        End If

        pbDrawOverlay.Image = tempBitmap ' Aktualisiere das Bild
    End Sub


    Private Sub pbDrawOverlay_Paint(sender As Object, e As PaintEventArgs) Handles pbDrawOverlay.Paint
        Dim g As Graphics = e.Graphics

        ' Zeichne Rechtecke
        For Each rect As Tuple(Of Rectangle, Pen) In rectList
            DrawRectangle(g, rect.Item1.Location, New System.Drawing.Point(rect.Item1.Right, rect.Item1.Bottom), rect.Item2)
        Next

        ' Zeichne Kreise
        For Each circle As Tuple(Of Rectangle, Pen) In circleList
            DrawEllipse(g, circle.Item1.Location, New System.Drawing.Point(circle.Item1.Right, circle.Item1.Bottom), circle.Item2)
        Next

        ' Zeichne Linien
        For Each line As Tuple(Of List(Of System.Drawing.Point), Pen) In lineList
            DrawLine(g, line.Item1(0), line.Item1(1), line.Item2)
        Next

        ' Zeichne Pfeile
        For Each arrow As Tuple(Of System.Drawing.Point, System.Drawing.Point, Pen) In arrowList
            DrawArrow(g, arrow.Item1, arrow.Item2, arrow.Item3)
        Next

        ' Zeichne Pinselstriche
        For Each brushTuple As Tuple(Of List(Of System.Drawing.Point), Pen) In brushList
            DrawBrushLine(g, brushTuple.Item1, brushTuple.Item2)
        Next

        For Each stamp As Tuple(Of String, Font, System.Drawing.Point, Color) In textStamps
            DrawTextStamp(stamp.Item1, stamp.Item2, stamp.Item3, stamp.Item4, e.Graphics) ' Farbe des Textes übergeben
        Next
    End Sub



    Private Sub DrawRectangle(g As Graphics, startPoint As System.Drawing.Point, endPoint As System.Drawing.Point, pen As Pen)
        ''g.DrawRectangle(pen, New Rectangle(startPoint, New Size(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y)))
        Dim x1 As Integer = Math.Min(startPoint.X, endPoint.X)
        Dim y1 As Integer = Math.Min(startPoint.Y, endPoint.Y)
        Dim width As Integer = Math.Abs(startPoint.X - endPoint.X)
        Dim height As Integer = Math.Abs(startPoint.Y - endPoint.Y)

        g.DrawRectangle(pen, New Rectangle(x1, y1, width, height))
    End Sub

    Private Sub DrawEllipse(g As Graphics, startPoint As System.Drawing.Point, endPoint As System.Drawing.Point, pen As Pen)
        g.DrawEllipse(pen, New Rectangle(startPoint, New Size(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y)))
    End Sub

    Private Sub DrawLine(g As Graphics, startPoint As System.Drawing.Point, endPoint As System.Drawing.Point, pen As Pen)
        g.DrawLine(pen, startPoint, endPoint)
    End Sub

    Private Sub DrawBrushLine(g As Graphics, brushLine As List(Of System.Drawing.Point), pen As Pen)
        If brushLine.Count > 1 Then
            For i As Integer = 1 To brushLine.Count - 1
                g.DrawLine(pen, brushLine(i - 1), brushLine(i))
            Next
        End If
    End Sub

    Private Sub DrawArrow(g As Graphics, startPoint As System.Drawing.Point, endPoint As System.Drawing.Point, pen As Pen)
        Dim arrowWidth As Integer = 10
        Dim arrowLength As Integer = 20

        Dim angle As Single = CSng(Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X))
        Dim arrowEnd1 As New PointF(endPoint.X - arrowLength * Math.Cos(angle - Math.PI / 6), endPoint.Y - arrowLength * Math.Sin(angle - Math.PI / 6))
        Dim arrowEnd2 As New PointF(endPoint.X - arrowLength * Math.Cos(angle + Math.PI / 6), endPoint.Y - arrowLength * Math.Sin(angle + Math.PI / 6))

        g.DrawLine(pen, startPoint, endPoint)
        g.DrawLine(pen, endPoint, arrowEnd1)
        g.DrawLine(pen, endPoint, arrowEnd2)
    End Sub
    Private Sub DrawTextStamp(text As String, font As Font, position As System.Drawing.Point, color As Color, g As Graphics)
        Using brush As New SolidBrush(color) ' Farbe des Textes verwenden
            g.DrawString(text, font, brush, position)
        End Using
    End Sub

    Private Sub pbDrawOverlay_SizeChanged(sender As Object, e As EventArgs) Handles pbDrawOverlay.SizeChanged
        If WindowState = FormWindowState.Minimized Then
            Return
        End If
        refreshDrawOverlay()
    End Sub

    Sub refreshDrawOverlay()
        rectList.Clear()
        circleList.Clear()
        lineList.Clear()
        arrowList.Clear()
        brushList.Clear()
        textStamps.Clear()
        tempBitmap = New Bitmap(pbDrawOverlay.Width, pbDrawOverlay.Height)
        pbDrawOverlay.Image = tempBitmap ' Setze das Bild des Overlay auf das neue Bitmap
    End Sub
    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        refreshDrawOverlay()
    End Sub
    Private Sub SaveScreenshotWithDrawings()
        ' Erstellen Sie eine Kopie des aktuellen Inhalts der pbDrawOverlay-PictureBox
        Dim bmp As New Bitmap(pbDrawOverlay.ClientSize.Width, pbDrawOverlay.ClientSize.Height)
        pbDrawOverlay.DrawToBitmap(bmp, pbDrawOverlay.ClientRectangle)

        ' Erstellen Sie eine Grafikobjekt für die Bitmap
        Using g As Graphics = Graphics.FromImage(bmp)
            ' Zeichnen Sie die gezeichneten Elemente auf die Bitmap
            DrawGraphicsOnBitmap(g)
        End Using

        ' Verzeichnis erstellen, wenn es nicht existiert

        If Not Directory.Exists(directoryPath) Then
            Directory.CreateDirectory(directoryPath)
        End If

        ' Dateipfad erstellen
        Dim fileName As String = $"screenshot_with_drawings_{DateTime.Now:yyyyMMdd_HHmmss}.png"
        Dim filePath As String = Path.Combine(directoryPath, fileName)

        ' Bild als PNG speichern
        bmp.Save(filePath, ImageFormat.Png)

        MessageBox.Show("Screenshot with Drawing saved!:" & vbCrLf & filePath)
    End Sub

    Private Sub DrawGraphicsOnBitmap(g As Graphics)
        ' Zeichnen Sie Rechtecke
        For Each rect As Tuple(Of Rectangle, Pen) In rectList
            DrawRectangle(g, rect.Item1.Location, New System.Drawing.Point(rect.Item1.Right, rect.Item1.Bottom), rect.Item2)
        Next

        ' Zeichnen Sie Kreise
        For Each circle As Tuple(Of Rectangle, Pen) In circleList
            DrawEllipse(g, circle.Item1.Location, New System.Drawing.Point(circle.Item1.Right, circle.Item1.Bottom), circle.Item2)
        Next

        ' Zeichnen Sie Linien
        For Each line As Tuple(Of List(Of System.Drawing.Point), Pen) In lineList
            DrawLine(g, line.Item1(0), line.Item1(1), line.Item2)
        Next

        ' Zeichnen Sie Pfeile
        For Each arrow As Tuple(Of System.Drawing.Point, System.Drawing.Point, Pen) In arrowList
            DrawArrow(g, arrow.Item1, arrow.Item2, arrow.Item3)
        Next

        ' Zeichnen Sie Pinselstriche
        For Each brushTuple As Tuple(Of List(Of System.Drawing.Point), Pen) In brushList
            DrawBrushLine(g, brushTuple.Item1, brushTuple.Item2)
        Next



        For Each textStamps As Tuple(Of List(Of System.Drawing.Point), Pen) In brushList
            DrawBrushLine(g, textStamps.Item1, textStamps.Item2)
        Next
    End Sub

    Private Sub AufnahmeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SnapshotWSToolStripMenuItem.Click
        SaveScreenshotWithDrawings()
    End Sub

    Private Sub SnapshotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SnapshotToolStripMenuItem.Click
        SnapShot()
    End Sub
    Private Sub pbDrawOverlay_Click(sender As Object, e As EventArgs) Handles pbDrawOverlay.Click

    End Sub



    Private Function GetPressedKey() As Keys
        Using changeKeyForm As New changeKey()
            changeKeyForm.ShowDialog()
            ' Gib die gespeicherte gedrückte Taste zurück
            Return changeKeyForm.PressedKey
        End Using
    End Function

    Private Sub RecordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecordToolStripMenuItem.Click

    End Sub

    Private Sub pbDrawOverlay_MouseLeave(sender As Object, e As EventArgs) Handles pbDrawOverlay.MouseLeave
        tempBitmap.Dispose()
        pbDrawOverlay.Image = Nothing
        tempBitmap = New Bitmap(pbDrawOverlay.Width, pbDrawOverlay.Height)
        pbDrawOverlay.Image = tempBitmap
    End Sub
End Class
