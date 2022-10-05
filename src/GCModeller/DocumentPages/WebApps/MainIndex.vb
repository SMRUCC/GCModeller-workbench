Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class MainIndex : Inherits WebApp

    Public Sub New()
        MyBase.New("/index.vbhtml")
    End Sub

    Public Sub openApplets()
        Call WebApp.Open(Of AppIndex)()
    End Sub

    Public Sub openDatabaseRepository()
        Call WebApp.Open(Of ImportsUniprot)()
    End Sub

    Public Sub openTaskManager()
        Call WebApp.Open(Of AppTasks)()
    End Sub
End Class
