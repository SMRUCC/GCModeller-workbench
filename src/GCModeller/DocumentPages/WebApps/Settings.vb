Imports Microsoft.VisualBasic.MIME.application.json
Imports Microsoft.VisualBasic.MIME.application.json.Javascript
Imports Microsoft.VisualBasic.My.JavaScript

Namespace WebApps

    Public Class Settings : Inherits WebApp

        Public Sub New()
            MyBase.New("/settings.vbhtml")
        End Sub

        Public Function GetSettings() As Global.GCModeller_win32Desktop.Settings.File
            Return Global.GCModeller_win32Desktop.Settings.Session.SettingsFile
        End Function

        Public Function SaveSettings(config As String)
            Dim configs As JavaScriptObject = DirectCast(config.ParseJson, JsonObject)

        End Function
    End Class
End Namespace