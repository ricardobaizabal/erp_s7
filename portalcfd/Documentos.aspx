<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" CodeBehind="Documentos.aspx.vb" Inherits="erp_s7.Documentos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function OnRequestStart(target, arguments) {
            console.log(arguments.get_eventTarget());  // Muestra el control que disparó la solicitud

            // Deshabilitar AJAX para los controles relevantes
            if ((arguments.get_eventTarget().indexOf("RadAjaxPanel1") > -1) || (arguments.get_eventTarget().indexOf("RadAjaxLoadingPanel1") > -1)) {
                arguments.set_enableAjax(false);
            }
        }

        function ShowCatalogosWindow() {
            var wnd = $find("<%= rwAgregarCatalogos.ClientID %>");
            wnd.show();
        }

        function rwAgregarCatalogos_Close(sender, args) {
            // Ejecuta postback para llamar el método del backend
            __doPostBack('<%= btnCerrarModalCatalogo.UniqueID %>', '');
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Width="100%" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
    <fieldset>
        <legend style="padding-right:6px; color:Black">
            <asp:Label ID="lblDocumentosTecnicosList" runat="server" Text="Lista de Documentos técnicos" Font-Bold="true" CssClass="item"></asp:Label>
        </legend>
        <table width="100%" border="0">
            <tr>
                <td style="height:2px">&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="gridDocumentosTecnicos" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" GridLines="None" AllowSorting="true"
                        PageSize="15" ShowStatusBar="True" 
                        Skin="Simple" Width="50%">
                        <PagerStyle Mode="NextPrevAndNumeric" />
                        <MasterTableView AllowMultiColumnSorting="true" AllowSorting="true" DataKeyNames="id,url" Name="DocumentosTecnicos" Width="100%">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Nombre" DataField="nombre" SortExpression="nombre" UniqueName="nombre">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdEdit" Text='<%# Eval("nombre") %>' CausesValidation="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="descripcion" HeaderText="Descripción" UniqueName="descripcion">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="tipoDocumentoTecnico" HeaderText="Tipo de Documento técnico" UniqueName="tipoDocumentoTecnico">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" 
                                    HeaderStyle-HorizontalAlign="Center" UniqueName="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="cmdDelete" ImageUrl="~/images/action_delete.gif" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn AllowFiltering="False" 
                                    HeaderStyle-HorizontalAlign="Center" UniqueName="Ver">
                                    <ItemTemplate>
                                                <asp:HyperLink 
                                                    ID="lnkVerURL"
                                                    runat="server"
                                                    Text="Ver"
                                                    NavigateUrl='<%# Eval("url") %>'
                                                    Target="_blank"
                                                    CssClass="item"
                                                    ForeColor="Blue"
                                                    style="float:right;" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="right" />
                                    <ItemStyle HorizontalAlign="right" />
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnAgregaDocumentoTecnico" runat="server" Text="Agrega Documento técnico" CausesValidation="False" CssClass="item" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
    </fieldset>
    <br />
    <asp:Panel ID="panelRegistroDocumentoTecnico" runat="server" Visible="False">
        <fieldset>
            <legend style="padding-right:6px; color:Black">
                <asp:Label ID="lblRegistroDocumentoTecnico" runat="server" Text="Agregar/Editar Documento técnico" Font-Bold="True" CssClass="item"></asp:Label>
            </legend>
            <br />
            <table width="100%" border="0">
                <tr valign="top">
                    <td width="20%">
                        <asp:Label ID="lblNombre" runat="server" CssClass="item" Font-Bold="True" Text="Nombre:"></asp:Label>
                    </td>
                    <td width="25%">
                        <asp:Label ID="lblDescripcion" runat="server" CssClass="item" Font-Bold="True" Text="Descripción:"></asp:Label>
                    </td>
                    <td width="25%">
                        <asp:Label ID="lblUrl" runat="server" CssClass="item" Font-Bold="True" Text="URL:"></asp:Label>
                    </td>
                    <td width="30%">
                        <asp:Label ID="lblTipoDocumentoTecnico" runat="server" CssClass="item" Font-Bold="True" Text="Tipo Documento técnico:"></asp:Label>
                    </td>
                </tr>
                <tr valign="top">
                    <td width="20%">
                        <asp:TextBox ID="txtNombre" CssClass="item" Width="200px" runat="server"></asp:TextBox>
                    </td>
                    <td width="25%">
                        <asp:TextBox ID="txtDescripcion" CssClass="item" Width="200px" runat="server"></asp:TextBox>
                    </td>
                    <td width="25%">
                        <asp:TextBox ID="txtURL" CssClass="item" Width="200px" runat="server"> </asp:TextBox>
                    </td>
                    <td width="30%">
                        <asp:DropDownList ID="cmbTipoDocumentoTecnico" runat="server" Width="100px" CssClass="box"></asp:DropDownList>
                    </td>
                </tr>
                <tr valign="top">
                    <td width="20%">
                        <asp:RequiredFieldValidator ID="ValNombre" runat="server" ControlToValidate="txtNombre" CssClass="item" ForeColor="Red" ErrorMessage=" *" SetFocusOnError="true" ValidationGroup="DocumentoTecnico"></asp:RequiredFieldValidator>
                    </td>
                    <td width="25%">
                        <asp:RequiredFieldValidator ID="valDescripcion" runat="server" ControlToValidate="txtDescripcion" CssClass="item" ForeColor="Red" ErrorMessage=" *" SetFocusOnError="true" ValidationGroup="DocumentoTecnico"></asp:RequiredFieldValidator>
                    </td>
                    <td width="25%">
                        <asp:RequiredFieldValidator ID="valURL" runat="server" ControlToValidate="txtNombre" CssClass="item" ForeColor="Red" ErrorMessage=" *" SetFocusOnError="true" ValidationGroup="DocumentoTecnico"></asp:RequiredFieldValidator>
                    </td>
                    <td width="30%">
                        <asp:LinkButton ID="lnkAgregarTipoDocumentoTecnico" CssClass="item" runat="server" Text="Agregar" ForeColor="Blue" style="float:left; padding-right:10px" CausesValidation="False" Font-Underline="false" OnClientClick = "ShowCatalogosWindow(); return false;"></asp:LinkButton>
                        <asp:RequiredFieldValidator ID="valTipoDocumentoTecnico" runat="server" ControlToValidate="cmbTipoDocumentoTecnico" CssClass="item" ForeColor="Red" ErrorMessage=" *" SetFocusOnError="true" InitialValue="0" ValidationGroup="DocumentoTecnico"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            
            <table width="100%" border="0">
                <tr>
                    <td width="50%">
                        <asp:Label ID="valDocumentoTecnico" runat="server" CssClass="item" ForeColor="Red" Visible="False"></asp:Label>                        
                    </td>
                </tr>
                <tr>
                    <td width="50%">
                        <asp:Button ID="btnGuardar" Text="Guardar" runat="server" CssClass="item" ValidationGroup="DocumentoTecnico" />&nbsp;
                        <asp:Button ID="btnCancelar" CausesValidation="false" Text="Cancelar" runat="server" CssClass="item" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="InsertOrUpdate" runat="server" Value="0" />
                        <asp:HiddenField ID="DocumentoTecnicoID" runat="server" Value="0" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    </telerik:RadAjaxPanel>

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <%--AGREGAR CATALOGOS--%>
            <telerik:RadWindow 
                ID="rwAgregarCatalogos" 
                runat="server" 
                Width="500px" 
                Height="400px"
                Modal="True"
                VisibleOnPageLoad="False"
                Behaviors="Close"
                OnClientClose="rwAgregarCatalogos_Close"
                Title="Agregar al Catalogo"
                CausesValidation="False">

                <ContentTemplate>
                    <div style="padding:15px;">
                        <asp:Label ID="lblCatalogo" runat="server" CssClass="item" Font-Bold="True" Text="Catalogo de Tipos de Documentos" Style="display: inline-block; margin: 0; padding: 0; margin-right:1px;"></asp:Label>                        
                    </div>

                    <div style="padding:15px;">
                        <asp:Label ID="lblCatalogo2" runat="server" CssClass="item" Text="Ingresa la nueva opción:"></asp:Label>                        
                        <telerik:RadTextBox ID="txtNombreCatalogo" runat="server" Width="50%" Height="20px" Style="vertical-align: top; text-align: left;"/>
                        <br />
                        <asp:Label ID="lblValidacionNombreCatalogo" runat="server" CssClass="item" ForeColor="Red" Visible="False"></asp:Label>                        
                    </div>

                    <div style="text-align:center; margin-top:20px;">
                        <asp:Button ID="btnAgregarCatalogo" runat="server" Text="Agregar" CausesValidation="False" CssClass="" OnClick="btnAgregarCatalogo_Click" />
                        <asp:Button ID="btnRegresarCatalogo" runat="server" Text="Regresar" CausesValidation="False" CssClass="" OnClick="btnRegresarCatalogo_Click" />
                    </div>

                    <asp:Button 
                    ID="btnCerrarModalCatalogo" 
                    runat="server" 
                    Style="display:none;" 
                    OnClick="btnCerrarModalCatalogo_Click" />
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>

    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Bootstrap" Width="100%">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>
