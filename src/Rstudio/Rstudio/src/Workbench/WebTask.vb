Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.ApplicationServices.Debugging.Diagnostics

#Disable Warning BC40000 ' Type or member is obsolete
<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class WebTask
#Enable Warning BC40000 ' Type or member is obsolete

    Public Property appName As String
    Public Property time As String
    Public Property title As String
    Public Property status As String
    ''' <summary>
    ''' the task unique id
    ''' </summary>
    ''' <returns></returns>
    Public Property session_id As String
    Public Property arguments As Dictionary(Of String, String)
    Public Property [error] As ExceptionData
    Public Property logtext As String

End Class
