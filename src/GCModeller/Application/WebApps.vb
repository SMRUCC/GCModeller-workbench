Imports WeifenLuo.WinFormsUI.Docking

Public Class WebApps

    Public ReadOnly Property url As String
        Get
            Return $"http://localhost:{Globals.webViewSvrPort}/{page}"
        End Get
    End Property

    Dim page As String

    Public Shared Function OpenApp(page As String) As Boolean
        Return New WebApps() With {.page = page}.Open
    End Function

    Public Function Open() As Boolean
        If $"{Globals.webView}/{page}".FileExists Then
            Dim doc As New FormWebView2Page With {.sourceURL = url}
            doc.Show(Globals.host.dockPanel)
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Sub RemoveZoomFactor()
        Dim page = getCurrentPage()

        If page Is Nothing Then
            Call Workbench.ShowStatusMessage("No app page is opened!", My.Resources.dialog_warning)
        Else
            page.WebView21.ZoomFactor = 100
        End If
    End Sub

    Public Shared Sub SetZoomFactor(delta As Double)
        Dim page = getCurrentPage()

        If page Is Nothing Then
            Call Workbench.ShowStatusMessage("No app page is opened!", My.Resources.dialog_warning)
        Else
            page.WebView21.ZoomFactor += delta
        End If
    End Sub

    Private Shared Function getCurrentPage() As FormWebView2Page
        Dim active As DockContent = Globals.host.dockPanel.ActiveContent

        If TypeOf active Is FormWebView2Page Then
            Return active
        Else
            Return Nothing
        End If
    End Function

End Class
