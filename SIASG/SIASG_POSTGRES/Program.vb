
Imports System.Data

Module Program
    Public Id_Grupo As Integer = 1 'FORNECEDORES
    Public processo As String = "teste"
    Public tabela As String = "TB_LOG"
    Public vw_download As String = ""
    ReadOnly m As New SIASG.clsMaster
    Sub Main()



        Try

            m.DownloadAsync()
        Catch e As Exception
            Console.WriteLine(e.ToString)
        Finally
            m.Dispose()
        End Try

    End Sub
End Module
