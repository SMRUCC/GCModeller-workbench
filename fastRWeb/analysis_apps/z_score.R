require(Rstudio);

const run = function(file, ssid) {
    # load via z-score transform by default
    const zscore = Rstudio::matrixFileReader(file);
    const session_file as string = `${getOption("system_tempdir")}/${ssid}/zscore.HTS`;
    const session_mat as string = `${getOption("system_tempdir")}/${ssid}/zscore.csv`;
    const data = as.data.frame(zscore);

    write.csv(data, file = session_mat);
    write.expr_matrix(zscore, file = session_file, binary = TRUE);

    print("peeks of the z-score matrix:");
    print(data, max.print = 6);

    write.csv(head(data, 10), file = buffer("dataframe"), tsv = TRUE);
}