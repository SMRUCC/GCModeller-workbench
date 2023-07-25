Public NotInheritable Class AppContainer

    ''' <summary>
    ''' the bin folder path of the internal rscript 
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property RStudio As String = $"{App.HOME}/Rstudio/bin"
    Public Shared ReadOnly Property Rscript As CLI.Rscript

    Private Sub New()
    End Sub

    Shared Sub New()
        Rscript = CLI.Rscript.FromEnvironment(RStudio)
    End Sub
End Class
