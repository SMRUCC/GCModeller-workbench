﻿
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Analysis.HTS.DataFrame
Imports SMRUCC.genomics.GCModeller.Workbench.ExperimentDesigner

<Package("geneExpression")>
Module geneExpression

    Sub New()

    End Sub

    ''' <summary>
    ''' load an expressin matrix data
    ''' </summary>
    ''' <param name="file$"></param>
    ''' <param name="exclude_samples"></param>
    ''' <returns></returns>
    <ExportAPI("load.expr")>
    Public Function loadExpression(file$, Optional exclude_samples As String() = Nothing) As Matrix
        Return Matrix.LoadData(file, If(exclude_samples Is Nothing, Nothing, New Index(Of String)(exclude_samples)))
    End Function

    <ExportAPI("average")>
    Public Function average(matrix As Matrix, sampleinfo As SampleInfo()) As Matrix
        Return Matrix.MatrixAverage(matrix, sampleinfo)
    End Function
End Module
