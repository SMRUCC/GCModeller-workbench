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

        public buildEnzymeTree(node: { id: string }, cb: (a: any[]) => void) {
            if (node.id === "#") {
                cb([{ "text": "EC Number", "id": "1", "children": true }]);
            } else if (node.id == "1") {
                // level1 EC-numbers
            } else {
                cb(["Child"]);
            }
        }
    }
}