require(HDS);
require(JSON);
require(GCModeller);

imports "ptf" from "annotationKit";

const run = function(guid) {
    const db = HDS::openStream(`/etc/repository/ptf/${guid}.db`);
    const protein_counts = HDS::getText(db, "/metadata/count.txt");
    const xrefs = ptf::list.xrefs(db);
    const summary_info = ptf::summary.xrefs(db, xrefs);
    # const protein_id = HDS::getText(db, "/metadata/proteins.txt");

    # print(HDS::tree(db));

    json_encode({
        code: 0, 
        info: {
            counts: protein_counts,
            backgrounds: xrefs,
            summary: summary_info
        }
    }) 
    |> writeLines(con = buffer("text"))
    ;
}


