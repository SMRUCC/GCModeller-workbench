namespace pages {

    export class enrichment_database extends Bootstrap {

        public get appName(): string {
            return "enrichment_database";
        }

        protected init(): void {
            $ts("#busy-indicator").hide();
        }

        /**
         * method execute on native host side, not R server backend
        */
        public open_uniprot_onclick() {
            $ts("#formFile").CType<HTMLInputElement>().value = apps.gcmodeller.getUniprotXmlDatabase();
        }

        public imports_onclick() {
            const data = {
                file: $ts.value("#formFile"),
                name: $ts.value("#title"),
                note: $ts.value("#description")
            };

            $ts("#busy-indicator").show();

            if (apps.gcmodeller.sendPost($ts.url("@web_invoke_imports"), JSON.stringify(data))) {
                // success
                console.log("success");
            } else {
                // error
                desktop.showToastMessage("Task error while calling of the uniprot database imports!");
            }

            $ts("#busy-indicator").hide();
        }
    }
}