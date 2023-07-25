Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports RawViewer
Imports SMRUCC.genomics.GCModeller.ModellingEngine.IO.Raw
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Internal.Object
Imports SMRUCC.Rsharp.Runtime.Interop
Imports SMRUCC.Rsharp.Runtime.Vectorization

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

    <ExportAPI("counts")>
    Public Function counts(pack As PackViewer) As Object
        Return New list With {
            .slots = pack _
                .GetCounts _
                .ToDictionary(Function(a) a.Key,
                              Function(a)
                                  Return CObj(a.Value)
                              End Function)
        }
    End Function

    <ExportAPI("load.molecule_list")>
    Public Function LoadMoleculeList(pack As PackViewer,
                                     <RRawVectorArgument>
                                     Optional [module] As Object = Nothing,
                                     Optional env As Environment = Nothing) As Object

        Dim mols = pack.GetMoleculeIdset
        Dim modNames As String() = CLRVector.asCharacter([module])

        If modNames.IsNullOrEmpty Then
            Return New list With {
                .slots = mols.ToDictionary(Function(a) a.Key, Function(a) CObj(a.Value))
            }
        Else
            Return New list With {
                .slots = modNames _
                    .ToDictionary(Function(a) a,
                                  Function(a)
                                      Return CObj(mols(a))
                                  End Function)
            }
        End If
    End Function
End Module
