#Region "Microsoft.VisualBasic::e5a9a0ca0b96b8dc06afb854cd5e1a65, win32_desktop\src\GCModeller\DocumentPages\WebApps\Viewers\MetabolicViewer.vb"

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

    '   Total Lines: 60
    '    Code Lines: 34 (56.67%)
    ' Comment Lines: 18 (30.00%)
    '    - Xml Docs: 94.44%
    ' 
    '   Blank Lines: 8 (13.33%)
    '     File Size: 2.01 KB


    ' Class MetabolicViewer
    ' 
    '     Constructor: (+1 Overloads) Sub New
    '     Function: getEnzymeClass, getMetabolicCompartments, getMetabolicEnzymes
    ' 
    ' /********************************************************************************/

#End Region

Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.DataStorage.HDSPack
Imports Microsoft.VisualBasic.DataStorage.HDSPack.FileSystem
Imports Microsoft.VisualBasic.Serialization.JSON

''' <summary>
''' view the metabolic graph network structure inside a virtual cell model  
''' </summary>
<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class MetabolicViewer : Inherits WebApp

    Dim proj As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="proj">
    ''' the gcmodeller modeller project file
    ''' </param>
    Public Sub New(proj As String)
        MyBase.New("/toolkit/viewer/metabolicViewer.vbhtml")
        Me.proj = proj
    End Sub

    Public Function getEnzymeClass() As String
        Return EnzymeRepository.getEnzymeClassId.GetJson
    End Function

    ''' <summary>
    ''' get compartments inside current cellular model
    ''' </summary>
    ''' <returns></returns>
    Public Function getMetabolicCompartments() As String()
        Using file As Stream = proj.Open(FileMode.Open, [readOnly]:=True)
            Dim buffer As New StreamPack(file, [readonly]:=True)
            Dim folder As StreamGroup = buffer.GetObject("/metabolic/")
            Dim compartments = folder.files _
                .Select(Function(f) f.fileName.BaseName) _
                .ToArray

            Return compartments
        End Using
    End Function

    ''' <summary>
    ''' get all metabolic enzyme json
    ''' </summary>
    ''' <param name="compartment"></param>
    ''' <returns></returns>
    Public Function getMetabolicEnzymes(compartment As String) As String
        Using file As Stream = proj.Open(FileMode.Open, [readOnly]:=True)
            Dim path As String = $"/metabolic/{compartment}.json"
            Dim json As String = New StreamPack(file, [readonly]:=True).ReadText(path)

            Return json
        End Using
    End Function
End Class
