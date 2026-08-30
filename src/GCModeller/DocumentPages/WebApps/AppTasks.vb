#Region "Microsoft.VisualBasic::4bf5723952939ed2adce3d4bfc07a462, win32_desktop\src\GCModeller\DocumentPages\WebApps\AppTasks.vb"

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

    '   Total Lines: 64
    '    Code Lines: 52 (81.25%)
    ' Comment Lines: 0 (0.00%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 12 (18.75%)
    '     File Size: 2.30 KB


    ' Class AppTasks
    ' 
    '     Constructor: (+1 Overloads) Sub New
    ' 
    '     Function: checkTaskList, getTaskList
    ' 
    '     Sub: openPage
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.InteropServices
Imports GCModeller
Imports Microsoft.VisualBasic.Serialization.JSON

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class AppTasks : Inherits WebApp

    Public Sub New()
        MyBase.New("/appTask.vbhtml")
    End Sub

    Public Function getTaskList() As String()
        Return TaskManager _
            .LoadTaskList(TaskManager.taskDb) _
            .Select(Function(a) a.GetJson) _
            .ToArray
    End Function

    Public Function checkTaskList() As String()
        Dim updates As New List(Of WebTask)

        For Each task As WebTask In TaskManager.LoadTaskList(TaskManager.taskDb)
            If task.status = "pending" OrElse task.status = "running" Then
                Dim check = $"http://127.0.0.1:{Globals.fastRwebPort}/check_invoke?request_id={task.session_id}".GET
                Dim flag = check.TrimNewLine.Trim.ParseBoolean

                If flag Then
                    task.logtext = $"http://127.0.0.1:{Globals.fastRwebPort}/get_invoke?request_id={task.session_id}".GET
                    task.status = "success"
                    updates.Add(task)
                End If
            End If
        Next

        If updates.Any Then
            Using taskMgr As New TaskManager(TaskManager.taskDb)
                For Each task As WebTask In updates
                    Call taskMgr.update(task.session_id, task)
                Next
            End Using
        End If

        Return updates.Select(Function(a) a.GetJson).ToArray
    End Function

    Public Sub openPage(ssid As String, taskJSON As String)
        Dim task As WebTask = taskJSON.LoadJSON(Of WebTask)
        Dim className As String = task.appName

        Static appPages As Dictionary(Of String, Type) = GetType(AppTasks).Assembly _
            .GetTypes _
            .Where(Function(t) t.IsInheritsFrom(GetType(WebApp))) _
            .ToDictionary(Function(t)
                              Return t.Name
                          End Function)

        Dim app As Type = appPages(className)
        Dim url_argv As String = $"session:{ssid}"
        Dim obj As WebApp = Activator.CreateInstance(app, url_argv)

        Call obj.Open()
    End Sub
End Class
