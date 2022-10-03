Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Text
Imports WeifenLuo.WinFormsUI.Docking

Public Class JSONContent : Inherits StringContent

    Public Sub New(json As String)
        MyBase.New(json, Encodings.UTF8WithoutBOM.CodePage, "application/json")
    End Sub
End Class

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class Message

    Public Property result As Boolean
    Public Property data As String

End Class

' 所有需要在JavaScript环境中暴露的对象
' 都需要标记上下面的两个自定义属性
<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public MustInherit Class WebApp

    Public Property arguments As Dictionary(Of String, String)

    Public Overridable ReadOnly Property url As String
        Get
            Dim baseURL As String = $"http://localhost:{Globals.webViewSvrPort}/{page.TrimStart("/"c)}"
            Dim query As String = ""

            If Not arguments.IsNullOrEmpty Then
                query = arguments _
                    .Select(Function(arg) $"{arg.Key}={arg.Value.UrlEncode(jswhitespace:=True)}") _
                    .JoinBy("&")
            End If

            Return baseURL & $"?{query}"
        End Get
    End Property

    Protected ReadOnly page As String

    Sub New(page As String)
        Me.page = page
    End Sub

    Public Function sendPost(url As String, json As String) As Message
        Dim httpClient As New HttpClient

        httpClient.DefaultRequestHeaders.Accept.Clear()
        httpClient.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

        Dim httpContent As New JSONContent(json)
        Dim response = httpClient.PostAsync(url, httpContent).Result
        Dim t As Task(Of String) = response.Content.ReadAsStringAsync
        Dim msg As New Message With {
            .data = t.Result,
            .result = response.IsSuccessStatusCode
        }

        Return msg
    End Function

    Public Overrides Function ToString() As String
        Return url
    End Function

    ''' <summary>
    ''' open current web app page on the workbench form
    ''' </summary>
    ''' <returns></returns>
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
