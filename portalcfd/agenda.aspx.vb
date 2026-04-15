Imports Telerik.Web.UI

Public Class AgendaPage
    Inherits System.Web.UI.Page
    Public agendaDto As New AgendaDTO
    Public agenda As New Agenda
    Dim ObjCat As New DataControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ObjCat.Catalogo(cmbResponsable, "select id, isnull(nombre,'null') as nombre from tblUsuario where borradobit is null", 0)
            ObjCat.Catalogo(cmbUsuario, "select id, isnull(nombre,'null') as nombre from tblUsuario where borradobit is null", 0, True)
            CargaAgenda()
            aplicaPermisosDeSession()
        End If
    End Sub
    Sub aplicaPermisosDeSession()
        Select Case Session("perfilid")
            ' Ejecutivo de ventas
            Case 3
                divAdd.Visible = False
                responsableid.Value = Session("userid")
                tdResponsable.Visible = False
                ' Cooriandor de Instalaciones
            Case 5
                divAdd.Visible = False
                responsableid.Value = Session("userid")
                tdResponsable.Visible = False
        End Select

    End Sub
    Private Sub CargaAgenda()
        RadScheduler1.DataSource = agendaDto.GetAllItems(cmbUsuario.SelectedValue)
        RadScheduler1.DataBind()
    End Sub
    Private Sub BtnAddClick(sender As Object, e As EventArgs) Handles btnAdd.Click
        PageCleanInputs()
        AddWindow.VisibleOnPageLoad = True
    End Sub
    Private Sub BtnCancelSeguimientoClick(sender As Object, e As EventArgs) Handles btnCancelSeguimiento.Click
        AddWindow.VisibleOnPageLoad = False
    End Sub
    Private Sub RadScheduler1_AppointmentCommand(sender As Object, e As Telerik.Web.UI.AppointmentCommandEventArgs) Handles RadScheduler1.AppointmentCommand
        Select Case e.CommandName
            Case "cmdEdit"
                agenda = agendaDto.FindById(e.CommandArgument)
                PageSet()
                AddWindow.VisibleOnPageLoad = True
        End Select
    End Sub
    Private Sub btnGuardarSeguimiento_Click(sender As Object, e As EventArgs) Handles btnGuardarSeguimiento.Click
        PageGet()
        agendaDto.Save(agenda)
        AddWindow.VisibleOnPageLoad = False
        CargaAgenda()
    End Sub
    Private Sub PageSet()
        agendaid.Value = agenda.id
        txtTitulo.Text = agenda.titulo
        calFecha.SelectedDate = agenda.fecha
        cmbResponsable.SelectedValue = agenda.usuario_responsableid
        responsableid.Value = agenda.usuario_responsableid
        txtDescripcion.Text = agenda.descripcion
        AddWindow.Title = " Editar Actividad en la Agenda"
    End Sub
    Private Sub PageGet()
        agenda.id = agendaid.Value
        agenda.titulo = txtTitulo.Text
        agenda.fecha = calFecha.SelectedDate
        agenda.usuario_responsableid = responsableid.Value
        agenda.descripcion = txtDescripcion.Text
    End Sub
    Private Sub PageCleanInputs()
        AddWindow.Title = "	Agregar Actividad en la Agenda"
        agendaid.Value = 0
        txtTitulo.Text = ""
        calFecha.SelectedDate = Date.Now
        cmbResponsable.SelectedValue = 0
        txtDescripcion.Text = ""
    End Sub
    Private Sub RadScheduler1_AppointmentDelete(sender As Object, e As AppointmentDeleteEventArgs) Handles RadScheduler1.AppointmentDelete
        agendaDto.DeleteById(e.Appointment.ID)
    End Sub

    Private Sub cmbUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsuario.SelectedIndexChanged
        CargaAgenda()
    End Sub

    Private Sub cmbResponsable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbResponsable.SelectedIndexChanged
        responsableid.Value = cmbResponsable.SelectedValue
    End Sub
End Class