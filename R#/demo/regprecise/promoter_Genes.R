imports "TRN.builder" from "phenotype_kit";
imports ["annotation.genbank_kit", "annotation.genomics_context", "annotation.workflow"] from "seqtoolkit";

require(dataframe);

let mapping = "K:\20200226\TRN\1025_mapping.csv"
:> open.stream(type = "Mapping", ioRead = TRUE)
:> projectAs(as.object)
:> groupBy(a -> a$Reads.Query)
:> lapply(function(a) {
	if (length(a) == 1) {
		a[1]$Reference;
	} else {
		let ref = sapply(a, x -> x$Reference);
		let scores = sapply(a, x -> x$"Score(bits)");
		
		ref[which.max(scores)];
	}
	
}, names = g -> g$key);

str(mapping);

let regions = "K:\20200226\20200516_gbk\X101SC19112292-Z01-J001_result\res.txt"
:> readText
:> as.promoter.models
:> projectAs(as.object)
;

let tuples = [];

for(a in regions) {
	if (a$numOfPromoters > 0) {
		let id = mapping[[a$locus_tag]];	
	
		if (!is.null(id)) {
			# print(id);
			
			for(site in a$tfBindingSites) {
				tuples = tuples << list(gene = id, regulator = as.object(site)$regulator);
			}		
		}
	}
}

let regs = tuples;

tuples = tuples :> groupBy(a -> a$regulator);

let regulator = tuples :> sapply(a -> a$key);
let n = tuples :> sapply(a -> length(a));
let gene_list = tuples :> sapply(a -> paste(a :> sapply(x -> x$gene), ", "));

data.frame(regulator = regulator, n = n, gene_list = gene_list)
:> write.csv(file = "K:\20200226\20200516_gbk\X101SC19112292-Z01-J001_result\res.csv")
;

# str(regs);

let expr = read.dataframe("K:\20200226\20200516_gbk\Archive 2\转录组蛋白质组结果1_细胞.csv", mode = "character");

# print(head(expr));

expr = expr :> groupBy(a => as.object(a)$ID) :> lapply(a => a[1], names = a => a$key);

print(names(expr));