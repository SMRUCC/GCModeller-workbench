var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
/// <reference path="../build/linq.d.ts" />
var apps;
(function (apps) {
    apps.gcmodeller = getWebview2HostObject();
    function getWebview2HostObject() {
        try {
            return window.chrome.webview.hostObjects.sync.gcmodeller;
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
    function showToastMessage(msg, title, subtitle, level, autohide) {
        if (title === void 0) { title = "Task Error"; }
        if (subtitle === void 0) { subtitle = ""; }
        if (level === void 0) { level = "info"; }
        if (autohide === void 0) { autohide = true; }
        $ts("#toast-message").appendElement(toastHtml(msg, title, subtitle, level, autohide));
    }
    desktop.showToastMessage = showToastMessage;
    var toastIconsMD = {
        "success": "fas fa-check fa-lg me-2",
        "danger": "fas fa-exclamation-circle fa-lg me-2",
        "warning": "fas fa-exclamation-triangle fa-lg me-2",
        "info": "fas fa-info-circle fa-lg me-2"
    };
    function toastHtml(msg, title, subtitle, level, autohide) {
        if (title === void 0) { title = "Task Error"; }
        if (subtitle === void 0) { subtitle = ""; }
        if (level === void 0) { level = "danger"; }
        if (autohide === void 0) { autohide = true; }
        var box = $ts("<div>", {
            class: ["toast", "show", "fade", "toast-" + level],
            role: "alert",
            "aria-live": "assertive",
            "aria-atomic": "true",
            "data-mdb-color": level,
            "data-mdb-autohide": autohide.toString()
        }).display("        \n            <div class=\"toast-header toast-" + level + "\">\n                <i class=\"" + toastIconsMD[level] + "\"></i>\n                <strong class=\"me-auto\">" + title + "</strong>\n                <small>" + subtitle + "</small>\n                <button type=\"button\" class=\"btn-close\" data-mdb-dismiss=\"toast\" aria-label=\"Close\">\n                </button>\n            </div>\n            <div class=\"toast-body\">" + processHtmlMsg(msg) + "</div>\n        ");
        return box;
    }
    function processHtmlMsg(text) {
        text = text.replace("<", "&lt;");
        text = Strings.lineTokens(text).join("<br />");
        return text;
    }
})(desktop || (desktop = {}));
var pages;
(function (pages) {
    var enrichment_database = /** @class */ (function (_super) {
        __extends(enrichment_database, _super);
        function enrichment_database() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        Object.defineProperty(enrichment_database.prototype, "appName", {
            get: function () {
                return "enrichment_database";
            },
            enumerable: true,
            configurable: true
        });
        enrichment_database.prototype.init = function () {
            $ts("#busy-indicator").hide();
        };
        /**
         * method execute on native host side, not R server backend
        */
        enrichment_database.prototype.open_uniprot_onclick = function () {
            $ts("#formFile").CType().value = apps.gcmodeller.getUniprotXmlDatabase();
        };
        enrichment_database.prototype.imports_onclick = function () {
            var data = {
                file: $ts.value("#formFile"),
                name: $ts.value("#title"),
                note: $ts.value("#description")
            };
            $ts("#busy-indicator").show();
            var msg = apps.gcmodeller.sendPost($ts.url("@web_invoke_imports"), JSON.stringify(data));
            if (msg.result) {
                // success
                desktop.showToastMessage(msg.data, "Imports Task Success", null, "success");
            }
            else {
                // error
                desktop.showToastMessage(msg.data, "Imports Task Error", null, "danger");
            }
            $ts("#busy-indicator").hide();
        };
        return enrichment_database;
    }(Bootstrap));
    pages.enrichment_database = enrichment_database;
})(pages || (pages = {}));
//# sourceMappingURL=biocad_desktop.js.map