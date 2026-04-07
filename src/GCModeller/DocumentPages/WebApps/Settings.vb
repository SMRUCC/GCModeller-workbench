#Region "Microsoft.VisualBasic::58665dfeeef375e754f9a9f14f466f15, win32_desktop\src\GCModeller\DocumentPages\WebApps\Settings.vb"

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

    '   Total Lines: 42
    '    Code Lines: 33 (78.57%)
    ' Comment Lines: 0 (0.00%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 9 (21.43%)
    '     File Size: 1.61 KB


    '     Class Settings
    ' 
    '         Constructor: (+1 Overloads) Sub New
    ' 
    '         Function: GetSettings
    ' 
    '         Sub: SaveSettings
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.InteropServices
Imports GCModeller_win32Desktop.Settings
Imports Microsoft.VisualBasic.MIME.application.json
Imports Microsoft.VisualBasic.MIME.application.json.Javascript
Imports Microsoft.VisualBasic.My.JavaScript

Namespace WebApps

    <ClassInterface(ClassInterfaceType.AutoDual)>
    <ComVisible(True)>
    Public Class Settings : Inherits WebApp

        Public Sub New()
            MyBase.New("/settings.vbhtml")
        End Sub

        Public Function GetSettings() As Global.GCModeller_win32Desktop.Settings.File
            Return Session.SettingsFile
        End Function

        Public Sub SaveSettings(jsonStr As String)
            Dim configs As JavaScriptObject = DirectCast(jsonStr.ParseJson, JsonObject)
            Dim config = Session.GetSettingsFile
            Dim dev2 = config.Dev2

            If dev2 Is Nothing Then
                config.Dev2 = Programs.IDE.Default
            End If

            config.BlastBin = configs(NameOf(config.BlastBin))
            config.BlastDb = configs(NameOf(config.BlastDb))
            config.RepositoryRoot = configs(NameOf(config.RepositoryRoot))

            dev2.RememberWindowStatus = configs(NameOf(dev2.RememberWindowStatus))
            dev2.IDE.Language = configs(NameOf(dev2.IDE.Language))
            dev2.StartPage.CloseAfterProjectLoad = configs(NameOf(dev2.StartPage.CloseAfterProjectLoad))
            dev2.StartPage.ShowOnStartUp = configs(NameOf(dev2.StartPage.ShowOnStartUp))

            Call Session.Finallize()
        End Sub
    End Class
End Namespace
