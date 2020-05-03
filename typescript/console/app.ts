/// <reference path="shell.ts" />

let con = new SimpleConsole({
    handleCommand: shell.handle_command,
    placeholder: "Enter JavaScript, or ASCII emoticons :)",
    storageID: "simple-console demo"
});

document.getElementById("Rconsole").append(con.element);

con.logHTML(
    "<h1>Welcome to <a href='https://github.com/SMRUCC/GCModeller-workbench'>R# Workbench!</a></h1>" +
    "<p>Try entering <code>5 + 5</code> below. Or some faces (ASCII emoticons like <code>:-P</code>).</p>"
);