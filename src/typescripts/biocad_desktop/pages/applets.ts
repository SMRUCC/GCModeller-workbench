namespace pages {

    export class applets extends Bootstrap {

        public get appName(): string {
            return "applets";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
            pages.background.run();
        }
    }
}