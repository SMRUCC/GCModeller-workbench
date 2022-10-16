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
                });
        }

        public run_onclick() {
            desktop.loading();
            
        }
    }
}