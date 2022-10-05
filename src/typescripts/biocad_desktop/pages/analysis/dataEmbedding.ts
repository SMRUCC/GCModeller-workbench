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
            const busy = $ts("#busy-indicator");

            busy.show();

            apps.gcmodeller
                .getFileOpen("Excel Matrix(*.csv)|*.csv")
                .then(async function (result) {
                    textbox.value = await result;
                    busy.hide();
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
                desktop.showToastMessage("The matrix data input file can not be nothing!", "Data Embedding Analysis", "danger");
                return;
            }

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_embedding"), json)
                .then(async function (result) {
                    desktop.promiseAsyncCallback<string>(result, function (success, message) {
                        if (success) {
                            console.log(message.info);

                            // show table at first
                            // then run data plots
                            desktop.showToastMessage("Run Data Embedding Analysis Success!", `${method} Task Success`, "success");
                        } else {
                            desktop.showToastMessage(message.info, `${method} Task Error`, "danger");
                        }
                    });
                });
        }
    }
}