#Region "Microsoft.VisualBasic::21cecd609173cdee42b51b54e00fd774, win32_desktop\src\Rstudio\Rstudio\src\RStudio.vb"

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
    '    Code Lines: 18 (81.82%)
    ' Comment Lines: 0 (0.00%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 4 (18.18%)
    '     File Size: 672 B


    ' Module RStudio
    ' 
    '     Function: config, getBlastBinDir, getRepositoryRoot
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData

<Package("RStudio")>
Public Module RStudio

    <ExportAPI("repository_root")>
    Public Function getRepositoryRoot() As String
        Return Settings.Session.GetSettingsFile.RepositoryRoot
    End Function

    <ExportAPI("ncbi_blast_dir")>
    Public Function getBlastBinDir() As String
        Return Settings.Session.GetSettingsFile.BlastBin
    End Function

    <ExportAPI("config")>
    Public Function config(baseDir As String) As Object
        Call Settings.Session.Initialize(baseDir)
        Return Nothing
    End Function
End Module
