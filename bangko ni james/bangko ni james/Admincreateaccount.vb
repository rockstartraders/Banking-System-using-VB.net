
Imports MySql.Data.MySqlClient


Public Class Admincreateaccount
    Dim con As New MySqlConnection("Server=localhost;userid=root;password=;database=james_bank")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader
    Dim query As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        con.Open()
        Dim query As String
        query = "Insert into admin(adminid,username,password,name,address,contactnumber) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')"

        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader()
        MsgBox(" New ADMIN Account has Been Created ")
        con.Close()

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        Button1.Enabled = False



        con.Open()
        query = "Select * from admin"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        ListView1.Items.Clear()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("adminid").ToString())


            lv.SubItems.Add(rd("username").ToString())
            lv.SubItems.Add(rd("password").ToString())
            lv.SubItems.Add(rd("name").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contactnumber").ToString())

        End While

        con.Close()


    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        con.Open()
        query = "Select * from admin"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        ListView1.Items.Clear()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("adminid").ToString())


            lv.SubItems.Add(rd("username").ToString())
            lv.SubItems.Add(rd("password").ToString())
            lv.SubItems.Add(rd("name").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contactnumber").ToString())



        End While
        con.Close()



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim a As DialogResult = MsgBox("Are You Sure You Want to Exit ?", 4 + 32, "Admin Create Account")
        If a = DialogResult.Yes Then
            Me.Close()
            Form4.Show()
        Else
            Me.Show()
        End If



    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = "" Then
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim adminid As String
        adminid = TextBox1.Text
        con.Open()
        query = "Update admin set adminid='" & TextBox1.Text & "',username='" & TextBox2.Text & "',password='" & TextBox3.Text & "',name='" & TextBox5.Text & "',address='" & TextBox6.Text & "',contactnumber='" & TextBox7.Text & "' where adminid= '" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader()
        MsgBox("Customer Information Has Been Updated", 0 + 64)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        con.Open()
        query = "Delete from admin where adminid='" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader()
        MsgBox("Data Has Been Deleted", 0 + 64)
    End Sub

   
    Private Sub ListView1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseClick
        Dim Adminid As String = ListView1.SelectedItems(0).SubItems(0).Text()
        Dim Username As String = ListView1.SelectedItems(0).SubItems(1).Text()
        Dim Password As String = ListView1.SelectedItems(0).SubItems(2).Text()
        Dim Name As String = ListView1.SelectedItems(0).SubItems(3).Text()
        Dim Address As String = ListView1.SelectedItems(0).SubItems(4).Text()
        Dim Contactnumber As String = ListView1.SelectedItems(0).SubItems(5).Text()
       




        TextBox1.Text = Adminid
        TextBox2.Text = Username
        TextBox3.Text = Password
        TextBox5.Text = Name
        TextBox6.Text = Address
        TextBox7.Text = Contactnumber

    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim adminid As String
        adminid = TextBox1.Text

        con.Open()
        query = "Update admin set adminid='" & TextBox1.Text & "',username='" & TextBox2.Text & "',password='" & TextBox3.Text & "',name='" & TextBox5.Text & "',address='" & TextBox6.Text & "',contactnumber='" & TextBox7.Text & "' where adminid= '" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader()
        If TextBox1.Text = "" Then  ' if else for condition
            MsgBox("Please Choose an Admin Account to Modify", 0 + 64)
        Else
            MsgBox("ADMIN Information Has Been Updated", 0 + 64)
        End If
        'MsgBox("ADMIN Information Has Been Updated", 0 + 64)


        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        Button1.Enabled = False

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("adminid").ToString())


            lv.SubItems.Add(rd("username").ToString())
            lv.SubItems.Add(rd("password").ToString())
            lv.SubItems.Add(rd("name").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contactnumber").ToString())



        End While
        con.Close()
        con.Open()
        query = "Select * from admin"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader()
        ListView1.Items.Clear()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("adminid").ToString())


            lv.SubItems.Add(rd("username").ToString())
            lv.SubItems.Add(rd("password").ToString())
            lv.SubItems.Add(rd("name").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contactnumber").ToString())



        End While
        con.Close()



    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Button1.Enabled = False


    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        con.Open()
        query = "Delete from admin where adminid='" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader()
        If TextBox1.Text = "" Then  ' if else for condition
            MsgBox("Please Choose an Admin Account Delete", 0 + 64)
        Else
            MsgBox("ADMIN Data Has Been Deleted", 0 + 64)

        End If
        'MsgBox("ADMIN Data Has Been Deleted", 0 + 64)

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("adminid").ToString())


            lv.SubItems.Add(rd("username").ToString())
            lv.SubItems.Add(rd("password").ToString())
            lv.SubItems.Add(rd("name").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contactnumber").ToString())



        End While

        con.Close()

        con.Open()
        query = "Select * from admin"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        ListView1.Items.Clear()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("adminid").ToString())


            lv.SubItems.Add(rd("username").ToString())
            lv.SubItems.Add(rd("password").ToString())
            lv.SubItems.Add(rd("name").ToString())
            lv.SubItems.Add(rd("address").ToString())
            lv.SubItems.Add(rd("contactnumber").ToString())



        End While
        con.Close()



    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            Button1.Enabled = False
        End If

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            Button1.Enabled = False
        End If

    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text = "" Then
            Button1.Enabled = False
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text = "" Then
            Button1.Enabled = False
        End If
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        If TextBox7.Text = "" Then
            Button1.Enabled = False

        Else
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        Button1.Enabled = False


    End Sub
End Class