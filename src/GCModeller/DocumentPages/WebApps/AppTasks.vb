

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
End Class
