
Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class DataRepository : Inherits WebApp

    Public Sub New()
        MyBase.New("/repository.vbhtml")
    End Sub
End Class
