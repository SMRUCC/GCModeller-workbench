require(JSON);
require(GCModeller);

imports "geneExpression" from "phenotype_kit";

const run = function(file, ssid, z_score = TRUE, algorithm = ["cmeans", "kmeans"], layout = [3,3]) {
    const expr0 = matrixFileReader(file, z_score);
    const patterns = expression.cmeans_pattern(expr0, dim = layout);
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

const matrixFileReader = function(file, z_score = TRUE) {
    const ext = tolower(file.ext(file));
    const expr0 = {
        if (ext == "csv") {
            geneExpression::load.expr(file);
        } else {
            # load binary
            geneExpression::load.expr0(file);
        }
    }

    if (z_score) {
        geneExpression::z_score(expr0);
    } else {
        expr0; 
    }
}