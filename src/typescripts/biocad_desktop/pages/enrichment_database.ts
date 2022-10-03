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

            const msg = apps.gcmodeller.sendPost($ts.url("@web_invoke_imports"), JSON.stringify(data));

            if (msg.result) {
                // success
                desktop.showToastMessage(msg.data, "Imports Task Success", null, "success");
            } else {
                // error
                desktop.showToastMessage(msg.data, "Imports Task Error", null, "danger");
            }

            $ts("#busy-indicator").hide();
        }
    }
}