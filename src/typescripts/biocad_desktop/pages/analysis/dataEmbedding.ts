/// <reference path="../analysis_session.ts" />

namespace pages {

    export class dataEmbedding extends analysis_session {

        public get appName(): string {
            return "dataEmbedding";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
        }

        public button_open_click() {
            const textbox = $ts("#matrix-file").CType<HTMLInputElement>();

            $ts("#busy-indicator").show();

            apps.gcmodeller
                .getFileOpen("Excel Matrix(*.csv)|*.csv")
                .then(async function (result) {
                    textbox.value = await result;
                    $ts("#busy-indicator").hide();
                });
        }

        public run_click() {
            $ts("#busy-indicator").show();

            const filepath: string = $ts.value("#matrix-file");
            const dimensions: number = $ts.value("#dimensions");
            const method: string = $ts.select.getOption("#algorithm");
            const session_id: string = super.generateSsid({ file: filepath, dims: dimensions, algo: method });
            const json = JSON.stringify({
                file: filepath,
                ssid: session_id,
                dims: dimensions,
                algorithm: method
            });

            if (Strings.Empty(filepath)) {
                desktop.showToastMessage("The matrix data input file can not be nothing!", "Data Embedding Analysis", null, "danger");
                return;
            }

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_embedding"), json)
                .then(async function (result) {

                });
        }
    }
}