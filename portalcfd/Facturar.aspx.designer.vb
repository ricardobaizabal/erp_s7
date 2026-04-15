'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class Facturar
    
    '''<summary>
    '''Control panelClients.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents panelClients As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control imgPanel1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents imgPanel1 As Global.System.Web.UI.WebControls.Image
    
    '''<summary>
    '''Control lblClientsSelectionLegend.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblClientsSelectionLegend As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control valClienteID.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valClienteID As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control valproyectoid.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valproyectoid As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control cmbCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbCliente As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control cmbSucursal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbSucursal As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control cmbProyecto.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbProyecto As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control valSerieId.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valSerieId As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control valMetodoPago.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valMetodoPago As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control valMoneda.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valMoneda As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control valTipoCambio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valTipoCambio As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control cmbTipoDocumento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbTipoDocumento As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control cmbMetodoPago.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbMetodoPago As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control cmbMoneda.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbMoneda As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control txtTipoCambio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtTipoCambio As Global.Telerik.Web.UI.RadNumericTextBox
    
    '''<summary>
    '''Control txtOrdenCompra.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtOrdenCompra As Global.Telerik.Web.UI.RadTextBox
    
    '''<summary>
    '''Control panelSpecificClient.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents panelSpecificClient As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Image1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Image1 As Global.System.Web.UI.WebControls.Image
    
    '''<summary>
    '''Control lblClientData.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblClientData As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblSocialReason.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblSocialReason As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblContact.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblContact As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblCondiciones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblCondiciones As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblSocialReasonValue.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblSocialReasonValue As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblContactValue.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblContactValue As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control cmbCondiciones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbCondiciones As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control lblContactPhone.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblContactPhone As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblRFC.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblRFC As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblTipoPrecio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblTipoPrecio As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblContactPhoneValue.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblContactPhoneValue As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblRFCValue.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblRFCValue As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblTipoPrecioValue.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblTipoPrecioValue As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblUsoCFDI.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblUsoCFDI As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control RequiredFieldValidator2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents RequiredFieldValidator2 As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control lblFormaPago.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblFormaPago As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control valFormaPago.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valFormaPago As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control cmbUsoCFD.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbUsoCFD As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control cmbFormaPago.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbFormaPago As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control lblObservaciones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblObservaciones As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblNumCtaPago.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblNumCtaPago As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control PanelRelacionados.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents PanelRelacionados As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control lblTipoRelacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblTipoRelacion As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control ValTipoRelecion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ValTipoRelecion As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control tiporelacionid.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tiporelacionid As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control lblUUID.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblUUID As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control cmbUUID.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cmbUUID As Global.System.Web.UI.WebControls.DropDownList
    
    '''<summary>
    '''Control ValFolioFiscal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ValFolioFiscal As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control btnAddUiid.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAddUiid As Global.Telerik.Web.UI.RadButton
    
    '''<summary>
    '''Control tblRelacionados.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tblRelacionados As Global.Telerik.Web.UI.RadGrid
    
    '''<summary>
    '''Control instrucciones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents instrucciones As Global.Telerik.Web.UI.RadTextBox
    
    '''<summary>
    '''Control txtNumCtaPago.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNumCtaPago As Global.Telerik.Web.UI.RadTextBox
    
    '''<summary>
    '''Control chkAduana.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents chkAduana As Global.System.Web.UI.WebControls.CheckBox
    
    '''<summary>
    '''Control panelInformacionAduanera.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents panelInformacionAduanera As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control valNombreAduana.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valNombreAduana As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control nombreaduana.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents nombreaduana As Global.Telerik.Web.UI.RadTextBox
    
    '''<summary>
    '''Control valFechaPedimento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valFechaPedimento As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control fechapedimento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents fechapedimento As Global.Telerik.Web.UI.RadDatePicker
    
    '''<summary>
    '''Control valNumeroPedimento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents valNumeroPedimento As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control numeropedimento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents numeropedimento As Global.Telerik.Web.UI.RadTextBox
    
    '''<summary>
    '''Control panelItemsRegistration.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents panelItemsRegistration As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control productoid.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents productoid As Global.System.Web.UI.WebControls.HiddenField
    
    '''<summary>
    '''Control partidaid.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents partidaid As Global.System.Web.UI.WebControls.HiddenField
    
    '''<summary>
    '''Control Image2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Image2 As Global.System.Web.UI.WebControls.Image
    
    '''<summary>
    '''Control lblClientItems.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblClientItems As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control txtSearchItem.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtSearchItem As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control gridResults.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gridResults As Global.Telerik.Web.UI.RadGrid
    
    '''<summary>
    '''Control btnCancelSearch.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnCancelSearch As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control itemsList.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents itemsList As Global.Telerik.Web.UI.RadGrid
    
    '''<summary>
    '''Control panelDescuento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents panelDescuento As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Image4.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Image4 As Global.System.Web.UI.WebControls.Image
    
    '''<summary>
    '''Control lblDescDescuento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblDescDescuento As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblDescuentoGeneral.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblDescuentoGeneral As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control txtDescuento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtDescuento As Global.Telerik.Web.UI.RadNumericTextBox
    
    '''<summary>
    '''Control btnAplicarDescuento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAplicarDescuento As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control RequiredFieldValidator1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents RequiredFieldValidator1 As Global.System.Web.UI.WebControls.RequiredFieldValidator
    
    '''<summary>
    '''Control panelResume.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents panelResume As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control Image3.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents Image3 As Global.System.Web.UI.WebControls.Image
    
    '''<summary>
    '''Control lblResume.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblResume As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblSubTotal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblSubTotal As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblSubTotalValue.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblSubTotalValue As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblImporteTasaCero.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblImporteTasaCero As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblImporteTasaCeroValue.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblImporteTasaCeroValue As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblDescuento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblDescuento As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblDescuentoValue.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblDescuentoValue As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblIVA.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblIVA As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblIVAValue.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblIVAValue As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control panelRetencion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents panelRetencion As Global.System.Web.UI.WebControls.Panel
    
    '''<summary>
    '''Control lblRet.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblRet As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblRetValue.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblRetValue As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblTotal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblTotal As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control lblTotalValue.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblTotalValue As Global.System.Web.UI.WebControls.Label
    
    '''<summary>
    '''Control btnCreateInvoice.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnCreateInvoice As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control btnCancelInvoice.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnCancelInvoice As Global.System.Web.UI.WebControls.Button
    
    '''<summary>
    '''Control RadWindow1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents RadWindow1 As Global.Telerik.Web.UI.RadWindow
    
    '''<summary>
    '''Control txtErrores.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtErrores As Global.System.Web.UI.WebControls.TextBox
    
    '''<summary>
    '''Control btnAceptar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAceptar As Global.System.Web.UI.WebControls.Button
End Class
