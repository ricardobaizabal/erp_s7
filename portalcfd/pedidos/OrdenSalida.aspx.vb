Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports Telerik.Web.UI
Imports Telerik.Reporting.Processing
Imports System.IO

Public Class OrdenSalida
    Inherits System.Web.UI.Page
    Dim datos As New DataSet
    Dim completosList = New List(Of Boolean)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblOrdenSalidaError.Visible = False
        rwConfirmarDevolucion.VisibleOnPageLoad = False

        If Not IsPostBack Then
            Dim dTable As New DataTable()
            productosList.DataSource = dTable
            ' pedidodetallelist.DataSource = dTable
            'intEstatusPedido = ObtenerEstatusPedido()
            Call DetallePedido()
            If fldEstatus.Value <> 5 And fldEstatus.Value <> 7 Then
                btnCrearSalida.Enabled = False
            End If
            'If estatusId.Value = 4 Then 'No mostrar nada si el estatus es cancelado
            '    Response.Redirect("pedidos.aspx?id=" & Request("id").ToString())
            'End If

        End If
        ' lblUser.Text = Session("contacto").ToString()
        MuestraPedido()
        '
        ' btnAuth.Attributes.Add("onclick", "javascript:return confirm('Va a autorizar un pedido y enviarlo a almacén. ¿Desea continuar?');")
        ' btnPack.Attributes.Add("onclick", "javascript:return confirm('Va a marcar como empaquetado el producto. ¿Desea continuar?');")
        '
        '
        pedidodetallelist_NeedData()
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
        ObjCat.Catalogo(cmbmotivo, "select id, nombre from tblAlmacen where id<>4 order by nombre", 0)
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


        Dim ObjData As New DataControl()
        Dim dsData As New DataSet()
        Try
            dsData = ObjData.FillDataSet("exec pPedidos @cmd=5, @pedidoid=" & Request("pedidoid").ToString)
            If Not IsNothing(dsData) Then
                For Each row As DataRow In dsData.Tables(0).Rows
                    ClienteId.Value = row("clienteid")
                    estatusId.Value = row("estatusid")
                    almacenId.Value = row("almacenid")
                    lblRazonsocial.Text = row("cliente")
                    fldEstatus.Value = row("estatusid")
                    'lblSucursal.Text = row("sucursal")
                    'lblAlmacen.Text = row("almacen")
                    'lblProyecto.Text = row("proyecto")
                    'lblOrdenCompra.Text = row("orden_compra")
                    'txtOrdenCompra.Text = row("orden_compra")
                    cmbclienteid.SelectedValue = row("clienteid")
                    Call CargaSucursales()
                    sucursalid.SelectedValue = ObjData.RunSQLScalarQuery("select top 1 isnull(sucursalid,0) from tblPedidos where id=" & Request("pedidoid"))
                    cmbalmacenid.SelectedValue = ObjData.RunSQLScalarQuery("select top 1 isnull(almacenid,0) from tblPedidos where id=" & Request("pedidoid"))
                    cmbmotivo.SelectedValue = ObjData.RunSQLScalarQuery("select top 1 isnull(almacenid,0) from tblPedidos where id=" & Request("pedidoid"))
                    proyectoid.SelectedValue = ObjData.RunSQLScalarQuery("select top 1 isnull(proyectoid,0) from tblPedidos where id=" & Request("pedidoid"))

                Next
            End If
        Catch ex As Exception
            lblMensaje.Text = "Error: " + ex.ToString()
        End Try
        ObjData = Nothing
    End Sub

    Private Sub MuestraProductos()
        Dim ObjData As New DataControl()
        Dim dsData As New DataSet()
        dsData = ObjData.FillDataSet("exec pPedidos @cmd=22, @clienteid='" & ClienteId.Value.ToString & "', @almacenid='" & almacenId.Value.ToString & "'")
        If Not IsNothing(dsData) Then
            productosList.DataSource = dsData
            productosList.DataBind()
        End If
        ObjData = Nothing
    End Sub
    Private Sub productosList_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles productosList.NeedDataSource
        Dim ObjData As New DataControl()
        Dim dsData As New DataSet()
        dsData = ObjData.FillDataSet("exec pMisProductos @cmd=11, @clienteid='" & ClienteId.Value.ToString & "'")
        productosList.DataSource = dsData
        ObjData = Nothing

    End Sub

    Private Sub MuestraPedido()
        Dim ObjData As New DataControl()
        datos = ObjData.FillDataSet("exec pPedidosConceptos @cmd=2, @pedidoid=" & Request("pedidoid"))
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
        Call MuestraPedido()
    End Sub

    Private Sub pedidodetallelist_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles pedidodetallelist.ItemDataBound
        Dim itm As Telerik.Web.UI.GridDataItem

        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem
                'Dim txtCantidad As Telerik.Web.UI.RadNumericTextBox = CType(e.Item.FindControl("txtCantidad"), Telerik.Web.UI.RadNumericTextBox)
                'Dim imgBtnRecalcular As ImageButton = CType(e.Item.FindControl("btnRecalcular"), ImageButton)

                itm = CType(e.Item, Telerik.Web.UI.GridDataItem)
                'txtCantidad.Text = itm.GetDataKeyValue("cantidad")

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

    Private Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Response.Redirect("pedidos.aspx")
    End Sub

    Private Sub pedidodetallelist_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles pedidodetallelist.NeedDataSource
        'Dim ObjData As New DataControl()
        'Dim dsData As New DataSet()
        'dsData = ObjData.FillDataSet("exec pPedidosConceptos @cmd=2, @pedidoid=" & Request("pedidoid").ToString)
        'If Not IsNothing(dsData) Then
        '    pedidodetallelist.DataSource = dsData
        'End If
        'ObjData = Nothing
        pedidodetallelist_NeedData("off")
    End Sub
    Private Sub pedidodetallelist_NeedData(Optional ByVal state As String = "on")
        Dim ObjData As New DataControl()
        datos = ObjData.FillDataSet("exec pPedidosConceptos @cmd=2, @pedidoid=" & Request("pedidoid").ToString)
        If Not IsNothing(datos) Then
            pedidodetallelist.DataSource = datos
        End If
        ObjData = Nothing

        If state = "on" Then
            pedidodetallelist.DataBind()
        End If
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
                    ObjData.RunSQLQuery("exec pPedidosConceptos @cmd=1, @pedidoid=" & Request("pedidoid") & ", @productoid=" & productoId.ToString & ", @codigo='" & strCodigo & "', @descripcion = '" & strDescripcion & "', @cantidad=" & dblCantidad & ", @unidad='" & strunidad & "', @precio='" & dlPrecio & "'")
                Else
                    valida = valida + 1
                    mensaje = mensaje & "La cantidad proporcionada es mayor a la disponibilidad actual para este producto.<br/>"
                End If
            End If
        Next
        ObjData = Nothing
        '
        If valida = 0 Then
            Response.Redirect("editapedido.aspx?id=" & Request("pedidoid"))
        Else
            Call MuestraPedido()
            Call MuestraProductos()
            lblMensaje.Text = mensaje
        End If
        '
    End Sub

    Private Sub HiddenButtonOk_Click(sender As Object, e As EventArgs) Handles HiddenButtonOk.Click
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pPedidos @cmd=9, @pedidoid='" & Request("pedidoid").ToString & "'")
        ObjData = Nothing
        Response.Redirect("~/portalcfd/pedidos/pedidos.aspx")
    End Sub

    'Private Sub btnMostrarDevolucion_Click(sender As Object, e As EventArgs) Handles btnMostrarDevolucion.Click
    '    listItemsDevolucion.DataSource = pedidodetallelist.DataSource
    '    listItemsDevolucion.DataBind()
    'End Sub

    'devoluciones parciales
    'Private Sub btnEfectuarDevolucion_Click(sender As Object, e As EventArgs) Handles btnEfectuarDevolucion.Click
    '    'rwConfirmarDevolucion.VisibleOnPageLoad = True
    '    'aquí se hará la operación de regresar el producto
    '    'efectua_devolucion(Request("pedidoid"))

    '    'validaciòn de producto disponible a devolver
    '    Dim objCtrl As New DataControl
    '    Dim dtValidacion As DataTable = objCtrl.FillDataSet("EXEC pValidacionesDevoluciones @cmd=1, @pedidoid='" & Request("pedidoid").ToString() & "'").Tables(0)

    '    Dim huboError As Boolean = False

    '    'devolver renglón por renglón
    '    For Each row As GridDataItem In listItemsDevolucion.Items
    '        'seleccionar 
    '        Dim jordanDevolver As Decimal = 0
    '        Dim noviembreDevolver As Decimal = 0
    '        Dim progresoDevolver As Decimal = 0
    '        Dim productoid As Decimal = 0
    '        Dim descripcion As String = row.Item("descripcion").Text
    '        Dim codigo As String = row.Item("codigo").Text

    '        'Dim txtDescripcion As RadTextBox = DirectCast(row.FindControl("txtDescripcion"), RadNumericTextBox)
    '        'Dim txtCantidadJordan As RadNumericTextBox = DirectCast(row.FindControl("txtCantidadJordan"), RadNumericTextBox)
    '        Dim txtProductoId As Telerik.Web.UI.RadTextBox = DirectCast(row.FindControl("txtProductoId"), Telerik.Web.UI.RadTextBox)
    '        Dim txtDescripcion As RadTextBox = DirectCast(row.FindControl("txtDescripcion"), RadTextBox)
    '        Dim txtCantidadJordan As RadNumericTextBox = DirectCast(row.FindControl("txtCantidadJordan"), RadNumericTextBox)
    '        Dim txtCantidadNoviembre As RadNumericTextBox = DirectCast(row.FindControl("txtCantidadNoviembre"), RadNumericTextBox)
    '        Dim txtCantidadProgreso As RadNumericTextBox = DirectCast(row.FindControl("txtCantidadProgreso"), RadNumericTextBox)

    '        Try
    '            productoid = Decimal.Parse(txtProductoId.Text)
    '        Catch ex As Exception
    '        End Try

    '        Try
    '            jordanDevolver = Decimal.Parse(txtCantidadJordan.Text)
    '        Catch ex As Exception
    '        End Try

    '        Try
    '            noviembreDevolver = Decimal.Parse(txtCantidadNoviembre.Text)
    '        Catch ex As Exception
    '        End Try

    '        Try
    '            progresoDevolver = Decimal.Parse(txtCantidadProgreso.Text)
    '        Catch ex As Exception
    '        End Try

    '        'descripcion = txtDescripcion.Text

    '        Try
    '            'Dim dtValidacion As DataTable = objCtrl.FillDataSet("EXEC pValidacionesDevoluciones @cmd=1, @pedidoid='" & Request("pedidoid").ToString() & "', @jordan_devolver='" & jordanDevolver.ToString() & "', @noviembre_devolver='" & noviembreDevolver.ToString() & "', @progreso_devolver='" & txtCantidadProgreso.ToString() & "'").Tables(0)
    '            Dim drValidacion As DataRow = dtValidacion.Select("productoid=" & productoid)(0)
    '            'disponible para devolver
    '            Dim jordanDisponible As Decimal = drValidacion("jordan")
    '            Dim noviembreDisponible As Decimal = drValidacion("noviembre")
    '            Dim progresoDisponible As Decimal = drValidacion("progreso")

    '            If jordanDevolver > jordanDisponible Then
    '                lblOrdenSalidaError.Text = lblOrdenSalidaError.Text & "La cantidad a devolver del producto " & codigo & " en Jordán no puede ser mayor a la del pedido" & "<br/>"
    '                huboError = True
    '            End If

    '            If noviembreDevolver > noviembreDisponible Then
    '                lblOrdenSalidaError.Text = lblOrdenSalidaError.Text & "La cantidad a devolver del producto " & codigo & " en Noviembre no puede ser mayor a la del pedido" & "<br/>"
    '                huboError = True
    '            End If

    '            If progresoDevolver > progresoDisponible Then
    '                lblOrdenSalidaError.Text = lblOrdenSalidaError.Text & "La cantidad a devolver del producto " & codigo & " en Progreso no puede ser mayor a la del pedido" & "<br/>"
    '                huboError = True
    '            End If

    '            'For Each rowValidacion As DataRow In dtValidacion.Rows
    '            '    lblOrdenSalidaError.Text = lblOrdenSalidaError.Text & rowValidacion("mensaje") & "\n"
    '            'Next
    '        Catch ex As Exception
    '        End Try

    '    Next

    '    'despues de la validación se hace el ajuste de almacén
    '    'For Each row As GridDataItem In listItemsDevolucion.Items
    '    '    Try
    '    '        '
    '    '        '   Agrega ajuste
    '    '        '
    '    '        If cantidad_jordan > 0 Then

    '    '            Dim ObjData As New DataControl
    '    '            ObjData.RunSQLQuery("exec pInventario @cmd=3, @tipomovimiento = '" & 15 & "', @productoid='" & productoid & "', @codigo='" & codigo & "', @descripcion='" & descripcion & "', @cantidad='" & txtCantidadJordan.Text & "', @userid='" & Session("userid").ToString & "', @comentario='" & comentario & "', @almacenid='" & 1 & "'")
    '    '            ObjData = Nothing
    '    '        End If

    '    '        If cantidad_noviembre > 0 Then

    '    '            Dim ObjData As New DataControl
    '    '            ObjData.RunSQLQuery("exec pInventario @cmd=3, @tipomovimiento = '" & 15 & "', @productoid='" & productoid & "', @codigo='" & codigo & "', @descripcion='" & descripcion & "', @cantidad='" & txtCantidadNoviembre.Text & "', @userid='" & Session("userid").ToString & "', @comentario='" & comentario & "', @almacenid='" & 2 & "'")
    '    '            ObjData = Nothing
    '    '        End If

    '    '        If cantidad_progreso > 0 Then

    '    '            Dim ObjData As New DataControl
    '    '            ObjData.RunSQLQuery("exec pInventario @cmd=3, @tipomovimiento = '" & 15 & "', @productoid='" & productoid & "', @codigo='" & codigo & "', @descripcion='" & descripcion & "', @cantidad='" & txtCantidadProgreso.Text & "', @userid='" & Session("userid").ToString & "', @comentario='" & comentario & "', @almacenid='" & 3 & "'")
    '    '            ObjData = Nothing
    '    '        End If

    '    '    Next
    '    'obj.RunSQLQuery("EXEC pDevolucion @cmd=7, @pedidoid='" & pedidoid & "', @salidaid='" & salidaid & "', @motivo_devolucion='" & motivo & "'")
    '    'Catch ex As Exception

    '    '    End Try
    '    'Next


    '    If Not String.IsNullOrEmpty(lblOrdenSalidaError.Text) Then
    '        lblOrdenSalidaError.Visible = True
    '        huboError = True
    '    End If

    'End Sub

    Private Sub btnCrearOrden_Click(sender As Object, e As EventArgs) Handles btnCrearOrden.Click
        Dim Obj As New DataControl
        Obj.RunSQLQuery("EXEC pPedidos @cmd=27, @clienteid='" & cmbclienteid.SelectedValue & "',  @sucursalid ='" & sucursalid.SelectedValue & "',  @almacenid ='" & cmbalmacenid.SelectedValue & "',  @marcaid ='" & proyectoid.SelectedValue & "',  @pedidoid ='" & Request("pedidoid").ToString() & "'")
    End Sub

    Private Sub btnCrearSalida_Click(sender As Object, e As EventArgs) Handles btnCrearSalida.Click
        Dim cantidad_pedida As Long = 0
        Dim ordendetalleid As Long = 0
        Dim codigo As String = ""
        Dim descripcion As String = ""
        Dim productoid As String = ""
        Dim mensaje As String = ""

        For Each row As GridDataItem In pedidodetallelist.MasterTableView.Items

            ordendetalleid = row.GetDataKeyValue("id")
            'cantidad_pedida = row.GetDataKeyValue("cantidad")
            codigo = row.GetDataKeyValue("codigo")
            descripcion = row.GetDataKeyValue("descripcion")
            productoid = row.GetDataKeyValue("productoid")

            Dim txtCantidad As RadNumericTextBox = DirectCast(row.FindControl("txtCantidad"), RadNumericTextBox)
            Dim txtCostoVariable As RadNumericTextBox = DirectCast(row.FindControl("txtCostoVariable"), RadNumericTextBox)

            Dim txtCantidadJordan As RadNumericTextBox = DirectCast(row.FindControl("txtCantidadJordan"), RadNumericTextBox)
            Dim txtCantidadNoviembre As RadNumericTextBox = DirectCast(row.FindControl("txtCantidadNoviembre"), RadNumericTextBox)
            Dim txtCantidadProgreso As RadNumericTextBox = DirectCast(row.FindControl("txtCantidadProgreso"), RadNumericTextBox)

            Dim almacenid As DropDownList = DirectCast(row.FindControl("almacenid"), DropDownList)
            Dim cantidad As Decimal = 0
            Dim cantidad_jordan As Decimal = 0
            Dim cantidad_noviembre As Decimal = 0
            Dim cantidad_progreso As Decimal = 0
            Dim costo_variable As Decimal = 0
            Dim comentario As String = "Ajuste por Salida"

            If Not String.IsNullOrWhiteSpace(txtObservaciones.Text) Then
                comentario = comentario & ": " & txtObservaciones.Text
            End If

            Try
                cantidad_jordan = Convert.ToDecimal(txtCantidadJordan.Text)
            Catch ex As Exception
                cantidad_jordan = 0
            End Try

            Try
                cantidad_noviembre = Convert.ToDecimal(txtCantidadNoviembre.Text)
            Catch ex As Exception
                cantidad_noviembre = 0
            End Try

            Try
                cantidad_progreso = Convert.ToDecimal(txtCantidadProgreso.Text)
            Catch ex As Exception
                cantidad_progreso = 0
            End Try

            '
            '   Agrega ajuste
            '
            If cantidad_jordan > 0 Then

                Dim ObjData As New DataControl
                ObjData.RunSQLQuery("exec pInventario @cmd=5, @tipomovimiento = '" & 3 & "', @productoid='" & productoid & "', @codigo='" & codigo & "', @descripcion='" & descripcion & "', @cantidad='" & txtCantidadJordan.Text & "', @userid='" & Session("userid").ToString & "', @comentario='" & comentario & "', @almacenid='" & 1 & "'")
                ObjData = Nothing
            End If

            If cantidad_noviembre > 0 Then

                Dim ObjData As New DataControl
                ObjData.RunSQLQuery("exec pInventario @cmd=5, @tipomovimiento = '" & 3 & "', @productoid='" & productoid & "', @codigo='" & codigo & "', @descripcion='" & descripcion & "', @cantidad='" & txtCantidadNoviembre.Text & "', @userid='" & Session("userid").ToString & "', @comentario='" & comentario & "', @almacenid='" & 2 & "'")
                ObjData = Nothing
            End If

            If cantidad_progreso > 0 Then

                Dim ObjData As New DataControl
                ObjData.RunSQLQuery("exec pInventario @cmd=5, @tipomovimiento = '" & 3 & "', @productoid='" & productoid & "', @codigo='" & codigo & "', @descripcion='" & descripcion & "', @cantidad='" & txtCantidadProgreso.Text & "', @userid='" & Session("userid").ToString & "', @comentario='" & comentario & "', @almacenid='" & 3 & "'")
                ObjData = Nothing
            End If

        Next

        'cambio estatus a pedido/orden salida
        efectua_salida(Request("pedidoid").ToString)

        Response.Redirect("~/portalcfd/pedidos/pedidos.aspx")

        lblMensaje.ForeColor = Drawing.Color.Red
        lblMensaje.Text = mensaje
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

    Sub efectua_salida(ByVal id As String)
        Dim ObjData As New DataControl
        Try
            ObjData.RunSQLScalarQuery("exec pOrdenSalida @cmd=6, @pedidoid = '" & id & "'")
        Catch ex As Exception
            lblMensaje.Text = "Error: " + ex.Message.ToString()
        End Try
        ObjData = Nothing
    End Sub

    Private Sub btnConfirmacionDevolucion(sender As Object, e As EventArgs) Handles btnConfirmarDevolucion.Click
        Dim motivo As String = txtMotivoDevolucion.Text
        efectua_devolucion(Request("pedidoid"), Request("salidaid"), motivo)
    End Sub

    Private Sub btnDevolver_Click(sender As Object, e As EventArgs) Handles btnDevolucion.Click
        rwConfirmarDevolucion.VisibleOnPageLoad = True
    End Sub

    'lcng: devolución total
    Sub efectua_devolucion(ByVal pedidoid As String, ByVal salidaid As String, ByVal motivo As String)
        Dim obj As New DataControl
        'Dim 
        Try
            Dim cantidad_pedida As Long = 0
            Dim ordendetalleid As Long = 0
            Dim codigo As String = ""
            Dim descripcion As String = ""
            Dim productoid As String = ""
            Dim mensaje As String = ""

            For Each row As GridDataItem In pedidodetallelist.MasterTableView.Items

                ordendetalleid = row.GetDataKeyValue("id")
                'cantidad_pedida = row.GetDataKeyValue("cantidad")
                codigo = row.GetDataKeyValue("codigo")
                descripcion = row.GetDataKeyValue("descripcion")
                productoid = row.GetDataKeyValue("productoid")

                Dim txtCantidad As RadNumericTextBox = DirectCast(row.FindControl("txtCantidad"), RadNumericTextBox)
                Dim txtCostoVariable As RadNumericTextBox = DirectCast(row.FindControl("txtCostoVariable"), RadNumericTextBox)

                Dim txtCantidadJordan As RadNumericTextBox = DirectCast(row.FindControl("txtCantidadJordan"), RadNumericTextBox)
                Dim txtCantidadNoviembre As RadNumericTextBox = DirectCast(row.FindControl("txtCantidadNoviembre"), RadNumericTextBox)
                Dim txtCantidadProgreso As RadNumericTextBox = DirectCast(row.FindControl("txtCantidadProgreso"), RadNumericTextBox)

                Dim almacenid As DropDownList = DirectCast(row.FindControl("almacenid"), DropDownList)
                Dim cantidad As Decimal = 0
                Dim cantidad_jordan As Decimal = 0
                Dim cantidad_noviembre As Decimal = 0
                Dim cantidad_progreso As Decimal = 0
                Dim costo_variable As Decimal = 0
                Dim comentario As String = "Devolución de Salida " & salidaid & ": " & motivo

                Try
                    cantidad_jordan = Convert.ToDecimal(txtCantidadJordan.Text)
                Catch ex As Exception
                    cantidad_jordan = 0
                End Try

                Try
                    cantidad_noviembre = Convert.ToDecimal(txtCantidadNoviembre.Text)
                Catch ex As Exception
                    cantidad_noviembre = 0
                End Try

                Try
                    cantidad_progreso = Convert.ToDecimal(txtCantidadProgreso.Text)
                Catch ex As Exception
                    cantidad_progreso = 0
                End Try

                '
                '   Agrega ajuste
                '
                If cantidad_jordan > 0 Then

                    Dim ObjData As New DataControl
                    ObjData.RunSQLQuery("exec pInventario @cmd=3, @tipomovimiento = '" & 15 & "', @productoid='" & productoid & "', @codigo='" & codigo & "', @descripcion='" & descripcion & "', @cantidad='" & txtCantidadJordan.Text & "', @userid='" & Session("userid").ToString & "', @comentario='" & comentario & "', @almacenid='" & 1 & "'")
                    ObjData = Nothing
                End If

                If cantidad_noviembre > 0 Then

                    Dim ObjData As New DataControl
                    ObjData.RunSQLQuery("exec pInventario @cmd=3, @tipomovimiento = '" & 15 & "', @productoid='" & productoid & "', @codigo='" & codigo & "', @descripcion='" & descripcion & "', @cantidad='" & txtCantidadNoviembre.Text & "', @userid='" & Session("userid").ToString & "', @comentario='" & comentario & "', @almacenid='" & 2 & "'")
                    ObjData = Nothing
                End If

                If cantidad_progreso > 0 Then

                    Dim ObjData As New DataControl
                    ObjData.RunSQLQuery("exec pInventario @cmd=3, @tipomovimiento = '" & 15 & "', @productoid='" & productoid & "', @codigo='" & codigo & "', @descripcion='" & descripcion & "', @cantidad='" & txtCantidadProgreso.Text & "', @userid='" & Session("userid").ToString & "', @comentario='" & comentario & "', @almacenid='" & 3 & "'")
                    ObjData = Nothing
                End If

            Next
            obj.RunSQLQuery("EXEC pDevolucion @cmd=7, @pedidoid='" & pedidoid & "', @salidaid='" & salidaid & "', @motivo_devolucion='" & motivo & "'")
        Catch ex As Exception

        End Try
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

End Class