require(HDS);
require(JSON);

const run = function(guid) {
    const db = HDS::openStream(`/etc/repository/ptf/${guid}.db`);
    const protein_counts = HDS::getText(db, "/metadata/count.txt");
    const protein_id = HDS::getText(db, "/metadata/proteins.txt");

    # print(HDS::tree(db));

    json_encode({
        code: 0, 
        info: {
            counts: protein_counts,
            proteins: protein_id
        }
    }) 
    |> writeLines(con = buffer("text"))
    ;
}


