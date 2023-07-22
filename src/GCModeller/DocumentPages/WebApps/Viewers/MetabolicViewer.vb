Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.DataStorage.HDSPack
Imports Microsoft.VisualBasic.DataStorage.HDSPack.FileSystem
Imports Microsoft.VisualBasic.Serialization.JSON

''' <summary>
''' view the metabolic graph network structure inside a virtual cell model  
''' </summary>
<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class MetabolicViewer : Inherits WebApp

    Dim proj As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="proj">
    ''' the gcmodeller modeller project file
    ''' </param>
    Public Sub New(proj As String)
        MyBase.New("/toolkit/viewer/metabolicViewer.vbhtml")
        Me.proj = proj
    End Sub

    Public Function getEnzymeClass() As String
        Return EnzymeRepository.getEnzymeClassId.GetJson
    End Function

    ''' <summary>
    ''' get compartments inside current cellular model
    ''' </summary>
    ''' <returns></returns>
    Public Function getMetabolicCompartments() As String()
        Using file As Stream = proj.Open(FileMode.Open, [readOnly]:=True)
            Dim buffer As New StreamPack(file, [readonly]:=True)
            Dim folder As StreamGroup = buffer.GetObject("/metabolic/")
            Dim compartments = folder.files _
                .Select(Function(f) f.fileName.BaseName) _
                .ToArray

            Return compartments
        End Using
    End Function

    ''' <summary>
    ''' get all metabolic enzyme json
    ''' </summary>
    ''' <param name="compartment"></param>
    ''' <returns></returns>
    Public Function getMetabolicEnzymes(compartment As String) As String
        Using file As Stream = proj.Open(FileMode.Open, [readOnly]:=True)
            Dim path As String = $"/metabolic/{compartment}.json"
            Dim json As String = New StreamPack(file, [readonly]:=True).ReadText(path)

            Return json
        End Using
    End Function
End Class
