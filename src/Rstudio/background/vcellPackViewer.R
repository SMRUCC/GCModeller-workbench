# imports "router" from "G:\GCModeller\src\workbench\win32_desktop\src\Rstudio\Rserver\assembly\net6.0\RwebHost.dll";

require(GCModeller);
require(Rstudio);
require(Rserver);
require(JSON);

# imports "http" from "Rstudio";
imports "Inspector" from "GCModellerDesktop";
imports "rawXML" from "vcellkit";

# the data backend R# script file for inspect the vcell data pack file
const packfile as string  = ?"--file" || stop("no result file was provided!");
const httpPort as integer = ?"--listen" || 80;

const success = function(obj) {
  JSON::json_encode({
    code: 0,
    info: obj
  });
}

const view = Inspector::load(open.vcellPack(file = packfile, mode = "read"));
const http = router::parse({

  [@url "/get/count/"]
  const get_count = function(req, response) {
    print("handling get summary counts.");
    Inspector::counts(view)
    |> success()
    |> writeLines(con = response)
    ;
  }

  [@url "/get/molecule_list/"]
  const get_molecules = function(req, response) {
    const q = getUrl(req)$query;
    const li = Inspector::load.molecule_list(view, module = q$set);
    const res = {
      if (length(q$set) == 1) {
        list(
          size = length(li),
          set = li
        )
      } else {
        li;
      }
    }
    
    res
    |> success()
    |> writeLines(con = response)
    ;
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
|> httpMethod("GET",  handleHttpGet, accessAny = TRUE)
|> httpMethod("POST", [req, response] => writeLines("HTTP POST test success!", con = response))
|> httpMethod("PUT", [req, response] => writeLines("HTTP PUT test success!", con = response))
|> listen(port = httpPort)
;

print("http server shutdown!");