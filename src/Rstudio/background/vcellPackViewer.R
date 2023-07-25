# imports "router" from "G:\GCModeller\src\workbench\win32_desktop\src\Rstudio\Rserver\assembly\net6.0\RwebHost.dll";

require(GCModeller);
require(Rstudio);
require(Rserver);

# imports "http" from "Rstudio";
imports "Inspector" from "GCModellerDesktop";
imports "rawXML" from "vcellkit";

# the data backend R# script file for inspect the vcell data pack file
const packfile as string  = ?"--file" || stop("no result file was provided!");
const httpPort as integer = ?"--listen" || 80;

const view = Inspector::load(open.vcellPack(file = packfile, mode = "read"));
const http = router::parse({

  [@url "/get/count/"]
  const get_count = function(req, response) {
    print("handling get summary counts.");
    writeLines(111, response);
  }

});

const handleHttpGet = function(req, response) {
    # implements the vcell data pack reader viewer code at this function
    # http get for read data
    const url = getUrl(req);

    print("request from the browser client:");
    str(url);

    router::handle(req, response, http);

    print("end of http processor!");
}

print(http);
cat("\n\n");
print(`background http services listen at port number: ${httpPort}.`);

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

print("http server shutdown!");