Imports System.Data

Public Class AgendaDTO
    Dim Obj As New DataControl
    Public agenda As Agenda
    Private Function String_SQL(ByVal cmd As Integer, ByVal agenda As Agenda) As String
        Dim sql As String = "exec pAgenda @cmd=" & cmd & ", " &
                            "@id='" & agenda.id & "'," &
                            "@usuario_responsableid='" & agenda.usuario_responsableid & "'," &
                            "@usuario_creaid='" & agenda.usuario_creaid & "'," &
                            "@titulo='" & agenda.titulo & "', " &
                            "@fecha='" & Format(agenda.fecha, "yyyy/MM/dd HH:mm:ss") & "', " &
                            "@descripcion='" & agenda.descripcion & "' "

        Return sql
    End Function
    Public Function Save(ByVal agenda As Agenda) As String
        Dim cmd As Integer = 0
        If agenda.id = 0 Then
            cmd = 1
        Else
            cmd = 4
        End If
        Dim result As String
        Try
            result = Obj.RunSQLScalarQueryString(String_SQL(cmd, agenda))
        Catch ex As Exception
            result = ex.Message
        End Try
        Return result
    End Function
    Public Function FindById(ByVal id As Integer) As Agenda
        agenda = New Agenda
        agenda.id = id
        Dim result As New DataSet
        result = Obj.FillDataSet(String_SQL(3, agenda))
        For Each row As DataRow In result.Tables(0).Rows
            agenda.usuario_responsableid = row("usuario_responsableid")
            agenda.usuario_creaid = row("usuario_creaid")
            agenda.titulo = row("titulo")
            agenda.fecha = row("fecha")
            agenda.descripcion = row("descripcion")
            agenda.ultimaModificacion = row("ultimaModificacion")
        Next
        Return agenda
    End Function
    Public Function GetAllItems(Optional ByVal usuario_responsableid As Integer = 0) As DataSet
        Dim result As DataSet
        agenda = New Agenda
        agenda.usuario_responsableid = usuario_responsableid
        result = Obj.FillDataSet(String_SQL(2, agenda))
        Return result
    End Function
    Public Function DeleteById(ByVal id As Integer) As String
        agenda = New Agenda
        agenda.id = id
        Dim result As String
        Try
            result = Obj.RunSQLScalarQueryString(String_SQL(5, agenda))
        Catch ex As Exception
            result = ex.Message
        End Try
        Return result
    End Function
End Class
