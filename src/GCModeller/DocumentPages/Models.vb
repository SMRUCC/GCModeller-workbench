Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Text

Public Class JSONContent : Inherits StringContent

    Public Sub New(json As String)
        MyBase.New(json, Encodings.UTF8WithoutBOM.CodePage, "application/json")
    End Sub
End Class

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class Message

    Public Property result As Boolean
    Public Property data As String

End Class