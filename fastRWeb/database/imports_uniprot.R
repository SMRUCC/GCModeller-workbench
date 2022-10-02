require(JSON);
require(GCModeller);

imports "ptf" from "annotationKit";
imports "uniprot" from "seqtoolkit";

const run = function(file, name, note = "") {
    const savedb as string = `/etc/repository/ptf/${md5(name)}.db`;
    const metafile as string = `/etc/repository/ptf/${md5(name)}.json`;
    const result as string = 

    try({
        file 
        |> open.uniprot(file)
        |> cache.ptf(file = savedb, hds.stream = TRUE)
        ;

        json_encode({
            name: name,
            note: note
        })
        |> writeLines(con = metafile)
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