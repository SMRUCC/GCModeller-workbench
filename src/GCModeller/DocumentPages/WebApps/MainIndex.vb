Imports System.Runtime.InteropServices

<ClassInterface(ClassInterfaceType.AutoDual)>
<ComVisible(True)>
Public Class MainIndex : Inherits AppIndex

    Public Sub New()
        MyBase.New("/index.vbhtml")
    End Sub

    Public Sub openApplets()
        Call WebApp.Open(Of AppIndex)()
    End Sub

    Public Sub openDatabaseRepository()
        Call WebApp.Open(Of DataRepository)()
    End Sub

    Public Sub openTaskManager()
        Call WebApp.Open(Of AppTasks)()
    End Sub

    Public Sub open_project()
        Using file As New OpenFileDialog With {
            .Filter = "All GCModeller Project(*.bioproj)|*.bioproj|GCModeller Cell Project(*.bioproj)|*.bioproj"
        }
            If file.ShowDialog = DialogResult.OK Then
                If file.FileName.ExtensionSuffix("bioproj") Then
                    ' virtual cell modeller project
                    Call New ModellerProject(file.FileName).Open()
                Else
                    ' omics data analysis project
                End If
            End If
        End Using
    End Sub

    Public Sub createBioProject()
        Call WebApp.Open(Of CreateBioProject)()
    End Sub

    Public Sub createOmicsProject()
        Call WebApp.Open(Of CreateOmicsProject)()
    End Sub
End Class
