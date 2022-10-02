/// <reference path="../build/linq.d.ts" />

namespace apps {

    export const gcmodeller: biocad_desktop = (<any>window).chrome.webview.hostObjects.sync.gcmodeller;

    export function run() {
        Router.AddAppHandler(new pages.enrichment_database());
        Router.RunApp();

        console.log(gcmodeller);
    }
}

$ts.mode = Modes.debug;
$ts(apps.run);
