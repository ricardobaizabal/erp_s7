Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class pedidos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            aplicaPermisosDeSession()
            If Session("perfilid") <> 1 Then
                pedidosList.MasterTableView.GetColumn("ColEtapaAbierto").Visible = False
            End If
            Call CargaClientes()
            Call CargaSucursales()
            Call CargaAlmacenes()
            Call CargaProyectos()
            Call MuestraPedidos()
            Call CargaEstatus()
            aplicaPermisosDeSession()
        End If
    End Sub

    Sub aplicaPermisosDeSession()
        Select Case Session("perfilid")
            ' Ejecutivo de ventas
            Case 3
                panelNuevoPedido.Visible = False
                pedidosList.MasterTableView.GetColumn("ColEtapaAbierto").Visible = False
                pedidosList.MasterTableView.GetColumn("ColFacturarAnticipo").Visible = False
                pedidosList.MasterTableView.GetColumn("ColFacturar").Visible = False

        End Select

    End Sub

    Private Sub CargaClientes()
        Dim ObjCat As New DataControl
        Select Case Session("perfilid")
            ' Ejecutivo de ventas
            Case 3
                ObjCat.Catalogo(clienteid, "select id, isnull(razonsocial,'') as razonsocial from tblMisClientes where ejecutivoid= '" & Session("userid") & "' order by razonsocial", 0)
                ObjCat.Catalogo(filtroclienteid, "select id, isnull(razonsocial,'') as razonsocial from tblMisClientes where ejecutivoid= '" & Session("userid") & "' order by razonsocial", 0, True)
            Case Else
                ObjCat.Catalogo(clienteid, "exec pPedidos @cmd=12, @userid='" & Session("userid").ToString & "'", 0)
                ObjCat.Catalogo(filtroclienteid, "exec pPedidos @cmd=12, @userid='" & Session("userid").ToString & "'", 0, True)
        End Select

        ObjCat = Nothing
    End Sub

    Private Sub CargaSucursales()
        Dim ObjCat As New DataControl
        ObjCat.Catalogo(sucursalid, "EXEC pListarSucursales @clienteid='" & clienteid.SelectedValue & "'", 0)
        ObjCat = Nothing
    End Sub

    Private Sub CargaAlmacenes()
        Dim ObjCat As New DataControl
        ObjCat.Catalogo(almacenid, "select id, nombre from tblAlmacen where id<>4 order by nombre", 0)
        ObjCat = Nothing
    End Sub

    Private Sub CargaProyectos()
        Dim ObjCat As New DataControl
        ObjCat.Catalogo(proyectoid, "select id, nombre from tblProyecto order by nombre", 0)
        ObjCat = Nothing
    End Sub

    Private Sub MuestraPedidos()
        Dim ObjData As New DataControl()
        Dim dsData As New DataSet()
        Dim montoTotalTxt As String = IIf(String.IsNullOrWhiteSpace(filtroMontoTotal.Text), "NULL", filtroMontoTotal.Text)

        Dim montoTotal As Decimal = 0

        Try
            montoTotal = Convert.ToDecimal(montoTotalTxt)
        Catch ex As Exception
            montoTotal = 0
        End Try

        dsData = ObjData.FillDataSet("exec pPedidos @cmd=2, @userid='" & Session("userid").ToString & "', @clienteid='" & filtroclienteid.SelectedValue.ToString & "', @estatusid='" & filtroestatusid.SelectedValue.ToString & "', @txtSearch='" & txtSearch.Text & "'" & ", @montoTotal='" & montoTotal & "'")
        pedidosList.DataSource = dsData
        pedidosList.DataBind()
        ObjData = Nothing
    End Sub

    Private Sub CargaEstatus()
        Dim ObjCat As New DataControl
        ObjCat.Catalogo(filtroestatusid, "select id, nombre from tblPedidoEstatus order by nombre", 0, True)
        ObjCat = Nothing
    End Sub

    Protected Sub pedidosList_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles pedidosList.ItemCommand
        Dim objdata As New DataControl()
        Select Case e.CommandName
            Case "cmdEditar"
                Response.Redirect("editapedido.aspx?id=" & e.CommandArgument)
            Case "cmbSalida"
                Response.Redirect("OrdenSalida.aspx?pedidoid=" & e.CommandArgument & "modo=agregar")
            Case "cmdEliminar"
                objdata.RunSQLQuery("exec pPedidos @cmd=4, @pedidoid=" & e.CommandArgument)
                objdata = Nothing
                Call MuestraPedidos()
            Case "cmdFacturar"
                Call Facturar(e.CommandArgument)
            Case "cmdFacturarAnticipo"
                Call GetCFD_Anticipo(e.CommandArgument)
            Case "cmdEtapaAbierto"
                Call CambiarEstatus(e.CommandArgument)
                Call MuestraPedidos()
        End Select
    End Sub

    Private Sub CambiarEstatus(ByVal pedidoid As Integer)
        Dim ObjData As New DataControl()
        ObjData.RunSQLQuery("exec pPedidos @cmd=26, @userid='" & Session("userid").ToString & "', @pedidoid='" & pedidoid.ToString & "'")
        ObjData = Nothing
    End Sub

    Private Sub pedidosList_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles pedidosList.NeedDataSource
        Dim ObjData As New DataControl()
        Dim dsData As New DataSet()
        Dim montoTotalTxt As String = IIf(String.IsNullOrWhiteSpace(filtroMontoTotal.Text), "NULL", filtroMontoTotal.Text)

        Dim montoTotal As Decimal = 0

        Try
            montoTotal = Convert.ToDecimal(montoTotalTxt)
        Catch ex As Exception
            montoTotal = 0
        End Try

        dsData = ObjData.FillDataSet("exec pPedidos @cmd=2, @userid='" & Session("userid").ToString & "', @clienteid='" & filtroclienteid.SelectedValue.ToString & "', @estatusid='" & filtroestatusid.SelectedValue.ToString & "', @txtSearch='" & txtSearch.Text & "'" & ", @montoTotal='" & montoTotal & "'")
        pedidosList.DataSource = dsData
        ObjData = Nothing
    End Sub

    Protected Sub btnCrearPedido_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCrearPedido.Click

        Dim saldo As Decimal
        Dim ObjData As New DataControl
        saldo = ObjData.RunSQLScalarQueryDecimal("select isnull(sum(a.importe),0)+isnull(sum(a.iva),0)-isnull(sum(a.importe_descuento),0) as saldo from tblCFD_Partidas a inner join tblCFD b on b.id=a.cfdid where b.estatus_cobranzaId=1 and b.estatus<>3 and DATEDIFF(D, b.fecha_promesa, GETDATE())>0 and b.timbrado=1 and dbo.fnTipoDocumentoId(b.serie, b.folio)=1 and b.clienteid='" & clienteid.SelectedValue.ToString & "'")
        ObjData = Nothing

        If Session("perfilid") <> 1 Then
            If saldo > 0 Then
                'RadWindowManager1.RadAlert("El cliente presenta un saldo pendiente de " & FormatCurrency(saldo, 2) & " <b>Debito a esto, no se podrá generar el pedido.</b>", 250, 200, "Alerta", Nothing)
                RadWindowManager1.RadConfirm("El cliente presenta un saldo pendiente de <b>" & FormatCurrency(saldo, 2) & "</b><br/><br/>¿Desea agregar el pedido al cliente?<br/><br/>", "confirmCallbackFn", 300, 180, Nothing, "Confirmación")
            Else
                Call AgregaPedido()
            End If
        Else
            If saldo > 0 Then
                RadWindowManager1.RadConfirm("¿Desea agregar el pedido al cliente?<br/><b>SALDO : " & FormatCurrency(saldo, 2) & "<b>?<br/><br/>", "confirmCallbackFn", 300, 180, Nothing, "Confirmación")
            Else
                Call AgregaPedido()
            End If
        End If

    End Sub

    Protected Sub pedidosList_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles pedidosList.ItemDataBound
        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem

                Dim btnEtapaAbierto As ImageButton = CType(e.Item.FindControl("btnEtapaAbierto"), ImageButton)

                Dim itm As Telerik.Web.UI.GridDataItem
                itm = CType(e.Item, Telerik.Web.UI.GridDataItem)

                Dim intEstatus As Integer = itm.GetDataKeyValue("estatusid")

                Dim itemTimbrado As Boolean = itm.GetDataKeyValue("timbrado")

                If intEstatus > 3 Then 'Deshabilitar Editar y Eliminar si el estatus es diferente a Abierto
                    CType(itm("ColDelete").Controls(1), ImageButton).Visible = False
                Else
                    btnEtapaAbierto.Visible = False
                End If
                If intEstatus = 4 Then 'Deshabilitar si el estatus es cancelado
                    btnEtapaAbierto.Visible = False
                    CType(itm("ColEditar").Controls(1), ImageButton).Visible = False
                    'CType(itm("ColFacturar").Controls(1), LinkButton).Visible = False
                End If
                'If intEstatus = 6 Then 'Habilitar el estatus facturar
                '    If Session("perfilid").ToString = "1" And itemTimbrado = False Then
                '        CType(itm("ColFacturar").Controls(1), LinkButton).Visible = True
                '    Else
                '        CType(itm("ColFacturar").Controls(1), LinkButton).Visible = False
                '    End If
                'Else
                '    CType(itm("ColFacturar").Controls(1), LinkButton).Visible = False
                'End If

                If Session("perfilid").ToString <> "1" Then
                    CType(itm("ColFacturar").Controls(1), ImageButton).Visible = False
                    CType(itm("ColFacturarAnticipo").Controls(1), ImageButton).Visible = False
                End If

                If intEstatus >= 7 Then 'Deshabilitar el cambio de estatus a abierto
                    btnEtapaAbierto.Visible = False
                    CType(itm("ColFacturar").Controls(1), ImageButton).Visible = False
                    CType(itm("ColFacturarAnticipo").Controls(1), ImageButton).Visible = False
                Else
                    If intEstatus <= 6 Then
                        CType(itm("ColFacturar").Controls(1), ImageButton).Visible = True
                        CType(itm("ColFacturarAnticipo").Controls(1), ImageButton).Visible = True
                    End If
                End If

                'If intEstatus <> 8 Then 'Deshabilitar si el estatus es cancelado
                '    CType(itm("ColFacturar").Controls(1), LinkButton).Visible = False
                'End If
                'If Session("perfilid").ToString = "3" Or Session("perfilid").ToString = "5" Or itemTimbrado = True Then
                '    CType(itm("ColFacturar").Controls(1), LinkButton).Visible = False
                'Else
                '    If intEstatus = 5 And itemTimbrado = False Then
                '        CType(itm("ColFacturar").Controls(1), LinkButton).Visible = True
                '    Else
                '        CType(itm("ColFacturar").Controls(1), LinkButton).Visible = False
                '    End If
                'End If

                If (e.Item.DataItem("condicionesid") = 1) Then
                    e.Item.ForeColor = Drawing.Color.Green
                End If

                If (e.Item.DataItem("estatusid") = 4 Or e.Item.DataItem("estatusid") = 9 Or e.Item.DataItem("estatusid") = 10) Then
                    e.Item.ForeColor = Drawing.Color.Red
                End If

                Dim btnDelete As ImageButton = CType(e.Item.FindControl("btnDelete"), ImageButton)
                btnDelete.Attributes.Add("onclick", "javascript:return confirm('Va a eliminar un pedido. ¿Desea continuar?')")

                btnEtapaAbierto.Attributes.Add("onclick", "javascript:return confirm('Va a regresar a estatus abierto un pedido. ¿Desea continuar?')")

        End Select
    End Sub

    Private Sub clienteid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clienteid.SelectedIndexChanged
        Call CargaSucursales()
    End Sub

    Protected Sub GetCFD(ByVal pedidoid As Integer, ByVal clienteid As Integer, ByVal sucursalid As Integer, ByVal tasaid As Integer, ByVal almacenid As Integer, ByVal orden_compra As String)

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim cmd As New SqlCommand("exec pPedidos @cmd=17, @clienteid='" & clienteid.ToString & "', @sucursalid='" & sucursalid.ToString & "', @almacenid='" & almacenid.ToString & "', @tasaid='" & tasaid.ToString & "', @pedidoid='" & pedidoid & "', @orden_compra='" & orden_compra.ToString & "'", conn)

        Try

            conn.Open()

            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read Then
                If Convert.ToDecimal(rs("cfdid")) > 0 Then
                    Response.Redirect("~/portalcfd/Facturar40.aspx?id=" & rs("cfdid").ToString, False)
                End If
            End If

            conn.Close()
            conn.Dispose()

        Catch ex As Exception
            lblMensaje.Text = "Error: " + ex.Message.ToString()
        Finally

            conn.Close()
            conn.Dispose()

        End Try
    End Sub

    Protected Sub GetCFD_Anticipo(ByVal pedidoid As Integer)

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim cmd As New SqlCommand("exec pPedidos @cmd=28, @pedidoid='" & pedidoid & "'", conn)

        Try

            conn.Open()

            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read Then
                If Convert.ToDecimal(rs("cfdid")) > 0 Then
                    Response.Redirect($"~/portalcfd/Facturar40.aspx?id={rs("cfdid").ToString}", False)
                End If
            End If

            conn.Close()
            conn.Dispose()

        Catch ex As Exception
            lblMensaje.Text = "Error: " + ex.Message.ToString()
        Finally

            conn.Close()
            conn.Dispose()

        End Try
    End Sub

    Protected Sub Facturar(ByVal pedidoid As Integer)

        '
        'Facturar pedido con partidas
        '
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim cmd As New SqlCommand("exec pPedidos @cmd=16, @pedidoid='" & pedidoid & "'", conn)

        Try

            conn.Open()

            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read Then
                If Convert.ToDecimal(rs("cfdid")) <= 0 Then
                    GetCFD(pedidoid, rs("clienteid"), rs("sucursalid"), rs("tasaid"), rs("almacenid"), rs("orden_compra").ToString)
                Else
                    Response.Redirect("~/portalcfd/Facturar40.aspx?id=" & rs("cfdid").ToString, False)
                End If
            End If

            conn.Close()
            conn.Dispose()

        Catch ex As Exception
            lblMensaje.Text = "Error: " + ex.Message.ToString()
        Finally

            conn.Close()
            conn.Dispose()

        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim ObjData As New DataControl()
        Dim dsData As New DataSet()
        Dim montoTotalTxt As String = IIf(String.IsNullOrWhiteSpace(filtroMontoTotal.Text), "NULL", filtroMontoTotal.Text)

        Dim montoTotal As Decimal = 0

        Try
            montoTotal = Convert.ToDecimal(montoTotalTxt)
        Catch ex As Exception
            montoTotal = 0
        End Try

        dsData = ObjData.FillDataSet("exec pPedidos @cmd=2, @userid='" & Session("userid").ToString & "', @clienteid='" & filtroclienteid.SelectedValue.ToString & "', @estatusid='" & filtroestatusid.SelectedValue.ToString & "', @txtSearch='" & txtSearch.Text & "'" & ", @montoTotal='" & montoTotal & "'")
        pedidosList.DataSource = dsData
        pedidosList.DataBind()
        ObjData = Nothing
    End Sub

    Private Sub btnAll_Click(sender As Object, e As EventArgs) Handles btnAll.Click

        filtroclienteid.SelectedValue = 0
        filtroestatusid.SelectedValue = 0
        txtSearch.Text = ""
        filtroMontoTotal.Text = ""

        Dim ObjData As New DataControl()
        Dim dsData As New DataSet()
        Dim montoTotalTxt As String = IIf(String.IsNullOrWhiteSpace(filtroMontoTotal.Text), "NULL", filtroMontoTotal.Text)

        Dim montoTotal As Decimal = 0

        Try
            montoTotal = Convert.ToDecimal(montoTotalTxt)
        Catch ex As Exception
            montoTotal = 0
        End Try

        dsData = ObjData.FillDataSet("exec pPedidos @cmd=2, @userid='" & Session("userid").ToString & "', @clienteid='" & filtroclienteid.SelectedValue.ToString & "', @estatusid='" & filtroestatusid.SelectedValue.ToString & "', @txtSearch='" & txtSearch.Text & "'" & ", @montoTotal='" & montoTotal & "'")
        pedidosList.DataSource = dsData
        pedidosList.DataBind()
        ObjData = Nothing
    End Sub

    Private Sub HiddenButtonOk_Click(sender As Object, e As EventArgs) Handles HiddenButtonOk.Click
        Call AgregaPedido()
    End Sub

    Private Sub AgregaPedido()
        Dim id As Integer = 0
        Dim ObjData As New DataControl
        Try
            id = ObjData.RunSQLScalarQuery("exec pPedidos @cmd=1, @userid=" & Session("userid") & ", @estatusid=1, @clienteid='" & clienteid.SelectedValue & "', @sucursalid='" & sucursalid.SelectedValue & "', @tasaid=3, @orden_compra='" & txtOrdenCompra.Text & "', @proyectoid='" & proyectoid.SelectedValue & "', @almacenid='" & almacenid.SelectedValue & "'")
            Response.Redirect("editapedido.aspx?id=" & id.ToString())
        Catch ex As Exception
            lblMensaje.Text = "Error: " + ex.Message.ToString()
        End Try
        ObjData = Nothing
    End Sub
#Region "Reporte Excel"
    Private selectedItems As New System.Collections.Generic.List(Of Integer)()
    Private selectedPedidos As New System.Collections.Generic.List(Of Integer)()
    Private Sub ExcelGrid_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles ExcelGrid.NeedDataSource
        Dim dt As New DataTable
        ExcelGrid.DataSource = dt
    End Sub

    Private Sub btnReportePedidos_Click(sender As Object, e As EventArgs) Handles btnReportePedidos.Click
        Dim cacheTable As New DataTable
        '
        '
        cacheTable.Columns.Add("fecha", GetType(String))
        cacheTable.Columns.Add("mes", GetType(String))
        cacheTable.Columns.Add("numero", GetType(Integer))
        cacheTable.Columns.Add("cliente", GetType(String))
        cacheTable.Columns.Add("marca", GetType(String))
        cacheTable.Columns.Add("nopedido", GetType(String))
        cacheTable.Columns.Add("cotizacion", GetType(String))
        cacheTable.Columns.Add("modelo", GetType(String))
        cacheTable.Columns.Add("sku", GetType(String))
        cacheTable.Columns.Add("totalpiezas", GetType(String))
        cacheTable.Columns.Add("comprador", GetType(String))
        cacheTable.Columns.Add("clientefinal", GetType(String))
        cacheTable.Columns.Add("clientefinalciudad", GetType(String))
        cacheTable.Columns.Add("guia", GetType(String))
        cacheTable.Columns.Add("comentarios", GetType(String))
        'cacheTable.Columns.Add("fullshopify", GetType(String))
        cacheTable.Columns.Add("metodopagoid", GetType(String))
        cacheTable.Columns.Add("metodopago", GetType(String))
        cacheTable.Columns.Add("factura", GetType(String))
        cacheTable.Columns.Add("montototal", GetType(String))
        'cacheTable.Columns.Add("idpago", GetType(String))
        '
        '
        For Each item As GridDataItem In pedidosList.SelectedItems
            selectedItems.Add(item.ItemIndex)
            selectedPedidos.Add(item.GetDataKeyValue("id"))
        Next
        Dim i As Integer = 1
        For Each pedidoid In selectedPedidos
            Dim Obj As New DataControl
            Dim dt As New DataSet

            dt = Obj.FillDataSet("EXEC pPedidos @cmd=29, @pedidoid=" & pedidoid)
            For Each row As DataRow In dt.Tables(0).Rows

                If row("factura") = "0" Then
                    row("factura") = " "
                End If
                cacheTable.Rows.Add(row("fecha"), row("mes"), i, row("cliente"), row("marca"), row("nopedido"), row("cotizacion"), row("modelo"), row("sku"), row("totalpiezas"), row("comprador"), row("clientefinal"), row("clientefinalciudad"), row("guia"), row("comentarios"), row("metodopagoid"), row("metodopago"), row("factura"), row("montototal"))
                i += 1
            Next
        Next
        '
        '
        ExcelGrid.DataSource = cacheTable
        ExcelGrid.DataBind()
        '

        ExcelGrid.ExportSettings.OpenInNewWindow = True

        ExcelGrid.ExportSettings.FileName = "Pedidos_" & Format(Now(), "ddMMyy HHmmss")

        ExcelGrid.MasterTableView.ExportToExcel()

    End Sub

#End Region


End Class