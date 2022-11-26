Imports System.Data.OracleClient
Imports System.Security.Cryptography
Imports System.Text



Public Class Login
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub
    Private Sub Limpiar()
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conecta As New OracleConnection
        Dim comando As New OracleCommand
        Dim adapter As New OracleDataAdapter
        Dim sql As String
        Dim respuesta As OracleDataReader
        Dim dt As DataTable
        Dim lector As OracleDataReader
        Dim clave As String
        Try
            conecta.ConnectionString = ("user id=Proyecto; password = 123;")
            conecta.Open()
            clave = encriptar(TextBox2.Text)
            sql = "Select nombre,id_tipo from usuarios where nombre ='" & TextBox1.Text & "' and clave='" & clave & "'"
            comando = New OracleCommand(sql, conecta)
            adapter.SelectCommand = comando
            lector = comando.ExecuteReader
            dt = New DataTable
            adapter.Fill(dt)
            If lector.HasRows = True Then
                If dt.Rows.Count = 1 Then
                    If dt.Rows(0)(1).ToString() = "1" Then
                        MsgBox("Aceptado", MsgBoxStyle.Information, "Acceso permitido")
                        MenuAdmi.Show()
                        Limpiar()
                        Me.Close()
                    ElseIf dt.Rows(0)(1).ToString() = "2" Then
                        MsgBox("Aceptado", MsgBoxStyle.Information, "Acceso permitido")
                        Form2.Show()
                        Limpiar()
                        Me.Close()
                    End If
                End If
            Else
                MsgBox("Usuario i/o contraseña incorrecto", MsgBoxStyle.Critical, "Advertencia")
                Limpiar()
            End If
        Catch ex As OracleException
            MessageBox.Show("error verifique los datos")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error")
        Finally
            conecta.Close()
        End Try
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



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.PasswordChar = ""
        ElseIf CheckBox1.Checked = False Then
            TextBox2.PasswordChar = "*"
        End If
    End Sub



    Private Function tipo(nombre As String) As Boolean
        Dim conecta As New OracleConnection
        Dim sql1 As String
        Dim respuesta As OracleDataReader
        Dim res As Integer
        Dim comando1 As New OracleCommand
        conecta.ConnectionString = ("user id=Proyecto; password = 123;")
        conecta.Open()
        sql1 = "Select id_tipo from usuarios where nombre ='" & TextBox1.Text & "'"
        comando1 = New OracleCommand(sql1, conecta)
        respuesta = comando1.ExecuteReader
        If respuesta.Read Then
            res = CInt(respuesta.Item("id_tipo"))
        End If
        respuesta.Close()
        Return res
    End Function



End Class