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
    }

    export class localblast extends Bootstrap {

        public get appName(): string {
            return "localblast";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
            // init analysis page
            const params: string = $ts.location("params");
            const session: string = $ts.location("session");

            if (!Strings.Empty(params, true)) {
                const args: blastParameter = JSON.parse(localStorage.getItem(params));

                $ts.value("#query-file", args.query);
                $ts.value("#reference-file", args.reference);

            } else if (!Strings.Empty(session, true)) {
                const args: blastParameter = JSON.parse(localStorage.getItem(params));

                $ts.value("#query-file", args.query);
                $ts.value("#reference-file", args.reference);
                
                throw new Error("Method not implemented.");
            }
        }

        public button_open_query_onclick() {
            desktop.winforms.openfileDialog("#query-file", apps.fasta_sequence);
        }

        public button_open_reference_onclick() {
            desktop.winforms.openfileDialog("#reference-file", apps.fasta_sequence);
        }
    }
}