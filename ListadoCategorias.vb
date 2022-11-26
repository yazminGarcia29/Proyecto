Imports System.Data.OracleClient
Public Class ListadoCategorias
    Private Sub ListadoCategorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call cargarRegistros()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim conecta As New OracleConnection
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            Dim datos As New OracleDataAdapter("SELECT * FROM CATEGORIAS WHERE NOM_CATEGORIA LIKE '%" & TextBox1.Text & "%'", conecta)
            Dim ds As New DataSet
            datos.Fill(ds, "Prueba")



            Me.DataGridView1.DataSource = ds.Tables("Prueba")
            Me.DataGridView1.Columns.Item(0).Width = 150
            Me.DataGridView1.Columns.Item(1).Width = 450

            conecta.Close()
        Catch ex As OracleException
            MessageBox.Show("Error verifique los datos")
        End Try
    End Sub
    Private Sub cargarRegistros()
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("SELECT ID_CATEGORIA, NOM_CATEGORIA
                                            FROM CATEGORIAS", conecta)
        Dim ds As New DataSet
        datos.Fill(ds, "Prueba")



        Me.DataGridView1.DataSource = ds.Tables("Prueba")
        Me.DataGridView1.Columns.Item(0).Width = 150
        Me.DataGridView1.Columns.Item(1).Width = 400

        conecta.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class