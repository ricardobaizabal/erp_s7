<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" CodeBehind="productos.aspx.vb" Inherits="erp_s7.productos" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function OnRequestStart(target, arguments) {
            if (arguments.get_eventTarget().indexOf("reporteGrid") > -1) {
                arguments.set_enableAjax(false);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="OnRequestStart">
        <fieldset>
            <legend style="padding-right: 6px; color: Black">
                <asp:Label ID="lblReportsLegend" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
            </legend>
            <table width="100%">
                <tr>
                    <td style="height: 5px"></td>
                </tr>
                <tr>
                    <td class="item">Seleccione el rango de fechas :<br />
                        <br />
                        <table width="100%" border="0">
                            <tr>
                                <td>Desde:</td>
                                <td>
                                    <telerik:RadDatePicker ID="fechaini" runat="server">
                                        <Calendar UseColumnHeadersAsSelectors="False"
                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>Hasta:</td>
                                <td>
                                    <telerik:RadDatePicker ID="fechafin" runat="server">
                                        <Calendar UseColumnHeadersAsSelectors="False"
                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                    </telerik:RadDatePicker>
                                </td>
                                <td>Cliente:</td>
                                <td>
                                    <asp:DropDownList ID="clienteid" runat="server" CssClass="box" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnGenerate" runat="server" Text="Generar" CssClass="boton" />
                                </td>
                            </tr>
                            <tr>
                                <td>Sucursal:</td>
                                <td>
                                    <asp:DropDownList ID="sucursalid" runat="server" CssClass="box" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td>Vendedor:</td>
                                <td>
                                    <asp:DropDownList ID="vendedorid" runat="server" CssClass="box"></asp:DropDownList>
                                </td>
                                <td>Proyecto:</td>
                                <td>
                                    <asp:DropDownList ID="proyectoid" runat="server" CssClass="box"></asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 5px"></td>
                </tr>
                <tr>
                    <td style="height: 5px">
                        <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" Font-Names="Verdana" Font-Size="Small" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <fieldset>
            <legend style="padding-right: 6px; color: Black"></legend>
            <table width="100%">
                <tr>
                    <td style="height: 5px">&nbsp;</td>
                </tr>
                <tr>
                    <td class="item">
                        <telerik:RadGrid ID="reporteGrid" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" GridLines="None" ShowFooter="true"
                            PageSize="50" ShowStatusBar="True"
                            Skin="Simple" Width="100%">
                            <PagerStyle Mode="NumericPages" />
                            <ExportSettings IgnorePaging="True" FileName="Productos">
                                <Excel Format="Biff" />
                            </ExportSettings>
                            <PagerStyle Mode="NumericPages" />
                            <MasterTableView AllowMultiColumnSorting="False" Name="Productos" Width="100%" NoMasterRecordsText="No existen registros en ese rango de fechas." CommandItemDisplay="Top">
                                <CommandItemSettings ShowRefreshButton="false" ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowExportToPdfButton="false" ExportToPdfText="Exportar a pdf" ExportToExcelText="Exportar a excel"></CommandItemSettings>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="codigo" HeaderText="Código" UniqueName="codigo">
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="descripcion" HeaderText="Descripción" UniqueName="descripcion">
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="cantidad" HeaderText="Cantidad" AllowSorting="true" ItemStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="total" HeaderText="Total" AllowSorting="true" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right">
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
        </fieldset>
    </telerik:RadAjaxPanel>
</asp:Content>
