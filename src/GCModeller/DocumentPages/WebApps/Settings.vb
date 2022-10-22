Imports GCModeller_win32Desktop.Settings
Imports Microsoft.VisualBasic.MIME.application.json
Imports Microsoft.VisualBasic.MIME.application.json.Javascript
Imports Microsoft.VisualBasic.My.JavaScript

Namespace WebApps

    Public Class Settings : Inherits WebApp

        Public Sub New()
            MyBase.New("/settings.vbhtml")
        End Sub

        Public Function GetSettings() As Global.GCModeller_win32Desktop.Settings.File
            Return Session.SettingsFile
        End Function

        Public Sub SaveSettings(jsonStr As String)
            Dim configs As JavaScriptObject = DirectCast(jsonStr.ParseJson, JsonObject)
            Dim config = Session.GetSettingsFile
            Dim dev2 = config.Dev2

            If dev2 Is Nothing Then
                config.Dev2 = Programs.IDE.Default
            End If

            config.BlastBin = configs(NameOf(config.BlastBin))
            config.BlastDb = configs(NameOf(config.BlastDb))
            config.RepositoryRoot = configs(NameOf(config.RepositoryRoot))

            dev2.RememberWindowStatus = configs(NameOf(dev2.RememberWindowStatus))
            dev2.IDE.Language = configs(NameOf(dev2.IDE.Language))

            Call Session.Finallize()
        End Sub
    End Class
End Namespace