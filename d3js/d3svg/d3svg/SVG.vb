Imports System.Runtime.CompilerServices
Imports System.Text

Public Class SVG

    Public Property CSS As String
    Public Property Width As Integer
    Public Property Height As Integer
    Public Property SVGContent As String

End Class

Public Module SVGBuilder

    Const XmlHead As String = "<?xml version=""1.0"" encoding=""utf-8"" standalone=""no""?>
<!DOCTYPE svg PUBLIC ""-//W3C//DTD SVG 1.1//EN"" ""http//www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd"">
"
    Const CSS As String = "<defs><style type=""text/css""><![CDATA[
{0}
]]></style></defs>"

    <Extension>
    Public Function Build(svg As SVG) As String
        Dim sb As New StringBuilder(XmlHead)

        Call sb.AppendLine($"<svg width=""{svg.Width}px"" height=""{svg.Height}px"" version=""1.1"" xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"">")
        Call sb.AppendLine(String.Format(SVGBuilder.CSS, svg.CSS))
        Call sb.AppendLine(svg.SVGContent)
        Call sb.AppendLine("</svg>")

        Return sb.ToString
    End Function

    <Extension>
    Public Function SaveSVG(svg As SVG, path As String) As Boolean
        Return svg.Build.SaveTo(path, Encoding.UTF8)
    End Function
End Module