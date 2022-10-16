require(JSON);
require(GCModeller);

imports "geneExpression" from "phenotype_kit";

const run = function(file, ssid, z_score = TRUE, algorithm = ["cmeans", "kmeans"], layout = [3,3]) {
    const expr0 = matrixFileReader(file, z_score);
    const patterns = expression.cmeans_pattern(expr0, dim = layout);
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