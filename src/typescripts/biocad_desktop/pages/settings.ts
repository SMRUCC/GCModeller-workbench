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
                BlastBin: $ts("#ncbi_blast_folder").CType<HTMLInputElement>().value,
                BlastDb: "",
                RepositoryRoot: "",
                RememberWindowStatus: $ts("#RememberWindowStatus").CType<HTMLInputElement>().checked,
                Language: $ts("#language").CType<HTMLSelectElement>().selectedIndex,
                CloseAfterProjectLoad: $ts("#CloseAfterProjectLoad").CType<HTMLInputElement>().checked,
                ShowOnStartUp: $ts("#ShowOnStartUp").CType<HTMLInputElement>().checked
            };
            var jsonStr: string = JSON.stringify(config);

            hostApp.SaveSettings(jsonStr);
        }
        //#endregion

        protected init(): void {
            desktop.loading("Load configurations...");

            this.rawConfigs = this.GetSettings();
            this.loadSettings();
        }

        private async loadSettings() {
            var configs = await this.rawConfigs;
            var IDEconfigs = await configs.Dev2;
            var windowConfig = await IDEconfigs.IDE;
            var startPage = await IDEconfigs.StartPage;

            $ts("#RememberWindowStatus").CType<HTMLInputElement>().checked = await IDEconfigs.RememberWindowStatus;
            $ts("#CloseAfterProjectLoad").CType<HTMLInputElement>().checked = await startPage.CloseAfterProjectLoad;
            $ts("#ShowOnStartUp").CType<HTMLInputElement>().checked = await startPage.ShowOnStartUp;
            $ts("#language").CType<HTMLSelectElement>().selectedIndex = await windowConfig.Language;
            $ts("#ncbi_blast_folder").CType<HTMLInputElement>().value = await configs.BlastBin;

            setTimeout(desktop.closeSpinner, 500);
        }

        public RememberWindowStatus_onchange() {
            this.SaveSettings();
        }

        public language_onchange() {
            this.SaveSettings();
        }

        public CloseAfterProjectLoad_onclick() {
            this.SaveSettings();
        }

        public ShowOnStartUp_onclick() {
            this.SaveSettings();
        }

        public open_ncbi_blast_folder_onclick() {
            const textbox: HTMLInputElement = <any>$ts("#ncbi_blast_folder");

            desktop.loading("Load configurations...");
            apps.gcmodeller
                .getFolderOpen()
                .then(async function (dir) {
                    textbox.value = dir;
                    desktop.closeSpinner();
                })
                ;
        }
    }
}