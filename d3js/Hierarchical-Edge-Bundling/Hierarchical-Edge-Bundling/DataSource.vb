Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.DocumentFormat.Csv
Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Linq

Module DataSource

    Public Function LoadAs(path As String) As FlareImports()
        Return LoadFromMaps(path)
    End Function

    Public Const fromNode As String = NameOf(fromNode)
    Public Const toNode As String = NameOf(toNode)
    Public Const Confidence As String = NameOf(Confidence)

    Public Function LoadFromMaps(path As String,
                                 Optional fromMap As String = fromNode,
                                 Optional toMap As String = toNode,
                                 Optional sizeMap As String = Confidence) As FlareImports()

        Dim maps As New Dictionary(Of String, String) From {
            {fromNode, fromMap},
            {toNode, toMap},
            {Confidence, sizeMap}
        }
        Dim interacts As IEnumerable(Of Interacts) =
            path.LoadCsv(Of Interacts)(maps:=maps)
        Dim GroupNodes = From x As Interacts
                         In interacts
                         Select x
                         Group x By x.From Into Group
        Dim __imports As FlareImports() =
            LinqAPI.Exec(Of FlareImports) <=
                From g In GroupNodes
                Let datas As Interacts() = g.Group.ToArray
                Select New FlareImports With {
                    .name = g.From,
                    .size = datas.Sum(Function(x) x.size),
                    .imports = datas.ToArray(Function(x) x.To)
                }

        Return __imports
    End Function
End Module

Public Class Interacts : Implements sIdEnumerable

    <Column(fromNode)>
    Public Property From As String Implements sIdEnumerable.Identifier
    <Column(toNode)>
    Public Property [To] As String
    <Column(Confidence)>
    Public Property size As Integer

    Public Overrides Function ToString() As String
        Return Me.GetJson
    End Function
End Class