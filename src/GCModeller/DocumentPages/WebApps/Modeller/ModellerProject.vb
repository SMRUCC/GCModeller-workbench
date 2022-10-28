
Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class ModellerProject : Inherits WebApp

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="path">
    ''' the file path of the project file to run modelling
    ''' </param>
    Public Sub New(path As String)
        MyBase.New("/toolkit/projects/modeller/project.vbhtml")

        arguments = New Dictionary(Of String, String)
        arguments("proj") = path
    End Sub
End Class
