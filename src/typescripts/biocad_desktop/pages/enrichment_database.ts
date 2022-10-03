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
            const textbox = $ts("#formFile").CType<HTMLInputElement>();

            apps.gcmodeller
                .getUniprotXmlDatabase()
                .then(path => textbox.value = path)
                ;
        }

        public imports_onclick() {
            $ts("#busy-indicator").show();

            const data = {
                file: $ts.value("#formFile"),
                name: $ts.value("#title"),
                note: $ts.value("#description")
            };
            const json = JSON.stringify(data);

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_imports"), json)
                .then(function (msg) {
                    if (msg.result) {
                        // success
                        desktop.showToastMessage(msg.data, "Imports Task Success", null, "success");
                    } else {
                        // error
                        desktop.showToastMessage(msg.data, "Imports Task Error", null, "danger");
                    }

                    $ts("#busy-indicator").hide();
                })
                ;
        }
    }
}