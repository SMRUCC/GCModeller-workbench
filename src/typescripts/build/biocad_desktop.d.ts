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
    getFileOpen(filterString: string): Promise<string>;
    sendPost(url: string, json: string): Promise<hostMsg>;
}
interface hostMsg {
    result: boolean;
    data: string;
}
declare namespace desktop {
    interface messageCallback<T> {
        (success: boolean, message: IMsg<T>): void;
    }
    /**
     * the host message async callback helper
    */
    function promiseAsyncCallback<T>(hostMsg: hostMsg, callback: messageCallback<T>): Promise<void>;
}
declare namespace desktop {
    function now(): string;
    function parseResultFlag(msg: hostMsg, message: IMsg<string>): Promise<boolean>;
    function parseMessage(msg: hostMsg): Promise<IMsg<string>>;
    function processHtmlMsg(text: string | Object): string;
}
declare namespace desktop {
    function showToastMessage(msg: string, title?: string, level?: "danger" | "success" | "warning" | "info", autohide?: boolean): void;
}
declare namespace js_plot {
    class scatter3d {
        private myChart;
        private option;
        constructor(div?: string);
        plot(data: any, symbolSize?: number): void;
    }
}
declare namespace pages {
    abstract class analysis_session extends Bootstrap {
        protected session_id: string;
        /**
         * the unique session id generator for the R# backend
        */
        protected generateSsid(contents: {}): string;
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
declare namespace pages {
    class dataEmbedding extends analysis_session {
        readonly appName: string;
        protected init(): void;
        button_open_click(): void;
        run_click(): void;
        private static plot3DScatter;
        refresh_Rplot_click(): void;
        save_project_click(): void;
        download_zip_click(): void;
    }
}
declare namespace pages {
    class enrichment_analysis extends analysis_session {
        private database;
        private static note_mapping;
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
    class runPLAS extends analysis_session {
        readonly appName: string;
        protected init(): void;
        add_equation_click(): void;
    }
}
