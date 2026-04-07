#Region "Microsoft.VisualBasic::70a298f8151247f8639e60aa5d6b60a0, win32_desktop\src\GCModeller\Forms\FormSplashScreen.vb"

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
    '    Code Lines: 22 (75.86%)
    ' Comment Lines: 0 (0.00%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 7 (24.14%)
    '     File Size: 796 B


    ' Class FormSplashScreen
    ' 
    '     Properties: splash
    ' 
    '     Sub: FormSplashScreen_Deactivate, FormSplashScreen_Load, FormSplashScreen_LostFocus, InitLoad
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Threading
Imports Microsoft.VisualBasic.Parallel

Public Class FormSplashScreen

    Public Property splash As Boolean = False

    Private Sub FormSplashScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        If splash Then
            Call RunTask(AddressOf InitLoad)
        End If
    End Sub

    Private Sub InitLoad()
        Call Globals.Load()
        Call Thread.Sleep(1500)
        Call Me.Invoke(Sub() Close())
    End Sub

    Private Sub FormSplashScreen_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus

    End Sub

    Private Sub FormSplashScreen_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        If Not splash Then
            Call Me.Close()
        End If
    End Sub
End Class
