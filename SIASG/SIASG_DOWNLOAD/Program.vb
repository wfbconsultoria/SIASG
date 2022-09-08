Imports System.Reflection.Emit

Module Program
    Public cnn As New Npgsql.NpgsqlConnection
    Public schema As String = "SIASG"
    Public tabela As String = "TB_LOG"
    Public processo As String = "DOWNLOAD"
    Public strSql As String = ""

    Sub Main()
        Console.Title = processo
        Console.BackgroundColor = ConsoleColor.Green
        ConectaBanco()

        Do
            ExecuteSQL(strSql)
            Console.WriteLine(processo & " - " & Now() & " - OK")
        Loop

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

        Catch e As Exception
            'LogErro(e)
            ConectaBanco = False
            Console.WriteLine(e.ToString)

        Finally
        End Try

    End Function

    Public Function ExecuteSQL(SQL As String) As Boolean
        SQL = ConverteSQL_PSQL(SQL)
        Try
            ExecuteSQL = False
            Dim cmd As Npgsql.NpgsqlCommand = cnn.CreateCommand
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
            ExecuteSQL = True
        Catch e As Exception
            ExecuteSQL = False
            'LogErro(e, SQL)
        Finally

        End Try

    End Function

    Function ConverteSQL_PSQL(SQL As String) As String
        Try
            SQL = Replace(SQL, "[", Chr(34))
            SQL = Replace(SQL, "]", Chr(34))
        Catch
            SQL = ""
        End Try
        ConverteSQL_PSQL = SQL
    End Function
End Module
