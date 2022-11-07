namespace pages.repository {

    export class enzyme_database extends Bootstrap {

        public get appName(): string {
            return "enzyme_database";
        };

        protected init(): void {
            const vm = this;

            $('#enzyme-tree').jstree({
                'core': {
                    'data': (node, cb) => vm.buildEnzymeTree(node, cb)
                }
            });
        }

        //#region "proxy"
        private async loadRootNodes() {
            var json: string = await apps.gcmodeller.getEnzymeClass();
            var classId = JSON.parse(json);

            return <{}>classId;
        }
        //#end region

        public buildEnzymeTree(node: { id: string }, cb: (a: any[]) => void) {
            if (node.id === "#") {
                cb([{ "text": "EC Number", "id": "0", "children": true }]);
            } else if (node.id == "0") {
                // level1 EC-numbers
                this.loadRootNodes().then(function (classIds) {
                    let classNodes = [];

                    for (let name in classIds) {
                        classNodes.push(
                            {
                                "text": name,
                                "id": classIds[name].toString(),
                                "children": true
                            }
                        );
                    }

                    cb(classNodes);
                });
            } else {
                cb(["Child"]);
            }
        }

        /**
         * Create a new background web task
        */
        public run_onclick() {
            desktop.loading("Build blast database...");

            const textbox = $ts("#uniprot-file").CType<HTMLInputElement>();
            const path: string = textbox.value;
            const json = {
                uniprot: path
            };
            const title: string = "Build enzyme blast+ database";

            if (Strings.Empty(path, true)) {
                desktop.showToastMessage("No uniprot assembly file was provided!", title, "danger");
                return;
            }

            apps.gcmodeller
                .createTask(`Imports Enzyme Database`, $ts.url("@web_invoke_imports"), JSON.stringify(json))
                .then(async function (msg) {
                    const task_id: string = await msg.data;

                    desktop.showTaskAlert();
                    desktop.showToastMessage(`Pending a new task: ${task_id}`, title, "info");
                })
                ;
        }

        public button_open_rhea_onclick() {
            desktop.winforms.openfileDialog("#rhea-file", apps.rhea_reactions);
        }

        public button_open_uniprot_onclick() {
            desktop.winforms.openfileDialog("#uniprot-file", apps.uniprot_assembly);
        }
    }
}