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

            apps.gcmodeller
                .getFileOpen(apps.ncbi_genbank_assembly)
                .then(async function (path) {
                    textbox.value = await path;
                })
                ;
        }
    }
}