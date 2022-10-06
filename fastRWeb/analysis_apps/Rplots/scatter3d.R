require(ggplot);
require(JSON);

imports "clustering" from "MLkit";

const run = function(ssid, k = 6) {
    const session_file = `${getOption("system_tempdir")}/${ssid}/dataEmbedding.dat`;
    const saveimage = `${getOption("system_tempdir")}/${ssid}/dataEmbedding.png`;
    const data = readRDS(session_file);

    if (k <= 0) {
        data[, "class"] = "class_unknow";
    } else {
        data = as.data.frame(kmeans(data, centers = k));
        rownames(data) = data[, "ID"];
        data[, "ID"] = NULL;
        data[, "class"] = `class_${data[, "Cluster"]}`;
        data[, "Cluster"] = NULL;
        data[, "dim1"] = as.numeric(data[, "dim1"]);
        data[, "dim2"] = as.numeric(data[, "dim2"]);
        data[, "dim3"] = as.numeric(data[, "dim3"]);
    }    

    print("view of the matrix data:");
    print(data, max.print = 6);

    # create ggplot layers and tweaks via ggplot style options
    const plt = ggplot(data, aes(x = "dim1", y = "dim2", z = "dim3"), padding = "padding:250px 500px 100px 100px;")
    
    # use scatter points for visual our data
    + geom_point(aes(color = "class"), color = "paper", shape = "triangle", size = 20)   
    + ggtitle("Scatter 3D")
    # use the default white theme from ggplot
    + theme_default()

    # use a 3d camera to rotate the charting plot 
    # and adjust view distance
    + view_camera(angle = [31.5,65,125], fov = 100000)
    ;

    bitmap(file = saveimage, size = [2400, 2000]) {
        plot(plt);
    }

    json_encode({
        code: 0,
        info: `/@temp/${ssid}/dataEmbedding.png`
    })
    |> writeLines(con = buffer("text"))
    ;
}