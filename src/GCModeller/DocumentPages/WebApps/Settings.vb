Namespace WebApps

    Public Class Settings : Inherits WebApp

        Public Sub New()
            MyBase.New("/settings.vbhtml")
        End Sub

        Public Function GetSettings() As Global.GCModeller_win32Desktop.Settings.File
            Return Global.GCModeller_win32Desktop.Settings.Session.SettingsFile
        End Function
    End Class
End Namespace