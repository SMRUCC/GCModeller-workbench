require(Rstudio);

const run = function(file, ssid, z_score = TRUE, algorithm = ["cmeans", "kmeans"], layout = [3,3]) {
    const expr0 = Rstudio::matrixFileReader(file, as.logical(z_score));
    const patterns = expr0 
    |> expression.cmeans_pattern(
        dim = as.integer(layout),
        fuzzification = 2,
        threshold = 0.1
    )
    ;
    const session_file as string = `${getOption("system_tempdir")}/${ssid}/patterns_data.dat`;
    const session_mat as string = `${getOption("system_tempdir")}/${ssid}/patterns.csv`;
    const data = cmeans_matrix(patterns);

    write.csv(data, file = session_mat);
    savePattern(patterns, file = session_file);

    const peeks = head(read.csv(session_mat, row.names = 1, check.names = FALSE), 10);

    print("preview of the result:");
    print(peeks);

    write.csv(peeks, file = buffer("dataframe"), tsv = TRUE);
}
