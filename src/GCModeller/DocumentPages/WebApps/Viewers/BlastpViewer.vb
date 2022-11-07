Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH

Public Class BlastpViewer : Inherits WebApp

    ReadOnly blastdata As BestHit()

    Public Sub New(blastdata As BestHit())
        MyBase.New("/toolkit/viewer/blastp.vbhtml")
        Me.blastdata = blastdata
    End Sub
End Class
