Imports System.Composition
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData

<Package("RStudio")>
Public Module RStudio

    <ExportAPI("repository_root")>
    Public Function getRepositoryRoot() As String
        Return Settings.Session.GetSettingsFile.RepositoryRoot
    End Function

    <ExportAPI("ncbi_blast_dir")>
    Public Function getBlastBinDir() As String
        Return Settings.Session.GetSettingsFile.BlastBin
    End Function
End Module
