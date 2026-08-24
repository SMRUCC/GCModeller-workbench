#Region "Microsoft.VisualBasic::5c3f9a237d02444080000a61173b07af, win32_desktop\src\GCModeller\DocumentPages\WebApps\DataAnalysis\RunBlast.vb"

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

    '   Total Lines: 29
    '    Code Lines: 14 (48.28%)
    ' Comment Lines: 11 (37.93%)
    '    - Xml Docs: 72.73%
    ' 
    '   Blank Lines: 4 (13.79%)
    '     File Size: 892 B


    ' Class RunBlast
    ' 
    '     Constructor: (+1 Overloads) Sub New
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class RunBlast : Inherits WebApp

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="parameters">
    ''' two string format:
    ''' 
    ''' 1. params:unique_id reference id to get parameter values from localstorage to init to run a task
    ''' 2. session:session_id reference id to view a task result
    ''' 
    ''' nothing just for open a new app page
    ''' </param>
    Public Sub New(Optional parameters As String = Nothing)
        MyBase.New("/apps/annotations/localblast.vbhtml")

        arguments = New Dictionary(Of String, String)

        If Not parameters.StringEmpty Then
            With parameters.GetTagValue(":")
                arguments(.Name) = .Value
            End With
        End If
    End Sub
End Class
