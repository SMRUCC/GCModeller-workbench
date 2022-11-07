namespace pages.viewers {

    export class view_protein_blast extends Bootstrap {

        private protein_ids: string[];

        public get appName(): string {
            return "blastp_viewer";
        };

        protected init(): void {
            const vm = this;

            apps.gcmodeller
                .getProteinIDs()
                .then(async function (list) {
                    list = await list;
                    vm.protein_ids = list;
                    vm.viewBlastp(vm.protein_ids[0]);

                    $ts("#number_proteins").display(vm.protein_ids.length.toString());
                });
        }

        private viewBlastp(id: string) {
            const show = function (data: any[]) {
                for (let i = 0; i < data.length; i++) {
                    delete data[i].QueryName;
                    delete data[i].HitName;
                    delete data[i].hit_length;
                    delete data[i].length_hit;
                    delete data[i].length_hsp;
                    delete data[i].length_query;
                    delete data[i].query_length;

                    data[i].evalue = data[i].evalue.toString();
                }

                $ts("#blast_output").clear();
                $ts.appendTable(data, "#blast_output", null, { class: ["table", "table-sm"] });
            }

            apps.gcmodeller.getBlastp(id).then(async function (json) {
                json = await json;
                show(JSON.parse(json));
            });
        }
    }
}