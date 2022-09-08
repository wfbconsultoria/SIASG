Module Program
    Public cnn As New Npgsql.NpgsqlConnection
    Sub Main()
        Console.Title = "IMPORT"
        Console.BackgroundColor = ConsoleColor.Blue
        ConectaBanco()
    End Sub

    Function CnnStr() As String
        CnnStr = ""
        Try
            'L� arquivo de configura��o para recuperar a string de conex�o
            Dim cnnConfig As String = "D:\GitHub_SIASG\SIASG\SIASG_CONFIG.txt"
            'Dim cnnConfig As String = "/home/bih_datasus/SIASG/SIASG_CONFIG.txt"
            Dim fi As New IO.StreamReader(cnnConfig)
            CnnStr = fi.ReadLine
            fi.Close()
        Catch e As Exception
            Console.WriteLine(e.ToString)
        Finally
        End Try
    End Function

    Function ConectaBanco() As Boolean
        Try
            'Conex�o Postgres
            cnn = New Npgsql.NpgsqlConnection(CnnStr)
            cnn.Open()
            ConectaBanco = True
            Console.WriteLine("OK")

        Catch e As Exception
            'LogErro(e)
            ConectaBanco = False
            Console.WriteLine(e.ToString)

        Finally
        End Try

    End Function

End Module
