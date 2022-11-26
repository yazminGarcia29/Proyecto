Imports System.Data.OracleClient
Public Class ConceptoVenta
    Private Sub ConceptoVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call cargarRegistros()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Try
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            conecta.Open()
            comando.Connection = conecta
            comando.CommandType = CommandType.Text
            comando.CommandText = "INSERT INTO concepto values(:idconcepto,:idventa,:id_producto,:cantidad,:precio_unitario,:importe)"
            comando.Parameters.Add(New OracleParameter(":idconcepto", TextBox1.Text))
            comando.Parameters.Add(New OracleParameter(":idventa", TextBox2.Text))
            comando.Parameters.Add(New OracleParameter(":id_producto", Label1.Text))
            comando.Parameters.Add(New OracleParameter(":cantidad", TextBox3.Text))
            comando.Parameters.Add(New OracleParameter(":precio_unitario", Label2.Text))
            Label9.Text = TextBox3.Text * Label2.Text
            comando.Parameters.Add(New OracleParameter(":importe", Label9.Text))
            comando.ExecuteNonQuery()
            MessageBox.Show("Guardado")
        Catch ex As OracleException
            MessageBox.Show("error verifique los datos")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error")
        Finally
            comando.Connection = conecta
            comando.CommandType = CommandType.Text
            comando.CommandText = "UPDATE VENTA SET TOTAL = (" & TextBox1.Text.Equals(TextBox1.Text) & ") WHERE IDCONCEPTO =" & TextBox1.Text & ""
            conecta.Close()
        End Try

        Call cargarRegistros()
    End Sub
    Private Sub cargarRegistros()
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("select idconcepto, venta.idventa, productos.nombre as Nombre_Producto,productos.id_producto, concepto.cantidad, concepto.precio_unitario, concepto.importe
                                            from concepto, venta, productos
                                            WHERE  VENTA.idventa = concepto.idventa and 
                                            concepto.id_producto = productos.id_producto", conecta)
        Dim ds As New DataSet
        datos.Fill(ds, "Prueba")



        Me.DataGridView1.DataSource = ds.Tables("Prueba")
        Me.DataGridView1.Columns.Item(0).Width = 70
        Me.DataGridView1.Columns.Item(1).Width = 70
        Me.DataGridView1.Columns.Item(2).Width = 140
        Me.DataGridView1.Columns.Item(3).Width = 70
        Me.DataGridView1.Columns.Item(4).Width = 70
        Me.DataGridView1.Columns.Item(5).Width = 70
        Me.DataGridView1.Columns.Item(6).Width = 70



        conecta.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListadoProductos.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Dim Id As Integer
        Integer.TryParse(TextBox1.Text, Id)
        Try
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            conecta.Open()
            If Id = 0 And String.IsNullOrEmpty(TextBox1.Text.Trim()) Then
                MessageBox.Show("ningun dato fue seleccionado")
            Else
                comando.Connection = conecta
                comando.CommandType = CommandType.Text
                comando.CommandText = "DELETE FROM CONCEPTO WHERE idconcepto=" & Me.TextBox1.Text
                comando.ExecuteNonQuery()
                MessageBox.Show("Eliminado")
            End If
        Catch ex As OracleException
            MessageBox.Show("Este dato tiene registros y no puede ser borrado")
        Finally
            conecta.Close()
        End Try
        Call cargarRegistros()
    End Sub
    Private Sub limpiar()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox2.Clear()


    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Try
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            conecta.Open()
            comando.Connection = conecta
            comando.CommandType = CommandType.Text
            comando.CommandText = "UPDATE CONCEPTO SET CANTIDAD =" & TextBox3.Text & ", IMPORTE = (" & TextBox3.Text * Label2.Text & ") WHERE IDCONCEPTO =" & TextBox1.Text & ""
            comando.ExecuteNonQuery()
            MessageBox.Show("Dato modificado")
        Catch ex As OracleException
            MessageBox.Show(ex.Message, "error no se pudo modificar")
        Finally
            conecta.Close()
        End Try
        Call cargarRegistros()
        Call limpiar()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
    End Sub
    Private Function Llenado_de_Datos(Valor As Integer) As Boolean
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Dim Resultado As Boolean = False
        Try
            conecta.ConnectionString = ("user id=proyecto; password = 123;")
            conecta.Open()
            comando.Connection = conecta
            comando.CommandType = CommandType.Text

            comando.CommandText = "select idconcepto, venta.idventa, productos.id_producto, concepto.cantidad, concepto.precio_unitario, concepto.importe
                                            from concepto, venta, productos
                                            WHERE  VENTA.idventa = concepto.idventa and 
                                            concepto.id_producto = productos.id_producto =" & Valor.ToString() & "'"

            Dim reader As OracleDataReader = comando.ExecuteReader

            While reader.Read()
                TextBox1.Text = reader(0).ToString()
                TextBox2.Text = reader(1).ToString()
                Label1.Text = reader(3).ToString()
                TextBox3.Text = reader(4).ToString()
                Label2.Text = reader(5).ToString()
                Label9.Text = reader(6).ToString()
                Resultado = True
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

            conecta.Close()
        End Try

        Return Resultado
    End Function

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index



            TextBox1.Text = i
            TextBox1.Text = DataGridView1.Item(0, i).Value()

            TextBox2.Text = DataGridView1.Item(1, i).Value()
            Label1.Text = DataGridView1.Item(3, i).Value()
            TextBox3.Text = DataGridView1.Item(4, i).Value()
            Label2.Text = DataGridView1.Item(5, i).Value()
            Label9.Text = DataGridView1.Item(6, i).Value()

        Catch ex As Exception



        End Try
    End Sub
End Class