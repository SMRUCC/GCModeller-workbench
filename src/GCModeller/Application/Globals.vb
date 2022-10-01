Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CommandLine.InteropService.Pipeline
Imports Microsoft.VisualBasic.Parallel

Public Class Globals

    Friend Shared host As FormMainHost

    Shared wwwroot As RunSlavePipeline

    Public Shared ReadOnly webViewSvrPort As Integer = 19612
    Public Shared ReadOnly webView As String

    Shared Sub New()
        webView = $"{App.HOME}/../web/".GetDirectoryFullPath
    End Sub

    Public Shared Sub Load()
        Call Workbench.Load()
        Call Globals.startWebServices()
    End Sub

    Private Shared Sub startWebServices()
        Dim host = Rserver.RscriptCommandLine.Rscript.FromEnvironment($"{App.HOME}/Rstudio/bin")
        Dim http_server As String = $"{App.HOME}/../src\Rstudio\http.R".GetFullPath
        Dim rpkg As String = $"{App.HOME}/Rstudio/packages/Rserver.zip".GetFullPath
        Dim commandLine As String = $"{http_server.CLIPath} --listen {webViewSvrPort} --wwwroot {webView.CLIPath} --attach {rpkg.CLIPath}"

        wwwroot = host.CreateSlave(commandLine)

        Call RunTask(AddressOf wwwroot.Run)
        Call New Thread(
            Sub()
                Call Thread.Sleep(3000)
                Call Workbench.LogTextOutput.WriteLine(wwwroot.ToString)
            End Sub).Start()
    End Sub

End Class
