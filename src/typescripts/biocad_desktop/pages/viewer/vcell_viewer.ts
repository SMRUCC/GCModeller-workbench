/// <reference path="../../../build/viewer.d.ts" />

namespace pages.viewers {

    export class vcell_viewer extends Bootstrap {

        public get appName(): string {
            return "vcell_viewer";
        }

        private port: string = $ts.location("service");
        private pins: string[] = [];

        private vectors: Dictionary<number[][]> = new Dictionary<number[][]>();
        private cur_modu: string;

        protected init(): void {
            const url = $ts.url("@counts");

            $ts.get(`http://localhost:${this.port}${url}`, function (result) {
                const li = $ts("#module_list");

                for (let name of Object.keys(result.info)) {
                    if (name != "Reactions") {
                        li.appendElement($ts("<option>", { value: name }).display(`${name} [${result.info[name]} molecules]`));
                    }
                }
            });
        }

        public module_list_onchange(value: string[]) {
            let vm = this;
            let url: string = $ts.url(`@idset/?set=${encodeURIComponent(value[0])}`);

            vm.cur_modu = value[0];
            url = `http://localhost:${this.port}${url}`;

            $ts.get<{ size: number, set: string[] }>(url, function (result) {
                const li = $ts("#molecules_list").clear();
                const data = <{ size: number, set: string[] }>result.info;

                if (data.size > 0) {
                    for (let id of data.set) {
                        li.appendElement($ts("<option>", { value: id }).display(id));
                    }

                    vm.molecules_list_onchange([data.set[0]]);
                }

                vm.clear_onclick();
            });
        }

        public clear_onclick() {
            this.pins = [];
            this.vectors = new Dictionary<number[][]>();
        }

        private reaction_bind: string;

        public molecules_list_onchange(value: string[]) {
            const id = value[0];
            const vm = this;
            const modu = this.cur_modu;
            const pins: { name: string, data: number[][] }[] = this.vectors
                .Select(function (a) {
                    return {
                        name: a.key,
                        data: a.value
                    }
                })
                .ToArray();

            this.reaction_bind = id;
            this.get_vector(value[0], function (size, v) {
                new js_plot.lineplot(`Expression of ${id}`, `From module ${modu}`, "container").plot(id, v, pins);
            });

            // list all related reaction id
            const url = $ts.url(`@reactions/?id=${id}`);

            $ts.get(`http://localhost:${this.port}${url}`, function (result) {
                let idset: string[] | string = <any>result.info;
                let li = $ts("#reaction_list");

                if (!Array.isArray(idset)) {
                    idset = [<string>idset];
                }

                console.log("get related reaction id set:");
                console.log(idset);

                for (let id of idset) {
                    li.appendElement($ts("<option>", { value: id }).display(id));
                }

                vm.reaction_list_onchange(idset[0]);
            });
        }

        public reaction_list_onchange(value: string[] | string) {
            let id: string = (<string[]>value)[0];
            let pins = [];
            let vm = this;

            this.get_vector(value[0], function (size, v) {
                new js_plot.lineplot(`Expression of ${id}`, `From module reactions`, "reaction-container").plot(id, v, pins);
            }, "Reactions");

            const url = $ts.url(`@graph/?id=${this.reaction_bind}&rxn=${id}`);

            $ts.get(`http://localhost:${this.port}${url}`, function (result) {
                vm.graph = <any>result.info;

                if (typeof vm.graph.reactants == "string") {
                    vm.graph.reactants = [<any>vm.graph.reactants];
                }
                if (typeof vm.graph.products == "string") {
                    vm.graph.products = [<any>vm.graph.products];
                }

                console.log(vm.graph);
            });
        }

        private graph: { "reactants": string[], "products": string[] };

        public view_mass_onclick() {
            const g = this.graph;
            const overlaps: { name: string, data: number[][] }[] = [];
            const idset = [...g.reactants].concat(g.products)

            for (let id of idset) {
                this.get_vector(id, function (size, v) {
                    overlaps.push({ name: id, data: v });

                    if (overlaps.length == idset.length) {
                        // plot overlaps
                        new js_plot.lineplot(`Metabolite overlaps`, `Reaction Flux Viewer`, "container").plot(null, null, overlaps);
                    }
                });
            }
        }

        private get_vector(id: string, callback: (size: number, v: number[][]) => void, modu: string = null) {
            const vm = this;
            const url = $ts.url(`@vector/?m=${modu || vm.cur_modu}&id=${id}`);

            $ts.get(`http://localhost:${this.port}${url}`, function (result) {
                const data = <{ size: number, vec: number[] }>result.info;
                const v = data.vec;
                const xy = Array(data.size).fill().map((element, index) => [index, v[index]]);

                callback(data.size, xy);
            });
        }

        public pin_onclick() {
            const id: string = $ts.select.getOption("#molecules_list");
            const vm = this;

            this.pins.push(id);
            this.get_vector(id, function (_, v) {
                vm.vectors.Add(id, v);
            });
        }
    }
}