Imports Microsoft.VisualBasic.Serialization.JSON
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH

Public Class BlastpViewer : Inherits WebApp

    ReadOnly blastdata As Dictionary(Of String, BestHit())

    Public Sub New(blastdata As BestHit())
        MyBase.New("/toolkit/viewer/blastp.vbhtml")

        Me.blastdata = blastdata _
            .GroupBy(Function(a) a.QueryName) _
            .ToDictionary(Function(prot) prot.Key,
                          Function(hits)
                              Return hits.ToArray
                          End Function)
    End Sub

    Public Function getProteinIDs() As String()
        Return blastdata.Keys.ToArray
    End Function

    Public Function getBlastp(id As String) As String
        Return blastdata(id).GetJson
    End Function
End Class
