#Region "Microsoft.VisualBasic::9c3a72117469aba2e82c85068dfda92d, win32_desktop\src\GCModeller\Forms\FormMainHost.vb"

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

    '   Total Lines: 89
    '    Code Lines: 65 (73.03%)
    ' Comment Lines: 3 (3.37%)
    '    - Xml Docs: 0.00%
    ' 
    '   Blank Lines: 21 (23.60%)
    '     File Size: 2.99 KB


    ' Class FormMainHost
    ' 
    '     Constructor: (+1 Overloads) Sub New
    ' 
    '     Function: FindDocument
    ' 
    '     Sub: CloseAllDocuments, EnableVSRenderer, FormMainHost_Closed, FormMainHost_Closing, FormMainHost_Load
    '          ShowMainPage
    ' 
    ' /********************************************************************************/

#End Region

Imports System.ComponentModel
Imports GCModeller_win32Desktop.Settings
Imports RibbonLib.Interop
Imports WeifenLuo.WinFormsUI.Docking

Public Class FormMainHost

    Private ReadOnly _toolStripProfessionalRenderer As New ToolStripProfessionalRenderer()

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AutoScaleMode = AutoScaleMode.Dpi
        vsToolStripExtender1.DefaultRenderer = _toolStripProfessionalRenderer
    End Sub

    Private Sub FormMainHost_Load(sender As Object, e As EventArgs) Handles Me.Load
        dockPanel.Theme = vS2015LightTheme1
        Globals.host = Me
        Me.Text = "GCModeller Workbench"

        Call New FormSplashScreen() With {.splash = True}.ShowDialog()
        Call Workbench.LogTextOutput.Show(Globals.host.dockPanel)

        EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015LightTheme1)

        ' apply settings
        Dim config = Session.GetSettingsFile.Dev2

        If config.StartPage.ShowOnStartUp Then
            ShowMainPage()
        End If

        If config.RememberWindowStatus Then
            If Not config.IDE.Size.IsEmpty Then
                Me.Size = config.IDE.Size
            End If
            If Not config.IDE.Location.IsEmpty Then
                Me.Location = config.IDE.Location
            End If
        End If

        Workbench.Ribbon.GroupDatabase.ContextAvailable = ContextAvailability.Active
    End Sub

    Public Sub ShowMainPage()
        Call WebApp.Open(Of MainIndex)()
    End Sub

    Private Function FindDocument(ByVal text As String) As IDockContent
        If dockPanel.DocumentStyle = DocumentStyle.SystemMdi Then
            For Each form In MdiChildren
                If Equals(form.Text, text) Then Return TryCast(form, IDockContent)
            Next

            Return Nothing
        Else

            For Each content In dockPanel.Documents
                If Equals(content.DockHandler.TabText, text) Then Return content
            Next

            Return Nothing
        End If
    End Function

    Public Sub CloseAllDocuments()
        For Each form As DockContent In dockPanel.Documents.ToArray
            If TypeOf form Is FormWebView2Page AndAlso form.DockState = DockState.Document Then
                Call form.Close()
            End If
        Next
    End Sub

    Private Sub EnableVSRenderer(version As VisualStudioToolStripExtender.VsVersion, theme As ThemeBase)
        vsToolStripExtender1.SetStyle(StatusStrip1, version, theme)
    End Sub

    Private Sub FormMainHost_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Call My.MyApplication.SaveSession()
    End Sub

    Private Sub FormMainHost_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Call App.Exit()
    End Sub
End Class

