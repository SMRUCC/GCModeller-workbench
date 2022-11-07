namespace pages.viewers {

    export class view_protein_blast extends Bootstrap {

        private protein_ids: string[];
        private intptr: number = 0;

        public get appName(): string {
            return "blastp_viewer";
        };

        public get current_id(): string {
            if (isNullOrUndefined(this.protein_ids) ||
                isNullOrUndefined(this.intptr) ||
                (this.protein_ids.length == 0)) {

                return "Missing";
            } else {
                return this.protein_ids[this.intptr];
            }
        }

        protected init(): void {
            const vm = this;

            apps.gcmodeller
                .getProteinIDs()
                .then(async function (list) {
                    list = await list;
                    vm.protein_ids = list;
                    vm.viewBlastp(vm.protein_ids[0]);
                    vm.intptr = 0;

                    $ts("#number_proteins").display(vm.protein_ids.length.toString());
                });
        }

        public previous_onclick() {
            if (this.intptr == 0) {
                // do nothing
            } else {
                this.intptr--;
                this.viewBlastp(this.current_id);
            }
        }

        public next_onclick() {
            if (this.intptr == this.protein_ids.length - 1) {
                // do nothing
            } else {
                this.intptr++;
                this.viewBlastp(this.current_id);
            }
        }

        private viewBlastp(id: string) {
            const show = function (data: any[]) {
                const terms: string[] = [];
                const no_hits = data.length == 0 || (data.length == 1 && data[0].HitName == "HITS_NOT_FOUND");
                const scores: {} = {};

                console.table(data[0].HitName);
                console.log(no_hits);

                for (let i = 0; i < data.length; i++) {
                    delete data[i].QueryName;
                    delete data[i].HitName;
                    delete data[i].hit_length;
                    delete data[i].length_hit;
                    delete data[i].length_hsp;
                    delete data[i].length_query;
                    delete data[i].query_length;

                    data[i].evalue = data[i].evalue.toString();

                    if (!Strings.Empty(<string>data[i].description, true)) {
                        const term_id: string = (<string>data[i].description).split('|')[0];

                        terms.push(term_id);

                        if (!(term_id in scores)) {
                            scores[term_id] = 0;
                        }

                        scores[term_id] += data[i].score;
                    }
                }

                let subtitle: string;

                if (no_hits) {
                    subtitle = `<div class="alert alert-warning" role="alert" data-mdb-color="warning" style="width: 400px;">
                    <i class="fas fa-exclamation-triangle me-3"></i>
                    ${id} has no hits!
                </div>`;
                } else {
                    subtitle = `${id} has ${data.length} annotation hits supports`;
                }

                $ts("#blast_output").clear();
                $ts("#protein_id").clear().display(subtitle);

                if (!no_hits) {
                    $ts.appendTable(data, "#blast_output", null, { class: ["table", "table-sm"] });
                } else {

                }

                const hits = $from(terms)
                    .GroupBy(x => x)
                    .Select(function (term) {
                        return {
                            name: term.Key,
                            value: term.Count
                        };
                    })
                    .ToArray();

                console.log("get hits summary:");
                console.table(hits);
                console.log(scores);

                new js_plot.piePlot("Annotation Hits Supports", "Term Hits", "preview_1")
                    .plot("protein hits", hits)
                    ;
                new js_plot.barplot("preview_2").plot(
                    $from(Object.keys(scores)).Select(function (name) {
                        return { name: name, value: Math.log(scores[name]) };
                    })
                );
            }

            apps.gcmodeller.getBlastp(id).then(async function (json) {
                json = await json;
                show(JSON.parse(json));
            });
        }
    }
}