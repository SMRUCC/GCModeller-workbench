Public Class ImportsNCBITaxonomy : Inherits WebApp

    Public Sub New()
        MyBase.New("/toolkit/ncbi_taxonomy.html")
    End Sub

    Public Overrides ReadOnly Property url As String
End Class
