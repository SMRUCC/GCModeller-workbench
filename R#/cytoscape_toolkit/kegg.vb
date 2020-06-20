﻿#Region "Microsoft.VisualBasic::6f6a40d3b13abcbd4ac9d20706d37d53, R#\cytoscape_toolkit\kegg.vb"

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

' Module kegg
' 
'     Function: compoundNetwork
' 
' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Assembly.KEGG.DBGET
Imports SMRUCC.genomics.Assembly.KEGG.WebServices
Imports SMRUCC.genomics.Model.Network.KEGG.ReactionNetwork

''' <summary>
''' The KEGG metabolism pathway network data R# scripting plugin for cytoscape software
''' </summary>
<Package("cytoscape.kegg", Category:=APICategories.ResearchTools, Publisher:="xie.guigang@gcmodeller.org")>
Module kegg

    ''' <summary>
    ''' Create kegg metabolism network based on the given metabolite compound data.
    ''' </summary>
    ''' <param name="reactions">The kegg ``br08201`` reaction database.</param>
    ''' <param name="compounds">Kegg compound id list</param>
    ''' <returns></returns>
    <ExportAPI("compounds.network")>
    Public Function compoundNetwork(reactions As ReactionTable(), compounds$(),
                                    Optional enzymes As Dictionary(Of String, String()) = Nothing,
                                    Optional filterByEnzymes As Boolean = False,
                                    Optional extended As Boolean = False) As NetworkGraph
        Return compounds _
            .Select(Function(cpd)
                        Return New NamedValue(Of String)(cpd, cpd)
                    End Function) _
            .DoCall(Function(list)
                        Return reactions.BuildModel(
                            compounds:=list,
                            enzymes:=enzymes,
                            filterByEnzymes:=filterByEnzymes,
                            extended:=extended
                        )
                    End Function)
    End Function

    ''' <summary>
    ''' assign pathway map id to the nodes in the given network graph
    ''' </summary>
    ''' <param name="graph">
    ''' the node vertex in this network graph object its label value 
    ''' could be one of: glycan, compound, kegg ortholog or reaction id 
    ''' </param>
    ''' <param name="maps"></param>
    ''' <param name="top3"></param>
    ''' <returns></returns>
    <ExportAPI("pathway_class")>
    Public Function assignPathwayClass(graph As NetworkGraph,
                                       maps As Map(),
                                       Optional top3 As Boolean = True,
                                       Optional excludesGlobalAndOverviewMaps As Boolean = True) As NetworkGraph

        Dim compounds As Node() = graph.vertex.Where(Function(a) a.label.IsPattern("[GCKR]\d+")).ToArray
        Dim assignments As New Dictionary(Of String, List(Of String))
        Dim overviews As Index(Of String) = BriteHEntry.Pathway _
            .GetGlobalAndOverviewMaps _
            .Select(Function(a) a.name.Match("\d+")) _
            .Indexing

        For Each id In compounds
            assignments.Add(id.label, New List(Of String))
        Next

        For Each map As Map In maps
            ' map011xx
            If excludesGlobalAndOverviewMaps Then
                If map.id.Match("\d+") Like overviews Then
                    Continue For
                End If
            End If

            For Each id As String In map.GetMembers
                If assignments.ContainsKey(id) Then
                    assignments(id).Add(map.id)
                End If
            Next
        Next

        If top3 Then
            Dim firstMapHits = assignments _
                .Select(Function(a) a.Value.Select(Function(mapId) (cid:=a.Key, mapId))) _
                .IteratesALL _
                .GroupBy(Function(a) a.mapId) _
                .OrderByDescending(Function(m) m.Count) _
                .Take(3) _
                .ToArray

            For Each block In firstMapHits
                Dim mapHit As Map = maps.First(Function(a) a.id = block.Key)

                For Each id As String In block.Select(Function(a) a.cid)
                    If Not graph.GetElementByID(id).data.HasProperty("map") Then
                        graph.GetElementByID(id).data("map") = mapHit.id
                        graph.GetElementByID(id).data("mapName") = mapHit.Name
                    End If
                Next
            Next
        Else
            For Each node In compounds
                node.data("maps") = assignments(node.label).ToArray.GetJson
            Next
        End If

        Return graph
    End Function
End Module

