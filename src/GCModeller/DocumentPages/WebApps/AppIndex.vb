﻿
Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class AppIndex : Inherits WebApp

    Public Sub New()
        MyBase.New("/applets.vbhtml")
    End Sub

    Public Sub openDataEmbedding()
        Call WebApp.Open(Of DataEmbedding)()
    End Sub
End Class