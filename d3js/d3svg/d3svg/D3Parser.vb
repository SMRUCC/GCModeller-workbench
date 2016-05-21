Imports System.Drawing

Public MustInherit Class D3Parser

    Public Function HtmlParser(html As String) As SVG
        Dim svg As New SVG With {
            .CSS = __css(html.ReadAllText().ShadowCopy(html)),
            .SVGContent = __svgNode(html),
            .Size = __propParser(html)
        }
        Return svg
    End Function

    Protected MustOverride Function __css(html As String) As String
    Protected MustOverride Function __svgNode(html As String) As String
    Protected MustOverride Function __propParser(html As String) As Size
End Class
