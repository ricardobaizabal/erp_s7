
Partial Class portalcfd_usercontrols_portalcfd_Menu_PortalCFD
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If System.Configuration.ConfigurationManager.AppSettings("usuarios") = 1 And Session("admin") = 0 Then
            lblUsuario.Text = "Usuario en sesión: <strong>" & Session("nombre").ToString & "</strong>"
            '
            '   Permisos para el menu
            '
            Select Case Session("perfilid")
                Case 2, 4
                    '   Nómina
                    RadMenu1.Items(1).Visible = False
                    '   Cuentas por cobrar
                    RadMenu1.Items(2).Items(1).Visible = False
                    '   Proveedores
                    RadMenu1.Items(3).Visible = False
                    '   Inventarios
                    RadMenu1.Items(4).Items(1).Visible = False
                    'RadMenu1.Items(4).Items(2).Visible = False
                    'RadMenu1.Items(4).Items(3).Visible = False
                    'RadMenu1.Items(4).Items(4).Visible = False
                    'RadMenu1.Items(4).Items(5).Visible = False
                    'RadMenu1.Items(4).Items(6).Visible = False
                    'RadMenu1.Items(4).Items(7).Visible = False
                    '   Facturación
                    RadMenu1.Items(5).Items(0).Visible = False
                    RadMenu1.Items(5).Items(2).Visible = False
                    RadMenu1.Items(5).Items(3).Visible = False
                    RadMenu1.Items(5).Items(4).Visible = False
                    RadMenu1.Items(5).Items(5).Visible = False
                    '   Reportes
                    'RadMenu1.Items(7).Visible = False
                    ' --- documentos ---
                    RadMenu1.Items(9).Visible = False
                    '   Configuración
                    RadMenu1.Items(10).Visible = False
                Case 3
                    '
                    ' Ejecutivo de ventas
                    '
                    ' --- Inicio ---
                    RadMenu1.Items(0).Visible = True
                    ' --- Agenda ---
                    RadMenu1.Items(1).Visible = True
                    ' --- Nomina ---
                    RadMenu1.Items(2).Visible = False
                    ' --- clientes ---
                    RadMenu1.Items(3).Visible = True
                    RadMenu1.Items(3).Items(0).Visible = False ' catalogo de clientes
                    RadMenu1.Items(3).Items(1).Visible = True ' cotizaciones
                    ' --- proveedores ---
                    RadMenu1.Items(4).Visible = False

                    ' --- inventarios ---
                    RadMenu1.Items(5).Visible = True
                    RadMenu1.Items(5).Items(0).Visible = True ' productos
                    RadMenu1.Items(5).Items(1).Visible = False ' almacenes
                    RadMenu1.Items(5).Items(2).Visible = False ' entradas de almacen
                    RadMenu1.Items(5).Items(3).Visible = False ' ajustes de inventario
                    RadMenu1.Items(5).Items(4).Visible = False ' kardex de producto
                    RadMenu1.Items(5).Items(5).Visible = False ' reporte de abastecimiento
                    RadMenu1.Items(5).Items(6).Visible = False ' reporte de caducidades
                    RadMenu1.Items(5).Items(7).Visible = False ' transferencias
                    RadMenu1.Items(5).Items(8).Visible = False ' reporte de consignaciones

                    ' --- facturacion ---
                    RadMenu1.Items(6).Visible = False
                    ' --- pedidos ---
                    RadMenu1.Items(7).Visible = True
                    ' --- reportes ---
                    RadMenu1.Items(8).Visible = False
                    ' --- documentos ---
                    RadMenu1.Items(9).Visible = False
                    ' --- configuracion ---
                    RadMenu1.Items(10).Visible = False
                Case 5
                    '
                    ' Coordinadoor de Instalaciones
                    '
                    ' --- Inicio ---
                    RadMenu1.Items(0).Visible = True
                    ' --- Agenda ---
                    RadMenu1.Items(1).Visible = True
                    ' --- Nomina ---
                    RadMenu1.Items(2).Visible = False
                    ' --- clientes ---
                    RadMenu1.Items(3).Visible = False
                    RadMenu1.Items(3).Items(0).Visible = False ' catalogo de clientes
                    RadMenu1.Items(3).Items(1).Visible = False ' cuentas por cobrar
                    RadMenu1.Items(3).Items(2).Visible = False ' cotizaciones
                    ' --- proveedores ---
                    RadMenu1.Items(4).Visible = False
                    ' --- inventarios ---
                    RadMenu1.Items(5).Visible = False
                    RadMenu1.Items(5).Items(0).Visible = False ' productos
                    RadMenu1.Items(5).Items(1).Visible = False ' almacenes
                    RadMenu1.Items(5).Items(2).Visible = False ' entradas de almacen
                    RadMenu1.Items(5).Items(3).Visible = False ' ajustes de inventario
                    RadMenu1.Items(5).Items(4).Visible = False ' kardex de producto
                    RadMenu1.Items(5).Items(5).Visible = False ' reporte de abastecimiento
                    RadMenu1.Items(5).Items(6).Visible = False ' reporte de caducidades
                    RadMenu1.Items(5).Items(7).Visible = False ' transferencias
                    RadMenu1.Items(5).Items(8).Visible = False ' reporte de consignaciones
                    ' --- facturacion ---
                    RadMenu1.Items(6).Visible = False
                    ' --- pedidos ---
                    RadMenu1.Items(7).Visible = False
                    ' --- reportes ---
                    RadMenu1.Items(8).Visible = False
                    ' --- documentos ---
                    RadMenu1.Items(9).Visible = False
                    ' --- configuracion ---
                    RadMenu1.Items(10).Visible = False

            End Select
            '
        End If
        '
    End Sub

End Class