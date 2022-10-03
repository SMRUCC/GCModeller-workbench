require(JSON);
require(GCModeller);

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

    json_encode({
        code: 0, 
        info: "success"
    }) 
    |> writeLines(con = buffer("text"))
    ;
}