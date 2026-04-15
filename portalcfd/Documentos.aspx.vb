Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Public Class Documentos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call muestraDocumentosTecnicos()
            Call Catalogos()
            gridDocumentosTecnicos.DataBind()
        End If
    End Sub

    Private Sub gridDocumentosTecnicos_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles gridDocumentosTecnicos.ItemCommand
        Select Case e.CommandName

            Case "cmdEdit"
                EditaDocumentoTecnico(e.CommandArgument)

            Case "cmdDelete"
                EliminaDocumentoTecnico(e.CommandArgument)

        End Select
    End Sub

    Private Sub gridDocumentosTecnicos_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles gridDocumentosTecnicos.ItemDataBound
        If TypeOf e.Item Is GridDataItem Then

            Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)

            If e.Item.OwnerTableView.Name = "DocumentosTecnicos" Then

                Dim lnkdel As ImageButton = CType(dataItem("Delete").FindControl("btnDelete"), ImageButton)
                lnkdel.Attributes.Add("onclick", "return confirm ('¿Está seguro que desea borrar este Documento técnico de la base de datos?');")

            End If

        End If
    End Sub

    Private Sub gridDocumentosTecnicos_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles gridDocumentosTecnicos.NeedDataSource
        Call muestraDocumentosTecnicos()
    End Sub

    Private Sub muestraDocumentosTecnicos()
        Dim ds As New DataSet()
        Dim ObjData As New DataControl
        ds = ObjData.FillDataSet("EXEC pDocumentosTecnicos @cmd=2")
        gridDocumentosTecnicos.MasterTableView.NoMasterRecordsText = "No se encontraron registros."
        gridDocumentosTecnicos.DataSource = ds
        ObjData = Nothing
    End Sub

    Private Sub Catalogos()
        Dim ObjData As New DataControl
        ObjData.Catalogo(cmbTipoDocumentoTecnico, "EXEC pDocumentosTecnicos @cmd=1", 0, 0)
        ObjData = Nothing
    End Sub



    Private Sub EditaDocumentoTecnico(ByVal id As Integer)

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)

        Try

            Dim cmd As New SqlCommand("EXEC pDocumentosTecnicos @cmd=3, @pDocumentoId='" & id.ToString & "'", conn)

            conn.Open()

            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read Then
                '
                txtNombre.Text = rs("nombre").ToString
                txtDescripcion.Text = rs("descripcion").ToString
                txtURL.Text = rs("url").ToString
                cmbTipoDocumentoTecnico.SelectedValue = rs("tipoDocumentoTecnicoId")
                '
                panelRegistroDocumentoTecnico.Visible = True
                '
                InsertOrUpdate.Value = 1
                DocumentoTecnicoID.Value = rs("id")

            End If

        Catch ex As Exception
            Response.Write(ex.Message.ToString)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Private Sub EliminaDocumentoTecnico(ByVal id As Integer)

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)

        Try

            Dim cmd As New SqlCommand("EXEC pDocumentosTecnicos @cmd=6, @pDocumentoId='" & id.ToString & "'", conn)

            conn.Open()

            Dim rs As SqlDataReader

            rs = cmd.ExecuteReader()
            rs.Close()

            conn.Close()

            panelRegistroDocumentoTecnico.Visible = False

            Response.Redirect("Documentos.aspx", False)

        Catch ex As Exception
            Response.Write(ex.Message.ToString)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Private Sub btnAgregaDocumentoTecnico_Click(sender As Object, e As EventArgs) Handles btnAgregaDocumentoTecnico.Click
        InsertOrUpdate.Value = 0
        txtNombre.Text = ""
        txtDescripcion.Text = ""
        txtURL.Text = ""
        cmbTipoDocumentoTecnico.SelectedValue = 0
        panelRegistroDocumentoTecnico.Visible = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        InsertOrUpdate.Value = 0
        txtNombre.Text = ""
        txtDescripcion.Text = ""
        txtURL.Text = ""
        cmbTipoDocumentoTecnico.SelectedValue = 0
        panelRegistroDocumentoTecnico.Visible = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim ObjData As New DataControl
        Dim mensaje As String = ""
        Dim ds As DataSet

        If InsertOrUpdate.Value = 0 Then
            ds = ObjData.FillDataSet("EXEC pDocumentosTecnicos @cmd=4, @pNombre='" & txtNombre.Text.ToString & "', @pDescripcion='" & txtDescripcion.Text.ToString & "', @pURL='" & txtURL.Text.ToString & "', @pTipoDocumentoTecnicoId='" & cmbTipoDocumentoTecnico.SelectedValue.ToString & "'")
        Else
            ds = ObjData.FillDataSet("EXEC pDocumentosTecnicos @cmd=5, @pDocumentoId='" & DocumentoTecnicoID.Value.ToString & "', @pNombre='" & txtNombre.Text.ToString & "', @pDescripcion='" & txtDescripcion.Text.ToString & "', @pURL='" & txtURL.Text.ToString & "', @pTipoDocumentoTecnicoId='" & cmbTipoDocumentoTecnico.SelectedValue.ToString & "'")
        End If

        Dim rs As DataRow = ds.Tables(0).Rows(0)
        mensaje = rs("mensaje").ToString

        If mensaje <> "" Or mensaje <> Nothing Then
            valDocumentoTecnico.Text = mensaje.ToString
            valDocumentoTecnico.Visible = True
            ObjData = Nothing

            Exit Sub
        End If

        ObjData = Nothing
        valDocumentoTecnico.Visible = False
        Response.Redirect("Documentos.aspx", False)
    End Sub

    Protected Sub lnkAgregarTipoDocumentoTecnico_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAgregarTipoDocumentoTecnico.Click
        rwAgregarCatalogos.VisibleOnPageLoad = True
    End Sub

    Protected Sub btnAgregarCatalogo_Click(ByVal sender As Object, ByVal e As EventArgs)
        If txtNombreCatalogo.Text = Nothing Or txtNombreCatalogo.Text = "" Then
            lblValidacionNombreCatalogo.Visible = True
            lblValidacionNombreCatalogo.Text = "Requerido"

            rwAgregarCatalogos.VisibleOnPageLoad = True
            Exit Sub
        End If

        Dim mensaje As String = ""
        Dim objdata As New DataControl
        Dim ds As DataSet = objdata.FillDataSet("EXEC pDocumentosTecnicos @cmd=6, @pNombre='" & txtNombreCatalogo.Text.ToString & "'")

        Dim rs As DataRow = ds.Tables(0).Rows(0)
        mensaje = rs("mensaje").ToString

        If mensaje = "" Or mensaje = Nothing Then
            objdata.Catalogo(cmbTipoDocumentoTecnico, "EXEC pDocumentosTecnicos @cmd=1", 0, 0)
        Else
            lblValidacionNombreCatalogo.Text = mensaje.ToString
            lblValidacionNombreCatalogo.Visible = True
            objdata = Nothing

            rwAgregarCatalogos.VisibleOnPageLoad = True
            Exit Sub
        End If

        objdata = Nothing

        txtNombreCatalogo.Text = ""
        lblValidacionNombreCatalogo.Visible = False
        rwAgregarCatalogos.VisibleOnPageLoad = False
    End Sub

    Protected Sub btnRegresarCatalogo_Click(ByVal sender As Object, ByVal e As EventArgs)
        txtNombreCatalogo.Text = ""
        lblValidacionNombreCatalogo.Visible = False

        rwAgregarCatalogos.VisibleOnPageLoad = False
    End Sub

    Protected Sub btnCerrarModalCatalogo_Click(sender As Object, e As EventArgs)
        txtNombreCatalogo.Text = ""
        lblValidacionNombreCatalogo.Visible = False

        rwAgregarCatalogos.VisibleOnPageLoad = False
    End Sub
End Class