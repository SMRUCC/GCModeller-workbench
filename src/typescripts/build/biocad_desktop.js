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
                getUniprotXmlDatabase: warningMsg
            };
        }
    }
    function warningMsg() {
        return __awaiter(this, void 0, void 0, function* () {
            throw new Error("Please run from webview2 application!");
        });
    }
    function run() {
        Router.AddAppHandler(new pages.enrichment_database());
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
            const dataString = yield msg.data;
            const json = JSON.parse(dataString);
            return json;
        });
    }
    desktop.parseMessage = parseMessage;
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
            <div class="toast-body">${processHtmlMsg(msg)}</div>
        `);
        return box;
    }
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
})(desktop || (desktop = {}));
var pages;
(function (pages) {
    class enrichment_database extends Bootstrap {
        get appName() {
            return "enrichment_database";
        }
        init() {
            $ts("#busy-indicator").show();
            this.scanDatabaseList();
        }
        scanDatabaseList() {
            apps.gcmodeller
                .scanDatabase()
                .then(function (json) {
                return __awaiter(this, void 0, void 0, function* () {
                    const jsonString = yield json;
                    const dbList = JSON.parse(jsonString);
                    console.log(dbList);
                });
            });
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