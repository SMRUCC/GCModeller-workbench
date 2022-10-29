namespace pages {

    export class cmeans_patterns extends analysis_session {

        public get appName(): string {
            return "cmeans_pattern";
        };

        protected init(): void {

        }

        public button_open_click() {
            desktop.winforms.openfileDialog("#matrix-file", apps.expressionMatrix);
        }

        public run_onclick() {
            const vm = this;

            desktop.loading();

            const rows = $ts.value("#rows");
            const cols = $ts.value("#cols");
            const algo = $ts.select.getOption("#algorithm");
            const z = $ts("#z-score").CType<HTMLInputElement>().checked;
            const file = $ts.value("#matrix-file");
            const json = {
                layout: [rows, cols],
                algorithm: algo,
                z_score: z,
                file: file,
                ssid: ""
            };

            json.ssid = super.generateSsid(json);

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_clustering"), JSON.stringify(json))
                .then(async function (result) {
                    desktop.promiseAsyncCallback<string>(result, function (flag, message) {
                        if (!flag) {
                            desktop.showToastMessage(message.info, "Run CMeans", "danger");
                        } else {
                            // request image display
                            vm.session_id = json.ssid;
                            vm.refresh_Rplot_onclick();

                            // show table
                            const data = $ts.csv(message.info, true).Objects();
                            const previews = data.Take(10);

                            $ts("#patterns-table").clear();
                            $ts.appendTable(previews, "#patterns-table", null, { class: ["table", "table-sm"] });
                        }
                    });
                });
        }

        public refresh_Rplot_onclick() {
            const colorSet: string = $ts.select.getOption("#colorSet");
            const json = { ssid: this.session_id, colorSet: colorSet };

            desktop.loading();
            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_Rplot"), JSON.stringify(json))
                .then(async function (result) {
                    desktop.promiseAsyncCallback<string>(result, function (flag, message) {
                        if (!flag) {
                            desktop.showToastMessage(message.info, "Plot Patterns", "danger");
                        } else {
                            const img_url: string = `${message.info}?refresh=${md5(desktop.now())}`;

                            // show images
                            $ts("#Rplot-box").CType<HTMLAnchorElement>().href = img_url;
                            $ts("#Rplot_js").CType<HTMLImageElement>().src = img_url;
                            $ts.goto("#example-3-collapsible");
                            $ts("#busy-indicator").hide();

                            desktop.showToastMessage("Expression data patterns plot success!", "Plot Patterns", "success");
                        }
                    });
                });
        }
    }
}