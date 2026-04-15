<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" CodeBehind="ordenes_salida.aspx.vb" Inherits="erp_s7.ordenes_salida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        function OnRequestStart(target, arguments) {
            if (arguments.get_eventTarget().indexOf("lnkPDF") > -1) {
                arguments.set_enableAjax(false);
            }
         }

<%--        function confirmCallbackFnGenerarNomina(arg) {
             if (arg) {
                 __doPostBack("<%=cmdpdf.UniqueID %>", "");
                     }
                 }--%>
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <%--<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1" ClientEvents-OnRequestStart="OnRequestStart">--%>
        <fieldset>
            <legend style="padding-right: 6px; color: Black">
                <asp:Label ID="lblOrdenesSalida" Text="Ordenes de Salida" runat="server" Font-Bold="true" CssClass="item"></asp:Label>
            </legend>
            <br />
            <table width="100%">
                <tr>
                    <td style="height: 2px"></td>
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
                            <MasterTableView AllowMultiColumnSorting="False" DataKeyNames="id" Name="Orders" Width="100%"  CommandItemDisplay="Top">
                                <CommandItemSettings ShowRefreshButton="false" ShowExportToExcelButton="true" ShowAddNewRecordButton="false" ShowExportToPdfButton="false" ExportToPdfText="Exportar a pdf" ExportToExcelText="Exportar a excel"></CommandItemSettings>
                                <Columns>
                                    <telerik:GridTemplateColumn AllowFiltering="true" HeaderText="No. Orden"
                                        UniqueName="id">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("pedidoid") & "-" & Eval("id")%>' CommandName="cmdEdit" Text='<%# Eval("id") %>' CausesValidation="false"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </telerik:GridTemplateColumn>
                                    
                                    <telerik:GridBoundColumn DataField="pedidoid" HeaderText="No. Pedido" UniqueName="pedidoid">
                                    </telerik:GridBoundColumn>
                                    
                                    <telerik:GridBoundColumn DataField="cotizacion" HeaderText="Cotizacion" UniqueName="cotizacion">
                                    </telerik:GridBoundColumn>
                                    
                                    <telerik:GridBoundColumn DataField="razonsocial" HeaderText="Cliente" UniqueName="cliente">
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="fecha_salida" HeaderText="Fecha" UniqueName="fecha">
                                    </telerik:GridBoundColumn>

                                    <telerik:GridBoundColumn DataField="estatus_nombre" HeaderText="Estatus" ItemStyle-HorizontalAlign="Center" UniqueName="estatus_nombre">
                                    </telerik:GridBoundColumn>

                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="" UniqueName="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkPDF" runat="server" Text="pdf" CommandArgument='<%# Eval("id") %>' CommandName="cmdPDF"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridTemplateColumn>

                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>
        </fieldset>

        <br />
    <%--</telerik:RadAjaxPanel>--%>
        <telerik:RadWindow ID="RadWindow2" runat="server" Modal="true" CenterIfModal="true" BorderStyle="None" BorderWidth="0px" AutoSize="False" Behaviors="Close" Skin="Bootstrap" VisibleOnPageLoad="False" Width="1024" Height="768">
        </telerik:RadWindow>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Bootstrap" Width="100%">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>
