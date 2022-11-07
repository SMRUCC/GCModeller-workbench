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
            const show = function (data) {
                console.log(data);
            }

            apps.gcmodeller.getBlastp(id).then(async function (json) {
                json = await json;
                show(JSON.parse(json));
            });
        }
    }
}