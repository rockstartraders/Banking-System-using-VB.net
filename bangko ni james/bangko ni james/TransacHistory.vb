

Imports MySql.Data.MySqlClient
Public Class TransacHistory

    Dim con As New MySqlConnection("Server=localhost;userid=root;password=;database=james_bank")
    Dim cmd As MySqlCommand
    Dim rd As MySqlDataReader

    Dim query As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        con.Open()
        query = "Select * from custtransaction Where accountno='"
        cmd = New MySqlCommand(query, con)
        rd = cmd.ExecuteReader

        ListView1.Items.Clear()

        While rd.Read
            Dim lv As ListViewItem = ListView1.Items.Add(rd("clientid").ToString())


            lv.SubItems.Add(rd("accountno").ToString())
            lv.SubItems.Add(rd("recipientaacnt").ToString())
            lv.SubItems.Add(rd("amounttransferred").ToString())
            lv.SubItems.Add(rd("deposit").ToString())
            lv.SubItems.Add(rd("withdrawal").ToString())
            lv.SubItems.Add(rd("availablebalance").ToString())

        End While


    End Sub

    Private Sub TransacHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class