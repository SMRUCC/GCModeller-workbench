Imports System.IO
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.DataStorage.HDSPack
Imports Microsoft.VisualBasic.DataStorage.HDSPack.FileSystem
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Assembly.NCBI.GenBank
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.BLASTOutput
Imports SMRUCC.genomics.Model
Imports SMRUCC.genomics.Model.BioSystems
Imports SMRUCC.genomics.SequenceModel.FASTA
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Components
Imports SMRUCC.Rsharp.Runtime.Interop

<Package("Modeller")>
Module Modeller

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

    <ExportAPI("extract_proteinset_fasta")>
    Public Function extractProteinSetFasta(proj As String, save As String) As Object
        Dim buffer As Stream = proj.Open(FileMode.Open, doClear:=False, [readOnly]:=True)
        Dim reader As New ProjectReader(buffer)
        Dim fasta As New FastaFile(reader.GetProteinFasta)

        Return fasta.Save(save)
    End Function

    <ExportAPI("save_enzyme_annotation")>
    Public Function saveEnzymeAnnotation(proj As String, anno As String) As Object
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

            Call buffer.WriteText(anno.ReadAllText, "/workspace/enzyme_blast.csv")
            Call buffer.WriteText(EC_numbers.GetJson, "/models/ec_numbers.json")
        End Using

        Return True
    End Function
End Module
