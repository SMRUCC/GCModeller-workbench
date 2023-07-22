require(GCModeller);
require(Rstudio);

imports "Inspector" from "GCModellerDesktop";
imports "rawXML" from "vcellkit";

# the data backend R# script file for inspect the vcell data pack file
const packfile as string = ?"--file" || stop("no result file was provided!");
const view = Inspector::load(open.vcellPack(file = packfile, mode = "read"));

