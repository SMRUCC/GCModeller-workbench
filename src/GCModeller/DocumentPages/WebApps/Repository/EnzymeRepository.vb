#Region "Microsoft.VisualBasic::23c8ac806383d7262b0145c948a6668c, win32_desktop\src\GCModeller\DocumentPages\WebApps\Repository\EnzymeRepository.vb"

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
    '     File Size: 804 B


    ' Class EnzymeRepository
    ' 
    '     Constructor: (+1 Overloads) Sub New
    '     Function: getEnzymeClass, getEnzymeClassId
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.MIME.application.json
Imports SMRUCC.genomics.ComponentModel.Annotation

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class EnzymeRepository : Inherits WebApp

    Public Sub New()
        MyBase.New("/toolkit/enzyme_database.vbhtml")
    End Sub

    Public Function getEnzymeClass() As String
        Return getEnzymeClassId.GetJson
    End Function

    Public Shared Function getEnzymeClassId() As Dictionary(Of String, Integer)
        Dim classList As New Dictionary(Of String, Integer)

        For Each name As EnzymeClasses In Enums(Of EnzymeClasses)()
            classList.Add(name.Description, CInt(name))
        Next

        Return classList
    End Function
End Class
