
Imports MySql.Data.MySqlClient
Public Class Form8
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
            TextBox2.Text = rd("availablebalance")   ' Condition
        Else
            MsgBox(" Invalid Account Please Try again ")
            TextBox2.Text = ""
        End If

        
        con.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim accountno As String


        accountno = TextBox1.Text



        con.Open()
        query = "Insert into custtransaction(accountno,withdrawal,date) values ('" & TextBox1.Text & "','" & TextBox3.Text & "','" & Label7.Text & "')"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        If TextBox3.Text = "" Then
            MsgBox(" This Field cannot be set as Empty. Please Enter a Valid Amount.", 0 + 64)

        ElseIf TextBox3.Text <= 99 Then
            MsgBox(" Sorry but the Minimum Amount you can Withdraw is 100 above. Please Try again. ", 0 + 64)
            TextBox3.Text = ""


        Else
            MsgBox("Successfull !  Please take your Cash ", 0 + 64)
        End If
        con.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim availablebalance As String
        Dim withdrawal As String
        Dim currentbalance As String
        Dim accountno As String
        accountno = TextBox1.Text

        availablebalance = TextBox4.Text
        withdrawal = TextBox3.Text
        currentbalance = TextBox2.Text
        con.Open()
        availablebalance = (Val(TextBox2.Text) - Val(TextBox3.Text))
        TextBox4.Text = availablebalance


        query = "Update custtransaction Set availablebalance= '" & TextBox4.Text & "' where accountno='" & accountno & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        con.Close()
    End Sub

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim D As Date = Now()   ' this is date and time 
        Label7.Text = D

        


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, "Withdraw")
        If a = DialogResult.Yes Then
            Me.Close()
            Form3.Show()
        Else
            Me.Show()
        End If

        
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    
    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
       


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
       

    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class