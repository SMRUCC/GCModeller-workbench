Imports Microsoft.VisualBasic.Windows.Forms

Public Class FormHEBViewer

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ToolStripManager.Renderer = New ChromeUIRender
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

    End Sub
End Class
