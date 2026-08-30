#Region "Microsoft.VisualBasic::638116a70093d1c7ed3372b41b232749, win32_desktop\src\GCModeller\DocumentPages\WebApps\Viewers\VCellDynamicsViewer.vb"

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

    '   Total Lines: 47
    '    Code Lines: 25 (53.19%)
    ' Comment Lines: 13 (27.66%)
    '    - Xml Docs: 23.08%
    ' 
    '   Blank Lines: 9 (19.15%)
    '     File Size: 1.53 KB


    ' Class VCellDynamicsViewer
    ' 
    '     Constructor: (+1 Overloads) Sub New
    '     Sub: (+2 Overloads) Dispose, runRhost
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class VCellDynamicsViewer : Inherits WebApp
    Implements IDisposable

    Dim disposedValue As Boolean
    Dim packfile As String

    Public Sub New(pack As String)
        MyBase.New("/toolkit/viewer/vcellViewer.vbhtml")
        Me.packfile = pack
    End Sub

    ''' <summary>
    ''' start the Rstudio background data host
    ''' </summary>
    Private Sub runRhost()

    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: 释放托管状态(托管对象)
            End If

            ' TODO: 释放未托管的资源(未托管的对象)并重写终结器
            ' TODO: 将大型字段设置为 null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: 仅当“Dispose(disposing As Boolean)”拥有用于释放未托管资源的代码时才替代终结器
    ' Protected Overrides Sub Finalize()
    '     ' 不要更改此代码。请将清理代码放入“Dispose(disposing As Boolean)”方法中
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' 不要更改此代码。请将清理代码放入“Dispose(disposing As Boolean)”方法中
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
