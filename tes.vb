Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle

Public Class bahan

    Private Sub btnHantar_Click(sender As Object, e As EventArgs) Handles btnHantar.Click

        Dim subjek As String = ""

        If rdVb.Checked Then
            subjek = "Visual Basic"
        ElseIf rdMath.Checked Then
            subjek = "Mathematics"
        ElseIf rdJava.Checked Then
            subjek = "Java"
        Else
            MessageBox.Show("Sila pilih subjek", "Ralat")
            Exit Sub
        End If

        Dim query As String = "INSERT INTO maklumat (nama, email, kelas, subjek) VALUES (@nama, @email, @kelas, @subjek)"

        Using conn As New MySqlConnection("server=localhost; user id=root; password=; database=myd;")
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@nama", txtNama.Text)
                cmd.Parameters.AddWithValue("@email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@kelas", txtKelas.Text)
                cmd.Parameters.AddWithValue("@subjek", subjek)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Data berjaya dihantar!", "Berjaya")
                Catch ex As MySqlException
                    MessageBox.Show("Ralat pangkalan data: " & ex.Message, "Ralat")
                End Try
            End Using
        End Using

    End Sub
End Class
