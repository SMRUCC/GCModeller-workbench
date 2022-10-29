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

    print("extract protein sequence set from the project file:");
    print("and then create blastp index!");

    Modeller::extract_proteinset_fasta(proj, save_fasta);

    # create blastp database
	# for run downstream annotation
	save_fasta
	|> makeblastdb(dbtype = "prot")
	|> writeLines(con = buffer("text"))
	;

    RStudio::echo_successMsg({
        ssid: ssid,
        dataset: save_fasta,
        # blast database targets that can be used for the 
        # data annotation job
        blast: {
            ec_numbers: Rstudio::fs.ec_numbers_fasta()
        }
    })
    ;
}