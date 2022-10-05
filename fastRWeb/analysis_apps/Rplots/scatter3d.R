require(ggplot);

const run = function(ssid) {
    const session_file = `${getOption("system_tempdir")}/${ssid}/dataEmbedding.dat`;
    const data = readRDS(session_file);

    data[, "class"] = "class_unknow";

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

    plot(plt, size = [2400, 2000])
    |> graphics(file = buffer("bitmap"))
    ;  
}