Imports System.Drawing
Imports System.Text.RegularExpressions

Public Class ForceDirectedGraph : Inherits D3Parser

    Const Style As String = "<style>.+?</style>"

    Protected Overrides Function __css(html As String) As String
        Dim style As String = Regex.Match(html, ForceDirectedGraph.Style, RegexICSng).Value
        style = style.GetValue
        Return style
    End Function

    Protected Overrides Function __propParser(html As String) As Size

    End Function

    Protected Overrides Function __svgNode(html As String) As String

    End Function
End Class
