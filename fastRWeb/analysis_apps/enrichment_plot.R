require(JSON);
require(GCModeller);

imports "visualPlot" from "visualkit";
imports "GSEA" from "gseakit";

const run = function(session_id, type = ["bar", "bubble"]) {
    const session_file as string = `${getOption("system_tempdir")}/${session_id}/enrichment.dat`;
    const enrichment = readRDS(session_file);

    type = type[1] || "bar";

    print("previews of the enrichment result:");
    print(enrichment, max.print = 6);
    print("start to run data plots!");
    print("The plot data type:");
    print(type);


}