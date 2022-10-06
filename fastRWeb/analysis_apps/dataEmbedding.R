require(JSON);

imports ["dataset", "umap", "t-SNE"] from "MLkit";

const processMatrix = function(file, z_score) {
    let matrix = read.csv(file, row.names = 1, check.names = FALSE);

    print("required of z-score transformation?");
    print(z_score);

    if (as.logical(z_score)) {
        for(name in colnames(matrix)) {
            let v = matrix[, name];
            v = (v-mean(v))/sd(v);
            matrix[, name] = v;
        }
    }

    matrix;
}

#' Do data embedding with different algorithm
#' 
const run = function(file, ssid, z_score = TRUE, dims = 3, algorithm = ["PCA", "t-SNE", "UMAP"]) {
    const session_file = `${getOption("system_tempdir")}/${ssid}/dataEmbedding.dat`;
    const matrix = processMatrix(file, z_score);
    const embedding = {
        "PCA": run_pca, 
        "t-SNE": run_tsne,
        "UMAP": run_umap
    };
    const func = embedding[[algorithm]];
    const result = func(matrix, as.integer(dims));

    print("View of your matrix result:");
    print(result, max.print = 6);
    print("the result matrix is save at session location:");
    print(session_file);

    saveRDS(result, file = session_file);
    write.csv(result, file = buffer("dataframe"), tsv = TRUE);
}

const run_umap = function(matrix, dims = 3) {
    const manifold = matrix
    |> umap(
        dimension            = dims, 
        numberOfNeighbors    = 15,
        localConnectivity    = 1,
        KnnIter              = 64,
        bandwidth            = 1
    )
    ;
    
    print("result dimension labels:");    
    print(`dim${1:dims}`);

    as.data.frame(manifold$umap, 
        labels = manifold$labels, 
        dimension = `dim${1:dims}`
    )
    ;
}

const run_pca = function(matrix, dims = 3) {
    const pca = prcomp(matrix);
    const result = as.data.frame(pca, npc = dims);
    colnames(result) = `dim${1:dims}`;
    result;
}

const run_tsne = function(matrix, dims = 3) {
    const tSNE = t.SNE(dimension = dims)
	|> data(matrix)
	|> solve(iterations = 200)	
	;
	const result = as.data.frame(tSNE);
    colnames(result) = `dim${1:dims}`;
    result;
}