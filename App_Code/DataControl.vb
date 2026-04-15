Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Public Class DataControl
    Private p_mensaje As String = ""
    Private p_conexion As String = ""

    Sub New()
        p_conexion = ConfigurationManager.ConnectionStrings("conn").ConnectionString
    End Sub

    ReadOnly Property mensaje() As String
        Get
            Return p_mensaje
        End Get
    End Property

    WriteOnly Property conexion() As String
        Set(ByVal value As String)
            p_conexion = value
        End Set
    End Property

    Public Sub RunSQLQuery(ByVal SQL As String)
        Dim conn As New SqlConnection(p_conexion)
        conn.Open()
        Dim cmd As New SqlCommand(SQL, conn)

        cmd.ExecuteNonQuery()
        conn.Close()
        conn.Dispose()
        conn = Nothing
    End Sub

    Public Function RunFieldsQuery(ByVal SQL As String) As Dictionary(Of String, Object)
        Dim fields As New Dictionary(Of String, Object)
        Dim conn As New SqlConnection(p_conexion)
        conn.Open()
        Dim cmd As New SqlCommand(SQL, conn)
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.Read() Then
            For Each row As DataRow In reader.GetSchemaTable().Rows
                Dim field_id As String = row("ColumnName")
                Dim i As Integer = reader.GetOrdinal(field_id)
                fields(field_id) = reader.GetValue(i)
            Next
        End If
        Return fields
    End Function

    Public Function RunSQLScalarQuery(ByVal SQL As String) As Long
        Dim valor As Long = 0
        Dim conn As New SqlConnection(p_conexion)
        conn.Open()
        Dim cmd As New SqlCommand(SQL, conn)
        valor = cmd.ExecuteScalar
        conn.Close()
        conn.Dispose()
        conn = Nothing
        Return valor
    End Function

    Public Function RunSQLScalarQueryDecimal(ByVal SQL As String) As Decimal
        Dim valor As Decimal = 0
        Dim conn As New SqlConnection(p_conexion)
        conn.Open()
        Dim cmd As New SqlCommand(SQL, conn)
        valor = cmd.ExecuteScalar
        conn.Close()
        conn.Dispose()
        conn = Nothing
        Return valor
    End Function

    Public Function RunSQLScalarQueryString(ByVal SQL As String) As String
        Dim valor As String = ""
        Dim conn As New SqlConnection(p_conexion)
        conn.Open()
        Dim cmd As New SqlCommand(SQL, conn)
        valor = cmd.ExecuteScalar
        conn.Close()
        conn.Dispose()
        conn = Nothing
        Return valor
    End Function

    Public Sub Catalogo(ByVal combo As Web.UI.WebControls.DropDownList, ByVal sql As String, ByVal sel As String, Optional ByVal todo As Boolean = False)
        '
        Dim conn As New SqlConnection(p_conexion)
        conn.Open()
        Dim cmd As New SqlDataAdapter(sql, conn)
        Dim ds As DataSet = New DataSet
        cmd.Fill(ds)
        combo.DataSource = ds
        combo.DataValueField = ds.Tables(0).Columns(0).ColumnName
        combo.DataTextField = ds.Tables(0).Columns(1).ColumnName
        combo.DataBind()
        '
        If todo Then
            combo.Items.Insert(0, New ListItem("--Todos--", "0"))
        Else
            combo.Items.Insert(0, New ListItem("--Seleccione--", "0"))
        End If
        If sel.Length > 0 Then
            combo.SelectedIndex = combo.Items.IndexOf(combo.Items.FindByValue(sel))
        End If
        conn.Close()
        conn.Dispose()
        conn = Nothing
        ''
    End Sub

    'lcng 09 de Enero 2025: ajuste para soportar fill de datos para drop down de telerik
    Public Sub Catalogo(ByVal combo As Telerik.Web.UI.RadDropDownList, ByVal sql As String, ByVal sel As String, Optional ByVal todo As Boolean = False)
        '
        Dim conn As New SqlConnection(p_conexion)
        conn.Open()
        Dim cmd As New SqlDataAdapter(sql, conn)
        Dim ds As DataSet = New DataSet
        cmd.Fill(ds)
        combo.DataSource = ds
        combo.DataValueField = ds.Tables(0).Columns(0).ColumnName
        combo.DataTextField = ds.Tables(0).Columns(1).ColumnName
        combo.DataBind()
        'no implementado sel
        If todo Then
            combo.Items.Insert(0, New Telerik.Web.UI.DropDownListItem("--Todos--", "0"))
        Else
            combo.Items.Insert(0, New Telerik.Web.UI.DropDownListItem("--Seleccione--", "0"))
        End If
        If sel.Length > 0 Then
            If Not combo.FindItemByText(sel) Is Nothing Then
                combo.SelectedIndex = combo.FindItemByText(sel).Index
            End If
        End If
        conn.Close()
        conn.Dispose()
        conn = Nothing
        '
    End Sub

    Public Sub CatalogoStr(ByVal combo As Web.UI.WebControls.DropDownList, ByVal sql As String, ByVal sel As String, Optional ByVal todo As Boolean = False)
        '
        Dim conn As New SqlConnection(p_conexion)
        conn.Open()
        Dim cmd As New SqlDataAdapter(sql, conn)
        Dim ds As DataSet = New DataSet
        cmd.Fill(ds)
        combo.DataSource = ds
        combo.DataValueField = ds.Tables(0).Columns(0).ColumnName
        combo.DataTextField = ds.Tables(0).Columns(1).ColumnName
        combo.DataBind()
        '
        If todo Then
            combo.Items.Insert(0, New ListItem("--Todos--", "0"))
        Else
            combo.Items.Insert(0, New ListItem("--Seleccione--", "0"))
        End If
        If sel.Length > 0 Then
            combo.SelectedIndex = combo.Items.IndexOf(combo.Items.FindByValue(sel))
        End If
        conn.Close()
        conn.Dispose()
        conn = Nothing
        '
    End Sub

    Public Function FillDataSet(ByVal SQL As String) As DataSet
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

    Public Sub Sentence(ByVal _sentence_ As String, ByVal type As Integer, ByVal param As ArrayList)
        Dim conn As New SqlConnection(p_conexion)
        Dim command As New SqlCommand
        Try
            conn.Open()
            command.Connection = conn
            If type = 0 Then
                command.CommandType = CommandType.Text
            Else
                command.CommandType = CommandType.StoredProcedure
            End If
            command.CommandText = _sentence_
            For cont As Integer = 0 To param.Count - 1
                command.Parameters.Add(param(cont))
            Next
            command.ExecuteNonQuery()
            command.Parameters.Clear()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Function SentenceScalarLong(ByVal _sentence_ As String, ByVal type As Integer, ByVal param As ArrayList) As Long
        Dim valor As Long = 0
        Dim conn As New SqlConnection(p_conexion)
        Dim command As New SqlCommand
        Try
            conn.Open()
            command.Connection = conn
            If type = 0 Then
                command.CommandType = CommandType.Text
            Else
                command.CommandType = CommandType.StoredProcedure
            End If
            command.CommandText = _sentence_
            For cont As Integer = 0 To param.Count - 1
                command.Parameters.Add(param(cont))
            Next
            valor = command.ExecuteScalar
            command.Parameters.Clear()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            conn.Close()
        End Try
        Return valor
    End Function
    Public Function ExecProcedure(ByVal _name As String, ByVal type As Integer, ByVal param() As SqlParameter) As String
        Dim valor As String = ""
        Dim conn As New SqlConnection(p_conexion)
        Dim command As New SqlCommand
        Try
            conn.Open()
            command.Connection = conn
            If type = 0 Then
                command.CommandType = CommandType.Text
            Else
                command.CommandType = CommandType.StoredProcedure
            End If
            command.CommandText = _name
            command.Parameters.AddRange(param)
            valor = command.ExecuteScalar()
            command.Parameters.Clear()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            conn.Close()
        End Try
        Return valor
    End Function
End Class