﻿Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Runtime.InteropServices
Imports GCModeller
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.ValueTypes
Imports WeifenLuo.WinFormsUI.Docking

' 所有需要在JavaScript环境中暴露的对象
' 都需要标记上下面的两个自定义属性
<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public MustInherit Class WebApp

    ''' <summary>
    ''' additional url query parameters, the parameter value is no needs to
    ''' do escaping, the <see cref="url"/> will do this job automatically.
    ''' </summary>
    ''' <returns></returns>
    Public Property arguments As Dictionary(Of String, String)

    Public Overridable ReadOnly Property icon As Icon
        Get
            Return Icon.FromHandle(My.Resources.applications_utilities.GetHicon)
        End Get
    End Property

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

    Public Function getFileOpen(Optional filterString As String = "Any File(*.*)|*.*") As String
        Try
            Using file As New OpenFileDialog With {.Filter = filterString}
                If file.ShowDialog = DialogResult.OK Then
                    Return file.FileName
                Else
                    Return Nothing
                End If
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function getFileSave(Optional filterString As String = "Any File(*.*)|*.*") As String
        Try
            Using file As New SaveFileDialog With {.Filter = filterString}
                If file.ShowDialog = DialogResult.OK Then
                    Return file.FileName
                Else
                    Return Nothing
                End If
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function getFolderOpen() As String
        Try
            Using folder As New FolderBrowserDialog
                If folder.ShowDialog = DialogResult.OK Then
                    Return folder.SelectedPath
                Else
                    Return Nothing
                End If
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' api for generates unique id for javascript client
    ''' </summary>
    ''' <returns></returns>
    Public Function getNextUniqueId() As String
        Return App.GetNextUniqueName($"gcmodeller_session_{App.PID}.{Now.UnixTimeStamp}.")
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="title"></param>
    ''' <param name="url">
    ''' this url should contains the url query parameter: ``rweb_background=true``.
    ''' </param>
    ''' <param name="json"></param>
    ''' <returns></returns>
    Public Async Function createTask(title As String, url As String, json As String) As Task(Of Message)
        Dim task As New WebTask With {
            .appName = Me.GetType.Name,
            .arguments = json.LoadJSON(Of Dictionary(Of String, String)),
            .status = "pending",
            .time = Now.ToString,
            .title = title,
            .url = url
        }
        Dim queue As Message = Await sendPost(url, json)
        Dim request_id As String = queue.data

        task.session_id = request_id.TrimNewLine.Trim

        Using taskMgr As New TaskManager(file:=TaskManager.taskDb)
            Call taskMgr.add(task)
        End Using

        Return queue
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="url"></param>
    ''' <param name="json"></param>
    ''' <returns>
    ''' the data of the message is the text content of the web api return
    ''' and then message result is a boolean value that indicated that
    ''' the http response is a success status code?
    ''' </returns>
    Public Async Function sendPost(url As String, json As String) As Task(Of Message)
        Dim httpClient As New HttpClient

        httpClient.DefaultRequestHeaders.Accept.Clear()
        httpClient.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
        httpClient.Timeout = TimeSpan.FromDays(1)

        Call Workbench.LogTextOutput.WriteLine($"POST {url}")
        Call Workbench.LogTextOutput.WriteLine($"  -> payload: {json}")

        Dim httpContent As New JSONContent(json)
        Dim response = httpClient.PostAsync(url, httpContent).Result
        Dim t As String = Await response.Content.ReadAsStringAsync
        Dim msg As New Message With {
            .data = t,
            .result = response.IsSuccessStatusCode
        }

        Call Workbench.LogTextOutput.WriteLine($"  <- {response.Content.Headers.ToString}")

        Return msg
    End Function

    Public Sub jumptoTaskManager()
        Dim hitAny As Boolean = False

        For Each page As IDockContent In Globals.host.dockPanel.Documents
            If TypeOf page Is FormWebView2Page Then
                If TypeOf DirectCast(page, FormWebView2Page).backend Is AppTasks Then
                    DirectCast(page, FormWebView2Page).DockState = DockState.Document
                    DirectCast(page, FormWebView2Page).Activate()
                    DirectCast(page, FormWebView2Page).Show(Globals.host.dockPanel)

                    hitAny = True
                End If
            End If
        Next

        If Not hitAny Then
            Call WebApp.Open(Of AppTasks)()
        End If
    End Sub

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
