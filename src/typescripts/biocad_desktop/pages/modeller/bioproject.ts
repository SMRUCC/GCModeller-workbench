namespace pages.modeller {

    export class bioproject extends Bootstrap {

        private path: string;

        public get appName(): string {
            return "bioproject";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
            this.path = decodeURIComponent($ts.location("proj"));
            this.loadSummary(this.path);

            $ts("#path").display(this.path);
        }

        private loadSummary(path: string) {
            const url: string = `@web_invoke_inspect_model?proj=${encodeURIComponent(path)}`;

            $ts.get(url, function (result) {
                if (result.code != 0) {
                    desktop.showToastMessage("Load project file error!", "Project Reader", "danger");
                } else {
                    console.log(result);
                }
            });
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
                        console.log(result);

                        if (result.code == 0) {
                            vm.create_localBlastTask(result, ssid, "ontology_annotation");
                        } else {
                            desktop.showToastMessage(result.info, "Extract Data Error", "danger");
                        }

                        desktop.closeSpinner();
                    });
                })
        }

        public subcellular_anno_onclick() {
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
                        console.log(result);

                        if (result.code == 0) {
                            vm.create_localBlastTask(result, ssid, "subcellular_location");
                        } else {
                            desktop.showToastMessage(result.info, "Extract Data Error", "danger");
                        }

                        desktop.closeSpinner();
                    });
                })
        }

        private create_localBlastTask(result: IMsg<any>, ssid: string, protocol: string) {
            const vm = this;
            const query: string = result.info.dataset;
            const project: string = vm.path;
            const map_path = {
                "ontology_annotation": x => <string>x.info.blast.ec_numbers,
                "subcellular_location": x => <string>x.info.blast.subcellular_location
            }
            const reference_fasta: string = map_path[protocol](result);
            const args = <annotations.blastParameter>{
                query: query,
                reference: reference_fasta,
                n_threads: 2,
                evalue: 1e-3,
                project: project,
                protocol: protocol
            };

            console.log("view of the annotation parameters:");
            console.log(args);

            localStorage.setItem(ssid, JSON.stringify(args));
            apps.gcmodeller.openLocalBlast(ssid);
        }
    }
}