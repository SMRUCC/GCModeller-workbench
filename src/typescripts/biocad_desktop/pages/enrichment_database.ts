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
                            $ts("#busy-indicator").show();
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

            sb = sb + `<span class="badge badge-primary">Database Name</span>: ${metadata.name}(${key})<br />`;
            sb = sb + `<span class="badge badge-primary">Note</span>: <p class="note note-light">${metadata.note}</p><br />`;

            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_inspector"), json)
                .then(async function (result) {
                    desktop.parseMessage(result).then(function (message) {
                        desktop.parseResultFlag(result, message).then(function (flag) {
                            const title = flag ? "Load Database Success" : "Load Database Error";
                            const data: {
                                counts: number,
                                summary: {
                                    GO: { clusters: number, unique_size: number }
                                }
                            } = <any>message.info;

                            let hookLinks: Delegate.Action = null;

                            console.log(data);

                            if (flag) {
                                const backgrounds = $from(Object.keys(data.summary))
                                    .Select(function (name) {
                                        const info: { clusters: number, unique_size: number } = data.summary[name];
                                        const pack = { name: name, info: info };

                                        return pack;
                                    })
                                    .Where(a => a.info.unique_size > 0)
                                    .Where(a => a.info.unique_size / a.info.clusters > 1)
                                    ;
                                const protein_ids: string = backgrounds
                                    .Select(a => enrichment_database.summaryLine(a.name, a.info))
                                    .JoinBy("")
                                    ;

                                // success
                                desktop.showToastMessage("Success!", title, null, "success");

                                hookLinks = function () {
                                    for (let model of backgrounds.ToArray()) {
                                        const name: string = model.name;
                                        const id: string = `#model-${name}`;

                                        console.log(id);

                                        $ts(id).onclick = function () {
                                            $ts("#busy-indicator").show();
                                            console.log(`view background model: ${name}...`);
                                            enrichment_database.viewModel(key, name, model.info);
                                        }
                                    }
                                }

                                sb = sb + `<span class="badge badge-primary">Protein Counts</span>: ${data.counts}<br />`;
                                sb = sb + `<span class="badge badge-primary">Models</span>: ${backgrounds.Count}<br />`;
                                sb = sb + `<span class="badge badge-primary">Backgrounds</span>: <br /><br />
                                    <ul class="list-group list-group-light">
                                        ${protein_ids}
                                    </ul>
                                `;
                            } else {
                                // error
                                desktop.showToastMessage(message.info, title, null, "danger");
                            }

                            $ts("#summary-info").display(sb);

                            if (!isNullOrUndefined(hookLinks)) {
                                hookLinks();
                            }
                        });
                    });
                });
        }

        /**
         * @param key a unique database hash name for query in the repository
        */
        private static viewModel(key: string, name: string, info: { clusters: number, unique_size: number }) {

        }

        private static summaryLine(name: string, info: { clusters: number, unique_size: number }): string {
            return `<li class="list-group-item d-flex justify-content-between align-items-center">
                        <div class="d-flex align-items-center">
                            <span class="badge rounded-pill badge-success">                
                                <i class="fab fa-laravel"></i>&nbsp;${name}              
                            </span>
                            ${info.clusters} / ${info.unique_size}
                        </div>
                        <a id="model-${name}" class="btn btn-link btn-rounded btn-sm" href="#" role="button">View</a>
                    </li>`;
        }

        private static buildDbCard(key: string, metadata: { name: string, note: string }): HTMLElement {
            return $ts("<div>", { class: ["card", "shadow-5"], style: "width: 300px;" }).display(` 
                <div class="bg-image hover-overlay ripple hover-zoom" data-mdb-ripple-color="light">
                    <img src="/assets/images/background.jpg" class="img-fluid hover-shadow"/>
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