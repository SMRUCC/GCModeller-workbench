Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.ComponentModel.Loci

<Package("annotation.genomics_context", Category:=APICategories.ResearchTools)>
Module context

    <ExportAPI("location")>
    Public Function location(left As Integer, right As Integer, Optional strand As Object = Nothing) As Object
        Dim strVal As Strands

        If strand Is Nothing Then
            strVal = Strands.Unknown
        ElseIf TypeOf strand Is Strands Then
            strVal = strand
        Else
            strVal = Scripting.ToString(strand).GetStrand
        End If

        Return New NucleotideLocation(left, right, strVal)
    End Function
End Module
