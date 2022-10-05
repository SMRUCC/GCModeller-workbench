/// <reference path="../build/linq.d.ts" />

namespace apps {

    /**
     * async proxy
    */
    export const gcmodeller: biocad_desktop = getWebview2HostObject();

    function getWebview2HostObject(): any {
        try {
            return (<any>window).chrome.webview.hostObjects.gcmodeller;
        } catch (Error) {
            return <biocad_desktop>{
                getUniprotXmlDatabase: <any>warningMsg,
                scanDatabase: <any>warningMsg,
                openEnrichmentPage: <any>warningMsg,

                sendPost: <any>warningMsg
            };
        }
    }

    async function warningMsg() {
        desktop.showToastMessage("Please run from webview2 application!", "Web app error", null, "warning");
    }

    export function run() {
        Router.AddAppHandler(new pages.enrichment_database());
        Router.AddAppHandler(new pages.enrichment_analysis());
        Router.AddAppHandler(new pages.dataEmbedding());
        Router.RunApp();
    }
}

$ts.mode = Modes.debug;
$ts(apps.run);
