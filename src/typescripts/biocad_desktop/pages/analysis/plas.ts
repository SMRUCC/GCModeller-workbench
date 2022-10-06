/// <reference path="../analysis_session.ts" />

namespace pages {

    export class runPLAS extends analysis_session {

        public get appName(): string {
            return "plas";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
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

            odes.appendElement(div);

            $ts(".del-eq").onclick = null;
            $ts(".del-eq").onclick = function (btn) {
                console.log(btn);
            }
        }
    }
}