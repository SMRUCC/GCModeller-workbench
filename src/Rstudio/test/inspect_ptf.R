require(HDS);
require(JSON);

db = HDS::openStream("E:\GCModeller\src\workbench\win32_desktop\demo\ncbi_dataset\GCF_000005845\eco.bioproj");

tree = HDS::tree(db);

print(tree);

writeLines(tree, con = `${@dir}/eco_project.txt`);

writeLines(db |> HDS::getText("/models/subcellular_location.json"), con = `${@dir}/eco_subcellularLocation.json`);
writeLines(db |> HDS::getText("/models/ec_numbers.json"), con = `${@dir}/eco_ec_numbers.json`);

db = HDS::openStream("E:\etc\repository\EC_numbers.db");

list = bdecode(db |> HDS::getText("/subcellularLocation.txt"));

writeLines(json_encode(list), con = `${@dir}/subcellularLocation.json`);

tree = HDS::tree(db);

# print(tree);

writeLines(tree, con = `${@dir}/ec_numbers.txt`);
writeLines(db |> HDS::getText("/subcellularLocation.txt"), con = `${@dir}/subcellularLocation.txt`);

