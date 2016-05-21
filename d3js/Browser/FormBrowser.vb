Imports Gecko

Public Class FormBrowser

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Xpcom.Initialize("./")
        geckoWebBrowser = New GeckoWebBrowser With {.Dock = DockStyle.Fill}
        Controls.Add(geckoWebBrowser)

        geckoWebBrowser.Navigate("http://127.0.0.1")
    End Sub
    Dim geckoWebBrowser As GeckoWebBrowser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        geckoWebBrowser.SaveDocument("x:\fffff.html")
    End Sub
End Class
