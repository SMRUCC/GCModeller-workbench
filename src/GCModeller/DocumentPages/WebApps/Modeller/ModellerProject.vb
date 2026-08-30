#Region "Microsoft.VisualBasic::d4c8f1bfbba4149a9c732118e6183198, win32_desktop\src\GCModeller\DocumentPages\WebApps\Modeller\ModellerProject.vb"

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

    '   Total Lines: 69
    '    Code Lines: 48 (69.57%)
    ' Comment Lines: 9 (13.04%)
    '    - Xml Docs: 88.89%
    ' 
    '   Blank Lines: 12 (17.39%)
    '     File Size: 2.27 KB


    ' Class ModellerProject
    ' 
    '     Properties: project
    ' 
    '     Constructor: (+1 Overloads) Sub New
    ' 
    '     Function: getBlastp
    ' 
    '     Sub: openEnzymeBlastViewer, openLocalBlast, openMetabolicViewer, openSubcellularBlastViewer
    ' 
    ' /********************************************************************************/

#End Region

Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.DataStorage.HDSPack
Imports Microsoft.VisualBasic.DataStorage.HDSPack.FileSystem
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH

''' <summary>
''' view gcmodeller virtual cell project data
''' </summary>
<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class ModellerProject : Inherits WebApp

    Public ReadOnly Property project As String
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Get
            Return arguments("proj")
        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="path">
    ''' the file path of the project file to run modelling
    ''' </param>
    Public Sub New(path As String)
        MyBase.New("/toolkit/projects/modeller/project.vbhtml")

        arguments = New Dictionary(Of String, String)
        arguments("proj") = path
    End Sub

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Sub openLocalBlast(ssid As String)
        Call New RunBlast($"params:{ssid}").Open()
    End Sub

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Sub openMetabolicViewer()
        Call New MetabolicViewer(project).Open()
    End Sub

    Public Sub openEnzymeBlastViewer()
        Dim data As BestHit() = getBlastp("/workspace/enzyme_blast.csv")
        Dim app As New BlastpViewer(data)

        Call app.Open()
    End Sub

    Private Function getBlastp(path As String) As BestHit()
        Using buffer = project.Open(FileMode.Open, doClear:=False, [readOnly]:=True)
            Dim file As New StreamPack(buffer, [readonly]:=True)
            Dim csv = file.ReadText(path).ParseDoc(removesBlank:=True)
            Dim blast As BestHit() = csv.AsDataSource(Of BestHit)(False).ToArray

            Return blast
        End Using
    End Function

    Public Sub openSubcellularBlastViewer()
        Dim data As BestHit() = getBlastp("/workspace/subcellular_location_blast.csv")
        Dim app As New BlastpViewer(data)

        Call app.Open()
    End Sub
End Class
