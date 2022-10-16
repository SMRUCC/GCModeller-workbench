namespace uikit.table_editor {

    export class tableEditor {

        private tbody: HTMLElement;
        private rows: editor[];

        /**
         * 只可以同时编辑一行数据，会利用这个开关来锁住再编辑的时候添加新的行数据或者编辑其他的行数据
        */
        public edit_lock: boolean;

        public table: HTMLTableElement;
        public fieldHeaders: string[];

        /**
         * 行号(如果第一列是唯一的数字id，则可以调用这个属性来获取最后一行的id作为id递增计算的基础)
        */
        public get keyIndex(): number {
            return $from(this.rows).Select(r => parseInt(r.tr.cells.item(0).innerText)).Max();
        };

        /**
         * 获取当前表格的行数
        */
        public get nrows(): number {
            let rows = this.tbody.getElementsByTagName("tr");

            if (isNullOrUndefined(rows)) {
                return 0;
            } else {
                return rows.length;
            }
        }

        /**
         * 这个构造函数将会创建一个新的table对象
         * 
         * @param id id value of a ``<div>`` tag. 
         * @param headers the object field names.
        */
        constructor(id: string, public headers: string[], public opts: editorConfig = defaultConfig()) {
            if (isNullOrUndefined(opts.showRowNumber)) {
                opts.showRowNumber = false;
            }

            if (opts.showRowNumber) {
                this.headers = ["NO."].concat(headers);
                this.fieldHeaders = [null].concat(headers);
            } else {
                this.fieldHeaders = [...headers];
            }

            if (isNullOrUndefined(opts.allowsAddNew)) {
                TypeScript.logging.warning(`editor config option [allowsAddNew] is missing, set to ${(opts.allowsAddNew = true)} by default!`);
            }

            this.rows = [];

            let thead = $ts("<thead>");
            let tbody = $ts("<tbody>");
            let table = $ts("<table>", {
                id: Strings.Empty(opts.table_id, true) ? `${id.replace(/[#]+/g, "")}-table` : opts.table_id,
                class: ["table"]
            }).appendElement(thead)
                .appendElement(tbody);

            if (!isNullOrUndefined(opts.clearContainer) && opts.clearContainer) {
                $ts(id).clear().appendElement(table);
            } else {
                $ts(id).appendElement(table);
            }

            if (!Strings.Empty(opts.style, true)) {
                table.setAttribute("style", opts.style);
            }
            if (!Strings.Empty(opts.className, true)) {
                table.className = opts.className;
            }

            let tr = $ts("<tr>");
            let addHeader = function (header: string, i: number) {
                let th = $ts("<th>").display(header);
                let config: columnConfig = contains(opts, i) ? <columnConfig>{ lockEditor: false } : opts.tdConfig[i];

                thead.appendChild(th);

                if (!Strings.Empty(config.width)) {
                    th.setAttribute("style", config.width);
                }
                if (!Strings.Empty(config.title)) {
                    th.display(config.title);
                }

                return th;
            }

            thead.appendChild(tr);

            let names = headers;

            if (isNullOrUndefined(opts.names) || Strings.Empty(opts.names.actions, true)) {
                names = names.concat(["actions"]);
            } else {
                names = headers.concat([opts.names.actions]);
            }

            for (let i = 0; i < names.length; i++) {
                let th = addHeader(names[i], i);

                if (i == names.length - 1) {
                    th.style.minWidth = "155px";
                }
            }

            this.table = <any>table;
            this.tbody = tbody;
        }

        public addNew(value: {} = null, hideInputs: boolean = false): editor {
            if (this.edit_lock || !this.opts.allowsAddNew) {
                if (!isNullOrUndefined(this.opts.warning)) {
                    this.opts.warning();
                }

                return null;
            } else {
                let row = this.addNewInternal(value, hideInputs);
                this.rows.push(row);
                return row;
            }
        }

        private addNewInternal(value: {}, hideInputs: boolean): editor {
            // 根据header的数量来生成对应的列
            let i = this.rows.length + 1;
            let displayRowNumber: boolean = this.opts.showRowNumber;
            let tr: HTMLTableRowElement = <any>$ts("<tr>", {
                id: `row-${i}`
            });
            let td: HTMLElement;
            let j: number = 0;

            for (let name of this.headers) {
                if (displayRowNumber) {
                    displayRowNumber = false;
                    td = $ts("<td>").display(i.toString());
                } else {
                    td = this.propertyValue(value, name, hideInputs, this.opts.tdConfig[j++]);
                }

                tr.appendChild(td);
            }

            this.tbody.appendChild(tr);
            this.edit_lock = true;

            return new editor(tr, this.tbody, this);
        }

        private propertyValue(value: any, name: string, hideInputs: boolean, config: columnConfig): HTMLElement {
            let td = $ts("<td>");
            let text = $ts("<div>", { id: "text", style: `display: ${hideInputs ? "block" : "none"}` });
            // <input id="input-symbol" type="text" style="width: 65%" class="form-control"></input>
            let input = $ts("<input>", {
                type: "text",
                style: `width: 85%; display: ${hideInputs ? "none" : "block"}`,
                class: ["form-control", `input-${name}`]
            });

            if (!isNullOrUndefined(value)) {
                let textVal: string = value[name];

                if (isNullOrUndefined(textVal)) {
                    textVal = "";
                }

                text.display(textVal);
                $input(input).value = textVal;
            }

            td.appendChild(input);
            td.appendChild(text);

            if ((!isNullOrUndefined(config)) && (!isNullOrUndefined(config.lockEditor)) && config.lockEditor) {
                input.hide();
                text.show();
            }

            return td;
        }

        /**
         * 将目标表格中的文本读取出来以进行后续的操作
        */
        public TableData<T extends {}>(keepsRowId: boolean = true): T[] {
            let table: T[] = [];
            let trList = this.tbody.getElementsByTagName("tr");

            for (let i = 0; i < trList.length; i++) {
                table.push(this.createObject(trList[i], keepsRowId));
            }

            return table;
        }

        public TableRows(): editor[] {
            return [...this.rows];
        }

        private createObject(tr: HTMLTableRowElement, keepsRowId: boolean): any {
            let tdList = tr.getElementsByTagName("td");
            let row: any = <any>{};
            let isRowId: boolean = this.opts.showRowNumber;

            for (var j = 0; j < tdList.length - 1; j++) {
                var td = tdList[j];
                var text: HTMLElement = td.getElementsByTagName("div")[0];

                if (isRowId) {
                    isRowId = false;

                    if (!keepsRowId) {
                        continue;
                    }
                }

                if (text) {
                    row[this.headers[j]] = text.innerText;
                } else {
                    row[this.headers[j]] = td.innerText;
                }
            }

            return row;
        }
    }
}