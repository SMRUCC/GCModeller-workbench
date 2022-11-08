require(JSON);
require(GCModeller);
require(RStudio);

imports "enzymatic" from "vcellkit";

#' create metabolic network model based on the annotation result
#' 
const run = function(proj) {
    const enzymeDbfile as string = Rstudio::fs.metabolic_db();
    const rhea = enzymatic::open.rhea(repo = enzymeDbfile);
}