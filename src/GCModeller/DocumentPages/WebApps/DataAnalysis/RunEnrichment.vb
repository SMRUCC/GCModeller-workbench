﻿
Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class RunEnrichment : Inherits WebApp

    Public Sub New()
        MyBase.New("/apps/enrichment.vbhtml")
    End Sub
End Class
