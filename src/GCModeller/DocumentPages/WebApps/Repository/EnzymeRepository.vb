
Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class EnzymeRepository : Inherits WebApp

    Public Sub New()
        MyBase.New("/toolkit/enzyme_database.vbhtml")
    End Sub
End Class
