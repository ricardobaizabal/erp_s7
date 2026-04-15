Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Partial Class portalcfd_almacen_kardex
    Inherits System.Web.UI.Page

    Private Sub portalcfd_almacen_kardex_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Title = Resources.Resource.WindowsTitle

        If Not IsPostBack Then
            gridResults.Visible = True
            gridResults.DataSource = GetProducts()
            gridResults.DataBind()
        End If

    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        gridResults.Visible = True
        gridResults.DataSource = GetProducts()
        gridResults.DataBind()
    End Sub
    Function GetProducts() As DataSet
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim cmd As New SqlDataAdapter("EXEC pInventario @cmd=2, @txtSearch='" & txtSearch.Text & "'", conn)
        Dim ds As DataSet = New DataSet
        Try
            conn.Open()
            cmd.Fill(ds)
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Return ds
    End Function
    Protected Sub gridResults_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles gridResults.ItemCommand
        Select Case e.CommandName
            Case "cmdView"
                Me.productoID.Value = e.CommandArgument
                Me.panelKardex.Visible = True
                Call MuestraKardex()
        End Select
    End Sub
    Private Sub MuestraKardex()
        Dim ObjData As New DataControl
        productslist.DataSource = ObjData.FillDataSet("exec pInventario @cmd=8, @productoid='" & productoID.Value.ToString & "'")
        productslist.DataBind()
        ObjData = Nothing
    End Sub
    Private Sub productslist_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles productslist.NeedDataSource
        Dim ObjData As New DataControl
        productslist.DataSource = ObjData.FillDataSet("exec pInventario @cmd=8, @productoid='" & productoID.Value.ToString & "'")
        ObjData = Nothing
    End Sub
    Private Sub gridResults_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles gridResults.NeedDataSource
        gridResults.DataSource = GetProducts()
    End Sub

End Class