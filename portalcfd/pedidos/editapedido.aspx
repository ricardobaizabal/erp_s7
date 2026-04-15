<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" CodeBehind="editapedido.aspx.vb" Inherits="erp_s7.editapedido" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //function OnRequestStart(target, arguments) {
        //    if ((arguments.get_eventTarget().indexOf("productosList") > -1) || (arguments.get_eventTarget().indexOf("btnImprimir") > -1) || (arguments.get_eventTarget().indexOf("btnAuth") > -1)) {
        //        arguments.set_enableAjax(false);
        //    }
        //}
        function confirmCallbackFn(arg) {
            if (arg) //the user clicked OK
            {
                __doPostBack("<%=HiddenButtonOk.UniqueID %>", "");
            }
            else {
                __doPostBack("<%=HiddenButtonCancel.UniqueID %>", "");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="OnRequestStart">--%>
    <div class="item"><a href="pedidos.aspx">Mis Pedidos</a></div>
    <br />
    <fieldset style="border-color: #cccccc; width: 98%; border-width: 1px; border-style: solid; padding: 10px;">
        <legend title="Pedidos." class="item"><strong>Agregar / Editar Pedido</strong></legend>
        <table id="tblIntMainContent2" width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" style="vertical-align: top;">
                    <table id="tblProductos" runat="server" width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellpadding="4" class="item">
                                    <tr>
                                        <td colspan="1">
                                            <strong>Cliente: </strong>
                                        </td>
                                        <td>
                                            <strong>Orden de compra: </strong>&nbsp;&nbsp;
                                        </td>
                                        <td width="25%" class="item">
                                            <strong>Almacén: </strong>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Enabled="false" runat="server" ErrorMessage="Requerido*" ControlToValidate="cmbalmacenid" ForeColor="Red" CssClass="item" InitialValue="0" SetFocusOnError="true" ValidationGroup="valAlmacen"></asp:RequiredFieldValidator>
                                        </td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="1">
                                            <asp:DropDownList ID="cmbclienteid" runat="server" AutoPostBack="true" ValidationGroup="grupo1" CssClass="box" Width="98%" Enabled="false" />
                                            <asp:Label ID="lblRazonsocial" runat="server" class="item" Text="" Visible="false" Width="150px"></asp:Label>
                                        </td>
                                        <td width="25%">
                                            <telerik:RadTextBox ID="txtOrdenCompra" runat="server" CssClass="item" Width="90%" />
                                        </td>
                                        <td width="25%">
                                            <asp:DropDownList ID="cmbalmacenid" runat="server" ValidationGroup="grupo1" CssClass="box" Width="50%"></asp:DropDownList>
                                        </td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <strong>Orden de compra Méx: </strong>
                                        </td>
                                        <td>
                                            <strong>Orden de compra USA: </strong>
                                        </td>
                                        <td width="20%">
                                            <label class="item"><strong>Folios Salida de Almacen:</strong></label>
                                        </td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadTextBox ID="txtOrdenCompraMex" runat="server" CssClass="item" Width="90%" />
                                        </td>
                                        <td>
                                            <telerik:RadTextBox ID="txtOrdenCompraUsa" runat="server" CssClass="item" Width="90%" />
                                        </td>
                                        <td width="20%">
                                            <telerik:RadTextBox ID="txtFolioSalida" runat="server" Width="88" Style="margin-top: 8px;" ValidationGroup="gFolioSalida"></telerik:RadTextBox>&nbsp;<asp:Button ID="btnGuardaFolioSalida" runat="server" CssClass="botones" Text="Guardar Folio" ValidationGroup="gFolioSalida" />
                                            <asp:RequiredFieldValidator ID="valFolioSalida" Enabled="false" runat="server" ErrorMessage="Requerido*" ControlToValidate="txtFolioSalida" ForeColor="Red" CssClass="item" InitialValue="0" SetFocusOnError="true" ValidationGroup="gFolioSalida"></asp:RequiredFieldValidator>
                                        </td>
                                        <td width="25%">
                                            <table>
                                                <tr>
                                                    <td style="width: 100%">
                                                        <telerik:RadGrid Width="100%" ID="FoliosList" runat="server" AllowPaging="True" PageSize="3" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0"
                                                            Skin="Simple" HeaderStyle-Font-Size="Small" ShowHeader="true" ShowFooter="true" MasterTableView-ShowHeadersWhenNoRecords="true">
                                                            <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                                                            </ClientSettings>
                                                            <MasterTableView DataKeyNames="id" ShowHeadersWhenNoRecords="true" NoMasterRecordsText="No se han agregado Folios">
                                                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                                                    <HeaderStyle Width="20px" />
                                                                </RowIndicatorColumn>
                                                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                                                    <HeaderStyle Width="20px" />
                                                                </ExpandCollapseColumn>
                                                                <Columns>
                                                                    <telerik:GridBoundColumn DataField="folio" ItemStyle-Height="20px" ItemStyle-Width="50px" FilterControlAltText="Filter column column" HeaderText="Folio" UniqueName="folio" HeaderStyle-Font-Size="Small">
                                                                    </telerik:GridBoundColumn>
                                                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" UniqueName="ColEliminarProducto" HeaderText="Eliminar">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdEliminar" ImageUrl="~/images/action_delete.gif" CausesValidation="false" />
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
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="25%">
                                            <asp:Button ID="btnActualizarDatos" runat="server" Text="Actualizar" CssClass="botones" CausesValidation="false" />
                                        </td>
                                        <td width="25%">&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td width="25%">&nbsp;</td>
                                        <td width="25%">&nbsp;</td>
                                        <td width="25%">
                                            <asp:DropDownList ID="sucursalid" runat="server" ValidationGroup="grupo1" CssClass="box" Width="90%" Visible="false" />
                                        </td>
                                        <td width="25%">
                                            <asp:DropDownList ID="proyectoid" runat="server" ValidationGroup="grupo1" CssClass="box" Width="90%" Visible="false"></asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%">
                                    <tr>
                                        <td align="right" class="item" colspan="3">
                                            <asp:Panel ID="panelBusqueda" DefaultButton="btnSearch" runat="server">
                                                <asp:Label ID="lblBuscar" runat="server" class="item" Text="Buscar productos:"></asp:Label>
                                                <telerik:RadTextBox ID="txtSearch" runat="server" Width="200px" ValidationGroup="ValSearch"></telerik:RadTextBox>&nbsp;
                                                    <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="botones" ValidationGroup="ValSearch" />
                                                <asp:Button ID="btnCancelarBusqueda" runat="server" Text="Cancelar Búsqueda" CssClass="botones" />
                                                <br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSearch" ErrorMessage="Debe ingresar un texto sobre productos a buscar." ValidationGroup="ValSearch" class="item" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="item">
                                <asp:Label ID="lblMensaje" runat="server" class="item" ForeColor="Red"></asp:Label>
                                <asp:HiddenField runat="server" ID="ClienteId" Value="0" />
                                <asp:HiddenField runat="server" ID="estatusId" Value="0" />
                                <asp:HiddenField runat="server" ID="almacenId" Value="0" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="panel1" Visible="false" runat="server">
                                    <asp:Label ID="lblProdsTitulo" runat="server" Font-Bold="true" Font-Size="Small" class="item" Text="Lista de Productos"></asp:Label><br />
                                    <br />
                                    <telerik:RadGrid Width="100%" ID="productosList" CssClass="grids" runat="server" AllowPaging="True"
                                        PageSize="50" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0"
                                        GridLines="None" Skin="Simple" HeaderStyle-Font-Size="Small" ShowHeader="true">
                                        <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True"></ClientSettings>
                                        <MasterTableView DataKeyNames="productoid,codigo,descripcion,unidad,unitario,existencia,disponibles" ShowHeadersWhenNoRecords="true" NoMasterRecordsText="No hay registros para mostrar.">
                                            <Columns>
                                                <telerik:GridBoundColumn DataField="codigo" ItemStyle-Width="10%" FilterControlAltText="Filter column column" HeaderText="Código" UniqueName="codigo" HeaderStyle-Font-Size="Small">
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridBoundColumn DataField="existencia" ItemStyle-Width="50px" HeaderText="Existencia"></telerik:GridBoundColumn>--%>

                                                <telerik:GridBoundColumn DataField="disponibles" ItemStyle-Width="5%" HeaderText="Disponibles" UniqueName="disponibles">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Cantidad" UniqueName="ColCantidad" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="txtCantidad" Width="60px" Type="Number" NumberFormat-DecimalDigits="2" runat="server"></telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="descripcion" ItemStyle-Width="50%" FilterControlAltText="Filter column2 column" HeaderText="Descripción" UniqueName="descripcion">
                                                </telerik:GridBoundColumn>
                                                <%--<telerik:GridNumericColumn DataField="unitario" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" FilterControlAltText="Filter column column" HeaderText="Precio" UniqueName="unitario" DataType="System.Decimal" DataFormatString="{0:$###,##0.00}" NumericType="Currency">
                                                    </telerik:GridNumericColumn>
                                                    <telerik:GridBoundColumn DataField="unidad" FilterControlAltText="Filter column2 column" HeaderText="Unidad" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Right" UniqueName="unidad">
                                                    </telerik:GridBoundColumn>--%>
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
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <div align="right">
                        <asp:Button ID="btnAgregaConceptos" runat="server" CssClass="item" Visible="False" Text="Agregar Conceptos" />&nbsp;&nbsp;
                    </div>
                </td>
            </tr>
            <tr>
                <td align="left" style="vertical-align: top;">
                    <br />
                    <asp:Label ID="lblPedidotitulo" runat="server" Font-Bold="true" Font-Size="Small" class="item" Text="Detalle del pedido"></asp:Label>
                    <br />
                    <br />
                    <telerik:RadGrid Width="99.8%" ID="pedidodetallelist" runat="server" AllowPaging="True"
                        PageSize="50" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0"
                        Skin="Simple" HeaderStyle-Font-Size="Small" ShowHeader="true" ShowFooter="true">
                        <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                        </ClientSettings>
                        <MasterTableView DataKeyNames="id,pedidoid,productoid,codigo,descripcion,unidad,cantidad,precio,importe" ShowHeadersWhenNoRecords="true" NoMasterRecordsText="No hay registros para mostrar.">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                <HeaderStyle Width="18px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                <HeaderStyle Width="18px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="codigo" FilterControlAltText="Filter column column" HeaderText="Código" UniqueName="codigo" HeaderStyle-Font-Size="Small">
                                </telerik:GridBoundColumn>

                                <telerik:GridTemplateColumn>
                                    <HeaderTemplate>Descripción</HeaderTemplate>
                                    <ItemTemplate>
                                        <telerik:RadTextBox ID="txtDescripcion"
                                            runat="server" Text='<%#Eval("descripcion") %>'
                                            OnTextChanged="txtDescripcionConcepto_TextChanged"
                                            AutoPostBack="true" Width="250px" CssClass="item"
                                            TextMode="MultiLine" Height="7.5em">
                                        </telerik:RadTextBox>
                                    </ItemTemplate>
                                    <ItemStyle VerticalAlign="Top" />
                                </telerik:GridTemplateColumn>

                                <telerik:GridBoundColumn DataField="unidad" ItemStyle-HorizontalAlign="Right" FilterControlAltText="Filter column2 column" HeaderText="Unidad" UniqueName="unidad">
                                </telerik:GridBoundColumn>

                                <%--<telerik:GridBoundColumn DataField="lote" HeaderText="Lote" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="caducidad" HeaderText="Caducidad" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>--%>



                                <%--<telerik:GridBoundColumn DataField="existencia" HeaderText="Existencia" UniqueName="existencia">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="disponibles" HeaderText="Disponibles" UniqueName="disponibles">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>--%>
                                <telerik:GridTemplateColumn DataField="monterrey" HeaderText="Jordán" UniqueName="mexico">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDisponiblesJordan" runat="server" Text="Disp.: "></asp:Label>
                                        <strong><%# Eval("monterrey") %></strong>
                                        <br />
                                        <telerik:RadNumericTextBox ID="txtCantidadJordan" runat="server"
                                            CssClass="mt-8" Width="60px" Type="Number"
                                            NumberFormat-DecimalDigits="2"
                                            OnTextChanged="txtCantidad_TextChanged"
                                            Value='<%# Eval("jordan") %>'
                                            AutoPostBack="true">
                                        </telerik:RadNumericTextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="mexico" HeaderText="20 Noviembre" UniqueName="existencia">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDisponiblesNoviembre" runat="server" Text="Disp.: "></asp:Label>
                                        <strong><%# Eval("mexico") %></strong>
                                        <br />
                                        <telerik:RadNumericTextBox ID="txtCantidadNoviembre" Width="60px"
                                            runat="server" CssClass="mt-8" Type="Number"
                                            NumberFormat-DecimalDigits="2"
                                            OnTextChanged="txtCantidad_TextChanged"
                                            Value='<%# Eval("noviembre") %>'
                                            AutoPostBack="true">
                                        </telerik:RadNumericTextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="guadalajara" HeaderText="Progreso" UniqueName="guadalajara">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDisponiblesProgreso" runat="server" Text="Disp.: "></asp:Label>
                                        <strong><%# Eval("guadalajara") %></strong>
                                        <br />
                                        <telerik:RadNumericTextBox ID="txtCantidadProgreso"
                                            runat="server" CssClass="mt-8" Width="60px" Type="Number"
                                            NumberFormat-DecimalDigits="2"
                                            OnTextChanged="txtCantidad_TextChanged"
                                            Value='<%# Eval("progreso") %>'
                                            AutoPostBack="true">
                                        </telerik:RadNumericTextBox>

                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="agregados" HeaderText="Agregados" UniqueName="agregados">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="cantidad" HeaderText="Cant." UniqueName="cantidad">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                <%--<telerik:GridTemplateColumn HeaderText="Cantidad" UniqueName="ColCantidad" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <telerik:RadNumericTextBox ID="txtCantidad" Width="60px" Type="Number" NumberFormat-DecimalDigits="2" MinValue="0" MaxValue="999" EnabledStyle-HorizontalAlign="Right" DisabledStyle-HorizontalAlign="Right" ReadOnlyStyle-HorizontalAlign="Right" runat="server">
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>--%>

                                <%--<telerik:GridNumericColumn DataField="importe" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" FilterControlAltText="Filter column column" HeaderText="Importe" UniqueName="importe" DataType="System.Decimal" DataFormatString="{0:$###,##0.00}" NumericType="Currency" Aggregate="Sum" FooterAggregateFormatString="TOTAL: {0:$###,##0.00}">
                                    </telerik:GridNumericColumn>--%>
                                <telerik:GridTemplateColumn>
                                    <HeaderTemplate>Precio</HeaderTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ID="txtPrecioConcepto" Type="Currency"
                                            Text='<%# Eval("precio") %>' Width="6em" NumberFormat-DecimalDigits="2"
                                            MinValue="0" runat="server" AutoPostBack="true" OnTextChanged="txtPrecioConcepto_TextChanged">
                                        </telerik:RadNumericTextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridNumericColumn NumericType="Currency" Aggregate="Sum" FooterAggregateFormatString="{0:C}" FooterStyle-Font-Bold="true" DataField="importe" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right" FilterControlAltText="Filter column column" HeaderText="Importe" UniqueName="importe">
                                </telerik:GridNumericColumn>


                                <%--<telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" UniqueName="ColRecalcularProducto" HeaderText="Recalcular">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnRecalcular" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdRecalcular" ImageUrl="~/images/action_calculate.gif" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>--%>

                                <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" UniqueName="ColEliminarProducto" HeaderText="Remover">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdEliminar" ImageUrl="~/images/action_delete.gif" />
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
                <td align="center" style="vertical-align: middle; height: 30px;">
                    <asp:Label ID="lblPedidoError" runat="server" CssClass="merror2" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="height: 70px;" class="item">
                    <asp:Button ID="btnColocarPedido" runat="server" Text="Colocar" CssClass="botones" />&nbsp;&nbsp;&nbsp; 
                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="botones" />&nbsp;
                    <asp:Button ID="btnAuth" runat="server" Text="Autorizar" CssClass="botones" />&nbsp;
                    <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" CssClass="botones" />&nbsp;
                    <asp:Button ID="btnReactivar" runat="server" Text="Reactivar" CssClass="botones" />&nbsp;
                    <asp:Button ID="btnPack" runat="server" Text="Empaquetado" CssClass="botones" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar Pedido" CssClass="botones" CausesValidation="false" />&nbsp; No. Guía:
                    <telerik:RadTextBox ID="txtGuia" Width="120px" runat="server"></telerik:RadTextBox>&nbsp;
                    <asp:Button ID="btnSent" runat="server" Text="Enviado" CssClass="botones" />&nbsp;
                    <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="botones" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </fieldset>
    <%--</telerik:RadAjaxPanel>--%>
    <telerik:RadWindowManager ID="RadWindowManager1" Localization-OK="Aceptar" Localization-Cancel="Cancelar" runat="server">
    </telerik:RadWindowManager>
    <asp:Button ID="HiddenButtonOk" Text="" Style="display: none;" runat="server" />
    <asp:Button ID="HiddenButtonCancel" Text="" Style="display: none;" runat="server" />
    <%--<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Bootstrap" Width="100%">
    </telerik:RadAjaxLoadingPanel>--%>
</asp:Content>
