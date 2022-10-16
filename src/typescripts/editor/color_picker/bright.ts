namespace uikit.color_picker.view {

    const w3color = TypeScript.ColorManager.w3color;

    /**
     * 生成亮度调整选择的表格
    */
    export function hslLum_top(color: string, evt: colorMapEvent): HTMLElement {
        var hslObj = new w3color(color);
        var h = hslObj.hue;
        var s = hslObj.sat;
        var lightness = Math.round(hslObj.lightness * 100);
        var levels: TypeScript.ColorManager.w3color[] = [];

        let div = $ts("<div>");

        for (let i = 0; i <= 20; i++) {
            levels.push(new w3color("hsl(" + h + "," + s + "," + (i * 0.05) + ")"));
        }

        levels.reverse();

        let table = $ts("<table>", { class: "colorTable", style: "width:100%;" });
        let match: boolean = false;
        let clickColor: clickColor = function (color: string) {
            evt.clickColor(color);
        }

        div.append($ts("<h3>").display("Lighter / Darker:"));
        div.append(table);

        for (let brightnessColor of levels) {
            match = rowBuilder(table, brightnessColor, match, hslObj, lightness, clickColor);
        }

        return div;
    }

    interface clickColor { (color: string): void; }

    function rowBuilder(
        table: IHTMLElement,
        color: TypeScript.ColorManager.w3color,
        match: boolean,
        hslObj: TypeScript.ColorManager.w3color,
        lightness: number,
        clickColor: clickColor): boolean {

        let tr: IHTMLElement;

        if ((!match) && lightness == Math.round(color.lightness * 100)) {
            tr = $ts("<tr>");

            tr.append($ts("<td>", { style: "text-align: right;" }).display(`<b>${lightness}%&nbsp;</b>`));
            tr.append($ts("<td>", { style: `background-color: ${new w3color(hslObj).toHexString()};` }).display(`<br><br>`))
            tr.append($ts("<td>").display(`&nbsp;<b>${new w3color(hslObj).toHexString()}</b>`));

            table.append($ts("<tr>").display("<td></td><td></td><td></td>"));
            table.append(tr);
            table.append($ts("<tr>").display("<td></td><td></td><td></td>"));

            match = true;
        } else {
            if ((!match) && (lightness > color.lightness)) {
                tr = $ts("<tr>");

                tr.append($ts("<td>", { style: "text-align: right;" }).display(`<b>${lightness}%&nbsp;</b>`));
                tr.append($ts("<td>", { style: `background-color: ${new w3color(hslObj).toHexString()};` }));
                tr.append($ts("<td>").display(`&nbsp;<b>${new w3color(hslObj).toHexString()}</b>`));

                table.append($ts("<tr>").display("<td></td><td></td><td></td>"));
                table.append(tr);
                table.append($ts("<tr>").display("<td></td><td></td><td></td>"));

                match = true;
            }

            tr = $ts("<tr>");

            tr.append($ts("<td>", {
                style: `width: 40px; text-align: right;`
            }).display(`${Math.round(color.lightness * 100)}%&nbsp;`));
            tr.append($ts("<td>", {
                style: `cursor: pointer;background-color: ${color.toHexString()}`,
                onclick: function () {
                    clickColor(color.toHexString());
                }
            }))
            tr.append($ts("<td>", {
                style: <any>{
                    width: "80px"
                }
            }).display(`&nbsp;${color.toHexString()}`));

            table.append(tr);
        }

        return match;
    }

    export function hslTable(color: string, x: "hue" | "sat" | "light") {
        var lineno, header, i, a, match, same, comp, loopHSL, HSL;
        var hslObj = new w3color(color);
        var h = hslObj.hue;
        var s = hslObj.sat;
        var l = hslObj.lightness;
        var arr = [];
        if (x == "hue") { header = "Hue"; lineno = 24; }
        if (x == "sat") { header = "Saturation"; lineno = 20; }
        if (x == "light") { header = "Lightness"; lineno = 20; }
        for (i = 0; i <= lineno; i++) {
            if (x == "hue") { arr.push(new w3color("hsl(" + (i * 15) + "," + s + "," + l + ")")); }
            if (x == "sat") { arr.push(new w3color("hsl(" + h + "," + (i * 0.05) + "," + l + ")")); }
            if (x == "light") { arr.push(new w3color("hsl(" + h + "," + s + "," + (i * 0.05) + ")")); }
        }
        if (x == "sat" || x == "light") { arr.reverse(); }
        a = "<h3>" + header + "</h3>";
        a += "<div class='w3-responsive'>";
        a += "<table class='w3-table-all colorTable' style='width:100%;white-space: nowrap;font-size:14px;'>";
        a += "<tr>";
        a += "<td style='width:150px;'></td>";
        a += "<td style='text-align:right;text-transform:capitalize;'>" + x + "&nbsp;</td>";
        a += "<td>Hex</td>";
        a += "<td>Rgb</td>";
        a += "<td>Hsl</td>";
        a += "</tr>";
        match = 0;
        for (i = 0; i < arr.length; i++) {
            same = 0;
            if (x == "hue") {
                loopHSL = new w3color(arr[i]).hue;
                HSL = h;
                if (i == arr.length - 1) { loopHSL = 360; }
                comp = (loopHSL > HSL);
            }
            if (x == "sat") {
                loopHSL = Math.round(new w3color(arr[i]).sat * 100);
                HSL = Number(s * 100);
                HSL = Math.round(HSL);
                comp = (loopHSL < HSL);
                HSL = HSL + "%";
                loopHSL = loopHSL + "%";
            }
            if (x == "light") {
                loopHSL = Math.round(new w3color(arr[i]).lightness * 100);
                HSL = Number(l * 100);
                HSL = Math.round(HSL);
                comp = (loopHSL < HSL);
                HSL = HSL + "%";
                loopHSL = loopHSL + "%";
            }
            if (HSL == loopHSL) {
                match++;
                same = 1;
            }
            if (comp) { match++; }
            if (match == 1) {
                a += "<tr class='w3-green'>";
                a += "<td style='background-color:" + hslObj.toHexString() + "'></td>";
                a += "<td style='text-align:right;'><b>" + HSL + "&nbsp;</b></td>";
                a += "<td><b>" + hslObj.toHexString() + "</b></td>";
                a += "<td><b>" + hslObj.toRgbString() + "</b></td>";
                a += "<td><b>" + hslObj.toHslString() + "</b></td>";
                a += "</tr>";
                match = 2;
            }
            if (same == 0) {
                a += "<tr>";
                a += "<td style='cursor:pointer;background-color:" + arr[i].toHexString() + "' onclick='clickColor(\"" + arr[i].toHexString() + "\")'></td>";
                a += "<td style='text-align:right;'>" + loopHSL + "&nbsp;</td>";
                a += "<td>" + arr[i].toHexString() + "</td>";
                a += "<td>" + arr[i].toRgbString() + "</td>";
                a += "<td>" + arr[i].toHslString() + "</td>";
                a += "</tr>";
            }
        }
        a += "</table></div>";

        return a;
    }
}