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

        }
    }
}