require(JSON);
require(GCModeller);
require(RStudio);

imports "GenBank" from "seqtoolkit";
imports "Modeller" from "GCModellerDesktop";
imports "UniProt" from "annotationKit";
imports "uniprot" from "seqtoolkit";
imports "annotation.workflow" from "seqtoolkit";
imports "blast+" from "seqtoolkit";

#' Run localblast search
#' 
#' @param query the file location of the query fasta file, and the
#'    localblast output save location is also located at the folder
#'    location of the query fasta file.
#' 
const run = function(query, reference, 
                     evalue = 1e-3, 
                     n_threads = 2) {

    const outputdir as string = dirname(query);
    const blast_outfile as string = `${outputdir}/blast.txt`;
    const blast_table as string = `${outputdir}/annotation.csv`;

    # run localblast at first
    options(ncbi_blast = RStudio::ncbi_blast_dir());

    print("the blast result output dir location:");
    print(outputdir);

    const logging = blastp(query, reference, blast_outfile, evalue, n_threads);

    blast_outfile 
    |> read.blast(type = "prot", fastMode = TRUE)
    |> blasthit.sbh()
    |> as.vector()
    |> write.csv(file = blast_table)
    ;

    const previews = head(read.csv(blast_table, check.names = FALSE));

    print("previews of the blast search table:");
    print(previews);

    write.csv(previews, file = buffer("dataframe"), tsv = TRUE);
}
