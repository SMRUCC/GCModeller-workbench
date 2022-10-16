/// <reference path="../../build/linq.d.ts" />

namespace uikit.table_editor {

    /**
     * @param filters the object field names
    */
    export function fromData<T extends {}>(data: T[], divId: string, filters?: string[], opts: editorConfig = defaultConfig()): tableEditor {
        let haveFilter: boolean = !isNullOrEmpty(filters);
        let headers = haveFilter ? filters : Object.keys(data[0]);
        let editor = new tableEditor(divId, headers, opts);
        let lock = opts.allowsAddNew;
        let copy: {};

        editor.opts.allowsAddNew = true;

        for (let element of data) {
            if (haveFilter) {
                copy = {};

                for (let name of filters) {
                    copy[name] = element[name];
                }

                element = <any>copy;
            }

            editor.edit_lock = false;
            editor.addNew(element, true).confirmNew();
        }

        editor.opts.allowsAddNew = lock;

        return editor;
    }
}