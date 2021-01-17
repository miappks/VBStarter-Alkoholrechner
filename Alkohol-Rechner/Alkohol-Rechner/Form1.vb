Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.Farbe = "Blue" Then
            ToolStrip1.BackColor = Color.GreenYellow
            Info.BackColor = Color.GreenYellow
            Button1.BackColor = Color.YellowGreen
            Button3.BackColor = Color.Orange
            ToolStripMenuItem4.BackColor = SystemColors.ActiveCaption
            Me.BackColor = Color.LightBlue

        Else
            Me.BackColor = SystemColors.Control
            ToolStripMenuItem3.BackColor = SystemColors.ActiveCaption
        End If

        TextBox1.Text = My.Settings.Gewicht
        TextBox2.Text = My.Settings.Alter
        TextBox3.Text = My.Settings.Koerpergroesse

        If My.Settings.Maennlich = False Then
            RadioButton2.Checked = True
        End If

        If TextBox1.Text IsNot "" Then
            TextBox4.Select()
        End If

        Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Double
        Dim r As Double
        Dim Alk As Double

        TextBox1.BackColor = If(TextBox1.Text = "", Color.Red, Color.White)
        TextBox2.BackColor = If(TextBox2.Text = "", Color.Red, Color.White)
        TextBox3.BackColor = If(TextBox3.Text = "", Color.Red, Color.White)
        TextBox4.BackColor = If(TextBox4.Text = "", Color.Red, Color.White)

        If TextBox1.Text IsNot "" And TextBox2.Text IsNot "" And TextBox3.Text IsNot "" And TextBox4.Text IsNot "" Then

            If RadioButton1.Checked = True Then 'männlich
                i = 2.447 - 0.09516 * TextBox2.Text + 0.1074 * TextBox3.Text + 0.3362 * TextBox1.Text
            Else 'weiblich
                i = -2.097 + 0.1069 * TextBox3.Text + 0.2466 * TextBox1.Text
            End If

            r = (1.055 * i) / (0.8 * TextBox1.Text)

            Alk = TextBox4.Text * TextBox1.Text * r
            TextBox5.Text = Math.Round(r, 2)
            TextBox11.Text = Math.Round(Alk, 2)
            TextBox10.Text = Math.Round(Alk * 25, 0)
            TextBox9.Text = Math.Round(Alk * 12, 0)
            TextBox8.Text = Math.Round(Alk * 5, 0)
            TextBox7.Text = Math.Round(Alk * 4, 0)
            TextBox6.Text = Math.Round(Alk * 3, 0)

            If TextBox4.Text > 3.4 Then 'Warning
                MsgBox("Alkohol kann ab 3.5 Promille tödlich sein!", MsgBoxStyle.Critical, "Achtung")
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

        TextBox4.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox10.Clear()
        TextBox11.Clear()
        TextBox5.Clear()

        TextBox1.BackColor = Color.White
        TextBox2.BackColor = Color.White
        TextBox3.BackColor = Color.White
        TextBox4.BackColor = Color.White

        TextBox4.Select()

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles Info.Click
        Dialog1.Show()
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles PromilleRechner.Click
        Alkohol_Rechner2.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        My.Settings.Farbe = ""
        My.Settings.Save()
        My.Settings.Reload()
        Me.Update()

        ToolStripMenuItem3.BackColor = SystemColors.ActiveCaption
        ToolStripMenuItem4.BackColor = SystemColors.Control

        Me.BackColor = SystemColors.Control
        ToolStrip1.BackColor = SystemColors.Control
        Info.BackColor = SystemColors.Control
        Button1.BackColor = Color.Gainsboro
        Button3.BackColor = Color.Gainsboro
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        My.Settings.Farbe = "Blue"
        My.Settings.Save()
        My.Settings.Reload()
        Me.Update()
        ToolStripMenuItem4.BackColor = SystemColors.ActiveCaption
        ToolStripMenuItem3.BackColor = SystemColors.Control

        ToolStrip1.BackColor = Color.GreenYellow
        Info.BackColor = Color.GreenYellow
        Button1.BackColor = Color.YellowGreen
        Button3.BackColor = Color.Orange
        Me.BackColor = Color.LightBlue

        'Me.BackColor = Color.FromArgb(192, 192, 255)
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


    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 46

            Case Else
                e.Handled = True
        End Select
    End Sub

End Class
