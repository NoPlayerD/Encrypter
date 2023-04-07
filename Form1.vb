﻿Imports System.IO
Imports System.Security.Cryptography
Imports System.IO.MemoryStream

Public Class Form1

    Private enc As System.Text.UTF8Encoding
    Private encryptor As ICryptoTransform
    Private decryptor As ICryptoTransform

    Dim def_key As Byte() = {43, 2, 53, 68, 231, 13, 94, 101, 123, 6, 0, 12, 32, 91, 4, 111, 31, 70, 21, 141, 123, 142, 234, 82, 95, 129, 187, 162, 12, 55, 98, 23}
    Dim def_iv As Byte() = {235, 13, 53, 45, 214, 222, 200, 109, 2, 98, 45, 76, 88, 53, 23, 78}

    Dim KEY_128 As Byte()
    Dim IV_128 As Byte()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim sPlainText As String = RichTextBox1.Text
            If Not String.IsNullOrEmpty(sPlainText) Then
                Dim memoryStream As MemoryStream = New MemoryStream()
                Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, Me.encryptor, CryptoStreamMode.Write)
                cryptoStream.Write(Me.enc.GetBytes(sPlainText), 0, sPlainText.Length)
                cryptoStream.FlushFinalBlock()
                RichTextBox1.Text = Convert.ToBase64String(memoryStream.ToArray())
                memoryStream.Close()
                cryptoStream.Close()
            Else
                MsgBox("Please enter a valid text to encrypt..", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            MsgBox("Please enter a valid text to encrypt..", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim cypherTextBytes As Byte() = Convert.FromBase64String(RichTextBox1.Text)
            Dim memoryStream As MemoryStream = New MemoryStream(cypherTextBytes)
            Dim cryptoStream As CryptoStream = New CryptoStream(memoryStream, Me.decryptor, CryptoStreamMode.Read)
            Dim plainTextBytes(cypherTextBytes.Length) As Byte
            Dim decryptedByteCount As Integer = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length)
            memoryStream.Close()
            cryptoStream.Close()
            RichTextBox1.Text = Me.enc.GetString(plainTextBytes, 0, decryptedByteCount)
        Catch ex As Exception
            MsgBox("Please enter a valid encrypted text..", MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            My.Computer.Clipboard.SetText(RichTextBox1.Text)
            MsgBox("Succesfully copied text..", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Error..", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not My.Settings.key = vbNullString And Not My.Settings.iv = vbNullString Then
            If File.Exists(My.Settings.key) And File.Exists(My.Settings.iv) Then
                KEY_128 = Utils.ReadFile(My.Settings.key) 'encrypt parameters
                IV_128 = Utils.ReadFile(My.Settings.iv) 'encrypt parameters
            End If
        Else
            KEY_128 = def_key 'encrypt parameters
            IV_128 = def_iv 'encrypt parameters
        End If

        Dim symmetricKey As RijndaelManaged = New RijndaelManaged()
        symmetricKey.Mode = CipherMode.CBC

        Me.enc = New System.Text.UTF8Encoding
        Me.encryptor = symmetricKey.CreateEncryptor(KEY_128, IV_128)
        Me.decryptor = symmetricKey.CreateDecryptor(KEY_128, IV_128)
    End Sub
End Class
