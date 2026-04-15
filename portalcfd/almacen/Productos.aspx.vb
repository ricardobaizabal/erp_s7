Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Class portalcfd_Productos
    Inherits System.Web.UI.Page
    Private ds As DataSet
    Public firstOpen As Boolean
    '
    '  Comentarios para el programador:
    '
    '   Debido a que es una este ERP es una copia de otro sistema; Para los almecenes se maneja de la siguiente Forma
    '   | id | nombre de la columna en DB | nombre la columna en el ERP |
    '   | 1  |        monterrey           |        Jordán               |
    '   | 2  |        méxico              |        20 Noviembre         |
    '   | 3  |        guadalajara         |        Progreso
    '
#Region "Load Initial Values"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ''''''''''''''
        'Window Title'
        ''''''''''''''

        Me.Title = Resources.Resource.WindowsTitle

        If Not IsPostBack Then

            firstOpen = True

            '''''''''''''''''''
            'Fieldsets Legends'
            '''''''''''''''''''

            lblProductsListLegend.Text = Resources.Resource.lblProductsListLegend
            lblProductEditLegend.Text = Resources.Resource.lblProductEditLegend

            ''''''''''''''
            'Label Titles'
            ''''''''''''''

            lblCode.Text = Resources.Resource.lblCode
            lblUnit.Text = Resources.Resource.lblUnit
            lblUnitaryPrice.Text = "Precio Unit. 1:"
            lblUnitaryPrice2.Text = "Precio Unit. 2:"
            lblUnitaryPrice3.Text = "Precio Unit. 3:"
            lblUnitaryPrice4.Text = "Precio Unit. 4:"

            lblDescription.Text = Resources.Resource.lblDescription

            '''''''''''''''''''
            'Validators Titles'
            '''''''''''''''''''

            RequiredFieldValidator1.Text = Resources.Resource.validatorMessage
            RequiredFieldValidator2.Text = Resources.Resource.validatorMessage
            RequiredFieldValidator3.Text = Resources.Resource.validatorMessage

            ''''''''''''''''
            'Buttons Titles'
            ''''''''''''''''

            btnAddProduct.Text = Resources.Resource.btnAddProduct
            btnSaveProduct.Text = Resources.Resource.btnSave
            btnCancel.Text = Resources.Resource.btnCancel
            '
            Dim objCat As New DataControl
            objCat.Catalogo(tasaid, "select id, nombre from tblTasa order by id", 0)
            objCat.Catalogo(monedaid, "select id, nombre from tblMoneda order by id", 0)
            objCat.Catalogo(proveedorid, "select id, razonsocial from tblMisProveedores order by razonsocial", 0)
            objCat.Catalogo(coleccionid, "select id, isnull(codigo,'') + ' - ' + isnull(nombre,'') as nombre from tblColeccion where isnull(borradoBit,0)=0 order by nombre", 0)
            objCat.Catalogo(filtrocoleccionid, "select id, isnull(codigo,'') + ' - ' + isnull(nombre,'') as nombre from tblColeccion where isnull(borradoBit,0)=0 order by nombre", 0)
            objCat.Catalogo(filtromarcaid, "select id, nombre from tblProyecto order by nombre", 0)
            objCat.Catalogo(proyectoid, "select id, nombre from tblProyecto order by nombre", 0)
            objCat.Catalogo(cboclaveunidad, "select clave, clave + ' - ' + isnull(nombre,'') as nombre from tblUnidad order by nombre", 0)
            objCat.Catalogo(cboproductoserv, "select clave, clave + ' - ' + isnull(nombre,'') as nombre from tblClaveProducto order by nombre", 0)
            objCat.Catalogo(cbmObjetoImpuesto, "select id, descripcion from tblObjetoImp", 0)
            objCat = Nothing
            '
            chkInventariableBit.Checked = True
            chkPerecederoBit.Checked = True
            'LCNG: Validación de visibilidad de textos
            If Session("perfilid") = 3 Then

                If Session("userid") = 2022 Then
                    btnAddProduct.Visible = True
                    btnSaveProduct.Enabled = True
                    productslist.MasterTableView.CommandItemDisplay = True
                Else
                    btnAddProduct.Visible = False
                    btnSaveProduct.Enabled = False
                    productslist.MasterTableView.CommandItemDisplay = False
                End If
                productslist.MasterTableView.GetColumn("Delete").Visible = False
            End If

            'LCNG: validación de ver precio unitario 4 
            If Session("usrPropVerPrecioUnit4") = True Then
                lblUnitaryPrice4.Visible = True
                txtUnitaryPrice4.Visible = True
            End If

            '
        End If

    End Sub

#End Region

#Region "Load List Of Products"

    Function GetProducts() As DataSet
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim cmd As New SqlDataAdapter("EXEC pMisProductos @cmd=1, @clienteid='" & Session("clienteid") & "', @txtSearch='" & txtSearch.Text & "', @proyectoid='" & filtromarcaid.SelectedValue.ToString & "', @coleccionid='" & filtrocoleccionid.SelectedValue.ToString & "', @upcSearch='" & upcSearch.Text & "', @firstOpen='" & firstOpen & "'", conn)
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
        firstOpen = False
        Return ds
    End Function

#End Region

#Region "Telerik Grid Products Loading Events"

    Protected Sub productslist_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles productslist.NeedDataSource

        If Not e.IsFromDetailTable Then
            ds = GetProducts()
            productslist.MasterTableView.NoMasterRecordsText = Resources.Resource.ProductsEmptyGridMessage
            productslist.DataSource = ds

        End If

    End Sub

#End Region

#Region "Telerik Grid Language Modification(Spanish)"

    Protected Sub productslist_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles productslist.Init

        productslist.PagerStyle.NextPagesToolTip = "Ver mas"
        productslist.PagerStyle.NextPageToolTip = "Siguiente"
        productslist.PagerStyle.PrevPagesToolTip = "Ver más"
        productslist.PagerStyle.PrevPageToolTip = "Atrás"
        productslist.PagerStyle.LastPageToolTip = "Última Página"
        productslist.PagerStyle.FirstPageToolTip = "Primera Página"
        productslist.PagerStyle.PagerTextFormat = "{4}    Página {0} de {1}, Registros {2} al {3} de {5}"
        productslist.SortingSettings.SortToolTip = "Ordernar"
        productslist.SortingSettings.SortedAscToolTip = "Ordenar Asc"
        productslist.SortingSettings.SortedDescToolTip = "Ordenar Desc"


        Dim menu As Telerik.Web.UI.GridFilterMenu = productslist.FilterMenu
        Dim i As Integer = 0

        While i < menu.Items.Count

            If menu.Items(i).Text = "NoFilter" Or menu.Items(i).Text = "Contains" Then
                i = i + 1
            Else
                menu.Items.RemoveAt(i)
            End If

        End While

        Call ModificaIdiomaGrid()

    End Sub

    Private Sub ModificaIdiomaGrid()

        productslist.GroupingSettings.CaseSensitive = False

        Dim Menu As Telerik.Web.UI.GridFilterMenu = productslist.FilterMenu
        Dim item As Telerik.Web.UI.RadMenuItem

        For Each item In Menu.Items

            ''''''''''''''''''''''''''''''''''''''''''''''
            'Change The Text For The StartsWith Menu Item'
            ''''''''''''''''''''''''''''''''''''''''''''''

            If item.Text = "StartsWith" Then
                item.Text = "Empieza con"
            End If

            If item.Text = "NoFilter" Then
                item.Text = "Sin Filtro"
            End If

            If item.Text = "Contains" Then
                item.Text = "Contiene"
            End If

            If item.Text = "EndsWith" Then
                item.Text = "Termina con"
            End If

        Next

    End Sub

#End Region

#Region "Telerik Grid Products Editing & Deleting Events"

    Protected Sub productslist_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles productslist.ItemDataBound

        If TypeOf e.Item Is GridDataItem Then

            Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)

            If e.Item.OwnerTableView.Name = "Products" Then

                Dim lnkdel As ImageButton = CType(dataItem("Delete").FindControl("btnDelete"), ImageButton)
                lnkdel.Attributes.Add("onclick", "return confirm ('" & Resources.Resource.ProductsDeleteConfirmationMessage & "');")
                Dim lnkEdit As LinkButton = CType(dataItem("Codigo").FindControl("lnkEdit"), LinkButton)

                If Session("perfilid") = 3 Then

                    If Session("userid") = 2022 Then
                        lnkEdit.Enabled = True
                    Else
                        lnkEdit.Enabled = False
                    End If
                End If

            End If

        End If

        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Footer
                If ds.Tables(0).Rows.Count > 0 Then
                    'If Not IsDBNull(ds.Tables(0).Compute("sum(mexico)", "")) Then
                    '    e.Item.Cells(13).Text = FormatNumber(ds.Tables(0).Compute("sum(mexico)", ""), 2).ToString
                    '    e.Item.Cells(13).HorizontalAlign = HorizontalAlign.Right
                    '    e.Item.Cells(13).Font.Bold = True
                    'End If
                    'If Not IsDBNull(ds.Tables(0).Compute("sum(monterrey)", "")) Then
                    '    e.Item.Cells(10).Text = FormatNumber(ds.Tables(0).Compute("sum(monterrey)", ""), 2).ToString
                    '    e.Item.Cells(10).HorizontalAlign = HorizontalAlign.Right
                    '    e.Item.Cells(10).Font.Bold = True
                    'End If
                    'If Not IsDBNull(ds.Tables(0).Compute("sum(guadalajara)", "")) Then
                    '    e.Item.Cells(14).Text = FormatNumber(ds.Tables(0).Compute("sum(guadalajara)", ""), 2).ToString
                    '    e.Item.Cells(14).HorizontalAlign = HorizontalAlign.Right
                    '    e.Item.Cells(14).Font.Bold = True
                    'End If
                    'If Not IsDBNull(ds.Tables(0).Compute("sum(matriz)", "")) Then
                    '    e.Item.Cells(15).Text = FormatNumber(ds.Tables(0).Compute("sum(matriz)", ""), 2).ToString
                    '    e.Item.Cells(15).HorizontalAlign = HorizontalAlign.Right
                    '    e.Item.Cells(15).Font.Bold = True
                    'End If
                    'If Not IsDBNull(ds.Tables(0).Compute("sum(mermas)", "")) Then
                    '    e.Item.Cells(13).Text = FormatNumber(ds.Tables(0).Compute("sum(mermas)", ""), 2).ToString
                    '    e.Item.Cells(13).HorizontalAlign = HorizontalAlign.Right
                    '    e.Item.Cells(13).Font.Bold = True
                    'End If
                    If Not IsDBNull(ds.Tables(0).Compute("sum(proceso)", "")) Then
                        e.Item.Cells(13).Text = FormatNumber(ds.Tables(0).Compute("sum(proceso)", ""), 2).ToString
                        e.Item.Cells(13).HorizontalAlign = HorizontalAlign.Right
                        e.Item.Cells(13).Font.Bold = True
                    End If
                    'If Not IsDBNull(ds.Tables(0).Compute("sum(disponibles)", "")) Then
                    '    e.Item.Cells(13).Text = FormatNumber(ds.Tables(0).Compute("sum(consignacion)", ""), 2).ToString
                    '    e.Item.Cells(13).HorizontalAlign = HorizontalAlign.Right
                    '    e.Item.Cells(13).Font.Bold = True
                    'End If
                    If Not IsDBNull(ds.Tables(0).Compute("sum(disponibles)", "")) Then
                        e.Item.Cells(14).Text = FormatNumber(ds.Tables(0).Compute("sum(disponibles)", ""), 2).ToString
                        e.Item.Cells(14).HorizontalAlign = HorizontalAlign.Right
                        e.Item.Cells(14).Font.Bold = True
                    End If
                End If
        End Select

    End Sub

    Protected Sub productslist_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles productslist.ItemCommand

        Select Case e.CommandName

            Case "cmdEdit"
                Call EditProduct(e.CommandArgument)
                Call CargaClientes()
                Call MuestraCodigos()
            Case "cmdDelete"
                Call DeleteProduct(e.CommandArgument)

        End Select

    End Sub

    Private Sub DeleteProduct(ByVal id As Integer)

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)

        Try

            Dim cmd As New SqlCommand("EXEC pMisProductos  @cmd='2', @productoId ='" & id.ToString & "'", conn)

            conn.Open()

            Dim rs As SqlDataReader

            rs = cmd.ExecuteReader()
            rs.Close()

            conn.Close()

            panelProductList.Visible = True
            panelProductRegistration.Visible = False
            ds = GetProducts()
            productslist.DataSource = ds
            productslist.DataBind()

        Catch ex As Exception


        Finally

            conn.Close()
            conn.Dispose()

        End Try

    End Sub

    Private Sub EditProduct(ByVal id As Integer)

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)

        Try

            Dim cmd As New SqlCommand("EXEC pMisProductos @cmd=4, @productoid='" & id & "'", conn)

            conn.Open()

            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read Then

                txtCode.Text = rs("codigo")
                'txtSKU.Text = rs("sku")
                txtUPC.Text = rs("upc")
                txtUnitaryPrice.Text = rs("unitario")
                txtUnitaryPrice2.Text = rs("unitario2")
                txtUnitaryPrice3.Text = rs("unitario3")
                txtUnitaryPrice4.Text = rs("unitario4")
                txtUnitaryPrice5.Text = rs("unitario5")
                txtUnitaryPrice6.Text = rs("unitario6")
                txtDescription.Text = rs("descripcion")
                txtMinimo.Text = rs("minimo")
                txtMaximo.Text = rs("maximo")
                txtReorden.Text = rs("punto_reorden")
                txtCostoStd.Text = rs("costo_estandar")
                txtCostoProm.Text = rs("costo_promedio")
                txtCompraMinima.Text = rs("compra_min")
                txtTiempoEntrega.Text = rs("tiempo_entrega")
                txtPresentacion.Text = rs("presentacion")
                txtPesoUnitario.Text = rs("peso")

                If rs("foto").ToString.Length > 0 Then
                    imgFoto.Visible = True
                    imgFoto.ImageUrl = "~/portalcfd/images/productos/" & rs("foto")
                Else
                    imgFoto.Visible = False
                End If

                lblImgFoto.Text = rs("foto")

                If rs("inventariableBit") = "1" Then
                    chkInventariableBit.Checked = True
                Else
                    chkInventariableBit.Checked = False
                End If

                If rs("perecederoBit") = "1" Then
                    chkPerecederoBit.Checked = True
                Else
                    chkPerecederoBit.Checked = False
                End If

                panelCodigosAlternos.Visible = True
                panelProductList.Visible = False
                panelProductRegistration.Visible = True

                InsertOrUpdate.Value = 1
                ProductID.Value = id
                Dim objCat As New DataControl
                objCat.Catalogo(tasaid, "select id, nombre from tblTasa order by id", rs("tasaid"))
                objCat.Catalogo(monedaid, "select id, nombre from tblMoneda order by id", rs("monedaid"))
                objCat.Catalogo(proveedorid, "select id, razonsocial from tblMisProveedores order by razonsocial", rs("proveedorid"))
                objCat.Catalogo(coleccionid, "select id, isnull(codigo,'') + ' - ' + isnull(nombre,'') as nombre from tblColeccion where isnull(borradoBit,0)=0 order by nombre", rs("coleccionid"))
                objCat.Catalogo(proyectoid, "select id, nombre from tblProyecto order by id", rs("proyectoid"))
                objCat.Catalogo(cboclaveunidad, "select clave, clave + ' - ' + isnull(nombre,'') as nombre from tblUnidad order by nombre", rs("claveunidad"))
                objCat.Catalogo(cboproductoserv, "select clave, clave + ' - ' + isnull(nombre,'') as nombre from tblClaveProducto order by nombre", rs("claveprodserv"))
                cbmObjetoImpuesto.SelectedValue = rs("objeto_impuestoid")
                objCat = Nothing

            End If

        Catch ex As Exception
            Throw New Exception("Error: " & ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Private Sub CargaClientes()
        Dim ObjData As New DataControl
        ObjData.Catalogo(clienteid, "select id, razonsocial from tblMisClientes order by razonsocial", 0)
        ObjData = Nothing
    End Sub

    Private Sub MuestraCodigos()
        Dim ObjData As New DataControl
        ClientCodesList.DataSource = ObjData.FillDataSet("exec pMisProductos @cmd=7, @productoid='" & ProductID.Value.ToString & "'")
        ClientCodesList.DataBind()
        ObjData = Nothing
    End Sub

    Private Sub ClientCodesList_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles ClientCodesList.ItemCommand
        Select Case e.CommandName
            Case "cmdDelete"
                Call BorraCodigo(e.CommandArgument)
                Call MuestraCodigos()
        End Select
    End Sub

    Private Sub ClientCodesList_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles ClientCodesList.ItemDataBound
        Select Case e.Item.ItemType
            Case GridItemType.Item, GridItemType.AlternatingItem
                Dim btnDelete As ImageButton = CType(e.Item.FindControl("btnDelete"), ImageButton)
                btnDelete.Attributes.Add("onclick", "javascript:return confirm('Va a eliminar un código de cliente. ¿Desea contiuar?');")
        End Select
    End Sub

    Private Sub ClientCodesList_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles ClientCodesList.NeedDataSource
        Dim ObjData As New DataControl
        ClientCodesList.DataSource = ObjData.FillDataSet("exec pMisProductos @cmd=7")
        ObjData = Nothing
    End Sub

#End Region

#Region "Telerik Grid Products Column Names (From Resource File)"

    Protected Sub productslist_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles productslist.ItemCreated

        If TypeOf e.Item Is GridHeaderItem Then

            Dim header As GridHeaderItem = CType(e.Item, GridHeaderItem)

            If e.Item.OwnerTableView.Name = "Products" Then

                header("codigo").Text = Resources.Resource.gridColumnNameCode
                header("unidad").Text = Resources.Resource.gridColumnNameMeasureUnit
                'header("descripcion").Text = Resources.Resource.gridColumnNameDescription
                header("unitario").Text = Resources.Resource.gridColumnNameUnitaryPrice
                'header("unitario2").Text = Resources.Resource.gridColumnNameUnitaryPrice2
                'header("unitario3").Text = Resources.Resource.gridColumnNameUnitaryPrice3
                'header("unitario4").Text = Resources.Resource.gridColumnNameUnitaryPrice4
            End If

        End If

    End Sub

#End Region

#Region "Display Product Data Panel"

    Protected Sub btnAddProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddProduct.Click

        InsertOrUpdate.Value = 0

        txtCode.Text = ""
        'txtUnit.Text = ""
        'txtUnitaryPrice.Text = ""
        'txtUnitaryPrice2.Text = ""
        'txtUnitaryPrice3.Text = ""
        'txtDescription.Text = ""
        cbmObjetoImpuesto.SelectedValue = 0
        panelProductList.Visible = False
        panelProductRegistration.Visible = True

    End Sub

#End Region

#Region "Save Product"

    Protected Sub btnSaveClient_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveProduct.Click

        Dim inventariableBit As Integer = 0
        Dim perecederoBit As Integer = 0

        If chkInventariableBit.Checked = True Then
            inventariableBit = 1
        Else
            inventariableBit = 0
        End If

        If chkPerecederoBit.Checked = True Then
            perecederoBit = 1
        Else
            perecederoBit = 0
        End If
        '
        '   Guarda imagen
        '
        Dim thumbnailName As String
        If foto.PostedFile.ContentLength > 0 Then
            thumbnailName = foto.PostedFile.FileName.Substring(foto.PostedFile.FileName.LastIndexOf("\") + 1)
            foto.SaveAs(Server.MapPath("..\images\productos\" + thumbnailName.ToString))
        Else
            thumbnailName = lblImgFoto.Text
        End If

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)

        Try

            If InsertOrUpdate.Value = 0 Then

                Dim DataControl As New DataControl
                lblMensaje.Text = DataControl.RunSQLScalarQueryString("EXEC pMisProductos @cmd=3, @clienteid='" & Session("clienteid").ToString &
                                                                                              "', @codigo='" & txtCode.Text &
                                                                                              "', @claveprodserv='" & cboproductoserv.SelectedValue.ToString &
                                                                                              "', @claveunidad='" & cboclaveunidad.SelectedValue.ToString &
                                                                                              "', @unitario='" & txtUnitaryPrice.Text &
                                                                                              "', @unitario2='" & txtUnitaryPrice2.Text &
                                                                                              "', @unitario3='" & txtUnitaryPrice3.Text &
                                                                                              "', @unitario4='" & txtUnitaryPrice4.Text &
                                                                                              "', @unitario5='" & txtUnitaryPrice5.Text &
                                                                                              "', @unitario6='" & txtUnitaryPrice6.Text &
                                                                                              "', @descripcion='" & txtDescription.Text &
                                                                                              "', @tasaid='" & tasaid.SelectedValue.ToString &
                                                                                              "', @maximo='" & txtMaximo.Text &
                                                                                              "', @minimo='" & txtMinimo.Text &
                                                                                              "', @punto_reorden='" & txtReorden.Text &
                                                                                              "', @costo_estandar='" & txtCostoStd.Text &
                                                                                              "', @costo_promedio='" & txtCostoProm.Text &
                                                                                              "', @compra_min='" & txtCompraMinima.Text &
                                                                                              "', @tiempo_entrega='" & txtTiempoEntrega.Text &
                                                                                              "', @presentacion='" & txtPresentacion.Text &
                                                                                              "', @monedaid='" & monedaid.SelectedValue.ToString &
                                                                                              "', @peso='" & txtPesoUnitario.Text &
                                                                                              "', @proveedorId='" & proveedorid.SelectedValue.ToString &
                                                                                              "', @inventariableBit='" & inventariableBit.ToString &
                                                                                              "', @foto='" & thumbnailName.ToString &
                                                                                              "', @perecederoBit='" & perecederoBit.ToString &
                                                                                              "', @coleccionid='" & coleccionid.SelectedValue.ToString &
                                                                                              "', @proyectoid='" & proyectoid.SelectedValue.ToString &
                                                                                              "', @upc='" & txtUPC.Text.ToString &
                                                                                              "', @objeto_impuestoid = '" & cbmObjetoImpuesto.SelectedValue & "'")
                DataControl = Nothing

                If lblMensaje.Text = "" Then
                    panelProductList.Visible = True
                    panelProductRegistration.Visible = False
                    ds = GetProducts()
                    productslist.MasterTableView.NoMasterRecordsText = Resources.Resource.ClientsEmptyGridMessage
                    productslist.DataSource = ds
                    productslist.DataBind()
                End If

            Else

                Dim cmd As New SqlCommand("EXEC pMisProductos @cmd=5, @productoid='" & ProductID.Value &
                                                                  "', @codigo='" & txtCode.Text &
                                                                  "', @claveprodserv='" & cboproductoserv.SelectedValue.ToString &
                                                                  "', @claveunidad='" & cboclaveunidad.SelectedValue.ToString &
                                                                  "', @unitario='" & txtUnitaryPrice.Text &
                                                                  "', @unitario2='" & txtUnitaryPrice2.Text &
                                                                  "', @unitario3='" & txtUnitaryPrice3.Text &
                                                                  "', @unitario4='" & txtUnitaryPrice4.Text &
                                                                  "', @unitario5='" & txtUnitaryPrice5.Text &
                                                                  "', @unitario6='" & txtUnitaryPrice6.Text &
                                                                  "', @descripcion='" & txtDescription.Text &
                                                                  "', @tasaid='" & tasaid.SelectedValue.ToString &
                                                                  "', @maximo='" & txtMaximo.Text &
                                                                  "', @minimo='" & txtMinimo.Text &
                                                                  "', @punto_reorden='" & txtReorden.Text &
                                                                  "', @costo_estandar='" & txtCostoStd.Text &
                                                                  "', @costo_promedio='" & txtCostoProm.Text &
                                                                  "', @compra_min='" & txtCompraMinima.Text &
                                                                  "', @tiempo_entrega='" & txtTiempoEntrega.Text &
                                                                  "', @presentacion='" & txtPresentacion.Text &
                                                                  "', @monedaid='" & monedaid.SelectedValue.ToString &
                                                                  "', @peso='" & txtPesoUnitario.Text &
                                                                  "', @proveedorId='" & proveedorid.SelectedValue.ToString &
                                                                  "', @inventariableBit='" & inventariableBit.ToString &
                                                                  "',  @foto='" & thumbnailName.ToString &
                                                                  "', @perecederoBit='" & perecederoBit.ToString &
                                                                  "', @coleccionid='" & coleccionid.SelectedValue.ToString &
                                                                  "', @proyectoid='" & proyectoid.SelectedValue.ToString &
                                                                  "', @upc='" & txtUPC.Text.ToString &
                                                                  "', @objeto_impuestoid = '" & cbmObjetoImpuesto.SelectedValue & "'", conn)

                conn.Open()

                cmd.ExecuteReader()

                panelProductList.Visible = True
                panelProductRegistration.Visible = False
                ds = GetProducts()
                productslist.MasterTableView.NoMasterRecordsText = Resources.Resource.ClientsEmptyGridMessage
                productslist.DataSource = ds
                productslist.DataBind()

                conn.Close()
                conn.Dispose()

            End If

        Catch ex As Exception
            Throw New Exception("Error: " & ex.Message)
        Finally

            conn.Close()
            conn.Dispose()
            conn = Nothing

        End Try

    End Sub

#End Region

#Region "Cancel Product (Save/Edit)"

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Response.Redirect("~/portalcfd/almacen/Productos.aspx")

    End Sub

#End Region

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        productslist.MasterTableView.NoMasterRecordsText = Resources.Resource.ProductsEmptyGridMessage
        ds = GetProducts()
        productslist.DataSource = ds
        productslist.DataBind()
    End Sub

    Protected Sub btnAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAll.Click
        txtSearch.Text = ""
        filtrocoleccionid.SelectedValue = 0
        filtromarcaid.SelectedValue = 0
        productslist.MasterTableView.NoMasterRecordsText = Resources.Resource.ProductsEmptyGridMessage
        ds = GetProducts()
        productslist.DataSource = ds
        productslist.DataBind()
    End Sub

    Private Sub btnAddCode_Click(sender As Object, e As System.EventArgs) Handles btnAddCode.Click
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pMisProductos @cmd=6, @clienteid='" & clienteid.SelectedValue.ToString &
                                                    "', @productoid='" & ProductID.Value.ToString &
                                                    "', @codigo='" & txtClientCode.Text & "'")
        ObjData = Nothing
        clienteid.SelectedIndex = 0
        txtClientCode.Text = ""
        Call MuestraCodigos()
    End Sub

    Private Sub BorraCodigo(ByVal codigoid As Long)
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pMisProductos @cmd=8, @codigoclienteid='" & codigoid.ToString & "'")
        ObjData = Nothing
    End Sub

End Class
