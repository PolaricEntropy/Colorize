Public Class FullscreenForm
    Dim r, g, b As Integer
    Dim nrOfLoops As Integer = =

    Private Sub FullscreenForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Get rid of the cursor.
        Cursor.Hide()
    End Sub

    Private Sub FullscreenForm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        'Handles the different keys.
        Select Case e.KeyCode
            Case Keys.NumPad9, Keys.D9
                If r < 254 Then
                    r += 1
                End If
            Case Keys.NumPad7, Keys.D7
                If r > 0 Then
                    r -= 1
                End If
            Case Keys.NumPad6, Keys.D6
                If b < 254 Then
                    b += 1
                End If
            Case Keys.NumPad4, Keys.D4
                If b > 0 Then
                    b -= 1
                End If
            Case Keys.NumPad3, Keys.D3
                If g < 254 Then
                    g += 1
                End If
            Case Keys.NumPad1, Keys.D1
                If g > 0 Then
                    g -= 1
                End If
            Case Keys.H
                ColorDialog1.Color = Color.FromArgb(255, r, g, b)
                Cursor.Show()
                If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    r = ColorDialog1.Color.R
                    b = ColorDialog1.Color.B
                    g = ColorDialog1.Color.G
                End If
                Cursor.Hide()
            Case Keys.R
                RandomColorTimer.Start()
            Case Keys.S
                RandomColorTimer.Stop()
            Case Keys.Space
                'if we are already white, then make us black.
                If r = 255 And b = 255 And g = 255 Then
                    r = 0
                    b = 0
                    g = 0
                Else
                    'Make the entire form white.
                    r = 255
                    b = 255
                    g = 255
                End If
        End Select

        BackColor = Color.FromArgb(255, r, g, b)

    End Sub

    Private Sub RandomColorTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RandomColorTimer.Tick

        Dim randomGen As New Random
        Dim randomCommand As Integer

        'Only pick a random command every 30th loop.
        If nrOfLoops = 30 Then
            randomCommand = randomGen.Next(0, 7)
            nrOfLoops = 0
        End If

        Select Case randomCommand
            Case 1 'If green is more than 40 lower it, else increase it.
                If g > 40 Then
                    g -= 2
                Else
                    g += 2
                End If
            Case 2 'If green is less than max increase it.
                If g < 254 Then
                    g += 2
                End If
            Case 3 'If blue is more than 40 lower it, else increase it.
                If b > 40 Then
                    b -= 2
                Else
                    b += 2
                End If
            Case 4 'If blue is less than max increase it.
                If b < 254 Then
                    b += 2
                End If
            Case 5 'If red is more than 40 lower it, else increase it.
                If r > 40 Then
                    r -= 2
                Else
                    r += 2
                End If
            Case 6 'If red is less than max increase it.
                If r < 254 Then
                    r += 2
                End If
        End Select

        BackColor = Color.FromArgb(255, r, g, b)
        nrOfLoops += 1
    End Sub
End Class
