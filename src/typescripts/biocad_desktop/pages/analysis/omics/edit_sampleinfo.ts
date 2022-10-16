/// <reference path="../../../../build/sampleinfo_editor.d.ts" />

namespace pages.analysis_project {

    export class edit_sampleinfo extends Bootstrap {

        public get appName(): string {
            return "edit_sampleinfo";
        };

        protected init(): void {
            app.initSampleEditor();

            let vm = this;

            this.reset();

            $ts("#save").onclick = function () {
                vm.save(null);
            }
        }

        public reset() {
            let vm = this;

            parseSampleInfo(this.analysisFile, info => this.beginEditSampleInfo1(info), function () {
                // 首先尝试自动解析
                layer.confirm(`老师好，您目前还没有上传样本分组信息文件，是否需要进行自动解析？`, {
                    btn: ['确定', '取消']
                }, function () {
                    desktop.closeSpinner();
                    vm.beginEditSampleInfo0();
                }, function () {
                    $goto(`/analysis/file?analysis_file=${$ts("@analysis_file")}`);
                });
            });
        }

        private sampleEditor: sampleinfo_editor.ui.sampleInfoUI;

        private beginEditSampleInfo0() {
            let vm = this;

            $ts.get(`@api:xcms_id`, function (data: IMsg<string[]>) {
                if (data.code == 0) {
                    vm.beginEditSampleInfo($from(<string[]>data.info).Skip(1).ToArray(false));
                } else {
                    desktop.showToastMessage(<string>data.info, "Sample Editor", "danger");
                }
            });
        }

        private beginEditSampleInfo1(samples: sampleinfo_editor.IsampleInfo[]) {
            let vm = this;

            // 手动编辑sampleInfo
            vm.sampleEditor = new sampleinfo_editor.ui.sampleInfoUI(
                "#edit_sampleinfo",
                samples,
                data => this.xload_sampleInfo(data),
                function () {
                    return vm.editor.fieldHeaders;
                });
            // vm.rawSampleInfo = vm.sampleEditor.model;
            // vm.doResetSampleInfo();
        }

        private beginEditSampleInfo(sampleNames: string[]) {
            let vm = this;

            TypeScript.logging.log("all sample names from the raw matrix data:");
            TypeScript.logging.log(JSON.stringify(sampleNames));

            // $(".illustrate").show();

            // 手动编辑sampleInfo
            vm.sampleEditor = new sampleinfo_editor.ui.sampleInfoUI(
                "#edit_sampleinfo",
                sampleNames,
                data => this.xload_sampleInfo(data),
                function () {
                    return vm.editor.fieldHeaders;
                });
            // vm.rawSampleInfo = vm.sampleEditor.model;
            // vm.doResetSampleInfo();
        }

        private editor: sampleinfo_editor.table_editor.tableEditor;
        private sampleInfo: {};

        private save(success: Delegate.Action) {
            desktop.loading("Save your sample information, wait for a while...");

            let i = 0;
            let rows = this.editor.TableRows();

            for (let row of this.editor.TableData<sampleinfo_editor.IsampleInfo>(false)) {
                this.sampleInfo[row.ID].injectionOrder = row.injectionOrder;
                this.sampleInfo[row.ID].batch = row.batch;
                this.sampleInfo[row.ID].sample_info = row.sample_info;
                this.sampleInfo[row.ID].sample_info1 = row.sample_info1;
                this.sampleInfo[row.ID].sample_info2 = row.sample_info2;
                this.sampleInfo[row.ID].sample_name = row.sample_name;

                if (rows[i++].dropFlag) {
                    this.sampleInfo[row.ID].delete = "1";
                } else {
                    this.sampleInfo[row.ID].delete = "0";
                }
            }

            let vec: sampleinfo_editor.IsampleInfo[] = [];

            for (let id in this.sampleInfo) {
                vec.push(this.sampleInfo[id]);
            }

            saveSampleInfo(vec, this.analysisFile, success);
        }

        private xload_sampleInfo(sampleInfo: sampleinfo_editor.IsampleInfo[]): HTMLElement {
            let hasFormatBug: boolean = false;

            for (let sample of sampleInfo) {
                // 这一列如果不存在的话，则默认都保留
                // 即设置为零
                // 否则会在下面都会被设置为删除状态
                if (Strings.Empty(sample.delete, true)) {
                    sample.delete = "0";
                } else if (sample.delete == "undefined") {
                    sample.delete = "0";
                }

                if (Strings.Empty(`${sample.injectionOrder}`, true)) {
                    sample.injectionOrder = 0;
                }

                if (Strings.Empty(`${sample.batch}`, true)) {
                    sample.batch = 0;
                }

                if ("sample_ID" in <any>sample) {
                    sample.ID = (<any>sample)["sample_ID"];
                    hasFormatBug = true;

                    delete (<any>sample).sample_ID;
                } else if (Strings.Empty(sample.ID, true) && "" in <any>sample) {
                    sample.ID = (<any>sample)[""];
                    hasFormatBug = true;

                    delete (<any>sample)[""];
                }
            }

            if (hasFormatBug) {
                const message = "We found some format error in your sampleinfo table file, please click on the [Save] button for fix this probem!";

                desktop.showToastMessage(message, "SampleInfo Editor", "warning");
            }

            this.sampleInfo = {};
            this.editor = sampleinfo_editor.table_editor.fromData(sampleInfo, "#edit_sampleinfo", [
                "ID", "sample_name", "sample_info", "sample_info1", "sample_info2", "injectionOrder", "batch"
            ], <sampleinfo_editor.table_editor.editorConfig>{
                deleteRow: edit_sampleinfo.deleteSampleRow,
                className: "table",
                table_id: "sampleinfo",
                allowsAddNew: false,
                names: <sampleinfo_editor.table_editor.buttonNames>{
                    remove: "删除样本",
                    edit: "编辑样本",
                    OK: "确认",
                    cancel: "取消",
                    actions: "操作",
                },
                tdConfig: [
                    { title: "样本编号", lockEditor: true },
                    { title: "样本名称", lockEditor: false },
                    { title: "组别名称", lockEditor: false },
                    { title: "亚型分类A", lockEditor: false },
                    { title: "亚型分类B", lockEditor: false },
                    { title: "进样顺序", lockEditor: false },
                    { title: "进样批次", lockEditor: false }
                ]
            });

            let rows = this.editor.TableRows();
            let i = 0;
            let row: sampleinfo_editor.table_editor.editor;

            for (let sample of sampleInfo) {
                this.sampleInfo[sample.ID] = sample;

                row = rows[i++];

                if (sample.delete != "0") {
                    edit_sampleinfo.deleteSampleRow(row.tr, row);
                }
            }

            return this.editor.table;
        }

        private static deleteSampleRow(tr: HTMLTableRowElement, editor: sampleinfo_editor.table_editor.editor) {
            let id: string = tr.cells.item(0).innerText;

            if (editor.dropFlag) {
                // 恢复
                tr.style.backgroundColor = "white";
                editor.getElementById("remove").innerHTML = "删除样本";
            } else {
                // 删除
                tr.style.backgroundColor = "gray";
                editor.getElementById("remove").innerHTML = "恢复样本";
            }

            editor.dropFlag = !editor.dropFlag;
        }
    }
}