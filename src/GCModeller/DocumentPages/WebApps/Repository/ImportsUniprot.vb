
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Serialization.JSON

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class ImportsUniprot : Inherits WebApp

    Public Sub New()
        MyBase.New("/toolkit/enrichment_database.vbhtml")
    End Sub

    Public Function scanDatabase() As String
        Dim list = "/etc/repository/".ListFiles("*.json").Where(Function(json) json.ChangeSuffix("db").FileExists()).ToArray
        Dim metadata = list _
            .ToDictionary(Function(path) path.BaseName,
                          Function(path)
                              Return path.LoadJsonFile(Of Dictionary(Of String, String))
                          End Function)

        Return metadata.GetJson
    End Function

    Public Function openEnrichmentPage(database As String, name As String, note As String) As Boolean
        Dim app As New RunEnrichment With {
            .arguments = New Dictionary(Of String, String) From {
                {"id", database},
                {"name", name},
                {"note", note}
            }
        }

        Return app.Open
    End Function
End Class
