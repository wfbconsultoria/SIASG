Imports System.Net
Imports System.IO
Imports System.Net.Http

Public Class clsMaster
    Implements IDisposable
    Private disposedValue As Boolean

    Private cnn As New Npgsql.NpgsqlConnection 'Conexão Postgres
    Private Const cnnStr As String = "Server=paris.datasus.net.br;Port=5432;UserId=bih_datasus;Password=Mepm2412;Database=bih_datasus"
    Public Const schema As String = "SIASG"

    'Public Const pasta_downloads As String = "/home/bih_datasus/SIASG/SIASG/DOWNLOADS/"
    Public Const pasta_downloads As String = "D:\DOWNLOADS"
    Public Const MyURL As String = "http://compras.dados.gov.br/materiais/v1/grupos.csv"
    Private Shared ReadOnly HttpClient As HttpClient = New HttpClient()

    Public Function ConectaBanco() As Boolean
        Try
            cnn = New Npgsql.NpgsqlConnection(cnnStr)
            cnn.Open()
            ConectaBanco = True
        Catch e As Exception
            ConectaBanco = False
        Finally
        End Try
    End Function

    Public Function ExecuteSQL(SQL As String) As Boolean
        SQL = ConverteSQL_PSQL(SQL)

        ExecuteSQL = False

        Dim cnn2 As New Npgsql.NpgsqlConnection(cnnStr)
        cnn2.Open()

        Try
            Dim cmd2 As Npgsql.NpgsqlCommand = cnn2.CreateCommand
            cmd2.CommandText = SQL
            cmd2.ExecuteNonQuery()
            ExecuteSQL = True
        Catch e As Exception
            ExecuteSQL = False
        Finally
            cnn2.Close()
        End Try

    End Function

    Public Function ExecuteSelect(SQL As String) As Npgsql.NpgsqlDataReader
        SQL = ConverteSQL_PSQL(SQL)
        Try
            If Not IsNothing(cnn) Then
                If cnn.State = Data.ConnectionState.Open Then cnn.Close()
            End If
            ConectaBanco()
            Dim cmd As Npgsql.NpgsqlCommand = cnn.CreateCommand
            cmd.Connection = cnn
            cmd.CommandText = SQL
            ExecuteSelect = cmd.ExecuteReader
        Catch e As Exception
            ExecuteSelect = Nothing
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
    Public Function Download(remoteUri As String, filename As String) As Boolean
        Try
            Using myWebClient As New WebClient()
                myWebClient.DownloadFile(remoteUri, filename)
            End Using
            Download = True
        Catch e As Exception
            Download = False
        Finally

        End Try
    End Function

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Não altere este código. Coloque o código de limpeza no método 'Dispose(disposing As Boolean)'
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Não altere este código. Coloque o código de limpeza no método 'Dispose(disposing As Boolean)'
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class

