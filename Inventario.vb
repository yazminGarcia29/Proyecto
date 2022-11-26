Imports System.Data.OracleClient
Public Class Inventario
    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call cargarRegistros()
    End Sub

    Private Sub cargarRegistros()
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("SELECT PRODUCTOS.NOMBRE, PRODUCTOS.CANTIDAD AS STOCK, PRODUCTOS.PRECIO, CATEGORIAS.NOM_CATEGORIA AS CATEGORIA
                                            FROM PRODUCTOS, CATEGORIAS
                                            WHERE PRODUCTOS.ID_CATEGORIA = CATEGORIAS.ID_CATEGORIA", conecta)
        Dim ds As New DataSet
        datos.Fill(ds, "Prueba")



        Me.DataGridView1.DataSource = ds.Tables("Prueba")
        Me.DataGridView1.Columns.Item(0).Width = 170
        Me.DataGridView1.Columns.Item(1).Width = 170
        Me.DataGridView1.Columns.Item(2).Width = 149
        Me.DataGridView1.Columns.Item(3).Width = 148


        conecta.Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("SELECT PRODUCTOS.NOMBRE, PRODUCTOS.CANTIDAD AS STOCK, PRODUCTOS.PRECIO, CATEGORIAS.NOM_CATEGORIA AS CATEGORIA
                                            FROM PRODUCTOS, CATEGORIAS
                                            WHERE PRODUCTOS.ID_CATEGORIA = CATEGORIAS.ID_CATEGORIA and PRODUCTOS.CANTIDAD > 0", conecta)
        Dim ds As New DataSet
        datos.Fill(ds, "Prueba")



        Me.DataGridView1.DataSource = ds.Tables("Prueba")
        Me.DataGridView1.Columns.Item(0).Width = 170
        Me.DataGridView1.Columns.Item(1).Width = 170
        Me.DataGridView1.Columns.Item(2).Width = 149
        Me.DataGridView1.Columns.Item(3).Width = 148


        conecta.Close()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("SELECT PRODUCTOS.NOMBRE, PRODUCTOS.CANTIDAD AS STOCK, PRODUCTOS.PRECIO, CATEGORIAS.NOM_CATEGORIA AS CATEGORIA
                                            FROM PRODUCTOS, CATEGORIAS
                                            WHERE PRODUCTOS.ID_CATEGORIA = CATEGORIAS.ID_CATEGORIA", conecta)
        Dim ds As New DataSet
        datos.Fill(ds, "Prueba")



        Me.DataGridView1.DataSource = ds.Tables("Prueba")
        Me.DataGridView1.Columns.Item(0).Width = 170
        Me.DataGridView1.Columns.Item(1).Width = 170
        Me.DataGridView1.Columns.Item(2).Width = 149
        Me.DataGridView1.Columns.Item(3).Width = 148


        conecta.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("SELECT PRODUCTOS.NOMBRE, PRODUCTOS.CANTIDAD AS STOCK, PRODUCTOS.PRECIO, CATEGORIAS.NOM_CATEGORIA AS CATEGORIA
                                            FROM PRODUCTOS, CATEGORIAS
                                            WHERE PRODUCTOS.ID_CATEGORIA = CATEGORIAS.ID_CATEGORIA and PRODUCTOS.CANTIDAD = 0", conecta)
        Dim ds As New DataSet
        datos.Fill(ds, "Prueba")



        Me.DataGridView1.DataSource = ds.Tables("Prueba")
        Me.DataGridView1.Columns.Item(0).Width = 170
        Me.DataGridView1.Columns.Item(1).Width = 170
        Me.DataGridView1.Columns.Item(2).Width = 149
        Me.DataGridView1.Columns.Item(3).Width = 148


        conecta.Close()
    End Sub
End Class