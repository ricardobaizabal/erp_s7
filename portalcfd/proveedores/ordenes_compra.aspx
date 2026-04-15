<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" CodeBehind="ordenes_compra.aspx.vb" Inherits="erp_s7.ordenes_compra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OnRequestStart(target, arguments) {
            if (arguments.get_eventTarget().indexOf("lnkPDF") > -1) {
                arguments.set_enableAjax(false);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="OnRequestStart">
        <asp:Panel ID="panelProductList" runat="server">
            <fieldset>
                <legend style="padding-right: 6px; color: Black">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/icons/buscador_03.jpg" ImageAlign="AbsMiddle" />
                    &nbsp;<asp:Label ID="lblFiltros" Text="Buscador" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
                </legend>
                <br />
                <table border="0" style="width: 100%;">
                    <tr>
                        <td style="width: 15%;">
                            <span class="item">Proveedor:</span>
                        </td>
                        <td align="left" style="width: 20%;">
                            <asp:DropDownList ID="filtroproveedorid" runat="server" Width="95%" CssClass="box"></asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 15%;">
                            <span class="item" style="width: 5%;">Usuario:</span>
                        </td>
                        <td align="left" style="width: 20%;">
                            <asp:DropDownList ID="filtrousuarioid" runat="server" Width="95%" CssClass="box"></asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <span class="item">Fecha Inicio:</span>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="filtroFechaInicio" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <span class="item">Fecha Fin:</span>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="filtroFechaFin" runat="server">
                            </telerik:RadDatePicker>
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSearch" runat="server" CssClass="item" Text="Buscar" />
                            &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAll" runat="server" CssClass="item" Text="Ver todo" />
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </fieldset>
        </asp:Panel>
        <fieldset>
            <legend style="padding-right: 6px; color: Black">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icons/ListaProveedores_03.jpg" ImageAlign="AbsMiddle" />
                &nbsp;<asp:Label ID="lblOrdenesCompra" Text="Ordenes de Compra" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
            </legend>
            <table border="0" style="width: 100%;">
                <tr>
                    <td style="height: 2px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="height: 5px">
                        <asp:Button ID="btnAddOrder" Text="Agregar O.C." runat="server" CausesValidation="False" CssClass="item" TabIndex="6" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 2px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="height: 5px">
                        <telerik:RadGrid ID="ordersList" runat="server" AllowPaging="True"
                            AutoGenerateColumns="False" GridLines="None"
                            PageSize="15" ShowStatusBar="True"
                            Skin="Simple" Width="100%">
                            <ExportSettings HideStructureColumns="true" IgnorePaging="True" FileName="OrdenesCompra">
                                <Excel Format="Biff" />
                            </ExportSettings>
                            <PagerStyle Mode="NumericPages" />
                            <MasterTableView AllowMultiColumnSorting="False" DataKeyNames="id" NoMasterRecordsText="No se encontraron registros." Name="Orders" Width="100%">
                                <CommandItemSettings ShowRefreshButton="false" ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowExportToPdfButton="false" ExportToPdfText="Exportar a pdf" ExportToExcelText="Exportar a excel"></CommandItemSettings>
                                <Columns>
                                    <telerik:GridTemplateColumn AllowFiltering="true" HeaderText="No. Orden"
                                        UniqueName="id">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdEdit" Text='<%# Eval("clave") %>' CausesValidation="false"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="fecha" HeaderText="Fecha" UniqueName="fecha">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="proveedor" HeaderText="Proveedor" UniqueName="proveedor">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="productos" HeaderText="Cat. Prod." ItemStyle-HorizontalAlign="Right" UniqueName="productos">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="costo_variable" DataFormatString="{0:C}" HeaderText="Costo Variable" ItemStyle-HorizontalAlign="Right" UniqueName="costo_variable">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="estatus" HeaderText="Estatus" ItemStyle-HorizontalAlign="Center" UniqueName="estatus">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="usuario" HeaderText="Usuario" ItemStyle-HorizontalAlign="Center" UniqueName="usuario">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" UniqueName="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRecibir" runat="server" CommandArgument='<%# eval("id") %>' CommandName="cmdReceive" Text="recibir"></asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="" UniqueName="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkPDF" runat="server" Text="pdf" CommandArgument='<%# Eval("id") %>' CommandName="cmdPDF"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn AllowFiltering="False" HeaderStyle-HorizontalAlign="Center" UniqueName="Delete">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdDelete" ImageUrl="~/images/action_delete.gif" />
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
                    <td style="height: 2px">&nbsp;</td>
                </tr>
            </table>
        </fieldset>
    </telerik:RadAjaxPanel>
    <telerik:RadWindow ID="RadWindow2" runat="server" Modal="true" CenterIfModal="true" BorderStyle="None" BorderWidth="0px" AutoSize="False" Behaviors="Close" Skin="Bootstrap" VisibleOnPageLoad="False" Width="1024" Height="768">
    </telerik:RadWindow>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Bootstrap" Width="100%">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>