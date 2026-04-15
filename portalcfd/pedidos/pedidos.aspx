<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" EnableEventValidation="false" CodeBehind="pedidos.aspx.vb" Inherits="erp_s7.pedidos" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .box-width-300px {
            width: 300px;
        }

        span .box-height-17px {
            height: 17px;
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
            if ((arguments.get_eventTarget().indexOf("pedidosList") > -1) || (arguments.get_eventTarget().indexOf("btnExportExcel") > -1)) {
                arguments.set_enableAjax(false);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadWindowManager ID="RadWindowManager1" Localization-OK="Aceptar" Localization-Cancel="Cancelar" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="OnRequestStart">
        <fieldset style="border-color: #cccccc; width: 100%; border-width: 0px; border-style: solid; padding: 10px;">
            <legend title="Pedidos." class="item"><strong>Mis Pedidos</strong></legend>
            <table id="tblIntMainContent2" border="0" width="100%" cellpadding="0" cellspacing="0">
                <tr style="display: none">
                    <td align="left" style="vertical-align: top;">
                        <asp:Panel ID="panelNuevoPedido" runat="server">
                            <table width="100%" border="0">
                                <tr valign="top" style="height: 20px;">
                                    <td colspan="6">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="item"><strong>Cliente:</strong></td>
                                    <td class="item"><strong>Sucursal:</strong></td>
                                    <td class="item"><strong>Almacén:</strong></td>
                                    <td class="item"><strong>Marca:</strong></td>
                                    <td class="item"><strong>Orden de compra:</strong></td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 35%;">
                                        <asp:DropDownList ID="clienteid" runat="server" AutoPostBack="true" ValidationGroup="grupo1" CssClass="box"></asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 15%;">
                                        <asp:DropDownList ID="sucursalid" runat="server" ValidationGroup="grupo1" CssClass="box"></asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 15%;">
                                        <asp:DropDownList ID="almacenid" runat="server" ValidationGroup="grupo1" CssClass="box"></asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 15%;">
                                        <asp:DropDownList ID="proyectoid" runat="server" ValidationGroup="grupo1" CssClass="box"></asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 12%;">
                                        <telerik:RadTextBox ID="txtOrdenCompra" Width="100px" runat="server" CssClass="item">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnCrearPedido" ValidationGroup="grupo1" runat="server" Text="Crear Pedido" CssClass="botones" />
                                    </td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 35%;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="clienteid" class="item" ErrorMessage="Seleccione un cliente" ForeColor="Red" InitialValue="0" SetFocusOnError="True" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left" style="width: 15%;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="sucursalid" class="item" ErrorMessage="Seleccione una sucursal" ForeColor="Red" InitialValue="0" SetFocusOnError="True" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left" style="width: 15%;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="almacenid" class="item" ErrorMessage="Seleccione un almacén" ForeColor="Red" InitialValue="0" SetFocusOnError="True" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left" style="width: 15%;">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="proyectoid" class="item" ErrorMessage="Seleccione un proyecto" ForeColor="Red" InitialValue="0" SetFocusOnError="True" ValidationGroup="grupo1"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr valign="top" style="height: 20px;">
                                    <td align="right" colspan="6">
                                        <asp:Label ID="lblMensaje" ForeColor="Red" runat="server" class="item" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <fieldset>
                            <legend style="padding-right: 6px; color: Black">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/icons/buscador_03.jpg" ImageAlign="AbsMiddle" />&nbsp;<asp:Label ID="lblFiltros" Text="Buscador" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
                            </legend>
                            <br />
                            <asp:Panel runat="server" DefaultButton="btnSearch">
                                <span class="item">Cliente:
                                <asp:DropDownList ID="filtroclienteid" runat="server" Width="250px" CssClass="box"></asp:DropDownList>&nbsp;&nbsp;&nbsp;Estatus:
                                <asp:DropDownList ID="filtroestatusid" runat="server" Width="100px" CssClass="box"></asp:DropDownList>&nbsp;&nbsp;&nbsp;Monto Total:
                                <telerik:RadNumericTextBox ID="filtroMontoTotal" runat="server" Width="100px" CssClass="box-height-17px"></telerik:RadNumericTextBox>&nbsp;&nbsp;&nbsp;Palabra clave:
                                <telerik:RadTextBox ID="txtSearch" runat="server" Width="120px"></telerik:RadTextBox>&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnSearch" runat="server" CssClass="boton" Text="Buscar" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnAll" runat="server" CssClass="boton" Text="Ver todos" />&nbsp;&nbsp;&nbsp;
                                </span>
                            </asp:Panel>
                            <br />
                            <br />
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnExportExcel" runat="server" Text="Exportar a Excel" Visible="false" /><br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="left" style="vertical-align: top;">
                        <telerik:RadGrid ID="pedidosList" runat="server" AllowPaging="True" PageSize="50" AllowSorting="True"
                            AutoGenerateColumns="False" CellSpacing="0" Skin="Simple" Width="100%" AllowMultiRowSelection="true">
                            <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                            </ClientSettings>
                            <MasterTableView DataKeyNames="id, cliente, fecha_alta, estatusid, estatus, timbrado" ShowHeadersWhenNoRecords="true" NoMasterRecordsText="No hay registros para mostrar.">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn1" Exportable="false"></telerik:GridClientSelectColumn>
                                    <telerik:GridBoundColumn DataField="id" HeaderText="No. Pedido" UniqueName="id" HeaderStyle-Font-Size="Small">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cotizacion" HeaderText="Cotización" UniqueName="cotizacion" HeaderStyle-Font-Size="Small">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cliente" HeaderText="Cliente" UniqueName="cliente" HeaderStyle-Font-Size="Small">
                                    </telerik:GridBoundColumn>
<%--                                    <telerik:GridBoundColumn DataField="sucursal" HeaderText="Sucursal" UniqueName="sucursal">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="proyecto" HeaderText="Marca" UniqueName="proyecto" HeaderStyle-Font-Size="Small">
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridBoundColumn DataField="ejecutivo" HeaderText="Ejecutivo" UniqueName="ejecutivo" HeaderStyle-Font-Size="Small">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="fecha_alta" HeaderText="Fecha alta" UniqueName="fecha_alta">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="estatus" HeaderText="Estatus" UniqueName="estatus">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="factura" HeaderText="Factura" UniqueName="factura">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="metodopagoid" HeaderText="Metodo de Pago" UniqueName="metodopagoid">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="formapago" HeaderText="Forma de Pago" UniqueName="formapago">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="fecha_pago" HeaderText="Fecha Pago" UniqueName="fecha_pago">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="guia" HeaderText="No. Guía" UniqueName="guia">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="orden_compra" HeaderText="Orden Compra" UniqueName="orden_compra">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="monto_total" HeaderText="Monto Total" UniqueName="monto_total" DataFormatString="{0:C2}">
                                    </telerik:GridBoundColumn>

                                    <telerik:GridTemplateColumn UniqueName="ColEditar" AllowFiltering="true" HeaderText="Ver/Editar" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdEditar" ImageUrl="~/images/action_edit.png" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColSalida" AllowFiltering="true" HeaderText="Dar salida" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnSalida" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmbSalida" ImageUrl="~/images/salida.png" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColEtapaAbierto" AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" HeaderText="Regresar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEtapaAbierto" runat="server" CommandArgument='<%# Eval("id") %>' Width="26px" CommandName="cmdEtapaAbierto" ImageUrl="~/images/refresh_reload_back.png" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColDelete" AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdEliminar" ImageUrl="~/images/action_delete.gif" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColFacturar" AllowFiltering="true" HeaderText="Facturar" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkFacturar" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdFacturar" ImageUrl="~/images/icon-newfile.png"></asp:ImageButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="ColFacturarAnticipo" AllowFiltering="true" HeaderText="Facturar anticipo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkFacturarAnticipo" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdFacturarAnticipo" ImageUrl="~/images/sell.png"></asp:ImageButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
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
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="display: none">
                            <telerik:RadGrid ID="ExcelGrid" runat="server" AllowPaging="True" PageSize="50"
                                AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" Skin="Simple" Width="100%" AllowMultiRowSelection="true"
                                ExportSettings-ExportOnlyData="false" ExportSettings-IgnorePaging="false">
                                <ExportSettings IgnorePaging="True" FileName="Pedidos">
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
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="100" DataField="fecha" HeaderText="Fecha" UniqueName="fecha" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="60" DataField="mes" HeaderText="Mes" UniqueName="mes" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="30" DataField="numero" HeaderText="#" UniqueName="numero" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="250" DataField="cliente" HeaderText="Cliente" UniqueName="cliente" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="120" DataField="marca" HeaderText="Marca" UniqueName="marca" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="LightBlue" HeaderStyle-Width="100" DataField="nopedido" HeaderText="No. Pedido" UniqueName="nopedido" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Lightgreen" HeaderStyle-Width="100" DataField="cotizacion" HeaderText="Cotizacion" UniqueName="cotizacion" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="300" DataField="modelo" HeaderText="Modelo" UniqueName="modelo" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="150" DataField="sku" HeaderText="SKU" UniqueName="sku" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="100" DataField="totalpiezas" HeaderText="Total Piezas" UniqueName="totalpiezas" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <%-- <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="250" DataField="comprador" HeaderText="Comprador" UniqueName="comprador" HeaderStyle-Font-Size="Small">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="250" DataField="clientefinal" HeaderText="Comprador Final" UniqueName="comprador" HeaderStyle-Font-Size="Small">
                                    </telerik:GridBoundColumn>--%>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="150" DataField="guia" HeaderText="Guía de Envío" UniqueName="guia" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="100" DataField="comentarios" HeaderText="Comentarios" UniqueName="comentarios" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="80" DataField="metodopagoid" HeaderText="Metodo Pago" UniqueName="factura" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="150" DataField="metodopago" HeaderText="Metodo pago" UniqueName="fullshopify" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="80" DataField="factura" HeaderText="Factura" UniqueName="factura" HeaderStyle-Font-Size="Small">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderStyle-BackColor="Silver" HeaderStyle-Width="110" DataField="montototal" HeaderText="Total" UniqueName="montototal" HeaderStyle-Font-Size="Small" DataType="System.Decimal" DataFormatString="{0:$###,##0.00}">
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
            </table>
        </fieldset>
    </telerik:RadAjaxPanel>
    <asp:Panel ID="panelConfirmacion" runat="server" Visible="false" Width="100%">
        <asp:Button ID="HiddenButtonOk" Text="" Style="display: none;" runat="server" />
        <asp:Button ID="HiddenButtonCancel" Text="" Style="display: none;" runat="server" />
    </asp:Panel>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Bootstrap" Width="100%">
    </telerik:RadAjaxLoadingPanel>
    <div style="text-align: right; float: inherit; margin-right: 5px">
        <asp:Button ID="btnReportePedidos" runat="server" Text="Descargar Packing List" CssClass="botones" />
        <br />
        <br />
    </div>
</asp:Content>
