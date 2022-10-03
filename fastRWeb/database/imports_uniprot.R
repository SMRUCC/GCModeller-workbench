require(JSON);
require(GCModeller);

imports "ptf" from "annotationKit";
imports "uniprot" from "seqtoolkit";

const run = function(file, name, note = "") {
    const savedb as string = `/etc/repository/ptf/${md5(name)}.db`;
    const metafile as string = `/etc/repository/ptf/${md5(name)}.json`;

    if (nchar(name) == 0) {
        json_encode({
            code: 500, 
            info: "The database name can not be empty!"
        }) 
        |> writeLines(con = buffer("text"))
        ;
    } else {
        const result as string = try({
            run_imports(file, savedb, name, note, metafile)
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
}

const run_imports = function(file, savedb, name, note, metafile) {
    file 
    |> open.uniprot()
    |> cache.ptf(
        file = savedb, 
        hds.stream = TRUE, 
        cacheTaxonomy = TRUE
    )
    ;

    json_encode({
        name: name,
        note: note
    })
    |> writeLines(con = metafile)
    ;

    "success";
}