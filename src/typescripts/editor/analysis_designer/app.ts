namespace sampleinfo_editor.analysis_editor {

    export interface analysisDesign {
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

    export interface updateDesigns { (current: analysisDesign[]): void; }
    export interface addDesign { (labels: string[]): void; }

    export function init1_analysisUI() {
        loadStyle();
    }

    /**
     * @param id the container id
    */
    export function loadDesigner(id: string, groups: string[], currentDesigns: analysisDesign[], handler: updateDesigns = null) {
        let labelContainer: IHTMLElement;
        let designContainer: IHTMLElement;

        $ts(id).clear().appendElement(createUI(UI_events.handlerEvent(handler)));

        labelContainer = $ts("#all_groups");
        designContainer = $ts("#designs");

        for (let label of groups) {
            labelContainer.appendElement(UI_events.doLabeler(label));
        }

        let labels: string[];
        let handleUpdate: Delegate.Action;

        handler = isNullOrUndefined(handler) ? DoNothing : handler;
        handleUpdate = function () {
            handler(UI_events.getCurrentDesigns());
        }

        for (let design of currentDesigns) {
            labels = design.group_info;
            designContainer.appendElement(analysisDesignItem(labels, designContainer, handleUpdate));
        }
    }

}