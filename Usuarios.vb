Imports System.Data.OracleClient
Imports System.Security.Cryptography
Imports System.Text



Public Class Usuarios
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Try
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            conecta.Open()
            comando.Connection = conecta
            comando.CommandType = CommandType.Text
            comando.CommandText = "INSERT INTO Usuarios values(:id_usuario,:id_tipo,:nombre,:paterno,:materno,:clave)"
            comando.Parameters.Add(New OracleParameter(":id_usuario", TextBox1.Text))
            comando.Parameters.Add(New OracleParameter(":id_tipo", Label7.Text))
            comando.Parameters.Add(New OracleParameter(":nombre", TextBox2.Text))
            comando.Parameters.Add(New OracleParameter(":paterno", TextBox3.Text))
            comando.Parameters.Add(New OracleParameter(":materno", TextBox4.Text))
            comando.Parameters.Add(New OracleParameter(":clave", encriptar(TextBox5.Text)))
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
    End Sub



    Private Function encriptar(Contraseña As String) As String
        Dim resultado As String
        Dim ue As New UnicodeEncoding()
        Dim ByteSourceText() As Byte = ue.GetBytes(Contraseña)
        Dim mds As New MD5CryptoServiceProvider()
        Dim ByteHash() As Byte = mds.ComputeHash(ByteSourceText)
        resultado = Convert.ToBase64String(ByteHash)
        Return Convert.ToBase64String(ByteHash)
    End Function



    Private Sub limpiar()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub



    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand



        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        conecta.Open()
        comando.Connection = conecta
        Dim sql As String = "SELECT descripcion,id_tipo FROM tipo_empleado"
        Dim cmd As New OracleCommand(sql, conecta)
        cmd.CommandType = CommandType.Text



        Dim oda As OracleDataAdapter
        Dim ds = New DataSet()
        oda = New OracleDataAdapter(cmd)
        oda.Fill(ds)
        ComboBox1.DataSource = ds.Tables(0)
        ComboBox1.DisplayMember = "descripcion"
        ComboBox1.ValueMember = "id_tipo"



        conecta.Close()
        Label7.Text = ""



    End Sub



    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        Label7.Text = ComboBox1.SelectedValue.ToString
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
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



            comando.CommandText = "SELECT * FROM Usuarios WHERE id_usuario='" & Valor.ToString() & "'"



            Dim reader As OracleDataReader = comando.ExecuteReader



            While reader.Read()
                TextBox1.Text = reader(0).ToString()
                Label7.Text = reader(1).ToString()
                TextBox2.Text = reader(2).ToString()
                TextBox3.Text = reader(3).ToString()
                TextBox4.Text = reader(4).ToString()
                TextBox5.Text = reader(5).ToString()
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
End Class