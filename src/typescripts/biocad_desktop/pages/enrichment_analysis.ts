namespace pages {

    export class enrichment_analysis extends Bootstrap {

        private database: string;

        public get appName(): string {
            return "enrichment_analysis";
        };

        protected init(): void {
            if ($ts.location.hasQueryArguments) {
                this.database = $ts.location("id");
            }

            console.log($ts.location);
            $ts("#busy-indicator").hide();
        }

        public run_onclick() {
            if (Strings.Empty(this.database)) {
                desktop.showToastMessage("Please select a database at first!", "Enrichment Analysis", null, "danger");
            } else {
                $ts("#busy-indicator").show();
            }
        }
    }
}