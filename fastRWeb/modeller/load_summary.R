require(RStudio);

imports "Modeller" from "GCModellerDesktop";

const run = function(proj) {
    # total <int32>
    # number_enzymes <int32>
    # enzyme_class <pie list data>
    # subcellular_locations <pie list data>
    Rstudio::echo_successMsg(Modeller::readProj(proj));
}