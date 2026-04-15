<%@ Page Language="vb" MasterPageFile="~/portalcfd/MasterPage_PortalCFD.master" AutoEventWireup="false" CodeBehind="agenda.aspx.vb" Inherits="erp_s7.AgendaPage" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="w-100">
        <div runat="server" id="divAdd" class="w-100">
            <br />
            <asp:Label ID="Label1" runat="server" Text="Ver agenda de:" CssClass="item" Font-Bold="True"></asp:Label><br />
            <asp:DropDownList ID="cmbUsuario" runat="server" Width="40%" AutoPostBack="true" CssClass="mt-8"></asp:DropDownList>
            <br />
        </div>
        <br />
        <asp:Button ID="btnAdd" CssClass="botones" runat="server" Text=" + Agregar"></asp:Button>
    </div>
    <br />
    <div class="w-100">
        <telerik:RadScheduler ID="RadScheduler1" runat="server" Skin="Simple"
            DataKeyField="id"
            DataStartField="fecha_inicio"
            DataEndField="fecha_fin"
            DataSubjectField="titulo"
            Culture="Spanish (Mexico)"
            Height="768px" HoursPanelTimeFormat="htt"
            SelectedView="MonthView"
            ValidationGroup="RadScheduler1" AllowInsert="False" AllowDelete="True" AllowEdit="false" WorkDayEndTime="23:00:00" WorkDayStartTime="14:00:00"
            DisplayRecurrenceActionDialogOnMove="True" EditFormDateFormat="d/M/yyyy" Localization-HeaderToday="Hoy" Localization-HeaderDay="Día"
            Localization-HeaderWeek="Semana" Localization-HeaderMonth="Mes" Localization-HeaderTimeline="Linea Tiempo" CustomAttributeNames="id,tipo_seguimientoid,userid" DataDescriptionField="descripcion">
            <Localization AdvancedAllDayEvent="All day" ConfirmDeleteText="Va a borrar una entrada de la agenda. ¿Desea continuar?" Delete="" />
            <AdvancedForm DateFormat="d/M/yyyy" TimeFormat="h:mm tt" Modal="True" />
            <AppointmentTemplate>
                <div class="calendarItem">
                    <asp:LinkButton ID="lnkDetail" runat="server" Text='<%# Eval("Subject") %>' ToolTip='<%# Eval("Description") %>' CommandName="cmdEdit" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                </div>
            </AppointmentTemplate>
        </telerik:RadScheduler>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    <telerik:RadWindow ID="AddWindow" Behaviors="Close" VisibleOnPageLoad="false" Title="Agregar Actividad en la Agenda" Width="600px" MinHeight="440px" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="agendaid" runat="server" Value="0" />
            <table border="0" style="width: 95%; line-height: 20px;" class="m-10">
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="true" Text="Título:"></asp:Label>
                        &nbsp;<asp:RequiredFieldValidator ID="valTitulo" runat="server" ValidationGroup="gpoSeguimiento" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Requerido" ControlToValidate="txtTitulo" CssClass="item"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txtTitulo" runat="server" Width="90%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblInicio" runat="server" Text="Fecha:" CssClass="item" Font-Bold="True"></asp:Label>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="gpoSeguimiento" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Requerido" ControlToValidate="calFecha" CssClass="item"></asp:RequiredFieldValidator><br />
                        <%--<telerik:RadDateTimePicker ID="calFecha" CultureInfo="Español (México)" DateInput-DateFormat="dd/MM/yyyy hh:mm:ss" runat="server">
                            <Calendar ID="Calendar1" runat="server" EnableKeyboardNavigation="true">
                            </Calendar>
                            <TimeView Interval="00:15:00" StartTime="07:00" EndTime="23:00" runat="server">
                            </TimeView>
                        </telerik:RadDateTimePicker>--%>
                        <telerik:RadDatePicker ID="calFecha" runat="server" CultureInfo="Español (México)"></telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td runat="server" id="tdResponsable">
                        <asp:Label ID="lblTipoSeguimiento" runat="server" Text="Responsable:" CssClass="item" Font-Bold="True"></asp:Label><br />
                        <asp:DropDownList ID="cmbResponsable" runat="server" Width="40%" AutoPostBack="true"></asp:DropDownList>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="gpoSeguimiento" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Requerido" InitialValue="0" ControlToValidate="cmbResponsable" CssClass="item"></asp:RequiredFieldValidator>
                    </td>
                    <%--<td>
                        <asp:Label ID="lblFin" runat="server" Text="Fin:" CssClass="item" Font-Bold="True"></asp:Label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="gpoSeguimiento" ForeColor="Red" SetFocusOnError="true" ErrorMessage="Requerido" ControlToValidate="calFechaFin" CssClass="item"></asp:RequiredFieldValidator><br />
                        <telerik:RadDateTimePicker ID="calFechaFin" CultureInfo="Español (México)" DateInput-DateFormat="dd/MM/yyyy hh:mm:ss" runat="server">
                            <Calendar ID="Calendar2" runat="server" EnableKeyboardNavigation="true">
                            </Calendar>
                            <TimeView Interval="00:15:00" StartTime="07:00" EndTime="23:00" runat="server">
                            </TimeView>
                        </telerik:RadDateTimePicker>
                    </td>--%>
                </tr>
                <tr valign="top">
                    <td colspan="3">
                        <asp:Label ID="lblDescripcionSeguimiento" runat="server" Text="Descripción:" CssClass="item" Font-Bold="True"></asp:Label><br />
                        <telerik:RadTextBox ID="txtDescripcion" TextMode="MultiLine" runat="server" Width="90%" Height="100px">
                        </telerik:RadTextBox>
                    </td>
                </tr>
                <tr valign="top">
                    <td colspan="3">
                        <div id="dmensajefechas" style="display: none; width: 80%;" class="div">
                            <asp:Label ID="lblMensajeFechas" runat="server" CssClass="item" ForeColor="#ffffff" Font-Bold="true" Font-Size="Small"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr style="height: 20px">
                    <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: end;">
                        <asp:Button ID="btnGuardarSeguimiento" runat="server" CausesValidation="true" ValidationGroup="gpoSeguimiento" Text="Guardar" CssClass="item" />&nbsp;
                        <asp:Button ID="btnCancelSeguimiento" runat="server" CausesValidation="false" Text="Cancelar" CssClass="item" />
                        <asp:HiddenField runat="server" ID="responsableid" Value="0" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </telerik:RadWindow>
</asp:Content>
