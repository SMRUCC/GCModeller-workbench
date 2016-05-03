Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call NetworkGenerator.LoadJson("G:\1.13.RegPrecise_network\Cellular Phenotypes\KEGG_Modules-SimpleModsNET").SaveTo("F:\GCModeller.Workbench\d3js\Force-Directed Graph\test.json")
    End Sub
End Class
