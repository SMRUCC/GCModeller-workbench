#Region "Microsoft.VisualBasic::210530ccecf5537e1195ff08361d72eb, win32_desktop\src\GCModeller\Forms\Tools\LoggingOutputWindow.vb"

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

    '   Total Lines: 31
    '    Code Lines: 21 (67.74%)
    ' Comment Lines: 4 (12.90%)
    '    - Xml Docs: 100.00%
    ' 
    '   Blank Lines: 6 (19.35%)
    '     File Size: 1018 B


    ' Class LoggingOutputWindow
    ' 
    '     Constructor: (+1 Overloads) Sub New
    '     Sub: LoggingOutputWindow_Load, ToolStripButton1_Click, ToolStripButton2_Click, WriteLine
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports WeifenLuo.WinFormsUI.Docking

Partial Public Class LoggingOutputWindow
    Inherits DocumentWindow

    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' 这个方法是线程安全的进行日志记录
    ''' </summary>
    ''' <param name="line"></param>
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Sub WriteLine(line As String)
        Call Invoke(Sub() textBox1.AppendText(line & vbCrLf))
    End Sub

    Private Sub LoggingOutputWindow_Load(sender As Object, e As EventArgs) Handles Me.Load
        DockState = DockState.DockBottomAutoHide
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        textBox1.WordWrap = ToolStripButton2.Checked
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        textBox1.Clear()
    End Sub
End Class

