#Region "Microsoft.VisualBasic::7b001e4f4bdcb0b2798cc29f5206f731, win32_desktop\src\GCModeller\DocumentPages\WebApps\DataRepository.vb"

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

    '   Total Lines: 22
    '    Code Lines: 17 (77.27%)
    ' Comment Lines: 0 (0.00%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 5 (22.73%)
    '     File Size: 558 B


    ' Class DataRepository
    ' 
    '     Constructor: (+1 Overloads) Sub New
    '     Sub: openEnrichmentRepository, openEnzymeRepository, openUniprotRepository
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class DataRepository : Inherits WebApp

    Public Sub New()
        MyBase.New("/repository.vbhtml")
    End Sub

    Public Sub openEnrichmentRepository()
        Call WebApp.Open(Of EnrichmentDatabase)()
    End Sub

    Public Sub openEnzymeRepository()
        Call WebApp.Open(Of EnzymeRepository)()
    End Sub

    Public Sub openUniprotRepository()
        Call WebApp.Open(Of ImportsUniProt)()
    End Sub
End Class
