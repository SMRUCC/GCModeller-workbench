Imports Microsoft.VisualBasic.Net.Http
Imports Microsoft.Web.WebView2.Core
Imports WeifenLuo.WinFormsUI.Docking

Public Class FormWebView2Page

    Public Property sourceURL As String = "https://gcmodeller.org/"
    Public Property backend As WebApp

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AutoScaleMode = AutoScaleMode.Dpi
        DockAreas = DockAreas.Document Or DockAreas.Float
        TabText = "Loading WebView2 App..."
    End Sub

    Private Sub FormWebView2Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not backend Is Nothing Then
            Me.Icon = backend.icon
        End If

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
        If Not backend Is Nothing Then
            WebView21.CoreWebView2.AddHostObjectToScript("gcmodeller", backend)
        End If

        ' WebView21.CoreWebView2.OpenDevToolsWindow()
        WebView21.CoreWebView2.Navigate(sourceURL)

        Call DeveloperOptions(enable:=True)
    End Sub

    Private Sub WebView21_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WebView21.NavigationCompleted
        Me.Text = WebView21.CoreWebView2.DocumentTitle
        Me.TabText = Me.Text
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        If MessageBox.Show("Close current app page?", "Workbench WebView", buttons:=MessageBoxButtons.OKCancel, icon:=MessageBoxIcon.Information) = DialogResult.OK Then
            Call Me.Close()
        End If
    End Sub

    Private Sub ReloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReloadToolStripMenuItem.Click
        If MessageBox.Show("Reload of current app page will lost all of the session information.", "Workbench WebView", buttons:=MessageBoxButtons.OKCancel, icon:=MessageBoxIcon.Information) = DialogResult.OK Then
            Call WebView21.Reload()
        End If
    End Sub

    ''' <summary>
    ''' open external link in default webbrowser
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub WebView21_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles WebView21.NavigationStarting
        Dim url As New URL(e.Uri)

        If url.hostName <> "127.0.0.1" AndAlso url.hostName <> "localhost" Then
            e.Cancel = True
            Process.Start(e.Uri)
        End If
    End Sub
End Class