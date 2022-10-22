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

        public run_onclick() {

        }

        public button_open_uniprot() {
            
        }
    }
}