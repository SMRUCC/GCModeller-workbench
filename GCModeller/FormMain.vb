Imports System.ComponentModel
Imports CefSharp
Imports CefSharp.WinForms

Public Class FormMain

    Dim WithEvents browser As ChromiumWebBrowser

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim settings As New CefSettings()
        Dim browserSettings As New BrowserSettings()

        Call Cef.Initialize(settings)

        browser = New ChromiumWebBrowser("https://gcmodeller.org/") With {
           .Dock = DockStyle.Fill,
           .BrowserSettings = browserSettings
        }

        Controls.Add(browser)
    End Sub

    Private Sub FormMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Call Cef.Shutdown()
    End Sub
End Class
