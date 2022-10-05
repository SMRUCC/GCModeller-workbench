

Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class AppTasks : Inherits WebApp

    Public Sub New()
        MyBase.New("/appTask.vbhtml")
    End Sub
End Class
