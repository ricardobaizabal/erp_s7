<%@ Page Title="" Language="VB" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" AutoEventWireup="false" CodeBehind="Facturar.aspx.vb" MaintainScrollPositionOnPostback="true" Inherits="erp_s7.Facturar" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .titulos {
            font-family: verdana;
            font-size: medium;
            color: Purple;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:Panel ID="panelClients" runat="server">
        <fieldset style="padding: 10px;">
            <legend style="padding-right: 6px; color: Black">
                <asp:Image ID="imgPanel1" runat="server" ImageUrl="~/portalcfd/images/comprobant.jpg" ImageAlign="AbsMiddle" />&nbsp;<asp:Label ID="lblClientsSelectionLegend" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
            </legend>
            <br />
            <table border="0" cellpadding="2" cellspacing="0" align="left" width="100%">
                <tr>
                    <td class="item" colspan="2">
                        <strong>Seleccione el cliente:</strong>&nbsp;<asp:RequiredFieldValidator ID="valClienteID" runat="server" InitialValue="0" ErrorMessage="Seleccione el cliente al cual le va a facturar." ControlToValidate="cmbCliente" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                    <td class="item">
                        <strong>Sucursal:</strong>
                    </td>
                    <td class="item" colspan="2">
                        <strong>Marca:</strong> <asp:RequiredFieldValidator Enabled="false" ID="valproyectoid" runat="server" ControlToValidate="cmbProyecto" InitialValue="0" ErrorMessage="Requerido." ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="item" colspan="2">
                        <asp:DropDownList ID="cmbCliente" runat="server" CausesValidation="false" CssClass="item" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td class="item">
                        <asp:DropDownList ID="cmbSucursal" runat="server" CssClass="box" Width="80%" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td class="item" colspan="2">
                        <asp:DropDownList id="cmbProyecto" runat="server" CssClass="box" Width="150px" AutoPostBack="false"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="item" style="width: 20%">
                        <strong>Tipo de documento:</strong>&nbsp;<asp:RequiredFieldValidator ID="valSerieId" runat="server" InitialValue="0" ErrorMessage="Requerido" ForeColor="Red" ControlToValidate="cmbTipoDocumento" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                    <td class="item" style="width: 20%">
                        <strong>Método de pago:</strong>&nbsp;<asp:RequiredFieldValidator ID="valMetodoPago" runat="server" InitialValue="0" ErrorMessage="Requerido" ControlToValidate="cmbMetodoPago" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                    <td class="item" style="width: 20%">
                        <strong>Moneda:</strong>&nbsp;<asp:RequiredFieldValidator ID="valMoneda" runat="server" InitialValue="0" ErrorMessage="Requerido" ControlToValidate="cmbMoneda" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                    <td class="item" style="width: 20%">
                        <strong>Tipo de cambio:</strong>&nbsp;<asp:RequiredFieldValidator ID="valTipoCambio" runat="server" ControlToValidate="txtTipoCambio" ForeColor="Red" ErrorMessage="Requerido" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
                    </td>
                    <td class="item" style="width: 20%">
                        <strong>Orden de compra:</strong>
                    </td>
                </tr>
                <tr>
                    <td class="item" style="width: 20%">
                        <asp:DropDownList ID="cmbTipoDocumento" runat="server" CssClass="box" AutoPostBack="True"></asp:DropDownList>
                    </td>
                    <td class="item" style="width: 20%">
                        <asp:DropDownList ID="cmbMetodoPago" runat="server" CssClass="box" Width="80%"></asp:DropDownList>
                    </td>
                    <td class="item" style="width: 20%">
                        <asp:DropDownList ID="cmbMoneda" runat="server" CssClass="box" Width="80%" AutoPostBack="True"></asp:DropDownList>
                    </td>
                    <td class="item" style="width: 20%">    
                        <telerik:RadNumericTextBox ID="txtTipoCambio" runat="server" NumberFormat-DecimalDigits="2" Value="0"></telerik:RadNumericTextBox>
                    </td>
                    <td class="item" style="width: 20%">
                        <telerik:RadTextBox ID="txtOrdenCompra" runat="server" CssClass="item">
                        </telerik:RadTextBox>
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <br />
    <asp:Panel ID="panelSpecificClient" runat="server" Visible="False">
        <fieldset style="padding: 10px;">
            <legend style="padding-right: 6px; color: Black">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/portalcfd/images/datClient.jpg" ImageAlign="AbsMiddle" />&nbsp;<asp:Label ID="lblClientData" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
            </legend>
            <br />
            <table width="100%" border="0">
                <tr>
                    <td width="33%">
                        <asp:Label ID="lblSocialReason" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                    </td>
                    <td width="33%">
                        <asp:Label ID="lblContact" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                    </td>
                    <td width="33%">
                        <asp:Label ID="lblCondiciones" runat="server" CssClass="item" Font-Bold="True" Text="Condiciones"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="33%">
                        <asp:Label ID="lblSocialReasonValue" runat="server" CssClass="item"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td width="33%">
                        <asp:Label ID="lblContactValue" runat="server" CssClass="item"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td width="33%">
                        <asp:DropDownList ID="cmbCondiciones" runat="server" CssClass="box"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td width="33%">
                        <asp:Label ID="lblContactPhone" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                    </td>
                    <td width="33%">
                        <asp:Label ID="lblRFC" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                    </td>
                    <td width="33%">
                        <asp:Label ID="lblTipoPrecio" runat="server" CssClass="item" Font-Bold="True" Text="Tipo de Precio:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="33%">
                        <asp:Label ID="lblContactPhoneValue" runat="server" CssClass="item"
                            Font-Bold="False"></asp:Label>
                    </td>
                    <td width="33%">
                        <asp:Label ID="lblRFCValue" runat="server" CssClass="item" Font-Bold="False"></asp:Label>
                    </td>
                    <td width="33%">
                        <asp:Label ID="lblTipoPrecioValue" runat="server" CssClass="item" Font-Bold="False"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td width="66%" colspan="2">
                        <asp:Label ID="lblUsoCFDI" runat="server" CssClass="item" Font-Bold="True" Text="Uso de CFDI:"></asp:Label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Requerido" ControlToValidate="cmbUsoCFD" ForeColor="Red" CssClass="item" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>

                    <td width="33%">
                        <asp:Label ID="lblFormaPago" runat="server" Text="Forma de pago:" CssClass="item" Font-Bold="true"></asp:Label>&nbsp;<asp:RequiredFieldValidator ID="valFormaPago" runat="server" ErrorMessage="Requerido" ControlToValidate="cmbFormaPago" ForeColor="Red" CssClass="item" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" width="66%">
                        <asp:DropDownList ID="cmbUsoCFD" runat="server" CssClass="box"></asp:DropDownList>
                    </td>
                    <td width="33%">
                        <asp:DropDownList ID="cmbFormaPago" runat="server" CssClass="box"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="66%" colspan="2">
                        <asp:Label ID="lblObservaciones" runat="server" CssClass="item" Font-Bold="True" Text="Observaciones:"></asp:Label>
                    </td>

                    <td width="33%">
                        <asp:Label ID="lblNumCtaPago" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Panel ID="PanelRelacionados" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="5">
                                        <div style="width: 100%; display: flex;">
                                            <div style="width: 33%;">
                                                <asp:Label ID="lblTipoRelacion" runat="server" CssClass="item" Font-Bold="True" >Tipo de Relación:</asp:Label>
                                                <asp:RequiredFieldValidator ID="ValTipoRelecion" runat="server" InitialValue="0"
                                                    ErrorMessage="Requerido." ControlToValidate="tiporelacionid" SetFocusOnError="true"
                                                    Enabled="false" ></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:DropDownList ID="tiporelacionid" runat="server" CssClass="box" 
                                                    Style="margin-top: 4px" DataTextField="descripcion" DataValueField="id">
                                                </asp:DropDownList>
                                                &nbsp;
                                            </div>
                                            <div style="width: 25%; margin-left: 10px">
                                                <asp:Label ID="lblUUID" runat="server" CssClass="item" Font-Bold="True" >UUID:</asp:Label>
                                                <br />
                                                <asp:DropDownList ID="cmbUUID" runat="server" CssClass="box" Width="95%" Style="margin-top: 8px"></asp:DropDownList>&nbsp;
                                                  <asp:RequiredFieldValidator ID="ValFolioFiscal" runat="server" ErrorMessage="Requerido."
                                                    ControlToValidate="cmbUUID" SetFocusOnError="true" Enabled="false" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                            <div>
                                                <br />
                                                <telerik:RadButton ID="btnAddUiid" runat="server" Text=" Agregar ">
                                                </telerik:RadButton>
                                            </div>
                                        </div>
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="5" width="70%">
                                        <telerik:RadGrid ID="tblRelacionados" runat="server" Width="58%" ShowStatusBar="True"
                                            AutoGenerateColumns="False" AllowPaging="True" PageSize="15" GridLines="None"
                                            Skin="Simple" AllowFilteringByColumn="false">
                                            <PagerStyle Mode="NumericPages"></PagerStyle>
                                            <MasterTableView Width="100%" Name="pedidos" AllowMultiColumnSorting="False" NoMasterRecordsText="No se han agregado UUID relacionados">
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="UUID" HeaderText="UUID (s)" UniqueName="pedido"
                                                        AllowFiltering="false">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center"
                                                        UniqueName="Borrar">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkBorrar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("uuid") %>'
                                                                CommandName="cmdDelete" CausesValidation="false"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView>
                                        </telerik:RadGrid>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" width="66%">
                        <telerik:RadTextBox ID="instrucciones" runat="server" Width="450px" CssClass="item" TextMode="MultiLine" Height="40px">
                        </telerik:RadTextBox>
                    </td>
                    <td width="33%">
                        <telerik:RadTextBox ID="txtNumCtaPago" runat="server" CssClass="item">
                        </telerik:RadTextBox>
                    </td>
                </tr>

                <tr>
                    <td width="33%">
                        <asp:CheckBox ID="chkAduana" CssClass="item" Visible="false" runat="server" Text="Incluye información aduanera" AutoPostBack="true" TextAlign="Right" />
                    </td>
                    <td width="33%">&nbsp;</td>
                    <td width="33%">&nbsp;</td>
                </tr>
                <asp:Panel ID="panelInformacionAduanera" runat="server" Visible="false">
                    <tr>
                        <td colspan="3" class="item" style="line-height: 20px;">
                            <strong>Nombre de la aduana:</strong>
                            <asp:RequiredFieldValidator ID="valNombreAduana" runat="server" ControlToValidate="nombreaduana" ErrorMessage="Escriba el nombre de la aduana." SetFocusOnError="true"></asp:RequiredFieldValidator><br />
                            <telerik:RadTextBox ID="nombreaduana" runat="server" Width="450px" CssClass="item">
                            </telerik:RadTextBox>
                            <br />
                            <strong>Fecha de pedimento:</strong>
                            <asp:RequiredFieldValidator ID="valFechaPedimento" runat="server" ControlToValidate="fechapedimento" ErrorMessage="Selecciona la fecha del pedimento." SetFocusOnError="true"></asp:RequiredFieldValidator><br />
                            <telerik:RadDatePicker ID="fechapedimento" runat="server">
                            </telerik:RadDatePicker>
                            <br />
                            <strong>Número de pedimento:</strong>
                            <asp:RequiredFieldValidator ID="valNumeroPedimento" runat="server" ControlToValidate="numeropedimento" ErrorMessage="Escriba el número de pedimento." SetFocusOnError="true"></asp:RequiredFieldValidator><br />
                            <telerik:RadTextBox ID="numeropedimento" runat="server" Width="450px" CssClass="item">
                            </telerik:RadTextBox>
                            <br />
                        </td>
                    </tr>
                </asp:Panel>
            </table>
        </fieldset>
    </asp:Panel>

    <br />

    <asp:Panel ID="panelItemsRegistration" runat="server" Visible="False">
        <fieldset style="padding: 10px;">
            <asp:HiddenField ID="productoid" Value="0" runat="server" />
            <asp:HiddenField ID="partidaid" Value="0" runat="server" />
            <legend style="padding-right: 6px; color: Black">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/portalcfd/images/concept.jpg" ImageAlign="AbsMiddle" />&nbsp;<asp:Label ID="lblClientItems" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
            </legend>
            <br />
            <table width="900" cellspacing="0" cellpadding="1" border="0" align="center">
                <tr>
                    <td valign="bottom" class="item">
                        <strong>Buscar:</strong>
                        <asp:TextBox ID="txtSearchItem" runat="server" CssClass="box" AutoPostBack="true"></asp:TextBox>&nbsp;presione enter después de escribir el código
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadGrid ID="gridResults" runat="server" Width="100%" ShowStatusBar="True"
                            AutoGenerateColumns="False" AllowPaging="False" GridLines="None"
                            Skin="Simple" Visible="False">
                            <MasterTableView Width="100%" DataKeyNames="id" Name="Items" AllowMultiColumnSorting="False">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="codigo" HeaderText="Código" UniqueName="codigo">
                                    </telerik:GridBoundColumn>

                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>Descripción</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDescripcion" runat="server" Text='<%# eval("descripcion") %>' Width="480px" CssClass="box" TextMode="MultiLine" Height="25px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="Top" />
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>Unidad</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnidad" runat="server" Text='<%# eval("unidad") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>Cant.</HeaderTemplate>
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtQuantity" runat="server" Skin="Default" Width="50px"
                                                MinValue="0" Value='0'>
                                                <NumberFormat DecimalDigits="4" GroupSeparator="" />
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>Precio Unit.</HeaderTemplate>
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtUnitaryPrice" runat="server" MinValue="0" Value="0"
                                                Skin="Default" Width="80px">
                                                <NumberFormat DecimalDigits="4" GroupSeparator="," />
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridBoundColumn DataField="lote" HeaderText="Lote" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="caducidad" HeaderText="Caducidad" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="existencia" HeaderText="Existencia"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="almacen" HeaderText="Almacen"></telerik:GridBoundColumn>

                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" UniqueName="Add">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnAdd" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdAdd" ImageUrl="~/portalcfd/images/action_add.gif" CausesValidation="False" ToolTip="Agregar producto como partida" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <asp:Button ID="btnCancelSearch" Visible="false" runat="server" CausesValidation="False" CssClass="item" Text="Cancelar" />
                    </td>
                </tr>
            </table>
            <br />
            <table width="80%" cellspacing="0" cellpadding="1" border="0" align="center">
                <tr>
                    <td>
                        <br />
                        <telerik:RadGrid ID="itemsList" runat="server" Width="100%" ShowStatusBar="True"
                            AutoGenerateColumns="False" AllowPaging="False" GridLines="None"
                            Skin="Simple" Visible="False">
                            <MasterTableView Width="100%" DataKeyNames="id" Name="Items" AllowMultiColumnSorting="False">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="codigo" HeaderText="Código" UniqueName="codigo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="descripcion" HeaderText="" UniqueName="descripcion">
                                        <ItemStyle VerticalAlign="Top" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="unidad" HeaderText="" UniqueName="unidad">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cantidad" HeaderText="" UniqueName="cantidad">
                                    </telerik:GridBoundColumn>
                                    <%--<telerik:GridBoundColumn DataField="precio" HeaderText="" UniqueName="precio" DataFormatString="{0:C}">
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" HeaderText="Precio Unitario" UniqueName="precio">
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtPrecio" Width="90px" AutoPostBack="true" Type="Currency" Text='<%# Eval("precio") %>' NumberFormat-DecimalDigits="2" OnTextChanged="txtPrecio_TextChanged" runat="server"></telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="importe" HeaderText="" UniqueName="importe" DataFormatString="{0:C}">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
        </fieldset>

    </asp:Panel>

    <br />

    <asp:Panel ID="panelDescuento" runat="server" Visible="False">
        <fieldset style="padding: 10px;">
            <legend style="padding-right: 6px; color: Black">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/portalcfd/images/descuento.jpg" ImageAlign="AbsMiddle" />&nbsp;<asp:Label ID="lblDescDescuento" runat="server" Text="Descuento a nivel factura" Font-Bold="true" CssClass="item"></asp:Label>
            </legend>

            <br />

            <table width="100%" border="0" align="left">
                <tr>
                    <td align="left" style="width: 8%">
                        <asp:Label ID="lblDescuentoGeneral" runat="server" CssClass="item" Font-Bold="True" Text="% Descuento:"></asp:Label>
                    </td>
                    <td align="left" style="width: 10%">
                        <telerik:RadNumericTextBox ID="txtDescuento" Type="Percent" MinValue="0" MaxValue="100" Width="90%" runat="server"></telerik:RadNumericTextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnAplicarDescuento" runat="server" ValidationGroup="vgDescuento" Text="Aplicar Descuento" CssClass="item" />&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0" ValidationGroup="vgDescuento" ErrorMessage="Proporcione un porcentaje de descuento" ControlToValidate="txtDescuento" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>

    <br />

    <asp:Panel ID="panelResume" runat="server" Visible="False">
        <fieldset style="padding: 10px;">
            <legend style="padding-right: 6px; color: Black">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/portalcfd/images/resumen.jpg" ImageAlign="AbsMiddle" />&nbsp;<asp:Label ID="lblResume" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
            </legend>

            <br />

            <table width="100%" align="left">
                <tr>
                    <td width="16%" align="left" style="width: 32%">
                        <asp:Label ID="lblSubTotal" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                        &nbsp;<asp:Label ID="lblSubTotalValue" runat="server" CssClass="item"
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="16%" align="left" style="width: 32%">
                        <asp:Label ID="lblImporteTasaCero" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                        &nbsp;<asp:Label ID="lblImporteTasaCeroValue" runat="server" CssClass="item"
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="16%" align="left" style="width: 32%">
                        <asp:Label ID="lblDescuento" runat="server" CssClass="item" Font-Bold="True" Text="Descuento="></asp:Label>
                        &nbsp;<asp:Label ID="lblDescuentoValue" runat="server" CssClass="item"
                            Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="16%" align="left" style="width: 32%">
                        <asp:Label ID="lblIVA" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                        &nbsp;<asp:Label ID="lblIVAValue" runat="server" CssClass="item" Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <%--<tr>
                    <td align="left" style="width: 32%">
                        <asp:Label ID="lblRetISR" runat="server" CssClass="item" Font-Bold="True" Text="Ret. ISR="></asp:Label>
                        &nbsp;<asp:Label ID="lblRetISRValue" runat="server" CssClass="item" Font-Bold="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" style="width: 32%">
                        <asp:Label ID="lblRetIVA" runat="server" CssClass="item" Font-Bold="True" Text="Ret. IVA="></asp:Label>
                        &nbsp;<asp:Label ID="lblRetIVAValue" runat="server" CssClass="item" Font-Bold="False"></asp:Label>
                    </td>
                </tr>--%>
                <asp:Panel ID="panelRetencion" runat="server" Visible="false">
                    <tr>
                        <td width="16%" align="left" style="width: 32%">
                            <asp:Label ID="lblRet" runat="server" CssClass="item" Font-Bold="True" Text="Retención 4%="></asp:Label>
                            &nbsp;<asp:Label ID="lblRetValue" runat="server" CssClass="item" Font-Bold="False"></asp:Label>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td width="16%" align="left" style="width: 32%">
                        <asp:Label ID="lblTotal" runat="server" CssClass="item" Font-Bold="True"></asp:Label>
                        &nbsp;<asp:Label ID="lblTotalValue" runat="server" CssClass="item" Font-Bold="False"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td align="left" width="16%">
                        <br />
                        <br />
                        <asp:Button ID="btnCreateInvoice" runat="server" CausesValidation="True" CssClass="item" />&nbsp;&nbsp;
                        <asp:Button ID="btnCancelInvoice" runat="server" CausesValidation="False" CssClass="item" />
                        <br />
                        <br />
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>

    <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" CenterIfModal="true" AutoSize="False" Behaviors="Close" VisibleOnPageLoad="False" Width="740" Height="600">
        <ContentTemplate>
            <br />
            <table align="center" width="95%">
                <tr>
                    <td>
                        <asp:TextBox ID="txtErrores" TextMode="MultiLine" Width="100%" Rows="32" ReadOnly="true" CssClass="item" runat="server"></asp:TextBox>
                    </td>
                    <tr>
                        <td align="left" width="16%">
                            <br />
                            <br />
                            <asp:Button ID="btnAceptar" runat="server" CausesValidation="true" CssClass="item" Text="Aceptar" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </tr>
            </table>
            <br />
        </ContentTemplate>
    </telerik:RadWindow>
    <%--<telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" CenterIfModal="true" AutoSize="false" VisibleOnPageLoad="false" Behaviors="Close" Width="700" Height="600">
        <ContentTemplate>
            <br />
            <table align="center" width="90%" border="0">
                <tr>
                    <td>
                        <telerik:RadGrid ID="itemsInventoryList" runat="server" Width="100%" ShowStatusBar="True" AutoGenerateColumns="False" AllowPaging="False" GridLines="None" Skin="Simple">
                            <MasterTableView Width="100%" DataKeyNames="id,productoid,existencia" Name="Items" AllowMultiColumnSorting="False">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="id" HeaderText="ID" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="descripcion" HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="unidad" HeaderText="Unidad" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="almacen" HeaderText="Almacén" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="lote" HeaderText="Lote" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="caducidad" HeaderText="Caducidad" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="existencia" HeaderText="Existencia" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>Cantidad</HeaderTemplate>
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtCantidad" runat="server" MinValue="0" Value="0" Skin="Default" Width="80px" OnTextChanged="txtCantidad_TextChanged" AutoPostBack="true">
                                                <NumberFormat DecimalDigits="4" GroupSeparator="," />
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <asp:Label ID="lblTotalDetalle" runat="server" Text="Total: 0" Font-Bold="true" CssClass="item"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" CssClass="item"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <br />
                        <br />
                        <asp:Button ID="btnGuardarDetalle" runat="server" Text="Guardar" CausesValidation="False" CssClass="item" />
                        <asp:HiddenField ID="totalPiezasProcesadas" Value="0" runat="server" />
                        <asp:HiddenField ID="totalPiezasPartida" Value="0" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
        </ContentTemplate>
    </telerik:RadWindow>--%>

</asp:Content>
