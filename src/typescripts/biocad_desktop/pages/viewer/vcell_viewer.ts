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
            $ts.get(`http://localhost:${this.port}/@counts`, function (result) {
                const li = $ts("#module_list");

                for (let name of Object.keys(result.info)) {
                    li.appendElement($ts("<option>", { value: name }).display(`${name} [${result.info[name]} molecules]`));
                }
            });
        }

        public module_list_onchange(value: string[]) {
            let vm = this;
            let url: string;

            vm.cur_modu = value[0];
            url = `http://localhost:${this.port}/@idset/?set=${encodeURIComponent(vm.cur_modu)}`;

            $ts.get<{ size: number, set: string[] }>(url, function (result) {
                const li = $ts("#molecules_list").clear();
                const data = <{ size: number, set: string[] }>result.info;

                if (data.size > 0) {
                    for (let id of data.set) {
                        li.appendElement($ts("<option>", { value: id }).display(id));
                    }
                }

                vm.clear_onclick();
            });
        }

        public clear_onclick() {
            this.pins = [];
            this.vectors = new Dictionary<number[][]>();
        }

        public molecules_list_onchange(value: string[]) {
            const id = value[0];
            const modu = this.cur_modu;
            const pins = this.vectors
                .Select(function (a) {
                    return {
                        name: a.key,
                        data: a.value
                    }
                })
                .ToArray();

            this.get_vector(value[0], function (size, v) {
                new js_plot.lineplot(`Expression of ${id}`, `From module ${modu}`, "container").plot(id, v, pins);
            });
        }

        private get_vector(id: string, callback: (size: number, v: number[][]) => void) {
            const vm = this;
            const url = `http://localhost:${this.port}/@vector/?m=${vm.cur_modu}&id=${id}`;

            $ts.get(url, function (result) {
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