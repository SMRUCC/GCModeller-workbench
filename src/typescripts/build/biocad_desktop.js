var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
/// <reference path="../build/linq.d.ts" />
var apps;
(function (apps) {
    /**
     * async proxy
    */
    apps.gcmodeller = getWebview2HostObject();
    function getWebview2HostObject() {
        try {
            return window.chrome.webview.hostObjects.gcmodeller;
        }
        catch (Error) {
            return {
                getUniprotXmlDatabase: warningMsg,
                scanDatabase: warningMsg,
                openEnrichmentPage: warningMsg,
                sendPost: warningMsg
            };
        }
    }
    function warningMsg() {
        return __awaiter(this, void 0, void 0, function* () {
            desktop.showToastMessage("Please run from webview2 application!", "Web app error", null, "warning");
        });
    }
    function run() {
        Router.AddAppHandler(new pages.enrichment_database());
        Router.AddAppHandler(new pages.enrichment_analysis());
        Router.RunApp();
    }
    apps.run = run;
})(apps || (apps = {}));
$ts.mode = Modes.debug;
$ts(apps.run);
var desktop;
(function (desktop) {
    var RSharp;
    (function (RSharp) {
        function RSharpErrorMessage(obj) {
            let sb = "R# Error:";
            let i = 1;
            let method;
            if (typeof obj.Message == "string") {
                sb = sb + "&nbsp;" + obj.Message.replace(/[<]/ig, "&lt;");
            }
            else {
                sb = sb + "<br/><br/>";
                for (let line of obj.Message) {
                    sb = sb + `&nbsp;&nbsp;${i++}.${line.replace(/[<]/ig, "&lt;")}<br/>`;
                }
            }
            sb = sb + "<br/>";
            sb = sb + `&nbsp;&nbsp;&nbsp;${obj.Source.replace(/[<]/ig, "&lt;")}<br/>`;
            sb = sb + `&nbsp;&nbsp;&nbsp;${"~".repeat(obj.Source.length)}<br/>`;
            sb = sb + "<br/>";
            for (let frame of obj.StackTrace) {
                method = `${frame.Method.Namespace}.${frame.Method.Module}.${frame.Method.Method}`;
                method = `${method} at ${frame.File} line ${frame.Line}`;
                sb = sb + `${method.replace(/[<]/ig, "&lt;")}<br />`;
            }
            return sb;
        }
        RSharp.RSharpErrorMessage = RSharpErrorMessage;
        function isRSharpError(obj) {
            const type = TypeScript.Reflection.$typeof(obj);
            const checks = ["Message", "Source", "TypeFullName", "StackTrace"];
            return $ts(checks).All(name => type.property.indexOf(name) > -1);
        }
        RSharp.isRSharpError = isRSharpError;
    })(RSharp = desktop.RSharp || (desktop.RSharp = {}));
})(desktop || (desktop = {}));
var desktop;
(function (desktop) {
    function parseResultFlag(msg, message) {
        return __awaiter(this, void 0, void 0, function* () {
            const flag = yield msg.result;
            const result = flag && (message.code == 0);
            return result;
        });
    }
    desktop.parseResultFlag = parseResultFlag;
    function parseMessage(msg) {
        return __awaiter(this, void 0, void 0, function* () {
            let dataString = yield msg.data;
            let json;
            if ($ts.csv.isTsvFile(dataString)) {
                json = {
                    code: 0,
                    info: dataString
                };
            }
            else if (dataString.startsWith("data:")) {
                // is a dataURI string
                json = {
                    code: 0,
                    info: dataString
                };
            }
            else {
                try {
                    json = JSON.parse(dataString);
                }
                catch (_a) {
                    json = {
                        code: 500,
                        info: dataString
                    };
                }
            }
            return json;
        });
    }
    desktop.parseMessage = parseMessage;
    function processHtmlMsg(text) {
        if (typeof text == "string") {
            text = text.replace(/[<]/ig, "&lt;");
            text = Strings.lineTokens(text).join("<br />");
        }
        else if (desktop.RSharp.isRSharpError(text)) {
            text = desktop.RSharp.RSharpErrorMessage(text);
        }
        else {
            text = "Unhandle error!";
        }
        return text;
    }
    desktop.processHtmlMsg = processHtmlMsg;
})(desktop || (desktop = {}));
var desktop;
(function (desktop) {
    function now() {
        return (new Date()).toLocaleTimeString();
    }
    function showToastMessage(msg, title = "Task Error", subtitle = now(), level = "info", autohide = true) {
        $ts("#busy-indicator").hide();
        $ts("#toast-message").appendElement(toastHtml(msg, title, subtitle, level, autohide));
    }
    desktop.showToastMessage = showToastMessage;
    const toastIconsMD = {
        "success": "fas fa-check fa-lg me-2",
        "danger": "fas fa-exclamation-circle fa-lg me-2",
        "warning": "fas fa-exclamation-triangle fa-lg me-2",
        "info": "fas fa-info-circle fa-lg me-2"
    };
    function toastHtml(msg, title = "Task Error", subtitle = "", level = "danger", autohide = true) {
        const box = $ts("<div>", {
            class: ["toast", "show", "fade", `toast-${level}`],
            role: "alert",
            "aria-live": "assertive",
            "aria-atomic": "true",
            "data-mdb-color": level,
            "data-mdb-autohide": autohide.toString(),
            style: "width: 500px;"
        }).display(`        
            <div class="toast-header toast-${level}">
                <i class="${toastIconsMD[level]}"></i>
                <strong class="me-auto">${title}</strong>
                <small>${(!subtitle) || (subtitle.toLowerCase() == "null") ? "" : subtitle}</small>
                <button type="button" class="btn-close" data-mdb-dismiss="toast" aria-label="Close">
                </button>
            </div>
            <div class="toast-body">${desktop.processHtmlMsg(msg)}</div>
        `);
        return box;
    }
})(desktop || (desktop = {}));
var pages;
(function (pages) {
    class enrichment_analysis extends Bootstrap {
        get appName() {
            return "enrichment_analysis";
        }
        ;
        init() {
            if ($ts.location.hasQueryArguments) {
                this.database = $ts.location("id");
            }
            console.log($ts.location);
            $ts("#busy-indicator").hide();
        }
        background_onchange(value) {
            const note_id = enrichment_analysis.note_mapping[value];
            for (let name in enrichment_analysis.note_mapping) {
                $ts(`#${enrichment_analysis.note_mapping[name]}`).hide();
            }
            $ts(`#${note_id}`).show();
        }
        run_onclick() {
            if (Strings.Empty(this.database)) {
                desktop.showToastMessage("Please select a database at first!", "Enrichment Analysis", null, "danger");
            }
            else {
                $ts("#busy-indicator").show();
                const type = $ts.select.getOption("#background");
                const symbols = $ts.value("#input_idlist");
                if (Strings.Empty(type)) {
                    desktop.showToastMessage("Please select a background for enrichment analysis at first!", "Enrichment Analysis", null, "danger");
                }
                else if (Strings.Empty(symbols)) {
                    desktop.showToastMessage("No gene/protein id list to run enrichment analysis!", "Enrichment Analysis", null, "danger");
                }
                else {
                    this.runInternal(type, symbols);
                }
            }
        }
        runInternal(type, symbols) {
            const ssid = md5(`enrichment-${(new Date()).toLocaleTimeString("en-US")}-${type}-${symbols}`);
            const vm = this;
            const json = JSON.stringify({
                id: this.database,
                background: type,
                symbols: Strings.lineTokens(symbols),
                ssid: ssid
            });
            let url = function (any) { return any["name"]; };
            if (type == "keyword") {
                url = function (term) {
                    return `<a target="__blank" href="https://www.uniprot.org/keywords/${term[""]}">${term["name"]}</a>`;
                };
            }
            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_enrichment"), json)
                .then(function (result) {
                return __awaiter(this, void 0, void 0, function* () {
                    desktop.parseMessage(result).then(function (message) {
                        desktop.parseResultFlag(result, message).then(function (flag) {
                            const title = flag ? "Run Enrichment Success" : "Analysis Error";
                            const data = message.info;
                            console.log(data);
                            if (flag) {
                                // success
                                const table = $ts.csv(data, true)
                                    .Objects()
                                    .Where(a => a["pvalue"] < 0.05)
                                    .Select(function (a) {
                                    a["name"] = url(a);
                                    return a;
                                });
                                $ts("#enrichment-result-table").clear();
                                $ts.appendTable(table, "#enrichment-result-table", null, { class: ["table", "table-sm"] });
                                $ts("#ex-with-icons-tabs-1").removeClass("show").removeClass("active");
                                $ts("#ex-with-icons-tabs-2").addClass("show").addClass("active");
                                $ts("#ex-with-icons-tab-1").removeClass("active");
                                $ts("#ex-with-icons-tab-2").addClass("active");
                                vm.session_id = ssid;
                                // do data plot
                                vm.plot_onclick();
                                desktop.showToastMessage("Success!", title, null, "success");
                            }
                            else {
                                // error
                                desktop.showToastMessage(message.info, title, null, "danger");
                            }
                        });
                    });
                });
            });
        }
        plot_onclick() {
            $ts("#busy-indicator").show();
            const json = JSON.stringify({
                session_id: this.session_id,
                type: "bar",
                background: $ts.select.getOption("#background"),
                top: 5
            });
            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_Rplot?base64=true"), json)
                .then(function (result) {
                return __awaiter(this, void 0, void 0, function* () {
                    desktop.parseMessage(result).then(function (message) {
                        desktop.parseResultFlag(result, message).then(function (flag) {
                            const title = flag ? "Run Enrichment Success" : "Analysis Error";
                            const data = message.info;
                            console.log(data);
                            if (flag) {
                                $ts("#Rplot").CType().src = data;
                                $ts("#Rplot-box").CType().href = data;
                                $ts("#busy-indicator").hide();
                            }
                            else {
                                desktop.showToastMessage(message.info, title, null, "danger");
                            }
                        });
                    });
                });
            });
        }
    }
    enrichment_analysis.note_mapping = {
        "GO": "go_note",
        "keyword": "uniprot_note",
        "Pfam": "pfam_note",
        "InterPro": "interpro_note"
    };
    pages.enrichment_analysis = enrichment_analysis;
})(pages || (pages = {}));
var pages;
(function (pages) {
    class enrichment_database extends Bootstrap {
        get appName() {
            return "enrichment_database";
        }
        init() {
            this.scanDatabaseList();
        }
        scanDatabaseList() {
            $ts("#busy-indicator").show();
            apps.gcmodeller
                .scanDatabase()
                .then(function (json) {
                return __awaiter(this, void 0, void 0, function* () {
                    const jsonString = yield json;
                    const dbList = JSON.parse(jsonString || "[]");
                    const dbSize = Object.keys(dbList).length;
                    const cardList = $ts("#repository");
                    for (let key in dbList) {
                        const metadata = dbList[key];
                        const card = enrichment_database.buildDbCard(key, metadata);
                        cardList.appendElement(card);
                        console.log(key);
                        $ts(`#${key}`).onclick = function () {
                            apps.gcmodeller.openEnrichmentPage(key, metadata.name, metadata.note);
                        };
                        $ts(`#${key}-meta`).onclick = function () {
                            $ts("#busy-indicator").show();
                            enrichment_database.showMetadata(key, metadata);
                        };
                    }
                    $ts("#busy-indicator").hide();
                    // show database summary information
                    desktop.showToastMessage(`Found ${dbSize} database.`, "Enrichment Database Repository", null, "info");
                });
            });
        }
        static showMetadata(key, metadata) {
            let sb = "";
            let json = JSON.stringify({
                guid: key
            });
            sb = sb + `<span class="badge badge-primary">Database Name</span>: ${metadata.name}(${key})<br />`;
            sb = sb + `<span class="badge badge-primary">Note</span>: <p class="note note-light">${metadata.note}</p><br />`;
            apps.gcmodeller
                .sendPost($ts.url("@web_invoke_inspector"), json)
                .then(function (result) {
                return __awaiter(this, void 0, void 0, function* () {
                    desktop.parseMessage(result).then(function (message) {
                        desktop.parseResultFlag(result, message).then(function (flag) {
                            const title = flag ? "Load Database Success" : "Load Database Error";
                            const data = message.info;
                            let hookLinks = null;
                            console.log(data);
                            if (flag) {
                                const backgrounds = $from(Object.keys(data.summary))
                                    .Select(function (name) {
                                    const info = data.summary[name];
                                    const pack = { name: name, info: info };
                                    return pack;
                                })
                                    .Where(a => a.info.unique_size > 0)
                                    .Where(a => a.info.unique_size / a.info.clusters > 1);
                                const protein_ids = backgrounds
                                    .Select(a => enrichment_database.summaryLine(a.name, a.info))
                                    .JoinBy("");
                                // success
                                desktop.showToastMessage("Success!", title, null, "success");
                                hookLinks = function () {
                                    for (let model of backgrounds.ToArray()) {
                                        const name = model.name;
                                        const id = `#model-${name}`;
                                        console.log(id);
                                        $ts(id).onclick = function () {
                                            $ts("#busy-indicator").show();
                                            console.log(`view background model: ${name}...`);
                                            enrichment_database.viewModel(key, name, model.info);
                                        };
                                    }
                                };
                                sb = sb + `<span class="badge badge-primary">Protein Counts</span>: ${data.counts}<br />`;
                                sb = sb + `<span class="badge badge-primary">Models</span>: ${backgrounds.Count}<br />`;
                                sb = sb + `<span class="badge badge-primary">Backgrounds</span>: <br /><br />
                                    <ul class="list-group list-group-light">
                                        ${protein_ids}
                                    </ul>
                                `;
                            }
                            else {
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
            });
        }
        /**
         * @param key a unique database hash name for query in the repository
        */
        static viewModel(key, name, info) {
            const json = JSON.stringify({
                guid: key, xref: name
            });
            apps.gcmodeller.sendPost($ts.url("@web_invoke_loadModel"), json).then(function (result) {
                return __awaiter(this, void 0, void 0, function* () {
                    desktop.parseMessage(result).then(function (message) {
                        desktop.parseResultFlag(result, message).then(function (flag) {
                            console.log(message);
                            if (flag) {
                                var galleryModal = new bootstrap.Modal($ts('#view-background'), {
                                    keyboard: false
                                });
                                $ts("#busy-indicator").hide();
                                $ts("#modal-close1").onclick = () => galleryModal.hide();
                                $ts("#modal-close2").onclick = () => galleryModal.hide();
                                galleryModal.show();
                            }
                            else {
                                desktop.showToastMessage(message.info, "Load Model Error", null, "danger");
                            }
                        });
                    });
                });
            });
        }
        static summaryLine(name, info) {
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
        static buildDbCard(key, metadata) {
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
        open_uniprot_onclick() {
            const textbox = $ts("#formFile").CType();
            apps.gcmodeller
                .getUniprotXmlDatabase()
                .then(function (path) {
                return __awaiter(this, void 0, void 0, function* () {
                    textbox.value = yield path;
                });
            });
        }
        imports_onclick() {
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
                return __awaiter(this, void 0, void 0, function* () {
                    desktop.parseMessage(msg).then(function (message) {
                        desktop.parseResultFlag(msg, message).then(function (flag) {
                            const title = flag ? "Imports Task Success" : "Imports Task Error";
                            if (flag) {
                                // success
                                desktop.showToastMessage(message.info, title, null, "success");
                            }
                            else {
                                // error
                                desktop.showToastMessage(message.info, title, null, "danger");
                            }
                            $ts("#busy-indicator").hide();
                        });
                    });
                });
            });
        }
    }
    pages.enrichment_database = enrichment_database;
})(pages || (pages = {}));
//# sourceMappingURL=biocad_desktop.js.map