namespace biodeep {

    export const sampleInfoId: string = "input-sampleinfo";
    export const batchInfoId: string = "input-batchinfo";
    export const sample1Id: string = "input-sample1";
    export const sample2Id: string = "input-sample2";

    /**
     * UI class for create sample group information
    */
    export class sampleInfoUI {

        private tableTitles: string[];

        public get model(): IsampleInfo[] {
            let vm = this;

            return $ts(this.trs)
                .Select(function (tr) {
                    let sample: IsampleInfo = <IsampleInfo>{};
                    let cells = tr.getElementsByTagName("td");

                    for (let title of vm.tableTitles) {
                        if (!Strings.Empty(title, true)) {
                            sample[title] = cells.item(vm.tableTitles.indexOf(title)).innerText;
                        }
                    }

                    return sample;
                }).ToArray(false);
        }

        public get csv(): string {
            let table: IsampleInfo[] = this.model;
            let text: string = biodeep.as_tabular(table);

            return text;
        }

        public get hasRowSelected(): boolean {
            for (var i = 0; i < this.trs.length; i++) {
                if (this.trs[i].classList.contains('selected')) {
                    return true;
                }
            }

            return false;
        }

        /**
         * @param builder 这个参数是用于兼容tableEditor模块的
         * @param getHeaders 设置这个参数一般是因为表头是被翻译过了的
        */
        public constructor(public container: string, sampleNames: string[] | IsampleInfo[], builder: sampleInfoTableBuilder, getHeaders: Delegate.Func<string[]> = null) {
            let raw: IsampleInfo[] = biodeep.ensureSampleInfoModel(sampleNames);

            if (isNullOrUndefined(builder)) {
                builder = sampleInfoUI.createSampleInfotable;
            }

            $ts(container).clear();
            $ts(container).appendElement(sampleInfoUI.createContextMenu());
            $ts(container).appendElement(builder(raw));

            this.init(getHeaders);
            this.exitEditMode();
        }

        private lastSelectedRow: HTMLTableRowElement;
        private trs: HTMLCollectionOf<HTMLTableRowElement>;

        public editMode: boolean = false;

        /**
         * hook events
        */
        private init(getHeaders: Delegate.Func<string[]>) {
            let vm = this;

            // disable text selection
            document.onselectstart = function () {
                return !vm.editMode;
            }

            this.trs = (<HTMLTableElement>$ts("#sampleinfo").any)
                .tBodies[0]
                .getElementsByTagName("tr");

            if (isNullOrUndefined(getHeaders)) {
                this.tableTitles = $ts(
                    (<HTMLTableElement>$ts("#sampleinfo").any)
                        .tHead
                        .getElementsByTagName("th")
                )
                    .Select(th => th.innerText)
                    .ToArray(false);
            } else {
                this.tableTitles = getHeaders();
            }

            $ts(this.trs).ForEach(tr => tr.onmousedown = function () {
                vm.RowClick(tr, false);
                vm.editMode = true;
            })

            this.registerContextMenu();
        }

        private displayMenu(a: Event): boolean {
            let menuBox: HTMLElement = window.document.querySelector(".menu");

            if (this.editMode) {
                let left = arguments[0].clientX;
                let top = arguments[0].clientY;
                let active: boolean = this.hasRowSelected;

                menuBox.style.left = left + "px";
                menuBox.style.top = top + "px";
                menuBox.style.display = "block";

                $ts("#add-group").interactive(active);
                $ts("#add-batch").interactive(active);
                $ts("#add-sample1").interactive(active);
                $ts("#add-sample2").interactive(active);

                a.preventDefault();

                return true;
            } else {
                return false;
            }
        }

        private registerContextMenu() {
            let menuDisplayed = false;
            let menuBox: HTMLElement = window.document.querySelector(".menu");
            let vm = this;

            window.addEventListener("contextmenu", a => menuDisplayed = this.displayMenu(a), false);
            window.addEventListener("click", function () {
                if (menuDisplayed == true) {
                    menuBox.style.display = "none";
                }
            }, true);

            $ts("#add-group").onclick = function () {
                vm.buildSampleInfo(`#${sampleInfoId}`);
            }
            $ts("#add-batch").onclick = function () {
                vm.buildSampleInfo(`#${batchInfoId}`);
            }

            $ts("#add-sample1").onclick = function () {
                vm.buildSampleInfo(`#${sample1Id}`);
            }

            $ts("#add-sample2").onclick = function () {
                vm.buildSampleInfo(`#${sample2Id}`);
            }

            $ts("#exit-edit-mode").onclick = function () {
                vm.exitEditMode();
            }
        }

        private exitEditMode() {
            for (let i = 0; i < this.trs.length; i++) {
                this.trs.item(i).classList.remove("selected");
            }

            this.editMode = false;
        }

        private buildSampleInfo(id: string) {
            let selects = $ts.select(".selected");
            let vm = this;

            $(id).modal();
            $input(`#sample-${sampleInfoId}`).value = null;
            $input(`#sample-${batchInfoId}`).value = null;
            $input(`#sample-${sample1Id}`).value = null;
            $input(`#sample-${sample2Id}`).value = null;
            $ts.select(".group_checked").ForEach(a => a.onclick = vm.hookDataUpdates(selects, a.getAttribute("field")));
        }

        private hookDataUpdates(selects: DOMEnumerator<HTMLElement>, field: string) {
            let vm = this;

            return function () {
                let name: string = $ts.value(`#sample-${sampleInfoId}`);
                let batch: string = $ts.value(`#sample-${batchInfoId}`);
                let sample1: string = $ts.value(`#sample-${sample1Id}`);
                let sample2: string = $ts.value(`#sample-${sample2Id}`);
                let index: number

                // 20200605 在这里允许空字符串
                // 空字符串表示进行批量信息删除
                if (field == sampleInfoId) {
                    index = vm.tableTitles.indexOf("sample_info");

                    for (let tr of selects.ToArray(false)) {
                        tr.getElementsByTagName("td").item(index).innerText = name;
                    }
                } else if (field == sample1Id) {
                    index = vm.tableTitles.indexOf("sample_info1");

                    for (let tr of selects.ToArray(false)) {
                        tr.getElementsByTagName("td").item(index).innerText = sample1;
                    }
                } else if (field == sample2Id) {
                    index = vm.tableTitles.indexOf("sample_info2");

                    for (let tr of selects.ToArray(false)) {
                        tr.getElementsByTagName("td").item(index).innerText = sample2;
                    }
                } else if (field == batchInfoId) {
                    index = vm.tableTitles.indexOf("batch");

                    if (!Strings.Empty(batch, true) && !Strings.isIntegerPattern(batch)) {
                        return alert("批次编号应该是一个任意整型数字符串！");
                    }

                    for (let tr of selects.ToArray(false)) {
                        tr.getElementsByTagName("td").item(index).innerText = batch;
                    }
                } else {
                    console.warn(`invalid tag string: ${field}!`);
                }

                vm.exitEditMode();
            }
        }

        RowClick(currenttr: HTMLTableRowElement, lock: boolean) {
            if ((<any>window.event).ctrlKey) {
                this.toggleRow(currenttr);
            }

            if ((<any>window.event).button === 0) {
                if (!(<any>window.event).ctrlKey && !(<any>window.event).shiftKey) {
                    this.clearAll();
                    this.toggleRow(currenttr);
                }

                if ((<any>window.event).shiftKey) {
                    this.selectRowsBetweenIndexes([this.lastSelectedRow.rowIndex, currenttr.rowIndex])
                }
            }
        }

        toggleRow(row: HTMLTableRowElement) {
            if (row.classList.contains("selected")) {
                row.classList.remove('selected');
            } else {
                row.classList.add('selected');
            }

            this.lastSelectedRow = row;
        }

        selectRowsBetweenIndexes(indexes: number[]) {
            let tr: HTMLTableRowElement

            indexes.sort(function (a, b) {
                return a - b;
            });

            for (var i = indexes[0] - 1; i < indexes[1]; i++) {
                tr = this.trs[i];

                if (!isNullOrUndefined(tr)) {
                    tr.classList.add('selected');
                }
            }
        }

        clearAll() {
            for (var i = 0; i < this.trs.length; i++) {
                this.trs[i].classList.remove('selected');
            }
        }

        /**
         * default method for create html table
        */
        private static createSampleInfotable(model: biodeep.IsampleInfo[]): HTMLElement {
            return $ts.evalHTML.table(model, null, { id: "sampleinfo", class: ["sampleinfo", "table"] });
        }

        private static createContextMenu(): HTMLElement {
            let div = $ts("<div>", { id: "context", class: "menu" });

            div.hide();
            div.appendElement($ts("<div>", { class: "menu-item", id: "add-group" }).display("批量编辑样本分组"));
            div.appendElement($ts("<div>", { class: "menu-item", id: "add-batch" }).display("批量编辑实验批次"));
            div.appendElement($ts("<div>", { class: "menu-item", id: "add-sample1" }).display("编辑亚型分类A"));
            div.appendElement($ts("<div>", { class: "menu-item", id: "add-sample2" }).display("编辑亚型分类B"));
            div.appendElement($ts("<hr>", { style: "margin-top: 5px; margin-bottom: 5px;" }));
            div.appendElement($ts("<div>", { class: "menu-item", id: "exit-edit-mode" }).display("退出编辑模式"));

            return div;
        }
    }
}

