require(JSON);
require(GCModeller);
require(RStudio);

imports "GenBank" from "seqtoolkit";
imports "Modeller" from "GCModellerDesktop";

const run = function(gbff, savefile) {
    gbff
    |> read.genbank()
    |> loadProject()
    |> writeProject(file = savefile)
    ;

    json_encode({
        code: 0,
        info:""
    })
    |> writeLines(con = buffer("text"))
    ;
}