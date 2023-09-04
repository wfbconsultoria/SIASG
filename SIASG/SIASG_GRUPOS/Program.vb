Imports System

Module Program
    Private Const TITULO As String = "GRUPOS"
    ReadOnly m As New SIASG.clsMaster
    Sub Main()
        Console.Title = TITULO & "Inicio: " & Now()
        Console.WriteLine(TITULO & " Inicio: " & Now())

    End Sub
End Module
