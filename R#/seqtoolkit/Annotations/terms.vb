﻿#Region "Microsoft.VisualBasic::fa305348b133420b3a28f1743e529893, R#\seqtoolkit\Annotations\terms.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xie (genetics@smrucc.org)
'       xieguigang (xie.guigang@live.com)
' 
' Copyright (c) 2018 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
' 
' 
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
' 
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
' 
' You should have received a copy of the GNU General Public License
' along with this program. If not, see <http://www.gnu.org/licenses/>.



' /********************************************************************************/

' Summaries:

' Module terms
' 
'     Function: COGannotations, GOannotations, KOannotations, Pfamannotations
' 
' /********************************************************************************/

#End Region

Imports System.Text
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.ComponentModel
Imports SMRUCC.genomics.ComponentModel.DBLinkBuilder
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH
Imports SMRUCC.genomics.Interops.NCBI.Extensions.Pipeline
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Internal.Object

<Package("annotation.terms", Category:=APICategories.ResearchTools, Publisher:="xie.guigang@gcmodeller.org")>
Module terms

    Sub New()
        Call Internal.ConsolePrinter.AttachConsoleFormatter(Of SecondaryIDSolver)(AddressOf printIDSolver)
    End Sub

    Private Function printIDSolver(solver As SecondaryIDSolver) As String
        Dim sb As New StringBuilder
        Dim synonym As String()
        Dim summary As String

        Call sb.AppendLine($"{NameOf(SecondaryIDSolver)} for {solver.Count} id entities:")
        Call sb.AppendLine($"[{solver.Count}] {solver.ALL.Take(10).JoinBy(" ")}...")
        Call sb.AppendLine()

        For Each id As String In solver.ALL.Take(6)
            synonym = solver.GetSynonym(id).alias
            summary = If(synonym.Length <= 5, synonym.JoinBy(vbTab), synonym.Take(5).JoinBy(vbTab) & "...")
            sb.AppendLine($"${id}: {summary}")
        Next

        Call sb.AppendLine("...")

        Return sb.ToString
    End Function

    ''' <summary>
    ''' do KO number assign based on the bbh alignment result.
    ''' </summary>
    ''' <param name="forward"></param>
    ''' <param name="reverse"></param>
    ''' <param name="env"></param>
    ''' <returns></returns>
    <ExportAPI("assign.KO")>
    Public Function KOannotations(forward As pipeline, reverse As pipeline, Optional env As Environment = Nothing) As pipeline
        If forward Is Nothing Then
            Return Internal.debug.stop("forward data stream is nothing!", env)
        ElseIf reverse Is Nothing Then
            Return Internal.debug.stop("reverse data stream is nothing!", env)
        ElseIf Not forward.elementType.raw Is GetType(BestHit) Then
            Return Internal.debug.stop($"forward is invalid data stream type: {forward.elementType.fullName}!", env)
        ElseIf Not reverse.elementType.raw Is GetType(BestHit) Then
            Return Internal.debug.stop($"reverse is invalid data stream type: {reverse.elementType.fullName}!", env)
        End If

        Return KOAssignment.KOassignmentBBH(forward.populates(Of BestHit), reverse.populates(Of BestHit)).DoCall(AddressOf pipeline.CreateFromPopulator)
    End Function

    <ExportAPI("assign.COG")>
    Public Function COGannotations()

    End Function

    <ExportAPI("assign.Pfam")>
    Public Function Pfamannotations()

    End Function

    <ExportAPI("assign.GO")>
    Public Function GOannotations()

    End Function

    <ExportAPI("write.id_maps")>
    Public Function saveIdMappings(maps As SecondaryIDSolver, file As String) As Boolean
        Return maps.Save(path:=file)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="skip2ndMaps">
    ''' set this parameter value to ``true`` for fixed for build the ``kegg2go`` mapping model.
    ''' </param>
    ''' <returns></returns>
    <ExportAPI("read.id_maps")>
    Public Function readIdMappings(file As String, Optional skip2ndMaps As Boolean = False) As SecondaryIDSolver
        Return DBLinkBuilder.LoadMappingText(file, skip2ndMaps)
    End Function

    <ExportAPI("synonym")>
    Public Function Synonyms(idlist As String(), idmap As SecondaryIDSolver, Optional excludeNull As Boolean = False) As Synonym()
        Return idmap.PopulateSynonyms(idlist, excludeNull:=excludeNull).ToArray()
    End Function
End Module

