Public Class Alkohol_Rechner2

    Private Sub Alkohol_Rechner2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.Farbe = "Blue" Then
            Me.BackColor = Color.LightBlue
            RadioButton2.BackColor = Color.LightBlue
            Button1.BackColor = Color.YellowGreen
            Button3.BackColor = Color.Orange
        Else
            Me.BackColor = SystemColors.Control
        End If

        TextBox1.Text = My.Settings.Gewicht
        TextBox2.Text = My.Settings.Alter
        TextBox3.Text = My.Settings.Koerpergroesse

        If My.Settings.Maennlich = False Then
            RadioButton2.Checked = True
        End If

        If TextBox1.Text IsNot "" Then
            TextBox12.Select()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Double
        Dim r As Double
        Dim Alk As Double
        Dim Promille As Double

        Dim Bier As Double
        Dim Wein As Double
        Dim Liqueur As Double
        Dim Schnaps1 As Double
        Dim Schnaps2 As Double

        TextBox1.BackColor = If(TextBox1.Text = "", Color.Red, Color.White)
        TextBox2.BackColor = If(TextBox2.Text = "", Color.Red, Color.White)
        TextBox3.BackColor = If(TextBox3.Text = "", Color.Red, Color.White)

        If TextBox1.Text IsNot "" And TextBox2.Text IsNot "" And TextBox3.Text IsNot "" Then

            If RadioButton1.Checked = True Then 'männlich
                i = 2.447 - 0.09516 * TextBox2.Text + 0.1074 * TextBox3.Text + 0.3362 * TextBox1.Text
            Else 'weiblich
                i = -2.097 + 0.1069 * TextBox3.Text + 0.2466 * TextBox1.Text
            End If

            Bier = If(TextBox12.Text = "", 0, TextBox12.Text)
            Wein = If(TextBox13.Text = "", 0, TextBox13.Text)
            Liqueur = If(TextBox14.Text = "", 0, TextBox14.Text)
            Schnaps1 = If(TextBox15.Text = "", 0, TextBox15.Text)
            Schnaps2 = If(TextBox16.Text = "", 0, TextBox16.Text)

            Alk = (Bier / 25) + (Wein / 12) + (Liqueur / 5) + (Schnaps1 / 4) + (Schnaps2 / 3)
            r = (1.055 * i) / (0.8 * TextBox1.Text)
            Promille = (Alk) / (TextBox1.Text * r)

            TextBox5.Text = Math.Round(r, 2)
            TextBox11.Text = Alk
            TextBox4.Text = Math.Round(Promille, 2)

            If Promille > 3.4 Then
                MsgBox("Alkohol kann ab 3.5 Promille tödlich sein!", MsgBoxStyle.Critical, "Info")
            End If

            My.Settings.Gewicht = TextBox1.Text
            My.Settings.Alter = TextBox2.Text
            My.Settings.Koerpergroesse = TextBox3.Text
            My.Settings.Maennlich = RadioButton1.Checked
            My.Settings.Save()
            My.Settings.Reload()
            Me.Update()

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox5.Clear()
        TextBox11.Clear()
        TextBox4.Clear()

        TextBox1.BackColor = Color.White
        TextBox2.BackColor = Color.White
        TextBox3.BackColor = Color.White

        TextBox12.Select()

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 46
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 46
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 46
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox13_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox13.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 46
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 46
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox15.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 46
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub TextBox16_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox16.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 46
            Case Else
                e.Handled = True
        End Select
    End Sub

End Class
