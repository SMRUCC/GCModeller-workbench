require(HDS);

db = HDS::openStream("/etc/repository/ptf/e434dd9c7f573fb03924e0c4d3d44d45.db");

print(HDS::tree(db));
