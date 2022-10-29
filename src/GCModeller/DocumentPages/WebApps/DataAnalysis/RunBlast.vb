
Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class RunBlast : Inherits WebApp

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="parameters">
    ''' two string format:
    ''' 
    ''' 1. params:unique_id reference id to get parameter values from localstorage to init to run a task
    ''' 2. session:session_id reference id to view a task result
    ''' 
    ''' nothing just for open a new app page
    ''' </param>
    Public Sub New(Optional parameters As String = Nothing)
        MyBase.New("/apps/annotations/localblast.vbhtml")

        arguments = New Dictionary(Of String, String)

        If Not parameters.StringEmpty Then

        End If
    End Sub
End Class
