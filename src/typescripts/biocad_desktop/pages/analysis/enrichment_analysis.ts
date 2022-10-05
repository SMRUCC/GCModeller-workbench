/// <reference path="../analysis_session.ts" />

namespace pages {

    export class enrichment_analysis extends analysis_session {

        private database: string;
        private static note_mapping = {
            "GO": "go_note",
            "keyword": "uniprot_note",
            "Pfam": "pfam_note",
            "InterPro": "interpro_note",
            "EC": "ec_note",
            "eggNOG": "eggnog_note"
        };

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
                desktop.showToastMessage("Please select a database at first!", "Enrichment Analysis", "danger");
            } else {
                $ts("#busy-indicator").show();

                const type: string = $ts.select.getOption("#background");
                const symbols: string = $ts.value("#input_idlist");

                if (Strings.Empty(type)) {
                    desktop.showToastMessage("Please select a background for enrichment analysis at first!", "Enrichment Analysis", "danger");
                } else if (Strings.Empty(symbols)) {
                    desktop.showToastMessage("No gene/protein id list to run enrichment analysis!", "Enrichment Analysis", "danger");
                } else {
                    this.runInternal(type, symbols);
                }
            }
        }

        private static term_url(type: "keyword" | "GO" | "EC" | "eggNOG" | "Pfam" | "InterPro"): Delegate.Func<any, string> {
            switch (type) {
                case "keyword":
                    return function (term) {
                        return `<a target="__blank" href="https://www.uniprot.org/keywords/${term[""]}">${term["name"]}</a>`;
                    }
                case "GO":
                    return function (term) {
                        return `<a target="__blank" href="http://amigo.geneontology.org/amigo/term/${term[""]}">${term["name"]}</a>`;
                    }
                case "Pfam":
                    return function (term) {
                        return `<a target="__blank" href="https://www.ebi.ac.uk/interpro/entry/pfam/${term[""]}/">${term["name"]}</a>`;
                    }
                case "InterPro":
                    return function (term) {
                        return `<a target="__blank" href="https://www.ebi.ac.uk/interpro/entry/InterPro/${term[""]}/">${term["name"]}</a>`;
                    }
                case "EC":
                    return function (term) {
                        return `<a target="__blank" href="https://www.genome.jp/dbget-bin/www_bfind_sub?mode=bfind&max_hit=1000&dbkey=enzyme&keywords=${term[""]}">${term["name"]}</a>`;
                    }

                default: return function (any) { return any["name"] };
            }
        }

        private runInternal(type: string, symbols: string) {
            const ssid: string = super.generateSsid({ type: type, symbols: symbols });
            const vm = this;
            const json: string = JSON.stringify({
                id: this.database,
                background: type,
                symbols: Strings.lineTokens(symbols),
                ssid: ssid
            });

            let url: (any) => string = enrichment_analysis.term_url(<any>type);

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_enrichment"), json)
                .then(function (result) {
                    desktop.promiseAsyncCallback<string>(result, function (flag, message) {
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

                            desktop.showToastMessage("Success!", title, "success");
                        } else {
                            // error
                            desktop.showToastMessage(message.info, title, "danger");
                        }
                    });
                });
        }

        public plot_onclick() {
            $ts("#busy-indicator").show();

            const json: string = JSON.stringify({
                session_id: this.session_id,
                type: "bar",
                background: $ts.select.getOption("#background"),
                top: 5
            });

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_Rplot?base64=true"), json)
                .then(async function (result) {
                    desktop.parseMessage(result).then(function (message) {
                        desktop.parseResultFlag(result, message).then(function (flag) {
                            const title = flag ? "Run Enrichment Success" : "Analysis Error";
                            const data: string = message.info;

                            console.log(data);

                            if (flag) {
                                $ts("#Rplot").CType<HTMLImageElement>().src = data;
                                $ts("#Rplot-box").CType<HTMLAnchorElement>().href = data;

                                $ts("#busy-indicator").hide();
                            } else {
                                desktop.showToastMessage(message.info, title, "danger");
                            }
                        });
                    });
                });
        }
    }
}