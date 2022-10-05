require(HDS);
require(JSON);
require(GCModeller);

imports "ptf" from "annotationKit";

const run = function(guid, xref) {
    const db = HDS::openStream(`/etc/repository/ptf/${guid}.db`);    
    const model = ptf::load_xref(db, xrefs);
    
    json_encode({
        code: 0, 
        info: {
            clusters: model
        }
    }) 
    |> writeLines(con = buffer("text"))
    ;
}


