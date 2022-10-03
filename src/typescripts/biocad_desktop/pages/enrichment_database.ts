namespace pages {

    export class enrichment_database extends Bootstrap {

        public get appName(): string {
            return "enrichment_database";
        }

        protected init(): void {
            $ts("#busy-indicator").show();

            this.scanDatabaseList();
        }

        private scanDatabaseList() {
            apps.gcmodeller
                .scanDatabase()
                .then(async function (json) {
                    const jsonString = await json;
                    const dbList: {} = JSON.parse(jsonString);
                    const dbSize = Object.keys(dbList).length;
                    const cardList = $ts("#ex-with-icons-tabs-1");

                    for (let key in dbList) {
                        const metadata: { name: string, note: string } = dbList[key];
                        const card = enrichment_database.buildDbCard(key, metadata);

                        cardList.appendElement(card);
                        console.log(key);

                        $ts(`#${key}`).onclick = function () {
                            console.log("show metadata:");
                            console.log(metadata);
                            console.log(key);
                        }
                    }

                    $ts("#busy-indicator").hide();

                    // show database summary information
                    desktop.showToastMessage(`Found ${dbSize} database.`, "Enrichment Database Repository", null, "info");
                });
        }

        private static buildDbCard(key: string, metadata: { name: string, note: string }): HTMLElement {
            return $ts("<div>", { class: ["card", "shadow-5"], style: "width: 300px;" }).display(` 
                <div class="bg-image hover-overlay ripple" data-mdb-ripple-color="light">
                    <img src="/assets/images/background.jpg" class="img-fluid"/>
                    <a href="#!">
                        <div class="mask" style="background-color: rgba(251, 251, 251, 0.15);"></div>
                    </a>
                </div>
                <div class="card-body">
                    <h5 class="card-title">${metadata.name}</h5>
                    <p class="card-text">${metadata.note}</p>
                    <a id="${key}" href="javascript:void(0);" class="btn btn-primary">View</a>
                </div>
            `);
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