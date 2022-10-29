#' Helper for read expression matrix file
#' 
#' @param file the file path of the target expression matrix file,
#'    data reader is distinct from the file extension suffix name:
#' 
#'    + csv: a plain text csv table file
#'    + hts: a binary data matrix of the expression data
#' 
#' @param z_score do z-score transform of the expression matrix data?
#'    default is yes!
#' 
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