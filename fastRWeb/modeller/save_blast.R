require(JSON);
require(GCModeller);
require(RStudio);

imports "GenBank" from "seqtoolkit";
imports "Modeller" from "GCModellerDesktop";
imports "UniProt" from "annotationKit";
imports "uniprot" from "seqtoolkit";
imports "annotation.workflow" from "seqtoolkit";
imports "blast+" from "seqtoolkit";

#' save the enzyme annotation result
#' 
const run = function(proj, blast_dir, protocol) {
    blast_dir = dirname(blast_dir);

    if (protocol == "ontology_annotation") {
        save_enzyme_annotation(proj, `${blast_dir}/annotation.csv`);
    } else {
        stop("not implemented");
    }

    Rstudio::echo_successMsg("success");
}
