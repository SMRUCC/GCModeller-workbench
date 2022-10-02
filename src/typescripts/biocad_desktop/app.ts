/// <reference path="../build/linq.d.ts" />

namespace apps {

    export function run() {
        Router.AddAppHandler(new pages.enrichment_database());
        Router.RunApp();
    }
}

$ts.mode = Modes.debug;
$ts(apps.run);
