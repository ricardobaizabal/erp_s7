Imports System.ComponentModel
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms
Imports Telerik.Reporting
Imports Telerik.Reporting.Drawing

Partial Public Class formato_pedidos_neogenis
    Inherits Telerik.Reporting.Report
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub formato_cfdi_NeedDataSource(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.NeedDataSource

        Dim pedidoId As Long = Me.ReportParameters("pedidoId").Value
        Dim ds As DataSet = New DataSet
        'Dim ta As New transferenciaRowsTableAdapters.pTransferenciaTableAdapter
        'Dim ta As New pedidoRowsTableAdapters.pPedidosTableAdapter
        'ta.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString
        'Dim ds As pedidoRows.pPedidosDataTable = ta.GetData(13, pedidoId, 0, 0, 0, 0, "")
        Try
            ds = FillDataSet("EXEC pPedidos @cmd=13, @pedidoid='" & pedidoId.ToString & "'")

        Catch ex As Exception
        End Try

        Dim processingReport = CType(sender, Telerik.Reporting.Processing.Report)
        processingReport.DataSource = ds
    End Sub
    Public Function FillDataSet(ByVal SQL As String) As DataSet
        Dim p_conexion As String = ConfigurationManager.ConnectionStrings("conn").ConnectionString
        Dim conn As New SqlConnection(p_conexion)
        conn.Open()
        Dim cmd As New SqlDataAdapter(SQL, conn)
        cmd.SelectCommand.CommandTimeout = 3600
        Dim ds As DataSet = New DataSet
        cmd.Fill(ds)
        conn.Close()
        conn.Dispose()
        conn = Nothing
        Return ds
    End Function
End Class