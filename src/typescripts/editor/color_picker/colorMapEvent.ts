namespace uikit.color_picker {

    export class colorMapEvent {

        public colorhex = "#FF0000";
        public color = "#FF0000";
        public colorObj = new TypeScript.ColorManager.w3color(this.color);
        public hh = 0;

        public constructor(private changeColor: useColor) {

        }

        mouseOverColor(hex: string) {
            $ts("#divpreview").show();
            $ts("#divpreview").style.backgroundColor = hex;
        }

        mouseOutMap() {
            if (this.hh == 0) {
                $ts("#divpreview").hide();
            } else {
                this.hh = 0;
            }

            $ts("#divpreview").style.backgroundColor = this.colorObj.toHexString();
        }

        clickColor(hex: number | string, seltop?: number, selleft?: number) {
            var c;

            if (hex == 0) {

            } else {
                c = hex;
            }

            let cObj = new TypeScript.ColorManager.w3color(c);

            this.colorhex = cObj.toHexString();
            this.colorObj = cObj;

            let r = cObj.red;
            let g = cObj.green;
            let b = cObj.blue;

            $ts("#colornamDIV").display(cObj.toName() || "");
            $ts("#colorhexDIV").css(`background-color: ${cObj.toHexString()};`, false).display(cObj.toHexString());
            $ts("#colorrgbDIV").display(cObj.toRgbString());
            $ts("#colorhslDIV").display(cObj.toHslString());

            if ((!seltop || seltop == -1) && (!selleft || selleft == -1)) {
                let colormap = $ts("#colormap");
                let areas = colormap.getElementsByTagName("AREA");
                let areacolor: string;
                let cc: string[];

                for (let i = 0; i < areas.length; i++) {
                    areacolor = areas[i].getAttribute("data-target");
                    cc = areacolor.split("|");
                    areacolor = cc[0];

                    if (areacolor.toLowerCase() == this.colorhex) {
                        cc = cc[1].split(",");
                        seltop = Number(cc[0]);
                        selleft = Number(cc[1]);

                        break;
                    }
                }
            }
            if ((seltop + 200) > -1 && selleft > -1) {
                $ts("#selectedhexagon").style.top = seltop + "px";
                $ts("#selectedhexagon").style.left = selleft + "px";
                $ts("#selectedhexagon").style.visibility = "visible";
            } else {
                $ts("#divpreview").style.backgroundColor = cObj.toHexString();
                $ts("#selectedhexagon").style.visibility = "hidden";
            }

            this.changeColor(this.colorObj);
        }
    }
}