# workbench filesystem

#' get file path of the fasta file for EC number annotation
#' 
const fs.ec_numbers_fasta = function() {
    `${RStudio::repository_root()}/blastdb/EC_numbers.fasta`;
}