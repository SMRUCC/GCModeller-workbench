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
    class applets extends Bootstrap {
        readonly appName: string;
        protected init(): void;
    }
}
declare namespace pages {
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
declare namespace pages.analysis_project {
    class create_project extends Bootstrap {
        readonly appName: string;
        protected init(): void;
        expr1_onclick(): void;
        sample2_onclick(): void;
        create3_onclick(): void;
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
