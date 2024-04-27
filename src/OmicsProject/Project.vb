#Region "Microsoft.VisualBasic::88aa2585966cb5e84de155bce9a0ef87, G:/GCModeller/src/workbench/win32_desktop/src/OmicsProject//Project.vb"

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

    '   Total Lines: 11
    '    Code Lines: 8
    ' Comment Lines: 0
    '   Blank Lines: 3
    '     File Size: 317 B


    ' Class Project
    ' 
    '     Properties: normalized, raw, samples, transformed
    ' 
    ' /********************************************************************************/

#End Region

Imports SMRUCC.genomics.Analysis.HTS.DataFrame
Imports SMRUCC.genomics.GCModeller.Workbench.ExperimentDesigner

Public Class Project

    Public Property samples As SampleInfo()
    Public Property raw As Matrix
    Public Property normalized As Matrix
    Public Property transformed As Matrix

End Class

