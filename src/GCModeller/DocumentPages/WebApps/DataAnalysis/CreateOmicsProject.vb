
Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class CreateOmicsProject : Inherits WebApp

    Public Sub New()
        MyBase.New("/toolkit/projects/omics/create.vbhtml")
    End Sub

    Public Sub openSampleEditor()
        Call WebApp.Open(Of EditSampleInfo)()
    End Sub
End Class
