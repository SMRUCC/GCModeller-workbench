require(GCModeller);
require(Rstudio);
require(Rserver);

imports "vbhtml" from "RwebHost";
imports "http" from "Rstudio";
imports "Inspector" from "GCModellerDesktop";
imports "rawXML" from "vcellkit";

# the data backend R# script file for inspect the vcell data pack file
const packfile as string  = ?"--file" || stop("no result file was provided!");
const httpPort as integer = ?"--listen" || 19695;

const view = Inspector::load(open.vcellPack(file = packfile, mode = "read"));
const handleHttpGet = function(req, response) {
    # implements the vcell data pack reader viewer code at this function
    # http get for read data
    const url = getUrl(req);

    print("request from the browser client:");
    str(url);

    
}

cat("\n\n");

http::http_socket()
|> headers(
  "X-Powered-By" = "R# web server",
  "Author"       = "xieguigang <xie.guigang@gcmodeller.org>",
  "Github"       = "https://github.com/rsharp-lang/Rserver",
  "Organization" = "R# language <https://github.com/rsharp-lang/>"
)
|> httpMethod("GET",  handleHttpGet)
|> httpMethod("POST", [req, response] => writeLines("HTTP POST test success!", con = response))
|> httpMethod("PUT", [req, response] => writeLines("HTTP PUT test success!", con = response))
|> listen(port = httpPort)
;
