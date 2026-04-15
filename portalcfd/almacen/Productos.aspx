<%@ Page Title="" Language="VB" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" AutoEventWireup="false" Inherits="erp_s7.portalcfd_Productos" MaintainScrollPositionOnPostback="true" CodeBehind="Productos.aspx.vb" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style4 {
            height: 25px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <%--<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">--%>
    <asp:Panel ID="panelProductList" runat="server">
        <fieldset>
            <legend style="padding-right: 6px; color: Black">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/icons/buscador_03.jpg" ImageAlign="AbsMiddle" />&nbsp;<asp:Label ID="lblFiltros" Text="Buscador" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
            </legend>
            <br />
            <table border="0" style="width: 100%;">
                <tr>
                    <td style="width: 10%;">
                        <span class="item">Palabra clave:</span>
                    </td>
                    <td style="width: 20%;">
                        <asp:TextBox ID="txtSearch" runat="server" Width="95%" CssClass="box"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <span class="item">Marca:</span>
                    </td>
                    <td style="width: 20%;">
                        <asp:DropDownList ID="filtromarcaid" runat="server" Width="95%" CssClass="box"></asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <span class="item">UPC:</span>
                    </td>
                    <td style="width: 20%;">
                        <asp:TextBox ID="upcSearch" runat="server" Width="92%" CssClass="box"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <span class="item">Colección:</span>
                    </td>
                    <td style="width: 20%;">
                        <asp:DropDownList ID="filtrocoleccionid" runat="server" Width="95%" CssClass="box"></asp:DropDownList>
                    </td>
                    <td align="left">
                        <asp:Button ID="btnSearch" runat="server" CssClass="boton" Text="Buscar" />&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAll" runat="server" CssClass="boton" Text="Ver todo" />&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <fieldset>
            <legend style="padding-right: 6px; color: Black">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icons/ListadoProductos_03.jpg" ImageAlign="AbsMiddle" />&nbsp;<asp:Label ID="lblProductsListLegend" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
            </legend>
            <table width="100%">
                <tr>
                    <td style="height: 5px">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadGrid ID="productslist" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" GridLines="None" ShowFooter="True"
                            PageSize="50" ShowStatusBar="True" ExportSettings-ExportOnlyData="False"
                            Skin="Simple" Width="100%">
                            <PagerStyle Mode="NumericPages" />
                            <ExportSettings IgnorePaging="True" FileName="CatalogoProductos">
                                <Excel Format="Biff" />
                            </ExportSettings>
                            <MasterTableView Width="100%" DataKeyNames="id" Name="Products" AllowMultiColumnSorting="False" NoMasterRecordsText="No existen productos registrados" CommandItemDisplay="Top">
                                <CommandItemSettings ShowRefreshButton="false" ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowExportToPdfButton="false" ExportToPdfText="Exportar a pdf" ExportToExcelText="Exportar a excel"></CommandItemSettings>
                                <Columns>
                                    <telerik:GridTemplateColumn AllowFiltering="true" HeaderText="" UniqueName="Codigo">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text='<%# Eval("codigo") %>' CommandArgument='<%# Eval("id") %>' CommandName="cmdEdit" CausesValidation="false"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                                    </telerik:GridTemplateColumn>
                                    <%--<telerik:GridBoundColumn DataField="upc" HeaderText="UPC" UniqueName="upc">
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridBoundColumn DataField="claveprodserv" HeaderText="Clave SAT" UniqueName="claveprodserv">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="unidad" HeaderText="" UniqueName="unidad">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn ItemStyle-Width="130px">
                                        <HeaderTemplate>
                                            Descripción
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label Text='<%#Eval("descripcionCompleta")%>' ID="descripcion" runat="server"></asp:Label>
                                            <telerik:RadToolTip ID="RadToolTip2" runat="server" TargetControlID="descripcion" RelativeTo="Element"
                                                Position="BottomCenter" RenderInPageRoot="true" ManualClose="false">
                                                <%#Eval("descripcionCompleta")%>
                                            </telerik:RadToolTip>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="proyecto" HeaderText="Marca" UniqueName="proyecto">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="coleccion" HeaderText="Colección" UniqueName="coleccion">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="unitario" HeaderText="" UniqueName="unitario" DataFormatString="{0:c}">
                                    </telerik:GridBoundColumn>
                                    <%-- <telerik:GridBoundColumn DataField="unitario2" HeaderText="" UniqueName="unitario2" DataFormatString="{0:c}">
                                    </telerik:GridBoundColumn>--%>
                                    <%--<telerik:GridBoundColumn DataField="unitario3" HeaderText="" UniqueName="unitario3" DataFormatString="{0:c}">
                                    </telerik:GridBoundColumn>--%>
                                    <%--<telerik:GridBoundColumn DataField="unitario4" HeaderText="" UniqueName="unitario4" DataFormatString="{0:c}">
                                    </telerik:GridBoundColumn>--%>
                                    <%--<telerik:GridBoundColumn DataField="unitario5" HeaderText="Precio Unit. 5 (USD)" UniqueName="unitario5" DataFormatString="{0:c}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="unitario6" HeaderText="Precio Unit. 6 (USD)" UniqueName="unitario6" DataFormatString="{0:c}">
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridBoundColumn DataField="monterrey" HeaderText="Jordán" UniqueName="mexico">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="mexico" HeaderText="20 Noviembre" UniqueName="existencia">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="guadalajara" HeaderText="Progreso" UniqueName="guadalajara">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridBoundColumn DataField="matriz" HeaderText="Matriz" UniqueName="matriz">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>--%>
                                    <%--<telerik:GridBoundColumn DataField="mermas" HeaderText="Mermas" UniqueName="existencia">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>--%>
                                    <telerik:GridBoundColumn DataField="proceso" HeaderText="En proceso" UniqueName="proceso">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridBoundColumn DataField="consignacion" HeaderText="En consignación" UniqueName="consignacion">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>--%>
                                    <%--<telerik:GridTemplateColumn ItemStyle-Width="20px" UniqueName="consignacion" AllowSorting="true">
                                        <HeaderTemplate>En consignación</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFolio" runat="server" Text='<%# Eval("consignacion") %>'></asp:Label>
                                            <telerik:RadToolTip ID="RadToolTip1" runat="server" TargetControlID="lblFolio" RelativeTo="Element" Position="BottomCenter" RenderInPageRoot="true" ManualClose="true"><%#Eval("detalle_consignacion")%></telerik:RadToolTip>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridTemplateColumn>--%>
                                    <telerik:GridBoundColumn DataField="disponibles" HeaderText="Disponibles" UniqueName="disponibles">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" UniqueName="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdDelete" ImageUrl="~/images/action_delete.gif" BorderStyle="None" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
                <tr>
                    <td style="height: 5px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="height: 5px">
                        <asp:Button ID="btnAddProduct" runat="server" CausesValidation="False" CssClass="item" TabIndex="6" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 5px">&nbsp;</td>
                </tr>
            </table>
        </fieldset>
        <br />
    </asp:Panel>
    <asp:Panel ID="panelProductRegistration" runat="server" Visible="False">
        <fieldset>
            <legend style="padding-right: 6px; color: Black">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/icons/AgregarEditarProducto_03.jpg" ImageAlign="AbsMiddle" />&nbsp;<asp:Label ID="lblProductEditLegend" runat="server" Font-Bold="True" CssClass="item"></asp:Label>
            </legend>
            <br />
            <table border="0" width="100%">
                <tr>
                    <td class="style4" width="20%">
                        <asp:Label ID="lblCode" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style4" width="20%">
                        <asp:Label ID="lblUnit" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style4" width="20%">
                        <asp:Label ID="lblFoto" runat="server" CssClass="item" Font-Bold="true" Text="Foto:"></asp:Label>
                    </td>
                    <td class="style4" width="20%">
                        <asp:Label ID="lblColeccion" runat="server" CssClass="item" Font-Bold="true" Text="Colección:"></asp:Label>
                    </td>
                    <td class="style4" rowspan="10" align="right" style="vertical-align: top;">
                        <asp:Image ID="imgFoto" runat="server" Width="100%" ImageAlign="AbsMiddle" /><br />
                        <asp:Label ID="lblImgFoto" runat="server" CssClass="item"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4" width="20%">
                        <telerik:RadTextBox ID="txtCode" runat="server" Width="85%">
                        </telerik:RadTextBox>
                    </td>
                    <td class="style4" width="20%">
                        <asp:DropDownList ID="cboclaveunidad" runat="server" CssClass="box" Width="85%"></asp:DropDownList>
                    </td>
                    <td class="style4" width="20%">
                        <asp:FileUpload ID="foto" Width="100%" runat="server" />
                    </td>
                    <td class="style4" width="20%">
                        <asp:DropDownList ID="coleccionid" runat="server" Width="95%" CssClass="box"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style4" width="20%">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" SetFocusOnError="true" Text="Requerido" ControlToValidate="txtCode" CssClass="item"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style4" width="20%">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" SetFocusOnError="true" Text="Requerido" InitialValue="0" ControlToValidate="cboclaveunidad" CssClass="item"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style4" width="20%">&nbsp;</td>
                    <td class="style4" width="20%">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style4" width="20%">
                        <asp:Label ID="lblUnitaryPrice" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtUnitaryPrice" CssClass="item"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style4" width="20%">
                        <asp:Label ID="lblUnitaryPrice2" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style4" width="20%">
                        <asp:Label ID="lblUnitaryPrice3" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                    </td>
                    <td class="style4" width="20%">
                        <asp:Label ID="lblUnitaryPrice4" runat="server" CssClass="item" Font-Bold="True" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4" width="20%">
                        <telerik:RadNumericTextBox ID="txtUnitaryPrice" runat="server" MinValue="0" Type="Currency"
                            Skin="Default" Value="0" Width="85%">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style4" width="20%">
                        <telerik:RadNumericTextBox ID="txtUnitaryPrice2" runat="server" MinValue="0" Type="Currency"
                            Skin="Default" Value="0" Width="85%">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style4" width="20%">
                        <telerik:RadNumericTextBox ID="txtUnitaryPrice3" runat="server" MinValue="0" Type="Currency"
                            Skin="Default" Value="0" Width="85%">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style4" width="20%">
                        <telerik:RadNumericTextBox ID="txtUnitaryPrice4" runat="server" MinValue="0" Type="Currency"
                            Skin="Default" Value="0" Width="85%" Visible="False">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="style4" width="20%">
                        <asp:Label ID="Label2" runat="server" CssClass="item" Font-Bold="True" Text="Precio Unit. 5 (USD):"></asp:Label>
                        <telerik:RadNumericTextBox ID="txtUnitaryPrice5" runat="server" MinValue="0" Type="Currency"
                            Skin="Default" Value="0" Width="85%" Style="margin-top: 12px;">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox>
                    </td>
                    <td class="style4" width="20%">
                        <asp:Label ID="lblUnitaryPrice6" runat="server" CssClass="item" Font-Bold="True" Text="Precio Unit. 6 (USD):"></asp:Label>
                        <telerik:RadNumericTextBox ID="txtUnitaryPrice6" runat="server" MinValue="0" Type="Currency"
                            Skin="Default" Value="0" Width="85%" Style="margin-top: 12px;">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox></td>
                    <td class="style4" width="20%">&nbsp;</td>
                    <td class="style4" width="20%">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td width="20%">
                        <asp:Label ID="lblUPC" runat="server" CssClass="item" Text="UPC:" Font-Bold="True"></asp:Label>
                    </td>
                    <td width="20%">
                        <asp:Label ID="lblClaveProdServ" runat="server" CssClass="item" Text="Clave producto / servicio:" Font-Bold="True"></asp:Label>
                    </td>
                    <td width="20%">
                        <asp:Label ID="lblDescription" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                    </td>
                    <td width="20%">&nbsp;</td>
                    <td width="20%">&nbsp;</td>
                </tr>
                <tr>
                    <td width="20%">
                        <telerik:RadTextBox ID="txtUPC" runat="server" Width="85%">
                        </telerik:RadTextBox>
                    </td>
                    <td width="20%">
                        <asp:DropDownList ID="cboproductoserv" runat="server" CssClass="box" Width="85%"></asp:DropDownList>
                    </td>
                    <td colspan="3">
                        <telerik:RadTextBox ID="txtDescription" runat="server" Width="62%">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="20%">&nbsp;</td>
                    <td width="20%">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" SetFocusOnError="true" Text="Requerido" InitialValue="0" ControlToValidate="cboclaveunidad" CssClass="item"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" SetFocusOnError="true" ControlToValidate="txtDescription" CssClass="item"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="line-height: 30px;">
                        <asp:Label ID="lblPresentacion" runat="server" CssClass="item" Font-Bold="true" Text="Presentación:"></asp:Label><br />
                        <telerik:RadTextBox ID="txtPresentacion" runat="server" Width="95%">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="line-height: 30px;">
                        <asp:Label ID="lblTasa" runat="server" CssClass="item" Font-Bold="true" Text="Tasa:"></asp:Label>&nbsp;<asp:RequiredFieldValidator ID="valTasa" runat="server" ControlToValidate="tasaid" ForeColor="Red" SetFocusOnError="true" CssClass="item" ErrorMessage="Requerido" InitialValue="0"></asp:RequiredFieldValidator><br />
                        <asp:DropDownList ID="tasaid" runat="server" CssClass="box"></asp:DropDownList>
                    </td>
                    <td style="line-height: 30px;">
                        <asp:Label ID="lblMaximo" runat="server" CssClass="item" Font-Bold="true" Text="Máximo:"></asp:Label><br />
                        <telerik:RadNumericTextBox ID="txtMaximo" runat="server" MinValue="0"
                            Skin="Default" Value="0">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox>
                    </td>
                    <td style="line-height: 30px;">
                        <asp:Label ID="lblMinimo" runat="server" CssClass="item" Font-Bold="true" Text="Mínimo:"></asp:Label><br />
                        <telerik:RadNumericTextBox ID="txtMinimo" runat="server" MinValue="0"
                            Skin="Default" Value="0">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox>
                    </td>
                    <td style="line-height: 30px;">
                        <asp:Label ID="lblReorden" runat="server" CssClass="item" Font-Bold="true" Text="Punto reorden:"></asp:Label><br />
                        <telerik:RadNumericTextBox ID="txtReorden" runat="server" MinValue="0"
                            Skin="Default" Value="0">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox>
                    </td>
                    <td style="line-height: 30px;">
                        <asp:Label ID="lblCostoStd" runat="server" CssClass="item" Font-Bold="true" Text="Costo estándar:"></asp:Label><br />
                        <telerik:RadNumericTextBox ID="txtCostoStd" runat="server" MinValue="0" Type="Currency"
                            Skin="Default" Value="0">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="line-height: 30px;">
                        <asp:Label ID="lblCompraMin" runat="server" CssClass="item" Font-Bold="true" Text="Compra mínima:"></asp:Label><br />
                        <telerik:RadNumericTextBox ID="txtCompraMinima" runat="server" MinValue="0"
                            Skin="Default" Value="0">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox>
                    </td>
                    <td style="line-height: 30px;">
                        <asp:Label ID="lblTiempoEntrega" runat="server" CssClass="item" Font-Bold="true" Text="Tiempo de entrega:"></asp:Label><br />
                        <telerik:RadTextBox ID="txtTiempoEntrega" runat="server">
                        </telerik:RadTextBox>
                    </td>
                    <td style="line-height: 30px;">
                        <asp:Label ID="lblMoneda" runat="server" CssClass="item" Font-Bold="true" Text="Moneda:"></asp:Label><br />
                        <asp:DropDownList ID="monedaid" runat="server" CssClass="box"></asp:DropDownList>
                    </td>
                    <td style="line-height: 30px;">
                        <asp:Label ID="lblPesoUnitario" runat="server" CssClass="item" Font-Bold="true" Text="Peso Unit. (Kgs):"></asp:Label><br />
                        <telerik:RadNumericTextBox ID="txtPesoUnitario" runat="server" MinValue="0"
                            Skin="Default" Value="0">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblCostoProm" runat="server" CssClass="item" Font-Bold="true" Text="Costo promedio:"></asp:Label><br />
                        <telerik:RadNumericTextBox ID="txtCostoProm" runat="server" MinValue="0"
                            Skin="Default" Value="0" Enabled="true">
                            <NumberFormat DecimalDigits="2" GroupSeparator="," />
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblProyecto" runat="server" CssClass="item" Font-Bold="true" Text="Marca:"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Requerido" ControlToValidate="proyectoid" InitialValue="0" CssClass="item"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblProveedor" runat="server" CssClass="item" Font-Bold="true" Text="Proveedor:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" CssClass="item" Font-Bold="True" Text="Objeto de impuesto:"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" SetFocusOnError="true" Text="Requerido" InitialValue="0" ControlToValidate="cbmObjetoImpuesto" CssClass="item"></asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="proyectoid" runat="server" CssClass="box"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="proveedorid" runat="server" CssClass="box"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="cbmObjetoImpuesto" runat="server" CssClass="box" Width="85%"></asp:DropDownList>
                    </td>

                    <td style="line-height: 30px; vertical-align: bottom;">
                        <asp:CheckBox ID="chkInventariableBit" Font-Bold="true" runat="server" Text="Producto Inventariable" CssClass="item" />&nbsp;&nbsp;
                        <%--<asp:CheckBox ID="chkManiobraBit" Font-Bold="true" runat="server" Text="Este producto será considerado como una maniobra" CssClass="item" />--%>
                    </td>
                    <td style="line-height: 30px; vertical-align: bottom;">
                        <asp:CheckBox ID="chkPerecederoBit" Font-Bold="true" runat="server" Text="Producto Perecedero" CssClass="item" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <br />
                        <asp:Button ID="btnSaveProduct" runat="server" Width="80px" CssClass="item" />&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" Width="80px" CssClass="item" CausesValidation="False" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" CssClass="item" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="width: 66%; height: 5px;">
                        <asp:HiddenField ID="InsertOrUpdate" runat="server" Value="0" />
                        <asp:HiddenField ID="ProductID" runat="server" Value="0" />
                    </td>
                </tr>
            </table>
            <br />
            <asp:Panel ID="panelCodigosAlternos" runat="server" Visible="False">
                <table border="0" width="100%">
                    <tr>
                        <td style="width: 100%; background-color: GrayText; color: White; font-family: Arial; padding-left: 10px; height: 25px;">
                            <asp:Label ID="Label1" runat="server" Text="Códigos alternos para clientes"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="clienteid" runat="server" CssClass="item"></asp:DropDownList>&nbsp;&nbsp;&nbsp;<telerik:RadTextBox ID="txtClientCode" runat="server" CssClass="item"></telerik:RadTextBox>&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnAddCode" runat="server" Text="Agregar" CssClass="item" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <telerik:RadGrid ID="ClientCodesList" runat="server" Width="70%" ShowStatusBar="True"
                                AutoGenerateColumns="False" AllowPaging="True" PageSize="15" GridLines="None"
                                Skin="Simple">
                                <PagerStyle Mode="NumericPages"></PagerStyle>
                                <MasterTableView Width="100%" DataKeyNames="id" Name="Codes" AllowMultiColumnSorting="False">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="cliente" HeaderText="Cliente" UniqueName="cliente">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="codigo" HeaderText="Código" UniqueName="codigo">
                                        </telerik:GridBoundColumn>

                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center"
                                            UniqueName="Delete">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("id") %>'
                                                    CommandName="cmdDelete" ImageUrl="~/images/action_delete.gif" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </fieldset>
        <br />
        <br />
        <br />
    </asp:Panel>
    <%--</telerik:RadAjaxPanel>--%>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Bootstrap" Width="100%">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>
