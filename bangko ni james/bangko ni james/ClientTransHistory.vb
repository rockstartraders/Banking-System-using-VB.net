Imports MySql.Data.MySqlClient

Public Class ClientTransHistory
    Dim con As New MySqlConnection("Server=localhost;userid=root;password=;database=james_bank")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader

    Dim query As String


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        con.Open()
        query = "Select * from custtransaction Where accountno='" & TextBox1.Text & "'"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        If TextBox1.Text = "" Then
            MsgBox(" Please Enter Customers Account No.", 0 + 64)

        Else
            TextBox1.Text = ""
            ListView1.Items.Clear()

        End If

        ListView1.Items.Clear()

        While rd.Read
            'Dim lv As ListViewItem = ListView1.Items.Add(rd("clientid").ToString())
            Dim lv As ListViewItem = ListView1.Items.Add(rd("accountno").ToString())

            'lv.SubItems.Add(rd("accountno").ToString())
            lv.SubItems.Add(rd("recipientaacnt").ToString())
            lv.SubItems.Add(rd("amounttransferred").ToString())
            lv.SubItems.Add(rd("deposit").ToString())
            lv.SubItems.Add(rd("withdrawal").ToString())
            lv.SubItems.Add(rd("date").ToString())

        End While
        con.Close()
    End Sub

    Private Sub ClientTransHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        ListView1.Items.Clear()


    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
       

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ' exit button

        Me.Dispose()
        Me.Close()
        Form4.Show()



    End Sub
End Class