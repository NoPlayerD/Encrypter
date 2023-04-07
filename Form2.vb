Imports System.IO
Public Class Form2
    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim path As String
        OpenFileDialog1.ShowDialog()
        If Not OpenFileDialog1.FileName = vbNullString Then
            path = OpenFileDialog1.FileName
            My.Settings.key = path
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not File.Exists(My.Settings.key) And Not File.Exists(My.Settings.iv) Then
            My.Settings.key = vbNullString
            My.Settings.iv = vbNullString
        End If

        If Not TextBox1.Text = My.Settings.key Then
            TextBox1.Text = My.Settings.key
        End If
        If Not TextBox2.Text = My.Settings.iv Then
            TextBox2.Text = My.Settings.iv
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim path As String
        OpenFileDialog2.ShowDialog()
        If Not OpenFileDialog2.FileName = vbNullString Then
            path = OpenFileDialog2.FileName
            My.Settings.iv = path
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim d As New FolderBrowserDialog
        Dim rnd As New Random
        Dim first, second, third, fourth As Integer
        Dim key As Byte()

        first = rnd.Next(1, 100)
        second = rnd.Next(1, 100)
        third = rnd.Next(1, 100)
        fourth = rnd.Next(1, 100)

        key = {first, 2, second, 68, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, third, 98, fourth}

        d.ShowDialog()
        If Not d.SelectedPath = vbNullString Then
            Try
                Utils.SaveFile(d.SelectedPath + "\key.dll", key)
            Catch ex As Exception
                MsgBox("Error..", MsgBoxStyle.Critical)
            End Try
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim d As New FolderBrowserDialog
        Dim rnd As New Random
        Dim first, second, third, fourth As Integer
        Dim key As Byte()

        first = rnd.Next(1, 100)
        second = rnd.Next(1, 100)
        third = rnd.Next(1, 100)
        fourth = rnd.Next(1, 100)

        key = {235, first, second, 45, 214, 222, 200, 109, 2, third, 45, 76, fourth, 53, 23, 78}

        d.ShowDialog()
        If Not d.SelectedPath = vbNullString Then
            Try
                Utils.SaveFile(d.SelectedPath + "\iv.dll", key)
            Catch ex As Exception
                MsgBox("Error..", MsgBoxStyle.Critical)
            End Try
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.key = vbNullString
        My.Settings.iv = vbNullString
    End Sub
End Class