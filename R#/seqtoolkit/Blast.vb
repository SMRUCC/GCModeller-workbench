﻿Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.TagData
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.DataMining.DynamicProgramming.NeedlemanWunsch
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Analysis.SequenceTools
Imports SMRUCC.genomics.Analysis.SequenceTools.DNA_Comparative
Imports SMRUCC.genomics.SequenceModel.FASTA

<Package("bioseq.blast")>
Module Blast

    ''' <summary>
    ''' Parse blosum from the given file data
    ''' </summary>
    ''' <param name="file">The blosum text data or text file path.</param>
    ''' <returns></returns>
    <ExportAPI("blosum")>
    Public Function ParseBlosumMatrix(Optional file$ = "Blosum-62") As Blosum
        If file = "Blosum-62" AndAlso Not file.FileExists Then
            Return Blosum.FromInnerBlosum62
        Else
            Return BlosumParser.LoadFromStream(file.SolveStream)
        End If
    End Function

    <ExportAPI("align.smith_waterman")>
    Public Function doAlign(query As FastaSeq, ref As FastaSeq, Optional blosum As Blosum = Nothing) As SmithWaterman
        Return SmithWaterman.Align(query, ref, blosum)
    End Function

    <ExportAPI("align.needleman_wunsch")>
    Public Function RunGlobalNeedlemanWunsch(query As FastaSeq, ref As FastaSeq) As FactorValue(Of Double, GlobalAlign(Of Char)())
        Dim score As Double = 0
        Dim alignments = RunNeedlemanWunsch.RunAlign(query, ref, score).ToArray

        Return (score, alignments)
    End Function

    <ExportAPI("align.gwANI")>
    Public Function gwANIMultipleAlignment(multipleSeq As FastaFile) As DataSet()
        Return gwANI.calculate_and_output_gwani(multipleSeq)
    End Function
End Module
