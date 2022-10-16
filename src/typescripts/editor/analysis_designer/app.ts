/// <reference path="../../../build/linq.d.ts" />

/// <reference path="html.ts" />
/// <reference path="css.ts" />

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

interface updateDesigns { (current: analysisDesign[]): void; }
interface addDesign { (labels: string[]): void; }

$ts(biodeep.loadStyle);

/**
 * @param id the container id
*/
function loadDesigner(id: string, groups: string[], currentDesigns: analysisDesign[], handler: updateDesigns = null) {
    let labelContainer: IHTMLElement;
    let designContainer: IHTMLElement;

    $ts(id).clear().appendElement(biodeep.createUI(biodeep.UI_events.handlerEvent(handler)));

    labelContainer = $ts("#all_groups");
    designContainer = $ts("#designs");

    for (let label of groups) {
        labelContainer.appendElement(biodeep.UI_events.doLabeler(label));
    }

    let labels: string[];
    let handleUpdate: Delegate.Action;

    handler = isNullOrUndefined(handler) ? DoNothing : handler;
    handleUpdate = function () {
        handler(biodeep.UI_events.getCurrentDesigns());
    }

    for (let design of currentDesigns) {
        labels = design.group_info;
        designContainer.appendElement(biodeep.analysisDesignItem(labels, designContainer, handleUpdate));
    }    
}


