Imports System.Data.OracleClient
Public Class LISTADOCLIENTES
    Private Sub LISTADOCLIENTES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call cargarRegistros()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Sub cargarRegistros()
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("select * from Clientes", conecta)
        Dim ds As New DataSet
        datos.Fill(ds, "Prueba")



        Me.DataGridView1.DataSource = ds.Tables("Prueba")
        Me.DataGridView1.Columns.Item(0).Width = 70
        Me.DataGridView1.Columns.Item(1).Width = 90
        Me.DataGridView1.Columns.Item(2).Width = 90
        Me.DataGridView1.Columns.Item(3).Width = 90
        Me.DataGridView1.Columns.Item(4).Width = 90
        Me.DataGridView1.Columns.Item(5).Width = 90
        Me.DataGridView1.Columns.Item(6).Width = 90



        conecta.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim conecta As New OracleConnection
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            Dim datos As New OracleDataAdapter("SELECT * FROM CLIENTES WHERE RFC LIKE '%" & TextBox1.Text & "%'", conecta)
            Dim ds As New DataSet
            datos.Fill(ds, "Prueba")



            Me.DataGridView1.DataSource = ds.Tables("Prueba")
            Me.DataGridView1.Columns.Item(0).Width = 70
            Me.DataGridView1.Columns.Item(1).Width = 90
            Me.DataGridView1.Columns.Item(2).Width = 90
            Me.DataGridView1.Columns.Item(3).Width = 90
            Me.DataGridView1.Columns.Item(4).Width = 90
            Me.DataGridView1.Columns.Item(5).Width = 90
            Me.DataGridView1.Columns.Item(6).Width = 90
            conecta.Close()
        Catch ex As OracleException
            MessageBox.Show("Error verifique los datos")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index



            Ventas.TextBox1.Text = i
            Ventas.TextBox1.Text = DataGridView1.Item(0, i).Value()

            Ventas.TextBox2.Text = DataGridView1.Item(2, i).Value()
            Ventas.TextBox3.Text = DataGridView1.Item(3, i).Value()
            Ventas.TextBox4.Text = DataGridView1.Item(4, i).Value()
            Ventas.TextBox5.Text = DataGridView1.Item(5, i).Value()
            Ventas.TextBox6.Text = DataGridView1.Item(6, i).Value()
            Ventas.ComboBox1.Text = DataGridView1.Item(1, i).Value()
        Catch ex As Exception



        End Try
    End Sub
End Class