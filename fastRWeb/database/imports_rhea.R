require(JSON);
require(GCModeller);
require(Rstudio);

imports "enzymatic" from "vcellkit";

#' Build a reference database for the metabolic network modeller
#' 
const run = function(src) {
    const enzymeDbfile as string = `${RStudio::repository_root()}/metabolic.db`;
    
    src 
    |> read.rhea() 
    |> enzymatic::imports_rhea(repo = enzymeDbfile)
    ;

    Rstudio::echo_successMsg("success");
}