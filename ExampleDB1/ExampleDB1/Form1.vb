Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim constr As String = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=D:\Northwind.mdf"

        Dim conn As New SqlConnection(constr)

        conn.Open()
        Dim sql As String = "select categoryname, categoryid from categories"
        Dim cmd As New SqlCommand(sql, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader

        While reader.Read
            ListBox1.Items.Add(reader(0) & ":" & reader(1))
        End While
        reader.Close()
        conn.Close()


    End Sub
End Class
