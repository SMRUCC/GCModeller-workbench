Imports Microsoft.Web.WebView2.Core
Imports WeifenLuo.WinFormsUI.Docking

Public Class FormWebView2Page

    Public Property sourceURL As String = "https://gcmodeller.org/"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AutoScaleMode = AutoScaleMode.Dpi
        DockAreas = DockAreas.Document Or DockAreas.Float
    End Sub

    Private Sub FormWebView2Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Init()
        Wait()
    End Sub

    Public Sub DeveloperOptions(enable As Boolean)
        WebView21.CoreWebView2.Settings.AreDevToolsEnabled = enable
        WebView21.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = enable
        WebView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = enable

        If enable Then
            Call Workbench.ShowStatusMessage($"[{TabText}] WebView2 developer tools has been enable!")
        End If
    End Sub

    Private Async Sub Init()
        Dim userDataFolder = (App.ProductProgramData & "/.webView2_cache/").GetDirectoryFullPath
        Dim env = Await CoreWebView2Environment.CreateAsync(Nothing, userDataFolder)

        Call Workbench.ShowStatusMessage($"set webview2 cache at '{userDataFolder}'.")

        Await WebView21.EnsureCoreWebView2Async(env)
    End Sub

    Private Sub Wait()

    End Sub

    Private Sub WebView21_CoreWebView2InitializationCompleted(sender As Object, e As CoreWebView2InitializationCompletedEventArgs) Handles WebView21.CoreWebView2InitializationCompleted
        WebView21.CoreWebView2.Navigate(sourceURL)

#If Not DEBUG Then
        Call DeveloperOptions(enable:=False)
#End If
    End Sub

    Private Sub WebView21_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WebView21.NavigationCompleted
        Me.Text = WebView21.CoreWebView2.DocumentTitle
        Me.TabText = Me.Text
    End Sub
End Class