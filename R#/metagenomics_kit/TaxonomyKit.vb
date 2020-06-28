﻿#Region "Microsoft.VisualBasic::f54c77d57c889dacd4b5cad498218c81, R#\metagenomics_kit\TaxonomyKit.vb"

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

' Module TaxonomyKit
' 
'     Constructor: (+1 Overloads) Sub New
'     Function: LoadNcbiTaxonomyTree, printTaxonomy
' 
' /********************************************************************************/

#End Region


Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Assembly.NCBI.Taxonomy
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Internal.Object
Imports SMRUCC.Rsharp.Runtime.Interop
Imports REnv = SMRUCC.Rsharp.Runtime.Internal.ConsolePrinter
Imports Taxonomy = SMRUCC.genomics.Metagenomics.Taxonomy

''' <summary>
''' toolkit for process ncbi taxonomy tree data
''' </summary>
<Package("taxonomy_kit", Category:=APICategories.UtilityTools, Publisher:="xie.guigang@gcmodeller.org")>
Module TaxonomyKit

    Sub New()
        REnv.AttachConsoleFormatter(Of Taxonomy)(AddressOf printTaxonomy)
        Internal.Object.Converts.addHandler(GetType(NcbiTaxonomyTree), AddressOf lineageTable)
    End Sub

    Private Function lineageTable(x As Object, args As list, env As Environment) As dataframe
        Dim tree As NcbiTaxonomyTree = DirectCast(x, NcbiTaxonomyTree)
        Dim taxonomy = tree.Taxonomy.Keys _
            .Select(Function(id)
                        Return tree _
                            .GetAscendantsWithRanksAndNames(id, True) _
                            .DoCall(Function(line)
                                        Return New Taxonomy(line) With {
                                            .ncbi_taxid = id
                                        }
                                    End Function)
                    End Function) _
            .ToArray
        Dim ncbi_taxid As Array = taxonomy.Select(Function(t) t.ncbi_taxid).ToArray
        Dim kingdom As Array = taxonomy.Select(Function(t) t.kingdom).ToArray
        Dim phylum As Array = taxonomy.Select(Function(t) t.phylum).ToArray
        Dim [class] As Array = taxonomy.Select(Function(t) t.class).ToArray
        Dim order As Array = taxonomy.Select(Function(t) t.order).ToArray
        Dim family As Array = taxonomy.Select(Function(t) t.family).ToArray
        Dim genus As Array = taxonomy.Select(Function(t) t.genus).ToArray
        Dim species As Array = taxonomy.Select(Function(t) t.species).ToArray

        Return New dataframe With {
            .columns = New Dictionary(Of String, Array) From {
                {NameOf(ncbi_taxid), ncbi_taxid},
                {NameOf(kingdom), kingdom},
                {NameOf(phylum), phylum},
                {NameOf([class]), [class]},
                {NameOf(order), order},
                {NameOf(family), family},
                {NameOf(genus), genus},
                {NameOf(species), species}
            }
        }
    End Function

    Private Function printTaxonomy(taxonomy As Taxonomy) As String
        Return $"<{taxonomy.lowestLevel}> {taxonomy.ToString(BIOMstyle:=True)}"
    End Function

    <ExportAPI("biom.string")>
    <RApiReturn(GetType(String))>
    Public Function TaxonomyBIOMString(<RRawVectorArgument> taxonomy As Object, Optional env As Environment = Nothing) As Object
        Dim list = pipeline.TryCreatePipeline(Of Taxonomy)(taxonomy, env)

        If list.isError Then
            Return list.getError
        Else
            Return list.populates(Of Taxonomy) _
                .Select(Function(tax) tax.ToString(BIOMstyle:=True)) _
                .ToArray
        End If
    End Function

    ''' <summary>
    ''' load ncbi taxonomy tree model from the given data files
    ''' </summary>
    ''' <param name="repo">a directory folder path which contains the NCBI taxonomy 
    ''' tree data files: ``nodes.dmp`` and ``names.dmp``.</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Builds the following dictionnary from NCBI taxonomy ``nodes.dmp`` and ``names.dmp``
    ''' files 
    ''' 
    ''' ```json 
    ''' { Taxid namedtuple('Node', ['name', 'rank', 'parent', 'children']
    '''     } 
    ''' ``` 
    ''' + https://www.biostars.org/p/13452/ 
    ''' + https://pythonhosted.org/ete2/tutorial/tutorial_ncbitaxonomy.html
    ''' </remarks>
    <ExportAPI("Ncbi.taxonomy_tree")>
    Public Function LoadNcbiTaxonomyTree(repo As String) As NcbiTaxonomyTree
        Return New NcbiTaxonomyTree(repo)
    End Function

    ''' <summary>
    ''' get taxonomy lineage model from the ncbi taxonomy tree by given taxonomy id
    ''' </summary>
    ''' <param name="tree">the ncbi taxonomy tree model</param>
    ''' <param name="taxid">the ncbi taxonomy id</param>
    ''' <param name="fullName"></param>
    ''' <returns></returns>
    <ExportAPI("lineage")>
    Public Function Lineage(tree As NcbiTaxonomyTree, taxid As Integer, Optional fullName As Boolean = False) As Taxonomy
        Return New Taxonomy(tree.GetAscendantsWithRanksAndNames(taxid, only_std_ranks:=Not fullName))
    End Function
End Module

