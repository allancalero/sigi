Imports MySql.Data.MySqlClient
Module conexionbase
    Public conex As New MySqlConnection
    Public ds As DataSet = New DataSet
    Public da As MySqlDataAdapter
    Public comando As MySqlCommand
    Dim conectar As String

    Sub conexion()
        conectar = "server=localhost;user=root;password='8787';database=inventario"
        Try
            conex.ConnectionString = conectar
            conex.Open()
            MsgBox("Conexion Sastifactoria")

        Catch ex As Exception
            MsgBox("Error de contraseña" + ex.Message)
        End Try
    End Sub

    Sub consultas(ByVal Sql As String, ByVal Tabla As String)
        Try
            ds.Tables.Clear()
            da = New MySqlDataAdapter(Sql, conex)
            da.Fill(ds, Tabla)
        Catch ex As Exception

        End Try

    End Sub

End Module
