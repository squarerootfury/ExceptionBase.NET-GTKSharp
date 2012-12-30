﻿Imports ExceptionBase

Public Class MainForm
    Dim ExBase As New ExceptionBase("", 1, ProductVersion.ToString, My.Resources.bug)

    ''' <summary>
    ''' Versucht, einen Integer mit dem Wert "Hallo Welt" zu definieren
    ''' und fängt den dabei entstandenen Fehler ab.
    ''' </summary>
    Private Sub testDoubleToString(sender As Object, e As EventArgs) Handles btnDoubleToStringError.Click
        Try
            Dim test As Integer = "Hallo Welt"
        Catch ex As Exception
            ExBase.Track(ex, True)
        End Try
    End Sub

    ''' <summary>
    ''' Versucht, eine nicht existierende Datei zu lesen
    ''' und fängt den dabei entstandenen Fehler ab.
    ''' </summary>
    Private Sub textNonexistentFile(sender As Object, e As EventArgs) Handles btnNonexistentFileError.Click
        Try
            Dim test As String = My.Computer.FileSystem.ReadAllText("C:\SomeNonExistentPath\That\WillNever\Exist.txt")
        Catch ex As Exception
            ExBase.Track(ex, True)
        End Try
    End Sub

    ''' <summary>
    ''' Überprüft die Serveradresse und (de-)aktiviert
    ''' daraufhin die Test-Buttons. Ist die Adresse korrekt,
    ''' werden Serveradresse und AppID in Exceptionbase.NET übernommen.
    ''' </summary>
    Private Sub validateServerAdress(sender As Object, e As EventArgs) Handles tbDatabaseAdress.TextChanged
        If tbDatabaseAdress.Text Like "http*://*.*/api/addException.php" Then
            ExBase.Server.Server = tbDatabaseAdress.Text
            ExBase.Application.ID = nudAppID.Value
            btnDoubleToStringError.Enabled = True
            btnNonexistentFileError.Enabled = True
        Else
            btnDoubleToStringError.Enabled = False
            btnNonexistentFileError.Enabled = False
        End If
    End Sub
End Class