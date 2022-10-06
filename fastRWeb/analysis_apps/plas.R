require(JSON);
require(GCModeller);

const run = function(odes, constants, session_id, final_time = 5, resolution = 10000) {
    const session_file as string = `${getOption("system_tempdir")}/${session_id}/plas.dat`;

    odes = json_decode(odes);
    constants = json_decode(constants);

    print("view of the dynamics system inputs:");
    print("odes");
    str(odes);
    print("constants");
    str(constants);
    print("t");
    print(final_time);
    print("resolution");
    print(resolution);

    stop("123");
}