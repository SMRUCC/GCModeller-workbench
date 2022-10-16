namespace sampleinfo_editor {

    export class metaEditor {

        public constructor(public sampleMeta: IsampleMeta[], div: string) {
            let table: IHTMLElement = $ts("<table>", { class: "table" });
            let header = $ts("<thead>").appendElement(
                $ts("<tr>")
                    .appendElement($ts("<th>").display("组别名称"))
                    .appendElement($ts("<th>").display("颜色"))
                    .appendElement($ts("<th>").display("形状"))
            );
            let body = $ts("<tbody>");
            let row: IHTMLElement;
            let pickers: string[] = [];
            let labels: {} = {};
            let defaultColors: {} = {};
            let metadata: {} = {};

            for (let meta of sampleMeta) {
                if (Strings.Empty(meta.color, true)) {
                    meta.color = "ee3333";
                }
                if (Strings.Empty(`${meta.shape}`, true)) {
                    meta.shape = 0;
                }

                let pickerId: string = `color-${meta.sampleInfo.replace(/\./g, "-")}`;

                row = $ts("<tr>");
                row.appendElement($ts("<td>").display(meta.sampleInfo));
                row.appendElement($ts("<td>", { id: pickerId }));
                // row.appendElement($ts("<td>").display(colorSetter(meta.sampleInfo, meta.color, <any>((label, value) => this.colorSetter(label, value)))));
                row.appendElement($ts("<td>").display(shapeSetter(meta.sampleInfo, <any>meta.shape, <any>((label, value) => this.shapeSetter(label, value)))));

                pickers.push(pickerId);
                labels[pickerId] = meta.sampleInfo;
                defaultColors[pickerId] = Strings.Empty(meta.color, true) ? "#ee3333" : ("#" + meta.color);
                metadata[pickerId] = meta;

                body.appendElement(row);
            }

            table.appendElement(header).appendElement(body);

            $ts(div)
                .clear()
                .appendElement(table);

            let color: string;
            let colorPicker: colorPicker.colorPickerUI;

            for (let id of pickers) {
                let currentLabel = metaEditor.holdLabel(labels[id]);

                colorPicker = sampleinfo_editor.colorPicker.fast("#" + id, colors, this.setColor(labels[id]), defaultColors[id], function () {
                    currentSampleinfo = currentLabel();
                    setMoreColors();
                });
                color = colorPicker.color;
                color = color.replace(/[#]+/g, "");

                colorPickers[labels[id]] = colorPicker;

                (<IsampleMeta>metadata[id]).color = color;
            }

            instance = this;
        }

        private static jqueryColorPickerUI(id: string, _default: string) {
            return $ts("<div>", {
                style: "width:128px;"
            }).display($ts("<input>", {
                style: "width:100px;",
                id: id,
                name: id,
                class: ["colorPicker", "evo-cp0"],
                placeholder: _default,
                value: _default
            }))
        }

        private static holdLabel(label: string) {
            return function (): string {
                return label;
            }
        }

        public setColor(label: string) {
            let vm = this;

            return function (color: string) {
                vm.colorSetter(label, color.substr(1));
            }
        }

        shapeSetter(label: string, value: string) {
            $from(this.sampleMeta).Where(a => a.sampleInfo == label).First.shape = <any>value;
        }

        colorSetter(label: string, value: string) {
            let sample = $from(this.sampleMeta).Where(a => a.sampleInfo == label).First;
            let colorModel = new TypeScript.ColorManager.w3color("#" + value);
            let a = new TypeScript.ColorManager.w3color(`rgb(${Math.round(colorModel.red / 2)}, ${Math.round(colorModel.green / 2)}, ${Math.round(colorModel.blue / 2)})`);
            let b = new TypeScript.ColorManager.w3color(`rgb(${255 - Math.round(colorModel.red / 2)}, ${255 - Math.round(colorModel.green / 2)}, ${255 - Math.round(colorModel.blue / 2)})`);

            sample.color = value;
            sample.color1 = a.toHexString().substr(1);
            sample.color2 = b.toHexString().substr(1);
        }
    }
}