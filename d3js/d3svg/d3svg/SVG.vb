Imports System.Runtime.CompilerServices
Imports System.Text

Public Class SVG

    Public Property CSS As String
    Public Property Width As Integer
    Public Property Height As Integer
    Public Property SVGContent As String

End Class

Public Module SVGBuilder

    <Extension>
    Public Function Build(svg As SVG) As String
        Dim sb As New StringBuilder

        Return sb.ToString
    End Function
End Module