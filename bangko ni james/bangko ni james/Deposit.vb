
Imports MySql.Data.MySqlClient

Public Class Deposit
    Dim con As New MySqlConnection("Server=localhost;userid=root;password=;database=james_bank")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader

    Dim query As String





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Open()

        query = "SELECT*  FROM custtransaction WHERE accountno ='" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        If rd.HasRows Then
            rd.Read()
            TextBox2.Text = rd("availablebalance")

        Else
            MsgBox(" Invalid Account Please Try again ")
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If

        con.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim accountno As String


        accountno = TextBox1.Text



        con.Open()
        query = "Insert into custtransaction(accountno,deposit,date) values ('" & TextBox1.Text & "','" & TextBox3.Text & "','" & Label6.Text & " ')  "
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        If TextBox3.Text = "" Then
            MsgBox(" This Field cannot be set as Empty. Please Enter a Valid Amount.", 0 + 64)

        
        Else
            MsgBox("Deposit Successfully ", 0 + 64)
            Button2.Enabled = False
        End If
        con.Close()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim bal As String
        Dim deposit As String
        Dim currentbalance As String
        Dim accountno As String
        accountno = TextBox1.Text

        bal = TextBox4.Text
        deposit = TextBox3.Text
        currentbalance = TextBox2.Text
        con.Open()
        bal = (Val(TextBox2.Text) + Val(TextBox3.Text))
        TextBox4.Text = bal


        query = "Update custtransaction Set availablebalance= '" & TextBox4.Text & "' where accountno='" & accountno & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        con.Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, "Deposit")
        If a = DialogResult.Yes Then
            Me.Close()
            Form3.Show()
        Else
            Me.Show()
        End If

    End Sub

   

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim D As Date = Now()   ' this is date and time 
        Label6.Text = D
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
       
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
End Class