#Region "Microsoft.VisualBasic::d4634f01c4d3880ce55a76230028b1b7, win32_desktop\src\GCModeller\DocumentPages\WebApps\AppIndex.vb"

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

    '   Total Lines: 38
    '    Code Lines: 29 (76.32%)
    ' Comment Lines: 0 (0.00%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 9 (23.68%)
    '     File Size: 861 B


    ' Class AppIndex
    ' 
    '     Constructor: (+2 Overloads) Sub New
    '     Sub: openCMeans, openDataEmbedding, openEnrichment, openMotifViewer, openPLAS
    '          openZscore
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class AppIndex : Inherits WebApp

    Public Sub New()
        MyBase.New("/applets.vbhtml")
    End Sub

    Protected Sub New(path As String)
        MyBase.New(path)
    End Sub

    Public Sub openDataEmbedding()
        Call WebApp.Open(Of DataEmbedding)()
    End Sub

    Public Sub openEnrichment()
        Call WebApp.Open(Of RunEnrichment)()
    End Sub

    Public Sub openPLAS()
        Call WebApp.Open(Of RunPLAS)()
    End Sub

    Public Sub openCMeans()
        Call WebApp.Open(Of CMeansAnalysis)()
    End Sub

    Public Sub openZscore()
        Call WebApp.Open(Of ZscoreAnalysis)()
    End Sub

    Public Sub openMotifViewer()
        Call WebApp.Open(Of MotifLogo)()
    End Sub
End Class
