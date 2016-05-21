Imports d3svg

Module Program

    Sub Main()
        Dim parser As D3Parser = New ForceDirectedGraph
        Dim svg As SVG = parser.HtmlFileParser("F:\GCModeller.Workbench\d3js\d3svg\data\Hierarchical-Edge-Bundling.htm")
        '   svg = parser.HtmlParser("http://127.0.0.1".GET)
        Call svg.Build.SaveTo("./test.svg")
        Dim model = svg.BuildModel
        Call model.SaveAsXml("F:\GCModeller.Workbench\d3js\d3svg\data\Hierarchical-Edge-Bundling.svg")

        Dim dev As New d3svg.DrawSVG("F:\GCModeller.Workbench\IDE_PlugIns\d3jsViewer")
        Call dev.RasterizeSvg("F:\GCModeller.Workbench\d3js\d3svg\data\Hierarchical-Edge-Bundling.svg", "F:\GCModeller.Workbench\d3js\d3svg\data\Hierarchical-Edge-Bundling.png")

    End Sub
End Module
