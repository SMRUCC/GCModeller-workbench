/// <reference path="../analysis_session.ts" />

namespace pages {

    export class runPLAS extends analysis_session {

        public get appName(): string {
            return "plas";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");

            // add one equation by default
            this.add_equation_click();
        }

        public loadDemo_click() {
            const vm = this;

            $ts.value("#time_final", "5");
            $ts.value("#resolution", "10000");

            

            vm.equationIndexing(<any>$ts(".eq-index"));
            vm.equationIndexing(<any>$ts(".const-index"));

            desktop.showToastMessage("Load 'Atkinson.txt' demo example success!", "PLAS Script", "info");
        }

        public add_equation_click() {
            const odes = $ts("#equations");
            const div = $ts("<div>", {
                class: ["input-group", "mb-3", "equation"]
            }).display(`
                <span class="input-group-text eq-index">1. </span>
                <input type="text" class="form-control" placeholder="y=f(x) at here"
                    aria-label="ode">
                <span class="input-group-text">, y<sub>0</sub>=</span>
                <input type="text" class="form-control"
                    placeholder="Initial value of variable y" aria-label="y0">
                <button class="btn btn-danger del-eq" type="button"> Remove
                </button>
            `);
            const vm = this;

            odes.appendElement(div);

            (<DOMEnumerator<HTMLButtonElement>><any>$ts(".del-eq")).onClick(function (btn) {
                btn.removeAttribute("onclick");
                odes.removeChild(btn.parentElement);
                vm.equationIndexing(<any>$ts(".eq-index"));
            });

            vm.equationIndexing(<any>$ts(".eq-index"));
        }

        private equationIndexing(list: DOMEnumerator<HTMLSpanElement>) {
            list.ForEach(function (span, i) {
                span.innerText = `${i + 1}. `;
            });
        }

        public add_constant_click() {
            const symbols = $ts("#constant-list");
            const div = $ts("<div>", {
                class: ["input-group", "mb-3", "const"]
            }).display(`
                <span class="input-group-text const-index">1. </span>
                <input type="text" class="form-control" placeholder="put constant symbol name at here"
                    aria-label="constant">
                <span class="input-group-text">, constant value=</span>
                <input type="text" class="form-control"
                    placeholder="Constant value of current symbol" aria-label="const_val">
                <button class="btn btn-danger del-const" type="button"> Remove
                </button>
            `);
            const vm = this;

            symbols.appendElement(div);

            (<DOMEnumerator<HTMLButtonElement>><any>$ts(".del-const")).onClick(function (btn) {
                btn.removeAttribute("onclick");
                symbols.removeChild(btn.parentElement);
                vm.equationIndexing(<any>$ts(".const-index"));
            });

            vm.equationIndexing(<any>$ts(".const-index"));
        }
    }
}