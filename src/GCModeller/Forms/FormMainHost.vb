Imports System.ComponentModel
Imports GCModeller_win32Desktop.RibbonLib.Controls
Imports RibbonLib
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

        Call WebApps.OpenApp("/apps/enrichment.html")

        Workbench.Ribbon.GroupDatabase.ContextAvailable = ContextAvailability.Active
    End Sub

    Public Sub ShowMainPage()
        Dim doc As New FormWebView2Page
        doc.Show(dockPanel)
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

    Private Sub CloseAllDocuments()
        If dockPanel.DocumentStyle = DocumentStyle.SystemMdi Then
            For Each form In MdiChildren
                form.Close()
            Next
        Else

            For Each document In dockPanel.DocumentsToArray()
                ' IMPORANT: dispose all panes.
                document.DockHandler.DockPanel = Nothing
                document.DockHandler.Close()
            Next
        End If
    End Sub

    Private Sub EnableVSRenderer(version As VisualStudioToolStripExtender.VsVersion, theme As ThemeBase)
        vsToolStripExtender1.SetStyle(StatusStrip1, version, theme)
    End Sub

    Private Sub FormMainHost_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub FormMainHost_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Call App.Exit()
    End Sub
End Class
