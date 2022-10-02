imports "gtk" from "Rstudio";

files = gtk::selectFiles(filter = "UniProt database(*.xml)|*.xml", multiple = FALSE);

writeLines(files, con = buffer("text"));