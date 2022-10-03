/// <reference path="../build/linq.d.ts" />

namespace apps {

    export const gcmodeller: biocad_desktop = getWebview2HostObject();

    function getWebview2HostObject() {
        try {
            return (<any>window).chrome.webview.hostObjects.sync.gcmodeller;
        } catch (Error) {
            return {
                getUniprotXmlDatabase: warningMsg
            };
        }
    }

    function warningMsg() {
        throw new Error("Please run from webview2 application!");
    }

    export function run() {
        Router.AddAppHandler(new pages.enrichment_database());
        Router.RunApp();

        console.log(gcmodeller);
    }
}

$ts.mode = Modes.debug;
$ts(apps.run);
