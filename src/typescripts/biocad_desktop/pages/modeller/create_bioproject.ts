namespace pages.modeller {

    export class create_bioproject extends Bootstrap {

        public get appName(): string {
            return "create_bioproject";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
        }

        public button_open_gbff_onclick() {
            const textbox = $ts("#gbff-file").CType<HTMLInputElement>();
            const vm = this;

            desktop.loading("Load genbank assembly...");

            apps.gcmodeller
                .getFileOpen(apps.ncbi_genbank_assembly)
                .then(async function (path) {
                    textbox.value = await path;

                    if (!Strings.Empty(textbox.value, true)) {
                        vm.viewModelSummary(textbox.value);
                    }
                })
                ;
        }

        private viewModelSummary(path: string) {
            $ts.get(`@web_invoke_inspector?gbff=${encodeURIComponent(path)}`, function (response) {
                if (response.code == 0) {
                    // show summary information

                } else {
                    desktop.showToastMessage(<any>response.info, "Load GenBank Assembly Error", "danger");
                }
            });
        }
    }
}