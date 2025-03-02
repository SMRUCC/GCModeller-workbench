require(GCModeller);
require(Rstudio);

imports "UniProt" from "annotationKit";
imports "uniprot" from "seqtoolkit";
imports "bioseq.fasta" from "seqtoolkit";
imports "blast+" from "seqtoolkit";

const run = function(uniprot) {
	const ecNumbersDbfile as string = `${RStudio::repository_root()}/EC_numbers.db`;
	const ecNumbersFasta as string = Rstudio::fs.ec_numbers_fasta();
	const subcellular_locationFasta as string = Rstudio::fs.subcellular_locations_fasta();
	
	options(ncbi_blast = RStudio::ncbi_blast_dir());

	using pack as UniProt::ECnumber_pack(ecNumbersDbfile, create_new = TRUE) {
		pack |> add_ecNumbers(			
			open.uniprot(uniprot)
		);
	}

	using pack as UniProt::ECnumber_pack(ecNumbersDbfile, create_new = FALSE) {
		pack 
		|> extract_fasta()
		|> write.fasta(file = ecNumbersFasta)
		;

		pack 
		|> extract_fasta(enzyme = FALSE)
		|> write.fasta(file = subcellular_locationFasta)
		;
	}

	# create blastp database
	# for run downstream annotation
	[		
		makeblastdb(ecNumbersFasta, dbtype = "prot"),
		makeblastdb(subcellular_locationFasta, dbtype = "prot")		
	]
	|> paste("
	
	")
	|> writeLines(con = buffer("text"))
	;
}

