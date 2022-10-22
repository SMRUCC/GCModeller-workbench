
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.MIME.application.json
Imports SMRUCC.genomics.ComponentModel.Annotation

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class EnzymeRepository : Inherits WebApp

    Public Sub New()
        MyBase.New("/toolkit/enzyme_database.vbhtml")
    End Sub

    Public Function getEnzymeClass() As String
        Dim classList As New Dictionary(Of String, Integer)

        For Each name As EnzymeClasses In Enums(Of EnzymeClasses)()
            classList.Add(name.Description, CInt(name))
        Next

        Return classList.GetJson
    End Function
End Class
