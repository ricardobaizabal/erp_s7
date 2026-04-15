<%@ Page Language="vb" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" EnableEventValidation="false" AutoEventWireup="false" CodeBehind="Cotizaciones.aspx.vb" Inherits="erp_s7.Cotizaciones" %>


<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style4 {
            height: 17px;
        }

        .style5 {
            height: 14px;
        }

        .style6 {
            height: 21px;
        }

        .mg-8 {
            margin-top: 8px;
        }

        .mg-10 {
            margin-top: 10px;
        }

        .lbl-errors-wrapper {
            text-align: center;
        }

        .box {
        }
    </style>
    <script type="text/javascript">
        function confirmCallbackFn(arg) {
            if (arg) //the user clicked OK
            {
                __doPostBack("<%=HiddenButtonOk.UniqueID %>", "");
            }
            else {
                __doPostBack("<%=HiddenButtonCancel.UniqueID %>", "");
            }
        }

        function OnRequestStart(target, arguments) {
            if ((arguments.get_eventTarget().indexOf("clientslist") > -1) || (arguments.get_eventTarget().indexOf("cotizacionesList") > -1) || (arguments.get_eventTarget().indexOf("Button2") > -1)) {
                arguments.set_enableAjax(false);
            }
        }
        function myFunction() {
            console.log("123")
            document.getElementById("ContentPlaceHolder1_Button1").click(); // Click on the checkbox
        }

    </script>
    <script type="text/javascript" language="javascript">
        function changePrice(sender, args) {
            var item = args.get_item();
            var price = item.get_value();
            console.log(sender)
            console.log(sender.get_element())
            console.log(sender.get_element().parentNode)
            console.log(item)
            console.log(item.get_value())
            console.log(item.get_text())
            var parent = sender.get_element().parentNode; //table cell (a parent element for your button)
            var textBox1 = $telerik.findControl(parent, "lblPrecioUnitario");
            console.log('value is' + price);
            textBox1.set_value(price);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <telerik:RadWindowManager ID="RadWindowManager1" Localization-OK="Aceptar" Localization-Cancel="Cancelar" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="OnRequestStart">
        <asp:Panel ID="panelAddCotizacion" runat="server" Visible="false">
            <fieldset>
                <legend style="padding-right: 6px; color: Black">
                    <asp:Label ID="Label1" runat="server" Font-Bold="true" CssClass="item" Text="Agregar nueva cotizacion"></asp:Label>
                </legend>
                <table style="width: 100%" border="0">
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblCotizacion" runat="server" Font-Bold="true" Font-Size="Small" class="item" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <label class="item"><strong>Cliente:</strong></label></td>
                        <td width="20%">
                            <label class="item"><strong>Tipo de precio:</strong></label></td>
                        <td width="20%">
                            <label class="item"><strong>Nombre del proyecto:</strong></label></td>
                        <td width="20%">
                            <label class="item"><strong>Orden de compra:</strong></label></td>
                        <td width="20%">
                            <label class="item"><strong>Importe Total:</strong></label></td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:DropDownList ID="clienteid" Width="100%" runat="server" AutoPostBack="true" ValidationGroup="addp" CssClass="box mg-8"  OnSelectedIndexChanged="clienteid_SelectedIndexChanged" /></td>
                        <td width="20%">
                            <asp:DropDownList ID="cmbTipoPrecio" runat="server" Width="58%" AutoPostBack="true" ValidationGroup="ValSearch" CssClass="box mg-8" /></td>
                        <td width="20%">
                            <telerik:RadTextBox ID="txtProyecto" runat="server" MaxLength="1000" Style="margin-top: 11px;" ValidationGroup="addp" /></td>
                        <td width="20%">
                            <telerik:RadTextBox ID="txtOrden" runat="server" MaxLength="1000" Style="margin-top: 11px;" /></td>
                        <td width="20%">
                            <telerik:RadNumericTextBox ID="txtImporteTotal" runat="server" MaxLength="1000" Style="margin-top: 11px;" /></td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:RequiredFieldValidator ID="valclienteid" runat="server" InitialValue="0" ErrorMessage="Requerido." ControlToValidate="clienteid" SetFocusOnError="true" class="item" ForeColor="Red" ValidationGroup="addp" /><br />
                        </td>
                        <td width="20%">
                            <asp:RequiredFieldValidator ID="valTipoPrecio" runat="server" InitialValue="0" ErrorMessage="Requerido." ControlToValidate="cmbTipoPrecio" SetFocusOnError="true" class="item" ForeColor="Red" ValidationGroup="ValSearch" /><br />
                        </td>
                        <td width="20%">
                            <asp:RequiredFieldValidator ID="valNombreProyecto" runat="server" ErrorMessage="Requerido." ControlToValidate="txtProyecto" SetFocusOnError="true" class="item" ForeColor="Red" ValidationGroup="addp" /><br />
                        </td>
                        <td width="20%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:Panel runat="server" ID="panelFlete" Style="width: 100%; display: block">
                                <label class="item">
                                    <asp:CheckBox runat="server" ID="bFlete" AutoPostBack="true" Checked="true" />&nbsp;<strong>Costo de flete:</strong></label><br />
                            </asp:Panel>
                        </td>
                        <td width="20%">
                            <asp:Panel runat="server" ID="panelTax" Visible="false">
                                <label class="item"><strong>Tax:</strong></label>
                            </asp:Panel>
                        </td>
                        <td width="20%">
                            <label class="item"><strong>Condiciones:</strong></label><br />
                        </td>
                        <td width="20%">
                            <asp:Label runat="server" class="item"><strong>Observacion:</strong></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:Panel runat="server" ID="panelFlete2" Style="width: 100%; display: block">
                                <telerik:RadNumericTextBox ID="txtFlete" runat="server" Type="Number" MaxLength="1000" Style="margin-top: 4px;" NumberFormat-DecimalDigits="2" Width="90%" Visible="true" Value="0" />
                                <telerik:RadTextBox Text="Por definir" ID="lblpd" runat="server" Style="margin-top: 4px;" Width="90%" Visible="false" Enabled="false" />
                            </asp:Panel>
                        </td>
                        <td width="20%">
                            <asp:Panel runat="server" ID="panelTax2" Visible="false">
                                <telerik:RadNumericTextBox ID="txtTax" runat="server" Type="Percent" MaxLength="1000" Style="margin-top: 11px;" NumberFormat-DecimalDigits="2" Width="80%" AutoPostBack="true" />
                            </asp:Panel>
                        </td>
                        <td width="20%">
                            <asp:DropDownList ID="cmbCondiciones" runat="server" Width="78%" AutoPostBack="true" CssClass="box mg-8" ValidationGroup="addp" />
                        </td>
                        <td width="20%">
                            <telerik:RadTextBox ID="txtObservaciones" runat="server" Width="95%" MaxLength="1000" Style="margin-top: 8px;" TextMode="MultiLine" />
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">&nbsp;</td>
                        <td width="20%">&nbsp;</td>
                        <td>
                            <asp:RequiredFieldValidator ID="valCondicionesId" runat="server" InitialValue="0" ErrorMessage="Requerido." ControlToValidate="cmbCondiciones" SetFocusOnError="true" class="item" ForeColor="Red" ValidationGroup="addp" /></td>
                        <td width="20%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <label class="item"><strong>Nombre Contacto:</strong></label><br />
                        </td>
                        <td width="20%">
                            <label class="item"><strong>Teléfono Contacto:</strong></label></td>
                        <td width="20%">
                            <%--<label class="item"><strong Visible="false">Enviar a:</strong></label><br />--%>
                        </td>
                        <td width="20%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <telerik:RadTextBox ID="txtContacto" runat="server" ValidationGroup="dcotizacion" Width="70%" MaxLength="200" Style="margin-top: 11px;" /></td>
                        <td width="20%">
                            <telerik:RadTextBox ID="txtTelContacto" runat="server" Width="70%" MaxLength="30" Style="margin-top: 11px;" /></td>
                        <td width="20%">
                            <telerik:RadTextBox ID="txtEnviarA" runat="server" Width="90%" MaxLength="510" Style="margin-top: 8px;" TextMode="MultiLine" Visible="false" />
                        </td>
                        <td width="20%">&nbsp;</td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:RequiredFieldValidator ID="valNombreContacto" runat="server" ErrorMessage="Requerido." ControlToValidate="txtContacto" SetFocusOnError="true" class="item" ForeColor="Red" ValidationGroup="addp" /></td>
                        <td width="20%">&nbsp;</td>
                        <td width="20%"></td>
                        <td width="20%"></td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td align="left" class="item" colspan="4">
                            <asp:Panel ID="panelBusqueda" DefaultButton="btnSearch" runat="server">
                                <asp:Label ID="lblBuscar" runat="server" class="item" Text="Buscar productos:" Font-Bold="true"></asp:Label><br />
                                <br />
                                <div style="display: inline-flex; margin-top: 10px;">
                                    <div>
                                        <asp:Label ID="Label3" runat="server" class="item" Text="Criterio de búsqueda:"></asp:Label><br />
                                        <telerik:RadTextBox ID="txtSearch" runat="server" Width="200px" CssClass="mg-8" Style="margin-top: 8px"></telerik:RadTextBox>&nbsp;&nbsp;&nbsp;                                                   
                                    </div>
                                    <div>
                                        <br />
                                        <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="botones mg-8" ValidationGroup="ValSearch" />
                                        <asp:Button ID="btnCancelarBusqueda" runat="server" Text="Cancelar Búsqueda" CssClass="botones mg-8" CausesValidation="false" />
                                    </div>
                                </div>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSearch" ErrorMessage="Debe ingresar un texto." ValidationGroup="ValSearch" class="item" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" class="item">
                            <asp:Label ID="lblMensaje" runat="server" class="item" ForeColor="Red"></asp:Label>
                            <asp:HiddenField runat="server" ID="HiddenField1" Value="0" />
                            <asp:HiddenField runat="server" ID="estatusId" Value="0" />
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <asp:Panel ID="panel1" Visible="false" runat="server">
                                <asp:Label ID="lblProdsTitulo" runat="server" Font-Bold="true" Font-Size="Small" class="item" Text="Lista de Productos"></asp:Label><br />
                                <br />
                                <telerik:RadGrid Width="100%" ID="productosList" CssClass="grids" runat="server" AllowPaging="True"
                                    PageSize="50" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0"
                                    GridLines="None" Skin="Simple" HeaderStyle-Font-Size="Small" ShowHeader="true">
                                    <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True"></ClientSettings>
                                    <MasterTableView DataKeyNames="productoid,codigo,descripcion,unidad,unitario,existencia,disponibles" ShowHeadersWhenNoRecords="true" NoMasterRecordsText="No hay productos para mostrar.">
                                        <Columns>
                                            <telerik:GridBoundColumn DataField="productoid" ItemStyle-Width="10%" FilterControlAltText="Filter column column" HeaderText="productoid" UniqueName="productoid" HeaderStyle-Font-Size="Small" Display="false">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="codigo" ItemStyle-Width="10%" FilterControlAltText="Filter column column" HeaderText="Código" UniqueName="codigo" HeaderStyle-Font-Size="Small">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn>
                                                <ItemStyle Width="10%" />
                                                <HeaderTemplate>Precio unitario</HeaderTemplate>
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="lblPrecioUnitario" ReadOnly="true" runat="server" Text='<%#Eval("unitario") %>' MinValue="0" Value="0"
                                                        Skin="Default" Width="80px" Style="margin-top: 2em; margin-bottom: .6em;">
                                                        <NumberFormat DecimalDigits="2" GroupSeparator="," />
                                                    </telerik:RadNumericTextBox>
                                                    <telerik:RadDropDownList ID="cmbPrecioUnitario" runat="server" OnClientItemSelected="changePrice"></telerik:RadDropDownList>
                                                    <telerik:RadNumericTextBox ID="txtUnitaryPrice" runat="server" MinValue="0" Text='<%#Eval("unitario") %>'
                                                        Skin="Default" Width="80px" NumberFormat-DecimalDigits="2" Visible="false">
                                                    </telerik:RadNumericTextBox>
                                                    <%--<asp:Label ID="lblPrecioUnitario"  runat="server" Visible="false" Text='<%# eval("unitario") %>'></asp:Label>--%>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>

                                            <telerik:GridTemplateColumn HeaderText="Cantidad" UniqueName="ColCantidad" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="txtCantidad" Width="98%" Type="Number" NumberFormat-DecimalDigits="2" runat="server"></telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Tiempo de entrega estimado" UniqueName="colEstimado" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <telerik:RadNumericTextBox ID="txtTiempoEntrega" Width="98%" NumberFormat-DecimalDigits="0" runat="server" MaxLength="50"></telerik:RadNumericTextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn>
                                                <HeaderTemplate>Descripción</HeaderTemplate>
                                                <ItemTemplate>
                                                    <telerik:RadTextBox runat="server" ID="descripcion"
                                                        Text='<%#Eval("descripcion") %>'
                                                        Width="200px" Height="5.5em" CssClass="item"
                                                        UniqueName="descripcion"
                                                        ReadOnly="False" TextMode="MultiLine"
                                                        Skin="Default">
                                                    </telerik:RadTextBox>
                                                    <telerik:RadTextBox ID="txtDescripcion"
                                                        runat="server" Text='<%#Eval("descripcion") %>'
                                                        Width="250px" CssClass="item"
                                                        TextMode="MultiLine" Height="5.5em" Visible="false"
                                                        Skin="Default">
                                                    </telerik:RadTextBox>
                                                </ItemTemplate>
                                                <ItemStyle VerticalAlign="Middle" />
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table border="0" style="width: 100%">
                    <tr>
                        <td colspan="4">
                            <br />
                            <div align="right">
                                <asp:Button ID="btnAgregaConceptos" runat="server" CssClass="item" Visible="False" Text="Agregar Conceptos" CausesValidation="false" />&nbsp;&nbsp;
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="vertical-align: top;" colspan="4">
                            <br />
                            <asp:Label ID="lblPedidotitulo" runat="server" Font-Bold="true" Font-Size="Small" class="item" Text="Detalle de la cotización"></asp:Label>
                            <br />
                            <br />
                            <telerik:RadGrid Width="99.8%" ID="cotizaciondetallelist" runat="server" AllowPaging="True"
                                PageSize="50" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0"
                                Skin="Simple" HeaderStyle-Font-Size="Small" ShowHeader="true" ShowFooter="true" MasterTableView-ShowHeadersWhenNoRecords="true">
                                <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                                </ClientSettings>
                                <MasterTableView DataKeyNames="id,cotizacionid,productoid,codigo,descripcion,unidad,cantidad,precio,importe,iva" ShowHeadersWhenNoRecords="true" NoMasterRecordsText="No se han agregado productos a esta cotización.">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="codigo" FilterControlAltText="Filter column column" HeaderText="Código" UniqueName="codigo" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridTemplateColumn DataField="descripcion" FilterControlAltText="Filter column2 column" HeaderText="Descripción" UniqueName="descripcion">
                                            <ItemTemplate>
                                                <telerik:RadTextBox ID="txtDescripcionDetalle" runat="server" Text='<%# Eval("descripcion") %>' Width="100%" AutoPostBack="true" OnTextChanged="txtDescripcionDetalle_TextChanged" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridBoundColumn DataField="unidad" ItemStyle-HorizontalAlign="Right" FilterControlAltText="Filter column2 column" HeaderText="Unidad" UniqueName="unidad">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridBoundColumn DataField="pedido" ItemStyle-HorizontalAlign="Right" FilterControlAltText="Filter column2 column" HeaderText="Pedido" UniqueName="pedido">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridTemplateColumn DataField="precio" ItemStyle-HorizontalAlign="Right" FilterControlAltText="Filter column column" HeaderText="Precio" UniqueName="precio">
                                            <ItemTemplate>
                                                <telerik:RadNumericTextBox ID="txtPrecioDetalle" runat="server" DbValue='<%# Eval("precio") %>' Width="100px" Type="Currency" NumberFormat-DecimalDigits="2" AutoPostBack="true" OnTextChanged="txtPrecioDetalle_TextChanged">
                                                    <NumberFormat DecimalDigits="2" GroupSeparator="," DecimalSeparator="." />
                                                </telerik:RadNumericTextBox>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="cantidad" HeaderText="Cantidad" UniqueName="cantidad">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridNumericColumn DataField="importe" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" FilterControlAltText="Filter column column" HeaderText="Importe" UniqueName="importe" DataType="System.Decimal" DataFormatString="{0:$###,##0.00}" NumericType="Currency">
                                        </telerik:GridNumericColumn>
                                        <telerik:GridNumericColumn DataField="iva" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" FilterControlAltText="Filter column column" HeaderText="Iva" UniqueName="iva" DataType="System.Decimal" DataFormatString="{0:$###,##0.00}" NumericType="Currency">
                                        </telerik:GridNumericColumn>
                                        <telerik:GridNumericColumn DataField="tiempoEstimadoD" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" FilterControlAltText="Filter column column" HeaderText="Tiempo de entrega estimado" UniqueName="importe" HeaderStyle-Width="12%">
                                        </telerik:GridNumericColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" UniqueName="ColEliminarProducto" HeaderText="Remover">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdEliminar" ImageUrl="~/images/action_delete.gif" CausesValidation="false" PostBackUrl="~/portalcfd/administracion/Cotizaciones.aspx" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div style="width: 100%; text-align: right;">
                                <asp:Button ID="btnCrearPedido" runat="server" Text="Crear Pedido" CssClass="botones" OnClientClick="myFunction()" />&nbsp;&nbsp;
                                <asp:Button ID="btnSaveCotizacion" runat="server" Text="Guardar Cotización" CssClass="botones" ValidationGroup="addp" CausesValidation="true" />&nbsp;&nbsp;
                                <asp:Button ID="btnCancelCotizacion" runat="server" Text="Cancelar" CssClass="botones" CausesValidation="false" />
                                <br />
                                <br />
                            </div>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <asp:Panel ID="panelCotizacion" runat="server">
            <fieldset>
                <legend style="padding-right: 6px; color: Black">
                    <asp:Label ID="lblcotizacionesList" runat="server" Font-Bold="true" CssClass="item" Text="Lista de cotizaciones"></asp:Label>
                </legend>
                <table width="100%">
                    <tr>
                        <td style="height: 5px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true" CssClass="item"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">

                            <fieldset style="padding: 10px; border: 0px">
                                <legend style="padding-right: 6px; color: Black">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="true" CssClass="item" Text="Filtros"></asp:Label>
                                </legend>
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="display: flex;">
                                            <div>
                                                <span class="item">Desde:</span>
                                                <br />
                                                <telerik:RadDatePicker ID="fha_ini" runat="server" Style="margin-top: 5px;" />
                                            </div>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <div>
                                            <span class="item">Hasta:</span>
                                            <br />
                                            <telerik:RadDatePicker ID="fha_fin" runat="server" Style="margin-top: 5px;" />
                                        </div>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <div>
                                            <br />
                                            <asp:Button ID="btnFitroOn" runat="server" CssClass="boton" Text="Buscar por Fechas" />&nbsp;
                                        </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="display: flex; margin-top: 15px;">
                                            <div>
                                                <span class="item">Cliente:</span>
                                                <br />
                                                <asp:DropDownList ID="cmbfiltrocliente" runat="server" CssClass="box" Style="width: 330px; margin-top: 5px;" />&nbsp;
                                            </div>
                                            &nbsp;&nbsp;
                                            <div>
                                                <span class="item">Proyecto:</span>
                                                <br />
                                                <asp:TextBox runat="server" ID="txtProyectoFiltro" CssClass="box" Style="width: 130px; margin-top: 5px;"></asp:TextBox>
                                                &nbsp;
                                            </div>
                                            <div>
                                                <span class="item">Contacto:</span>
                                                <br />
                                                <asp:TextBox runat="server" ID="txtContactoFiltro" CssClass="box" Style="width: 130px; margin-top: 5px;"></asp:TextBox>
                                                &nbsp;
                                            </div>
                                            <%--  --%>
                                            <div>
                                                <span class="item">Monto Total:</span>
                                                <br />
                                                <telerik:RadNumericTextBox runat="server" ID="txtMontoTotal" CssClass="box" Style="width: 130px; margin-top: 5px;"></telerik:RadNumericTextBox>
                                                &nbsp;
                                            </div>
                                            <div style="margin-top: 16px">
                                                <asp:Button ID="btnCLiente3" runat="server" CssClass="boton" Text="Buscar" />&nbsp;
                                                <asp:Button ID="btnFiltroOff" runat="server" CssClass="boton" Text="Ver todo" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="display: flex; margin-top: 15px;">
                                            <div>
                                                <span class="item">Folio:</span>
                                                <br />
                                                <asp:TextBox runat="server" ID="txtfolio" CssClass="box" Style="width: 130px; margin-top: 5px;"></asp:TextBox>
                                                &nbsp;
                                            </div>
                                            <div style="margin-top: 16px">
                                                <asp:Button ID="btnFolio" runat="server" CssClass="boton" Text="Buscar Folio" />
                                                <%--<asp:Button ID="Button3" runat="server" CssClass="boton" Text="Ver todo" />--%>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                            <div style="width: 100%; text-align: right;">
                                <asp:Button ID="btnAddCotizacion" runat="server" Text="Agregar nueva cotización" CssClass="botones" />&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="Exportar a Excel" OnClick="Button2_Click" CssClass="botones" />
                                <br />
                                <br />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="cotizacionesList" runat="server" Width="100%" ShowStatusBar="True"
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="15" GridLines="None"
                                Skin="Simple" ExportSettings-ExportOnlyData="False" AllowMultiRowSelection="true"
                                OnNeedDataSource="CotizacionesList_NeedDataSource" AllowFilteringByColumn="false">
                                <ExportSettings IgnorePaging="True" FileName="Listado Cotizaciones">
                                    <Excel Format="Biff" />
                                </ExportSettings>
                                <PagerStyle Mode="NumericPages"></PagerStyle>
                                <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                                </ClientSettings>
                                <MasterTableView Width="100%" DataKeyNames="id" ShowHeadersWhenNoRecords="true" NoMasterRecordsText="No se encontraron registros para mostrar." Name="Clients" AllowMultiColumnSorting="False" CommandItemDisplay="none">
                                    <CommandItemSettings ShowRefreshButton="false" ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowExportToPdfButton="false" ExportToPdfText="Exportar a pdf" ExportToExcelText="Exportar a excel"></CommandItemSettings>
                                    <%--<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>--%>
                                    <Columns>
                                        <%--<telerik:GridClientSelectColumn UniqueName="ClientSelectColumn1" Exportable="false"></telerik:GridClientSelectColumn>--%>
                                        <telerik:GridBoundColumn DataField="folio" HeaderText="Folio" UniqueName="armfolio" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="fechaCotizacion" HeaderText="Fecha" UniqueName="fecha" DataFormatString="{0:d}" AllowFiltering="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="cliente" HeaderText="Cliente" UniqueName="cliente" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="pedido" HeaderText="Pedido" UniqueName="pedido" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="contacto" HeaderText="Contacto" UniqueName="contacto" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ordenCompra" HeaderText="Orden de compra" UniqueName="cliente" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="proyecto" ItemStyle-Width="100" HeaderText="Proyecto" UniqueName="proyecto" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="vendedor" HeaderText="Representante de Ventas" UniqueName="vendedor" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TipoPrecio" HeaderText="Tipo" UniqueName="cliente" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="monto_total" HeaderText="Monto Total" UniqueName="monto_total" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" DataFormatString="{0:C2}">
                                        </telerik:GridBoundColumn>
                                        <%--<telerik:GridBoundColumn DataField="total" AllowSorting="false" HeaderText="Total" UniqueName="total" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>--%>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="" UniqueName="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPDF" runat="server" Text="pdf" CommandArgument='<%# Eval("id") %>' CommandName="cmdPDF" PostBackUrl="~/portalcfd/administracion/Cotizaciones.aspx"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                        <%--<telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Enviar" UniqueName="" HeaderStyle-HorizontalAlign="Center" >
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgSend" runat="server" ImageUrl="~/portalcfd/images/envelope.jpg" CommandArgument='<%# Eval("id") %>' CommandName="cmdSend" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>   --%>
                                        <telerik:GridTemplateColumn UniqueName="ColEditar" AllowFiltering="true" HeaderText="Ver/Editar" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdEditar" ImageUrl="~/images/action_edit.png" CausesValidation="false" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" UniqueName="Borrar">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBorrar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("id") %>' CommandName="cmdEliminar" CausesValidation="false"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <%--<ClientSettings>
                                    <Selecting AllowRowSelect="true"></Selecting>
                                </ClientSettings>--%>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="display: none">
                                <telerik:RadGrid ID="ExcelGrid" runat="server" AllowPaging="True" PageSize="50"
                                    AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Skin="Simple" Width="100%" AllowMultiRowSelection="true"
                                    ExportSettings-ExportOnlyData="false" ExportSettings-IgnorePaging="false" OnItemDataBound="RadGrid1_ItemDataBound">

                                    <ExportSettings IgnorePaging="True" FileName="Cotizaciones">
                                        <Excel Format="Biff" />
                                    </ExportSettings>

                                    <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                                    </ClientSettings>

                                    <MasterTableView ShowHeadersWhenNoRecords="true" NoMasterRecordsText="No hay registros para mostrar." CommandItemDisplay="none">
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                            <HeaderStyle Width="20px" />
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                            <HeaderStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="100" DataField="folio" HeaderText="folio" UniqueName="folio" HeaderStyle-Font-Size="Small">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="100" DataField="fechaCotizacion" HeaderText="Fecha" UniqueName="fechaCotizacion" HeaderStyle-Font-Size="Small">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="100" DataField="cliente" HeaderText="Cliente" UniqueName="cliente" HeaderStyle-Font-Size="Small">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="100" DataField="pedido" HeaderText="Pedido" UniqueName="pedido" HeaderStyle-Font-Size="Small">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="100" DataField="ordenCompra" HeaderText="Orden Compra" UniqueName="ordenCompra" HeaderStyle-Font-Size="Small">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="100" DataField="proyecto" HeaderText="Proyecto" UniqueName="proyecto" HeaderStyle-Font-Size="Small">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderStyle-BackColor="LightBlue" HeaderStyle-Width="100" DataField="vendedor" HeaderText="Vendedor" UniqueName="vendedor" HeaderStyle-Font-Size="Small">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderStyle-BackColor="LightBlue" HeaderStyle-Width="100" DataField="TipoPrecio" HeaderText="TipoPrecio" UniqueName="tipoPrecio" HeaderStyle-Font-Size="Small">
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>

                                    </MasterTableView>
                                    <ClientSettings>
                                        <Selecting AllowRowSelect="true"></Selecting>
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 5px">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 5px">&nbsp;</td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <asp:HiddenField runat="server" ID="RegistroID" Value="0" />
        <asp:HiddenField runat="server" ID="InsertOrUpdate" Value="0" />
        <asp:HiddenField runat="server" ID="filtroBit" Value="1" />
        <asp:HiddenField runat="server" ID="puedeVerPrecioUnit4" Value="False" />
    </telerik:RadAjaxPanel>
    <asp:Button ID="Button1" Style="display: none;" runat="server" Text="Crear Pedido" CssClass="botones" OnClientClick="return confirm('Se creara un pedido con la informacion proporcinada, ¿Desea continuar?');" />&nbsp;&nbsp;
    <asp:Panel ID="panelConfirmacion" runat="server" Visible="false" Width="100%">
        <asp:Button ID="HiddenButtonOk" Text="" Style="display: none;" runat="server" />
        <asp:Button ID="HiddenButtonCancel" Text="" Style="display: none;" runat="server" />
    </asp:Panel>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Bootstrap" Width="100%">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadWindowManager ID="rwError" runat="server" Modal="false" RenderMode="Lightweight" CenterIfModal="true" EnableShadow="false" Localization-OK="Aceptar" Localization-Cancel="Cancelar">
    </telerik:RadWindowManager>
    <telerik:RadWindow ID="RadWindow" runat="server" Title="Error" Modal="True" CenterIfModal="True" Width="200" Height="200">
        <ContentTemplate>
            <br />
            <table align="center" width="95%">
                <tr>
                    <td class="lbl-errors-wrapper">
                        <asp:Label ID="lblErrores" Width="100%" runat="server"></asp:Label>
                        <%--<asp:TextBox ID="txtErrores" TextMode="MultiLine" Width="100%" Rows="10" ReadOnly="true" CssClass="item" runat="server"></asp:TextBox>--%>
                    </td>
                    <tr>
                        <td align="center" width="16%">
                            <br />
                            <br />
                            <asp:Button ID="btnAceptar" runat="server" CausesValidation="true" CssClass="cssBoton" Text="Aceptar" />&nbsp;&nbsp;
                        </td>
                    </tr>
                </tr>

            </table>
            <br />
        </ContentTemplate>
    </telerik:RadWindow>
</asp:Content>

