namespace pages.modeller {

    export class bioproject extends Bootstrap {

        private path: string;

        public get appName(): string {
            return "bioproject";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
            this.path = decodeURIComponent($ts.location("proj"));

            $ts("#path").display(this.path);
        }

        public enzyme_anno_onclick() {
            desktop.loading("Extract protein set, wait for a while...");

            $ts.post("@web_invoke_extract_proteins", {
                proj: this.path
            }, function (result) {

                

            });
        }
    }
}