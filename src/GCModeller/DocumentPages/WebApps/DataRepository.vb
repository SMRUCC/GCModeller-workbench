
Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class DataRepository : Inherits WebApp

    Public Sub New()
        MyBase.New("/repository.vbhtml")
    End Sub

    Public Sub openEnrichmentRepository()
        Call WebApp.Open(Of EnrichmentDatabase)()
    End Sub

    Public Sub openEnzymeRepository()
        Call WebApp.Open(Of EnzymeRepository)()
    End Sub
End Class
