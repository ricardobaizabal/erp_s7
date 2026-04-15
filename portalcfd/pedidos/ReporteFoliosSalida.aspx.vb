Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class ReporteFoliosSalida
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CargaClientes()
            Call MuestraPedidos()
            Call CargaEstatus()
        End If

    End Sub

    Private Sub MuestraPedidos()
        Dim ObjData As New DataControl()
        Dim dsData As New DataSet()
        dsData = ObjData.FillDataSet("exec pPedidos @cmd=30, @userid='" & Session("userid").ToString & "', @clienteid='" & filtroclienteid.SelectedValue.ToString & "', @estatusid='" & filtroestatusid.SelectedValue.ToString & "', @txtSearch='" & txtSearch.Text & "'")
        If dsData.Tables(0).Rows.Count > 0 Then
            pedidosList.DataSource = dsData
            pedidosList.DataBind()
        End If
        ObjData = Nothing
    End Sub
    Private Sub pedidosList_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles pedidosList.NeedDataSource
        Dim ObjData As New DataControl()
        Dim dsData As New DataSet()
        dsData = ObjData.FillDataSet("exec pPedidos @cmd=30, @userid='" & Session("userid").ToString & "', @clienteid='" & filtroclienteid.SelectedValue.ToString & "', @estatusid='" & filtroestatusid.SelectedValue.ToString & "', @txtSearch='" & txtSearch.Text & "'")
        pedidosList.DataSource = dsData
        ObjData = Nothing
    End Sub
    Private Sub CargaClientes()
        Dim ObjCat As New DataControl
        Select Case Session("perfilid")
            ' Ejecutivo de ventas
            Case 3
                'ObjCat.Catalogo(clienteid, "select id, isnull(razonsocial,'') as razonsocial from tblMisClientes where ejecutivoid= '" & Session("userid") & "' order by razonsocial", 0)
                ObjCat.Catalogo(filtroclienteid, "select id, isnull(razonsocial,'') as razonsocial from tblMisClientes where ejecutivoid= '" & Session("userid") & "' order by razonsocial", 0, True)
            Case Else
                'ObjCat.Catalogo(clienteid, "exec pPedidos @cmd=12, @userid='" & Session("userid").ToString & "'", 0)
                ObjCat.Catalogo(filtroclienteid, "exec pPedidos @cmd=12, @userid='" & Session("userid").ToString & "'", 0, True)
        End Select

        ObjCat = Nothing
    End Sub
    Private Sub CargaEstatus()
        Dim ObjCat As New DataControl
        ObjCat.Catalogo(filtroestatusid, "select id, nombre from tblPedidoEstatus order by nombre", 0, True)
        ObjCat = Nothing
    End Sub

    Protected Sub pedidosList_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles pedidosList.ItemDataBound
        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem

                Dim itm As Telerik.Web.UI.GridDataItem
                itm = CType(e.Item, Telerik.Web.UI.GridDataItem)

                Dim intEstatus As Integer = itm.GetDataKeyValue("estatusid")

                Dim itemTimbrado As Boolean = itm.GetDataKeyValue("timbrado")

                If (e.Item.DataItem("condicionesid") = 1) Then
                    e.Item.ForeColor = Drawing.Color.Green
                End If

                If (e.Item.DataItem("estatusid") = 4 Or e.Item.DataItem("estatusid") = 9 Or e.Item.DataItem("estatusid") = 10) Then
                    e.Item.ForeColor = Drawing.Color.Red
                End If

        End Select
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim ObjData As New DataControl()
        Dim dsData As New DataSet()
        dsData = ObjData.FillDataSet("exec pPedidos @cmd=30, @userid='" & Session("userid").ToString & "', @clienteid='" & filtroclienteid.SelectedValue.ToString & "', @estatusid='" & filtroestatusid.SelectedValue.ToString & "', @txtSearch='" & txtSearch.Text & "'")
        pedidosList.DataSource = dsData
        pedidosList.DataBind()
        ObjData = Nothing
    End Sub

End Class