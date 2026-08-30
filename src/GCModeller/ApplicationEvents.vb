#Region "Microsoft.VisualBasic::ba74174b4abf643427f1ceba95409174, win32_desktop\src\GCModeller\ApplicationEvents.vb"

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

    '   Total Lines: 36
    '    Code Lines: 23 (63.89%)
    ' Comment Lines: 6 (16.67%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 7 (19.44%)
    '     File Size: 1.78 KB


    '     Class MyApplication
    ' 
    '         Sub: ConfigRStudioConfiguration, SaveSession
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports GCModeller_win32Desktop.Settings.Programs.IDE
Imports Microsoft.VisualBasic.ApplicationServices
Imports Rserver.RscriptCommandLine
Imports AppSession = GCModeller_win32Desktop.Settings.Session

Namespace My

    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Public Shared Sub SaveSession()
            Dim configs = AppSession.GetSettingsFile
            Dim pos As Point = Globals.host.Location
            Dim size As Size = Globals.host.Size

            configs.Dev2.IDE.Size = New IDEConfig.SizeF With {.Width = size.Width, .Height = size.Height}
            configs.Dev2.IDE.Location = New IDEConfig.PointF With {.Left = pos.X, .Top = pos.Y}

            Call AppSession.Finallize()
        End Sub

        Public Shared Sub ConfigRStudioConfiguration()
            Dim rpath As String = $"{App.HOME}/../src/Rstudio/config.R"
            Dim host As Rscript = Rscript.FromEnvironment($"{App.HOME}/Rstudio/bin")
            Dim arguments As String = $"--config {AppSession.SettingsDir.CLIPath}"

            Call host.SetDotNetCoreDll()
            Call host.RunDotNetApp($"{rpath.CLIPath} {arguments}").Run()
        End Sub
    End Class
End Namespace
