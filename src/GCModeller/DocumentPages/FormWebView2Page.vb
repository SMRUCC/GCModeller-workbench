Imports WeifenLuo.WinFormsUI.Docking

Public Class FormWebView2Page

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AutoScaleMode = AutoScaleMode.Dpi
        DockAreas = DockAreas.Document Or DockAreas.Float
    End Sub

    Private Sub FormWebView2Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        WebView21.CoreWebView2.Navigate("https://gcmodeller.org/")
    End Sub
End Class