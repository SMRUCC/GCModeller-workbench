#Region "Microsoft.VisualBasic::df391a449d2453ee32c462f1c24312c4, win32_desktop\src\GCModeller\DocumentPages\WebApps\MainIndex.vb"

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

    '   Total Lines: 45
    '    Code Lines: 35 (77.78%)
    ' Comment Lines: 2 (4.44%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 8 (17.78%)
    '     File Size: 1.31 KB


    ' Class MainIndex
    ' 
    '     Constructor: (+1 Overloads) Sub New
    '     Sub: createBioProject, createOmicsProject, open_project, openApplets, openDatabaseRepository
    '          openTaskManager
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class MainIndex : Inherits AppIndex

    Public Sub New()
        MyBase.New("/index.vbhtml")
    End Sub

    Public Sub openApplets()
        Call WebApp.Open(Of AppIndex)()
    End Sub

    Public Sub openDatabaseRepository()
        Call WebApp.Open(Of DataRepository)()
    End Sub

    Public Sub openTaskManager()
        Call WebApp.Open(Of AppTasks)()
    End Sub

    Public Sub open_project()
        Using file As New OpenFileDialog With {
            .Filter = "All GCModeller Project(*.bioproj)|*.bioproj|GCModeller Cell Project(*.bioproj)|*.bioproj"
        }
            If file.ShowDialog = DialogResult.OK Then
                If file.FileName.ExtensionSuffix("bioproj") Then
                    ' virtual cell modeller project
                    Call New ModellerProject(file.FileName).Open()
                Else
                    ' omics data analysis project
                End If
            End If
        End Using
    End Sub

    Public Sub createBioProject()
        Call WebApp.Open(Of CreateBioProject)()
    End Sub

    Public Sub createOmicsProject()
        Call WebApp.Open(Of CreateOmicsProject)()
    End Sub
End Class
