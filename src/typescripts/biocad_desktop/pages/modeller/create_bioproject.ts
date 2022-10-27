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

            // desktop.loading("Load genbank assembly...");

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

        public create_project_onclick() {
            const textbox = $ts("#gbff-file").CType<HTMLInputElement>();
            const vm = this;

            if (Strings.Empty(textbox.value, true)) {
                desktop.showToastMessage("No data file is selected!", "Create Project", "danger");
                return;
            }

            apps.gcmodeller
                .getFileSave(apps.gcmodeller_project)
                .then(async function (savefile) {
                    savefile = await savefile;

                    if (Strings.Empty(savefile, true)) {
                        // cancel, do nothing
                    } else {
                        desktop.loading("Create project from genbank assembly...");

                        $ts.post("@web_invoke_imports", {
                            gbff: textbox.value,
                            savefile: savefile
                        }, function (result) {
                            if (result.code == 0) {

                            } else {
                                desktop.showToastMessage(<any>result.info, "Create Project", "danger");
                            }
                        });
                    }
                });
        }
    }
}