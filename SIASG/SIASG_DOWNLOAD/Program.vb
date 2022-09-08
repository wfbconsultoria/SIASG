
Module Program
    Public cnn As New Npgsql.NpgsqlConnection
    Sub Main()
        ConectaBanco()
    End Sub

    Function CnnStr() As String
        CnnStr = ""
        Try
            'Lê arquivo de configuração para recuperar a string de conexão
            'Dim cnnConfig As String = "D:\GitHub_SIASG\SIASG\SIASG_CONFIG.txt"
            Dim cnnConfig As String = "/home/bih_datasus/SIASG/SIASG_CONFIG.txt"
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
            'Conexão Postgres
            cnn = New Npgsql.NpgsqlConnection(CnnStr)
            cnn.Open()
            ConectaBanco = True
            Console.WriteLine("OK")
            Console.Read()
        Catch e As Exception
            'LogErro(e)
            ConectaBanco = False
            Console.WriteLine(e.ToString)
            Console.Read()
        Finally
        End Try

    End Function

End Module
