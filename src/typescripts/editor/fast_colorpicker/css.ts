namespace uikit.colorPicker {

    export const selectpicker: string = "selectpicker";

    export function doStyle() {
        let htmlHead = $ts("&head");

        if (isNullOrUndefined($ts("#context-style"))) {
            htmlHead.appendElement($ts("<style>", {
                id: "context-style"
            }).display(`
        .${selectpicker} {
            width: 150px;
            box-shadow: 2px 2px 5px lightgray;
            border-style: solid;
            border-width: 1px;
            border-color: grey;
            border-radius: 3px;
            padding-left: 5px;
            padding-right: 5px;
            padding-top: 3px;
            padding-bottom: 3px;
            position: fixed;
            background-color: white;
text-align: left !important;
        }

        .color-item:hover {
        background-color: skyblue;
    }

        .color-item {
            height: 24px;
        }`)
            );
        }
    }
}