namespace pages {

    export class settings extends Bootstrap {

        public get appName(): string {
            return "settings";
        };

        private rawConfigs: desktop.configuration;

        //#region "page proxy"
        private GetSettings(): desktop.configuration {
            var hostApp: any = apps.gcmodeller;
            var result: desktop.configuration = hostApp.GetSettings();

            return result;
        }

        private SaveSettings() {
            var hostApp: any = apps.gcmodeller;
            var config = {
                BlastBin: "",
                BlastDb: "",
                RepositoryRoot: "",
                RememberWindowStatus: $ts("#RememberWindowStatus").CType<HTMLInputElement>().checked,
                Language: ""
            };
            var jsonStr: string = JSON.stringify(config);

            hostApp.SaveSettings(jsonStr);
        }
        //#endregion

        protected init(): void {
            this.rawConfigs = this.GetSettings();
            this.loadSettings();
        }

        private async loadSettings() {
            var configs = await this.rawConfigs;
            var IDEconfigs = await configs.Dev2;
            var windowConfig = await IDEconfigs.IDE;

            $ts("#RememberWindowStatus").CType<HTMLInputElement>().checked = await IDEconfigs.RememberWindowStatus;
        }

        public RememberWindowStatus_onchange() {
            this.SaveSettings();
        }
    }
}