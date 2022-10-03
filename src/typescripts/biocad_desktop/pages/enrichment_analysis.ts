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

                const type: string = $ts.select.getOption("#enrichment_background");
                const symbols: string = $ts.value("#input_idlist");

                if (Strings.Empty(type)) {
                    desktop.showToastMessage("Please select a background for enrichment analysis at first!", "Enrichment Analysis", null, "danger");
                } else if (Strings.Empty(symbols)) {
                    desktop.showToastMessage("No gene/protein id list to run enrichment analysis!", "Enrichment Analysis", null, "danger");
                } else {
                    const json: string = JSON.stringify({
                        id: this.database,
                        background: type,
                        symbols: Strings.lineTokens(symbols)
                    });

                    apps.gcmodeller
                        .sendPost($ts.url("@web_invoke_enrichment"), json)
                        .then(async function (result) {
                            desktop.parseMessage(result).then(function (message) {
                                desktop.parseResultFlag(result, message).then(function (flag) {
                                    const title = flag ? "Run Enrichment Success" : "Analysis Error";
                                    const data: { counts: number, proteins: string } = <any>message.info;

                                    console.log(data);

                                    if (flag) {
                                        // success
                                        const table = $ts.csv(<any>data, true)
                                            .Objects()
                                            .Where(a => a["pvalue"] < 0.05)
                                            ;

                                        $ts("#enrichment-result-table").clear();
                                        $ts.appendTable(table, "#enrichment-result-table", null, { class: ["table", "table-sm"] });
                                        $ts("#ex-with-icons-tabs-1").removeClass("show").removeClass("active");
                                        $ts("#ex-with-icons-tabs-2").addClass("show").addClass("active");

                                        desktop.showToastMessage("Success!", title, null, "success");
                                    } else {
                                        // error
                                        desktop.showToastMessage(message.info, title, null, "danger");
                                    }
                                });
                            });
                        });
                }
            }
        }
    }
}