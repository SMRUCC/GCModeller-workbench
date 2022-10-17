require(Rstudio);

const run = function(file, ssid) {
    # load via z-score transform by default
    const zscore = Rstudio::matrixFileReader(file);
    const session_file as string = `${getOption("system_tempdir")}/${ssid}/zscore_data.dat`;
    const session_mat as string = `${getOption("system_tempdir")}/${ssid}/zscore.csv`;
}