

Imports System.Runtime.InteropServices
Imports GCModeller

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class AppTasks : Inherits WebApp

    Public Sub New()
        MyBase.New("/appTask.vbhtml")
    End Sub

    Public Function getTaskList() As WebTask()
        Return TaskManager.LoadTaskList(TaskManager.taskDb).ToArray
    End Function
End Class
