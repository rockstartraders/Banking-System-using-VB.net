Imports MySql.Data.MySqlClient

Public Class Login_Panel
    Dim con As New MySqlConnection("Server=localhost;userid=root;password=;database=james_bank")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String
    Dim ds As New DataSet
    Dim maxrows As Integer



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = "Admin" Then
            Dim username As String
            Dim password As String

            username = TextBox1.Text
            password = TextBox2.Text


            con.Open()

            query = "SELECT * FROM admin WHERE username ='" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader

            If rd.HasRows Then   ' this is to show the name on the admin panel / admin name '

                rd.Read()
                Form4.Label12.Text = rd("username")
                Form4.TextBox9.Text = rd("adminid")
                Form4.Show()



            Else
                MsgBox("Invalid User Name and Password !", 0 + 64)
            End If

        ElseIf ComboBox1.Text = "Customer" Then
            Dim username As String
            Dim password As String


            username = TextBox1.Text
            password = TextBox2.Text


            con.Open()

            query = "SELECT * FROM custinfo WHERE username='" & TextBox1.Text & "' and password= '" & TextBox2.Text & "'"
            cmd = New MySqlCommand(query, con)
            rd = cmd.ExecuteReader

            If rd.HasRows Then

                rd.Read()
                Form3.Label1.Text = rd("name")
                CustomerPasswordChange.TextBox1.Text = rd("accountno")
                BalanceInquiry.TextBox1.Text = rd("accountno")
                Form3.Show()



            Else
                MsgBox("Invalid User Name and Password !", 0 + 64)

            End If



        End If

        ComboBox1.Text = ""   ' Clear function ' 
        TextBox1.Text = ""
        TextBox2.Text = ""
        Me.Hide()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        ' Integral Value modified 9/30/2018

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, "Login")
        If a = DialogResult.Yes Then
            Me.Close()
        Else
            Me.Show()
        End If




        


    End Sub
End Class
