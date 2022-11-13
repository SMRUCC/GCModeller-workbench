imports "package_utils" from "devkit";

package_utils::attach("E:\GCModeller\src\workbench\pkg");

require(JSON);
require(GCModeller);

imports "enzymatic" from "vcellkit";
imports "sabiork" from "vcellkit";

setwd(@dir);

const sabio_rk = sabiork::open("./sabio-rk.db");
const kineticis = sabiork::get_kineticis(sabio_rk, "5.3.1.9");

str(kineticis);

for(law in kineticis) {
	str(law);
}