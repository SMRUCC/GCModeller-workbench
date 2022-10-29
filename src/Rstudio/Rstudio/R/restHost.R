require(JSON);

const echo_successMsg = function(data, code = 0) {
    json_encode({
        code: code,
        info: data
    })
    |> writeLines(con = buffer("text"))
    ;
}