Imports System.Runtime.InteropServices

''' <summary>
''' different analysis molecules
''' </summary>
<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class RunDAM : Inherits WebApp

    Public Sub New()
        MyBase.New("/apps/dam.vbhtml")
    End Sub
End Class
