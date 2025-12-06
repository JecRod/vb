Imports MySql.Data.MySqlClient

Public Class Form1


    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        If ValidateForm() = False Then
            Exit Sub
        End If

        Dim query As String = "Insert INTO users (nama, email, tel) VALUES (@nama, @email, @tel)"

        Using conn As New MySqlConnection("server=localhost;user id=root; password=; database=myd;")
            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@nama", txtNama.Text)
                cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@tel", txtNo.Text)

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()

            End Using
        End Using
        MessageBox.Show(
    "Data berjaya dimasukkan!" & vbCrLf &
    "Nama: " & txtNama.Text & vbCrLf &
    "Email: " & txtEmail.Text & vbCrLf &
    "No. Tel: " & txtNo.Text)

        MessageBox.Show("Data Insert")

        txtNama.Clear()
        txtEmail.Clear()
        txtNo.Clear()

    End Sub


    Private Function ValidateForm() As Boolean
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Masukkan la nama tu.", "Ralat")
            txtNama.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtEmail.Text) Then
            MessageBox.Show("Masukkan la email tu.", "Ralat")
            txtEmail.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(txtNo.Text) Then
            MessageBox.Show("Masukkan la no tu.", "Ralat")
            txtNo.Focus()
            Return False
        End If

        Return True
    End Function
End Class
