require(JSON);
require(GCModeller);

imports "enzymatic" from "vcellkit";

setwd(@dir);

const rhea = read.rhea("../data/rhea/rhea-reactions.txt");
