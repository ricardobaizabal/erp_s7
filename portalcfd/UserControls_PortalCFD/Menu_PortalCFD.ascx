<%@ Control Language="VB" AutoEventWireup="false" Inherits="erp_s7.portalcfd_usercontrols_portalcfd_Menu_PortalCFD" CodeBehind="Menu_PortalCFD.ascx.vb" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadMenu ID="RadMenu1" runat="server" Width="100%" Skin="Silk" Style="z-index: 3000">
    <Items>
        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Inicio" NavigateUrl="~/portalcfd/Home.aspx">
        </telerik:RadMenuItem>
        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Agenda" NavigateUrl="~/portalcfd/agenda.aspx">
        </telerik:RadMenuItem>
        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Nómina" NavigateUrl="#">
            <Items>
                <telerik:RadMenuItem Text="Empleados" NavigateUrl="~/portalcfd/Empleados.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Timbrado" NavigateUrl="~/portalcfd/TimbradoNomina.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Catálogos" NavigateUrl="#">
                    <Items>
                        <telerik:RadMenuItem Text="Departamentos" NavigateUrl="~/portalcfd/Departamentos.aspx"></telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="Percepciones" NavigateUrl="~/portalcfd/Percepciones.aspx"></telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="Deducciones" NavigateUrl="~/portalcfd/Deducciones.aspx"></telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Clientes">
            <Items>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Catálogo de Clientes" NavigateUrl="~/portalcfd/administracion/clientes.aspx"></telerik:RadMenuItem>
                <%--<telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Cuentas por Cobrar" NavigateUrl="~/portalcfd/administracion/cuentasporcobrar.aspx"></telerik:RadMenuItem>--%>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Cotizaciones" NavigateUrl="~/portalcfd/administracion/Cotizaciones.aspx"></telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Proveedores">
            <Items>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Catálogo de Proveedores" NavigateUrl="~/portalcfd/proveedores/proveedores.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Ordenes de compra" NavigateUrl="~/portalcfd/proveedores/ordenes_compra.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Direcciones" NavigateUrl="~/portalcfd/proveedores/direccion.aspx"></telerik:RadMenuItem>
                <%--<telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Carga de facturas" NavigateUrl="~/portalcfd/proveedores/cargafactura.aspx"></telerik:RadMenuItem>--%>
                <%--<telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Cuentas por pagar" NavigateUrl="~/portalcfd/proveedores/cuentasporpagar.aspx"></telerik:RadMenuItem>--%>
            </Items>
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Inventario" NavigateUrl="#">
            <Items>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Productos" NavigateUrl="~/portalcfd/almacen/Productos.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Almacenes" NavigateUrl="~/portalcfd/almacen/almacenes.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Entradas de almacen" NavigateUrl="~/portalcfd/almacen/entradas.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Ajustes de inventario" NavigateUrl="~/portalcfd/almacen/ajustes.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Kardex de producto" NavigateUrl="~/portalcfd/almacen/kardex.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Reporte de abastecimiento" NavigateUrl="~/portalcfd/almacen/abastecimiento.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Reporte de caducidades" NavigateUrl="~/portalcfd/almacen/caducidades.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Transferencias" NavigateUrl="~/portalcfd/almacen/transferencias.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Consignaciones" NavigateUrl="~/portalcfd/almacen/consignaciones.aspx"></telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Facturación">
            <Items>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Nueva Factura" NavigateUrl="~/portalcfd/Facturar40.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Facturas Emitidas" NavigateUrl="~/portalcfd/CFD.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Nuevo Complemento de Pagos" NavigateUrl="~/portalcfd/ComplementoDePagos40.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Complementos de Pago Emitidos" NavigateUrl="~/portalcfd/ComplementosEmitidos.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Folios" NavigateUrl="~/portalcfd/folios.aspx" />
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Firma & Certificados" NavigateUrl="~/portalcfd/Configuracion.aspx" />
            </Items>
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Pedidos" NavigateUrl="#">
            <Items>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Ver Pedidos" NavigateUrl="~/portalcfd/pedidos/pedidos.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Ordenes de Salida" NavigateUrl="~/portalcfd/pedidos/ordenes_salida.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Mensajería" NavigateUrl="~/portalcfd/pedidos/mensajeria.aspx"></telerik:RadMenuItem>
            </Items>
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Reportes" NavigateUrl="~/portalcfd/Reportes.aspx">
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Documentos" NavigateUrl="~/portalcfd/Documentos.aspx">
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Configuración">
            <Items>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Datos de la Empresa" NavigateUrl="~/portalcfd/configuracion/Datos.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Ajustes del Sistema" NavigateUrl="~/portalcfd/configuracion/ajustes.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Administración de Usuarios" NavigateUrl="~/portalcfd/usuarios/usuarios.aspx"></telerik:RadMenuItem>
                <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Catálogos Sistema" NavigateUrl="#">
                    <Items>
                        <telerik:RadMenuItem Text="Marcas" NavigateUrl="~/portalcfd/configuracion/Marcas.aspx"></telerik:RadMenuItem>
                        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Colecciones" NavigateUrl="~/portalcfd/almacen/colecciones.aspx"></telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="Productos o Servicios" NavigateUrl="~/portalcfd/configuracion/Claves.aspx"></telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="Unidades de Medida" NavigateUrl="~/portalcfd/configuracion/Unidad.aspx"></telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="Cuentas de Beneficiario" NavigateUrl="~/portalcfd/CuentasBeneficiario.aspx"></telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
                <%--<telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Administración de Perfiles" NavigateUrl="~/portalcfd/usuarios/perfiles.aspx"></telerik:RadMenuItem>--%>
            </Items>
        </telerik:RadMenuItem>

        <telerik:RadMenuItem runat="server" ExpandMode="ClientSide" Text="Salir" NavigateUrl="~/portalcfd/Salir.aspx">
        </telerik:RadMenuItem>
    </Items>
</telerik:RadMenu>
<br />
<br />
<br />
<br />
<div align="right" class="item">
    <asp:Label ID="lblUsuario" runat="server" CssClass="item"></asp:Label>
</div>
