require(JSON);
require(GCModeller);

imports "S.system" from "simulators";

const run = function(odes, constants, session_id, final_time = 5, resolution = 10000) {
    const session_file as string = `${getOption("system_tempdir")}/${session_id}/plas.csv`;

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

    # set y0 of the ODEs system
    const symbol_names = sapply(odes, x -> first(strsplit(x$target, "=", fixed = TRUE)));
    const symbols = lapply(odes, x -> as.numeric(x$value), names = symbol_names);
    const consts = lapply(constants, x -> as.numeric(x$value), names = x -> x$target);
    const ssystem = lapply(odes, function(t) {
        const split = unlist(strsplit(t$target, "=", fixed = TRUE));
        const expr = split[2];

        expr;
    });

    names(ssystem) = symbol_names;
    consts$is.const = TRUE;

    print("get odes symbols y0:");
    str(symbols);
    print("symbol expressions:");
    str(ssystem);

    using data.driver as snapshot(session_file, symbols = names(symbols)) {
        data.driver
        |> kernel(S.script(session_id))
        |> environment(symbols = consts)
        |> environment(symbols = symbols)
        |> s.system(ssystem = ssystem)
        |> run(ticks = final_time, resolution = 1/as.numeric(resolution))
        ;
    }

    json_encode({
        code: 0,
        info: `/@temp/${session_id}/plas.csv`
    })
    |> writeLines(con = buffer("text"))
    ;
}