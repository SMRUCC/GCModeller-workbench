#Region "Microsoft.VisualBasic::7fda1cf79acf46b8aaa5e0a9dbfb0f16, win32_desktop\src\GCModeller\DocumentPages\WebApps\Repository\EnrichmentDatabase.vb"

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

    '   Total Lines: 35
    '    Code Lines: 28 (80.00%)
    ' Comment Lines: 0 (0.00%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 7 (20.00%)
    '     File Size: 1.20 KB


    ' Class EnrichmentDatabase
    ' 
    '     Constructor: (+1 Overloads) Sub New
    '     Function: openEnrichmentPage, scanDatabase
    ' 
    ' /********************************************************************************/

#End Region


Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Serialization.JSON

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class EnrichmentDatabase : Inherits WebApp

    Public Sub New()
        MyBase.New("/toolkit/enrichment_database.vbhtml")
    End Sub

    Public Function scanDatabase() As String
        Dim list = "/etc/repository/".ListFiles("*.json").Where(Function(json) json.ChangeSuffix("db").FileExists()).ToArray
        Dim metadata = list _
            .ToDictionary(Function(path) path.BaseName,
                          Function(path)
                              Return path.LoadJsonFile(Of Dictionary(Of String, String))
                          End Function)

        Return metadata.GetJson
    End Function

    Public Function openEnrichmentPage(database As String, name As String, note As String) As Boolean
        Dim app As New RunEnrichment With {
            .arguments = New Dictionary(Of String, String) From {
                {"id", database},
                {"name", name},
                {"note", note}
            }
        }

        Return app.Open
    End Function
End Class

