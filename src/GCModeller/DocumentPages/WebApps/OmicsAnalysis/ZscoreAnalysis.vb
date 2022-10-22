Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class ZscoreAnalysis : Inherits WebApp

    Public Sub New()
        MyBase.New("/apps/z_score.vbhtml")
    End Sub
End Class
