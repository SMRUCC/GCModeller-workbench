Imports System.Composition
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData

<Package("RStudio")>
Public Module RStudio

    <ExportAPI("repository_root")>
    Public Function getRepositoryRoot() As String
        Return Settings.Session.GetSettingsFile.RepositoryRoot
    End Function
End Module
