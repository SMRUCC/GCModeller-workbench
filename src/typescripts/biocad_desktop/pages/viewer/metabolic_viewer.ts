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
            const list = $ts("#compartment_list");

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
                    vm.compartments[id] = [];
                    list.appendElement($ts("<option>", { value: id }).display(id));
                }
            });
        }

        /**
         * @param id is a array when select options populated?
        */
        public compartment_list_onchange(id: string[] | string) {
            if (typeof id == "string") {
                this.showMetabolicNetwork(id);
            } else {
                this.showMetabolicNetwork(id[0]);
            }
        }

        private showMetabolicNetwork(id: string) {
            const vm = this;

            if (isNullOrEmpty(this.compartments[id])) {
                // query and then show network
                apps.gcmodeller.getMetabolicEnzymes(id).then(async function (json) {
                    json = await json;
                    vm.compartments[id] = JSON.parse(json);
                    vm.showNetworkImpl(id, vm.compartments[id]);
                });
            } else {
                this.showNetworkImpl(id, this.compartments[id]);
            }
        }

        private showNetworkImpl(compartment: string, enzymes: enzyme[]) {
            const ec_numbers: string[] = [];
            const vm = this;
            const reactions: reaction[] = [];
            const rxnList = $ts("#reaction-graph-data").clear();

            for (let enzyme of enzymes) {
                for (let rxn of enzyme.reactions) {
                    for (let number of rxn.enzyme) {
                        ec_numbers.push(number);
                    }

                    reactions.push(rxn);
                }
            }

            const count_enzymes = $from(ec_numbers)
                .Where(str => !Strings.Empty(str, true))
                .GroupBy(id => id.split(".")[0])
                .Where(group => `EC${group.Key}` in vm.category_index)
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

            console.table(count_enzymes);
            console.log(reactions);

            new js_plot.piePlot("Metabolic Composition", `Subcellular Location: ${compartment}`, "enzyme-class")
                .plot("Reaction Counts", count_enzymes)
                ;

            $from(reactions)
                .GroupBy(rxn => rxn.entry)
                .ForEach(function (data) {
                    const rxn = data.First;
                    const ref_id: string = rxn.entry.replace(":", "-");
                    const link = $ts("<a>", { id: ref_id, href: "#" }).display(rxn.definition.replace(/[<]/ig, "&lt;"));
                    const li = $ts("<li>").display(link);

                    rxnList.appendElement(li);
                });
        }
    }
}