#Region "Microsoft.VisualBasic::f53bb2545e78cfeedf98cbdda7819671, win32_desktop\src\GCModeller\DocumentPages\WebApps\Viewers\BlastpViewer.vb"

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

    '   Total Lines: 26
    '    Code Lines: 20 (76.92%)
    ' Comment Lines: 0 (0.00%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 6 (23.08%)
    '     File Size: 851 B


    ' Class BlastpViewer
    ' 
    '     Constructor: (+1 Overloads) Sub New
    '     Function: getBlastp, getProteinIDs
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH

Public Class BlastpViewer : Inherits WebApp

    ReadOnly blastdata As Dictionary(Of String, BestHit())

    Public Sub New(blastdata As BestHit())
        MyBase.New("/toolkit/viewer/blastp.vbhtml")

        Me.blastdata = blastdata _
            .GroupBy(Function(a) a.QueryName) _
            .ToDictionary(Function(prot) prot.Key,
                          Function(hits)
                              Return hits.ToArray
                          End Function)
    End Sub

    Public Function getProteinIDs() As String()
        Return blastdata.Keys.ToArray
    End Function

    Public Function getBlastp(id As String) As String
        Return blastdata(id).GetJson
    End Function
End Class
