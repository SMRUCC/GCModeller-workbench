#Region "Microsoft.VisualBasic::4e5a9d2d6f59393e1eb7dc36e2e79fcf, win32_desktop\src\GCModeller\Forms\Base\ExplorerWindow.vb"

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

    '   Total Lines: 6
    '    Code Lines: 5 (83.33%)
    ' Comment Lines: 0 (0.00%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 1 (16.67%)
    '     File Size: 206 B


    ' Class ExplorerWindow
    ' 
    '     Sub: ExplorerWindow_Load
    ' 
    ' /********************************************************************************/

#End Region

Public Class ExplorerWindow

    Private Sub ExplorerWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DockAsTabbedDocumentToolStripMenuItem.Enabled = False
    End Sub
End Class
