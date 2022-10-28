
Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class OmicsProject : Inherits WebApp

    Public Sub New(path As String)
        MyBase.New("")

        arguments = New Dictionary(Of String, String)
        arguments("proj") = path
    End Sub
End Class
