Imports LANS.SystemsBiology.SequenceModel.FASTA
Imports Microsoft.VisualBasic.Windows.Forms

Public Class FormViwer

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ToolStripManager.Renderer = New ChromeUIRender
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Using open As New OpenFileDialog With {.Filter = ""}
            If open.ShowDialog = DialogResult.OK Then
                Dim fa As New FastaFile(open.FileName)
                Dim html As String = HTMLRenderer.VisualNts(fa)
                Dim tmp As String = App.GetAppSysTempFile(".html")
                Call html.SaveTo(tmp)
                Call WebBrowser1.Navigate(tmp)
            End If
        End Using
    End Sub

    Private Sub FormViwer_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class
