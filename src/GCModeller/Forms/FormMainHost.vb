﻿Imports WeifenLuo.WinFormsUI.Docking

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
        Me.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015LightTheme1)
        OpenDocument()
    End Sub

    Public Sub OpenDocument()
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
End Class
