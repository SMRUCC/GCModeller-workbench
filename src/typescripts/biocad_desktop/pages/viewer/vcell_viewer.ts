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

        public module_list_onchange(value: string) {
            $ts.get(`@idset/?set=${encodeURIComponent(value[0])}`, function (result) {
                console.log(result);
            });
        }
    }
}