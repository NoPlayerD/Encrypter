Option Strict On
Option Explicit On
Namespace Global.Utils
    Public Module modUtils
        ''' <summary>
        ''' Reads a file at the given path into a byte array
        ''' </summary>
        ''' <param name="filePath">The path of the file to be read</param>
        ''' <param name="shareOption">Determines how the file will be shared by processes</param>
        ''' <returns>The contents of the file as a byte array</returns>
        Public Function ReadFile(filePath As String, Optional shareOption As System.IO.FileShare = System.IO.FileShare.None) As Byte()
            Dim fileBytes() As Byte

            Using fs = New System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, shareOption)
                ReDim fileBytes(CInt(fs.Length - 1))
                fs.Read(fileBytes, 0, fileBytes.Length)
            End Using

            Return fileBytes
        End Function

        ''' <summary>
        ''' Saves a file at the given path with the contents of the byte array
        ''' </summary>
        ''' <param name="filePath">The path of the file to be saved</param>
        ''' <param name="fileBytes">The byte array containing the file contents</param>
        ''' <param name="shareOption">Determines how the file will be shared by processes</param>
        Public Sub SaveFile(filePath As String, fileBytes As Byte(), Optional shareOption As System.IO.FileShare = System.IO.FileShare.None)
            Using fs = New System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write, shareOption)
                fs.Write(fileBytes, 0, fileBytes.Length)
            End Using
        End Sub
    End Module
End Namespace
