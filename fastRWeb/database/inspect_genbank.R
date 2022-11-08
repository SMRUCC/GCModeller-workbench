require(JSON);
require(GCModeller);

const run = function(gbff) {
    if (!file.exists(gbff)) {
        stop([
            `the given file(${basename(gbff)}) is mising on your file system!`, 
            `full name: ${gbff}`
        ]);
    }

    Rstudio::echo_successMsg("");
}