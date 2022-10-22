Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.ApplicationServices.Debugging.Diagnostics

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class WebTask

    Public Property appName As String
    Public Property time As String
    Public Property title As String
    Public Property status As String
    Public Property session_id As String
    Public Property arguments As Dictionary(Of String, String)
    Public Property [error] As ExceptionData

End Class
