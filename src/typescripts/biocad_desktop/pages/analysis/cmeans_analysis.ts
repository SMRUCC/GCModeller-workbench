namespace pages {

    export class cmeans_patterns extends analysis_session {

        public get appName(): string {
            return "cmeans_pattern";
        };

        protected init(): void {

        }

        public button_open_click() {
            desktop.loading();
            apps.gcmodeller
                .getFileOpen(omicsAnalysis.expressionMatrix)
                .then(async function (path) {
                    const file: string = await path;
                    const textbox: HTMLInputElement = <any>$ts("#matrix-file");

                    textbox.value = file;
                    desktop.closeSpinner();
                });
        }

        public run_onclick() {
            const vm = this;

            desktop.loading();

            const rows = $ts.value("#rows");
            const cols = $ts.value("#cols");
            const algo = $ts.select.getOption("#algorithm");
            const z = $ts.value("#z-score");
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
                        }
                    });
                });
        }

        public refresh_Rplot_onclick() {
            const json = { ssid: this.session_id };

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