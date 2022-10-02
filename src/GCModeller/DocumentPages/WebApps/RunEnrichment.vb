Public Class RunEnrichment : Inherits WebApp

    Public Sub New()
        MyBase.New("/apps/enrichment.html")
    End Sub

    Public Overrides ReadOnly Property url As String
End Class
