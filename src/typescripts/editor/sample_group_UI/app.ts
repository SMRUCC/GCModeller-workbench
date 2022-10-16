/// <reference path="../../../build/linq.d.ts" />

$ts(function () {
    // initialize the web app style
    biodeep.ui.doStyle();
    biodeep.createInputModal(biodeep.sampleInfoId, "设置分组名称", "请在这里输入样本分组名称");
    biodeep.createInputModal(biodeep.batchInfoId, "设置实验批次", "请在这里输入实验批次编号");
    biodeep.createInputModal(biodeep.sample1Id, "设置亚型分类A", "请在这里输入亚型分类编号");
    biodeep.createInputModal(biodeep.sample2Id, "设置亚型分类B", "请在这里输入亚型分类编号");
});

interface sampleInfoTableBuilder { (model: biodeep.IsampleInfo[]): HTMLElement; }