﻿#Region "Microsoft.VisualBasic::6b920d940e15c1b875e0bda04b2ac40b, R#\kegg_kit\britekit.vb"

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

' Module britekit
' 
'     Function: BriteTable, ParseBriteJson, ParseBriteTree
' 
' /********************************************************************************/

#End Region


Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Assembly.KEGG.DBGET.BriteHEntry
Imports SMRUCC.genomics.Assembly.KEGG.WebServices
Imports SMRUCC.Rsharp.Runtime
Imports REnv = SMRUCC.Rsharp.Runtime.Internal

''' <summary>
''' Toolkit for process the kegg brite text file
''' </summary>
<Package("kegg.brite")>
Module britekit

    ''' <summary>
    ''' Convert the kegg brite htext tree to plant table
    ''' </summary>
    ''' <param name="htext"></param>
    ''' <param name="entryIDPattern$"></param>
    ''' <returns></returns>
    <ExportAPI("brite.as.table")>
    Public Function BriteTable(htext As Object, Optional entryIDPattern$ = "[a-z]+\d+", Optional env As Environment = Nothing) As Object
        Dim terms As IEnumerable(Of BriteTerm)

        If htext Is Nothing Then
            Return REnv.debug.stop("htext object is nothing!", env)
        ElseIf htext.GetType Is GetType(htext) Then
            terms = DirectCast(htext, htext).Deflate(entryIDPattern)
        ElseIf htext.GetType Is GetType(htextJSON) Then
            terms = DirectCast(htext, htextJSON).DeflateTerms
        Else
            Return REnv.debug.stop(New NotSupportedException(htext.GetType.FullName), env)
        End If

        Return terms _
            .Select(Function(term)
                        Return New EntityObject With {
                            .ID = term.kegg_id,
                            .Properties = New Dictionary(Of String, String) From {
                                {NameOf(term.class), term.class},
                                {NameOf(term.category), term.category},
                                {NameOf(term.subcategory), term.subcategory},
                                {NameOf(term.order), term.order},
                                {NameOf(term.entry), term.entry.Key},
                                {"name", term.entry.Value}
                            }
                        }
                    End Function) _
            .GroupBy(Function(term) term.ID) _
            .Select(Function(termGroup)
                        Return termGroup.First
                    End Function) _
            .ToArray
    End Function

    ''' <summary>
    ''' Do parse of the kegg brite text file.
    ''' </summary>
    ''' <param name="file">
    ''' The file text content, brite id or its file path
    ''' </param>
    ''' <returns></returns>
    <ExportAPI("brite.parse")>
    Public Function ParseBriteTree(file$, Optional env As Environment = Nothing) As Object
        If file.IsPattern("[a-z]+\d+", RegexICSng) Then
            Select Case file.ToLower
                Case NameOf(htext.br08201) : Return htext.br08201
                Case NameOf(htext.br08204) : Return htext.br08204
                Case CompoundBrite.cpd_br08001,
                     CompoundBrite.cpd_br08002,
                     CompoundBrite.cpd_br08003,
                     CompoundBrite.cpd_br08005,
                     CompoundBrite.cpd_br08006,
                     CompoundBrite.cpd_br08007,
                     CompoundBrite.cpd_br08008,
                     CompoundBrite.cpd_br08009,
                     CompoundBrite.cpd_br08010,
                     CompoundBrite.cpd_br08021

                    Return htext.GetInternalResource(file)
                Case Else
                    Return REnv.debug.stop({$"Invalid brite id: {file}", $"brite id: {file}"}, env)
            End Select
        Else
            Return htext.StreamParser(res:=file)
        End If
    End Function

    ''' <summary>
    ''' Do parse of the kegg brite json file.
    ''' </summary>
    ''' <param name="file$"></param>
    ''' <param name="env"></param>
    ''' <returns></returns>
    <ExportAPI("brite.parseJSON")>
    Public Function ParseBriteJson(file$, Optional env As Environment = Nothing) As Object
        Return htextJSON.parseJSON(file)
    End Function

    <ExportAPI("KO.geneNames")>
    Public Function KOgeneNames() As Dictionary(Of String, String)
        Dim brites = PathwayMapping.DefaultKOTable
        Dim names As New Dictionary(Of String, String)
        Dim name As String

        For Each term In brites
            name = term.Value.description
            name = name.StringSplit(";\s*").First

            If name.StringEmpty Then
                names.Add(term.Key, term.Key)
            Else
                names.Add(term.Key, name)
            End If
        Next

        Return names
    End Function
End Module

