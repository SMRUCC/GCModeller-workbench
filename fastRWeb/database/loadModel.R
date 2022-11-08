require(HDS);
require(JSON);
require(GCModeller);

imports "ptf" from "annotationKit";

#' load enrichment background model
#' 
const run = function(guid, xref) {
    const db = HDS::openStream(`/etc/repository/ptf/${guid}.db`);    
    const model = ptf::load_xref(db, xref);
    
    Rstudio::echo_successMsg({
        clusters: model
    })
    ;
}


