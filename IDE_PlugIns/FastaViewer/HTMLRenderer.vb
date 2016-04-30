Imports System.Text
Imports LANS.SystemsBiology.SequenceModel.FASTA

Public Module HTMLRenderer

    Public Const A As String = "<span style=""color:red"">A</span>"
    Public Const T As String = "<span style=""color:green"">T</span>"
    Public Const G As String = "<span style=""color:orange"">G</span>"
    Public Const C As String = "<span style=""color:blue"">C</span>"

    Public ReadOnly Property Nt As Dictionary(Of Char, String) =
        New Dictionary(Of Char, String) From {
 _
        {"A"c, A}, {"T"c, T}, {"G"c, G}, {"C"c, C}
    }

    Public Function VisualNT(nt As FastaToken) As String
        Dim sb As New StringBuilder(4096)

        For Each r As Char In nt.SequenceData.ToUpper
            If HTMLRenderer.Nt.ContainsKey(r) Then
                sb.Append(HTMLRenderer.Nt(r))
            Else
                sb.Append(r)
            End If
        Next

        Return sb.ToString
    End Function

    Public Function VisualNts(file As FastaFile) As String

    End Function
End Module
