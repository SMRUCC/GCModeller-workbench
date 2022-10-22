namespace pages {

    export class zscore_analysis extends analysis_session {

        public get appName(): string {
            return "z_score";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
        }

        public button_open_onclick() {
            desktop.loading("Open matrix file...");
            apps.gcmodeller
                .getFileOpen(apps.expressionMatrix)
                .then(async function (path) {
                    const file: string = await path;
                    const textbox: HTMLInputElement = <any>$ts("#matrix-file");

                    textbox.value = file;
                    desktop.closeSpinner();
                });
        }

        public run_onclick() {
            const vm = this;

            desktop.loading("Do z-score plot...");

            const file = $ts.value("#matrix-file");
            const json = {                
                file: file,
                ssid: ""
            };

            json.ssid = super.generateSsid(json);

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_zscore"), JSON.stringify(json))
                .then(async function (result) {
                    desktop.promiseAsyncCallback<string>(result, function (flag, message) {
                        if (!flag) {
                            desktop.showToastMessage(message.info, "Run Z-score", "danger");
                        } else {
                            // request image display
                            vm.session_id = json.ssid;
                            vm.refresh_Rplot_onclick();

                            // show table
                            const data = $ts.csv(message.info, true).Objects();
                            const previews = data.Take(10);

                            $ts("#zscore-table").clear();
                            $ts.appendTable(previews, "#zscore-table", null, { class: ["table", "table-sm"] });
                        }
                    });
                });
        }

        public refresh_Rplot_onclick() {
            const colorSet: string = $ts.select.getOption("#colorSet");
            const json = { ssid: this.session_id, colorSet: colorSet };

            desktop.loading("Do z-score plot...");
            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_Rplot"), JSON.stringify(json))
                .then(async function (result) {
                    desktop.promiseAsyncCallback<string>(result, function (flag, message) {
                        if (!flag) {
                            desktop.showToastMessage(message.info, "Plot Z-score", "danger");
                        } else {
                            const img_url: string = `${message.info}?refresh=${md5(desktop.now())}`;

                            // show images
                            $ts("#Rplot-box").CType<HTMLAnchorElement>().href = img_url;
                            $ts("#Rplot_js").CType<HTMLImageElement>().src = img_url;
                            $ts.goto("#example-3-collapsible");
                            
                            desktop.closeSpinner();
                            desktop.showToastMessage("Expression data patterns plot success!", "Plot Z-score", "success");
                        }
                    });
                });
        }
    }
}