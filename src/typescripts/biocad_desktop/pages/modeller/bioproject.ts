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
                    const summary: any = result.info;
                    const total = summary.total;
                    const enzyme_numbers = summary.number_enzymes;
                    const no_annotation = (total - enzyme_numbers) < 0 ? 0 : (total - enzyme_numbers);

                    console.log(summary);

                    // show summary pie
                    new js_plot.piePlot("Protein Annotations", "Metabolic Annotation", "summary_pie").plot(
                        "protein numbers", [
                        { name: "enzymes", value: enzyme_numbers },
                        { name: "no annotation", value: no_annotation }
                    ]);

                    const enzyme_annotations: {} = summary.enzyme_class;
                    const count1 = $from(Object.keys(enzyme_annotations))
                        .Select(function (label) {
                            return {
                                name: label,
                                value: enzyme_annotations[label]
                            }
                        })
                        .ToArray();

                    new js_plot.piePlot("Metabolic Annotation", "Enzyme Class Counts", "summary_enzyme_pie")
                        .plot("protein numbers", count1)
                        ;

                    const subcellular_locations: {} = summary.subcellular_locations;
                    const count2 = $from(Object.keys(subcellular_locations))
                        .Select(function (label) {
                            return {
                                name: label,
                                value: subcellular_locations[label]
                            }
                        })
                        .ToArray();

                    new js_plot.piePlot("Subcellular Locations Annotation", "Metabolic Locations", "summary_location_pie")
                        .plot("protein numbers", count2)
                        ;
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