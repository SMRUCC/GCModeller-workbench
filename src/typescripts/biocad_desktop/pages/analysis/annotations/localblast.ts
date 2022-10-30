namespace pages.annotations {

    export interface blastParameter {
        query: string;
        reference: string;
        evalue: number;
        n_threads: number;
        /**
         * the project target file that can be used for 
         * save annotation result data
        */
        project: string;
        protocol: "sbh" | "ontology_annotation";
    }

    export class localblast extends Bootstrap {

        private project: string = null;

        public get appName(): string {
            return "localblast";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
            // init analysis page
            const params: string = $ts.location("params");
            const session: string = $ts.location("session");
            const localblast = this;

            if (!Strings.Empty(params, true)) {
                localblast.loadParameters(params);
            } else if (!Strings.Empty(session, true)) {
                localblast.loadParameters(session);

                // task session will disable all form-controls
                $ts("#protocols").interactive(false);
                $ts("#button_open_query").interactive(false);
                $ts("#query-file").interactive(false);
                $ts("#button_open_reference").interactive(false);
                $ts("#reference-file").interactive(false);
                $ts("#run").interactive(false);
            }
        }

        private loadParameters(session_id: string) {
            const args: blastParameter = JSON.parse(localStorage.getItem(session_id));

            $ts.value("#query-file", args.query);
            $ts.value("#reference-file", args.reference);
            $ts.value("#protocols", args.protocol);

            this.project = args.project;
        }

        public button_open_query_onclick() {
            desktop.winforms.openfileDialog("#query-file", apps.fasta_sequence);
        }

        public button_open_reference_onclick() {
            desktop.winforms.openfileDialog("#reference-file", apps.fasta_sequence);
        }

        public run_onclick() {
            const args = <blastParameter>{
                query: $ts.value("#query-file"),
                reference: $ts.value("#reference-file"),
                evalue: 1e-3,
                n_threads: 2,
                /**
                 * the project target file that can be used for 
                 * save annotation result data
                */
                project: this.project,
                protocol: $ts.select.getOption("protocols")
            };
            const title: string = "Localblast Search";

            apps.gcmodeller
                .createTask(`Run blast search`, $ts.url("@web_invoke_localblast"), JSON.stringify(args))
                .then(async function (msg) {
                    const task_id: string = await msg.data;

                    desktop.showTaskAlert();
                    desktop.showToastMessage(`Pending a new task: ${task_id}`, title, "info");
                })
                ;
        }
    }
}