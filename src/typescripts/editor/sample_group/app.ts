namespace sampleinfo_editor {

    export function init0_groupUI() {
        // initialize the web app style
        ui.doStyle();

        ui.createInputModal(ui.sampleInfoId, "设置分组名称", "请在这里输入样本分组名称");
        ui.createInputModal(ui.batchInfoId, "设置实验批次", "请在这里输入实验批次编号");
        ui.createInputModal(ui.sample1Id, "设置亚型分类A", "请在这里输入亚型分类编号");
        ui.createInputModal(ui.sample2Id, "设置亚型分类B", "请在这里输入亚型分类编号");
    }

    export interface sampleInfoTableBuilder { (model: IsampleInfo[]): HTMLElement; }

}