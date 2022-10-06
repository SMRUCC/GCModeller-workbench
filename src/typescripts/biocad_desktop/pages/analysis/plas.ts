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

            $ts("#equations").clear();
            $ts("#constant-list").clear();

            for (let eq of [
                ["x1=beta1*(lamda1*(1+alpha1*(x4^n1)/(1+x4^n1))-x1)", -100],
                ["x2=x1-x2", -100000],
                ["x3=beta3*(lamda3*(1+alpha2*((x4/a)^n2)/(1+(x4/a)^n2))*(1/(1+x2^n3))-x3)", 0],
                ["x4=beta4*(x3-x4)", 10]
            ]) {
                const textbox = vm.add_equation_click();

                textbox.eq.value = eq[0].toString();
                textbox.y0.value = eq[1].toString();
            }

            for (let constant of [
                ["beta1", "30"],
                ["beta3", "30"],
                ["beta4", "1"],
                ["lamda1", "2"],
                ["lamda3", "2"],
                ["alpha1", "20"],
                ["alpha2", "20"],
                ["alpha3", "1"],
                ["a", "1"],
                ["n1", "4"],
                ["n2", "5"],
                ["n3", "1"]
            ]) {
                const textbox = vm.add_constant_click();

                textbox.name.value = constant[0].toString();
                textbox.val.value = constant[1].toString();
            }

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
            const textbox = div.getElementsByTagName("input");
            const ode_eq = textbox.item(0);
            const ode_y0 = textbox.item(1);

            odes.appendElement(div);

            (<DOMEnumerator<HTMLButtonElement>><any>$ts(".del-eq")).onClick(function (btn) {
                btn.removeAttribute("onclick");
                odes.removeChild(btn.parentElement);
                vm.equationIndexing(<any>$ts(".eq-index"));
            });

            vm.equationIndexing(<any>$ts(".eq-index"));

            return { eq: ode_eq, y0: ode_y0 };
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
            const textbox = div.getElementsByTagName("input");
            const const_name = textbox.item(0);
            const const_val = textbox.item(1);

            symbols.appendElement(div);

            (<DOMEnumerator<HTMLButtonElement>><any>$ts(".del-const")).onClick(function (btn) {
                btn.removeAttribute("onclick");
                symbols.removeChild(btn.parentElement);
                vm.equationIndexing(<any>$ts(".const-index"));
            });

            vm.equationIndexing(<any>$ts(".const-index"));

            return { name: const_name, val: const_val };
        }

        private static loadContents(div_class) {
            const list: DOMEnumerator<HTMLElement> = <any>$ts(`.${div_class}`);
            const contents: {}[] = [];

            list.ForEach(function (div) {
                const textbox = div.getElementsByTagName("input");
                const symbol = textbox.item(0);
                const val = textbox.item(1);
                const data = { target: symbol.value, value: val.value };

                contents.push(data);
            });

            return contents;
        }

        public run_click() {
            $ts("#busy-indicator").show();

            // extract odes system
            const odes = runPLAS.loadContents("equation");
            const constants = runPLAS.loadContents("const");
            const time_final = $ts.value("#time_final");
            const resolution = $ts.value("#resolution");
            // get session unique id
            const ssid: string = super.generateSsid({
                sys: odes,
                const: constants,
                t: time_final,
                resolution: resolution
            });
            const json: string = JSON.stringify({
                odes: JSON.stringify(odes),
                constants: JSON.stringify(constants),
                final_time: time_final,
                resolution: resolution,
                session_id: ssid
            });

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_run_plas"), json)
                .then(async function (result) {
                    desktop.promiseAsyncCallback<string>(result, function (success, message) {
                        if (success) {
                            console.log(message);
                        } else {
                            desktop.showToastMessage(message.info, "Run PLAS", "danger");
                        }

                        $ts("#busy-indicator").hide();
                    });
                });
        }
    }
}