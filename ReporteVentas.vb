Imports System.Data.OracleClient
Public Class ReporteVentas
    Private Sub ReporteVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call cargarRegistros()
    End Sub
    Private Sub cargarRegistros()
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("SELECT IDVENTA, CLIENTES.RFC, CLIENTES.NOMBRE, VENTA.TOTAL, VENTA.FECHA
                                            FROM VENTA, CLIENTES
                                            WHERE VENTA.RFC = CLIENTES.RFC", conecta)
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

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("SELECT IDVENTA, CLIENTES.RFC, CLIENTES.NOMBRE, VENTA.TOTAL,VENTA.FECHA
                                            FROM VENTA, CLIENTES
                                            WHERE VENTA.RFC = CLIENTES.RFC", conecta)
        Dim ds As New DataSet
        datos.Fill(ds, "Prueba")



        Me.DataGridView1.DataSource = ds.Tables("Prueba")
        Me.DataGridView1.Columns.Item(0).Width = 90
        Me.DataGridView1.Columns.Item(1).Width = 150
        Me.DataGridView1.Columns.Item(2).Width = 150
        Me.DataGridView1.Columns.Item(3).Width = 100
        Me.DataGridView1.Columns.Item(4).Width = 100

        If RadioButton1.Checked = True Then
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        Else
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        End If

        conecta.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("SELECT IDVENTA, CLIENTES.RFC, CLIENTES.NOMBRE, VENTA.TOTAL, VENTA.FECHA
                                            FROM VENTA, CLIENTES
                                            WHERE VENTA.RFC = CLIENTES.RFC AND FECHA BETWEEN 
                                            ('" & DateTimePicker1.Text & "') AND ('" & DateTimePicker2.Text & "')", conecta)
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged


    End Sub
End Class