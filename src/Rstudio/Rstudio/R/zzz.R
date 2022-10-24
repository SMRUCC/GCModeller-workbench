require(JSON);
require(GCModeller);

imports "geneExpression" from "phenotype_kit";
imports "RStudio" from "GCModellerDesktop";

const .onLoad = function() {
    # load config repository automatically
    RStudio::config(getOption("gcmodeller.config"));

    print("Load workbench desktop runtime!");
    print(`RStudio::config(${getOption("gcmodeller.config")})`);
}