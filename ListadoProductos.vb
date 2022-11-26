Imports System.Data.OracleClient
Public Class ListadoProductos
    Private Sub ListadoProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call cargarRegistros()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub cargarRegistros()
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("SELECT ID_PRODUCTO, CATEGORIAS.NOM_CATEGORIA AS CATEGORIA, PRODUCTOS.NOMBRE, PRODUCTOS.PRECIO, PRODUCTOS.CANTIDAD
                                            FROM PRODUCTOS, CATEGORIAS
                                            WHERE PRODUCTOS.ID_CATEGORIA = CATEGORIAS.ID_CATEGORIA", conecta)
        Dim ds As New DataSet
        datos.Fill(ds, "Prueba")



        Me.DataGridView1.DataSource = ds.Tables("Prueba")
        Me.DataGridView1.Columns.Item(0).Width = 90
        Me.DataGridView1.Columns.Item(1).Width = 150
        Me.DataGridView1.Columns.Item(2).Width = 150
        Me.DataGridView1.Columns.Item(3).Width = 100
        Me.DataGridView1.Columns.Item(4).Width = 100

        conecta.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim conecta As New OracleConnection
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            Dim datos As New OracleDataAdapter("SELECT * FROM PRODUCTOS WHERE NOMBRE LIKE '%" & TextBox1.Text & "%'", conecta)
            Dim ds As New DataSet
            datos.Fill(ds, "Prueba")



            Me.DataGridView1.DataSource = ds.Tables("Prueba")
            Me.DataGridView1.Columns.Item(0).Width = 90
            Me.DataGridView1.Columns.Item(1).Width = 150
            Me.DataGridView1.Columns.Item(2).Width = 150
            Me.DataGridView1.Columns.Item(3).Width = 100
            Me.DataGridView1.Columns.Item(4).Width = 100
            conecta.Close()
        Catch ex As OracleException
            MessageBox.Show("Error verifique los datos")
        End Try
    End Sub
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index



            ConceptoVenta.Label1.Text = i
            ConceptoVenta.Label1.Text = DataGridView1.Item(0, i).Value()
            ConceptoVenta.Label2.Text = DataGridView1.Item(3, i).Value()


        Catch ex As Exception



        End Try
    End Sub
End Class