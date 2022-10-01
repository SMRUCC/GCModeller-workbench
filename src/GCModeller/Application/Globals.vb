Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CommandLine.InteropService.Pipeline
Imports Microsoft.VisualBasic.Parallel

Public Class Globals

    Friend Shared host As FormMainHost

    Shared wwwroot As RunSlavePipeline

    Public Shared ReadOnly webview As Integer = 19612

    Public Shared Sub Load()
        Call Globals.startWebServices()
        Call Workbench.Load()
    End Sub

    Private Shared Sub startWebServices()
        Dim host = Rserver.RscriptCommandLine.Rscript.FromEnvironment($"{App.HOME}/Rstudio/bin")
        Dim http_server As String = $"{App.HOME}/../src\Rstudio\http.R"
        Dim webView As String = $"{App.HOME}/../web/"
        Dim rpkg As String = $"{App.HOME}/Rstudio/packages/Rserver.zip"
        Dim commandLine As String = $"{http_server.CLIPath} --listen {webView} --wwwroot {webView.CLIPath} --attach {rpkg.CLIPath}"

        wwwroot = host.CreateSlave(commandLine)

        Call RunTask(AddressOf wwwroot.Run)
    End Sub

End Class
