Imports WeifenLuo.WinFormsUI.Docking

Public MustInherit Class WebApp

    Public Overridable ReadOnly Property url As String
        Get
            Return $"http://localhost:{Globals.webViewSvrPort}/{page.TrimStart("/"c)}"
        End Get
    End Property

    Protected ReadOnly page As String

    Sub New(page As String)
        Me.page = page
    End Sub

    Public Function Open() As Boolean
        If $"{Globals.webView}/{page}".FileExists Then
            Dim doc As New FormWebView2Page With {
                .sourceURL = url,
                .backend = Me
            }

            Call doc.Show(Globals.host.dockPanel)

            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function Open(Of app As {New, WebApp})() As Boolean
        Return New app().Open
    End Function

    Public Shared Sub RemoveZoomFactor()
        Dim page = getCurrentPage()

        If page Is Nothing Then
            Call Workbench.ShowStatusMessage("No app page is opened!", My.Resources.dialog_warning)
        Else
            page.WebView21.ZoomFactor = 1
        End If
    End Sub

    Public Shared Sub SetZoomFactor(delta As Double)
        Dim page = getCurrentPage()

        If page Is Nothing Then
            Call Workbench.ShowStatusMessage("No app page is opened!", My.Resources.dialog_warning)
        Else
            Try
                page.WebView21.ZoomFactor += delta / 100
            Catch ex As Exception
                Call Workbench.ShowStatusMessage(ex.Message, My.Resources.dialog_warning)
            End Try
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
