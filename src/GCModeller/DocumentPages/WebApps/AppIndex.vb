
Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class AppIndex : Inherits WebApp

    Public Sub New()
        MyBase.New("/applets.vbhtml")
    End Sub

    Protected Sub New(path As String)
        MyBase.New(path)
    End Sub

    Public Sub openDataEmbedding()
        Call WebApp.Open(Of DataEmbedding)()
    End Sub

    Public Sub openEnrichment()
        Call WebApp.Open(Of RunEnrichment)()
    End Sub

    Public Sub openPLAS()
        Call WebApp.Open(Of RunPLAS)()
    End Sub
End Class
