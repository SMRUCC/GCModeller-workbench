
Imports System.Runtime.InteropServices

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

End Class
