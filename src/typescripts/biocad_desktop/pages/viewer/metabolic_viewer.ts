/// <reference path="../../../build/viewer.d.ts" />

namespace pages.viewers {

    export class metabolic_viewer extends Bootstrap {

        public get appName(): string {
            return "metabolic_viewer";
        };

        private readonly compartments: {} = {};

        protected init(): void {
            const vm = this;
            const list = $ts("#compartment-list");

            apps.gcmodeller.getMetabolicCompartments().then(async function (list_ids) {
                const compartment_ids: string[] = await list_ids;

                for (let id of compartment_ids) {
                    const ref: string = id.replace(/\s+/ig, "-");

                    vm.compartments[id] = [];
                    list.appendElement($ts("<li>").display(`<a href="#" onclick="javascript:void(0);" id="${ref}">${id}</a>`));
                    $ts(`#${ref}`).onclick = function () {
                        vm.showMetabolicNetwork(id);
                    }
                }
            })
        }

        private showMetabolicNetwork(id: string) {
            const vm = this;

            if (isNullOrEmpty(this.compartments[id])) {
                // query and then show network
                apps.gcmodeller.getMetabolicEnzymes(id).then(async function (json) {
                    json = await json;
                    vm.compartments[id] = JSON.parse(json);
                    vm.showNetworkImpl(vm.compartments[id]);
                });
            } else {
                this.showNetworkImpl(this.compartments[id]);
            }
        }

        private showNetworkImpl(enzymes: any[]) {
            console.log(enzymes);
        }
    }
}