namespace pages {

    export class enrichment_analysis extends Bootstrap {

        public get appName(): string {
            return "enrichment_analysis";
        };

        protected init(): void {
            console.log($ts.location);
        }

    }
}