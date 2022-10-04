require(JSON);
require(GCModeller);

const run = function(session_id) {
    const session_file as string = `${getOption("system_tempdir")}/${session_id}/enrichment.dat`;
    const enrichment = readRDS(session_file);

    print(enrichment, max.print = 6);
    
}