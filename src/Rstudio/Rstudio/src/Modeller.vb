Imports System.IO
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Assembly.NCBI.GenBank
Imports SMRUCC.genomics.Model
Imports SMRUCC.genomics.Model.BioSystems
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
End Module
