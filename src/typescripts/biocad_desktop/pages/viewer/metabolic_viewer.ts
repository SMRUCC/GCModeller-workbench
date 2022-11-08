/// <reference path="../../../build/viewer.d.ts" />

namespace pages.viewers {

    export interface enzyme {
        protein_id: string;
        reactions: reaction[];
    }

    export interface reaction {
        definition: string;
        entry: string;
        enzyme: string[];
        euqation: equation;
    }

    export interface equation {
        Id: string;
        reversible: boolean;
        Reactants: CompoundFactor[];
        Products: CompoundFactor[];
    }

    export interface CompoundFactor {
        Compartment: string;
        ID: string;
        StoiChiometry: number;
    }

    export class metabolic_viewer extends Bootstrap {

        public get appName(): string {
            return "metabolic_viewer";
        };

        private readonly compartments: {} = {};
        private readonly enzyme_class: {} = {};
        private readonly category_index: {} = {};

        protected init(): void {
            const vm = this;
            const list = $ts("#compartment-list");

            apps.gcmodeller.getEnzymeClass().then(async function (json) {
                json = await json;

                let classList = JSON.parse(json);

                for (let name in classList) {
                    vm.enzyme_class[name] = classList[name];
                    vm.category_index[`EC${classList[name]}`] = name;
                }

                console.log(vm.enzyme_class);
            });
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
            });
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

        private showNetworkImpl(enzymes: enzyme[]) {
            const ec_numbers: string[] = [];
            const vm = this;

            for (let enzyme of enzymes) {
                for (let rxn of enzyme.reactions) {
                    for (let number of rxn.enzyme) {
                        ec_numbers.push(number);
                    }
                }
            }

            const count_enzymes = $from(ec_numbers)
                .GroupBy(id => id.split(".")[0])
                .Select(function (group) {
                    const num: string = group.Key;
                    const tag_name: string = vm.category_index[`EC${num}`];

                    return {
                        name: tag_name,
                        value: group.Count
                    }
                })
                .ToArray()
                ;
        }
    }
}