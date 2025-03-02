﻿#Region "Microsoft.VisualBasic::9704393b99b7c1f96d93674c278a0bdf, win32_desktop\src\Rstudio\Rstudio\src\Workbench\WebTask.vb"

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

    '   Total Lines: 40
    '    Code Lines: 17 (42.50%)
    ' Comment Lines: 19 (47.50%)
    '    - Xml Docs: 100.00%
    ' 
    '   Blank Lines: 4 (10.00%)
    '     File Size: 1.21 KB


    ' Class WebTask
    ' 
    '     Properties: [error], appName, arguments, logtext, session_id
    '                 status, time, title, url
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.ApplicationServices.Debugging.Diagnostics

''' <summary>
''' the task object is saved as json string
''' </summary>
#Disable Warning BC40000 ' Type or member is obsolete
<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class WebTask
#Enable Warning BC40000 ' Type or member is obsolete

    ''' <summary>
    ''' the name reference of the app page
    ''' </summary>
    ''' <returns></returns>
    Public Property appName As String
    Public Property time As String
    ''' <summary>
    ''' the task display title
    ''' </summary>
    ''' <returns></returns>
    Public Property title As String

    ''' <summary>
    ''' "success" | "error" | "pending" | "cancel";
    ''' </summary>
    ''' <returns></returns>
    Public Property status As String
    ''' <summary>
    ''' the task unique id
    ''' </summary>
    ''' <returns></returns>
    Public Property session_id As String
    Public Property arguments As Dictionary(Of String, String)
    Public Property [error] As ExceptionData
    Public Property logtext As String
    Public Property url As String

End Class
