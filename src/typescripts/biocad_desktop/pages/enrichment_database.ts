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
                .then(async function (path) {
                    textbox.value = await path;
                })
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
                .then(async function (msg) {
                    desktop.parseMessage(msg).then(function (message) {
                        desktop.parseResultFlag(msg, message).then(function (flag) {
                            const title = flag ? "Imports Task Success" : "Imports Task Error";

                            if (flag) {
                                // success
                                desktop.showToastMessage(message.info, title, null, "success");
                            } else {
                                // error
                                desktop.showToastMessage(message.info, title, null, "danger");
                            }

                            $ts("#busy-indicator").hide();
                        });
                    });
                });
        }
    }
}