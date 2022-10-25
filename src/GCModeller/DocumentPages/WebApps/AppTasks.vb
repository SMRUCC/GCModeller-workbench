

Imports System.Runtime.InteropServices
Imports GCModeller
Imports Microsoft.VisualBasic.MIME.application.json

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class AppTasks : Inherits WebApp

    Public Sub New()
        MyBase.New("/appTask.vbhtml")
    End Sub

    Public Function getTaskList() As String()
        Return TaskManager _
            .LoadTaskList(TaskManager.taskDb) _
            .Select(Function(a) a.GetJson) _
            .ToArray
    End Function

    Public Function checkTaskList() As String()
        Dim updates As New List(Of WebTask)

        For Each task As WebTask In TaskManager.LoadTaskList(TaskManager.taskDb)
            If task.status = "pending" OrElse task.status = "running" Then
                Dim check = $"http://127.0.0.1:{Globals.fastRwebPort}/check_invoke?request_id={task.session_id}".GET
                Dim flag = check.TrimNewLine.Trim.ParseBoolean

                If flag Then
                    task.logtext = $"http://127.0.0.1:{Globals.fastRwebPort}/get_invoke?request_id={task.session_id}".GET
                    task.status = "success"
                    updates.Add(task)
                End If
            End If
        Next

        If updates.Any Then
            Using taskMgr As New TaskManager(TaskManager.taskDb)
                For Each task As WebTask In updates
                    Call taskMgr.update(task.session_id, task)
                Next
            End Using
        End If

        Return updates.Select(Function(a) a.GetJson).ToArray
    End Function
End Class
