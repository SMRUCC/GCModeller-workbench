/// <reference path="linq.d.ts" />
/// <reference path="sampleinfo_editor.d.ts" />
declare namespace apps {
    const uniprot_assembly: string;
    const expressionMatrix: string;
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
    scanDatabase(): Promise<string>;
    openEnrichmentPage(database: string, name: string, note: string): Promise<boolean>;
    getEnzymeClass(): Promise<string>;
    getTaskList(): Promise<string[]>;
    checkTaskList(): Promise<string[]>;
    getFileOpen(filterString: string): Promise<string>;
    getFolderOpen(): Promise<string>;
    sendPost(url: string, json: string): Promise<hostMsg>;
    createTask(title: string, url: string, json: string): Promise<hostMsg>;
    jumptoTaskManager(): any;
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
    /**
     * show ``#busy-indicator`` loading spinner
    */
    function loading(message?: string): void;
    function closeSpinner(): void;
    function showTaskAlert(): void;
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
declare namespace desktop {
    interface configuration {
        BlastBin: string;
        BlastDb: string;
        RepositoryRoot: string;
        Dev2: IDEConfiguration;
    }
    interface IDEConfiguration {
        StartPage: {
            CloseAfterProjectLoad: boolean;
            ShowOnStartUp: boolean;
        };
        IDE: IDEWindowConfig;
        Session: any;
        RememberWindowStatus: boolean;
    }
    interface IDEWindowConfig {
        Location: {
            Left: number;
            Top: number;
        };
        Size: {
            Width: number;
            Height: number;
        };
        Language: languages;
    }
    enum languages {
        System = 0,
        "zh-CN" = 1,
        "en-US" = 2,
        "fr-FR" = 3
    }
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
         *
         * this unique id is generated based on the context of:
         *
         *   1. current timestamp
         *   2. current page app name
         *   3. additionally, the analysis parameter json object string
         *
         * @param contents the additional context data to generate
         *    the guid, this parameter value can be optional
        */
        protected generateSsid(contents?: {}): string;
    }
}
declare namespace pages {
    interface webapp {
        title: string;
        desc: string;
        /**
         * The function name to invoke method in host app
         *
         * this property can be used as the unique id of the web app
        */
        appLink: string;
        icon: string;
    }
    function toSearchTerm(item: webapp, i: number): pages.suggestion_list.term[];
    class applets extends Bootstrap {
        static readonly defaultIcon: string;
        readonly appList: webapp[];
        private terms;
        private suggestions;
        readonly appName: string;
        protected init(): void;
        /**
         * handling of the app search event
        */
        private hookSearchBar;
        private static showAppList;
        private static buildElement;
    }
}
declare namespace pages {
    class data_repository extends Bootstrap {
        readonly appName: string;
        protected init(): void;
    }
}
declare namespace omicsAnalysis {
    function parseSampleInfo(analysis_file: string, using: Delegate.Sub, err?: Delegate.Sub): void;
    function saveSampleInfo(table: sampleinfo_editor.IsampleInfo[], analysis_file: string, success: Delegate.Action): void;
}
declare namespace pages {
    class settings extends Bootstrap {
        readonly appName: string;
        private rawConfigs;
        private GetSettings;
        private SaveSettings;
        protected init(): void;
        private loadSettings;
        RememberWindowStatus_onchange(): void;
        language_onchange(): void;
        CloseAfterProjectLoad_onclick(): void;
        ShowOnStartUp_onclick(): void;
        open_ncbi_blast_folder_onclick(): void;
        open_repository_folder_onclick(): void;
    }
}
declare namespace pages {
    interface Task {
        appName: string;
        time: string;
        title: string;
        status: "success" | "error" | "pending" | "running" | "cancel";
        session_id: string;
        arguments: {};
        /**
         * not empty if the status is ``error``
        */
        error: desktop.RSharpError;
        logtext: string;
        url: string;
    }
    class web_task extends Bootstrap {
        readonly appName: string;
        protected init(): void;
        private checkList;
        private showTaskDatalist;
        private loadTaskList;
        private static getHostObject;
        private static buildTaskHtml;
    }
}
declare namespace pages {
    class cmeans_patterns extends analysis_session {
        readonly appName: string;
        protected init(): void;
        button_open_click(): void;
        run_onclick(): void;
        refresh_Rplot_onclick(): void;
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
        loadDemo_click(): void;
        add_equation_click(): {
            eq: HTMLInputElement;
            y0: HTMLInputElement;
        };
        private equationIndexing;
        add_constant_click(): {
            name: HTMLInputElement;
            val: HTMLInputElement;
        };
        private static loadContents;
        run_click(): void;
        createPlot(): void;
    }
}
declare namespace pages {
    class zscore_analysis extends analysis_session {
        readonly appName: string;
        protected init(): void;
        button_open_onclick(): void;
        run_onclick(): void;
        refresh_Rplot_onclick(): void;
    }
}
declare namespace pages.analysis_project {
    class create_project extends Bootstrap {
        readonly appName: string;
        protected init(): void;
        expr1_onclick(): void;
        sample2_onclick(): void;
        create3_onclick(): void;
        button_open_matrix_click(): void;
        private check_matrix;
        button_open_sampleinfo_click(): void;
    }
}
declare namespace pages.analysis_project {
    class edit_sampleinfo extends Bootstrap {
        readonly appName: string;
        protected init(): void;
        reset(): void;
        private sampleEditor;
        private beginEditSampleInfo0;
        private beginEditSampleInfo1;
        private beginEditSampleInfo;
        private editor;
        private sampleInfo;
        private save;
        private xload_sampleInfo;
        private static deleteSampleRow;
    }
}
declare namespace pages.background {
    /**
     * 画布的参数设置
    */
    interface CanvasSettings {
        /**
         * 所创建的画布对象的id
        */
        canvasId: string;
        zIndex: number;
        opacity: number;
        color: string;
        /**
         * 点的数量
        */
        n: number;
    }
    /**
     * 画布上面的一个移动的点的模型
    */
    interface dot {
        /**
         * 当前的位置``x``
        */
        x: number;
        /**
         * 当前的位置``y``
        */
        y: number;
        xa: number;
        ya: number;
        max: number;
    }
}
declare namespace pages.background {
    class network {
        uCanvas: HTMLCanvasElement;
        uContext: CanvasRenderingContext2D;
        f: dot;
        size: number[];
        dots: dot[];
        setting: CanvasSettings;
        frameRender: (callback: FrameRequestCallback) => number;
        constructor(uCanvas?: HTMLCanvasElement, uContext?: CanvasRenderingContext2D, f?: dot, size?: number[], dots?: dot[], setting?: CanvasSettings, frameRender?: (callback: FrameRequestCallback) => number);
        static getTag(tagName: string): Element;
        static getById(id: string): Element;
        /**
         * 当窗口大小发生改变的时候，画布的事件
        */
        canvasResize(): void;
        /**
         * 更新画布上面的一帧动画
        */
        update(): void;
        static defaultCallback(callback: FrameRequestCallback): number;
        /**
         * 注册鼠标设备以及画布更新事件
        */
        registerDevice(): void;
    }
    /**
     * 运行这个网络画布
     *
     * @param containerId Canvas所进行显示的目标div的id编号，如果这个编号为空值，则默认显示在整个body上面
     * @param settings 配置参数
    */
    function run(containerId?: string, settings?: CanvasSettings): void;
}
declare namespace pages.repository {
    class enrichment_database extends Bootstrap {
        readonly appName: string;
        protected init(): void;
        private scanDatabaseList;
        private showDatabaseList;
        private static showMetadata;
        private static displayDatabaseContentSummary;
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
declare namespace pages.repository {
    class enzyme_database extends Bootstrap {
        readonly appName: string;
        protected init(): void;
        private loadRootNodes;
        buildEnzymeTree(node: {
            id: string;
        }, cb: (a: any[]) => void): void;
        /**
         * Create a new background web task
        */
        run_onclick(): void;
        button_open_uniprot(): void;
    }
}
declare namespace pages.suggestion_list.render {
    /**
     * 将结果显示到网页上面
     *
     * @param div 带有#符号前缀的id查询表达式
    */
    function makeSuggestions(terms: term[], div: string, click: (term: term) => void, top?: number, caseInsensitive?: boolean, divClass?: any, addNew?: ((newTerm: string) => void)): (input: string) => void;
}
declare namespace pages.suggestion_list {
    class suggestion {
        private terms;
        constructor(terms: term[]);
        hasEquals(input: string, caseInsensitive?: boolean): boolean;
        /**
         * 返回最相似的前5个结果
        */
        populateSuggestion(input: string, top?: number, caseInsensitive?: boolean): term[];
        private static makeAdditionalSuggestion;
        private static getScore;
    }
}
declare namespace pages.suggestion_list {
    const NA: number;
    /**
     * Term for suggestion
    */
    class term {
        id: number;
        term: string;
        /**
         * @param id 这个term在数据库之中的id编号
        */
        constructor(id: number, term: string);
        /**
         * 使用动态规划算法计算出当前的这个term和用户输入之间的相似度
        */
        dist(input: string): number;
        static indexOf(term: string, input: string): number;
    }
    interface scoreTerm {
        score: number;
        term: term;
    }
}
