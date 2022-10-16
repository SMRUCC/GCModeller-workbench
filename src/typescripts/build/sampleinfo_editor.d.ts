/// <reference path="linq.d.ts" />
declare namespace biodeep {
    class labelStack {
        private labels;
        readonly n: number;
        add(label: string): void;
        delete(label: string): void;
        popall(): string[];
    }
}
declare namespace biodeep {
    function createUI(handler: addDesign): HTMLElement;
    const labels: labelStack;
    function analysisDesignItem(labels: string[], container: HTMLElement, handleUpdate: Delegate.Action): HTMLElement;
}
declare namespace biodeep {
    function loadStyle(): void;
}
interface analysisDesign {
    /**
     * 比对的组别数量
    */
    groups: number;
    /**
     * 比对的组别的编号
    */
    label: string;
    group_info: string[];
}
interface updateDesigns {
    (current: analysisDesign[]): void;
}
interface addDesign {
    (labels: string[]): void;
}
/**
 * @param id the container id
*/
declare function loadDesigner(id: string, groups: string[], currentDesigns: analysisDesign[], handler?: updateDesigns): void;
declare namespace biodeep.UI_events {
    function handlerEvent(handler: updateDesigns): addDesign;
    function doLabeler(label: string): HTMLElement;
    function getCurrentDesigns(): analysisDesign[];
}
interface IsampleMeta {
    sampleInfo: string;
    shape: number;
    color: string;
    color1: string;
    color2: string;
}
interface saveAction {
    (meta: IsampleMeta[]): void;
}
declare namespace biodeep {
    class metaEditor {
        sampleMeta: IsampleMeta[];
        constructor(sampleMeta: IsampleMeta[], div: string);
        private static jqueryColorPickerUI;
        private static holdLabel;
        setColor(label: string): (color: string) => void;
        shapeSetter(label: string, value: string): void;
        colorSetter(label: string, value: string): void;
    }
    function reset(): void;
    function setColorValue(color: TypeScript.ColorManager.w3color): void;
}
interface sampleInfoTableBuilder {
    (model: biodeep.IsampleInfo[]): HTMLElement;
}
declare namespace biodeep {
    interface IsampleInfo {
        /**
         * the unique id
        */
        ID: string;
        /**
         * the display title of the sample
        */
        sample_name: string;
        /**
         * the sample group name
        */
        sample_info: string;
        /**
         * injection order in LC-MS experiment, used for batch normalization only
        */
        injectionOrder: number;
        /**
         * the LC-MS experiment batch number
        */
        batch: number;
        sample_info1?: string;
        sample_info2?: string;
        color: string;
        color1?: string;
        color2?: string;
        shape: number;
        shape1?: number;
        shape2?: number;
        delete?: string;
    }
    function ensureSampleInfoModel(data: string[] | IEnumerator<string> | IsampleInfo[]): IsampleInfo[];
    function as_tabular(sampleInfo: IsampleInfo[] | IEnumerator<IsampleInfo>): string;
    function buildModels(guessInfo: NamedValue<string[]>[]): IsampleInfo[];
    function guess_groupInfo(sampleNames: string[] | IEnumerator<string>): NamedValue<string[]>[];
}
declare namespace biodeep.ui {
    function doStyle(): void;
}
declare namespace biodeep {
    const sampleInfoId: string;
    const batchInfoId: string;
    const sample1Id: string;
    const sample2Id: string;
    /**
     * UI class for create sample group information
    */
    class sampleInfoUI {
        container: string;
        private tableTitles;
        readonly model: IsampleInfo[];
        readonly csv: string;
        readonly hasRowSelected: boolean;
        /**
         * @param builder 这个参数是用于兼容tableEditor模块的
         * @param getHeaders 设置这个参数一般是因为表头是被翻译过了的
        */
        constructor(container: string, sampleNames: string[] | IsampleInfo[], builder: sampleInfoTableBuilder, getHeaders?: Delegate.Func<string[]>);
        private lastSelectedRow;
        private trs;
        editMode: boolean;
        /**
         * hook events
        */
        private init;
        private displayMenu;
        private registerContextMenu;
        private exitEditMode;
        private buildSampleInfo;
        private hookDataUpdates;
        RowClick(currenttr: HTMLTableRowElement, lock: boolean): void;
        toggleRow(row: HTMLTableRowElement): void;
        selectRowsBetweenIndexes(indexes: number[]): void;
        clearAll(): void;
        /**
         * default method for create html table
        */
        private static createSampleInfotable;
        private static createContextMenu;
    }
}
declare namespace biodeep {
    function createInputModal(id: string, title: string, description: string): void;
}
declare namespace uikit.table_editor {
    /**
     * @param filters the object field names
    */
    function fromData<T extends {}>(data: T[], divId: string, filters?: string[], opts?: editorConfig): tableEditor;
}
declare namespace uikit.table_editor {
    /**
     * 对表格之中的单行数据的编辑操作的对象
    */
    class editor {
        tr: HTMLTableRowElement;
        tbody: HTMLElement;
        table: tableEditor;
        /**
         * 操作按钮的表格的列对象
        */
        private editorActiontd;
        private divs;
        dropFlag: boolean;
        private _onremoves;
        /**
         * @param tr 进行数据编辑操作的行对象
        */
        constructor(tr: HTMLTableRowElement, tbody: HTMLElement, table: tableEditor);
        getElementById(id: string): HTMLElement;
        /**
         * 将符合id条件的html元素显示出来
        */
        show(id: string): void;
        /**
         * 隐藏掉目标html元素对象
        */
        hide(id: string): void;
        /**
         * 将表格内容的输入框隐藏掉
        */
        hideInputs(confirm?: boolean): void;
        /**
         * 点击编辑按钮之后显示表格的单元格内容编辑的输入框
        */
        showInputs(): void;
        /**
         * 确认添加新的表格行数据
        */
        confirmNew(): void;
        /**
         * 取消新增的行数据
        */
        cancelAddNew(): void;
        onDelete(action: Delegate.Sub): void;
        /**
         * 对当前的行数据进行删除
        */
        removeCurrent(): void;
        /**
         * 当前的行进入编辑模式
        */
        editThis(): void;
        /**
         * 确认对当前的行数据的编辑操作，并退出编辑模式
        */
        confirmEdit(confirm?: boolean): void;
    }
}
declare namespace uikit.table_editor {
    interface editorConfig {
        style?: string;
        className?: string;
        table_id?: string;
        tdConfig?: columnConfig[];
        warning?: Delegate.Action;
        deleteRow?: Delegate.Sub;
        showRowNumber: boolean;
        allowsAddNew: boolean;
        names?: buttonNames;
        clearContainer?: boolean;
    }
    interface buttonNames {
        remove: string;
        edit: string;
        OK: string;
        cancel: string;
        actions: string;
    }
    interface columnConfig {
        width?: string;
        lockEditor?: boolean;
        /**
         * the display title
        */
        title?: string;
        asUrl?: Delegate.Func<string>;
    }
    function defaultButtonNames(): buttonNames;
    function defaultConfig(): editorConfig;
    function contains(opts: editorConfig, i: number): boolean;
}
declare namespace uikit.table_editor {
    class tableEditor {
        headers: string[];
        opts: editorConfig;
        private tbody;
        private rows;
        /**
         * 只可以同时编辑一行数据，会利用这个开关来锁住再编辑的时候添加新的行数据或者编辑其他的行数据
        */
        edit_lock: boolean;
        table: HTMLTableElement;
        fieldHeaders: string[];
        /**
         * 行号(如果第一列是唯一的数字id，则可以调用这个属性来获取最后一行的id作为id递增计算的基础)
        */
        readonly keyIndex: number;
        /**
         * 获取当前表格的行数
        */
        readonly nrows: number;
        /**
         * 这个构造函数将会创建一个新的table对象
         *
         * @param id id value of a ``<div>`` tag.
         * @param headers the object field names.
        */
        constructor(id: string, headers: string[], opts?: editorConfig);
        addNew(value?: {}, hideInputs?: boolean): editor;
        private addNewInternal;
        private propertyValue;
        /**
         * 将目标表格中的文本读取出来以进行后续的操作
        */
        TableData<T extends {}>(keepsRowId?: boolean): T[];
        TableRows(): editor[];
        private createObject;
    }
}
declare namespace uikit.table_editor.template {
    /**
     * 定义了如何生成表格之中的行数据进行编辑操作的按钮的html用户界面
    */
    const editor_template: string;
}
