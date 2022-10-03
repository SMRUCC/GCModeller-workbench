
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Serialization.JSON

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class ImportsUniprot : Inherits WebApp

    Public Sub New()
        MyBase.New("/toolkit/enrichment_database.html")
    End Sub

    Public Function getUniprotXmlDatabase() As String
        Try
            Using file As New OpenFileDialog With {.Filter = "UniProt Xml dataset(*.xml)|*.xml"}
                If file.ShowDialog = DialogResult.OK Then
                    Return file.FileName
                Else
                    Return Nothing
                End If
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

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


        Return True
    End Function
End Class
