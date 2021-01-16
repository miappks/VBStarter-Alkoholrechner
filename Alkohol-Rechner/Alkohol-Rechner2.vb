Public Class Alkohol_Rechner2


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


        If TextBox1.Text = "" Then
            TextBox1.BackColor = Color.Red
        Else TextBox1.BackColor = Color.White
        End If

        If TextBox2.Text = "" Then
            TextBox2.BackColor = Color.Red
        Else TextBox2.BackColor = Color.White
        End If

        If TextBox3.Text = "" Then
            TextBox3.BackColor = Color.Red
        Else TextBox3.BackColor = Color.White
        End If



        If TextBox1.Text IsNot "" And TextBox2.Text IsNot "" And TextBox3.Text IsNot "" And
            RadioButton1.Checked = True Then

            i = 2.447 - 0.09516 * TextBox2.Text + 0.1074 * TextBox3.Text + 0.3362 * TextBox1.Text

            If TextBox12.Text = "" Then
                Bier = 0
            Else
                Bier = TextBox12.Text
            End If

            If TextBox13.Text = "" Then
                Wein = 0
            Else
                Wein = TextBox13.Text
            End If
            If TextBox14.Text = "" Then
                Liqueur = 0
            Else
                Liqueur = TextBox14.Text
            End If
            If TextBox15.Text = "" Then
                Schnaps1 = 0
            Else
                Schnaps1 = TextBox15.Text
            End If
            If TextBox16.Text = "" Then
                Schnaps2 = 0
            Else
                Schnaps2 = TextBox16.Text
            End If

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
            My.Settings.Maennlich = True
            My.Settings.Save()
            My.Settings.Reload()
            Me.Update()


        ElseIf TextBox1.Text IsNot "" And TextBox2.Text IsNot "" And TextBox3.Text IsNot "" And
            RadioButton2.Checked = True Then
            i = -2.097 + 0.1069 * TextBox3.Text + 0.2466 * TextBox1.Text

            If TextBox12.Text = "" Then
                Bier = 0
            Else
                Bier = TextBox12.Text
            End If

            If TextBox13.Text = "" Then
                Wein = 0
            Else
                Wein = TextBox13.Text
            End If
            If TextBox14.Text = "" Then
                Liqueur = 0
            Else
                Liqueur = TextBox14.Text
            End If
            If TextBox15.Text = "" Then
                Schnaps1 = 0
            Else
                Schnaps1 = TextBox15.Text
            End If
            If TextBox16.Text = "" Then
                Schnaps2 = 0
            Else
                Schnaps2 = TextBox16.Text
            End If

            Alk = (Bier / 25) + (Wein / 12) + (Liqueur / 5) + (Schnaps1 / 4) + (Schnaps2 / 3)
            r = (1.055 * i) / (0.8 * TextBox1.Text)
            Promille = (Alk) / (TextBox1.Text * r)

            TextBox5.Text = Math.Round(r, 2)
            TextBox11.Text = Alk
            TextBox4.Text = Math.Round(Promille, 2)

            If TextBox4.Text > 3.4 Then
                MsgBox("Alkohol kann ab 3.5 Promille tödlich sein!", MsgBoxStyle.Critical, "Info")
            End If

            My.Settings.Gewicht = TextBox1.Text
            My.Settings.Alter = TextBox2.Text
            My.Settings.Koerpergroesse = TextBox3.Text
            My.Settings.Maennlich = False
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
        Else
            RadioButton1.Checked = True
        End If
        If TextBox1.Text IsNot "" Then
            TextBox12.Select()
        End If


    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
