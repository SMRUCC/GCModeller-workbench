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

End Class
