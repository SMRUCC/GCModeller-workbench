require(Rstudio);

const run = function(ssid, colorSet = "Jet") {
    const session_file as string = `${getOption("system_tempdir")}/${ssid}/zscore.HTS`;
    const data = load.expr0(session_file);
}