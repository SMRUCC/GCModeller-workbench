/// <reference path="../../../uikit/build/uikit.colorPicker.d.ts" />

namespace biodeep {

    /**
     * 预设的颜色
    */
    const colors: string[] = [
        "#E41A1C",
        "#377EB8",
        "#4DAF4A",
        "#984EA3",
        "#FF7F00",
        "#FFFF33",
        "#A65628",
        "#F781BF",
        "#999999"
    ];
    const shapes: {} = {
        shape21: "●",
        shape22: "■",
        shape23: "◆",
        shape24: "▲",
        shape25: "▼",
        shape1: "○",
        shape0: "□",
        shape5: "◇",
        shape2: "△",
        shape6: "▽"
    };

    let colorPickers: {} = {};
    let instance: metaEditor;

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
            let colorPicker: uikit.colorPicker.colorPickerUI;

            for (let id of pickers) {
                let currentLabel = metaEditor.holdLabel(labels[id]);

                colorPicker = uikit.colorPicker.fast("#" + id, colors, this.setColor(labels[id]), defaultColors[id], function () {
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

    function shapeSetter(label: string, _default: string, setValue: Delegate.Sub) {
        let opt = $ts("<select>", {
            onchange: function () {
                let strVal: string = (<HTMLSelectElement><any>opt).value;

                strVal = strVal.match(/\d+/g)[0];
                setValue(label, strVal);
            }
        });
        let index = 0;
        let i = 0;

        _default = Strings.Empty(_default, true) ? "shape0" : ("shape" + _default);

        for (let name in shapes) {
            opt.appendElement($ts("<option>", { value: name }).display(shapes[name]));

            if (name == _default) {
                index = i;
            } else {
                ++i;
            }
        }

        let reset: Delegate.Action = function () {
            (<HTMLSelectElement><any>opt).selectedIndex = index;
        }

        reset();
        resetActions.push(reset);

        return opt;
    }

    let current: HTMLSelectElement;
    let currentSetVal: Delegate.Sub;
    let currentLabel: string;
    let currentMoreOpt: HTMLElement;

    function colorSetter(label: string, _default: string, setValue: Delegate.Sub) {
        // 选择更多颜色
        let setMore = function () {
            current = <any>opt;
            currentSetVal = setValue;
            currentLabel = label;
            currentMoreOpt = MoreOpt;

            setMoreColors();
        }
        let MoreOpt = $ts("<option>", {
            value: "more",
            style: "background-color: white;",
            onclick: setMore
        }).display("选择更多颜色...");

        let opt = $ts("<select>", {
            onchange: function () {
                let colorVal: string = (<HTMLSelectElement><any>opt).value;

                if (colorVal != "more") {
                    opt.style.backgroundColor = colorVal;
                    setValue(label, colorVal.substr(1));
                } else {
                    setMore();
                }
            },
            class: ["selectpicker", "form-control"]
        });

        let index = 0;
        let i = 0;

        _default = Strings.Empty(_default, true) ? "#ee3333" : ("#" + _default);
        _default = _default.toLowerCase();

        for (let color of colors) {
            opt.appendElement($ts("<option>", {
                value: color,
                "data-content": `<span style="background-color: ${color};">&nbsp;&nbsp;&nbsp;</span> ${color}`,
                style: `background-color: ${color};`
            }).display($ts("<div>").appendElement($ts("<span>", { style: `background-color: ${color};` }).display("&nbsp;&nbsp;&nbsp;")).appendElement($ts("<span>", { style: `background-color: white !important; color: black;` }).display(color))));

            if (color.toLowerCase() == _default) {
                index = i;
            } else {
                ++i;
            }
        }

        let reset: Delegate.Action = function () {
            (<HTMLSelectElement><any>opt).selectedIndex = index;
            opt.style.backgroundColor = _default;
        }

        reset();
        resetActions.push(reset);
        opt.appendElement(MoreOpt);

        return opt;
    }

    let resetActions: Delegate.Action[] = [];

    export function reset() {
        for (let action of resetActions) {
            action();
        }
    }

    let currentSampleinfo: string;

    export function setColorValue(color: TypeScript.ColorManager.w3color) {
        let colorStr: string = color.toHexString();

        //current.style.backgroundColor = colorStr;
        //current.value = colorStr;
        //currentSetVal(currentLabel, colorStr.substr(1));
        //currentMoreOpt.style.backgroundColor = colorStr;
        //currentMoreOpt.innerHTML = colorStr + " [重新选择颜色]";

        (<uikit.colorPicker.colorPickerUI>colorPickers[currentSampleinfo]).setDisplayColor(colorStr);
        instance.setColor(currentSampleinfo)(colorStr);

        console.log(colorStr);
    }

    function setMoreColors() {
        console.log("设置更多的颜色");

        $ts("#colorBox").show()
        $ts("#pca2d-settings-panel").show();
    }
}