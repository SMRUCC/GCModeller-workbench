require(JSON);
require(charts);

const run = function(ssid) {
    const session_data as string = `${getOption("system_tempdir")}/${ssid}/plas.dat`;
    const session_plot as string = `${getOption("system_tempdir")}/${ssid}/plas.png`;
    const data = readRDS(session_data);

    print("previews of the simulator output time line snapshots:");
    print(data, max.print = 6);

    # x axis
    const time_x as double = as.numeric(data[, "#time"]);
    const symbols = colnames(data) 
    |> which(name -> name != "#time") 
    |> lapply(name -> as.numeric(data[, name]), names = name -> name)
    ;
    const colorSet = colors("paper", n = length(symbols), character = TRUE);

    print("time:");
    print(time_x);
    print("S-systems output:");
    str(symbols);

    const lines = sapply(names(symbols), function(name, i) {
        const y = symbols[[name]];
        const sline = serial(time_x, y, name = name, color = colorSet[i]);

        sline;
    });

    bitmap(file = session_plot, size = [2100, 1600]) {
        plot(lines, line = TRUE, y.format = "G2", padding = "padding: 150px 200px 200px 300px;",grid.fill = "white");
    }

    json_encode({
        code: 0,
        info: `/@temp/${ssid}/plas.png`
    })
    |> writeLines(con = buffer("text"))
    ;
}