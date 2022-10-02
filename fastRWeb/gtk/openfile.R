imports "gtk" from "Rstudio";

const run = function() {
    let files = gtk::selectFiles(filter = "UniProt database(*.xml)|*.xml", multiple = FALSE);

    print("file open:");
    print(files);

    writeLines(files, con = buffer("text"));
}

