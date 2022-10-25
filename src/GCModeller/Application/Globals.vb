Imports System.Threading
Imports GCModeller_win32Desktop.My
Imports GCModeller_win32Desktop.Settings
Imports GCModeller_win32Desktop.Settings.Programs
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CommandLine.InteropService.Pipeline
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Parallel

Public Class Globals

    Friend Shared host As FormMainHost

    Shared wwwroot As RunSlavePipeline
    Shared fastRweb As RunSlavePipeline

    Public Shared ReadOnly webViewSvrPort As Integer = 19612
    Public Shared ReadOnly webView As String
    Public Shared ReadOnly fastRwebPort As Integer = 7452

    Shared Sub New()
        webView = $"{App.HOME}/../web/".GetDirectoryFullPath
    End Sub

    Public Shared Sub Load()
        ' make sure the configuration node is not empty
        Dim configs = Session.GetSettingsFile

        If configs.BlastDb.StringEmpty Then
            configs.BlastDb = "/etc/repository/fasta/"
        End If
        If configs.RepositoryRoot.StringEmpty Then
            configs.RepositoryRoot = "/etc/repository/"
        End If
        If configs.Dev2 Is Nothing Then
            configs.Dev2 = IDE.Default
        End If

        If configs.Dev2.IDE Is Nothing Then configs.Dev2.IDE = IDE.IDEConfig.Default
        If configs.Dev2.Session Is Nothing Then configs.Dev2.Session = IDE.SessionF.Default
        If configs.Dev2.StartPage Is Nothing Then configs.Dev2.StartPage = IDE.StartPageF.Default

        Call Workbench.Load()
        Call MyApplication.ConfigRStudioConfiguration()

        ' Call Globals.startWebServices()
        ' Call Globals.launchFastRweb()
    End Sub

    Private Shared Sub launchFastRweb()
        Dim host = Rserver.RscriptCommandLine.Rserve.FromEnvironment($"{App.HOME}/Rstudio/bin")
        Dim rweb As String = $"{App.HOME}/../fastRWeb/".GetDirectoryFullPath
        Dim commandLine As String = host.GetstartCommandLine(fastRwebPort,, rweb:=rweb)

        ' Rserve --start --port "7452" --tcp "3838" --rweb "E:/GCModeller/src/workbench/win32_desktop/fastRWeb/" --n_threads "8" /@set --internal_pipeline=TRUE
        fastRweb = host.CreateSlave(commandLine, workdir:=host.Path.ParentPath)
        fastRweb.Shell = True

        Call RunTask(AddressOf fastRweb.Run) _
            .DoCall(Sub(task)
                        Call App.AddExitCleanHook(
                            Sub()
                                Try
                                    Call task.Abort()
                                Catch ex As Exception
                                End Try
                            End Sub)
                    End Sub)
        Call New Thread(
            Sub()
                Call Thread.Sleep(3000)
                Call Workbench.LogTextOutput.WriteLine(fastRweb.ToString)
            End Sub).Start()
    End Sub

    Private Shared Sub startWebServices()
        Dim host = Rserver.RscriptCommandLine.Rscript.FromEnvironment($"{App.HOME}/Rstudio/bin")
        Dim http_server As String = $"{App.HOME}/../src\Rstudio\http.R".GetFullPath
        Dim rpkg As String = $"{App.HOME}/Rstudio/packages/Rserver.zip".GetFullPath
        Dim commandLine As String = $"{http_server.CLIPath} --listen {webViewSvrPort} --wwwroot {webView.CLIPath} --attach {rpkg.CLIPath}"

        ' Rscript E:/GCModeller/src/workbench/win32_desktop/src/Rstudio/http.R --listen 19612 --wwwroot E:/GCModeller/src/workbench/win32_desktop/web/ --attach E:/GCModeller/src/workbench/win32_desktop/Apps/Rstudio/packages/Rserver.zip
        wwwroot = host.CreateSlave(commandLine, workdir:=host.Path.ParentPath)
        wwwroot.Shell = True

        Call RunTask(AddressOf wwwroot.Run) _
            .DoCall(Sub(task)
                        Call App.AddExitCleanHook(
                            Sub()
                                Try
                                    Call task.Abort()
                                Catch ex As Exception
                                End Try
                            End Sub)
                    End Sub)
        Call New Thread(
            Sub()
                Call Thread.Sleep(3000)
                Call Workbench.LogTextOutput.WriteLine(wwwroot.ToString)
            End Sub).Start()
    End Sub

End Class
