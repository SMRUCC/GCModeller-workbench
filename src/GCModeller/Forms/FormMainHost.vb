﻿Imports System.ComponentModel
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
