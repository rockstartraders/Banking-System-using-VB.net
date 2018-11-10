Imports MySql.Data.MySqlClient
Public Class Form4
    Dim con As New MySqlConnection("Server=localhost;userid=root;password=;database=james_bank")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Elseif for the update button

        If TextBox1.Text = "" Then
            Button1.Enabled = False
        ElseIf TextBox2.Text = "" Then
            Button1.Enabled = False

        Else
            Button1.Enabled = True
        End If


        con.Open()
        query = "Insert into custinfo (adminid,clientid,accountno,name,username,password,address,contactnumber) values ('" & TextBox9.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        MsgBox("New Account Has Been Created ", 0 + 64)

        con.Close()

        con.Open()

        query = "Insert into custtransaction (clientid,accountno,availablebalance) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox8.Text & "')"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        MsgBox("New Customer Has Been added to Transaction Database", 0 + 64)

        con.Close()

        con.Open()
        query = "Select * from custinfo"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        ListView1.Items.Clear()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("clientid").ToString())


            lv.SubItems.Add(rd("accountno").ToString())
            lv.SubItems.Add(rd("name").ToString())
            lv.SubItems.Add(rd("username").ToString())
            lv.SubItems.Add(rd("password").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contactnumber").ToString())



            ' new line - this is for clear function ' 

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            ' TextBox9.Text = "" no need foe this because the code is associated with the log in for fetch reason ' 

            ' This is for button to disable again '  
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button8.Enabled = True


        End While





        query = "SELECT * FROM admin WHERE username ='" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'"
        cmd = New MySqlCommand(query, con)

        If rd.HasRows Then

            rd.Read()
            Me.TextBox9.Text = rd("adminid")
            Me.Show()



        Else
            MsgBox("")
        End If





        con.Close()









    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        'Dim admin As String = ListView1.SelectedItems(0).SubItems(0).Text()
        Dim clientid As String = ListView1.SelectedItems(0).SubItems(0).Text()
        Dim accntno As String = ListView1.SelectedItems(0).SubItems(1).Text()
        Dim name As String = ListView1.SelectedItems(0).SubItems(2).Text()
        Dim username As String = ListView1.SelectedItems(0).SubItems(3).Text()
        Dim pass As String = ListView1.SelectedItems(0).SubItems(4).Text()
        Dim add As String = ListView1.SelectedItems(0).SubItems(5).Text()
        Dim contact As String = ListView1.SelectedItems(0).SubItems(6).Text()
     

        'TextBox8.Text = admin'


        TextBox1.Text = clientid
        TextBox2.Text = accntno
        TextBox3.Text = name
        TextBox4.Text = username
        TextBox5.Text = pass
        TextBox6.Text = add
        TextBox7.Text = contact
        'TextBox9.Text = admin'

       




    End Sub

   
    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        con.Open()
        query = "Select * from custinfo"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader
        ListView1.Items.Clear()
        While rd.Read
            'Dim lv As ListViewItem = ListView1.Items.Add(rd("adminid").ToString())   clientID is the one I need first 
            Dim lv As ListViewItem = ListView1.Items.Add(rd("clientid").ToString())

            'lv.SubItems.Add(rd("clientid").ToString())   Not relevant for the meantime 
            'lv.SubItems.Add(rd("adminid").ToString())    Not relevant for the meantime

            lv.SubItems.Add(rd("accountno").ToString())
            lv.SubItems.Add(rd("name").ToString())
            lv.SubItems.Add(rd("username").ToString())
            lv.SubItems.Add(rd("password").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contactnumber").ToString())





        

            ' Disable button during form load '

            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            Button8.Enabled = True



        End While
        con.Close()




    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        
        Dim clientid As String
        clientid = TextBox1.Text
        con.Open()
        query = "Update custinfo set clientid='" & TextBox1.Text & "',name='" & TextBox3.Text & "',username='" & TextBox4.Text & "',password='" & TextBox5.Text & "',address='" & TextBox6.Text & "',contactnumber='" & TextBox7.Text & "' where clientid='" & clientid & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader()

        If TextBox1.Text = "" Then  ' if else for condition
            MsgBox("Please Choose an Account to Modify", 0 + 64)
        Else
            MsgBox("Customer Information Has Been Updated", 0 + 64)
        End If

        'MsgBox("Customer Information Has Been Updated", 0 + 64)

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ' TextBox9.Text = "" no need foe this because the code is associated with the log in for fetch reason ' 

        ' This is for button to disable again '  
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button8.Enabled = True

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("clientid").ToString())


            lv.SubItems.Add(rd("accountno").ToString())
            lv.SubItems.Add(rd("name").ToString())
            lv.SubItems.Add(rd("username").ToString())
            lv.SubItems.Add(rd("password").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contactnumber").ToString())
        End While


        


        con.Close()


        con.Open()
        query = "Select * from custinfo"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        ListView1.Items.Clear()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("clientid").ToString())


            lv.SubItems.Add(rd("accountno").ToString())
            lv.SubItems.Add(rd("name").ToString())
            lv.SubItems.Add(rd("username").ToString())
            lv.SubItems.Add(rd("password").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contactnumber").ToString())
        End While
        con.Close()


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        con.Open()
        query = "Delete from custinfo where clientid='" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader()
        If TextBox1.Text = "" Then  ' if else for condition
            MsgBox("Please Choose an Account to Delete.", 0 + 64)
        Else
            MsgBox("Customers Account Information Has Been Deleted", 0 + 64)
        End If

        'MsgBox("Data Has Been Deleted", 0 + 64)

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ' TextBox9.Text = "" no need foe this because the code is associated with the log in for fetch reason ' 

        ' This is for button to disable again '  
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button8.Enabled = True

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("clientid").ToString())


            lv.SubItems.Add(rd("accountno").ToString())
            lv.SubItems.Add(rd("name").ToString())
            lv.SubItems.Add(rd("username").ToString())
            lv.SubItems.Add(rd("password").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contactnumber").ToString())
        End While





        con.Close()


        con.Open()
        query = "Select * from custinfo"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        ListView1.Items.Clear()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("clientid").ToString())


            lv.SubItems.Add(rd("accountno").ToString())
            lv.SubItems.Add(rd("name").ToString())
            lv.SubItems.Add(rd("username").ToString())
            lv.SubItems.Add(rd("password").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contactnumber").ToString())
        End While


        con.Close()


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Admincreateaccount.Show()
        Me.Dispose()

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form6.Show()
    End Sub

    Private Sub TextBox9_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)




    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""


    End Sub


    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        ' This is for button to disable again '  
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button8.Enabled = True
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        If TextBox8.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        If TextBox8.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        ' Integral Value modified 09/30/2018 ' 

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, "Admin Panel")
        If a = DialogResult.Yes Then
            Me.Close()
            Me.Dispose()
            Login_Panel.Show()


        Else
            Me.Show()
        End If

    End Sub

    Private Sub TextBox9_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox9.TextChanged
      
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click


        ' Enable buttons after click ' 

        'Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button8.Enabled = False  ' disable button after ' 

        

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ListView1.Update()

    End Sub

    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button8.Enabled = True

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        ClientTransHistory.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox8.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox8.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        If TextBox8.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        If TextBox8.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        If TextBox8.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        If TextBox8.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If
    End Sub
End Class