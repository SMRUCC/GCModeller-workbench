namespace pages {

    export class enrichment_analysis extends Bootstrap {

        private database: string;
        private static note_mapping = {
            "GO": "go_note",
            "keyword": "uniprot_note",
            "Pfam": "pfam_note",
            "InterPro": "interpro_note"
        };
        private session_id: string;

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

        public background_onchange(value: string) {
            const note_id: string = enrichment_analysis.note_mapping[value];

            for (let name in enrichment_analysis.note_mapping) {
                $ts(`#${enrichment_analysis.note_mapping[name]}`).hide();
            }

            $ts(`#${note_id}`).show();
        }

        public run_onclick() {
            if (Strings.Empty(this.database)) {
                desktop.showToastMessage("Please select a database at first!", "Enrichment Analysis", null, "danger");
            } else {
                $ts("#busy-indicator").show();

                const type: string = $ts.select.getOption("#background");
                const symbols: string = $ts.value("#input_idlist");

                if (Strings.Empty(type)) {
                    desktop.showToastMessage("Please select a background for enrichment analysis at first!", "Enrichment Analysis", null, "danger");
                } else if (Strings.Empty(symbols)) {
                    desktop.showToastMessage("No gene/protein id list to run enrichment analysis!", "Enrichment Analysis", null, "danger");
                } else {
                    this.runInternal(type, symbols);
                }
            }
        }

        private runInternal(type: string, symbols: string) {
            const ssid: string = md5(`enrichment-${(new Date()).toLocaleTimeString("en-US")}-${type}-${symbols}`);
            const vm = this;
            const json: string = JSON.stringify({
                id: this.database,
                background: type,
                symbols: Strings.lineTokens(symbols),
                ssid: ssid
            });

            let url: (any) => string = function (any) { return any["name"] };

            if (type == "keyword") {
                url = function (term) {
                    return `<a target="__blank" href="https://www.uniprot.org/keywords/${term[""]}">${term["name"]}</a>`;
                }
            }

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_enrichment"), json)
                .then(async function (result) {
                    desktop.parseMessage(result).then(function (message) {
                        desktop.parseResultFlag(result, message).then(function (flag) {
                            const title = flag ? "Run Enrichment Success" : "Analysis Error";
                            const data: string = message.info;

                            console.log(data);

                            if (flag) {
                                // success
                                const table = $ts.csv(data, true)
                                    .Objects()
                                    .Where(a => a["pvalue"] < 0.05)
                                    .Select(function (a) {
                                        a["name"] = url(a);
                                        return a;
                                    })
                                    ;

                                $ts("#enrichment-result-table").clear();
                                $ts.appendTable(table, "#enrichment-result-table", null, { class: ["table", "table-sm"] });
                                $ts("#ex-with-icons-tabs-1").removeClass("show").removeClass("active");
                                $ts("#ex-with-icons-tabs-2").addClass("show").addClass("active");
                                $ts("#ex-with-icons-tab-1").removeClass("active");
                                $ts("#ex-with-icons-tab-2").addClass("active");

                                vm.session_id = ssid;
                                // do data plot
                                vm.plot_onclick();

                                desktop.showToastMessage("Success!", title, null, "success");
                            } else {
                                // error
                                desktop.showToastMessage(message.info, title, null, "danger");
                            }
                        });
                    });
                });
        }

        public plot_onclick() {
            const json: string = JSON.stringify({
                session_id: this.session_id,
                type: "bar",
                background: $ts.select.getOption("#background"),
                top: 5
            });

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_Rplot"), json)
                .then(async function (result) {
                    desktop.parseMessage(result).then(function (message) {
                        desktop.parseResultFlag(result, message).then(function (flag) {
                            const title = flag ? "Run Enrichment Success" : "Analysis Error";
                            const data: string = message.info;

                            console.log(data);

                            if (flag) {

                            } else {
                                desktop.showToastMessage(message.info, title, null, "danger");
                            }
                        });
                    });
                });
        }
    }
}