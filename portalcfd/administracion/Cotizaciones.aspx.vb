Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports Telerik.Reporting.Processing
Imports System.IO
Imports Telerik.Web.UI.GridExcelBuilder

Public Class Cotizaciones
    Inherits System.Web.UI.Page
    Dim datos As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RadWindow.VisibleOnPageLoad = False
        If Not IsPostBack Then
            Call CargaComboBox()
            fha_ini.SelectedDate = Now()
            fha_fin.SelectedDate = Now()

            If Session("perfilid") = 1 Then
                Button2.Enabled = True
            Else
                Button2.Enabled = False
            End If

        End If
    End Sub
#Region "Eventos de los objetos"

#End Region
    Public Sub CotizacionesList_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles cotizacionesList.NeedDataSource
        Call CotizacionesListFiltro0_NeedData("off")
        btnCrearPedido.Attributes.Add("onclick", "javascript:" + btnCrearPedido.ClientID + ".disabled=true;" + ClientScript.GetPostBackEventReference(btnCrearPedido, ""))
    End Sub
    Private Sub btnAddCotizacion_Click(sender As Object, e As EventArgs) Handles btnAddCotizacion.Click
        Call NuevaCotzacionID()
        panelAddCotizacion.Visible = True
        panelCotizacion.Visible = False
    End Sub
    Private Sub btnAgregaConceptos_Click(sender As Object, e As EventArgs) Handles btnAgregaConceptos.Click
        Dim productoId As Long = 0
        Dim strCodigo, strDescripcion, strunidad, txtDescripcion, descripcion As String
        Dim dblCantidad, dlPrecio, DlPreciolbl As Double

        Dim mensaje As String = ""
        Dim ObjData As New DataControl
        For Each row As GridDataItem In productosList.MasterTableView.Items
            productoId = row.GetDataKeyValue("productoid")
            strCodigo = row.GetDataKeyValue("codigo")
            strDescripcion = row.GetDataKeyValue("descripcion")
            strunidad = row.GetDataKeyValue("unidad")
            'dlPrecio = row.GetDataKeyValue("unitario")

            Dim txtTiempoEntrega As RadNumericTextBox = DirectCast(row.FindControl("txtTiempoEntrega"), RadNumericTextBox)
            Dim txtCantidad As RadNumericTextBox = DirectCast(row.FindControl("txtCantidad"), RadNumericTextBox)
            Dim txtUnitaryPrice As RadNumericTextBox = CType(row.FindControl("txtUnitaryPrice"), RadNumericTextBox)
            Dim lblPrecioUnitario As RadNumericTextBox = CType(row.FindControl("lblPrecioUnitario"), RadNumericTextBox)
            Dim lblDescripcion As RadTextBox = CType(row.FindControl("txtDescripcion"), RadTextBox)
            Dim descrip As RadTextBox = CType(row.FindControl("descripcion"), RadTextBox)

            Try
                dblCantidad = Convert.ToDecimal(txtCantidad.Text)
            Catch ex As Exception
                dblCantidad = 0
            End Try

            Try
                dlPrecio = Convert.ToDecimal(txtUnitaryPrice.Text)
            Catch ex As Exception
                dlPrecio = 0
            End Try

            Try
                DlPreciolbl = Convert.ToDecimal(lblPrecioUnitario.Text)
            Catch ex As Exception
                DlPreciolbl = 0
            End Try

            Try
                txtDescripcion = lblDescripcion.Text
            Catch ex As Exception
                txtDescripcion = " "
            End Try

            'Dim productoidtbl = row.DataItem("productoid")
            If productoId = 191 Then
                If dblCantidad > 0 Then
                    ObjData.RunSQLQuery("exec pCotizacionDetalle @cmd=1, @cotizacionid=" & RegistroID.Value & ", @productoid=" & productoId.ToString & ", @codigo='" & strCodigo & "', @descripcion = '" & strDescripcion & "', @cantidad=" & dblCantidad & ", @unidad='" & strunidad & "', @precio='" & dlPrecio & "', @tiempoEstimado='" & txtTiempoEntrega.Text & "'")
                End If

            ElseIf productoId = 580 Then
                If dblCantidad > 0 Then
                    ObjData.RunSQLQuery("exec pCotizacionDetalle @cmd=1, @cotizacionid=" & RegistroID.Value & ", @productoid=" & productoId.ToString & ", @codigo='" & strCodigo & "', @descripcion = '" & txtDescripcion & "', @cantidad=" & dblCantidad & ", @unidad='" & strunidad & "', @precio='" & dlPrecio & "', @tiempoEstimado='" & txtTiempoEntrega.Text & "'")
                End If


            ElseIf productoId = 91147 Then
                If dblCantidad > 0 Then
                    ObjData.RunSQLQuery("exec pCotizacionDetalle @cmd=1, @cotizacionid=" & RegistroID.Value & ", @productoid=" & productoId.ToString & ", @codigo='" & strCodigo & "', @descripcion = '" & txtDescripcion & "', @cantidad=" & dblCantidad & ", @unidad='" & strunidad & "', @precio='" & dlPrecio & "', @tiempoEstimado='" & txtTiempoEntrega.Text & "'")
                End If

            ElseIf productoId = 631 Then
                If dblCantidad > 0 Then
                    ObjData.RunSQLQuery("exec pCotizacionDetalle @cmd=1, @cotizacionid=" & RegistroID.Value & ", @productoid=" & productoId.ToString & ", @codigo='" & strCodigo & "', @descripcion = '" & txtDescripcion & "', @cantidad=" & dblCantidad & ", @unidad='" & strunidad & "', @precio='" & dlPrecio & "', @tiempoEstimado='" & txtTiempoEntrega.Text & "'")
                End If
            Else
                If dblCantidad > 0 Then
                    ObjData.RunSQLQuery("exec pCotizacionDetalle @cmd=1, @cotizacionid=" & RegistroID.Value & ", @productoid=" & productoId.ToString & ", @codigo='" & strCodigo & "', @descripcion = '" & strDescripcion & "', @cantidad=" & dblCantidad & ", @unidad='" & strunidad & "', @precio='" & DlPreciolbl & "', @tiempoEstimado='" & txtTiempoEntrega.Text & "'")
                End If
            End If

            'If dblCantidad > 0 Then
            '    ObjData.RunSQLQuery("exec pCotizacionDetalle @cmd=1, @cotizacionid=" & RegistroID.Value & ", @productoid=" & productoId.ToString & ", @codigo='" & strCodigo & "', @descripcion = '" & strDescripcion & "', @cantidad=" & dblCantidad & ", @unidad='" & strunidad & "', @precio='" & dlPrecio & "', @tiempoEstimado='" & txtTiempoEntrega.Text & "'")
            'End If
        Next
        ObjData = Nothing
        '

        Call MuestraPedido()
        'Call MuestraProductos()
        panel1.Visible = False
        btnAgregaConceptos.Visible = False
        lblMensaje.Text = mensaje
        '
    End Sub



#Region "Funciones publicas"
    Public Sub CotizacionesList_NeedData(ByVal state As String)
        Dim ObjD As New DataControl
        Dim montoTotalTxt As String = IIf(IsNothing(txtMontoTotal.Value), "NULL", txtMontoTotal.Value)

        If filtrobit.Value = 3 Then
            Dim cmd As String = "exec pCotizaciones @cmd=2" & ", @fhaini='" & Format(fha_ini.SelectedDate, "yyyy-MM-dd") & "', @fhafin='" & Format(fha_fin.SelectedDate, "yyyy-MM-dd") & "', @filtrobit='" & filtroBit.Value & "', @clienteid='" & cmbfiltrocliente.SelectedValue & "', @folio='" & txtfolio.Text & "', @proyecto='" & txtProyectoFiltro.Text & "', @contacto='" & txtContactoFiltro.Text & "', @usuarioid='" & Session("userid") & "'" & ", @montoTotal = " & montoTotalTxt
            cotizacionesList.DataSource = ObjD.FillDataSet(cmd)
        Else
            Dim cmd As String = "exec pCotizaciones @cmd=2" & ", @fhaini='" & Format(fha_ini.SelectedDate, "yyyy-MM-dd") & "', @fhafin='" & Format(fha_fin.SelectedDate, "yyyy-MM-dd") & "', @filtrobit='" & filtroBit.Value & "', @clienteid='" & cmbfiltrocliente.SelectedValue & "', @folio='" & txtfolio.Text & "', @proyecto='" & txtProyectoFiltro.Text & "', @contacto='" & txtContactoFiltro.Text & "', @usuarioid='" & Session("userid") & "'" & ", @montoTotal = " & montoTotalTxt
            cotizacionesList.DataSource = ObjD.FillDataSet(cmd)
        End If

        If state = "on" Then
            cotizacionesList.DataBind()
        End If
        cotizacionesList.MasterTableView.NoMasterRecordsText = "No se han agregado productos"
    End Sub

    'Public Sub CotizacionesListFiltro3_NeedData(ByVal state As String)
    '    Dim ObjD As New DataControl
    '    If (fha_ini.SelectedDate < Now() And txtfolio.Text = "") Then
    '        filtrobit.Value = 1
    '        Dim cmd As String = "exec pCotizaciones @cmd=2" & ", @fhaini='" & Format(fha_ini.SelectedDate, "yyyy-MM-dd") & "', @fhafin='" & Format(fha_fin.SelectedDate, "yyyy-MM-dd") & "', @filtrobit='" & filtrobit.Value & "', @clienteid='" & cmbfiltrocliente.SelectedValue & "', @folio='" & txtfolio.Text & "', @usuarioid='" & Session("userid") & "'"
    '        cotizacionesList.DataSource = ObjD.FillDataSet(cmd)

    '    Else
    '        filtrobit.Value = 3
    '        Dim cmd As String = "exec pCotizaciones @cmd=2" & ", @fhaini='" & Format(fha_ini.SelectedDate, "yyyy-MM-dd") & "', @fhafin='" & Format(fha_fin.SelectedDate, "yyyy-MM-dd") & "', @filtrobit='" & filtrobit.Value & "', @clienteid='" & cmbfiltrocliente.SelectedValue & "', @folio='" & txtfolio.Text & "', @usuarioid='" & Session("userid") & "'"
    '        cotizacionesList.DataSource = ObjD.FillDataSet(cmd)
    '    End If
    '    'Dim cmd As String = "exec pCotizaciones @cmd=2" & ", @fhaini='" & Format(fha_ini.SelectedDate, "yyyy-MM-dd") & "', @fhafin='" & Format(fha_fin.SelectedDate, "yyyy-MM-dd") & "', @filtrobit='" & filtrobit.Value & "', @clienteid='" & cmbfiltrocliente.SelectedValue & "', @folio='" & txtfolio.Text & "', @usuarioid='" & Session("userid") & "'"
    '    'cotizacionesList.DataSource = ObjD.FillDataSet(cmd)
    '    If state = "on" Then
    '        cotizacionesList.DataBind()
    '    End If
    '    cotizacionesList.MasterTableView.NoMasterRecordsText = "No se han agregado productos"
    'End Sub
    Public Sub Buscafolio(ByVal state As String)
        Dim ObjD As New DataControl

        If (txtfolio.Text <> "") Then
            filtrobit.Value = 2
            Dim cmd As String = "exec pCotizaciones @cmd=9" & ", @fhaini='" & Format(fha_ini.SelectedDate, "yyyy-MM-dd") & "', @fhafin='" & Format(fha_fin.SelectedDate, "yyyy-MM-dd") & "', @filtrobit='" & filtrobit.Value & "', @clienteid='" & cmbfiltrocliente.SelectedValue & "', @folio='" & txtfolio.Text & "', @proyecto='" & txtProyectoFiltro.Text & "', @contacto='" & txtContactoFiltro.Text & "', @usuarioid='" & Session("userid") & "'"
            cotizacionesList.DataSource = ObjD.FillDataSet(cmd)
            If state = "on" Then
                cotizacionesList.DataBind()
            End If
        End If

    End Sub
    Public Sub BuscaProyecto(ByVal state As String)
        Dim ObjD As New DataControl

        If (txtProyectoFiltro.Text <> "" Or txtContactoFiltro.Text <> "") Then
            filtrobit.Value = 4
            Dim cmd As String = "exec pCotizaciones @cmd=12" & ", @fhaini='" & Format(fha_ini.SelectedDate, "yyyy-MM-dd") & "', @fhafin='" & Format(fha_fin.SelectedDate, "yyyy-MM-dd") & "', @filtrobit='" & filtrobit.Value & "', @clienteid='" & cmbfiltrocliente.SelectedValue & "', @folio='" & txtfolio.Text & "', @proyecto='" & txtProyectoFiltro.Text & "', @contacto='" & txtContactoFiltro.Text & "', @usuarioid='" & Session("userid") & "'"
            cotizacionesList.DataSource = ObjD.FillDataSet(cmd)
            If state = "on" Then
                cotizacionesList.DataBind()
            End If
        End If

    End Sub

    Public Sub CotizacionesListFiltro0_NeedData(ByVal state As String)
        Dim ObjD As New DataControl
        filtrobit.Value = 0
        Dim cmd As String = "exec pCotizaciones @cmd=2" & ", @fhaini='" & Format(fha_ini.SelectedDate, "yyyy-MM-dd") & "', @fhafin='" & Format(fha_fin.SelectedDate, "yyyy-MM-dd") & "', @filtrobit='" & filtrobit.Value & "', @clienteid='" & cmbfiltrocliente.SelectedValue & "', @folio='" & txtfolio.Text & "', @proyecto='" & txtProyectoFiltro.Text & "', @contacto='" & txtContactoFiltro.Text & "', @usuarioid='" & Session("userid") & "'"
        cotizacionesList.DataSource = ObjD.FillDataSet(cmd)
        If state = "on" Then
            cotizacionesList.DataBind()
        End If
        cotizacionesList.MasterTableView.NoMasterRecordsText = "No se han agregado productos"
    End Sub
    Public Sub CargaComboBox()
        Dim ObjCat As New DataControl
        Select Case Session("perfilid")
            ' Ejecutivo de ventas
            Case 3
                ObjCat.Catalogo(clienteid, "select id, isnull(razonsocial,'') as razonsocial from tblMisClientes where ejecutivoid= '" & Session("userid") & "' order by razonsocial", 0)
                ObjCat.Catalogo(cmbfiltrocliente, "select id, isnull(razonsocial,'') as razonsocial from tblMisClientes where ejecutivoid= '" & Session("userid") & "' order by razonsocial", 0)

            Case Else
                ObjCat.Catalogo(clienteid, "select id, isnull(razonsocial,'') as razonsocial from tblMisClientes order by razonsocial", 0)
                ObjCat.Catalogo(cmbfiltrocliente, "select id, isnull(razonsocial,'') as razonsocial from tblMisClientes order by razonsocial", 0)

        End Select

        'ObjCat.Catalogo(cmbTipoPrecio, "select * from tblTipoPrecio where id in (1,2,3,4,5)", 1)
        ObjCat.Catalogo(cmbTipoPrecio, "select id, nombre from tblTipoPrecio order by id", 1)
        ObjCat.Catalogo(cmbCondiciones, "select id, nombre from tblCondicionesPago order by id", 0)
        ObjCat = Nothing
    End Sub
    Protected Sub BtnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Call BuscaProductos()
    End Sub
    Private Sub BuscaProductos()
        MuestraProductos()
        panel1.Visible = True
        btnAgregaConceptos.Visible = True
        lblMensaje.Text = ""
    End Sub
    Private Sub MuestraProductos()
        If cmbTipoPrecio.SelectedValue <> 0 Then
            Dim ObjData As New DataControl()
            Dim dsData As New DataSet()
            dsData = ObjData.FillDataSet("exec pCotizacionDetalle @cmd=4, @txtSearch='" & txtSearch.Text & "', @almacenid='5', @clienteid='" & clienteid.SelectedValue & "'")
            'dsData = ObjData.FillDataSet("exec pCotizacionDetalle @cmd=4, @txtSearch='" & txtSearch.Text & "', @clienteid='" & clienteid.SelectedValue & "', @almacenid='5', @tmpPrecioid='" & cmbTipoPrecio.SelectedValue & "'")

            If Not IsNothing(dsData) Then
                productosList.DataSource = dsData
                productosList.DataBind()
            End If
            ObjData = Nothing
            'Else
            '    valTipoPrecio.IsValid = False
        End If
    End Sub
    Private Sub MuestraPedido()
        Dim ObjData As New DataControl()
        datos = ObjData.FillDataSet("exec pCotizacionDetalle @cmd=2, @cotizacionid=" & RegistroID.Value)
        If Not IsNothing(datos) Then
            cotizaciondetallelist.DataSource = datos
            cotizaciondetallelist.DataBind()
        End If
        ObjData = Nothing
        Call CheckPrecioID()
    End Sub
    Public Sub NuevaCotzacionID()
        Dim NewID As Integer = 0
        If RegistroID.Value = 0 Then
            Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
            Dim cmd As New SqlCommand($"exec pCotizaciones @cmd=1, @usuarioid='{Session("userid")}'", conn)
            conn.Open()
            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()
            If rs.Read Then
                NewID = rs("id")
            Else
                NewID = 0
            End If
            conn.Close()
            conn.Dispose()
        End If
        RegistroID.Value = NewID
    End Sub
    Public Sub SaveCotizacion()

        Dim objData As New DataControl
        objData.RunSQLScalarQuery("exec pCotizaciones @cmd=4, @id='" & RegistroID.Value &
                                  "',@clienteid='" & clienteid.SelectedValue &
                                  "',@ordenCompra='" & txtOrden.Text &
                                  "',@observaciones='" & txtObservaciones.Text &
                                  "',@contacto='" & txtContacto.Text &
                                  "',@telContacto='" & txtTelContacto.Text & '"',@condiciones='" & txtCondiciones.Text &
                                  "',@enviarA='" & txtEnviarA.Text &
                                  "',@tipoprecioid='" & cmbTipoPrecio.SelectedValue &
                                  "',@flete='" & txtFlete.Text &
                                  "',@tax='" & txtTax.Text &
                                  "',@condicionPagoId='" & cmbCondiciones.SelectedValue &
                                  "',@proyecto='" & txtProyecto.Text & "'")
        objData = Nothing

        Call EditContizacionOK(0)

        RegistroID.Value = 0
        Response.Redirect("~/portalcfd/administracion/Cotizaciones.aspx")

    End Sub
    Private Sub btnSaveCotizacion_Click(sender As Object, e As EventArgs) Handles btnSaveCotizacion.Click
        Call SaveCotizacion()
    End Sub
    Private Sub btnCancelCotizacion_Click(sender As Object, e As EventArgs) Handles btnCancelCotizacion.Click
        If InsertOrUpdate.Value = 0 Then
            Dim objData As New DataControl
            objData.RunSQLScalarQuery("exec pCotizaciones @cmd=5, @id='" & RegistroID.Value & "'")
            objData = Nothing
        Else
            Call EditContizacionOK(RegistroID.Value)
        End If
        RegistroID.Value = 0
        Response.Redirect("~/portalcfd/administracion/Cotizaciones.aspx")

    End Sub
    Private Sub cotizaciondetallelist_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles cotizaciondetallelist.ItemCommand
        Dim objdata As New DataControl()
        Select Case e.CommandName
            Case "cmdEliminar"
                objdata.RunSQLQuery("exec pCotizacionDetalle @cmd=3, @id=" & e.CommandArgument)
                Call CheckPrecioID()
                objdata = Nothing
        End Select
        Call MuestraPedido()
    End Sub

    Protected Sub txtDescripcionDetalle_TextChanged(sender As Object, e As EventArgs)
        Dim txtDescripcion As Telerik.Web.UI.RadTextBox = CType(sender, Telerik.Web.UI.RadTextBox)
        Dim gridItem As GridDataItem = CType(txtDescripcion.NamingContainer, GridDataItem)
        Dim id As String = gridItem.GetDataKeyValue("id").ToString()
        Dim nuevaDescripcion As String = txtDescripcion.Text.Replace("'", "''")
        
        Dim objData As New DataControl()
        objData.RunSQLQuery("exec pCotizacionDetalle @cmd=5, @id=" & id & ", @descripcion='" & nuevaDescripcion & "'")
        objData = Nothing
        
        Call cotizaciondetallelist_NeedData("on")
    End Sub

    Protected Sub txtPrecioDetalle_TextChanged(sender As Object, e As EventArgs)
        Dim txtPrecio As Telerik.Web.UI.RadNumericTextBox = CType(sender, Telerik.Web.UI.RadNumericTextBox)
        Dim gridItem As GridDataItem = CType(txtPrecio.NamingContainer, GridDataItem)
        Dim id As String = gridItem.GetDataKeyValue("id").ToString()
        Dim nuevoPrecio As Decimal = 0
        
        If txtPrecio.Value IsNot Nothing Then
            nuevoPrecio = CDec(txtPrecio.Value)
        End If
        
        Dim objData As New DataControl()
        objData.RunSQLQuery("exec pCotizacionDetalle @cmd=5, @id=" & id & ", @precio=" & nuevoPrecio.ToString().Replace(",", "."))
        objData = Nothing
        
        Call cotizaciondetallelist_NeedData("on")
    End Sub

    Private Sub cotizaciondetallelist_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles cotizaciondetallelist.NeedDataSource
        cotizaciondetallelist_NeedData("off")
    End Sub
    Public Sub cotizaciondetallelist_NeedData(ByVal state As String)
        Dim ObjData As New DataControl()
        datos = ObjData.FillDataSet("exec pCotizacionDetalle @cmd=2, @cotizacionid=" & RegistroID.Value)
        If Not IsNothing(datos) Then
            cotizaciondetallelist.DataSource = datos
        End If
        ObjData = Nothing
        If state = "on" Then
            cotizaciondetallelist.DataBind()
        End If
        Call CheckPrecioID()
    End Sub
    Private Sub CheckPrecioID()
        Dim ObjData As New DataControl()
        datos = ObjData.FillDataSet("exec pCotizacionDetalle @cmd=2, @cotizacionid=" & RegistroID.Value)
        If datos.Tables(0).Rows.Count = 0 Then
            cmbTipoPrecio.Enabled = True
        Else
            cmbTipoPrecio.Enabled = False
        End If
    End Sub
    Private Sub cotizacionesList_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles cotizacionesList.ItemCommand
        Dim objdata As New DataControl()
        Select Case e.CommandName
            Case "cmdEliminar"
                objdata.RunSQLQuery("exec pCotizaciones @cmd=5, @id=" & e.CommandArgument)
                objdata = Nothing
            Case "cmdEditar"

#Region "Validar si hay pedido"
                Dim dataControl As New DataControl
                Dim dtValidacion As DataTable = dataControl.FillDataSet("exec pValidacionesCotizaciones @cmd=1, " & "@id='" & e.CommandArgument & "'").Tables(0)
                Dim huboError As Boolean = False
                Dim mensajeErr As String = ""

                For Each dr As DataRow In dtValidacion.Rows
                    mensajeErr = mensajeErr & dr("mensaje") & vbNewLine
                Next

                If dtValidacion.Rows.Count > 0 Then
                    huboError = True
                    'ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('" & mensajeErr & "')")
                    'rwError.RadAlert(mensajeErr, 300, 200, "", "")
                    'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" & mensajeErr & "')", True)
                    RadWindow.VisibleOnPageLoad = True
                    lblErrores.Text = mensajeErr
                    Return
                End If

#End Region


                Call EditContizacionOK(e.CommandArgument)
                Call EditCotizacion(e.CommandArgument)
            Case "cmdPDF"
                DownloadPDF(e.CommandArgument)
        End Select
        Call CotizacionesList_NeedData("on")
    End Sub
    Public Sub EditCotizacion(ByVal id As String)
        RegistroID.Value = id
        cotizaciondetallelist_NeedData("on")
        panelAddCotizacion.Visible = True
        panelCotizacion.Visible = False
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim cmd As New SqlCommand("exec pCotizaciones @cmd=3, @id='" & id & "'", conn)
        conn.Open()
        Dim rs As SqlDataReader
        rs = cmd.ExecuteReader()
        If rs.Read Then
            Dim Folio As String = Convert.ToString(rs("id"))
            lblCotizacion.Text = "GT-" + Folio
            clienteid.SelectedValue = rs("clienteid")
            txtObservaciones.Text = rs("observaciones")
            txtContacto.Text = rs("contacto")
            txtTelContacto.Text = rs("telContacto")
            'txtCondiciones.Text = rs("condiciones")
            txtEnviarA.Text = rs("enviarA")
            txtOrden.Text = rs("ordenCompra")
            cmbTipoPrecio.SelectedValue = rs("tipoprecioid")
            ValidaTipoPrecioOption(rs("tipoprecioid"))
            txtProyecto.Text = rs("proyecto")
            cmbCondiciones.SelectedValue = rs("condicionPagoId")
            If rs("tipoprecioid") = 5 Then
                txtTax.Text = rs("tax")
            Else
                If rs("flete") > -1 Then
                    Call ValInput_CostoFlete(True)
                    txtFlete.Text = rs("flete")
                Else
                    bFlete.Checked = False
                    Call ValInput_CostoFlete(False)
                End If
            End If
        End If
        conn.Close()
        conn.Dispose()
    End Sub
    Private Sub EditContizacionOK(ByVal state As Integer)
        If state = 0 Then
            InsertOrUpdate.Value = 0
            btnSaveCotizacion.Text = "Guardar Cotización"
            Label1.Text = "Agregar nueva cotizacion"
        Else
            InsertOrUpdate.Value = 1
            btnSaveCotizacion.Text = "Actualiza Cotización"
            Label1.Text = "Editar Cotización"
        End If
    End Sub

    Private Sub btnCancelarBusqueda_Click(sender As Object, e As EventArgs) Handles btnCancelarBusqueda.Click
        panel1.Visible = False
        btnAgregaConceptos.Visible = False
        lblMensaje.Text = ""
    End Sub
#End Region
#Region "Manejo de PDF"
    Private Sub DownloadPDF(ByVal id As Long)
        Dim TipoDOC As Integer = 0
        Dim fecha As String = ""
        Dim registro As Long = 0
        Dim connF As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim cmdF As New SqlCommand("exec pCotizaciones @cmd=3, @id='" & id.ToString & "'", connF)
        Try

            connF.Open()

            Dim rs As SqlDataReader
            rs = cmdF.ExecuteReader()

            If rs.Read Then
                fecha = rs("fechaCotizacion").ToString
                registro = rs("id").ToString
                TipoDOC = rs("tipoprecioid")
            End If
        Catch ex As Exception
            '
        Finally
            connF.Close()
            connF.Dispose()
            connF = Nothing
        End Try
        '
        Dim FilePath = Server.MapPath("~/portalcfd/pdf/") & "Cotizacion_" & registro.ToString & ".pdf"
        'If File.Exists(FilePath) Then
        '    Dim FileName As String = Path.GetFileName(FilePath)
        '    Response.Clear()
        '    Response.ContentType = "application/octet-stream"
        '    Response.AddHeader("Content-Disposition", "attachment; filename=""" & FileName & """")
        '    Response.Flush()
        '    Response.WriteFile(FilePath)
        '    Response.End()
        'Else
        If TipoDOC = 5 Or TipoDOC = 6 Then
            GuardaPDF(GeneraCotizacionPDF_USD(id), FilePath)
        Else
            GuardaPDF(GeneraCotizacionPDF(id), FilePath)
        End If


        Dim FileName As String = Path.GetFileName(FilePath)
        Response.Clear()
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", "attachment; filename=""" & FileName & """")
        Response.Flush()
        Response.WriteFile(FilePath)
        Response.End()
        'End If
        ''
    End Sub
    Private Sub GuardaPDF(ByVal report As Telerik.Reporting.Report, ByVal fileName As String)
        Dim reportProcessor As New Telerik.Reporting.Processing.ReportProcessor()
        Dim result As RenderingResult = reportProcessor.RenderReport("PDF", report, Nothing)
        Using fs As New FileStream(fileName, FileMode.Create)
            fs.Write(result.DocumentBytes, 0, result.DocumentBytes.Length)
        End Using
    End Sub
    Private Function GeneraCotizacionPDF(ByVal id As Long) As Telerik.Reporting.Report
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim fechaCotizacion As DateTime
        Dim ordenCompra As String = ""
        Dim observaciones As String = ""
        Dim condiciones As String = ""
        Dim condiciones2 As String = ""
        Dim tax As String = ""
        Dim cotizacionID As Integer = 0
        Dim cobrarA As String = ""
        Dim enviarA As String = ""
        Dim RepVentas As String = ""
        Dim MailRepVentas As String = ""
        Dim Proyecto As String = ""
        Dim contacto As String = ""
        Dim contactoCliente As String = ""

        Dim ds As DataSet = New DataSet
        Try
            Dim cmd As New SqlCommand("EXEC [pCotizaciones] @cmd=3, @id='" & id.ToString & "'", conn)
            conn.Open()
            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read Then
                cotizacionID = rs("id")
                fechaCotizacion = rs("fechaCotizacion")
                ordenCompra = rs("ordenCompra")
                observaciones = rs("observaciones")
                condiciones = rs("condiciones")
                cobrarA = rs("CobrarA")
                enviarA = rs("EnviarA")
                RepVentas = rs("RepVentas")
                MailRepVentas = rs("MailRepVentas")
                Proyecto = rs("proyecto")
                condiciones2 = rs("IdCondicionesNombre")
                contacto = rs("contacto")
                contactoCliente = rs("contactoCliente")

            End If
            rs.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            conn.Close()
        End Try
        Dim reporte As New CotizacionPDF

        reporte.ReportParameters("paramImgBanner2").Value = Server.MapPath("~/portalcfd/logos/" & "none.png")
        reporte.ReportParameters("txtordenCompra").Value = ordenCompra
        reporte.ReportParameters("txtfechaCotizacion").Value = Format(fechaCotizacion, "dd MMMM yyyy")
        reporte.ReportParameters("txtObservacionesCotizacion").Value = observaciones
        reporte.ReportParameters("txtCondiciones").Value = condiciones
        reporte.ReportParameters("cotizacionID").Value = cotizacionID
        reporte.ReportParameters("txtCobrarA").Value = cobrarA
        If contacto = "" Then
            reporte.ReportParameters("txtContacto").Value = contactoCliente
        Else
            reporte.ReportParameters("txtContacto").Value = contacto
        End If
        'reporte.ReportParameters("txtEnviarA").Value = enviarA
        reporte.ReportParameters("txtTitulo").Value = $"Cotización Folio No. {cotizacionID}"
        '
        reporte.ReportParameters("txtRepVentas").Value = RepVentas
        reporte.ReportParameters("txtMailRepVentas").Value = MailRepVentas
        reporte.ReportParameters("txtProyecto").Value = Proyecto
        reporte.ReportParameters("txtCondiciones").Value = condiciones
        reporte.ReportParameters("txtCondiciones2").Value = condiciones2
        '
        Try
            Dim cmd As New SqlCommand("EXEC pCotizaciones @cmd=6", conn)
            conn.Open()

            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read Then
                reporte.ReportParameters("txtLinea1").Value = rs("txtLinea1")
                reporte.ReportParameters("txtLinea2").Value = rs("txtLinea2")
                reporte.ReportParameters("txtLinea3").Value = rs("txtLinea3")
                reporte.ReportParameters("txtLinea4").Value = rs("txtLinea4")
                reporte.ReportParameters("txtLinea5").Value = rs("txtLinea5")
                reporte.ReportParameters("txtLinea6").Value = rs("txtLinea6")
                reporte.ReportParameters("paramImgBanner").Value = Server.MapPath("~/portalcfd/logos/" & rs("logo_cotizacion").ToString)
            End If

        Catch ex As Exception
        Finally
            conn.Close()
        End Try
        '
        Try
            Dim cmd As New SqlCommand("EXEC pCotizaciones @cmd=7 , @id = '" & id.ToString & "'", conn)
            conn.Open()

            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read Then
                reporte.ReportParameters("txtSubtotal").Value = FormatCurrency(rs("subtotal"))
                reporte.ReportParameters("txtIva").Value = FormatCurrency(rs("iva"))
                reporte.ReportParameters("txtTotal").Value = FormatCurrency(rs("total"))
                If rs("fleteb") > -1 Then
                    reporte.ReportParameters("txtFlete").Value = FormatCurrency(rs("flete"))
                Else
                    reporte.ReportParameters("txtFlete").Value = "Por definir"
                End If
                reporte.ReportParameters("txtAnticipo").Value = FormatCurrency(rs("Anticipo"))
            End If

        Catch ex As Exception
        Finally
            conn.Close()
            conn.Dispose()
        End Try
        Return reporte
    End Function
    Private Function GeneraCotizacionPDF_USD(ByVal id As Long) As Telerik.Reporting.Report
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim fechaCotizacion As String = ""
        Dim ordenCompra As String = ""
        Dim observaciones As String = ""
        Dim condiciones As String = ""
        Dim tax As String = ""
        Dim cotizacionID As Integer = 0
        Dim cobrarA As String = ""
        Dim enviarA As String = ""
        Dim contacto As String = ""
        Dim contactoCliente As String = ""

        Dim ds As DataSet = New DataSet
        Try
            Dim cmd As New SqlCommand("EXEC [pCotizaciones] @cmd=3, @id='" & id.ToString & "'", conn)
            conn.Open()
            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()
            If rs.Read Then
                cotizacionID = rs("id")
                fechaCotizacion = rs("fechaCotizacion")
                ordenCompra = rs("ordenCompra")
                observaciones = rs("observaciones")
                condiciones = rs("condiciones")
                cobrarA = rs("CobrarA")
                enviarA = rs("EnviarA")
                contacto = rs("contacto")
                contactoCliente = rs("contactoCliente")
            End If
            rs.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            conn.Close()
        End Try

        Dim reporte As New CotizacionProductosPDF_elm.ReportePDF_USD

        reporte.ReportParameters("paramImgBanner2").Value = Server.MapPath("~/portalcfd/logos/" & "none.png")
        reporte.ReportParameters("txtordenCompra").Value = ordenCompra
        reporte.ReportParameters("txtfechaCotizacion").Value = FormatDateTime(fechaCotizacion, DateFormat.ShortDate)
        reporte.ReportParameters("txtObservacionesCotizacion").Value = observaciones
        reporte.ReportParameters("txtCondiciones").Value = condiciones
        reporte.ReportParameters("cotizacionID").Value = cotizacionID
        reporte.ReportParameters("txtCobrarA").Value = cobrarA
        If contacto = "" Then
            reporte.ReportParameters("txtContacto").Value = contactoCliente
        Else
            reporte.ReportParameters("txtContacto").Value = contacto
        End If
        'reporte.ReportParameters("txtEnviarA").Value = enviarA
        reporte.ReportParameters("txtTitulo").Value = $"ARM-{cotizacionID}"
        '
        Try
            Dim cmd As New SqlCommand("EXEC pCotizaciones @cmd=6", conn)
            conn.Open()

            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read Then
                reporte.ReportParameters("txtLinea1").Value = rs("txtLinea1")
                reporte.ReportParameters("txtLinea2").Value = rs("txtLinea2")
                reporte.ReportParameters("txtLinea3").Value = rs("txtLinea3")
                reporte.ReportParameters("txtLinea4").Value = rs("txtLinea4")
                reporte.ReportParameters("txtLinea5").Value = rs("txtLinea5")
                reporte.ReportParameters("txtLinea6").Value = rs("txtLinea6")
                reporte.ReportParameters("paramImgBanner").Value = Server.MapPath("~/portalcfd/logos/" & rs("logo_cotizacion").ToString)
            End If

        Catch ex As Exception
        Finally
            conn.Close()
        End Try
        '
        Try
            Dim cmd As New SqlCommand("EXEC pCotizaciones @cmd=8 , @id = '" & id.ToString & "'", conn)
            conn.Open()

            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read Then
                reporte.ReportParameters("txtSubtotal").Value = FormatCurrency(rs("subtotal"))
                reporte.ReportParameters("txtTaxText").Value = rs("taxText")
                reporte.ReportParameters("txtTax").Value = FormatCurrency(rs("tax"))
                reporte.ReportParameters("txtTotal").Value = FormatCurrency(rs("total"))

            End If

        Catch ex As Exception
        Finally

            conn.Close()
            conn.Dispose()

        End Try
        Return reporte
    End Function
    Private Sub cmbTipoPrecio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoPrecio.SelectedIndexChanged
        ValidaTipoPrecioOption(cmbTipoPrecio.SelectedValue)
        panel1.Visible = False
        btnAgregaConceptos.Visible = False
        If txtSearch.Text.Length > 0 Then
            Call BuscaProductos()
        End If
    End Sub
    Private Sub ValidaTipoPrecioOption(ByVal state As Integer )
        If state = 5 Or state = 6 Then
            panelTax.Visible = True
            panelFlete.Visible = False
        Else
            txtTax.Text = ""
            panelTax.Visible = False
            panelFlete.Visible = True
        End If
    End Sub
    Private Sub bFlete_CheckedChanged(sender As Object, e As EventArgs) Handles bFlete.CheckedChanged
        Call ValInput_CostoFlete(bFlete.Checked)
    End Sub

    Private Sub ValInput_CostoFlete(ByVal state As Boolean)
        If state = True Then
            txtFlete.Value = 0
            lblpd.Visible = False
            txtFlete.Visible = True
        Else
            txtFlete.Value = -1
            txtFlete.Visible = False
            lblpd.Visible = True
        End If
    End Sub
    'btnCrearPedido_Click [triangulado]
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Obj As New DataControl
        Dim saldo As Decimal
        Dim ObjData As New DataControl
        saldo = ObjData.RunSQLScalarQueryDecimal("select isnull(sum(a.importe),0)+isnull(sum(a.iva),0)-isnull(sum(a.importe_descuento),0) as saldo from tblCFD_Partidas a inner join tblCFD b on b.id=a.cfdid where b.estatus_cobranzaId=1 and b.estatus<>3 and DATEDIFF(D, b.fecha_promesa, GETDATE())>0 and b.timbrado=1 and dbo.fnTipoDocumentoId(b.serie, b.folio)=1 and b.clienteid='" & clienteid.SelectedValue.ToString & "'")
        ObjData = Nothing

        If Session("perfilid") <> 1 Then
            If saldo > 0 Then
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
    Private Sub AgregaPedido()
        Dim id As Integer = 0
        Dim ObjData As New DataControl
        Try
            id = ObjData.RunSQLScalarQuery("exec pPedidos @cmd=1, @userid=" & Session("userid") & ", @estatusid=1, @clienteid='" & clienteid.SelectedValue & "',@idcotizacion ='" & RegistroID.Value & "',  @tasaid=3, @orden_compra='" & txtOrden.Text & "'")

            Call agregaConceptos(id)
            Response.Redirect("~/portalcfd/pedidos/editapedido.aspx?id=" & id.ToString())
        Catch ex As Exception
            lblMensaje.Text = "Error: " + ex.Message.ToString()
        End Try
        ObjData = Nothing
    End Sub
    Private Sub agregaConceptos(ByVal pedidoid As Integer)
        Dim productoId As Long = 0
        Dim strCodigo, strDescripcion, strunidad As String
        Dim dblCantidad, dlPrecio As Double
        Dim valida As Integer = 0
        Dim mensaje As String = ""
        Dim ObjData As New DataControl
        For Each row As GridDataItem In cotizaciondetallelist.MasterTableView.Items
            productoId = row.GetDataKeyValue("productoid")
            strCodigo = row.GetDataKeyValue("codigo")
            strDescripcion = row.GetDataKeyValue("descripcion")
            strunidad = row.GetDataKeyValue("unidad")
            dlPrecio = row.GetDataKeyValue("precio")
            dblCantidad = row.GetDataKeyValue("cantidad")
            ObjData.RunSQLQuery("exec pPedidosConceptos @cmd=1, @pedidoid=" & pedidoid & ", @productoid=" & productoId.ToString & ", @codigo='" & strCodigo & "', @descripcion = '" & strDescripcion & "', @cantidad=" & dblCantidad & ", @unidad='" & strunidad & "', @precio='" & dlPrecio & "'")
        Next
        ObjData = Nothing
    End Sub

    Private Sub cotizaciondetallelist_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles cotizaciondetallelist.ItemDataBound
        Dim itm As Telerik.Web.UI.GridDataItem

        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem
                Dim imgBtnEliminar As ImageButton = CType(e.Item.FindControl("btnEliminar"), ImageButton)

                imgBtnEliminar.Attributes.Add("onclick", "javascript:return confirm('Va a eliminar un concepto del pedido. ¿Desea continuar?');")

                itm = CType(e.Item, Telerik.Web.UI.GridDataItem)

                If estatusId.Value > 1 Then
                    imgBtnEliminar.Visible = False
                End If
            Case Telerik.Web.UI.GridItemType.Footer
                If datos.Tables(0).Rows.Count > 0 Then
                    e.Item.Cells(7).Text = datos.Tables(0).Compute("sum(cantidad)", "")
                    e.Item.Cells(7).HorizontalAlign = HorizontalAlign.Right
                    e.Item.Cells(7).Font.Bold = True
                    '
                    e.Item.Cells(8).Text = FormatCurrency(datos.Tables(0).Compute("sum(importe)", ""), 2).ToString
                    e.Item.Cells(8).HorizontalAlign = HorizontalAlign.Right
                    e.Item.Cells(8).Font.Bold = True
                    '
                    '
                    e.Item.Cells(9).Text = FormatCurrency(datos.Tables(0).Compute("sum(iva)", ""), 2).ToString
                    e.Item.Cells(9).HorizontalAlign = HorizontalAlign.Right
                    e.Item.Cells(9).Font.Bold = True
                    '
                End If
        End Select
    End Sub

    Private Sub cotizacionesList_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles cotizacionesList.ItemDataBound
        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem
                Dim btnDelete As LinkButton = CType(e.Item.FindControl("lnkBorrar"), LinkButton)
                btnDelete.Attributes.Add("onclick", "javascript:return confirm('Va a eliminar un pedido. ¿Desea continuar?')")
        End Select

    End Sub

    Private Sub HiddenButtonOk_Click(sender As Object, e As EventArgs) Handles HiddenButtonOk.Click
        Call AgregaPedido()
    End Sub

    Private Sub btnFiltroOff_Click(sender As Object, e As EventArgs) Handles btnFiltroOff.Click
        filtrobit.Value = 0
        cmbfiltrocliente.SelectedValue = 0
        txtfolio.Text = ""
        txtProyectoFiltro.Text = ""
        txtContactoFiltro.Text = ""
        CotizacionesList_NeedData("on")
    End Sub

    Private Sub btnFitroOn_Click(sender As Object, e As EventArgs) Handles btnFitroOn.Click
        filtrobit.Value = 1
        CotizacionesList_NeedData("on")
    End Sub

    Private Sub btnFolio_Click(sender As Object, e As EventArgs) Handles btnFolio.Click
        filtrobit.Value = 2
        Buscafolio("on")
    End Sub
    Private Sub btnCLiente3_Click(sender As Object, e As EventArgs) Handles btnCLiente3.Click
        filtrobit.Value = 3
        CotizacionesList_NeedData("on")
    End Sub

    Private Sub productosList_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles productosList.ItemDataBound
        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem
                Dim txtUnitaryPrice As RadNumericTextBox = CType(e.Item.FindControl("txtUnitaryPrice"), RadNumericTextBox)
                Dim lblPrecioUnitario As RadNumericTextBox = CType(e.Item.FindControl("lblPrecioUnitario"), RadNumericTextBox)
                Dim lblDescripcion As RadTextBox = CType(e.Item.FindControl("txtDescripcion"), RadTextBox)
                Dim descripcion As RadTextBox = CType(e.Item.FindControl("descripcion"), RadTextBox)
                Dim cmbPrecioUnitario As RadDropDownList = CType(e.Item.FindControl("cmbPrecioUnitario"), RadDropDownList)

                Dim productoid = e.Item.DataItem("productoid")
                If productoid = 191 Then
                    txtUnitaryPrice.Visible = True
                    lblPrecioUnitario.Visible = False
                ElseIf productoid = 580 Then
                    txtUnitaryPrice.Visible = True
                    lblDescripcion.Visible = True
                    lblPrecioUnitario.Visible = False
                    descripcion.Visible = False
                ElseIf productoid = 91147 Then
                    txtUnitaryPrice.Visible = True
                    lblDescripcion.Visible = True
                    lblPrecioUnitario.Visible = False
                    descripcion.Visible = False
                ElseIf productoid = 631 Then
                    txtUnitaryPrice.Visible = True
                    lblDescripcion.Visible = True
                    lblPrecioUnitario.Visible = False
                    descripcion.Visible = False
                End If

                'cmbPrecioUnitario.on
                cmbPrecioUnitario.Items.Add(New DropDownListItem("Unitario 1", e.Item.DataItem("unitario")))
                cmbPrecioUnitario.Items.Add(New DropDownListItem("Unitario 2", e.Item.DataItem("unitario2")))
                cmbPrecioUnitario.Items.Add(New DropDownListItem("Unitario 3", e.Item.DataItem("unitario3")))
                If Session("usrPropVerPrecioUnit4") = True Then
                    cmbPrecioUnitario.Items.Add(New DropDownListItem("Unitario 4", e.Item.DataItem("unitario4")))
                Else
                    cmbPrecioUnitario.Items.Add(New DropDownListItem("Unitario 4", 0))
                End If
                cmbPrecioUnitario.Items.Add(New DropDownListItem("Unitario 5", e.Item.DataItem("unitario5")))
                cmbPrecioUnitario.Items.Add(New DropDownListItem("Unitario 6", e.Item.DataItem("unitario6")))

                txtUnitaryPrice.Text = e.Item.DataItem("precio")
        End Select
    End Sub

#End Region

#Region "Reporte Excel"
    Private selectedItems As New System.Collections.Generic.List(Of Integer)()
    Private selectedPedidos As New System.Collections.Generic.List(Of Integer)()

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim cacheTable As New DataTable
        '
        cacheTable.Columns.Add("folio", GetType(String))
        cacheTable.Columns.Add("fechaCotizacion", GetType(String))
        cacheTable.Columns.Add("cliente", GetType(String))
        cacheTable.Columns.Add("pedido", GetType(String))
        cacheTable.Columns.Add("ordenCompra", GetType(String))
        cacheTable.Columns.Add("proyecto", GetType(String))
        cacheTable.Columns.Add("vendedor", GetType(String))
        cacheTable.Columns.Add("TipoPrecio", GetType(String))
        '
        Dim Obj As New DataControl
        Dim dt As New DataSet

        If filtrobit.Value = 2 Then
            dt = Obj.FillDataSet("exec pCotizaciones @cmd=11" & ", @fhaini='" & Format(fha_ini.SelectedDate, "yyyy-MM-dd") & "', @fhafin='" & Format(fha_fin.SelectedDate, "yyyy-MM-dd") & "', @filtrobit='" & filtrobit.Value & "', @clienteid='" & cmbfiltrocliente.SelectedValue & "', @folio='" & txtfolio.Text & "', @proyecto='" & txtProyectoFiltro.Text & "', @contacto='" & txtContactoFiltro.Text & "', @usuarioid='" & Session("userid") & "'")
        Else
            dt = Obj.FillDataSet("exec pCotizaciones @cmd=10" & ", @fhaini='" & Format(fha_ini.SelectedDate, "yyyy-MM-dd") & "', @fhafin='" & Format(fha_fin.SelectedDate, "yyyy-MM-dd") & "', @filtrobit='" & filtrobit.Value & "', @clienteid='" & cmbfiltrocliente.SelectedValue & "', @folio='" & txtfolio.Text & "', @proyecto='" & txtProyectoFiltro.Text & "', @contacto='" & txtContactoFiltro.Text & "', @usuarioid='" & Session("userid") & "'")
        End If
        For Each row As DataRow In dt.Tables(0).Rows
            cacheTable.Rows.Add(row("folio"), CType(row("fechaCotizacion"), DateTime).ToString("MM/dd/yyyy"), row("cliente"), row("pedido"), row("ordenCompra"), row("proyecto"), row("vendedor"), row("TipoPrecio"))
        Next
        'CType(row("fechaCotizacion"), DateTime).ToString("dd")

        '
        ExcelGrid.DataSource = cacheTable
        ExcelGrid.DataBind()
        '
        ExcelGrid.ExportSettings.OpenInNewWindow = True
        ExcelGrid.ExportSettings.FileName = "Cotizaciones_" & Format(Now(), "ddMMyy HHmmss")
        ExcelGrid.MasterTableView.ExportToExcel()

    End Sub

    Private Sub ExcelGrid_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles ExcelGrid.NeedDataSource
        Dim dt As New DataTable
        ExcelGrid.DataSource = dt
    End Sub

    Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs)

    End Sub

    Protected Sub descripcion_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub cmbPrecioUnitario_ItemSelected(sender As Object, e As DropDownListEventArgs)

    End Sub
    Protected Sub clienteid_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Try
            Dim cmd As New SqlCommand("EXEC pCotizaciones @cmd=13 , @clienteid = '" & clienteid.SelectedValue & "'", conn)
            conn.Open()

            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read() Then
                txtContacto.Text = rs("contacto").ToString()
            Else
                txtContacto.Text = ""
            End If

        Catch ex As Exception
        Finally

            conn.Close()
            conn.Dispose()

        End Try
    End Sub

#End Region

End Class