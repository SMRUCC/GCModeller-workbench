Imports LANS.SystemsBiology.AnalysisTools.SequenceTools.SequencePatterns
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

    Dim file As String

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Using open As New OpenFileDialog With {
            .Title = "Select a fasta sequence file",
            .Filter = "Fasta sequence file(*.fasta,*.fa,*.fsa,*.fas)|*.fasta;*.fa;*.fsa;*.fas"
        }
            If open.ShowDialog = DialogResult.OK Then
                Dim fa As New FastaFile(open.FileName)
                Dim html As String = HTMLRenderer.VisualNts(fa)
                Dim tmp As String = App.GetAppSysTempFile(".html")
                Call html.SaveTo(tmp)
                Call WebBrowser1.Navigate(tmp)

                file = open.FileName
            End If
        End Using
    End Sub

    Private Sub FormViwer_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Call Process.Start("https://github.com/SMRUCC/GCModeller.Workbench")
    End Sub

    Private Sub SequenceLogoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SequenceLogoToolStripMenuItem.Click
        Dim fa As New FastaFile(file)
        Dim l As Integer = fa.First.Length
        For Each x In fa
            If x.Length <> l Then
                MsgBox("The fasta sequence length is not identical!")
                Return
            End If
        Next

        Dim logo As Image = SequenceLogo.DrawingDevice.DrawFrequency(fa)
        PictureBox1.BackgroundImage = logo
    End Sub
End Class
