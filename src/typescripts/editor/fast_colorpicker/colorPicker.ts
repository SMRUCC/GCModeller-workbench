namespace uikit.colorPicker {

    let instances: {} = {};

    export class colorPickerUI {

        /**
         * the selected color displayer
        */
        private display: IHTMLElement;
        private pickerMenu: IHTMLElement;
        private container: IHTMLElement;
        private setColor: Delegate.Sub = DoNothing;

        public color: string;

        public constructor(public id: string, defaultColor: string = "#000000") {
            let rect = $ts(id).getBoundingClientRect();
            let vm = this;

            defaultColor = "#" + defaultColor.replace(/[#]+/g, "");
            defaultColor = defaultColor.toLowerCase();

            this.display = this.createColorItem(defaultColor, false);
            this.display.style.border = "2px solid skyblue";
            this.color = defaultColor;

            this.container = $ts("<div>", { style: "display: none;" });
            this.pickerMenu = $ts("<div>", {
                class: selectpicker,
                style: `left: ${rect.left}px; top: ${rect.top}px;`,
                onclick: function () {
                    vm.display.style.zIndex = "999";
                    vm.hideOthers();
                },
                onblur: function () {
                    vm.hideThis();
                },
                onfocusout: function () {
                    vm.hideThis();
                }
            }).display(this.display)
                .appendElement(this.container);

            $ts(id).display(this.pickerMenu);

            instances[id] = this;
        }

        public hookSetColor(action: Delegate.Sub): colorPickerUI {
            this.setColor = action;
            return this;
        }

        private hideOthers() {
            let container = this.container;
            let ui: colorPickerUI = this;

            if (container.style.display == "none") {
                container.style.display = "block";
            } else {
                container.style.display = "none";
            }

            for (let id in instances) {
                if (id != this.id) {
                    ui = <colorPickerUI>instances[id];

                    container = ui.container;
                    container.style.display = "none";
                    ui.display.style.zIndex = "0";
                    ui.container.style.zIndex = "0";
                    ui.pickerMenu.style.zIndex = "0";
                }
            }
        }

        private hideThis() {
            if (this.container.style.display == "block") {
                this.container.style.display = "none";
            }
        }

        private createColorItem(color: string, hookEvt: boolean = true) {
            let vm = this;

            return this.createDisplayComponents($ts("<div>", {
                onclick: function () {
                    if (hookEvt) {
                        vm.setDisplayColor(color);
                    }

                    colorPickerUI.hideAll();
                },
                class: "color-item"
            }), color);
        }

        public setDisplayColor(color: string) {
            this.setColor(color);
            // set display color
            this.createDisplayComponents(this.display, color);
            this.color = color;
        }

        private static hideAll() {
            for (let id in instances) {
                (<colorPickerUI>instances[id]).display.style.zIndex = "10";
                (<colorPickerUI>instances[id]).container.style.zIndex = "10";
                (<colorPickerUI>instances[id]).pickerMenu.style.zIndex = "10";
            }
        }

        private createDisplayComponents(div: IHTMLElement, color: string) {
            return div
                .clear()
                .appendElement("&nbsp;&nbsp;")
                .appendElement($ts("<span>", {
                    style: `background-color: ${color};`
                }).display("&nbsp;&nbsp;&nbsp;&nbsp;"))
                .appendElement("&nbsp;&nbsp;")
                .appendElement($ts("<span>", {
                    class: "color-text"
                }).display(color));
        }

        public addOptions(colors: string[]): colorPickerUI {
            for (let color of colors) {
                this.container.appendElement(this.createColorItem(color.toLowerCase()));
            }

            return this;
        }

        public tryHandleMoreColors(handler: Delegate.Action): colorPickerUI {
            if (!isNullOrUndefined(handler)) {
                let item = this.createColorItem("#000000");

                item.getElementsByClassName("color-text").item(0).innerHTML = "选择更多颜色...";
                item.onclick = function () {
                    handler();
                }

                this.container.appendElement(item);
            }

            return this;
        }
    }
}