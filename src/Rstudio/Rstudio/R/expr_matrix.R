
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