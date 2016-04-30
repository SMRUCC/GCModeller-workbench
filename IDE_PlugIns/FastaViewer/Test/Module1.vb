Imports LANS.SystemsBiology.SequenceModel.FASTA

Module Module1

    Sub Main()

        Dim html As String = FastaViewer.HTMLRenderer.VisualNT(New FastaFile("F:\GCModeller.Workbench\IDE_PlugIns\data\Staphylococcaceae_LexA___Staphylococcaceae.fasta").First)
        Call html.SaveTo("./test.html")

        Call New FastaViewer.FormViwer().ShowDialog()
    End Sub
End Module
