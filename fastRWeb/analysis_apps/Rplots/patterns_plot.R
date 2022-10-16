require(JSON);
require(GCModeller);

imports "geneExpression" from "phenotype_kit";
imports "visualPlot" from "visualkit";

const run = function(ssid) {
    const session_file as string = `${getOption("system_tempdir")}/${ssid}/patterns_data.dat`;
    const session_plot as string = `${getOption("system_tempdir")}/${ssid}/TCseq.png`;
    const patterns = geneExpression::readPattern(session_file);

    print("view patterns result:");
	print(patterns);

    bitmap(file = session_plot) {
        plot(patterns,
            size           = [9000, 5000], 
            colorSet       = "Jet", 
            axis_label.cex = "font-style: normal; font-size: 14; font-family: Microsoft YaHei;"
        );
    }

    json_encode({
        code: 0,
        info: `/@temp/${ssid}/${basename(session_plot)}.png`
    })
    |> writeLines(con = buffer("text"))
    ;
}