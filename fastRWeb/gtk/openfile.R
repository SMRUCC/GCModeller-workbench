imports "gtk" from "Rstudio";

require(JSON);

const run = function() {
    let files = gtk::selectFiles(
        filter      = "UniProt database(*.xml)|*.xml", 
        multiple    = FALSE, 
        throwCancel = FALSE
    );

    print("file open:");
    print(files);

    json_encode({
        code: ifelse(is.null(files) || [length(files) == 0], 500, 0), 
        info: files
    }) 
    |> writeLines(con = buffer("text"))
    ;
}

