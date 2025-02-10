#Region "Microsoft.VisualBasic::75699f6947f819cf81cd0d1b1bce4bdf, win32_desktop\src\Rstudio\Rstudio\src\Inspector.vb"

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


    ' Code Statistics:

    '   Total Lines: 95
    '    Code Lines: 70 (73.68%)
    ' Comment Lines: 15 (15.79%)
    '    - Xml Docs: 80.00%
    ' 
    '   Blank Lines: 10 (10.53%)
    '     File Size: 3.59 KB


    ' Module Inspector
    ' 
    '     Function: counts, getReactionGraph, GetReactions, LoadMoleculeList, Loadvector
    '               LoadViewer
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports RawViewer
Imports SMRUCC.genomics.GCModeller.ModellingEngine.IO.Raw
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Internal.Object
Imports SMRUCC.Rsharp.Runtime.Interop
Imports SMRUCC.Rsharp.Runtime.Vectorization

<Package("Inspector")>
Module Inspector

    <ExportAPI("load")>
    Public Function LoadViewer(pack As Object, Optional env As Environment = Nothing) As Object
        If pack Is Nothing Then
            Return Internal.debug.stop("the required data pack could not be nothing!", env)
        End If

        If TypeOf pack Is Reader Then
            Return New PackViewer(DirectCast(pack, Reader))
        Else
            Return Internal.debug.stop(New NotImplementedException, env)
        End If
    End Function

    <ExportAPI("counts")>
    Public Function counts(pack As PackViewer) As Object
        Return New list With {
            .slots = pack _
                .GetCounts _
                .ToDictionary(Function(a) a.Key,
                              Function(a)
                                  Return CObj(a.Value)
                              End Function)
        }
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pack"></param>
    ''' <param name="[module]"></param>
    ''' <param name="env"></param>
    ''' <returns>
    ''' the returns value of this function is different based on the
    ''' parameter value <paramref name="module"/>:
    ''' 
    ''' 1. default null mean returns the id set of all modules
    ''' 2. single string will generates a id character vector from this function
    ''' 3. multiple module names will generates a subset of the all modules list
    ''' </returns>
    <ExportAPI("load.molecule_list")>
    <RApiReturn(GetType(String))>
    Public Function LoadMoleculeList(pack As PackViewer,
                                     <RRawVectorArgument>
                                     Optional [module] As Object = Nothing,
                                     Optional env As Environment = Nothing) As Object

        Dim mols = pack.GetMoleculeIdset
        Dim modNames As String() = CLRVector.asCharacter([module])

        If modNames.IsNullOrEmpty Then
            ' returns all
            Return New list With {
                .slots = mols.ToDictionary(Function(a) a.Key, Function(a) CObj(a.Value))
            }
        ElseIf modNames.Length = 1 Then
            Return mols.TryGetValue(modNames.First)
        Else
            Return New list With {
                .slots = modNames _
                    .ToDictionary(Function(a) a,
                                  Function(a)
                                      Return CObj(mols(a))
                                  End Function)
            }
        End If
    End Function

    <ExportAPI("load.vector")>
    <RApiReturn(GetType(Double))>
    Public Function Loadvector(pack As PackViewer, modu_name As String, id As String) As Object
        Return pack.GetVector(modu_name, id).ToArray
    End Function

    <ExportAPI("load.reaction_ids")>
    Public Function GetReactions(pack As PackViewer, id As String) As Object
        Return pack.GetReactionIdSet(id)
    End Function

    <ExportAPI("load.reaction_graph")>
    Public Function getReactionGraph(pack As PackViewer, id As String, rxn As String) As Object
        Return pack.getReactionGraph(id, rxn)
    End Function
End Module
