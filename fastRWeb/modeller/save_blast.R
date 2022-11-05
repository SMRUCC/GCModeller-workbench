require(JSON);
require(GCModeller);
require(RStudio);

imports "GenBank" from "seqtoolkit";
imports "Modeller" from "GCModellerDesktop";
imports "UniProt" from "annotationKit";
imports "uniprot" from "seqtoolkit";
imports "annotation.workflow" from "seqtoolkit";
imports "blast+" from "seqtoolkit";

const save = {
    ontology_annotation: save_enzyme_annotation,
    subcellular_location: save_subcellular_location
};

#' save the enzyme annotation result
#' 
const run = function(proj, blast_dir, protocol = [
                        "sbh", 
                        "ontology_annotation", 
                        "subcellular_location"
                    ]) {

    blast_dir = dirname(blast_dir);
    protocol = save[[protocol]];

    if (!is.null(protocol)) {
        protocol(proj, `${blast_dir}/annotation.csv`);
    } else {
        stop("not implemented");
    }

    Rstudio::echo_successMsg("success");
}

