/// <reference path="../../../build/viewer.d.ts" />

namespace pages.viewers {

    export class vcell_viewer extends Bootstrap {

        public get appName(): string {
            return "vcell_viewer";
        }

        protected init(): void {
            $ts.get("@counts", function (result) {
                const li = $ts("#module_list");

                for (let name of Object.keys(result.info)) {
                    li.appendElement($ts("<option>", { value: name }).display(`${name} [${result.info[name]} molecules]`));
                }
            });
        }

        public module_list_onchange(value: string[]) {
            $ts.get<{ size: number, set: string[] }>(`@idset/?set=${encodeURIComponent(value[0])}`, function (result) {
                const li = $ts("#molecules_list").clear();
                const data = <{ size: number, set: string[] }>result.info;

                if (data.size > 0) {
                    for (let id of data.set) {
                        li.appendElement($ts("<option>", { value: id }).display(id));
                    }
                }
            });
        }

        public molecules_list_onchange(value: string[]) {
            const id = value[0];
            const modu = $ts.select.getOption("#module_list")

            console.log(value);
            console.log(modu);

            $ts.get(`@vector/?m=${modu}&id=${id}`, function (result) {
                const data = <{ size: number, vec: number[] }>result.info;
                const v = data.vec;
                const xy = Array(data.size).fill().map((element, index) => [index, v[index]]);
                const plot = new js_plot.lineplot(`Expression of ${id}`, `From module ${modu}`, "container");

                console.log(xy);
                plot.plot(id, xy);
            });
        }
    }
}