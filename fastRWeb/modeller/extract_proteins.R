require(JSON);
require(GCModeller);
require(RStudio);

imports "GenBank" from "seqtoolkit";
imports "Modeller" from "GCModellerDesktop";
imports "UniProt" from "annotationKit";
imports "uniprot" from "seqtoolkit";
imports "bioseq.fasta" from "seqtoolkit";
imports "blast+" from "seqtoolkit";

#' Extract protein sequence fasta file for run blast annotation
#' 
#' @param proj from a given project file
#' 
const run = function(proj, ssid) {
    const save_fasta as string = `${getOption("system_tempdir")}/${ssid}/proteins.fasta`;   

    options(ncbi_blast = RStudio::ncbi_blast_dir());

    # create blastp database
	# for run downstream annotation
	save_fasta
	|> makeblastdb(dbtype = "prot")
	|> writeLines(con = buffer("text"))
	;

    json_encode({
        ssid: ssid,
        dataset: save_fasta
    })
    |> writeLines(con = buffer("text"))
    ;
}