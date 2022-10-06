require(JSON);

const run = function(ssid) {
    const session_file = `${getOption("system_tempdir")}/${ssid}/dataEmbedding.dat`;
    const saveimage = `${getOption("system_tempdir")}/${ssid}/dataEmbedding.png`;
    const csvfile_export = `${getOption("system_tempdir")}/${ssid}/dataEmbedding.csv`;
    const data = readRDS(session_file);
    const zipfile = `${getOption("system_tempdir")}/${ssid}/download.zip`;

    write.csv(data, file = csvfile_export, row.names = TRUE);

    zip(zipfile, [session_file, saveimage, csvfile_export]);

    json_encode({
        code: 0,
        info: `/@temp/${ssid}/download.zip`
    })
    |> writeLines(con = buffer("text"))
    ;
}