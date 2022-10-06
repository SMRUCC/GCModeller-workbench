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
            const z_score: boolean = $ts("#z-score").CType<HTMLInputElement>().checked;
            const json = JSON.stringify({
                file: filepath,
                ssid: session_id,
                dims: dimensions,
                algorithm: method,
                z_score: z_score
            });
            const vm = this;

            if (Strings.Empty(filepath)) {
                desktop.showToastMessage("The matrix data input file can not be nothing!", "Data Embedding Analysis", "danger");
                return;
            }

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_embedding"), json)
                .then(async function (result) {
                    desktop.promiseAsyncCallback<string>(result, function (success, message) {
                        if (success) {
                            const data = $ts.csv(message.info, true).Objects();
                            const previews = data.Take(10);

                            vm.session_id = session_id;

                            $ts("#embedding-table").clear();
                            $ts.appendTable(previews, "#embedding-table", null, { class: ["table", "table-sm"] });
                            dataEmbedding.plot3DScatter(session_id);

                            // show table at first
                            // then run data plots
                            desktop.showToastMessage("Run Data Embedding Analysis Success!", `${method} Task Success`, "success");
                        } else {
                            desktop.showToastMessage(message.info, `${method} Task Error`, "danger");
                        }
                    });
                });
        }

        // private static plot3DScatter(data: any[]) {
        //     const keys: string[] = Object.keys(data[0]);
        //     const name: string = keys[0];
        //     const x: string = keys[1];
        //     const y: string = keys[2];
        //     const z: string = keys[3];

        //     data = $from(data)
        //         .Select(a => [a[name], parseFloat(a[x]), parseFloat(a[y]), parseFloat(a[z])])
        //         .ToArray()
        //         ;
        //     data = [
        //         ["", "dim1", "dim2", "dim3"]
        //     ].concat(data);

        //     console.log("view of the data matrix for plot 3d scatter:");
        //     console.log(data);

        //     new js_plot.scatter3d("Rplot_js").plot(data);
        // }
        private static plot3DScatter(session_id: string) {
            const json: string = JSON.stringify({
                ssid: session_id,
                k: $ts.value("#kmeans")
            });

            apps.gcmodeller.sendPost($ts.url("@web_invoke_Rplot"), json).then(function (result) {
                desktop.promiseAsyncCallback<string>(result, function (success, message) {
                    if (success) {
                        const img_url: string = `${message.info}?refresh=${md5(desktop.now())}`;

                        // show images
                        $ts("#Rplot-box").CType<HTMLAnchorElement>().href = img_url;
                        $ts("#Rplot_js").CType<HTMLImageElement>().src = img_url;

                        $ts("#busy-indicator").hide();
                    } else {
                        desktop.showToastMessage(message.info, `Rplot Error`, "danger");
                    }
                });
            })
        }

        public refresh_Rplot_click() {
            $ts("#busy-indicator").show();

            if (!Strings.Empty(this.session_id)) {
                dataEmbedding.plot3DScatter(this.session_id);
            } else {
                desktop.showToastMessage("Data session id can not be nothing!", `Rplot Error`, "danger");
            }
        }

        public save_project_click() {
            desktop.showToastMessage("You should run this analysis from a data analysis project", `Report Error`, "danger");
        }

        public download_zip_click() {
            const url: string = $ts.url("@web_invoke_zip");
            const json: string = JSON.stringify({
                ssid: this.session_id
            });

            $ts("#busy-indicator").show();

            if (!Strings.Empty(this.session_id)) {
                apps.gcmodeller.sendPost(url, json).then(async function (result) {
                    desktop.promiseAsyncCallback<string>(result, function (success, message) {
                        if (success) {
                            const features = `
                                height=500, width=800, top=100, left=100, toolbar=no, 
                                menubar=no,
                                scrollbars=no,resizable=no, location=no, 
                                status=no`;

                            // request url to download
                            window.open(message.info, "newW", features);
                        } else {
                            desktop.showToastMessage(message.info, `Report Error`, "danger");
                        }

                        $ts("#download-group").show();
                        $ts("#busy-indicator").hide();
                    })
                })
            } else {
                desktop.showToastMessage("Data session id can not be nothing!", `Report Error`, "danger");
            }
        }
    }
}