imports "package_utils" from "devkit";

package_utils::attach("E:\GCModeller\src\workbench\pkg");

require(JSON);
require(GCModeller);

imports "enzymatic" from "vcellkit";
imports "sabiork" from "vcellkit";

# parser test
xml = "E:\GCModeller\src\workbench\win32_desktop\demo\searchKineticLaws_sbml_q=ecnumber_5.3.1.9.xml";
xml = sabiork::parseSbml(xml);

str([[xml]::model]::listOfFunctionDefinitions);

for(f in [[xml]::model]::listOfFunctionDefinitions) {
	print([f]::expression);
}

setwd(@dir);

const rhea = read.rhea("../data/rhea/rhea-reactions.txt");
# const sabio_rk = sabiork::new("./sabio-rk.db");
const sabio_rk = sabiork::open("./sabio-rk.db");

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