Imports MySql.Data.MySqlClient
Public Class CustomerPasswordChange
    Dim con As New MySqlConnection("Server=localhost;userid=root;password=;database=james_bank")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader

    Dim query As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim accountno As String
        Dim oldpin As String
        Dim newpin As String

        accountno = TextBox1.Text
        oldpin = TextBox2.Text
        newpin = TextBox3.Text

        con.Open()
        query = "select * from custinfo where accountno='" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        If rd.HasRows Then

            con.Close()
            con.Open()
            query = "Update custinfo set password = '" & TextBox3.Text & "' where accountno ='" & TextBox1.Text & "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader
            MsgBox("Password Has Been Changed", 0 + 64)

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""


            con.Close()

        Else
            MsgBox("Account number does not exits, Please try again", 0 + 48)
        End If


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, "Change PIN")
        If a = DialogResult.Yes Then
            Me.Close()
            Form3.Show()
        Else
            Me.Show()
        End If
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged


    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub CustomerPasswordChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.Enabled = False
    End Sub
End Class