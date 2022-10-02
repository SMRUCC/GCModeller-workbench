namespace pages {

    export class enrichment_database extends Bootstrap {

        public get appName(): string {
            return "enrichment_database";
        }

        protected init(): void {
            // throw new Error("Method not implemented.");
        }

        /**
         * method execute on native host side, not R server backend
        */
        public open_uniprot_onclick() {
            
        }

        public imports_onclick() {
            const data = {
                file: $ts.value("#formFile"),
                name: $ts.value("#title"),
                note: $ts.value("#description")
            };

            $ts.post("@web_invoke_imports", data, function (result: IMsg<string>) {
                if (result.code != 0) {

                } else {
                    // location.reload();
                }
            });
        }
    }
}