Imports System.Data.OracleClient
Public Class Categorias

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Try
            conecta.ConnectionString = ("User id=proyecto; password = 123;")
            conecta.Open()
            comando.Connection = conecta
            comando.CommandType = CommandType.Text
            comando.CommandText = "INSERT INTO Categorias values(:Id_Categoria,:nom_categoria)"
            comando.Parameters.Add(New OracleParameter(":Id_Categoria", TextBox1.Text))
            comando.Parameters.Add(New OracleParameter(":nom_categoria", TextBox2.Text))
            comando.ExecuteNonQuery()
            MessageBox.Show("Guardado")
        Catch ex As OracleException
            MessageBox.Show("error verifique los datos")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error")
        Finally
            conecta.Close()
        End Try
        Call limpiar()
        Call Registros()


    End Sub

    Private Sub limpiar()
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

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

            comando.CommandText = "SELECT * FROM categorias WHERE Id_Categoria='" & Valor.ToString() & "'"

            Dim reader As OracleDataReader = comando.ExecuteReader

            While reader.Read()
                TextBox1.Text = reader(0).ToString()
                TextBox2.Text = reader(1).ToString()
                Resultado = True
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conecta.Close()
        End Try

        Return Resultado
    End Function
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim Id As Integer

        Integer.TryParse(TextBox1.Text, Id)
        Call Llenado_de_Datos(Id)


    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Try
            conecta.ConnectionString = ("User id=proyecto; password = 123;")
            conecta.Open()
            comando.Connection = conecta
            comando.CommandType = CommandType.Text
            comando.CommandText = "UPDATE Categorias set nom_categoria = '" & TextBox2.Text & "' WHERE Id_Categoria =" & TextBox1.Text & ""
            comando.ExecuteNonQuery()
            MessageBox.Show("Actualizado")


        Catch ex As OracleException
            MessageBox.Show("error verifique los datos")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error")
        Finally
            conecta.Close()
        End Try
        Call Registros()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Try
            conecta.ConnectionString = ("User id=proyecto; password = 123;")
            conecta.Open()
            comando.Connection = conecta
            comando.CommandType = CommandType.Text
            comando.CommandText = "Delete from Categorias WHERE Id_Categoria =" & TextBox1.Text & ""

            comando.ExecuteNonQuery()
            MessageBox.Show("Eliminado")
        Catch ex As OracleException
            MessageBox.Show("error verifique los datos")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error")
        Finally
            conecta.Close()
        End Try
        Call limpiar()
        Call Registros()

    End Sub

    Private Sub Registros()
        Dim conecta As New OracleConnection
        conecta.ConnectionString = ("user id=proyecto; password = 123;")
        Dim datos As New OracleDataAdapter("Select Id_Categoria, nom_categoria from categorias", conecta)
        Dim ds As New DataSet
        datos.Fill(ds, "Categorias")

        Me.DataGridView1.DataSource = ds.Tables("Categorias")
        Me.DataGridView1.Columns.Item(0).Width = 100
        Me.DataGridView1.Columns.Item(1).Width = 400


        conecta.Close()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            Button6.Enabled = False
        Else
            Button6.Enabled = True
        End If

        If TextBox2.Text = "" Then
            Button4.Enabled = False
        Else
            Button4.Enabled = True
        End If

        If TextBox1.Text = "" Then
            Button2.Enabled = False
        Else
            Button2.Enabled = True
        End If
    End Sub

    Private Sub Categorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Registros()
    End Sub





    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index



            TextBox1.Text = i
            TextBox1.Text = DataGridView1.Item(0, i).Value()

            TextBox2.Text = DataGridView1.Item(2, i).Value()

        Catch ex As Exception



        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class