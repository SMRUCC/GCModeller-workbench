require(JSON);

const run = function(ssid) {
    const session_file = `${getOption("system_tempdir")}/${ssid}/dataEmbedding.dat`;
    const saveimage = `${getOption("system_tempdir")}/${ssid}/dataEmbedding.png`;
    const csvfile_export = `${getOption("system_tempdir")}/${ssid}/dataEmbedding.csv`;
    const data = readRDS(session_file);

    write.csv(data, file = csvfile_export, row.names = TRUE);
    
}