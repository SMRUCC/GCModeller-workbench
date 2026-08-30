#Region "Microsoft.VisualBasic::f9d8ff7c2eafade3f04599a38de034b8, win32_desktop\src\GCModeller\DocumentPages\WebApps\Omics\CreateOmicsProject.vb"

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

    '   Total Lines: 14
    '    Code Lines: 11 (78.57%)
    ' Comment Lines: 0 (0.00%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 3 (21.43%)
    '     File Size: 364 B


    ' Class CreateOmicsProject
    ' 
    '     Constructor: (+1 Overloads) Sub New
    '     Sub: openSampleEditor
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class CreateOmicsProject : Inherits WebApp

    Public Sub New()
        MyBase.New("/toolkit/projects/omics/create.vbhtml")
    End Sub

    Public Sub openSampleEditor()
        Call WebApp.Open(Of EditSampleInfo)()
    End Sub
End Class
