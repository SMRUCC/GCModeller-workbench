require(JSON);
require(GCModeller);

const run = function(gbff) {
    if (!file.exists(gbff)) {
        stop([
            `the given file(${basename(gbff)}) is mising on your file system!`, 
            `full name: ${gbff}`
        ]);
    }



    json_encode({
        code: 0,
        info: ""
    })
    |> writeLines(con = buffer("text"))
    ;
}