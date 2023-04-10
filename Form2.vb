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
        d.Description = "Select a KEY dll"
        Dim rnd As New Random
        Dim keys(35) As Integer
        Dim key As Byte()

        For i As Integer = 0 To 35
            keys(i) = rnd.Next(1, 200)
        Next

        key = {keys(1), keys(2), keys(3), keys(4), keys(5), keys(6), keys(7), keys(8), keys(9), keys(10), keys(11), keys(12), keys(13), keys(14), keys(15), keys(16), keys(17), keys(18), keys(19), keys(20), keys(21), keys(22), keys(23), keys(24), keys(25), keys(26), keys(27), keys(28), keys(29), keys(30), keys(31), keys(32)}

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
        d.Description = "Select a IV dll"
        Dim rnd As New Random
        Dim ivs(16) As Integer
        Dim iv As Byte()

        For i As Integer = 0 To 16
            ivs(i) = rnd.Next(1, 200)
        Next

        iv = {ivs(1), ivs(2), ivs(3), ivs(4), ivs(5), ivs(6), ivs(7), ivs(8), ivs(9), ivs(10), ivs(11), ivs(12), ivs(13), ivs(14), ivs(15), ivs(16)}

        d.ShowDialog()
        If Not d.SelectedPath = vbNullString Then
            Try
                Utils.SaveFile(d.SelectedPath + "\iv.dll", iv)
            Catch ex As Exception
                MsgBox("Error..", MsgBoxStyle.Critical)
            End Try
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.key = vbNullString
        My.Settings.iv = vbNullString
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim b As New FolderBrowserDialog
        b.Description = "Select a folder containing the IV and KEY dll"
        b.ShowDialog()
        If Not b.SelectedPath = vbNullString Then
            Try
                My.Settings.key = b.SelectedPath & "\key.dll"
                My.Settings.iv = b.SelectedPath & "\iv.dll"
            Catch ex As Exception
                MsgBox("Please select a valid folder contains key and iv dll", MsgBoxStyle.Critical)
            End Try
        End If

    End Sub
End Class