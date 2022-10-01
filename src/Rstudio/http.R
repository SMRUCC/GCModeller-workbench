imports "http" from "Rhttp";

# title: R# web http server
# author: xieguigang
# description: a commandline R# script for running a http web server.

[@info "the http port for listen, 80 port number is used by default."]
const httpPort as integer  = ?"--listen"  || 80;
[@info "A directory path that contains the R script for running in this R# web server."]
[@type "directory"]
const webContext as string = ?"--wwwroot" || `${dirname(@script)}/../web.R`;

#' Route url as local R script file
#' 
#' @param url the url object that parsed from the
#'     http request.
#' 
const router as function(url) {
  `${webContext}/${ trim(url$path, ".") }.R`;
}

#' Handle http GET request
#' 
const handleHttpGet as function(req, response) {
  const R as string = router(getUrl(req));

  print("request from the browser client:");
  str(getUrl(req));

  print("view the request data headers:");
  str(getHeaders(req));

  print("this is the unparsed raw text of the http header message:");
  print(getHttpRaw(req));

  if (file.exists(R)) {
    writeLines(source(R), con = response);
  } else {
    response
    |> httpError(404, `the required Rscript file is not found on filesystem location: '${ normalizePath(R) }'!`)
    ;
  }
}

#' Handle http POST request
#' 
const handleHttpPost as function(req, response) {
  const R as string = router(getUrl(req));

  str(getUrl(req));
  str(getHeaders(req));

  print(getHttpRaw(req));

  if (file.exists(R)) {
    writeLines(source(R), con = response);
  } else {
    response
    |> httpError(404, `the required Rscript file is not found on filesystem location: '${ normalizePath(R) }'!`)
    ;
  }
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
|> httpMethod("POST", handleHttpPost)
|> httpMethod("PUT", [req, response] => writeLines("HTTP PUT test success!", con = response))
|> listen(port = httpPort)
;
