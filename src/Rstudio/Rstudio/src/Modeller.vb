Imports System.IO
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.DataStorage.HDSPack
Imports Microsoft.VisualBasic.DataStorage.HDSPack.FileSystem
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Assembly.NCBI.GenBank
Imports SMRUCC.genomics.ComponentModel.Annotation
Imports SMRUCC.genomics.Data
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.BLASTOutput
Imports SMRUCC.genomics.Model
Imports SMRUCC.genomics.Model.BioSystems
Imports SMRUCC.genomics.SequenceModel.FASTA
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Components
Imports SMRUCC.Rsharp.Runtime.Internal.Object
Imports SMRUCC.Rsharp.Runtime.Interop

<Package("Modeller")>
Module Modeller

    <ExportAPI("build_metabolic_network")>
    Public Function buildMetabolicNetwork(proj As String, rhea As RheaNetworkReader) As Object
        Dim buffer As Stream = proj.Open(FileMode.Open, doClear:=False, [readOnly]:=True)
        Dim reader As New ProjectReader(buffer)
        Dim enzymes = reader.GetEnzymeAnnotation
        Dim compartments = reader.GetLocationAnnotation

        Return Nothing
    End Function

    <ExportAPI("loadProject")>
    <RApiReturn(GetType(Project))>
    Public Function createProject(assembly As Object, Optional env As Environment = Nothing) As Object
        If assembly Is Nothing Then
            Return Nothing
        End If

        If TypeOf assembly Is GBFF.File Then
            Return BioSystems.Utils.FromGenBank(genbank:=assembly)
        Else
            Return Message.InCompatibleType(GetType(GBFF.File), assembly.GetType, env)
        End If
    End Function

    <ExportAPI("writeProject")>
    <RApiReturn(GetType(Boolean))>
    Public Function writeProject(proj As Project, file As Object, Optional env As Environment = Nothing) As Object
        Dim buffer = SMRUCC.Rsharp.GetFileStream(file, FileAccess.Write, env)

        If buffer Like GetType(Message) Then
            Return buffer.TryCast(Of Message)
        End If

        Using writer As New ProjectWriter(buffer.TryCast(Of Stream))
            Call writer.WriteProject(proj)
        End Using

        Return True
    End Function

    ''' <summary>
    ''' get project summary metadata
    ''' </summary>
    ''' <param name="proj"></param>
    ''' <returns></returns>
    <ExportAPI("readProj")>
    Public Function loadProject(proj As String) As Object
        Dim buffer As Stream = proj.Open(FileMode.Open, doClear:=False, [readOnly]:=True)
        Dim reader As New ProjectReader(buffer)
        Dim enzymeClass = Enums(Of EnzymeClasses)().ToDictionary(Function(a) CInt(a).ToString)
        Dim annoClass = reader.GetEnzymeAnnotation.Values _
            .IteratesALL _
            .GroupBy(Function(a) a.Split("."c).First) _
            .ToDictionary(Function(c) enzymeClass(c.Key).Description,
                          Function(c)
                              Return c.Count
                          End Function)
        Dim locations = reader.GetLocationAnnotation.Values _
            .IteratesALL _
            .GroupBy(Function(a) a) _
            .ToDictionary(Function(a) a.Key,
                          Function(a)
                              Return a.Count
                          End Function)

        Return New list With {
            .slots = New Dictionary(Of String, Object) From {
                {"total", reader.TotalProteins},
                {"number_enzymes", reader.TotalEnzymes},
                {"enzyme_class", annoClass},
                {"subcellular_locations", locations}
            }
        }
    End Function

    <ExportAPI("extract_proteinset_fasta")>
    Public Function extractProteinSetFasta(proj As String, save As String) As Object
        Dim buffer As Stream = proj.Open(FileMode.Open, doClear:=False, [readOnly]:=True)
        Dim reader As New ProjectReader(buffer)
        Dim fasta As New FastaFile(reader.GetProteinFasta)

        Return fasta.Save(save)
    End Function

    <ExportAPI("save_enzyme_annotation")>
    Public Function saveEnzymeAnnotation(proj As String, anno As String) As Object
        Call saveBlast(proj, anno, "/workspace/enzyme_blast.csv", "/models/ec_numbers.json")
        Return True
    End Function

    Private Sub saveBlast(proj As String, anno As String, blast_file As String, json_file As String)
        Using buffer As New StreamPack(proj)
            Dim besthits = anno.LoadCsv(Of BestHit)
            Dim EC_numbers = besthits _
                .Where(Function(i)
                           Return i.identities > 0.6 AndAlso
                                  i.positive > 0.6 AndAlso
                                  i.HitName <> IBlastOutput.HITS_NOT_FOUND
                       End Function) _
                .GroupBy(Function(i) i.QueryName) _
                .ToDictionary(Function(a) a.Key,
                              Function(a)
                                  Return a _
                                     .Select(Function(i) i.HitName.Split("|"c).First) _
                                     .Distinct _
                                     .ToArray
                              End Function)

            Call buffer.Delete(blast_file)
            Call buffer.Delete(json_file)
            Call buffer.WriteText(anno.ReadAllText, blast_file)
            Call buffer.WriteText(EC_numbers.GetJson, json_file)
        End Using
    End Sub

    <ExportAPI("save_subcellular_location")>
    Public Function saveSubcellularLocationAnnotation(proj As String, anno As String) As Object
        Call saveBlast(proj, anno, "/workspace/subcellular_location_blast.csv", "/models/subcellular_location.json")
        Return True
    End Function
End Module
