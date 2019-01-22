Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conStr As String
        Dim id As String = TextBox1.Text
        Dim Check As Boolean = True

        conStr = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=D:\Northwind.mdf"
        Dim conn As New SqlConnection(conStr)

        conn.Open()
        Dim sql As String = "SELECT CompanyName , ContactName,Address , City , Phone 
                             FROM Customers
                             where CustomerID = '" & id.ToUpper & "'"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        While reader.Read()
            Label7.Text = reader("companyname")
            Label8.Text = reader("contactname")
            Label9.Text = reader("address")
            Label10.Text = reader("city")
            Label11.Text = reader("phone")
            Check = False

        End While
        If Check = True Then
            MessageBox.Show(id.ToUpper & " not found...")
            Label7.Text = ""
            Label8.Text = ""
            Label9.Text = ""
            Label10.Text = ""
            Label11.Text = ""
            TextBox1.Text = ""
        End If

        reader.Close()
        conn.Close()
    End Sub
End Class