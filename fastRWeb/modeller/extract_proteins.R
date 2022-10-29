require(JSON);
require(GCModeller);
require(RStudio);

imports "GenBank" from "seqtoolkit";
imports "Modeller" from "GCModellerDesktop";

#' Extract protein sequence fasta file for run blast annotation
#' 
#' @param proj from a given project file
#' 
const run = function(proj) {
    const ssid as string = getOption("web_request_id");
    
}