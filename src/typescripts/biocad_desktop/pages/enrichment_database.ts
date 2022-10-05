namespace pages {

    export class enrichment_database extends Bootstrap {

        public get appName(): string {
            return "enrichment_database";
        }

        protected init(): void {
            this.scanDatabaseList();
        }

        private scanDatabaseList() {
            $ts("#busy-indicator").show();

            apps.gcmodeller
                .scanDatabase()
                .then(async function (json) {
                    const jsonString = await json;
                    const dbList: {} = JSON.parse(jsonString || "[]");
                    const dbSize = Object.keys(dbList).length;
                    const cardList = $ts("#repository");

                    for (let key in dbList) {
                        const metadata: { name: string, note: string } = dbList[key];
                        const card = enrichment_database.buildDbCard(key, metadata);

                        cardList.appendElement(card);
                        console.log(key);

                        $ts(`#${key}`).onclick = function () {
                            apps.gcmodeller.openEnrichmentPage(key, metadata.name, metadata.note);
                        }

                        $ts(`#${key}-meta`).onclick = function () {
                            enrichment_database.showMetadata(key, metadata);
                        }
                    }

                    $ts("#busy-indicator").hide();

                    // show database summary information
                    desktop.showToastMessage(`Found ${dbSize} database.`, "Enrichment Database Repository", null, "info");
                });
        }

        private static showMetadata(key: string, metadata: { name: string, note: string }) {
            let sb = "";
            let json: string = JSON.stringify({
                guid: key
            });

            sb = sb + `Database Name: ${metadata.name}(${key})<br />`;
            sb = sb + `Note: <p>${metadata.note}</p><br />`;

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_inspector"), json)
                .then(async function (result) {
                    desktop.parseMessage(result).then(function (message) {
                        desktop.parseResultFlag(result, message).then(function (flag) {
                            const title = flag ? "Load Database Success" : "Load Database Error";
                            const data: { counts: number, proteins: string } = <any>message.info;
                            const protein_ids = Strings.lineTokens(data.proteins).join("<br />");

                            if (flag) {
                                // success
                                desktop.showToastMessage("Success!", title, null, "success");

                                sb = sb + `Protein Counts: ${data.counts}<br />`;
                                sb = sb + `Protein ID: ${protein_ids}<br />`;
                            } else {
                                // error
                                desktop.showToastMessage(message.info, title, null, "danger");
                            }

                            $ts("#summary-info").display(sb);
                        });
                    });
                });
        }

        private static buildDbCard(key: string, metadata: { name: string, note: string }): HTMLElement {
            return $ts("<div>", { class: ["card", "shadow-5"], style: "width: 300px;" }).display(` 
                <div class="bg-image hover-overlay ripple" data-mdb-ripple-color="light">
                    <img src="/assets/images/background.jpg" class="img-fluid"/>
                    <a href="javascript:void(0);" id="${key}-meta">
                        <div class="mask" style="background-color: rgba(251, 251, 251, 0.15);"></div>
                    </a>
                </div>
                <div class="card-body">
                    <h5 class="card-title">${metadata.name}</h5>
                    <p class="card-text">${metadata.note}</p>
                    <a id="${key}" href="javascript:void(0);" class="btn btn-primary">Run</a>
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