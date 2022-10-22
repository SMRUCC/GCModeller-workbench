namespace pages {

    export class Settings extends Bootstrap {

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

        }
    }
}