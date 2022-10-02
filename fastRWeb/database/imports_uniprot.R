require(JSON);
require(GCModeller);

imports "ptf" from "annotationKit";
imports "uniprot" from "seqtoolkit";

const run = function(file) {
    const savedb as string = `/etc/repository/ptf/${md5(basename(file))}.db`;
    const result as string = 
    
    try({
        file 
        |> open.uniprot(file)
        |> cache.ptf(file = savedb, hds.stream = TRUE)
        ;

        "success";
    })
    ;

    if (is.null(result)) {
        json_encode({
            code: 500, 
            info: as.list(traceback())
        }) 
        |> writeLines(con = buffer("text"))
        ;
    } else {
        json_encode({
            code: 0, 
            info: savedb
        }) 
        |> writeLines(con = buffer("text"))
        ;
    }
}