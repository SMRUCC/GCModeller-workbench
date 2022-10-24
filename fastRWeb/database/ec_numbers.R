require(GCModeller);

imports "UniProt" from "annotationKit";
imports "uniprot" from "seqtoolkit";
imports "bioseq.fasta" from "seqtoolkit";

const run = function(uniprot) {
	const ecNumbersDbfile as string = `/EC_numbers.db`;
	const ecNumbersFasta as string = `${dirname(ecNumbersDbfile)}/EC_numbers.fasta`;

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
	}
}