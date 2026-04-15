Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports Telerik.Web.UI
Imports Telerik.Reporting.Processing
Imports System.IO

Public Class editapedido
    Inherits System.Web.UI.Page
    Dim datos As New DataSet
    Dim completosList = New List(Of Boolean)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblPedidoError.Visible = False
        If Not IsPostBack Then
            Dim dTable As New DataTable()
            productosList.DataSource = dTable
            ' pedidodetallelist.DataSource = dTable
            'intEstatusPedido = ObtenerEstatusPedido()
            Call DetallePedido()
            'If estatusId.Value = 4 Then 'No mostrar nada si el estatus es cancelado
            '    Response.Redirect("pedidos.aspx?id=" & Request("id").ToString())
            'End If
            If estatusId.Value > 1 Then 'Deshabilitar edición de pedido si su estatus no es abierto
                lblBuscar.Visible = False
                txtSearch.Visible = False
                btnSearch.Visible = False
                btnCancelarBusqueda.Visible = False
                btnColocarPedido.Visible = False
            Else
                lblBuscar.Visible = True
                txtSearch.Visible = True
                btnSearch.Visible = True
                btnCancelarBusqueda.Visible = True
            End If
            ' lblUser.Text = Session("contacto").ToString()
            muestraPedido()
            '
            ' btnAuth.Attributes.Add("onclick", "javascript:return confirm('Va a autorizar un pedido y enviarlo a almacén. ¿Desea continuar?');")
            ' btnPack.Attributes.Add("onclick", "javascript:return confirm('Va a marcar como empaquetado el producto. ¿Desea continuar?');")
            '
            Select Case estatusId.Value
                Case 1  '   Abierto
                    txtGuia.Enabled = False
                    btnAuth.Enabled = False
                    btnRechazar.Enabled = False
                    btnPack.Enabled = False
                    btnSent.Enabled = False
                    btnReactivar.Enabled = False
                Case 2, 3  '   En proceso
                    txtGuia.Enabled = False
                    btnColocarPedido.Enabled = False
                    btnPack.Enabled = False
                    btnCancel.Enabled = False
                    btnSent.Enabled = False
                    btnReactivar.Enabled = False
                Case 5  ' Autorizado
                    txtGuia.Enabled = False
                    btnColocarPedido.Enabled = False
                    btnAuth.Enabled = False
                    btnRechazar.Enabled = False
                    btnCancel.Enabled = False
                    btnSent.Enabled = False
                    btnReactivar.Enabled = False
                Case 6 'Empaquetado
                    btnColocarPedido.Enabled = False
                    btnAuth.Enabled = False
                    btnRechazar.Enabled = False
                    btnPack.Enabled = False
                    btnCancel.Enabled = False
                    btnSearch.Enabled = False
                    txtGuia.Enabled = False
                    btnSent.Enabled = False
                    btnReactivar.Enabled = False
                Case 7 'Facturado
                    txtGuia.Enabled = False
                    btnColocarPedido.Enabled = False
                    btnAuth.Enabled = False
                    btnRechazar.Enabled = False
                    btnPack.Enabled = False
                    btnCancel.Enabled = False
                    btnSearch.Enabled = False
                    txtGuia.Enabled = True
                    btnSent.Enabled = True
                    btnReactivar.Enabled = False
                Case 10 'Rechazado
                    txtGuia.Enabled = False
                    btnAuth.Enabled = False
                    btnRechazar.Enabled = False
                    btnCancel.Enabled = False
                    btnColocarPedido.Enabled = False
                    btnPack.Enabled = False
                    btnSearch.Enabled = False
                    btnSent.Enabled = False
                    btnReactivar.Enabled = True
                Case Else
                    txtGuia.Enabled = False
                    btnAuth.Enabled = False
                    btnRechazar.Enabled = False
                    btnCancel.Enabled = False
                    btnColocarPedido.Enabled = False
                    btnPack.Enabled = False
                    btnSearch.Enabled = False
                    btnSent.Enabled = False
                    btnReactivar.Enabled = False
            End Select
            '
            aplicaPermisosDeSession()
            pedidodetallelist_NeedData()
        End If
    End Sub
    Sub aplicaPermisosDeSession()
        Select Case Session("perfilid")
            Case 3
                txtGuia.Enabled = False
                btnAuth.Enabled = False
                'btnPack.Enabled = False
                btnSent.Enabled = False
                txtGuia.Enabled = False
                btnRechazar.Enabled = False
                btnReactivar.Enabled = False
            Case 5
                txtGuia.Enabled = False
                btnAuth.Enabled = False
                btnPack.Enabled = False
                btnSent.Enabled = False
                txtGuia.Enabled = False
                btnRechazar.Enabled = False
                btnReactivar.Enabled = False
        End Select

    End Sub
    Private Sub CargaClientes()
        Dim ObjCat As New DataControl
        ObjCat.Catalogo(cmbclienteid, "select a.id, isnull(razonsocial,'') as razonsocial from tblMisClientes a ", 0)
        'ObjCat.Catalogo(filtroclienteid, "exec pPedidos @cmd=12, @userid='" & Session("userid").ToString & "'", 0, True)
        ObjCat = Nothing
    End Sub

    Private Sub CargaSucursales()
        Dim ObjCat As New DataControl
        ObjCat.Catalogo(sucursalid, "EXEC pListarSucursales @clienteid='" & cmbclienteid.SelectedValue & "'", 0)
        ObjCat = Nothing
    End Sub

    Private Sub CargaAlmacenes()
        Dim ObjCat As New DataControl
        ObjCat.Catalogo(cmbalmacenid, "select id, nombre from tblAlmacen where id<>4 order by nombre", 0)
        ObjCat = Nothing
    End Sub

    Private Sub CargaProyectos()
        Dim ObjCat As New DataControl
        ObjCat.Catalogo(proyectoid, "select id, nombre from tblProyecto order by nombre", 0)
        ObjCat = Nothing
    End Sub
    Private Sub DetallePedido()
        '
        Call CargaClientes()
        Call CargaSucursales()
        Call CargaAlmacenes()
        Call CargaProyectos()
        Call FoliosList_NeedData(Request("id").ToString)

        Dim ObjData As New DataControl()
        Dim dsData As New DataSet()
        Try
            dsData = ObjData.FillDataSet("exec pPedidos @cmd=5, @pedidoid=" & Request("id").ToString)
            If Not IsNothing(dsData) Then
                For Each row As DataRow In dsData.Tables(0).Rows
                    ClienteId.Value = row("clienteid")
                    estatusId.Value = row("estatusid")
                    almacenId.Value = row("almacenid")
                    lblRazonsocial.Text = row("cliente")
                    'lblSucursal.Text = row("sucursal")
                    'lblAlmacen.Text = row("almacen")
                    'lblProyecto.Text = row("proyecto")
                    'lblOrdenCompra.Text = row("orden_compra")
                    txtOrdenCompra.Text = row("orden_compra")
                    txtOrdenCompraMex.Text = row("ordenCompraMex")
                    txtOrdenCompraUsa.Text = row("ordenCompraUsa")
                    txtGuia.Text = row("guia")
                    cmbclienteid.SelectedValue = row("clienteid")
                    Call CargaSucursales()
                    sucursalid.SelectedValue = ObjData.RunSQLScalarQuery("select top 1 isnull(sucursalid,0) from tblPedidos where id=" & Request("id"))
                    cmbalmacenid.SelectedValue = ObjData.RunSQLScalarQuery("select top 1 isnull(almacenid,0) from tblPedidos where id=" & Request("id"))
                    proyectoid.SelectedValue = ObjData.RunSQLScalarQuery("select top 1 isnull(proyectoid,0) from tblPedidos where id=" & Request("id"))

                Next
            End If
        Catch ex As Exception
            lblMensaje.Text = "Error: " + ex.ToString()
        End Try
        ObjData = Nothing
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        MuestraProductos()
        panel1.Visible = True
        btnAgregaConceptos.Visible = True
        lblMensaje.Text = ""
    End Sub

    Private Sub MuestraProductos()
        Dim ObjData As New DataControl()
        Dim dsData As New DataSet()
        dsData = ObjData.FillDataSet("exec pPedidos @cmd=22, @txtSearch='" & txtSearch.Text & "', @clienteid='" & ClienteId.Value.ToString & "', @almacenid='" & almacenId.Value.ToString & "'")
        If Not IsNothing(dsData) Then
            productosList.DataSource = dsData
            productosList.DataBind()
        End If
        ObjData = Nothing
    End Sub
    Private Sub productosList_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles productosList.NeedDataSource
        If txtSearch.Text <> "" Then
            Dim ObjData As New DataControl()
            Dim dsData As New DataSet()
            dsData = ObjData.FillDataSet("exec pMisProductos @cmd=11, @txtSearch='" & txtSearch.Text & "', @clienteid='" & ClienteId.Value.ToString & "'")
            productosList.DataSource = dsData
            ObjData = Nothing
        End If

    End Sub

    Private Sub MuestraPedido()
        Dim ObjData As New DataControl()
        datos = ObjData.FillDataSet("exec pPedidosConceptos @cmd=2, @pedidoid=" & Request("id"))
        If Not IsNothing(datos) Then
            pedidodetallelist.DataSource = datos
            pedidodetallelist.DataBind()
        End If
        ObjData = Nothing
    End Sub

    Protected Sub pedidodetallelist_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles pedidodetallelist.ItemCommand
        Dim objdata As New DataControl()
        Select Case e.CommandName
            Case "cmdRecalcular"
                Dim strCodigo, strDescripcion, strunidad As String
                Dim dblCantidad, dlPrecio As Double
                Dim disponibles As Double = 0
                Dim intProductoID As Int64
                Dim existencia As Decimal = 0
                Dim itm As Telerik.Web.UI.GridDataItem
                itm = CType(e.Item, Telerik.Web.UI.GridDataItem)
                If CType(itm("ColCantidad").Controls(1), Telerik.Web.UI.RadNumericTextBox).Value.HasValue Then
                    strCodigo = itm.GetDataKeyValue("codigo")
                    strDescripcion = itm.GetDataKeyValue("descripcion")
                    strunidad = itm.GetDataKeyValue("unidad")
                    dblCantidad = CType(itm("ColCantidad").Controls(1), Telerik.Web.UI.RadNumericTextBox).Value
                    dlPrecio = itm.GetDataKeyValue("precio")
                    existencia = itm.GetDataKeyValue("existencia")
                    intProductoID = itm.GetDataKeyValue("productoid")
                    If existencia >= dblCantidad Then
                        lblMensaje.Text = ""
                        objdata.RunSQLQuery("exec pPedidosConceptos @cmd=4, @conceptoid=" & e.CommandArgument & ", @productoid=" & intProductoID & ", @codigo='" & strCodigo & "', @descripcion = '" & strDescripcion & "', @cantidad=" & dblCantidad & ", @unidad='" & strunidad & "', @precio=" & dlPrecio & ", @importe=0, @iva=0")
                        objdata = Nothing
                    Else
                        lblMensaje.Text = "*La cantidad solicitada es mayor a la disponibilidad para este producto"
                    End If
                End If
            Case "cmdEliminar"
                objdata.RunSQLQuery("exec pPedidosConceptos @cmd=3, @conceptoid=" & e.CommandArgument)
                objdata = Nothing
        End Select
        Call muestraPedido()
    End Sub

    Private Sub pedidodetallelist_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles pedidodetallelist.ItemDataBound
        Dim itm As Telerik.Web.UI.GridDataItem

        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem
                'Dim txtCantidad As Telerik.Web.UI.RadNumericTextBox = CType(e.Item.FindControl("txtCantidad"), Telerik.Web.UI.RadNumericTextBox)
                'Dim imgBtnRecalcular As ImageButton = CType(e.Item.FindControl("btnRecalcular"), ImageButton)
                Dim imgBtnEliminar As ImageButton = CType(e.Item.FindControl("btnEliminar"), ImageButton)

                imgBtnEliminar.Attributes.Add("onclick", "javascript:return confirm('Va a eliminar un concepto del pedido. ¿Desea continuar?');")

                itm = CType(e.Item, Telerik.Web.UI.GridDataItem)
                'txtCantidad.Text = itm.GetDataKeyValue("cantidad")

                If estatusId.Value > 1 Then 'Deshabilitar edición si es el estatus no es abierto
                    'txtCantidad.Enabled = False
                    'imgBtnRecalcular.Visible = False
                    imgBtnEliminar.Visible = False
                End If

                Dim agregados As Integer = itm.Item("agregados").Text
                Dim cantidad As Integer = itm.Item("cantidad").Text

                If agregados = cantidad Then
                    completosList.Add(True)
                Else
                    completosList.Add(False)
                End If


            Case Telerik.Web.UI.GridItemType.Footer
                If datos.Tables(0).Rows.Count > 0 Then
                    e.Item.Cells(9).Text = datos.Tables(0).Compute("sum(cantidad)", "")
                    e.Item.Cells(9).HorizontalAlign = HorizontalAlign.Right
                    e.Item.Cells(9).Font.Bold = True
                    ''
                    'e.Item.Cells(10).Text = FormatCurrency(datos.Tables(0).Compute("sum(importe)", ""), 2).ToString
                    'e.Item.Cells(10).HorizontalAlign = HorizontalAlign.Right
                    'e.Item.Cells(10).Font.Bold = True
                    '
                End If
        End Select

    End Sub

    Private Sub btnColocarPedido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnColocarPedido.Click
        Dim objdata As New DataControl()
        Dim intError As Integer = 0
        Try
            objdata.RunSQLQuery("exec pPedidos @cmd=6, @pedidoid=" & Request("id").ToString())

            Dim email_pedidos As String = System.Configuration.ConfigurationManager.AppSettings("email_pedidos").ToString

            'Dim email As String = ""
            'email = objdata.RunSQLScalarQueryString("select isnull(email,'') as email from tblUsuario where id='" & Session("userid").ToString & "'")

            'Dim ObjComm As New Communications
            'ObjComm.EmailTo = email_pedidos
            'ObjComm.EmailSubject = "Notificación de pedido No." & Request("id").ToString() & "  -  " & DateTime.Now.ToString("dd/MM/yyyy")
            'ObjComm.EmailFrom = email
            'ObjComm.EmailBody = ""
            'ObjComm.EmailSend()
            'ObjComm = Nothing

        Catch ex As Exception
            intError = 1
            lblPedidoError.Visible = True
            lblPedidoError.Text = "Error: " + Left(ex.ToString(), 200)
        End Try
        objdata = Nothing
        If intError = 0 Then
            Response.Redirect("pedidos.aspx?id=" & Request("id"))
        End If
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("pedidos.aspx")
    End Sub

    Private Sub pedidodetallelist_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles pedidodetallelist.NeedDataSource
        'Dim ObjData As New DataControl()
        'Dim dsData As New DataSet()
        'dsData = ObjData.FillDataSet("exec pPedidosConceptos @cmd=2, @pedidoid=" & Request("id").ToString)
        'If Not IsNothing(dsData) Then
        '    pedidodetallelist.DataSource = dsData
        'End If
        'ObjData = Nothing
        pedidodetallelist_NeedData("off")
    End Sub
    Private Sub pedidodetallelist_NeedData(Optional ByVal state As String = "on")
        Dim ObjData As New DataControl()
        datos = ObjData.FillDataSet("exec pPedidosConceptos @cmd=2, @pedidoid=" & Request("id").ToString)
        If Not IsNothing(datos) Then
            pedidodetallelist.DataSource = datos
        End If
        ObjData = Nothing

        If state = "on" Then
            pedidodetallelist.DataBind()
        End If
        If completosList.Contains(False) Then
            btnColocarPedido.Enabled = False
        Else
            btnColocarPedido.Enabled = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pPedidos @cmd=3, @pedidoid='" & Request("id").ToString & "'")
        ObjData = Nothing
        Response.Redirect("~/portalcfd/pedidos/pedidos.aspx")
    End Sub

    Private Sub btnAuth_Click(sender As Object, e As System.EventArgs) Handles btnAuth.Click

        'Dim limite_credito As Decimal
        'Dim saldo As Decimal
        'Dim total_pedido As Decimal

        Dim ObjData As New DataControl
        'limite_credito = ObjData.RunSQLScalarQueryDecimal("select isnull(limite_credito,0) from tblMisClientes where id='" & ClienteId.Value.ToString & "'")
        'saldo = ObjData.RunSQLScalarQueryDecimal("select isnull(sum(a.importe),0)+isnull(sum(a.iva),0)-isnull(sum(a.importe_descuento),0) as saldo from tblCFD_Partidas a inner join tblCFD b on b.id=a.cfdid where b.estatus_cobranzaId=1 and b.estatus<>3 and DATEDIFF(D, b.fecha_promesa, GETDATE())>0 and b.timbrado=1 and dbo.fnTipoDocumentoId(b.serie, b.folio)=1 and b.clienteid='" & ClienteId.Value.ToString & "'")
        'total_pedido = ObjData.RunSQLScalarQueryDecimal("select sum(isnull(importe,0)+isnull(iva,0)) from tblPedidosConceptos where pedidoid='" & Request("id").ToString() & "'")

        'If limite_credito > total_pedido Then
        '    If saldo > 0 Then
        '        RadWindowManager1.RadConfirm("El cliente presenta un saldo pendiente de <b>" & FormatCurrency(saldo, 2) & "</b><br/><br/>¿Desea agregar el pedido al cliente?<br/><br/>", "confirmCallbackFn", 300, 180, Nothing, "Confirmación")
        '    Else

        '    End If
        'Else
        '    RadWindowManager1.RadAlert("El monto total <b>" & FormatCurrency(total_pedido, 2) & "</b> del pedido excede al limite de credito autorizado: <b>" & FormatCurrency(limite_credito, 2) & "</b>", 250, 200, "Alerta", Nothing)
        'End If

        ObjData.RunSQLQuery("exec pPedidos @cmd=9, @pedidoid='" & Request("id").ToString & "'")
        ObjData = Nothing
        Response.Redirect("~/portalcfd/pedidos/pedidos.aspx")
    End Sub

    Private Sub btnPack_Click(sender As Object, e As System.EventArgs) Handles btnPack.Click
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pPedidos @cmd=10, @pedidoid='" & Request("id").ToString & "'")
        ObjData = Nothing
        Response.Redirect("~/portalcfd/pedidos/pedidos.aspx")
    End Sub

    Private Sub btnSent_Click(sender As Object, e As System.EventArgs) Handles btnSent.Click
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pPedidos @cmd=11, @pedidoid='" & Request("id").ToString & "', @guia='" & txtGuia.Text & "'")
        ObjData = Nothing
        Response.Redirect("~/portalcfd/pedidos/pedidos.aspx")
    End Sub

    Private Sub btnCancelarBusqueda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarBusqueda.Click
        Response.Redirect("editapedido.aspx?id=" & Request("id"))
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Dim FilePath = Server.MapPath("~/portalcfd/pedidos/documentos/") & "ng_pedido_" & Request("id").ToString() & ".pdf"
        GuardaPDF(GeneraPDF_Pedido(Request("id")), FilePath)
        Dim FileName As String = Path.GetFileName(FilePath)
        Response.Clear()
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", "attachment; filename=""" & FileName & """")
        Response.Flush()
        Response.WriteFile(FilePath)
        Response.End()

        'If File.Exists(FilePath) Then
        '    Dim FileName As String = Path.GetFileName(FilePath)
        '    Response.Clear()
        '    Response.ContentType = "application/octet-stream"
        '    Response.AddHeader("Content-Disposition", "attachment; filename=""" & FileName & """")
        '    Response.Flush()
        '    Response.WriteFile(FilePath)
        '    Response.End()
        'Else
        '    GuardaPDF(GeneraPDF_Pedido(Request("id")), FilePath)

        '    Dim FileName As String = Path.GetFileName(FilePath)
        '    Response.Clear()
        '    Response.ContentType = "application/octet-stream"
        '    Response.AddHeader("Content-Disposition", "attachment; filename=""" & FileName & """")
        '    Response.Flush()
        '    Response.WriteFile(FilePath)
        '    Response.End()
        'End If
    End Sub

    Private Sub GuardaPDF(ByVal report As Telerik.Reporting.Report, ByVal fileName As String)
        Dim reportProcessor As New Telerik.Reporting.Processing.ReportProcessor()
        Dim result As RenderingResult = reportProcessor.RenderReport("PDF", report, Nothing)
        Using fs As New FileStream(fileName, FileMode.Create)
            fs.Write(result.DocumentBytes, 0, result.DocumentBytes.Length)
        End Using
    End Sub

    Private Function GeneraPDF_Pedido(ByVal pedidoid As Long) As Telerik.Reporting.Report
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)

        Dim folio As Long = 0
        Dim almacen As String = ""
        Dim proyecto As String = ""
        Dim vendedor As String = ""

        Dim fecha As String = ""
        Dim cliente As String = ""
        Dim sucursal As String = ""
        Dim orden_compra As String = ""

        Dim ds As DataSet = New DataSet

        Dim cmd As New SqlCommand("EXEC pPedidos @cmd=14, @pedidoid='" & pedidoid.ToString & "'", conn)
        conn.Open()
        Dim rs As SqlDataReader
        rs = cmd.ExecuteReader()

        If rs.Read Then
            folio = rs("id")
            almacen = rs("almacen")
            proyecto = rs("proyecto")
            vendedor = rs("vendedor")
            fecha = rs("fecha")
            cliente = rs("cliente")
            sucursal = rs("sucursal")
            orden_compra = rs("orden_compra")
        End If
        rs.Close()

        conn.Close()
        conn.Dispose()
        conn = Nothing

        Dim reporte As New CotizacionProductosPDF_elm.formato_pedidos_neogenis

        reporte.ReportParameters("plantillaId").Value = 5
        reporte.ReportParameters("pedidoId").Value = pedidoid

        reporte.ReportParameters("txtFolio").Value = folio
        reporte.ReportParameters("txtAlmacen").Value = almacen
        reporte.ReportParameters("txtProyecto").Value = proyecto
        reporte.ReportParameters("txtVendedor").Value = vendedor

        reporte.ReportParameters("txtFecha").Value = fecha
        reporte.ReportParameters("txtCliente").Value = cliente
        reporte.ReportParameters("txtSucursal").Value = sucursal
        reporte.ReportParameters("txtOC").Value = orden_compra
        reporte.ReportParameters("paramImgBanner").Value = Server.MapPath("~/portalcfd/logos/" & Session("logo_formato"))

        Dim totalPzas As String
        Dim objData As New DataControl
        totalPzas = objData.RunSQLScalarQuery("exec pPedidos @cmd=15, @pedidoid='" & pedidoid.ToString & "'")
        objData = Nothing
        '
        reporte.ReportParameters("txtTotalPiezas").Value = totalPzas.ToString
        '
        Return reporte

    End Function

    Private Sub btnAgregaConceptos_Click(sender As Object, e As EventArgs) Handles btnAgregaConceptos.Click
        Dim productoId As Long = 0
        Dim strCodigo, strDescripcion, strunidad As String
        Dim dblCantidad, dlPrecio As Double
        Dim disponibles As Double = 0
        Dim valida As Integer = 0
        Dim mensaje As String = ""
        Dim unidad As String = ""
        Dim ObjData As New DataControl
        For Each row As GridDataItem In productosList.MasterTableView.Items
            Dim servicio As Boolean = False
            productoId = row.GetDataKeyValue("productoid")
            strCodigo = row.GetDataKeyValue("codigo")
            strDescripcion = row.GetDataKeyValue("descripcion")
            strunidad = row.GetDataKeyValue("unidad")
            dlPrecio = row.GetDataKeyValue("unitario")
            disponibles = row.GetDataKeyValue("disponibles")
            unidad = row.GetDataKeyValue("unidad")

            Dim txtCantidad As RadNumericTextBox = DirectCast(row.FindControl("txtCantidad"), RadNumericTextBox)

            Try
                dblCantidad = Convert.ToDecimal(txtCantidad.Text)
            Catch ex As Exception
                dblCantidad = 0
            End Try

            If unidad.Contains("Serv") Then
                servicio = True
            End If

            If dblCantidad > 0 Then
                If disponibles >= dblCantidad Or servicio = True Then
                    ObjData.RunSQLQuery("exec pPedidosConceptos @cmd=1, @pedidoid=" & Request("id") & ", @productoid=" & productoId.ToString & ", @codigo='" & strCodigo & "', @descripcion = '" & strDescripcion & "', @cantidad=" & dblCantidad & ", @unidad='" & strunidad & "', @precio='" & dlPrecio & "'")
                Else
                    valida = valida + 1
                    mensaje = mensaje & "La cantidad proporcionada es mayor a la disponibilidad actual para este producto.<br/>"
                End If
            End If
        Next
        ObjData = Nothing
        '
        If valida = 0 Then
            Response.Redirect("editapedido.aspx?id=" & Request("id"))
        Else
            Call MuestraPedido()
            Call MuestraProductos()
            lblMensaje.Text = mensaje
        End If
        '
    End Sub

    Private Sub HiddenButtonOk_Click(sender As Object, e As EventArgs) Handles HiddenButtonOk.Click
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pPedidos @cmd=9, @pedidoid='" & Request("id").ToString & "'")
        ObjData = Nothing
        Response.Redirect("~/portalcfd/pedidos/pedidos.aspx")
    End Sub

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pPedidos @cmd=24, @pedidoid='" & Request("id").ToString & "'")
        ObjData = Nothing
        Response.Redirect("~/portalcfd/pedidos/pedidos.aspx")
    End Sub

    Private Sub btnReactivar_Click(sender As Object, e As EventArgs) Handles btnReactivar.Click
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pPedidos @cmd=25, @pedidoid='" & Request("id").ToString & "'")
        ObjData = Nothing
        Response.Redirect("~/portalcfd/pedidos/pedidos.aspx")
    End Sub

    Private Sub btnActualizarDatos_Click(sender As Object, e As EventArgs) Handles btnActualizarDatos.Click
        Dim Obj As New DataControl
        Obj.RunSQLQuery("EXEC pPedidos @cmd=27, @clienteid='" & cmbclienteid.SelectedValue & "', @orden_compra ='" & txtOrdenCompra.Text & "',  @sucursalid ='" & sucursalid.SelectedValue & "',  @almacenid ='" & cmbalmacenid.SelectedValue & "',  @marcaid ='" & proyectoid.SelectedValue & "',  @pedidoid ='" & Request("id").ToString() & "', @ordenCompraMex='" & txtOrdenCompraMex.Text & "', @ordenCompraUsa='" & txtOrdenCompraUsa.Text & "'")
    End Sub

    Sub txtCantidad_TextChanged(sender As Object, e As EventArgs)
        Dim txt = DirectCast(sender, RadNumericTextBox)
        Dim cell = DirectCast(txt.Parent, GridTableCell)
        Dim item As GridDataItem = cell.Item
        Dim index As Integer = item.ItemIndex

        For Each dataItem As Telerik.Web.UI.GridDataItem In pedidodetallelist.MasterTableView.Items
            If dataItem.ItemIndex = index Then
                Dim id As Integer = dataItem.GetDataKeyValue("id")
                Dim txtCantidadJordan As RadNumericTextBox = CType(dataItem.FindControl("txtCantidadJordan"), RadNumericTextBox)
                Dim txtCantidadNoviembre As RadNumericTextBox = CType(dataItem.FindControl("txtCantidadNoviembre"), RadNumericTextBox)
                Dim txtCantidadProgreso As RadNumericTextBox = CType(dataItem.FindControl("txtCantidadProgreso"), RadNumericTextBox)

                actualiza_pagoid(id, txtCantidadJordan.Text, txtCantidadNoviembre.Text, txtCantidadProgreso.Text)

                Exit For
            End If

        Next
        pedidodetallelist_NeedData()
    End Sub

    Sub actualiza_pagoid(ByVal conceptoid As Integer, ByVal jordan As String, ByVal noviembre As String, ByVal progreso As String)
        Dim ObjData As New DataControl
        Try
            ObjData.RunSQLScalarQuery("exec pPedidosConceptos @cmd=5, @conceptoid = '" & conceptoid & "', @jordan='" & jordan & "', @noviembre='" & noviembre & "', @progreso='" & progreso & "'")
        Catch ex As Exception
            lblMensaje.Text = "Error: " + ex.Message.ToString()
        End Try
        ObjData = Nothing
    End Sub

    Sub txtDescripcionConcepto_TextChanged(sender As Object, e As EventArgs)
        Dim txt = DirectCast(sender, RadTextBox)
        Dim cell = DirectCast(txt.Parent, GridTableCell)
        Dim item As GridDataItem = cell.Item
        Dim index As Integer = item.ItemIndex

        For Each dataItem As Telerik.Web.UI.GridDataItem In pedidodetallelist.MasterTableView.Items
            If dataItem.ItemIndex = index Then
                Dim id As Integer = dataItem.GetDataKeyValue("id")
                updateDescripcionConcepto(txt.Text, id)
                Exit For
            End If
        Next
        pedidodetallelist_NeedData()
    End Sub

    Private Sub updateDescripcionConcepto(ByVal descripcion As String, ByVal conceptoid As Integer)
        Dim Obj As New DataControl
        Dim parameters() As SqlParameter = {
         New SqlParameter("@cmd", SqlDbType.Int) With {.Value = 6},
         New SqlParameter("@conceptoid", SqlDbType.Int) With {.Value = conceptoid},
         New SqlParameter("@descripcion", SqlDbType.VarChar) With {.Value = descripcion}
        }
        Obj.ExecProcedure("pPedidosConceptos", 1, parameters)
    End Sub

    Sub txtPrecioConcepto_TextChanged(sender As Object, e As EventArgs)
        Dim txt = DirectCast(sender, RadNumericTextBox)
        Dim cell = DirectCast(txt.Parent, GridTableCell)
        Dim item As GridDataItem = cell.Item
        Dim index As Integer = item.ItemIndex
        For Each dataItem As Telerik.Web.UI.GridDataItem In pedidodetallelist.MasterTableView.Items
            If dataItem.ItemIndex = index Then
                Dim id As Integer = dataItem.GetDataKeyValue("id")
                updatePrecioConcepto(txt.Text & vbCrLf, id)
                Exit For
            End If
        Next
        pedidodetallelist_NeedData()
    End Sub
    Sub updatePrecioConcepto(ByVal precio As Decimal, ByVal conceptoid As Integer)
        Dim Obj As New DataControl
        Dim parameters() As SqlParameter = {
         New SqlParameter("@cmd", SqlDbType.Int) With {.Value = 7},
         New SqlParameter("@conceptoid", SqlDbType.Int) With {.Value = conceptoid},
         New SqlParameter("@precio", SqlDbType.Money) With {.Value = precio}
        }
        Obj.ExecProcedure("pPedidosConceptos", 1, parameters)
    End Sub

    Private Sub btnGuardaFolioSalida_Click(sender As Object, e As EventArgs) Handles btnGuardaFolioSalida.Click
        Dim objData As New DataControl
        objData.RunSQLScalarQuery("exec pPedidosConceptos @cmd=8, @pedidoid='" & Request("id").ToString & "',@FolioSalida='" & txtFolioSalida.Text & "'")
        objData = Nothing

        FoliosList_NeedData(Request("id").ToString)
    End Sub
    Private Sub FoliosList_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles FoliosList.ItemCommand
        Dim objdata As New DataControl()
        Select Case e.CommandName
            Case "cmdEliminar"
                objdata.RunSQLQuery("exec pPedidosConceptos @cmd=10, @id=" & e.CommandArgument)
                objdata = Nothing
        End Select
        FoliosList_NeedData(Request("id").ToString)
    End Sub
    Public Sub FoliosList_NeedData(ByVal state As String)
        Dim ObjD As New DataControl

        Dim cmd As String = "exec pPedidosConceptos @cmd=9, @pedidoid='" & Request("id").ToString & "'"
        FoliosList.DataSource = ObjD.FillDataSet(cmd)
        FoliosList.DataBind()
        FoliosList.MasterTableView.NoMasterRecordsText = "No se han agregado productos"
    End Sub

End Class