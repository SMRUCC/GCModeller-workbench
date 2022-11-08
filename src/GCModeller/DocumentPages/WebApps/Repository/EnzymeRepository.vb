
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
        Return getEnzymeClassId.GetJson
    End Function

    Public Shared Function getEnzymeClassId() As Dictionary(Of String, Integer)
        Dim classList As New Dictionary(Of String, Integer)

        For Each name As EnzymeClasses In Enums(Of EnzymeClasses)()
            classList.Add(name.Description, CInt(name))
        Next

        Return classList
    End Function
End Class
