Imports System
Imports System.IO


Module Program
    Sub Main()
        Console.WriteLine(cnnStr())
        Console.Read()
    End Sub

    Function cnnStr() As String
        'L� arquivo de configura��o para recuperar a string de conex�o
        cnnStr = ""
        Dim arquivo As String = "/home/bih_datasus/SIASG/SIASG/SIASG_CONFIG.txt"
        Dim fluxoTexto As IO.StreamReader
        Console.WriteLine(arquivo)
        Console.WriteLine("ARQUIVO COMPILADO NOVAMENTE")
        If IO.File.Exists(arquivo) Then
            fluxoTexto = New IO.StreamReader(arquivo)
            cnnStr = fluxoTexto.ReadLine
            fluxoTexto.Close()
        Else
            Console.WriteLine("Arquivo de configura��o ausente")
            Console.WriteLine("ARQUIVO COMPILADO NOVAMENTE")
        End If

    End Function

End Module
