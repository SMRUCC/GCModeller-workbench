
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.DataStorage.HDSPack
Imports Microsoft.VisualBasic.DataStorage.HDSPack.FileSystem
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class ModellerProject : Inherits WebApp

    Public ReadOnly Property project As String
        Get
            Return arguments("proj")
        End Get
    End Property

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

    Public Sub openLocalBlast(ssid As String)
        Call New RunBlast($"params:{ssid}").Open()
    End Sub

    Public Sub openEnzymeBlastViewer()
        Dim data As BestHit() = getBlastp("/workspace/enzyme_blast.csv")
        Dim app As New BlastpViewer(data)

        Call app.Open()
    End Sub

    Private Function getBlastp(path As String) As BestHit()
        Using buffer = project.Open(FileMode.Open, doClear:=False, [readOnly]:=True)
            Dim file As New StreamPack(buffer, [readonly]:=True)
            Dim csv = file.ReadText(path).ParseDoc(removesBlank:=True)
            Dim blast As BestHit() = csv.AsDataSource(Of BestHit)(False).ToArray

            Return blast
        End Using
    End Function

    Public Sub openSubcellularBlastViewer()
        Dim data As BestHit() = getBlastp("/workspace/subcellular_location_blast.csv")
        Dim app As New BlastpViewer(data)

        Call app.Open()
    End Sub
End Class
