# workbench filesystem

#' get file path of the fasta file for EC number annotation
#' 
const fs.ec_numbers_fasta = function() {
    `${RStudio::repository_root()}/blastdb/EC_numbers.fasta`;
}

#' get file path of the fasta file for subcellular locations
#' 
const fs.subcellular_locations_fasta = function() {
    `${RStudio::repository_root()}/blastdb/subcellular_locations.fasta`;
}

const fs.metabolic_db = function() {
    `${RStudio::repository_root()}/metabolic.db`;
}