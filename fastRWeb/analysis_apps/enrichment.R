require(JSON);
require(GCModeller);
require(HDS);

imports "ptf" from "annotationKit";
imports "GSEA" from "gseakit";

const run = function(id, background, symbols) {
    const databaseUrl as string = `/etc/repository/ptf/${id}.db`;

    print("gene symbols that user input:");
    print(symbols);
    print("select background model:");
    print(background);
    print("open database file:");
    print(databaseUrl);

    if(!file.exists(databaseUrl)) {
        stop(`Protein annotation database '${id}' is not found on your file system!`);
    } 

    const model = ptf::loadBackgroundModel(HDS::openStream(databaseUrl), background);
    const result = model 
    |> enrichment(symbols, outputAll = FALSE) 
    |> as.data.frame()
    ;

    print(result, max.print = 6);

    json_encode({
        code: 0, 
        info: "success"
    }) 
    |> writeLines(con = buffer("text"))
    ;
}