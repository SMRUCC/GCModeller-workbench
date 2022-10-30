Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.ApplicationServices.Debugging.Diagnostics

''' <summary>
''' the task object is saved as json string
''' </summary>
#Disable Warning BC40000 ' Type or member is obsolete
<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class WebTask
#Enable Warning BC40000 ' Type or member is obsolete

    ''' <summary>
    ''' the name reference of the app page
    ''' </summary>
    ''' <returns></returns>
    Public Property appName As String
    Public Property time As String
    ''' <summary>
    ''' the task display title
    ''' </summary>
    ''' <returns></returns>
    Public Property title As String

    ''' <summary>
    ''' "success" | "error" | "pending" | "cancel";
    ''' </summary>
    ''' <returns></returns>
    Public Property status As String
    ''' <summary>
    ''' the task unique id
    ''' </summary>
    ''' <returns></returns>
    Public Property session_id As String
    Public Property arguments As Dictionary(Of String, String)
    Public Property [error] As ExceptionData
    Public Property logtext As String
    Public Property url As String

End Class
