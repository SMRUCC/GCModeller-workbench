Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports RawViewer
Imports SMRUCC.genomics.GCModeller.ModellingEngine.IO.Raw
Imports SMRUCC.Rsharp.Runtime

<Package("Inspector")>
Module Inspector

    <ExportAPI("load")>
    Public Function LoadViewer(pack As Object, Optional env As Environment = Nothing) As Object
        If pack Is Nothing Then
            Return Internal.debug.stop("the required data pack could not be nothing!", env)
        End If

        If TypeOf pack Is Reader Then
            Return New PackViewer(DirectCast(pack, Reader))
        Else
            Return Internal.debug.stop(New NotImplementedException, env)
        End If
    End Function
End Module
