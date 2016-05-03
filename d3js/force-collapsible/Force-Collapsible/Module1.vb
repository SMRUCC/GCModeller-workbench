Module Module1

    Sub Main()
        Call NetworkGenerator.FromRegulations("G:\4.15\MEME\footprints\xcb-modules.TestFootprints2,2.csv").SaveTo("G:\4.15\MEME\footprints\xcb-modules.TestFootprints2,2.json")
        Call NetworkGenerator.FromRegulations("G:\4.15\MEME\footprints\xcb-pathways.TestFootprints2,2.csv").SaveTo("G:\4.15\MEME\footprints\xcb-pathways.TestFootprints2,2.json")
    End Sub
End Module
