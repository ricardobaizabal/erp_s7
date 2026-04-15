Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class direccion
    Inherits System.Web.UI.Page

#Region "Load Initial Values"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''''''''''''''
        'Window Title'
        ''''''''''''''

        Me.Title = Resources.Resource.WindowsTitle

        If Not IsPostBack Then

            '''''''''''''''''''
            'Fieldsets Legends'
            '''''''''''''''''''

            lblDireccionListLegend.Text = "Listado de Direcciones"
            lblClientEditLegend.Text = "Agregar/Editar Dirección"

            '''''''''''''''''''''''''''''''''
            'Combobox Values & Empty Message'
            '''''''''''''''''''''''''''''''''

            Dim TelerikRadComboBox As New FillRadComboBox
            TelerikRadComboBox.FillRadComboBox(cmbStates, "EXEC pCatalogos @cmd=1")

            cmbStates.Text = Resources.Resource.cmbEmptyMessage

            ''''''''''''''
            'Label Titles'
            ''''''''''''''

            lblStreet.Text = Resources.Resource.lblStreet
            lblExtNumber.Text = Resources.Resource.lblExtNumber
            lblIntNumber.Text = Resources.Resource.lblIntNumber
            lblColony.Text = Resources.Resource.lblColony
            lblCountry.Text = Resources.Resource.lblCountry
            lblState.Text = Resources.Resource.lblState
            lblTownship.Text = Resources.Resource.lblTownship
            lblContact.Text = Resources.Resource.lblContact
            lblEmail.Text = Resources.Resource.lblContactEmail
            lblPhone.Text = Resources.Resource.lblContactPhone
            lblZipCode.Text = Resources.Resource.lblZipCode

            '''''''''''''''''''
            'Validators Titles'
            '''''''''''''''''''

            RequiredFieldValidator2.Text = Resources.Resource.validatorMessage
            RequiredFieldValidator3.Text = Resources.Resource.validatorMessage
            RequiredFieldValidator4.Text = Resources.Resource.validatorMessage
            RequiredFieldValidator5.Text = Resources.Resource.validatorMessage
            RequiredFieldValidator6.Text = Resources.Resource.validatorMessage
            RequiredFieldValidator8.Text = Resources.Resource.validatorMessage
            RequiredFieldValidator9.Text = Resources.Resource.validatorMessage

            ''''''''''''''''
            'Buttons Titles'
            ''''''''''''''''

            btnAddAddress.Text = "Agregar Dirección"
            btnSaveClient.Text = Resources.Resource.btnSave
            btnCancel.Text = Resources.Resource.btnCancel

        End If

    End Sub

#End Region

#Region "Load List Of Addresses"

    Function GetAddresses() As DataSet

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim cmd As New SqlDataAdapter("EXEC pDireccion  @cmd=1", conn)

        Dim ds As DataSet = New DataSet

        Try

            conn.Open()

            cmd.Fill(ds)

            conn.Close()
            conn.Dispose()

        Catch ex As Exception


        Finally

            conn.Close()
            conn.Dispose()

        End Try

        Return ds

    End Function

#End Region

#Region "Telerik Grid Providers Loading Events"

    Protected Sub addresseslist_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles addresseslist.NeedDataSource

        If Not e.IsFromDetailTable Then

            addresseslist.MasterTableView.NoMasterRecordsText = Resources.Resource.ClientsEmptyGridMessage
            addresseslist.DataSource = GetAddresses()

        End If

    End Sub

#End Region

#Region "Telerik Grid Language Modification(Spanish)"

    Protected Sub clientslist_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles addresseslist.Init

        addresseslist.PagerStyle.NextPagesToolTip = "Ver mas"
        addresseslist.PagerStyle.NextPageToolTip = "Siguiente"
        addresseslist.PagerStyle.PrevPagesToolTip = "Ver más"
        addresseslist.PagerStyle.PrevPageToolTip = "Atrás"
        addresseslist.PagerStyle.LastPageToolTip = "Última Página"
        addresseslist.PagerStyle.FirstPageToolTip = "Primera Página"
        addresseslist.PagerStyle.PagerTextFormat = "{4}    Página {0} de {1}, Registros {2} al {3} de {5}"
        addresseslist.SortingSettings.SortToolTip = "Ordernar"
        addresseslist.SortingSettings.SortedAscToolTip = "Ordenar Asc"
        addresseslist.SortingSettings.SortedDescToolTip = "Ordenar Desc"


        Dim menu As Telerik.Web.UI.GridFilterMenu = addresseslist.FilterMenu
        Dim i As Integer = 0

        While i < menu.Items.Count

            If menu.Items(i).Text = "NoFilter" Or menu.Items(i).Text = "Contains" Then
                i = i + 1
            Else
                menu.Items.RemoveAt(i)
            End If

        End While

        Call ModificaIdiomaGrid()

    End Sub

    Private Sub ModificaIdiomaGrid()

        addresseslist.GroupingSettings.CaseSensitive = False

        Dim Menu As Telerik.Web.UI.GridFilterMenu = addresseslist.FilterMenu
        Dim item As Telerik.Web.UI.RadMenuItem

        For Each item In Menu.Items

            ''''''''''''''''''''''''''''''''''''''''''''''
            'Change The Text For The StartsWith Menu Item'
            ''''''''''''''''''''''''''''''''''''''''''''''

            If item.Text = "StartsWith" Then
                item.Text = "Empieza con"
            End If

            If item.Text = "NoFilter" Then
                item.Text = "Sin Filtro"
            End If

            If item.Text = "Contains" Then
                item.Text = "Contiene"
            End If

            If item.Text = "EndsWith" Then
                item.Text = "Termina con"
            End If

        Next

    End Sub

#End Region

#Region "Telerik Grid Providers Editing & Deleting Events"

    Protected Sub addresseslist_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles addresseslist.ItemDataBound

        If TypeOf e.Item Is GridDataItem Then

            Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)

            If e.Item.OwnerTableView.Name = "Providers" Then

                Dim lnkdel As ImageButton = CType(dataItem("Delete").FindControl("btnDelete"), ImageButton)
                lnkdel.Attributes.Add("onclick", "return confirm ('" & Resources.Resource.ProviderDeleteConfirmationMessage & "');")

            End If

        End If

    End Sub

    Protected Sub addresseslist_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles addresseslist.ItemCommand

        Select Case e.CommandName

            Case "cmdEdit"
                EditAddress(e.CommandArgument)

            Case "cmdDelete"
                DeleteAddress(e.CommandArgument)

        End Select

    End Sub

    Private Sub DeleteAddress(ByVal id As Integer)

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)

        Try

            Dim cmd As New SqlCommand("EXEC pDireccion @cmd='3', @id ='" & id.ToString & "'", conn)

            conn.Open()

            Dim rs As SqlDataReader

            rs = cmd.ExecuteReader()
            rs.Close()

            conn.Close()

            panelClientRegistration.Visible = False

            addresseslist.DataSource = GetAddresses()
            addresseslist.DataBind()

        Catch ex As Exception


        Finally

            conn.Close()
            conn.Dispose()

        End Try

    End Sub

    Private Sub EditAddress(ByVal id As Integer)

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)

        Try

            Dim cmd As New SqlCommand("EXEC pDireccion @cmd='2', @id='" & id & "'", conn)

            conn.Open()

            Dim rs As SqlDataReader
            rs = cmd.ExecuteReader()

            If rs.Read Then
                txtDescripcion.Text = rs("descripcion")
                txtStreet.Text = rs("calle")
                txtExtNumber.Text = rs("numero_exterior")
                txtIntNumber.Text = rs("numero_interior")
                txtColony.Text = rs("colonia")
                txtCountry.Text = rs("pais")
                cmbStates.SelectedValue = rs("estadoid")
                txtTownship.Text = rs("municipio")
                txtZipCode.Text = rs("codigo_postal")
                txtPhone.Text = rs("telefono")
                txtContact.Text = rs("contacto")
                txtEmail.Text = rs("correo")

                panelClientRegistration.Visible = True

                InsertOrUpdate.Value = 1
                ClientsID.Value = id

            End If

        Catch ex As Exception


        Finally

            conn.Close()
            conn.Dispose()

        End Try

    End Sub

#End Region

#Region "Telerik Grid Addresses Column Names (From Resource File)"

    Protected Sub addresseslist_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles addresseslist.ItemCreated

        If TypeOf e.Item Is GridHeaderItem Then

            Dim header As GridHeaderItem = CType(e.Item, GridHeaderItem)

            'If e.Item.OwnerTableView.Name = "Addresses" Then

            '    header("razonsocial").Text = Resources.Resource.gridColumnNameSocialReason
            '    header("contacto").Text = Resources.Resource.gridColumnNameContact
            '    header("telefono_contacto").Text = Resources.Resource.gridColumnNameContactPhone
            '    header("rfc").Text = Resources.Resource.gridColumnNameRFC

            'End If

        End If

    End Sub

#End Region

#Region "Display Provider Data Panel"

    Protected Sub btnAddAddress_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddAddress.Click

        InsertOrUpdate.Value = 0

        txtStreet.Text = ""
        txtExtNumber.Text = ""
        txtIntNumber.Text = ""
        txtColony.Text = ""
        txtCountry.Text = ""
        txtTownship.Text = ""
        txtZipCode.Text = ""

        Dim TelerikRadComboBox As New FillRadComboBox
        TelerikRadComboBox.FillRadComboBox(cmbStates, "EXEC pCatalogos @cmd=1")

        cmbStates.Text = Resources.Resource.cmbEmptyMessage

        panelClientRegistration.Visible = True

    End Sub

#End Region

#Region "Save Provider"

    Protected Sub btnSaveClient_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveClient.Click

        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)

        Try

            If InsertOrUpdate.Value = 0 Then

                Dim cmd As New SqlCommand("EXEC pDireccion @cmd=4, @descripcion='" & txtDescripcion.Text & "', @calle='" & txtStreet.Text & "', @numero_interior='" & txtIntNumber.Text & "', @numero_exterior='" & txtExtNumber.Text & "', @colonia='" & txtColony.Text & "', @pais='" & txtCountry.Text & "', @municipio='" & txtTownship.Text & "', @estadoid='" & cmbStates.SelectedValue & "', @telefono='" & txtPhone.Text & "', @contacto='" & txtContact.Text & "', @correo='" & txtEmail.Text & "', @codigo_postal='" & txtZipCode.Text & "'", conn)

                conn.Open()

                cmd.ExecuteReader()

                panelClientRegistration.Visible = False

                addresseslist.MasterTableView.NoMasterRecordsText = Resources.Resource.ClientsEmptyGridMessage
                addresseslist.DataSource = GetAddresses()
                addresseslist.DataBind()

                conn.Close()
                conn.Dispose()

            Else

                Dim cmd As New SqlCommand("EXEC pDireccion @cmd=5, @id='" & ClientsID.Value & "',@descripcion='" & txtDescripcion.Text & "', @calle='" & txtStreet.Text & "', @numero_interior='" & txtIntNumber.Text & "', @numero_exterior='" & txtExtNumber.Text & "', @colonia='" & txtColony.Text & "', @pais='" & txtCountry.Text & "', @municipio='" & txtTownship.Text & "', @estadoid='" & cmbStates.SelectedValue & "', @telefono='" & txtPhone.Text & "', @contacto='" & txtContact.Text & "', @correo='" & txtEmail.Text & "', @codigo_postal='" & txtZipCode.Text & "'", conn)

                conn.Open()

                cmd.ExecuteReader()

                panelClientRegistration.Visible = False

                addresseslist.MasterTableView.NoMasterRecordsText = Resources.Resource.ClientsEmptyGridMessage
                addresseslist.DataSource = GetAddresses()
                addresseslist.DataBind()

                conn.Close()
                conn.Dispose()

            End If

        Catch ex As Exception


        Finally

            conn.Close()
            conn.Dispose()

        End Try

    End Sub

#End Region

#Region "Cancel Provider (Save/Edit)"

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        InsertOrUpdate.Value = 0

        txtStreet.Text = ""
        txtExtNumber.Text = ""
        txtIntNumber.Text = ""
        txtColony.Text = ""
        txtCountry.Text = ""
        txtTownship.Text = ""
        txtZipCode.Text = ""

        Dim TelerikRadComboBox As New FillRadComboBox
        TelerikRadComboBox.FillRadComboBox(cmbStates, "EXEC pCatalogos @cmd=1")

        cmbStates.Text = Resources.Resource.cmbEmptyMessage

        panelClientRegistration.Visible = False

    End Sub

#End Region

End Class