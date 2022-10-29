require(JSON);

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