Imports System.Data.SqlClient
Imports System.IO
Imports Telerik.Reporting.Processing

Public Class ordenes_salida
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call MuestraOrdenes()
        End If
    End Sub

    Private Sub MuestraOrdenes()
        Dim ObjData As New DataControl
        ordersList.DataSource = ObjData.FillDataSet("exec pOrdenSalida @cmd=1")
        ordersList.DataBind()
        ObjData = Nothing
    End Sub

    Private Sub ordersList_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles ordersList.ItemCommand
        Select Case e.CommandName
            Case "cmdEdit"
                Dim args As String() = e.CommandArgument.ToString().Split("-")
                Dim pedidoid As String = args(0)
                Dim salidaid As String = args(1)
                Response.Redirect("~/portalcfd/pedidos/OrdenSalida.aspx?pedidoid=" & pedidoid & "&salida=" & salidaid & "&modo=editar")
            Case "cmdPDF"
                'RadWindow1.VisibleOnPageLoad = False
                Return
                Call DownloadPDF(e.CommandArgument)
        End Select
    End Sub

    Private Sub ordersList_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles ordersList.ItemDataBound
        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem
                Dim btnDelete As ImageButton = CType(e.Item.FindControl("btnDelete"), ImageButton)
                Dim lnkRecibir As LinkButton = CType(e.Item.FindControl("lnkRecibir"), LinkButton)
                Dim lnkPDF As LinkButton = CType(e.Item.FindControl("lnkPDF"), LinkButton)
                'btnDelete.Attributes.Add("onclick", "javascript:return confirm('Va a borrar una orden de compra. ¿Desea continuar?');")
                'btnDelete.Enabled = False
                'lnkRecibir.Visible = False

                'If e.Item.DataItem("estatusid") = 1 Then
                '    btnDelete.Enabled = True
                'Else
                '    btnDelete.ToolTip = "Operación no permitida"
                'End If
                'If e.Item.DataItem("estatusid") = 2 Then
                '    lnkRecibir.Visible = True
                'End If
                'If e.Item.DataItem("estatusid") = 3 Or e.Item.DataItem("estatusid") = 4 Then
                '    btnDelete.Visible = False
                'End If
        End Select
    End Sub

    Private Sub ordersList_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles ordersList.NeedDataSource
        Dim ObjData As New DataControl
        ordersList.DataSource = ObjData.FillDataSet("exec pOrdenSalida @cmd=1")
        ObjData = Nothing
    End Sub

    'pending
    Private Sub DownloadPDF(ByVal cfdid As Long)
        Dim connF As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim cmdF As New SqlCommand("pOrdenCompra @cmd=7, @ordenId='" & cfdid.ToString & "'", connF)

        Dim FilePath = Server.MapPath("~/portalcfd/pdf/") & "os_" & cfdid.ToString & ".pdf"

        If File.Exists(FilePath) Then
            'If False Then
            Dim FileName As String = Path.GetFileName(FilePath)
            Response.Clear()
            Response.ContentType = "application/octet-stream"
            Response.AddHeader("Content-Disposition", "attachment; filename=""" & FileName & """")
            Response.Flush()
            Response.WriteFile(FilePath)
            Response.End()
        Else
            'If serie.ToString = "R" Then
            '    GuardaPDF(GeneraPDF_Documento(cfdid), FilePath)
            'Else
            GuardaPDF(GeneraPDF(cfdid), FilePath)
            'End If


            Dim FileName As String = Path.GetFileName(FilePath)
            Response.Clear()
            Response.ContentType = "application/octet-stream"
            Response.AddHeader("Content-Disposition", "attachment; filename=""" & FileName & """")
            Response.Flush()
            Response.WriteFile(FilePath)
            Response.End()
        End If
        ''
    End Sub

    Private Sub GuardaPDF(ByVal report As Telerik.Reporting.Report, ByVal fileName As String)
        Dim reportProcessor As New Telerik.Reporting.Processing.ReportProcessor()
        Dim result As RenderingResult = reportProcessor.RenderReport("PDF", report, Nothing)
        Using fs As New FileStream(fileName, FileMode.Create)
            fs.Write(result.DocumentBytes, 0, result.DocumentBytes.Length)
        End Using
    End Sub

    Public Function GeneraPDF(ByVal cfdid As Long) As Telerik.Reporting.Report
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString)
        Dim plantillaid As Integer = 1
        Dim clave As String = ""
        Dim fecha As String = ""
        Dim contacto As String = ""
        Dim razonsocial As String = ""
        Dim provdireccion As String = ""
        Dim provtelefono As String = ""
        Dim provemail As String = ""
        Dim solicita As String = ""
        Dim ocdireccion As String = ""
        Dim octelefono As String = ""
        Dim ocemail As String = ""
        Dim occondiciones As String = ""
        Dim ocshipvia As String = ""
        Dim ocfob As String = ""
        Dim dtConceptos As DataTable = Nothing

        Try
            ' Verificar si hay registros asociados al cfdid
            Dim checkCmd As New SqlCommand("pOrdenCompra @cmd=3, @ordenId='" & cfdid.ToString & "'", conn)
            conn.Open()
            Dim checkReader As SqlDataReader = checkCmd.ExecuteReader()

            If Not checkReader.HasRows Then
                ' Si no hay registros, simplemente retornar Nothing
                Return Nothing
            End If
            checkReader.Close()

            ' Obtener el plantillaid
            Dim cmd As New SqlCommand("pOrdenCompra @cmd=13, @ordenId='" & cfdid.ToString & "'", conn)
            Dim rs As SqlDataReader = cmd.ExecuteReader()

            If rs.Read() Then
                'plantillaid = rs("plantillaid")
                clave = rs("clave")
                fecha = rs("fecha")
                contacto = rs("para")
                razonsocial = rs("razonsocial")
                provdireccion = rs("prdireccion")
                provtelefono = rs("prtelefono")
                provemail = rs("premail")
                solicita = rs("solicita")
                ocdireccion = rs("ocdireccion")
                octelefono = rs("octelefono")
                ocemail = rs("ocemail")
                occondiciones = rs("condiciones")
                ocshipvia = rs("embarquevia")
                ocfob = rs("FOB")
            End If
            rs.Close()

            'obtener conceptos
            'Dim cmdConceptos As New SqlCommand("")
            Dim ctrConceptos As New DataControl
            dtConceptos = ctrConceptos.FillDataSet("pOrdenCompra @cmd=7, @ordenId='" & cfdid.ToString & "'").Tables(0)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            conn.Close()
            conn.Dispose()
        End Try

        ' Crear y retornar el reporte si hay registros
        Dim reporte As New FormatoOrdenCompra
        reporte.DataSource = dtConceptos
        'reporte.ReportParameters("plantillaId").Value = plantillaid
        reporte.ReportParameters("pIdOrdenCompra").Value = cfdid
        reporte.ReportParameters("txtOrdenId").Value = cfdid.ToString
        reporte.ReportParameters("txtfechaOrden").Value = fecha
        reporte.ReportParameters("txtContacto").Value = contacto
        reporte.ReportParameters("txtRazonSocial").Value = razonsocial
        reporte.ReportParameters("txtProvDireccion").Value = provdireccion
        reporte.ReportParameters("txtProvTelefono").Value = provtelefono
        reporte.ReportParameters("txtProvEmail").Value = provemail
        reporte.ReportParameters("txtSolicita").Value = solicita
        reporte.ReportParameters("txtOCDireccion").Value = ocdireccion
        reporte.ReportParameters("txtOCTelefono").Value = octelefono
        reporte.ReportParameters("txtOCEmail").Value = ocemail
        reporte.ReportParameters("txtOCCondiciones").Value = occondiciones
        reporte.ReportParameters("txtOCShipvia").Value = ocshipvia
        reporte.ReportParameters("txtOCFOB").Value = ocfob
        reporte.ReportParameters("paramImgBanner").Value = Server.MapPath("~/portalcfd/logos/" & "grupo-trina-logo.jpg")

        Return reporte
    End Function
    Private Function Num2Text(ByVal value As Decimal) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function




    Private Sub EliminaOrden(ByVal ordenid As Long)
        Dim ObjData As New DataControl
        ObjData.RunSQLQuery("exec pOrdenCompra @cmd=4, @ordenid='" & ordenid.ToString & "'")
        ObjData = Nothing
    End Sub

End Class