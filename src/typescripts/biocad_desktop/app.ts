/// <reference path="../build/linq.d.ts" />

namespace apps {

    export const uniprot_assembly: string = "UniProt Xml dataset(*.xml)|*.xml";
    export const expressionMatrix: string = "Microsoft Excel(*.csv)|*.csv|GCModeller HTS Matrix(*.HTS)|*.HTS";

    /**
     * async proxy
    */
    export const gcmodeller: biocad_desktop = getWebview2HostObject();

    function getWebview2HostObject(): any {
        try {
            return (<any>window).chrome.webview.hostObjects.gcmodeller;
        } catch (Error) {
            return <biocad_desktop>{               
                scanDatabase: <any>warningMsg,
                openEnrichmentPage: <any>warningMsg,

                sendPost: <any>warningMsg
            };
        }
    }

    async function warningMsg() {
        desktop.showToastMessage("Please run from webview2 application!", "Web app error", "warning");
    }

    export function run() {
        Router.AddAppHandler(new pages.applets());
        Router.AddAppHandler(new pages.settings());
        Router.AddAppHandler(new pages.data_repository());

        Router.AddAppHandler(new pages.analysis_project.create_project());
        Router.AddAppHandler(new pages.analysis_project.edit_sampleinfo());

        Router.AddAppHandler(new pages.repository.enrichment_database());
        Router.AddAppHandler(new pages.repository.enzyme_database());

        Router.AddAppHandler(new pages.enrichment_analysis());
        Router.AddAppHandler(new pages.cmeans_patterns());
        Router.AddAppHandler(new pages.zscore_analysis());
        Router.AddAppHandler(new pages.dataEmbedding());
        Router.AddAppHandler(new pages.runPLAS());

        Router.RunApp();
    }
}

$ts.mode = Modes.debug;
$ts(apps.run);
