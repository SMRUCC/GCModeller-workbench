imports "package_utils" from "devkit";

package_utils::attach("E:\GCModeller\src\workbench\pkg");

require(JSON);
require(GCModeller);

imports "enzymatic" from "vcellkit";
imports "sabiork" from "vcellkit";

setwd(@dir);

const rhea = read.rhea("../data/rhea/rhea-reactions.txt");
const sabio_rk = sabiork::new("./sabio-rk.db");

for(reaction in rhea) {
	ec_numbers = [reaction]::enzyme;
	ec_numbers = ec_numbers[ec_numbers != ""];
	
	if (!is.null(ec_numbers)) {
		print(ec_numbers);
	
		for(num in ec_numbers) {
			sabiork::query(num, cache = sabio_rk);
		}
	}
}

close(sabio_rk);