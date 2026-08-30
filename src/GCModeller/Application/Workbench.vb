#Region "Microsoft.VisualBasic::779a98b810e08a2c6c7621bc144f8674, win32_desktop\src\GCModeller\Application\Workbench.vb"

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

    '   Total Lines: 56
    '    Code Lines: 46 (82.14%)
    ' Comment Lines: 0 (0.00%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 10 (17.86%)
    '     File Size: 2.53 KB


    ' Class Workbench
    ' 
    '     Properties: Ribbon
    ' 
    '     Sub: addRibbonEvents, Load, OpenFile, ShowStatusMessage
    ' 
    ' /********************************************************************************/

#End Region

Imports GCModeller_win32Desktop.RibbonLib.Controls

Public Class Workbench

    Friend Shared ReadOnly Property Ribbon As RibbonItems
    Friend Shared ReadOnly LogTextOutput As New LoggingOutputWindow

    Public Shared Sub Load()
        _Ribbon = New RibbonItems(Globals.host.Ribbon1)

        Call addRibbonEvents()
    End Sub

    Private Shared Sub addRibbonEvents()
        AddHandler Ribbon.About.ExecuteEvent, Sub() Call New FormSplashScreen().Show()
        AddHandler Ribbon.Open.ExecuteEvent, Sub() Call OpenFile()

        AddHandler Ribbon.ButtonEnrichmentDatabase.ExecuteEvent, Sub() Call WebApp.Open(Of EnrichmentDatabase)()
        AddHandler Ribbon.ButtonNCBITaxonomy.ExecuteEvent, Sub() Call WebApp.Open(Of ImportsNCBITaxonomy)()
        AddHandler Ribbon.ViewAppTasks.ExecuteEvent, Sub() Call WebApp.Open(Of AppTasks)()
        AddHandler Ribbon.ButtonStartPage.ExecuteEvent, Sub() Call Globals.host.ShowMainPage()
        AddHandler Ribbon.PageSetup.ExecuteEvent, Sub() Call WebApp.Open(Of WebApps.Settings)()

        AddHandler Ribbon.ZoomIn.ExecuteEvent, Sub() Call WebApp.SetZoomFactor(5)
        AddHandler Ribbon.ZoomOut.ExecuteEvent, Sub() Call WebApp.SetZoomFactor(-5)
        AddHandler Ribbon.Zoom100Percent.ExecuteEvent, Sub() Call WebApp.RemoveZoomFactor()
    End Sub

    Public Shared Sub ShowStatusMessage(msg As String, Optional icon As Image = Nothing)
        Globals.host.Invoke(
            Sub()
                If Not icon Is Nothing Then
                    Globals.host.ToolStripStatusLabel1.Image = icon
                Else
                    Globals.host.ToolStripStatusLabel1.Image = My.Resources.user_invisible
                End If

                Globals.host.ToolStripStatusLabel1.Text = msg
            End Sub)
    End Sub

    Public Shared Sub OpenFile()
        Using file As New OpenFileDialog With {
            .Filter = "GCModeller Virtual Cell Simulator Output(*.vcellPack)|*.vcellPack"
        }
            If file.ShowDialog = DialogResult.OK Then
                Select Case file.FileName.ExtensionSuffix
                    Case "vcellpack"
                        Call New VCellDynamicsViewer(file.FileName).Open()
                    Case Else
                        MessageBox.Show("The file type that you specific has not been implemented yet!", "File Reader Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select
            End If
        End Using
    End Sub
End Class
