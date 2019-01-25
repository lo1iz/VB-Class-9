Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Dim path As String = "" 'ใส่ที่อยู่ดาต้าเบสเองนะครับ
    Dim Constr As String = "Server=(LocalDB)\MSSQLLocalDB;AttachDBFilename=D:\Northwind.mdf" & path
    Dim conn As New SqlConnection(Constr)
    Dim Serchby() As String = {"รหัสสินค้า", "ชื่อสินค้า", "ราคา", "จำนวน"}

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(Serchby)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn.Open()

        Dim sql As String = "SELECT  Products.CategoryId,Products.ProductName,Products.UnitPrice,Products.UnitsInStock
                             FROM Products
							 Order by  " & ComboBox1.SelectedIndex + 1
        If ComboBox1.SelectedIndex = -1 Then
            sql = "SELECT  Products.CategoryId,Products.ProductName,Products.UnitPrice,Products.UnitsInStock
            FROM Products Order by Products.CategoryId"
        End If
        Dim cmd As New SqlCommand(sql, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim data As New DataSet()
        adapter.Fill(data, "Products")

        DataGridView1.DataSource = data.Tables("Products")
        conn.Close()
    End Sub
End Class