#Region "Microsoft.VisualBasic::e4406240579b45a9b9de368ad812cf8d, G:/GCModeller/src/workbench/win32_desktop/src/Rstudio/RscriptHost//AppContainer.vb"

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

    '   Total Lines: 16
    '    Code Lines: 9
    ' Comment Lines: 4
    '   Blank Lines: 3
    '     File Size: 451 B


    ' Class AppContainer
    ' 
    '     Properties: Rscript, RStudio
    ' 
    '     Constructor: (+2 Overloads) Sub New
    ' 
    ' /********************************************************************************/

#End Region

Public NotInheritable Class AppContainer

    ''' <summary>
    ''' the bin folder path of the internal rscript 
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property RStudio As String = $"{App.HOME}/Rstudio/bin"
    Public Shared ReadOnly Property Rscript As CLI.Rscript

    Private Sub New()
    End Sub

    Shared Sub New()
        Rscript = CLI.Rscript.FromEnvironment(RStudio)
    End Sub
End Class

