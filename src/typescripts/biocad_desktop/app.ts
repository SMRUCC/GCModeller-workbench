/// <reference path="../build/linq.d.ts" />

namespace apps {

    /**
     * async proxy
    */
    export const gcmodeller: biocad_desktop = getWebview2HostObject();

    function getWebview2HostObject() {
        try {
            return (<any>window).chrome.webview.hostObjects.gcmodeller;
        } catch (Error) {
            return {
                getUniprotXmlDatabase: warningMsg
            };
        }
    }

    async function warningMsg() {
        throw new Error("Please run from webview2 application!");
    }

    export function run() {
        Router.AddAppHandler(new pages.enrichment_database());
        Router.AddAppHandler(new pages.enrichment_analysis());
        Router.RunApp();
    }
}

$ts.mode = Modes.debug;
$ts(apps.run);
