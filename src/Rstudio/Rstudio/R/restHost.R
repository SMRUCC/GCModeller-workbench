require(JSON);

#' echo back the success message data to the 
#' desktop client
#' 
#' @param data any kind of the R# data object, the object data
#'   will be encoded as json string automatically in this 
#'   function
#' 
const echo_successMsg = function(data, code = 0) {
    print("view of the message data to post back:");
    str(data);

    json_encode({
        code: code,
        info: data
    })
    |> writeLines(con = buffer("text"))
    ;
}