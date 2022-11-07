namespace pages.viewers {

    export class view_protein_blast extends Bootstrap {

        private protein_ids: string[];
        private intptr: number = 0;

        public get appName(): string {
            return "blastp_viewer";
        };

        public get current_id(): string {
            return this.protein_ids[this.intptr];
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

                for (let i = 0; i < data.length; i++) {
                    delete data[i].QueryName;
                    delete data[i].HitName;
                    delete data[i].hit_length;
                    delete data[i].length_hit;
                    delete data[i].length_hsp;
                    delete data[i].length_query;
                    delete data[i].query_length;

                    data[i].evalue = data[i].evalue.toString();
                    terms.push((<string>data[i].description).split('|')[0]);
                }

                $ts("#blast_output").clear();
                $ts("#protein_id").clear().display(id);
                $ts.appendTable(data, "#blast_output", null, { class: ["table", "table-sm"] });

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

                new js_plot.piePlot("Annotation Hits Supports", "Term Hits", "preview_1")
                    .plot("protein hits", hits)
                    ;
            }

            apps.gcmodeller.getBlastp(id).then(async function (json) {
                json = await json;
                show(JSON.parse(json));
            });
        }
    }
}