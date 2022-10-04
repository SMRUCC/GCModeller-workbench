require(JSON);
require(GCModeller);

imports "visualPlot" from "visualkit";
imports ["GSEA", "UniProt"] from "gseakit";

const run = function(session_id, type = ["bar", "bubble"], background = "", top = 5) {
    const session_file as string = `${getOption("system_tempdir")}/${session_id}/enrichment.dat`;
    const enrichment = readRDS(session_file);
    const terms = GSEA::to_enrichment_terms(enrichment);

    type = type[1] || "bar";

    print("previews of the enrichment result:");
    print(enrichment, max.print = 6);
    # print(head(terms));
    print("start to run data plots!");
    print("The plot data type:");
    print(type);

    let enrich_profiles = NULL;

    if ([!is.null(background)] && [background == "keyword"]) {
        let keywords = "E:\GCModeller\src\workbench\win32_desktop\src\Rstudio\data\UniProt-Keywords.tsv"
        |> read.csv(tsv = TRUE, check.names = FALSE)
        ;

        enrich_profiles = UniProt::keyword_profiles(terms, keywords, top = top);
    } else {
        stop("not implemented");
    }

    if (type == "bar") {
        enrich_profiles
        |> category_profiles.plot(            
            colors = "paper",
            title = "UniProt Keywords",
            axis.title = "-log10(p-value)",
            size = [1200,1600],
            dpi = 100
        )
        |> graphics(file = buffer("bitmap"))
        ;        
    } else {
        stop("not implemented");
    }
}