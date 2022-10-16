require(GCModeller);

imports "visualPlot" from "visualkit";
imports ["geneExpression", "sampleInfo"] from "phenotype_kit";

const sampleinfo = read.sampleinfo("E:\GCModeller\src\workbench\win32_desktop\demo\sampleinfo.csv");
const data = "E:\GCModeller\src\workbench\win32_desktop\demo\all_counts.csv"
|> read.csv(row_names = 1)
|> load.expr(rm_ZERO = TRUE)
|> average(sampleinfo = sampleinfo)
|> relative()
|> z_score()
;

write.expr_matrix(data, file = "E:\GCModeller\src\workbench\win32_desktop\demo\expr0.HTS", binary = TRUE);