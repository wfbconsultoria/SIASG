
Imports System.Data

Module Program
    Public Id_Grupo As Integer = 1 'FORNECEDORES
    Public processo As String = "teste"
    Public tabela As String = "TB_LOG"
    Public vw_download As String = ""

    Sub Main(args As String())

        Dim A As New SIASG.CLS_SIASG

        Dim X As Integer
        Try
            For X = 1 To 100
                A.ExecuteSQL("INSERT INTO [" & A.schema & "]." & "[" & tabela & "] ([PROCESSO]) Values ('" & processo & "')")
                Console.WriteLine(processo & " - " & Now() & " - inserindo")
            Next

            Dim dtr As Npgsql.NpgsqlDataReader = A.ExecuteSelect("SELECT * FROM [" & A.schema & "]." & "[" & tabela & "]")
            If dtr.HasRows Then
                Do While dtr.Read()
                    Console.WriteLine(processo & " - " & Now() & " - " & dtr("ID").ToString & " - " & "LENDO")
                Loop
            End If

        Catch e As Exception
            Console.WriteLine(e.ToString)
        Finally
            A.Dispose()
        End Try

    End Sub
End Module
