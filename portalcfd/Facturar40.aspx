<%@ Page Title="" Language="VB" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" AutoEventWireup="false" Inherits="erp_s7.portalcfd_Facturar40" MaintainScrollPositionOnPostback="true" CodeBehind="Facturar40.aspx.vb" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
       //function onCantChange(sender){
       //    var parent = sender.parentNode;
       //    var textBox1 = $telerik.findControl(parent, 'txtNov');
       //   //var lblAgregadosCant = $telerik.findControl(parent, 'lblAgregadosCant');
       //    //const numNow = lblAgregadosCant.innerHTML;
       //    console.log(textBox1);
       //    //const numAdd = textBox1.set_value(5);
       //   // console.log('El valor ahora es ' + numNow);
       //    console.log('El valor agregado es' +  numAdd);
       // }
    </script>
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
                        <strong>Seleccione el cliente:</strong>&nbsp;<asp:RequiredFieldValidator ID="valClienteID" runat="server" InitialValue="0" ErrorMessage="Seleccione el cliente al cual le va a facturar." ControlToValidate="cmbCliente" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                    <td class="item" style="width: 20%">
                        <%--<strong>Almacén:</strong>&nbsp;<asp:RequiredFieldValidator ID="ValAlmacen" runat="server" ErrorMessage="Seleccione un almacen." ControlToValidate="cmbAlmacen" InitialValue="0" SetFocusOnError="true" ForeColor="Red" Font-Bold="true" ValidationGroup="valStart"></asp:RequiredFieldValidator>--%>
                    </td>
                    <td class="item" style="width: 20%">
                        <%--<strong>Sucursal:</strong>--%>
                    </td>
                    <td class="item">
                        <%--<strong>Marca:</strong>--%>&nbsp;<asp:RequiredFieldValidator Enabled="false"  ID="valProyecto" runat="server" ControlToValidate="cmbProyecto" InitialValue="0" ErrorMessage="Requerido" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
                    </td>
                </tr>
                <tr>
                    <td class="item" colspan="2">
                        <asp:DropDownList ID="cmbCliente" runat="server" CssClass="box" Width="80%" AutoPostBack="true" CausesValidation="true" ValidationGroup="valStart"></asp:DropDownList>
                    </td>
                    <td class="item" style="width: 20%">
                        <asp:DropDownList Visible="false" ID="cmbAlmacen" runat="server" CssClass="box" Width="80%" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td class="item" style="width: 20%">
                        <asp:DropDownList Visible="false" ID="cmbSucursal" runat="server" CssClass="box" WidthWidth="80%" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td class="item">
                        <asp:DropDownList Visible="false" ID="cmbProyecto" runat="server" CssClass="box" Width="80%" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="item" style="width: 20%">
                        <strong>Tipo de documento:</strong>&nbsp;<asp:RequiredFieldValidator ID="valTipoDocumento" runat="server" InitialValue="0" ErrorMessage="Requerido" ControlToValidate="cmbTipoDocumento" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                    <td class="item" style="width: 20%">
                        <strong>Método de pago:</strong>&nbsp;<asp:RequiredFieldValidator ID="valMetodoPago" runat="server" InitialValue="0" ErrorMessage="Requerido" ControlToValidate="cmbMetodoPago" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                    <td class="item" style="width: 20%">
                        <strong>Moneda:</strong>&nbsp;<asp:RequiredFieldValidator ID="valMoneda" runat="server" InitialValue="0" ErrorMessage="Requerido" ControlToValidate="cmbMoneda" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                    <td class="item" style="width: 20%">
                        <strong>Tipo de cambio:</strong>&nbsp;<asp:RequiredFieldValidator ID="valTipoCambio" runat="server" ControlToValidate="txtTipoCambio" ErrorMessage="Requerido" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                    <td class="item" style="width: 20%">
                        <strong>Orden de compra:</strong>
                    </td>
                </tr>
                <tr>
                    <td class="item" style="width: 20%">
                        <asp:DropDownList ID="cmbTipoDocumento" runat="server" CssClass="box" Width="80%" AutoPostBack="True"></asp:DropDownList>
                    </td>
                    <td class="item" style="width: 20%">
                        <asp:DropDownList ID="cmbMetodoPago" runat="server" CssClass="box" Width="80%"></asp:DropDownList>
                    </td>
                    <td class="item" style="width: 20%">
                        <asp:DropDownList ID="cmbMoneda" runat="server" CssClass="box" Width="80%" AutoPostBack="True"></asp:DropDownList>
                    </td>
                    <td class="item" style="width: 20%">
                        <telerik:RadNumericTextBox ID="txtTipoCambio" runat="server" Width="50%" Type="Currency" Enabled="false" NumberFormat-DecimalDigits="2" Value="0"></telerik:RadNumericTextBox>
                    </td>
                    <td class="item" style="width: 20%">
                        <telerik:RadTextBox ID="txtOrdenCompra" runat="server" Width="50%" CssClass="item">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr>
                    <td class="item" colspan="1">
                        <strong>Exportación</strong>&nbsp;<asp:RequiredFieldValidator ID="valExportacion" runat="server" InitialValue="0" ErrorMessage="Requerido" CssClass="item" ControlToValidate="cmbExportacion" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td colspan="1">
                        <asp:DropDownList ID="cmbExportacion" runat="server" CssClass="box" Width="90%"></asp:DropDownList>
                    </td>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Panel ID="PanelRelacionados" runat="server" >
                            <table style="width: 100%;">
                                <tr>
                                    <td colspan="5">
                                        <div style="width: 100%; display: flex;">
                                            <div style="width: 33%;">
                                                <asp:Label ID="lblTipoRelacion" runat="server" CssClass="item" Font-Bold="True">Tipo de Relación:</asp:Label>
                                                <asp:RequiredFieldValidator ID="ValTipoRelecion" runat="server" InitialValue="0"
                                                    ErrorMessage="Requerido." ControlToValidate="tiporelacionid" SetFocusOnError="true"
                                                    Enabled="false"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:DropDownList ID="tiporelacionid" runat="server" CssClass="box"
                                                    Style="margin-top: 4px">
                                                </asp:DropDownList>
                                                &nbsp;
                                            </div>
                                            <div style="width: 25%; margin-left: 10px">
                                                <asp:Label ID="lblUUID" runat="server" CssClass="item" Font-Bold="True">UUID:</asp:Label>
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
                                            <MasterTableView DataKeyNames="UUID" Width="100%" Name="pedidos" AllowMultiColumnSorting="False" NoMasterRecordsText="No se han agregado UUID relacionados">
                                                <Columns>
                                                    <telerik:GridBoundColumn DataField="UUID" HeaderText="UUID (s)" UniqueName="UUID"
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
            <table width="80%" border="0">
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
                        <asp:Label ID="lblSocialReasonValue" runat="server" CssClass="item" Font-Bold="False"></asp:Label>
                    </td>
                    <td width="33%">
                        <asp:Label ID="lblContactValue" runat="server" CssClass="item" Font-Bold="False"></asp:Label>
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
                        <asp:Label ID="lblContactPhoneValue" runat="server" CssClass="item" Font-Bold="False"></asp:Label>
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
                        <asp:Label ID="lblUsoCFDI" runat="server" CssClass="item" Font-Bold="True" Text="Uso de CFDI:"></asp:Label>
                    </td>
                    <td width="33%">
                        <asp:Label ID="lblFormaPago" runat="server" Text="Forma de pago:" CssClass="item" Font-Bold="true"></asp:Label>
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
                    <td colspan="2" width="66%">
                        <asp:RequiredFieldValidator ID="valUsoCFDI" runat="server" InitialValue="0" ErrorMessage="Requerido" class="item" ControlToValidate="cmbUsoCFD" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                    </td>
                    <td width="33%">
                        <asp:RequiredFieldValidator ID="valFormaPago" runat="server" InitialValue="0" ErrorMessage="Requerido" class="item" ControlToValidate="cmbFormaPago" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
                    <td colspan="2" width="66%">
                        <telerik:RadTextBox ID="txtObservaciones" runat="server" Width="90%" CssClass="item" TextMode="MultiLine" Height="40px">
                        </telerik:RadTextBox>
                    </td>
                    <td width="33%">
                        <telerik:RadTextBox ID="txtNumCtaPago" runat="server" CssClass="item">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td width="33%">
                        <asp:CheckBox Visible="true" CssClass="item" ID="chkAduana" runat="server" Text="Incluye información aduanera" AutoPostBack="true" TextAlign="Right" />
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
            <asp:HiddenField ID="productoid" runat="server" />
            <legend style="padding-right: 6px; color: Black">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/portalcfd/images/concept.jpg" ImageAlign="AbsMiddle" />&nbsp;<asp:Label ID="lblClientItems" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
            </legend>
            <br />
            <table width="100%" cellspacing="0" cellpadding="1" border="0" align="center">
                <tr>
                    <td valign="bottom" class="item">
                        <strong>Buscar:</strong>
                        <asp:TextBox ID="txtSearchItem" runat="server" CssClass="item" AutoPostBack="true"></asp:TextBox>&nbsp;presione enter después de escribir el código
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <telerik:RadGrid ID="gridResults" runat="server" Width="100%" ShowStatusBar="True"
                            AutoGenerateColumns="False" AllowPaging="False" GridLines="None"
                            Skin="Simple" Visible="False">
                            <MasterTableView Width="100%" DataKeyNames="productoid" Name="Items" AllowMultiColumnSorting="False">
                                <Columns>
                                    <telerik:GridTemplateColumn ItemStyle-Width="80px">
                                        <HeaderTemplate>Código</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("codigo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn ItemStyle-Width="80px">
                                        <HeaderTemplate>Código SAT</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCodigoSAT" runat="server" Text='<%#Eval("claveprodserv") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>Descripción</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDescripcion" runat="server" Text='<%#Eval("descripcion") %>' Width="300px" CssClass="item" TextMode="MultiLine" Height="25px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle VerticalAlign="Top" />
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>Unidad</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnidad" runat="server" Text='<%#Eval("unidad") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>Jordan</HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <%--<input id="" type="number" onchange="onCantChange(this)" min="0" class="w-50" />--%>
                                            <telerik:RadNumericTextBox ID="txtJordan" runat="server" Skin="Default" Width="50px" MinValue="0" Value='0' 
                                                AutoPostBack="true" OnTextChanged="txtAlmacen_TextChanged">
                                                <NumberFormat DecimalDigits="2" GroupSeparator="" />
                                            </telerik:RadNumericTextBox>
                                            <strong>Existencia:&nbsp;</strong><asp:Label ID="lblJordanExis" runat="server" Text='<%# Eval("existJordan") %>'></asp:Label>
                                            <strong>Disponibles:&nbsp;</strong><asp:Label ID="lblJordanDisp" runat="server" Text='<%# Eval("dispJordan") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>20 de Noviembre</HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            
                                            <telerik:RadNumericTextBox ID="txtNov" runat="server" Skin="Default" Width="50px" MinValue="0" Value='0' 
                                                AutoPostBack="true" OnTextChanged="txtAlmacen_TextChanged">
                                                <NumberFormat DecimalDigits="2" GroupSeparator="" />
                                            </telerik:RadNumericTextBox>
                                            <strong>Existencia:&nbsp;</strong><asp:Label ID="lblNovExis" runat="server" Text='<%# Eval("existNov") %>'></asp:Label>
                                            <strong>Disponibles:&nbsp;</strong><asp:Label ID="lblNovDisp" runat="server" Text='<%# Eval("dispNov") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>Progreso</HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtProg" runat="server" Skin="Default" Width="45px" MinValue="0" Value='0'
                                                 AutoPostBack="true" OnTextChanged="txtAlmacen_TextChanged">
                                                <NumberFormat DecimalDigits="2" GroupSeparator="" />
                                            </telerik:RadNumericTextBox>
                                            <strong>Existencia:&nbsp;</strong><asp:Label ID="lblProgExis" runat="server" Text='<%# Eval("existProg") %>'></asp:Label>
                                            <strong>Disponibles:&nbsp;</strong><asp:Label ID="lblProgDisp" runat="server" Text='<%# Eval("dispProg") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>Agregados</HeaderTemplate>
                                        <ItemTemplate>
                                            <%--<telerik:RadNumericTextBox ID="txtQuantity" runat="server" Skin="Default" Width="50px" MinValue="0" Value='0'>
                                                <NumberFormat DecimalDigits="4" GroupSeparator="" />
                                            </telerik:RadNumericTextBox>--%>
                                            <asp:Label ID="lblAgregadosCant" runat="server" Text="0" Font-Bold="true"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>Precio Unit.</HeaderTemplate>
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtUnitaryPrice" runat="server" MinValue="0" Value="0"
                                                Skin="Default" Width="70px">
                                                <NumberFormat DecimalDigits="2" GroupSeparator="," />
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn>
                                        <HeaderTemplate>Desc.</HeaderTemplate>
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtDescuentMoney" runat="server" MinValue="0" Value="0"
                                                Skin="Default" Width="70px">
                                                <NumberFormat DecimalDigits="2" GroupSeparator="," />
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <%--<telerik:GridBoundColumn DataField="existencia" HeaderText="Existencia"></telerik:GridBoundColumn>--%>

                                    <%--<telerik:GridTemplateColumn>
                                        <HeaderTemplate>Disponibles</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblDisponibles" runat="server" Text='<%# Eval("disponibles")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>--%>

                                    <%--<telerik:GridBoundColumn DataField="almacen" HeaderText="Almacen"></telerik:GridBoundColumn>--%>

                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" UniqueName="Add">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnAdd" runat="server" CommandArgument='<%# Eval("productoid") %>' CommandName="cmdAdd" ImageUrl="~/portalcfd/images/action_add.gif" CausesValidation="False" ToolTip="Agregar producto como partida" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <br />
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 70%;" align="left">
                                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" CssClass="item"></asp:Label>
                                    </td>
                                    <td style="width: 30%;" align="right">
                                        <asp:Button ID="btnCancelSearch" Visible="false" runat="server" CausesValidation="False" CssClass="item" Text="Cancelar" />&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnAgregaConceptos" runat="server" CssClass="item" Visible="False" Text="Agregar Partidas" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
            <table width="900" cellspacing="0" cellpadding="1" border="0" align="center">
                <tr>
                    <td>
                        <br />
                        <telerik:RadGrid ID="itemsList" runat="server" Width="100%" ShowStatusBar="True" ShowFooter="true"
                            AutoGenerateColumns="False" AllowPaging="False" GridLines="None"
                            Skin="Simple" Visible="False">
                            <MasterTableView Width="100%" DataKeyNames="id" Name="Items" AllowMultiColumnSorting="False">
                                <Columns>
                                    <telerik:GridBoundColumn DataField="codigo" HeaderText="" UniqueName="codigo">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="claveprodserv" HeaderText="Código SAT" UniqueName="claveprodserv">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="descripcion" HeaderText="" UniqueName="descripcion">
                                        <ItemStyle VerticalAlign="Top" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="unidad" HeaderText="" UniqueName="unidad">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cantidad" ItemStyle-HorizontalAlign="Right" HeaderText="" UniqueName="cantidad">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="precio" HeaderText="" UniqueName="precio" DataFormatString="{0:C}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="importe" HeaderText="" UniqueName="importe" DataFormatString="{0:C}">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" UniqueName="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdDelete" ImageUrl="~/images/action_delete.gif" CausesValidation="False" />
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
                    <td align="left" style="width: 10%">
                        <asp:Label ID="lblDescuentoGeneral" runat="server" CssClass="item" Font-Bold="True" Text="Porcentaje:"></asp:Label>
                    </td>
                    <td align="left" style="width: 10%">
                        <%--Type="Currency"--%>
                        <telerik:RadNumericTextBox ID="txtDescuento"  Width="90%" runat="server"></telerik:RadNumericTextBox>
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
                        <asp:Button ID="btnCreateInvoice" runat="server" CausesValidation="true" CssClass="item" />&nbsp;&nbsp;
                        <asp:Button ID="btnCancelInvoice" runat="server" CausesValidation="False" CssClass="item" />&nbsp;&nbsp;
                        <asp:Button ID="btnPreFactura" runat="server" CausesValidation="False" CssClass="item" />
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
    <telerik:RadWindow ID="RadWindow2" runat="server" Modal="true" CenterIfModal="true" AutoSize="False" Behaviors="Close" VisibleOnPageLoad="False" Width="200" Height="200">
        <ContentTemplate>
            <br />
            <table align="center" width="95%">
                <tr>
                    <td>
                        <asp:TextBox ID="txtErroresPre" TextMode="MultiLine" Width="100%" Rows="32" ReadOnly="true" CssClass="item" runat="server"></asp:TextBox>
                    </td>
                    <tr>
                        <td align="left" width="16%">
                            <br />
                            <br />
                            <asp:Button ID="btnAceptarPre" runat="server" CausesValidation="true" CssClass="item" Text="Aceptar" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </tr>
            </table>
            <br />
        </ContentTemplate>
    </telerik:RadWindow>
</asp:Content>
