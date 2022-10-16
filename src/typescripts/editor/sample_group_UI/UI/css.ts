namespace biodeep.ui {

    export function doStyle() {
        let htmlHead = $ts("&head");

        if (isNullOrUndefined($ts("#table-style"))) {
            htmlHead.appendElement($ts("<style>", {
                id: "table-style"
            }).display(`
            .selected {
                background-color: lightBlue;
            }
            `));
        }

        if (isNullOrUndefined($ts("#context-style"))) {
            htmlHead.appendElement($ts("<style>", {
                id: "context-style"
            }).display(`
        .menu {
            width: 150px;
            box-shadow: 1px 1px 5px #888888;
            border-style: solid;
            border-width: 1px;
            border-color: grey;
            border-radius: 2px;
            padding-left: 5px;
            padding-right: 5px;
            padding-top: 3px;
            padding-bottom: 3px;
            position: fixed;
            background-color: white;
            z-index: 999;
        }

        .menu-item {
            height: 20px;
        }

            .menu-item:hover {
                background-color: #6CB5FF;
                cursor: pointer;
            }
            `)
            );
        }
    }
}