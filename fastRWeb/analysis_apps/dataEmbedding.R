require(JSON);

imports ["dataset", "umap", "t-SNE"] from "MLkit";

#' Do data embedding with different algorithm
#' 
const run = function(file, ssid, dims = 3, algorithm = ["PCA", "t-SNE", "UMAP"]) {
    const session_file = `${getOption("system_tempdir")}/${session_id}/dataEmbedding.dat`;
    const matrix = read.csv(file, row.names = 1, check.names = FALSE);
    const embedding = {
        "PCA": run_pca, 
        "t-SNE": run_tsne,
        "UMAP": run_umap
    };
    const func = embedding[[algorithm]];
    const result = func(matrix, dims);

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
    
    as.data.frame(manifold$umap, 
        labels = manifold$labels, 
        dimension = `dim${1:dims}`
    )
    ;
}

const run_pca = function(matrix, dims = 3) {

}

const run_tsne = function(matrix, dims = 3) {
    const tSNE = t.SNE()
	|> data(matrix)
	|> solve(iterations = 200)	
	;
	
	tSNE 
	|> as.data.frame(row.names = tags) 
	;
}