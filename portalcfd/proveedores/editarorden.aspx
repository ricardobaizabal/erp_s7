<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" CodeBehind="editarorden.aspx.vb" Inherits="erp_s7.editarorden" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <fieldset>
        <legend style="padding-right: 6px; color: Black">
            <asp:Label ID="lblEditorOrdenes" runat="server" Font-Bold="true" CssClass="item" Text="Editor de Orden de Compra"></asp:Label>
        </legend>
        <br />
        <table width="100%" border="0">
            <tr>
                <td class="item" width="50%">
                    <asp:Label ID="lblClaveOC" runat="server" Font-Bold="true" CssClass="item" Text="Folio:"></asp:Label>
                    <asp:Label ID="lblOrden" runat="server" CssClass="item"></asp:Label>
                </td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">&nbsp;</td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <strong>Proveedor: </strong>
                </td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <asp:DropDownList ID="proveedorid" runat="server" Width="85%" CssClass="item"></asp:DropDownList>
                </td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <asp:RequiredFieldValidator ID="valProveedor" runat="server" ForeColor="Red" ValidationGroup="vgOC" SetFocusOnError="true" Text="Requerido" ControlToValidate="proveedorid" InitialValue="0" CssClass="item"></asp:RequiredFieldValidator>
                </td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <strong>Dirección de Entrega: </strong>
                </td>
                <td class="item" width="50%">
                    <strong>Condiciones de pago: </strong>
                </td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <asp:DropDownList ID="cmbDireccion" runat="server" CssClass="item" Width="85%"></asp:DropDownList>
                </td>
                <td class="item" width="50%">
                    <asp:DropDownList ID="cmbCondiciones" runat="server" CssClass="item" Width="85%"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="item" width="50%">&nbsp;</td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <strong>Teléfono:</strong>
                </td>
                <td class="item" width="50%">
                    <strong>Embarque vía: </strong>
                </td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <telerik:RadTextBox ID="txtOCTelefono" runat="server" Width="85%"></telerik:RadTextBox>
                </td>
                <td class="item" width="50%">
                    <telerik:RadTextBox ID="txtShipVia" runat="server" Width="85%"></telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td class="item" width="50%">&nbsp;</td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <strong>Email:</strong>
                </td>
                <td class="item" width="50%">
                    <strong>FOB:</strong>
                </td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <telerik:RadTextBox ID="txtOCEmail" runat="server" Width="85%"></telerik:RadTextBox>
                </td>
                <td class="item" width="50%">
                    <telerik:RadTextBox ID="txtOCFob" runat="server" Width="85%"></telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td class="item" width="50%">&nbsp;</td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <strong>Mensajería:</strong>
                </td>
                <td class="item" width="50%">
                    <strong>Flete prepagado:</strong>
                </td>
            </tr>
            <tr style="vertical-align: top;">
                <td class="item" width="50%">
                    <asp:DropDownList ID="cmbMensajeria" runat="server" Width="85%"></asp:DropDownList>
                </td>
                <td class="item" width="50%">
                    <asp:RadioButtonList ID="rdFletePrepagado" runat="server">
                        <asp:ListItem Text="No" />
                        <asp:ListItem Text="Si" />
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="item" width="50%">&nbsp;</td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <strong>Nombre del Proyecto:</strong>
                </td>
                <td class="item" width="50%">
                    <strong>Lugar del Proyecto:</strong>
                </td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <telerik:RadTextBox ID="txtProyectoNombre" runat="server" Width="500px"></telerik:RadTextBox>
                </td>
                <td class="item" width="50%">
                    <telerik:RadTextBox ID="txtProyectoLugar" runat="server" Width="500px"></telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td class="item" width="50%">&nbsp;</td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <strong>Usuario Solicita:</strong>
                </td>
                <td class="item" width="50%">
                    <strong>Usuario Autoriza:</strong>
                </td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <asp:DropDownList ID="cmbUsuarioSolicita" runat="server" Width="85%"></asp:DropDownList>
                </td>
                <td class="item" width="50%">
                    <asp:DropDownList ID="cmbUsuarioAutoriza" runat="server" Width="85%"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="item" width="50%">&nbsp;</td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <strong>Comentarios:</strong>
                </td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <telerik:RadTextBox ID="txtComentarios" runat="server" TextMode="MultiLine" Width="600px" Height="90px"></telerik:RadTextBox>
                </td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">&nbsp;</td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
        </table>
    </fieldset>
    <br />
    <fieldset class="item">
        <legend style="padding-right: 6px; color: Black">
            <asp:Label ID="lblPartidas" runat="server" Font-Bold="true" CssClass="item" Text="Conceptos"></asp:Label>
        </legend>
        <br />
        Producto: &nbsp;<asp:TextBox ID="txtSearch" runat="server" CssClass="item"></asp:TextBox>&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Buscar" CausesValidation="false" CssClass="item" />&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancelar búsqueda" CssClass="item" /><br />
        <br />
        <asp:Panel ID="panelSearch" runat="server" Visible="false">
            <telerik:RadGrid ID="resultslist" runat="server" Width="100%" ShowStatusBar="True"
                AutoGenerateColumns="False" AllowPaging="True" PageSize="500" GridLines="None"
                Skin="Simple">
                <PagerStyle Mode="NumericPages"></PagerStyle>
                <MasterTableView Width="100%" DataKeyNames="id" NoMasterRecordsText="No se encontraron registros." Name="Products" AllowMultiColumnSorting="False">
                    <Columns>
                        <telerik:GridBoundColumn DataField="codigo" ItemStyle-Width="100px" HeaderText="Código" UniqueName="codigo">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="descripcion" HeaderText="Descripción" UniqueName="descripcion">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn AllowFiltering="False" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" HeaderText="Cantidad" UniqueName="cantidad">
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="txtCantidad" Value="0" MinValue="0" runat="server" Width="80px"></telerik:RadNumericTextBox>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="costo" HeaderText="Costo" ItemStyle-Width="100px" UniqueName="unitario" DataFormatString="{0:c}">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="moneda" HeaderText="Moneda" ItemStyle-Width="100px" UniqueName="moneda">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn AllowFiltering="False" ItemStyle-Width="100px" HeaderStyle-HorizontalAlign="Center" Visible="false" UniqueName="Add">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnAdd" runat="server" CommandArgument='<%# Eval("id") %>'
                                    CommandName="cmdAdd" ImageUrl="~/portalcfd/images/action_add.gif" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:Panel>
        <br />
        <br />
        <div align="right">
            <asp:Button ID="btnAgregaConceptos" runat="server" CssClass="item" Visible="false" Text="Agregar Conceptos" />&nbsp;&nbsp;
        </div>
        <br />
        <br />
        <br />
        <telerik:RadGrid ID="conceptosList" runat="server" Width="100%" ShowStatusBar="True"
            AutoGenerateColumns="False" AllowPaging="True" PageSize="20" GridLines="None"
            Skin="Simple" ShowFooter="true">
            <PagerStyle Mode="NumericPages"></PagerStyle>
            <MasterTableView Width="100%" DataKeyNames="id" NoMasterRecordsText="No se encontraron registros." Name="Products" AllowMultiColumnSorting="False">
                <Columns>
                    <telerik:GridBoundColumn DataField="codigo" HeaderText="Código" UniqueName="codigo">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="descripcion" HeaderText="Descripción" UniqueName="descripcion">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderText="Cantidad" UniqueName="cantidad">
                        <ItemTemplate>
                            <telerik:RadNumericTextBox ID="txtCantidad" runat="server" Width="80px"></telerik:RadNumericTextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="costo" HeaderText="Costo" UniqueName="costo" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="costo_variable" HeaderText="Costo Variable" UniqueName="costo_variable" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="total" HeaderText="Costo Total" UniqueName="total" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="moneda" HeaderText="Moneda" UniqueName="moneda">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center"
                        UniqueName="Del">
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
        <br />
        <span style="color: Red;">* campos requeridos</span>
        <br />
        <br />
        <asp:Button ID="btnAddorder" runat="server" Text="Guardar" />&nbsp;&nbsp;
            <asp:Button ID="btnProcess" runat="server" Text="Procesar orden" BackColor="Green" ForeColor="White" />&nbsp;&nbsp;
            <asp:Button ID="btnCancelar" runat="server" Text="Regresar al listado" CausesValidation="false" />
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
        <br />
        <br />
    </fieldset>
    <br />
    <br />
    <br />
</asp:Content>
