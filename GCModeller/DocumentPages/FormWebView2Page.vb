Public Class FormWebView2Page

    Private Sub FormWebView2Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        WebView21.CoreWebView2.Navigate("https://gcmodeller.org/")
    End Sub
End Class