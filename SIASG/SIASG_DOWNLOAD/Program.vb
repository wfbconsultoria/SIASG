Imports System
Imports System.IO


Module Program
    Sub Main()
        Console.WriteLine(cnnStr())
        Console.Read()
    End Sub

    Function cnnStr() As String
        'Lê arquivo de configuração para recuperar a string de conexão
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
            Console.WriteLine("Arquivo de configuração ausente")
            Console.WriteLine("ARQUIVO COMPILADO NOVAMENTE")
        End If

    End Function

End Module
