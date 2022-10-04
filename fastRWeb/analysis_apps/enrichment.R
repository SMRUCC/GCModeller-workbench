require(JSON);
require(GCModeller);
require(HDS);

imports "ptf" from "annotationKit";
imports "GSEA" from "gseakit";

const run = function(id, background, symbols, ssid = md5(`enrichment-${toString(now())}`)) {
    const databaseUrl as string = `/etc/repository/ptf/${id}.db`;
    const session_file as string = `${getOption("system_tempdir")}/${ssid}/enrichment.dat`;

    print("gene symbols that user input:");
    print(symbols);
    print("select background model:");
    print(background);
    print("open database file:");
    print(databaseUrl);

    if(!file.exists(databaseUrl)) {
        stop(`Protein annotation database '${id}' is not found on your file system!`);
    } else {
        print("the session result file will be saved at file location:");
        print(session_file);
    }

    const model = ptf::loadBackgroundModel(HDS::openStream(databaseUrl), background);
    const result = model 
    |> enrichment(symbols, outputAll = FALSE) 
    |> as.data.frame()
    ;

    saveRDS(result, file = session_file);
    print(result, max.print = 6);
    write.csv(result, file = buffer("dataframe"), tsv = TRUE);
}