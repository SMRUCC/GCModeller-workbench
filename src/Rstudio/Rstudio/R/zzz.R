require(JSON);
require(GCModeller);

imports "geneExpression" from "phenotype_kit";
imports "RStudio" from "GCModellerDesktop";

const .onLoad = function() {
    RStudio::config(getOption("gcmodeller.config"));
}