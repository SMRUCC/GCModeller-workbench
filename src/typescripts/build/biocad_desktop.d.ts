/// <reference path="linq.d.ts" />
declare namespace apps {
    /**
     * async proxy
    */
    const gcmodeller: biocad_desktop;
    function run(): void;
}
declare namespace desktop {
    interface RSharpError {
        Message: string | string[];
        Source: string;
        TypeFullName: string;
        StackTrace: {
            File: string;
            Line: string;
            Method: {
                Method: string;
                Module: string;
                Namespace: string;
            };
        }[];
    }
}
declare namespace desktop.RSharp {
    function RSharpErrorMessage(obj: RSharpError): string;
    function isRSharpError(obj: {}): boolean;
}
interface biocad_desktop {
    getUniprotXmlDatabase(): Promise<string>;
    scanDatabase(): Promise<string>;
    openEnrichmentPage(database: string, name: string, note: string): Promise<boolean>;
    sendPost(url: string, json: string): Promise<hostMsg>;
}
interface hostMsg {
    result: boolean;
    data: string;
}
declare namespace desktop {
    function parseResultFlag(msg: hostMsg, message: IMsg<string>): Promise<boolean>;
    function parseMessage(msg: hostMsg): Promise<IMsg<string>>;
    function processHtmlMsg(text: string | Object): string;
}
declare namespace desktop {
    function showToastMessage(msg: string, title?: string, subtitle?: string, level?: "danger" | "success" | "warning" | "info", autohide?: boolean): void;
}
declare namespace pages {
    class dataEmbedding extends Bootstrap {
        readonly appName: string;
        protected init(): void;
    }
}
declare namespace pages {
    class enrichment_analysis extends Bootstrap {
        private database;
        private static note_mapping;
        private session_id;
        readonly appName: string;
        protected init(): void;
        background_onchange(value: string): void;
        run_onclick(): void;
        private static term_url;
        private runInternal;
        plot_onclick(): void;
    }
}
declare namespace pages {
    class enrichment_database extends Bootstrap {
        readonly appName: string;
        protected init(): void;
        private scanDatabaseList;
        private static showMetadata;
        /**
         * @param key a unique database hash name for query in the repository
        */
        private static viewModel;
        static showProteins(array: string): void;
        private static summaryLine;
        private static buildDbCard;
        /**
         * method execute on native host side, not R server backend
        */
        open_uniprot_onclick(): void;
        imports_onclick(): void;
    }
}
