<%@ Page Title="" Language="VB" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" AutoEventWireup="false" Inherits="erp_s7.portalcfd_almacen_kardex" CodeBehind="kardex.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <fieldset>
            <legend style="padding-right: 6px; color: Black">
                <asp:Label ID="lblEntradas" runat="server" Font-Bold="true" CssClass="item" Text="Kardex de Producto"></asp:Label>
            </legend>
            <br />
            <asp:Panel runat="server" DefaultButton="btnSearch">
                <table border="0" cellpadding="2" cellspacing="0" align="center" width="100%">
                    <tr>
                        <td class="item">Escriba el código o alguna palabra clave para encontrar el producto:<br />
                            <br />
                            <asp:TextBox ID="txtSearch" Width="250px" runat="server" CssClass="box"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" CssClass="boton" Text="Buscar" CausesValidation="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="gridResults" runat="server" Width="60%" ShowStatusBar="True"
                                AutoGenerateColumns="False" AllowPaging="False" GridLines="None"
                                Skin="Simple" Visible="false">
                                <MasterTableView Width="100%" DataKeyNames="id" Name="Items" NoMasterRecordsText="No se encontraron registros." AllowMultiColumnSorting="False">
                                    <Columns>
                                        <telerik:GridTemplateColumn>
                                            <HeaderTemplate>Código</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCodigo" runat="server" Text='<%# eval("codigo") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Middle" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn>
                                            <HeaderTemplate>Descripción</HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDescripcion" runat="server" Text='<%# eval("descripcion") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Middle" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" UniqueName="Add">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkview" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdView" Text="Ver kardex"></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle VerticalAlign="Middle" />
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
                            <asp:HiddenField ID="productoID" runat="server" Value="0" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
        </fieldset>
        <br />
        <asp:Panel runat="server" ID="panelKardex" Visible="false">
            <fieldset>
                <legend style="padding-right: 6px; color: Black">
                    <asp:Label ID="lblProductsListLegend" Text="Kardex del producto seleccionado" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
                </legend>
                <table width="100%">
                    <tr>
                        <td style="height: 5px"></td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadGrid ID="productslist" runat="server" Width="100%" ShowStatusBar="True"
                                AutoGenerateColumns="False" AllowPaging="False" GridLines="None"
                                Skin="Simple">
                                <PagerStyle Mode="NumericPages"></PagerStyle>
                                <MasterTableView Width="100%" DataKeyNames="id" Name="Products" NoMasterRecordsText="No se encontraron registros." AllowMultiColumnSorting="False">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="fecha" HeaderText="Fecha" UniqueName="fecha">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="usuario" HeaderText="Usuario" UniqueName="usuario">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="documento" HeaderText="Documento" UniqueName="documento">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="codigo" HeaderText="Código" UniqueName="unidad">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="movimiento" HeaderText="Movimiento" UniqueName="movimiento">
                                        </telerik:GridBoundColumn>
                                        <%-- <telerik:GridBoundColumn DataField="unidad" HeaderText="Unidad" UniqueName="unidad">
                                    </telerik:GridBoundColumn>--%>
                                        <telerik:GridBoundColumn DataField="descripcion" HeaderText="Descripción" UniqueName="descripcion">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="noPedimento" HeaderText="No. Pedimento" UniqueName="pedimento">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="existencia" HeaderText="Existencia" UniqueName="existencia" ItemStyle-HorizontalAlign="Right">
                                        </telerik:GridBoundColumn>
                                        <%--<telerik:GridBoundColumn DataField="almacen" HeaderText="Almacén" UniqueName="almacen" ItemStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>--%>
                                        <telerik:GridBoundColumn DataField="jordan" HeaderText="Jordán" UniqueName="jordan" ItemStyle-HorizontalAlign="Right">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="noviembre" HeaderText="20 Nov." UniqueName="noviembre" ItemStyle-HorizontalAlign="Right">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="progreso" HeaderText="Progreso" UniqueName="progreso" ItemStyle-HorizontalAlign="Right">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="cantidad" HeaderText="Cant." UniqueName="cantidad" ItemStyle-HorizontalAlign="Right">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="comentario" HeaderText="Comentarios" UniqueName="comentarios">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <br />
    </telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Bootstrap" Width="100%">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>