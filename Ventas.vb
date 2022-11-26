Imports System.Data.OracleClient
Public Class Ventas
    Private Sub Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand



        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        conecta.Open()
        comando.Connection = conecta
        Dim sql As String = "SELECT descripcion,id_genero FROM Generos"
        Dim cmd As New OracleCommand(sql, conecta)
        cmd.CommandType = CommandType.Text



        Dim oda As OracleDataAdapter
        Dim ds = New DataSet()
        oda = New OracleDataAdapter(cmd)
        oda.Fill(ds)
        ComboBox1.DataSource = ds.Tables(0)
        ComboBox1.DisplayMember = "descripcion"
        ComboBox1.ValueMember = "id_genero"



        conecta.Close()
        Label7.Text = ""

        Call cargarRegistros2()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Label7.Text = ComboBox1.SelectedValue.ToString
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Try
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            conecta.Open()
            comando.Connection = conecta
            comando.CommandType = CommandType.Text
            comando.CommandText = "INSERT INTO Clientes values(:RFC,:id_genero,:nombre,:paterno,:materno,:direccion,:telefono)"
            comando.Parameters.Add(New OracleParameter(":RFC", TextBox1.Text))
            comando.Parameters.Add(New OracleParameter(":id_genero", Label7.Text))
            comando.Parameters.Add(New OracleParameter(":nombre", TextBox2.Text))
            comando.Parameters.Add(New OracleParameter(":paterno", TextBox3.Text))
            comando.Parameters.Add(New OracleParameter(":materno", TextBox4.Text))
            comando.Parameters.Add(New OracleParameter(":direccion", TextBox5.Text))
            comando.Parameters.Add(New OracleParameter(":telefono", TextBox6.Text))
            comando.ExecuteNonQuery()
            MessageBox.Show("Guardado")
        Catch ex As OracleException
            MessageBox.Show("error verifique los datos")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error")
        Finally
            conecta.Close()
        End Try

        Call cargarRegistros2()
    End Sub

    Private Sub cargarRegistros2()
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("select idventa, clientes.rfc, total, fecha
                                            from venta, clientes
                                            WHERE  VENTA.rfc = clientes.rfc", conecta)
        Dim ds As New DataSet
        datos.Fill(ds, "Prueba")



        Me.DataGridView2.DataSource = ds.Tables("Prueba")
        Me.DataGridView2.Columns.Item(0).Width = 70
        Me.DataGridView2.Columns.Item(1).Width = 70
        Me.DataGridView2.Columns.Item(2).Width = 100
        Me.DataGridView2.Columns.Item(3).Width = 70




        conecta.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LISTADOCLIENTES.Show()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ConceptoVenta.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Dim Id As Integer
        Integer.TryParse(TextBox1.Text, Id)
        Try
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            conecta.Open()
            If Id = 0 And String.IsNullOrEmpty(ComboBox1.Text.Trim()) Then
                MessageBox.Show("ningun dato fue seleccionado")
            Else
                comando.Connection = conecta
                comando.CommandType = CommandType.Text
                comando.CommandText = "DELETE FROM venta WHERE idventa=" & Me.TextBox1.Text
                comando.ExecuteNonQuery()
                MessageBox.Show("Eliminado")
            End If
        Catch ex As OracleException
            MessageBox.Show("Este dato tiene registros y no puede ser borrado")
        Finally
            conecta.Close()
        End Try
        Call cargarRegistros2()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Try
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            conecta.Open()
            comando.Connection = conecta
            comando.CommandType = CommandType.Text
            comando.CommandText = "INSERT INTO VENTA values(:IDVENTA,:RFC,:TOTAL,:FECHA)"
            comando.Parameters.Add(New OracleParameter(":IDVENTA", TextBox7.Text))
            comando.Parameters.Add(New OracleParameter(":RFC", TextBox1.Text))
            comando.Parameters.Add(New OracleParameter(":TOTAL", Label9.Text))
            comando.Parameters.Add(New OracleParameter(":FECHA", DateTimePicker1.Value))

            comando.ExecuteNonQuery()
            MessageBox.Show("Guardado")
        Catch ex As OracleException
            MessageBox.Show("error verifique los datos")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error")
        Finally
            conecta.Close()
        End Try

        Call cargarRegistros2()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class