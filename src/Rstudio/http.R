require(Rserver);

imports "vbhtml" from "RwebHost";
imports "http" from "RwebHost";

# title: R# web http server
# author: xieguigang
# description: a commandline R# script for running a http web server.

[@info "the http port for listen, 80 port number is used by default."]
const httpPort as integer  = ?"--listen"  || 80;
[@info "A directory path that contains the R script for running in this R# web server."]
[@type "directory"]
const webContext as string = ?"--wwwroot" || `${@dir}/../../web/`;

#' Route url as local R script file
#' 
#' @param url the url object that parsed from the
#'     http request.
#' 
const router = function(url) {
  const relpath as string = trim(url$path, ".");
  const isMap_temp as boolean = startsWith(url$path, "@temp");

  if (relpath == "") {
    list(
      file = normalizePath(`${webContext}/index.html`),
      is_script = FALSE
    );
  } else {
    let file = `${webContext}/${relpath}.R`;

    if (file.ext(relpath) != "R") {
      const tempfile as string = ifelse(isMap_temp, gsub(relpath, "@temp", getOption("system_tempdir")), `${webContext}/${relpath}`); 
      
      print("non-script file:");
      print(tempfile);

      list(
        file = normalizePath(tempfile), 
        is_script = FALSE
      );
    } else {
      if (file.exists(file)) {
        list(file = normalizePath(file), is_script = TRUE);
      } else {
        list(file = normalizePath(`${webContext}/${relpath}/index.html`), is_script = FALSE);
      }
    }
  }  
}

#' Handle http GET request
#' 
const handleHttpGet = function(req, response) {
  const local = router(getUrl(req));

  print("request from the browser client:");
  str(getUrl(req));

  print("view the request data headers:");
  str(getHeaders(req));

  print("this is the unparsed raw text of the http header message:");
  print(getHttpRaw(req));

  if ([local$is_script] && file.exists(local$file)) {
	print(`run script: '${local$file}'!`);
    writeLines(source(local$file), con = response);
  } else {
    if (!local$is_script) {
      if (file.ext(local$file) in ["html","htm","txt", "vbhtml"]) {
        if (file.ext(local$file) == "vbhtml") {
		  print("Rendering html page and send content data!");
		  
          [local$file] 
          |> vbhtml::rendering(
            wwwroot = webContext
          )
          |> writeLines(con = response)
          ;
        } else {
		  print("Response a html text file!");
		
          writeLines(readText(local$file), con = response);
        }        
      } else {
		print(`Push file downloads: '${local$file}'!`);
        response 
        |> pushDownload(local$file)
        ;
      }
    } else {
      response
      |> httpError(404, `the required Rscript file is not found on filesystem location: '${ normalizePath(local$file) }'!`)
      ;
    }
  }
}

#' Handle http POST request
#' 
const handleHttpPost = function(req, response) {
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
|> httpMethod("GET",  handleHttpGet, accessAny = TRUE)
|> httpMethod("POST", handleHttpPost, accessAny = TRUE)
|> httpMethod("PUT", [req, response] => writeLines("HTTP PUT test success!", con = response), accessAny = TRUE)
|> listen(port = httpPort)
;
