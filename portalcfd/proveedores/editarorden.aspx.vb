Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Globalization
Imports System.Threading

Public Class editarorden
    Inherits System.Web.UI.Page
    Private ds As DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not String.IsNullOrEmpty(Request("id")) Then
                Call MuestraDatosGenerales()
                Call CargaConceptos()
            End If
        End If
        '
        btnProcess.Attributes.Add("onclick", "javascript:return confirm('Va a procesar este pedido, una vez procesado no podrá modificarlo. ¿Desea continuar?');")
        '
    End Sub
    Private Sub MuestraDatosGenerales()
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)

        Try

            Dim cmd As New SqlCommand("exec pOrdenCompra @cmd=3, @ordenid='" & Request("id").ToString & "'", conn)

            conn.Open()

            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read Then
                lblOrden.Text = rs("clave").ToString
                Dim ObjData As New DataControl
                ObjData.Catalogo(proveedorid, "select id, razonsocial as nombre from tblMisProveedores order by razonsocial", rs("proveedorid"))
                ObjData.Catalogo(cmbCondiciones, "select id, nombre from tblCondiciones order by nombre", rs("condicionesid"))
                ObjData.Catalogo(cmbDireccion,
                    " SELECT dr.id, " &
                    "     'Calle ' + calle + ', No. ' + numero_exterior +  " &
                    " Case " &
                    "         when ISNULL(numero_interior, '') = '' then '' " &
                    "         Else ' Int. ' + numero_interior  " &
                    " End + " &
                    "     ', ' + colonia + ', ' + dbo.fn_camelcase(municipio) + ', ' + dbo.fn_camelcase(st.nombre) + ', ' + dbo.fn_camelcase(dr.pais) as nombre " &
                    " FROM " &
                    " tblDireccion dr " &
                    " Left Join tblEstado st ON st.id = dr.estadoid",
                    rs("direccionid")
                )

                ObjData.Catalogo(cmbMensajeria, "select id, descripcion as nombre from tblMensajeria order by nombre", rs("mensajeriaid"))
                ObjData.Catalogo(cmbUsuarioSolicita, "select id, nombre from tblUsuario order by nombre", rs("userid"))
                ObjData.Catalogo(cmbUsuarioAutoriza, "select id, nombre from tblUsuario order by nombre", rs("usuarioautoriza"))

                'ObjData.Catalogo(cmbDireccion, "select id, razonsocial as nombre from tblMisProveedores order by razonsocial", rs("direccionid"))
                ObjData = Nothing
                'txtShipTo.Text = rs("shipto")
                txtShipVia.Text = rs("shipvia")
                txtOCTelefono.Text = rs("phone")
                txtOCEmail.Text = rs("email")
                txtOCFob.Text = rs("Fob")
                txtComentarios.Text = rs("comentarios")

                'txtMensajeriaid = rs("mensajeriaid")
                rdFletePrepagado.SelectedIndex = IIf(rs("fleteprepagado"), 1, 0)
                txtProyectoNombre.Text = rs("proyectonombre")
                txtProyectoLugar.Text = rs("proyectolugar")

                'cmbUsuarioSolicita.SelectedValue = rs("usuariosolicita")
                'cmbUsuarioAutoriza.SelectedValue = rs("usuarioautoriza")

                Session("estatusid") = rs("estatusid")

                'If Session("estatusid").ToString = "3" Then
                '    btnProcess.Enabled = False
                '    btnProcess.ToolTip = "Operación no permitida."
                'End If

                'en teoría me deberían de proporcionar el criterio de usuario autorizador
                'tampoco sé si proponer solución.
                'cmbUsuarioSolicita.Enabled = False
                'cmbUsuarioAutoriza.Enabled = False

                If rs("estatusid") <> 1 Then
                    proveedorid.Enabled = False
                    txtComentarios.Enabled = False
                    txtSearch.Enabled = False
                    txtShipVia.Enabled = False

                    txtOCTelefono.Enabled = False
                    txtOCEmail.Enabled = False
                    txtOCFob.Enabled = False

                    cmbDireccion.Enabled = False
                    cmbCondiciones.Enabled = False
                    cmbMensajeria.Enabled = False

                    rdFletePrepagado.Enabled = False
                    txtProyectoNombre.Enabled = False
                    txtProyectoLugar.Enabled = False

                    cmbUsuarioSolicita.Enabled = False
                    cmbUsuarioAutoriza.Enabled = False

                    btnAddorder.Enabled = False
                    btnProcess.Enabled = False
                    btnSearch.Enabled = False
                    btnCancel.Enabled = False

                    conceptosList.Enabled = False

                End If
            End If
        Catch ex As Exception
        Finally
            conn.Close()
            conn.Dispose()
            conn = Nothing
        End Try
    End Sub
    Private Sub CargaConceptos()
        Dim ObjData As New DataControl
        ds = ObjData.FillDataSet("exec pOrdenCompra @cmd=7, @ordenid='" & Request("id").ToString & "'")
        conceptosList.DataSource = ds
        conceptosList.DataBind()
        ObjData = Nothing
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("~/portalcfd/proveedores/ordenes_compra.aspx")
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        panelSearch.Visible = True
        btnAgregaConceptos.Visible = True
        Dim ObjData As New DataControl
        resultslist.DataSource = ObjData.FillDataSet("exec pMisProductos @cmd=1, @txtSearch='" & txtSearch.Text & "'")
        resultslist.DataBind()
        ObjData = Nothing
    End Sub
    Private Sub resultslist_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles resultslist.ItemCommand
        Select Case e.CommandName
            Case "cmdAdd"
                Call AgregaItem(e.CommandArgument, e.Item)
        End Select
    End Sub
    Private Sub resultslist_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles resultslist.NeedDataSource
        Dim ObjData As New DataControl
        resultslist.DataSource = ObjData.FillDataSet("exec pMisProductos @cmd=1, @txtSearch='" & txtSearch.Text & "'")
        ObjData = Nothing
    End Sub
    Private Sub AgregaItem(ByVal productoId As Long, ByVal item As GridItem)
        Dim txtCantidad As RadNumericTextBox = DirectCast(item.FindControl("txtCantidad"), RadNumericTextBox)
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pOrdenCompra @cmd=5, @ordenId='" & Request("id").ToString & "', @cantidad='" & txtCantidad.Text & "', @productoId='" & productoId.ToString & "'")
        ObjData = Nothing
        '
        txtSearch.Text = ""
        panelSearch.Visible = False
        Call CargaConceptos()
        '
    End Sub
    Private Sub conceptosList_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles conceptosList.ItemCommand
        Select Case e.CommandName
            Case "cmdDelete"
                Call EliminaConcepto(e.CommandArgument)
                Call CargaConceptos()
        End Select
    End Sub
    Private Sub conceptosList_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles conceptosList.ItemDataBound
        Select Case e.Item.ItemType
            Case GridItemType.Item, GridItemType.AlternatingItem
                Dim txtCantidad As RadNumericTextBox = CType(e.Item.FindControl("txtCantidad"), RadNumericTextBox)
                txtCantidad.Text = e.Item.DataItem("cantidad")
                '
                Dim btnDelete As ImageButton = CType(e.Item.FindControl("btnDelete"), ImageButton)
                btnDelete.Attributes.Add("onclick", "javascript:return confirm('Va a eliminar un concepto de la orden de compra. ¿Desea continuar?');")

                If Session("estatusid") <> 1 Then
                    btnDelete.Visible = False
                End If
                '
            Case GridItemType.Footer
                If ds.Tables(0).Rows.Count > 0 Then
                    e.Item.Cells(4).Text = ds.Tables(0).Compute("sum(cantidad)", "")
                    e.Item.Cells(4).Font.Bold = True
                    e.Item.Cells(4).HorizontalAlign = HorizontalAlign.Center
                    e.Item.Cells(6).Text = FormatCurrency(ds.Tables(0).Compute("sum(costo_variable)", ""), 2).ToString
                    e.Item.Cells(6).Font.Bold = True
                    e.Item.Cells(6).HorizontalAlign = HorizontalAlign.Right
                    e.Item.Cells(7).Text = FormatCurrency(ds.Tables(0).Compute("sum(total)", ""), 2).ToString
                    e.Item.Cells(7).Font.Bold = True
                    e.Item.Cells(7).HorizontalAlign = HorizontalAlign.Right
                End If
        End Select
    End Sub
    Private Sub conceptosList_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles conceptosList.NeedDataSource
        Dim ObjData As New DataControl
        ds = ObjData.FillDataSet("exec pOrdenCompra @cmd=7, @ordenid='" & Request("id").ToString & "'")
        conceptosList.DataSource = ds
        ObjData = Nothing
    End Sub
    Private Sub EliminaConcepto(ByVal conceptoid As Long)
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pOrdenCompra @cmd=6, @conceptoid='" & conceptoid.ToString & "'")
        ObjData = Nothing
    End Sub
    Protected Sub btnAddorder_Click(sender As Object, e As EventArgs) Handles btnAddorder.Click
        '
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-US")
        '
        Dim conceptoId As Long = 0

        'TODO: add this fields to query
        'txtMensajeriaid = rs("mensajeriaid")
        'rdFletePrepagado.SelectedIndex = rs("fleteprepagado")
        'txtProyectoNombre = rs("proyectonombre")
        'txtProyectoLugar = rs("proyectolugar")

        'txtUsuarioSolicita = rs("usuariosolicita")
        'txtUsuarioAutoriza = rs("usuarioautoriza")

        'Dim fletePrepagado = 

        Dim ObjDataOC As New DataControl
        ObjDataOC.RunSQLQuery("exec pOrdenCompra @cmd=14, @ordenid='" & Request("id").ToString &
                              "', @proveedorid = '" & proveedorid.SelectedValue & " '," & "@shipvia = '" & txtShipVia.Text & "'," & "@comentarios = '" & txtComentarios.Text & "'," & "@direccionid = '" & cmbDireccion.SelectedValue & "'," & "@phone = '" & txtOCTelefono.Text & "'," & "@email = '" & txtOCEmail.Text & "'," & "@condicionesid = '" & cmbCondiciones.SelectedValue & "', @fob = '" & txtOCFob.Text &
                              "', @mensajeriaid = '" & cmbMensajeria.SelectedValue.ToString & "', " & "@fleteprepagado = '" & rdFletePrepagado.SelectedIndex & "', " & "@usuarioautoriza = '" & cmbUsuarioAutoriza.SelectedValue & "', " & "@proyectonombre = '" & txtProyectoNombre.Text & "', " & "@proyectolugar = '" & txtProyectoLugar.Text & "'")

        Dim ObjData As New DataControl
        For Each row As GridDataItem In conceptosList.MasterTableView.Items
            conceptoId = row.GetDataKeyValue("id")
            Dim txtCantidad As RadNumericTextBox = DirectCast(row.FindControl("txtCantidad"), RadNumericTextBox)
            ObjData.RunSQLQuery("exec pOrdenCompra @cmd=8, @conceptoid='" & conceptoId.ToString & "', @cantidad='" & txtCantidad.Text & "'")
        Next
        ObjData = Nothing
        '
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-MX")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("es-MX")
        '
        lblMensaje.Text = "Datos actualizados."
        '
        Call CargaConceptos()
        '
    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtSearch.Text = ""
        panelSearch.Visible = False
    End Sub
    Private Sub btnProcess_Click(sender As Object, e As System.EventArgs) Handles btnProcess.Click
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pOrdenCompra @cmd=9, @ordenid='" & Request("id").ToString & "'")
        ObjData = Nothing
        Response.Redirect("~/portalcfd/proveedores/ordenes_compra.aspx")
    End Sub
    Private Sub btnAgregaConceptos_Click(sender As Object, e As EventArgs) Handles btnAgregaConceptos.Click
        '
        Dim productoId As Long = 0
        Dim ObjData As New DataControl
        For Each row As GridDataItem In resultslist.MasterTableView.Items
            productoId = row.GetDataKeyValue("id")
            Dim txtCantidad As RadNumericTextBox = DirectCast(row.FindControl("txtCantidad"), RadNumericTextBox)
            If Convert.ToDecimal(txtCantidad.Text.ToString) > 0 Then
                ObjData.RunSQLQuery("exec pOrdenCompra @cmd=5, @ordenId='" & Request("id").ToString & "', @cantidad='" & txtCantidad.Text & "', @productoId='" & productoId.ToString & "'")
            End If
        Next
        ObjData = Nothing
        '
        txtSearch.Text = ""
        panelSearch.Visible = False
        btnAgregaConceptos.Visible = False
        Call CargaConceptos()
    End Sub

End Class