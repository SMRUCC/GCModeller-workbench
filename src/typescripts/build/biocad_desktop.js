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
    apps.gcmodeller = getWebview2HostObject();
    function getWebview2HostObject() {
        try {
            return window.chrome.webview.hostObjects.gcmodeller;
        }
        catch (Error) {
            return {
                getUniprotXmlDatabase: warningMsg
            };
        }
    }
    function warningMsg() {
        throw new Error("Please run from webview2 application!");
    }
    function run() {
        Router.AddAppHandler(new pages.enrichment_database());
        Router.RunApp();
        console.log(apps.gcmodeller);
    }
    apps.run = run;
})(apps || (apps = {}));
$ts.mode = Modes.debug;
$ts(apps.run);
var desktop;
(function (desktop) {
    function showToastMessage(msg, title = "Task Error", subtitle = "", level = "info", autohide = true) {
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
            "data-mdb-autohide": autohide.toString()
        }).display(`        
            <div class="toast-header toast-${level}">
                <i class="${toastIconsMD[level]}"></i>
                <strong class="me-auto">${title}</strong>
                <small>${(!subtitle) || (subtitle.toLowerCase() == "null") ? "" : subtitle}</small>
                <button type="button" class="btn-close" data-mdb-dismiss="toast" aria-label="Close">
                </button>
            </div>
            <div class="toast-body">${processHtmlMsg(msg)}</div>
        `);
        return box;
    }
    function processHtmlMsg(text) {
        text = text.replace(/[<]/ig, "&lt;");
        text = Strings.lineTokens(text).join("<br />");
        return text;
    }
})(desktop || (desktop = {}));
var pages;
(function (pages) {
    class enrichment_database extends Bootstrap {
        get appName() {
            return "enrichment_database";
        }
        init() {
            $ts("#busy-indicator").hide();
        }
        /**
         * method execute on native host side, not R server backend
        */
        open_uniprot_onclick() {
            const textbox = $ts("#formFile").CType();
            apps.gcmodeller
                .getUniprotXmlDatabase()
                .then(path => textbox.value = path);
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
                    msg = yield msg;
                    console.log(msg);
                    if (msg.result) {
                        // success
                        desktop.showToastMessage(msg.data, "Imports Task Success", null, "success");
                    }
                    else {
                        // error
                        desktop.showToastMessage(msg.data, "Imports Task Error", null, "danger");
                    }
                    $ts("#busy-indicator").hide();
                });
            });
        }
    }
    pages.enrichment_database = enrichment_database;
})(pages || (pages = {}));
//# sourceMappingURL=biocad_desktop.js.map