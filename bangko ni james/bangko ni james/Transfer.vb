Imports MySql.Data.MySqlClient
Public Class Form9
    Dim con As New MySqlConnection("Server=localhost;userid=root;password=;database=james_bank")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader

    Dim query As String


    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        con.Open()

        query = "SELECT*  FROM custtransaction WHERE accountno ='" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        If rd.HasRows Then
            rd.Read()
            TextBox2.Text = rd("availablebalance")
        End If
        con.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim accountno As String


        accountno = TextBox1.Text



        con.Open()
        query = "Insert into custtransaction(accountno,recipientaacnt,amounttransferred,date) values ('" & TextBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & Label8.Text & "')"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        ' malupit na Condition hahaha 

        If TextBox3.Text = "" Then
            MsgBox(" The field for Recipient Account no. cannot be set as Empty.Please enter a valid Account no.", 0 + 64)


        ElseIf TextBox4.Text = "" Then
            MsgBox(" Amount Field cannot be set as Empty.", 0 + 64)

        ElseIf TextBox4.Text > TextBox2.Text Then
            MsgBox(" Amount Entered  Does Not Match with your current Balance")
            TextBox4.Text = ""

        Else
            MsgBox("Amount Has Been Transferred Successfully", 0 + 64)


        End If
        con.Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim bal As String
        Dim transfer As String
        Dim currentbalance As String
        Dim accountno As String
        accountno = TextBox1.Text

        bal = TextBox5.Text
        transfer = TextBox4.Text
        currentbalance = TextBox2.Text
        con.Open()
        bal = (Val(TextBox2.Text) - Val(TextBox4.Text))
        TextBox5.Text = bal


        query = "Update custtransaction Set availablebalance= '" & TextBox5.Text & "' where accountno= '" & accountno & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        con.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim clientid As String


        clientid = TextBox1.Text



        con.Open()
        query = "Insert into custtransaction (recipientaccntno) values ('" & TextBox3.Text & "' ) "
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        con.Close()
        MsgBox("Enter amount to Transfer")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, "Transfer Funds")
        If a = DialogResult.Yes Then
            Me.Close()
            Form3.Show()
        Else
            Me.Show()
        End If




    End Sub

    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim D As Date = Now()   ' this is date and time 
        Label8.Text = D
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub
End Class