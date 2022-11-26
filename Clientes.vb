Imports System.Data.OracleClient
Public Class Clientes


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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
        Call cargarRegistros()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()

    End Sub



    Private Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Call cargarRegistros()
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Label7.Text = ComboBox1.SelectedValue.ToString
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Me.Close()
    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim Id As Integer
        Integer.TryParse(TextBox1.Text, Id)
        Call Llenado_de_Datos(Id)
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Dim conecta As New OracleConnection
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            Dim datos As New OracleDataAdapter("SELECT * FROM CLIENTES WHERE NOMBRE LIKE '%" & TextBox7.Text & "%'", conecta)
            Dim ds As New DataSet
            datos.Fill(ds, "Prueba")





            Me.DataGridView1.DataSource = ds.Tables("Prueba")
            Me.DataGridView1.Columns.Item(0).Width = 85
            Me.DataGridView1.Columns.Item(1).Width = 90
            Me.DataGridView1.Columns.Item(2).Width = 90
            Me.DataGridView1.Columns.Item(3).Width = 70
            Me.DataGridView1.Columns.Item(4).Width = 70
            Me.DataGridView1.Columns.Item(5).Width = 70
            conecta.Close()
        Catch ex As OracleException
            MessageBox.Show("Error verifique los datos")
        End Try
    End Sub




    Private Function Llenado_de_Datos(Valor As Integer) As Boolean
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Dim Resultado As Boolean = False
        Try
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            conecta.Open()
            comando.Connection = conecta
            comando.CommandType = CommandType.Text



            comando.CommandText = "SELECT * FROM Clientes WHERE RFC='" & Valor.ToString() & "'"



            Dim reader As OracleDataReader = comando.ExecuteReader



            While reader.Read()
                TextBox1.Text = reader(0).ToString()
                Label7.Text = reader(1).ToString()
                TextBox2.Text = reader(2).ToString()
                TextBox3.Text = reader(3).ToString()
                TextBox4.Text = reader(4).ToString()
                TextBox5.Text = reader(5).ToString()
                TextBox6.Text = reader(6).ToString()
                Resultado = True
            End While



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conecta.Close()
        End Try



        Return Resultado
    End Function


    Private Sub limpiar()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Dim Id As Integer
        Integer.TryParse(TextBox1.Text, Id)
        Try
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            conecta.Open()
            If (Id = 0 And String.IsNullOrEmpty(TextBox2.Text.Trim())) Then
                MessageBox.Show("ningun dato fue seleccionado")
            Else
                comando.Connection = conecta
                comando.CommandType = CommandType.Text
                comando.CommandText = "DELETE FROM Clientes WHERE RFC=" & Me.TextBox1.Text
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


    Private Sub cargarRegistros()
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("select * 
                                            from Clientes", conecta)
        Dim ds As New DataSet
        datos.Fill(ds, "Prueba")



        Me.DataGridView1.DataSource = ds.Tables("Prueba")
        Me.DataGridView1.Columns.Item(0).Width = 70
        Me.DataGridView1.Columns.Item(1).Width = 90



        conecta.Close()
    End Sub



    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
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
            comando.CommandText = "UPDATE clientes SET ID_GENERO ='" & Label7.Text & "', NOMBRE ='" & TextBox2.Text & "', PATERNO ='" & TextBox3.Text & "', MATERNO ='" & TextBox4.Text & "', DIRECCION ='" & TextBox5.Text & "', TELEFONO ='" & TextBox6.Text & "' WHERE RFC ='" & TextBox1.Text & "'"
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
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index



            TextBox1.Text = i
            TextBox1.Text = DataGridView1.Item(0, i).Value()
            Label7.Text = DataGridView1.Item(1, i).Value()
            TextBox2.Text = DataGridView1.Item(2, i).Value()
            TextBox3.Text = DataGridView1.Item(3, i).Value()
            TextBox4.Text = DataGridView1.Item(4, i).Value()
            TextBox5.Text = DataGridView1.Item(5, i).Value()
            TextBox6.Text = DataGridView1.Item(6, i).Value()
        Catch ex As Exception



        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class