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

    Rstudio::echo_successMsg("Imports genbank assembly success!");
}