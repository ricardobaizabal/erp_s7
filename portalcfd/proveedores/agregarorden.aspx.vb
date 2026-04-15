Imports System.Data
Imports System.Data.SqlClient
Public Class agregarorden
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call CargaProveedores()
        End If
    End Sub

    Private Sub CargaProveedores()
        Dim ObjData As New DataControl
        ObjData.Catalogo(proveedorid, "select id, razonsocial as nombre from tblMisProveedores order by razonsocial", 0)
        ObjData.Catalogo(cmbCondiciones, "select id, nombre from tblCondiciones order by nombre", 0)
        ObjData.Catalogo(cmbDireccion,
                    " SELECT dr.id, " &
                    "     'Calle ' + calle + ', No. ' + numero_exterior +  " &
                    " Case " &
                    "         when ISNULL(numero_interior, '') = '' then '' " &
                    "         Else ' Int. ' + numero_interior  " &
                    " End + " &
                    "     ', ' + colonia + ', ' + dbo.fn_camelcase(municipio) + ', ' + dbo.fn_camelcase(st.nombre) + ', ' + dbo.fn_camelcase(dr.pais) as nombre " &
                    " FROM " &
                    " tblDireccion dr " &
                    " Left Join tblEstado st ON st.id = dr.estadoid",
                    0
        )
        ObjData.Catalogo(cmbMensajeria, "select id, descripcion as nombre from tblMensajeria order by nombre", -1)
        ObjData.Catalogo(cmbUsuarioSolicita, "select id, nombre from tblUsuario order by nombre", -1)
        ObjData.Catalogo(cmbUsuarioAutoriza, "select id, nombre from tblUsuario order by nombre", -1)

        cmbUsuarioSolicita.SelectedValue = Session("userid")
        cmbUsuarioSolicita.Enabled = False
        cmbUsuarioAutoriza.Enabled = False

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim cmd As New SqlCommand("EXEC pCliente @cmd=5", conn)

        conn.Open()

        Dim rs As SqlDataReader
        rs = cmd.ExecuteReader()

        If rs.Read Then
            ObjData.Catalogo(cmbUsuarioAutoriza, "select id, nombre from tblUsuario order by nombre", rs("usuarioautorizaid"))
            Dim usuarioAutoriza As String = ""
            usuarioAutoriza = IIf(IsDBNull(rs("usuarioautorizaid")), "", rs("usuarioautorizaid"))
            ObjData.Catalogo(cmbUsuarioAutoriza, "select id, nombre from tblUsuario order by nombre", usuarioAutoriza)
        End If
        ObjData = Nothing
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Response.Redirect("~/portalcfd/proveedores/ordenes_compra.aspx")
    End Sub

    Private Sub btnAddorder_Click(sender As Object, e As System.EventArgs) Handles btnAddorder.Click
        If Page.IsValid Then

            Dim ordenId As Long = 0
            Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)

            Try
                Dim cmd As New SqlCommand("exec pOrdenCompra @cmd=2, @userid='" & Session("userid").ToString & "', @proveedorid = '" & proveedorid.SelectedValue & " '," & "@shipvia = '" & txtShipVia.Text & "'," & "@comentarios = '" & txtComentarios.Text & "'," & "@direccionid = '" & cmbDireccion.SelectedValue & "'," & "@phone = '" & txtOCTelefono.Text & "'," & "@email = '" & txtOCEmail.Text & "'," & "@condicionesid = '" & cmbCondiciones.SelectedValue & "', @fob = '" & txtOCFob.Text & "', @mensajeriaid = '" & cmbMensajeria.SelectedValue.ToString & "', " & "@fleteprepagado = '" & rdFletePrepagado.SelectedIndex & "', " & "@usuarioautoriza = '" & cmbUsuarioAutoriza.SelectedValue & "', " & "@proyectonombre = '" & txtProyectoNombre.Text & "', " & "@proyectolugar = '" & txtProyectoLugar.Text & "'", conn)
                conn.Open()

                Dim rs As SqlDataReader
                rs = cmd.ExecuteReader()

                If rs.Read Then
                    ordenId = rs("ordenId")
                End If

            Catch ex As Exception
            Finally
                conn.Close()
                conn.Dispose()
                conn = Nothing
            End Try

            Response.Redirect("~/portalcfd/proveedores/editarorden.aspx?id=" & ordenId.ToString)

        End If
    End Sub

End Class