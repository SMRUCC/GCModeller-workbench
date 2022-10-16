namespace sampleinfo_editor {

    /**
     * 预设的颜色
    */
    export const colors: string[] = [
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
    export const shapes: {} = {
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

    export let colorPickers: {} = {};
    export let instance: metaEditor;

    export function shapeSetter(label: string, _default: string, setValue: Delegate.Sub) {
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

    export function colorSetter(label: string, _default: string, setValue: Delegate.Sub) {
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

    export let currentSampleinfo: string = "n/a";

    export function setColorValue(color: TypeScript.ColorManager.w3color) {
        let colorStr: string = color.toHexString();

        //current.style.backgroundColor = colorStr;
        //current.value = colorStr;
        //currentSetVal(currentLabel, colorStr.substr(1));
        //currentMoreOpt.style.backgroundColor = colorStr;
        //currentMoreOpt.innerHTML = colorStr + " [重新选择颜色]";

        (<colorPicker.colorPickerUI>colorPickers[currentSampleinfo]).setDisplayColor(colorStr);
        instance.setColor(currentSampleinfo)(colorStr);

        console.log(colorStr);
    }

    export function setMoreColors() {
        console.log("设置更多的颜色");

        $ts("#colorBox").show()
        $ts("#pca2d-settings-panel").show();
    }
}