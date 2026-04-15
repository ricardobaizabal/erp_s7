<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" CodeBehind="ReporteFoliosSalida.aspx.vb" Inherits="erp_s7.ReporteFoliosSalida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        
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
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <fieldset style="border-color: #cccccc; width: 98%; border-width: 0px; border-style: solid; padding: 10px;">
            <legend title="Pedidos." class="item"><strong>Mis Pedidos</strong></legend>
            <table id="tblIntMainContent2" border="0" width="100%" cellpadding="0" cellspacing="0">
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
                            <span class="item">Cliente:
                            <asp:DropDownList ID="filtroclienteid" runat="server" Width="250px" CssClass="box"></asp:DropDownList>&nbsp;&nbsp;&nbsp;Estatus:
                            <asp:DropDownList ID="filtroestatusid" runat="server" CssClass="box"></asp:DropDownList>&nbsp;&nbsp;&nbsp;Folio:
                            <asp:TextBox ID="txtFolio" runat="server" Width="120px" CssClass="box"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnFolio" runat="server" CssClass="boton" Text="Buscar" />&nbsp;&nbsp;&nbsp;Palabra clave:
                            <asp:TextBox ID="txtSearch" runat="server" Width="120px" CssClass="box"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnSearch" runat="server" CssClass="boton" Text="Buscar" />&nbsp;&nbsp;&nbsp;
                            </span>
                            <br />
                            <br />
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" style="vertical-align: top;">
                        <telerik:RadGrid ID="pedidosList" runat="server" AllowPaging="True" PageSize="50" AllowSorting="True" 
                            AutoGenerateColumns="False" CellSpacing="0" Skin="Simple" Width="100%"  AllowMultiRowSelection="true" ExportSettings-ExportOnlyData="False">
                            <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True" >
                            </ClientSettings>
                            <ExportSettings IgnorePaging="True" FileName="ReportePedidosFolios">
                                    <Excel Format="Biff" />
                                </ExportSettings>
                                <PagerStyle Mode="NumericPages" />
                            <MasterTableView DataKeyNames="id, cliente, fecha_alta, estatusid, estatus, timbrado" ShowHeadersWhenNoRecords="true" NoMasterRecordsText="No hay registros para mostrar." CommandItemDisplay="Top">
                                <CommandItemSettings ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowExportToPdfButton="false" ExportToPdfText="Exportar a pdf" ExportToExcelText="Exportar a excel"></CommandItemSettings>
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn DataField="id" HeaderText="No. Pedido" UniqueName="id" HeaderStyle-Font-Size="Small">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="id" HeaderText="F. Salida" UniqueName="folio" HeaderStyle-Font-Size="Small">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="cliente" HeaderText="Cliente" UniqueName="cliente" HeaderStyle-Font-Size="Small">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ejecutivo" HeaderText="Ejecutivo" UniqueName="ejecutivo" HeaderStyle-Font-Size="Small">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="fecha_alta" HeaderText="Fecha alta" UniqueName="fecha_alta">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="estatus" HeaderText="Estatus" UniqueName="estatus">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="factura" HeaderText="Factura" UniqueName="factura">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="guia" HeaderText="No. Guía" UniqueName="guia">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="orden_compra" HeaderText="Orden Compra" UniqueName="orden_compra">
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
                        <br />
                    </td>
                </tr>
            </table>
        </fieldset>
    </telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Bootstrap" Width="100%">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>
