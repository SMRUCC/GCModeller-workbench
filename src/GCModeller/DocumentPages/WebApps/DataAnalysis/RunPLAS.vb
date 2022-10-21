
Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class RunPLAS : Inherits WebApp

    Public Sub New()
        MyBase.New("/apps/plas.vbhtml")
    End Sub
End Class
