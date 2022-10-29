require(JSON);
require(GCModeller);
require(RStudio);

imports "GenBank" from "seqtoolkit";
imports "Modeller" from "GCModellerDesktop";
imports "UniProt" from "annotationKit";
imports "uniprot" from "seqtoolkit";
imports "bioseq.fasta" from "seqtoolkit";
imports "blast+" from "seqtoolkit";

#' Run localblast search
#' 
#' @param query the file location of the query fasta file, and the
#'    localblast output save location is also located at the folder
#'    location of the query fasta file.
#' 
const run = function(query, reference, 
                     evalue = 1e-3, 
                     n_threads = 2, 
                     protocol = ["sbh", "ontology_annotation"]) {

    # run localblast at first
    
}