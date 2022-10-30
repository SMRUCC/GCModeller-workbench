require(HDS);

db = HDS::openStream("E:\GCModeller\src\workbench\win32_desktop\demo\ncbi_dataset\GCF_000005845\eco.bioproj");

tree = HDS::tree(db);

print(tree);

writeLines(tree, con = `${@dir}/tree.txt`);
