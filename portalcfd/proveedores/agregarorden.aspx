<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" CodeBehind="agregarorden.aspx.vb" Inherits="erp_s7.agregarorden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <fieldset>
        <legend style="padding-right: 6px; color: Black">
            <asp:Label ID="lblEditorOrdenes" runat="server" Font-Bold="true" CssClass="item" Text="Agregar Orden de Compra"></asp:Label>
        </legend>
        <br />
        <table width="100%" border="0">
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
                        <asp:ListItem Text="No" Selected="True" />
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
                    <telerik:RadTextBox ID="txtProyectoNombre" runat="server" Width="85%"></telerik:RadTextBox>
                </td>
                <td class="item" width="50%">
                    <telerik:RadTextBox ID="txtProyectoLugar" runat="server" Width="85%"></telerik:RadTextBox>
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
                <td class="item" width="50%">
                    <asp:RequiredFieldValidator ID="valUsuarioSolicita" runat="server" ForeColor="Red" ValidationGroup="vgOC" SetFocusOnError="true" Text="Requerido" ControlToValidate="cmbUsuarioSolicita" InitialValue="0" CssClass="item"></asp:RequiredFieldValidator>
                </td>
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
                    <telerik:RadTextBox ID="txtComentarios" runat="server" TextMode="MultiLine" Width="85%" Height="90px"></telerik:RadTextBox>
                </td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">&nbsp;</td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
            <tr>
                <td class="item" width="50%">
                    <asp:Button ID="btnAddorder" runat="server" CssClass="item" ValidationGroup="vgOC" Text="Guardar" />&nbsp;&nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="item" Text="Cancelar" CausesValidation="false" />
                </td>
                <td class="item" width="50%">&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
    </fieldset>
</asp:Content>
