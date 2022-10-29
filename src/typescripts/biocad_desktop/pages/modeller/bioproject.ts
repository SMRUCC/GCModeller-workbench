namespace pages.modeller {

    export class bioproject extends Bootstrap {

        private path: string;

        public get appName(): string {
            return "bioproject";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
            this.path = decodeURIComponent($ts.location("proj"));

            $ts("#path").display(this.path);
        }

        public enzyme_anno_onclick() {
            const vm = this;

            desktop.loading("Extract protein set, wait for a while...");
            apps.gcmodeller
                .getNextUniqueId()
                .then(async function (ssid) {
                    ssid = await ssid;

                    $ts.post("@web_invoke_extract_proteins", {
                        proj: vm.path,
                        ssid: ssid
                    }, function (result: IMsg<any>) {
                        if (result.code == 0) {
                            const query: string = result.info.dataset;
                            const project: string = vm.path;
                            const ec_numbers: string = result.info.blast.ec_numbers;
                            const args = <annotations.blastParameter>{
                                query: query,
                                reference: ec_numbers,
                                n_threads: 2,
                                evalue: 1e-3,
                                project: project
                            };

                            console.log("view of the annotation parameters:");
                            console.log(args);

                            localStorage.setItem(ssid, JSON.stringify(args));
                            apps.gcmodeller.openEnzymeBlast(ssid);
                        }

                        desktop.closeSpinner();
                    });
                })
        }
    }
}