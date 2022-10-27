require(HDS);

db = HDS::openStream("E:\GCModeller\src\workbench\win32_desktop\demo\ncbi_dataset\GCF_000005845\eco.bioproj");

print(HDS::tree(db));
