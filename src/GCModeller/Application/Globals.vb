Imports Microsoft.VisualBasic.CommandLine.InteropService.Pipeline
Imports Microsoft.VisualBasic.Parallel

Public Class Globals

    Friend Shared host As FormMainHost

    Shared wwwroot As RunSlavePipeline

    Public Shared Sub Load()
        Call startWebServices()
    End Sub

    Private Shared Sub startWebServices()
        Dim host = Rserver.RscriptCommandLine.Rscript.FromEnvironment($"{App.HOME}/")
        Dim commandLine As String = $""

        wwwroot = host.CreateSlave(commandLine)

        Call RunTask(AddressOf wwwroot.Run)
    End Sub

End Class
