namespace uikit.color_picker.view {

    export interface IpolyMap {
        coords: number[];
        color: string;
        offsets: number[];
    }

    export function createPolyMap(evt: colorMapEvent, container: string | IHTMLElement) {
        let map = $ts("<map>", { id: "colormap", name: "colormap" });
        let img = $ts("<img>", {
            style: "margin-right:2px;",
            src: colorMapBase64,
            usemap: "#colormap",
            alt: "colormap"
        });

        // <area style="cursor:pointer" 
        //       shape="poly"
        //       coords="63,0,72,4,72,15,63,19,54,15,54,4" 
        //       onclick="clickColor('#003366',-200,54)"
        //       onmouseover="mouseOverColor('#003366')" 
        //       alt="#003366">

        $from(poly)
            .Select(pdata => $ts("<area>", {
                style: "cursor:pointer",
                shape: "poly",
                coords: pdata.coords.join(","),
                alt: pdata.color,
                onclick: function () {
                    // ������ʾ���ȵ�������
                    $ts("#lumtopcontainer").show();
                    // $ts("#colorBtn").show();
                    evt.clickColor(pdata.color, pdata.offsets[0], pdata.offsets[1]);
                },
                onmouseover: function () {
                    evt.mouseOverColor(pdata.color);
                },
                "data-target": `${pdata.color}|${pdata.offsets.join(",")}`
            }))
            .ForEach(a => map.append(a));

        if (typeof container == "string") {
            container = $ts(container);
        }

        container.display(img).append(map);
        container.style.margin = "auto";
        container.style.width = "236px";
    }

    export const colorMapBase64: string = "data:image/gif;base64,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";

    export const poly: IpolyMap[] = [
        { coords: [63, 0, 72, 4, 72, 15, 63, 19, 54, 15, 54, 4], color: '#003366', offsets: [-200, 54] },
        { coords: [81, 0, 90, 4, 90, 15, 81, 19, 72, 15, 72, 4], color: '#336699', offsets: [-200, 72] },
        { coords: [99, 0, 108, 4, 108, 15, 99, 19, 90, 15, 90, 4], color: '#3366CC', offsets: [-200, 90] },
        { coords: [117, 0, 126, 4, 126, 15, 117, 19, 108, 15, 108, 4], color: '#003399', offsets: [-200, 108] },
        { coords: [135, 0, 144, 4, 144, 15, 135, 19, 126, 15, 126, 4], color: '#000099', offsets: [-200, 126] },
        { coords: [153, 0, 162, 4, 162, 15, 153, 19, 144, 15, 144, 4], color: '#0000CC', offsets: [-200, 144] },
        { coords: [171, 0, 180, 4, 180, 15, 171, 19, 162, 15, 162, 4], color: '#000066', offsets: [-200, 162] },
        { coords: [54, 15, 63, 19, 63, 30, 54, 34, 45, 30, 45, 19], color: '#006666', offsets: [-185, 45] },
        { coords: [72, 15, 81, 19, 81, 30, 72, 34, 63, 30, 63, 19], color: '#006699', offsets: [-185, 63] },
        { coords: [90, 15, 99, 19, 99, 30, 90, 34, 81, 30, 81, 19], color: '#0099CC', offsets: [-185, 81] },
        { coords: [108, 15, 117, 19, 117, 30, 108, 34, 99, 30, 99, 19], color: '#0066CC', offsets: [-185, 99] },
        { coords: [126, 15, 135, 19, 135, 30, 126, 34, 117, 30, 117, 19], color: '#0033CC', offsets: [-185, 117] },
        { coords: [144, 15, 153, 19, 153, 30, 144, 34, 135, 30, 135, 19], color: '#0000FF', offsets: [-185, 135] },
        {
            coords: [162, 15, 171, 19, 171, 30, 162, 34, 153, 30, 153, 19], color: '#3333FF', offsets: [-185, 153]
        }
        , {
            coords: [180, 15, 189, 19, 189, 30, 180, 34, 171, 30, 171, 19], color: '#333399', offsets: [-185, 171]
        }
        , {
            coords: [45, 30, 54, 34, 54, 45, 45, 49, 36, 45, 36, 34], color: '#669999', offsets: [-170, 36]
        }
        , {
            coords: [63, 30, 72, 34, 72, 45, 63, 49, 54, 45, 54, 34], color: '#009999', offsets: [-170, 54]
        }
        , {
            coords: [81, 30, 90, 34, 90, 45, 81, 49, 72, 45, 72, 34], color: '#33CCCC', offsets: [-170, 72]
        }
        , {
            coords: [99, 30, 108, 34, 108, 45, 99, 49, 90, 45, 90, 34], color: '#00CCFF', offsets: [-170, 90]
        }
        , {
            coords: [117, 30, 126, 34, 126, 45, 117, 49, 108, 45, 108, 34], color: '#0099FF', offsets: [-170, 108]
        }
        , {
            coords: [135, 30, 144, 34, 144, 45, 135, 49, 126, 45, 126, 34], color: '#0066FF', offsets: [-170, 126]
        }
        , {
            coords: [153, 30, 162, 34, 162, 45, 153, 49, 144, 45, 144, 34], color: '#3366FF', offsets: [-170, 144]
        }
        , {
            coords: [171, 30, 180, 34, 180, 45, 171, 49, 162, 45, 162, 34], color: '#3333CC', offsets: [-170, 162]
        }
        , {
            coords: [189, 30, 198, 34, 198, 45, 189, 49, 180, 45, 180, 34], color: '#666699', offsets: [-170, 180]
        }
        , {
            coords: [36, 45, 45, 49, 45, 60, 36, 64, 27, 60, 27, 49], color: '#339966', offsets: [-155, 27]
        }
        , {
            coords: [54, 45, 63, 49, 63, 60, 54, 64, 45, 60, 45, 49], color: '#00CC99', offsets: [-155, 45]
        }
        , {
            coords: [72, 45, 81, 49, 81, 60, 72, 64, 63, 60, 63, 49], color: '#00FFCC', offsets: [-155, 63]
        }
        , {
            coords: [90, 45, 99, 49, 99, 60, 90, 64, 81, 60, 81, 49], color: '#00FFFF', offsets: [-155, 81]
        }
        , {
            coords: [108, 45, 117, 49, 117, 60, 108, 64, 99, 60, 99, 49], color: '#33CCFF', offsets: [-155, 99]
        }
        , {
            coords: [126, 45, 135, 49, 135, 60, 126, 64, 117, 60, 117, 49], color: '#3399FF', offsets: [-155, 117]
        }
        , {
            coords: [144, 45, 153, 49, 153, 60, 144, 64, 135, 60, 135, 49], color: '#6699FF', offsets: [-155, 135]
        }
        , {
            coords: [162, 45, 171, 49, 171, 60, 162, 64, 153, 60, 153, 49], color: '#6666FF', offsets: [-155, 153]
        }
        , {
            coords: [180, 45, 189, 49, 189, 60, 180, 64, 171, 60, 171, 49], color: '#6600FF', offsets: [-155, 171]
        }
        , {
            coords: [198, 45, 207, 49, 207, 60, 198, 64, 189, 60, 189, 49], color: '#6600CC', offsets: [-155, 189]
        }
        , {
            coords: [27, 60, 36, 64, 36, 75, 27, 79, 18, 75, 18, 64], color: '#339933', offsets: [-140, 18]
        }
        , {
            coords: [45, 60, 54, 64, 54, 75, 45, 79, 36, 75, 36, 64], color: '#00CC66', offsets: [-140, 36]
        }
        , {
            coords: [63, 60, 72, 64, 72, 75, 63, 79, 54, 75, 54, 64], color: '#00FF99', offsets: [-140, 54]
        }
        , {
            coords: [81, 60, 90, 64, 90, 75, 81, 79, 72, 75, 72, 64], color: '#66FFCC', offsets: [-140, 72]
        }
        , {
            coords: [99, 60, 108, 64, 108, 75, 99, 79, 90, 75, 90, 64], color: '#66FFFF', offsets: [-140, 90]
        }
        , {
            coords: [117, 60, 126, 64, 126, 75, 117, 79, 108, 75, 108, 64], color: '#66CCFF', offsets: [-140, 108]
        }
        , {
            coords: [135, 60, 144, 64, 144, 75, 135, 79, 126, 75, 126, 64], color: '#99CCFF', offsets: [-140, 126]
        }
        , {
            coords: [153, 60, 162, 64, 162, 75, 153, 79, 144, 75, 144, 64], color: '#9999FF', offsets: [-140, 144]
        }
        , {
            coords: [171, 60, 180, 64, 180, 75, 171, 79, 162, 75, 162, 64], color: '#9966FF', offsets: [-140, 162]
        }
        , {
            coords: [189, 60, 198, 64, 198, 75, 189, 79, 180, 75, 180, 64], color: '#9933FF', offsets: [-140, 180]
        }
        , {
            coords: [207, 60, 216, 64, 216, 75, 207, 79, 198, 75, 198, 64], color: '#9900FF', offsets: [-140, 198]
        }
        , {
            coords: [18, 75, 27, 79, 27, 90, 18, 94, 9, 90, 9, 79], color: '#006600', offsets: [-125, 9]
        }
        , {
            coords: [36, 75, 45, 79, 45, 90, 36, 94, 27, 90, 27, 79], color: '#00CC00', offsets: [-125, 27]
        }
        , {
            coords: [54, 75, 63, 79, 63, 90, 54, 94, 45, 90, 45, 79], color: '#00FF00', offsets: [-125, 45]
        }
        , {
            coords: [72, 75, 81, 79, 81, 90, 72, 94, 63, 90, 63, 79], color: '#66FF99', offsets: [-125, 63]
        }
        , {
            coords: [90, 75, 99, 79, 99, 90, 90, 94, 81, 90, 81, 79], color: '#99FFCC', offsets: [-125, 81]
        }
        , {
            coords: [108, 75, 117, 79, 117, 90, 108, 94, 99, 90, 99, 79], color: '#CCFFFF', offsets: [-125, 99]
        }
        , {
            coords: [126, 75, 135, 79, 135, 90, 126, 94, 117, 90, 117, 79], color: '#CCCCFF', offsets: [-125, 117]
        }
        , {
            coords: [144, 75, 153, 79, 153, 90, 144, 94, 135, 90, 135, 79], color: '#CC99FF', offsets: [-125, 135]
        }
        , {
            coords: [162, 75, 171, 79, 171, 90, 162, 94, 153, 90, 153, 79], color: '#CC66FF', offsets: [-125, 153]
        }
        , {
            coords: [180, 75, 189, 79, 189, 90, 180, 94, 171, 90, 171, 79], color: '#CC33FF', offsets: [-125, 171]
        }
        , {
            coords: [198, 75, 207, 79, 207, 90, 198, 94, 189, 90, 189, 79], color: '#CC00FF', offsets: [-125, 189]
        }
        , {
            coords: [216, 75, 225, 79, 225, 90, 216, 94, 207, 90, 207, 79], color: '#9900CC', offsets: [-125, 207]
        }
        , {
            coords: [9, 90, 18, 94, 18, 105, 9, 109, 0, 105, 0, 94], color: '#003300', offsets: [-110, 0]
        }
        , {
            coords: [27, 90, 36, 94, 36, 105, 27, 109, 18, 105, 18, 94], color: '#009933', offsets: [-110, 18]
        }
        , {
            coords: [45, 90, 54, 94, 54, 105, 45, 109, 36, 105, 36, 94], color: '#33CC33', offsets: [-110, 36]
        }
        , {
            coords: [63, 90, 72, 94, 72, 105, 63, 109, 54, 105, 54, 94], color: '#66FF66', offsets: [-110, 54]
        }
        , {
            coords: [81, 90, 90, 94, 90, 105, 81, 109, 72, 105, 72, 94], color: '#99FF99', offsets: [-110, 72]
        }
        , {
            coords: [99, 90, 108, 94, 108, 105, 99, 109, 90, 105, 90, 94], color: '#CCFFCC', offsets: [-110, 90]
        }
        , {
            coords: [117, 90, 126, 94, 126, 105, 117, 109, 108, 105, 108, 94], color: '#FFFFFF', offsets: [-110, 108]
        }
        , {
            coords: [135, 90, 144, 94, 144, 105, 135, 109, 126, 105, 126, 94], color: '#FFCCFF', offsets: [-110, 126]
        }
        , {
            coords: [153, 90, 162, 94, 162, 105, 153, 109, 144, 105, 144, 94], color: '#FF99FF', offsets: [-110, 144]
        }
        , {
            coords: [171, 90, 180, 94, 180, 105, 171, 109, 162, 105, 162, 94], color: '#FF66FF', offsets: [-110, 162]
        }
        , {
            coords: [189, 90, 198, 94, 198, 105, 189, 109, 180, 105, 180, 94], color: '#FF00FF', offsets: [-110, 180]
        }
        , {
            coords: [207, 90, 216, 94, 216, 105, 207, 109, 198, 105, 198, 94], color: '#CC00CC', offsets: [-110, 198]
        }
        , {
            coords: [225, 90, 234, 94, 234, 105, 225, 109, 216, 105, 216, 94], color: '#660066', offsets: [-110, 216]
        }, {
            coords: [18, 105, 27, 109, 27, 120, 18, 124, 9, 120, 9, 109], color: '#336600', offsets: [-95, 9]
        }, {
            coords: [36, 105, 45, 109, 45, 120, 36, 124, 27, 120, 27, 109], color: '#009900', offsets: [-95, 27]
        }, {
            coords: [54, 105, 63, 109, 63, 120, 54, 124, 45, 120, 45, 109], color: '#66FF33', offsets: [-95, 45]
        }, {
            coords: [72, 105, 81, 109, 81, 120, 72, 124, 63, 120, 63, 109], color: '#99FF66', offsets: [-95, 63]
        }, {
            coords: [90, 105, 99, 109, 99, 120, 90, 124, 81, 120, 81, 109], color: '#CCFF99', offsets: [-95, 81]
        }, {
            coords: [108, 105, 117, 109, 117, 120, 108, 124, 99, 120, 99, 109], color: '#FFFFCC', offsets: [-95, 99]
        }, {
            coords: [126, 105, 135, 109, 135, 120, 126, 124, 117, 120, 117, 109], color: '#FFCCCC', offsets: [-95, 117]
        }, {
            coords: [144, 105, 153, 109, 153, 120, 144, 124, 135, 120, 135, 109], color: '#FF99CC', offsets: [-95, 135]
        }, {
            coords: [162, 105, 171, 109, 171, 120, 162, 124, 153, 120, 153, 109], color: '#FF66CC', offsets: [-95, 153]
        }, {
            coords: [180, 105, 189, 109, 189, 120, 180, 124, 171, 120, 171, 109], color: '#FF33CC', offsets: [-95, 171]
        }, {
            coords: [198, 105, 207, 109, 207, 120, 198, 124, 189, 120, 189, 109], color: '#CC0099', offsets: [-95, 189]
        }, {
            coords: [216, 105, 225, 109, 225, 120, 216, 124, 207, 120, 207, 109], color: '#993399', offsets: [-95, 207]
        }, {
            coords: [27, 120, 36, 124, 36, 135, 27, 139, 18, 135, 18, 124], color: '#333300', offsets: [-80, 18]
        }, {
            coords: [45, 120, 54, 124, 54, 135, 45, 139, 36, 135, 36, 124], color: '#669900', offsets: [-80, 36]
        }, {
            coords: [63, 120, 72, 124, 72, 135, 63, 139, 54, 135, 54, 124], color: '#99FF33', offsets: [-80, 54]
        }, {
            coords: [81, 120, 90, 124, 90, 135, 81, 139, 72, 135, 72, 124], color: '#CCFF66', offsets: [-80, 72]
        }, {
            coords: [99, 120, 108, 124, 108, 135, 99, 139, 90, 135, 90, 124], color: '#FFFF99', offsets: [-80, 90]
        }, {
            coords: [117, 120, 126, 124, 126, 135, 117, 139, 108, 135, 108, 124], color: '#FFCC99', offsets: [-80, 108]
        }, {
            coords: [135, 120, 144, 124, 144, 135, 135, 139, 126, 135, 126, 124], color: '#FF9999', offsets: [-80, 126]
        }, {
            coords: [153, 120, 162, 124, 162, 135, 153, 139, 144, 135, 144, 124], color: '#FF6699', offsets: [-80, 144]
        }, {
            coords: [171, 120, 180, 124, 180, 135, 171, 139, 162, 135, 162, 124], color: '#FF3399', offsets: [-80, 162]
        }, {
            coords: [189, 120, 198, 124, 198, 135, 189, 139, 180, 135, 180, 124], color: '#CC3399', offsets: [-80, 180]
        }, {
            coords: [207, 120, 216, 124, 216, 135, 207, 139, 198, 135, 198, 124], color: '#990099', offsets: [-80, 198]
        }, {
            coords: [36, 135, 45, 139, 45, 150, 36, 154, 27, 150, 27, 139], color: '#666633', offsets: [-65, 27]
        }, {
            coords: [54, 135, 63, 139, 63, 150, 54, 154, 45, 150, 45, 139], color: '#99CC00', offsets: [-65, 45]
        }, {
            coords: [72, 135, 81, 139, 81, 150, 72, 154, 63, 150, 63, 139], color: '#CCFF33', offsets: [-65, 63]
        }, {
            coords: [90, 135, 99, 139, 99, 150, 90, 154, 81, 150, 81, 139], color: '#FFFF66', offsets: [-65, 81]
        }, {
            coords: [108, 135, 117, 139, 117, 150, 108, 154, 99, 150, 99, 139], color: '#FFCC66', offsets: [-65, 99]
        },
        {
            coords: [126, 135, 135, 139, 135, 150, 126, 154, 117, 150, 117, 139], color: '#FF9966', offsets: [-65, 117]
        },
        {
            coords: [144, 135, 153, 139, 153, 150, 144, 154, 135, 150, 135, 139], color: '#FF6666', offsets: [-65, 135]
        },
        {
            coords: [162, 135, 171, 139, 171, 150, 162, 154, 153, 150, 153, 139], color: '#FF0066', offsets: [-65, 153]
        },
        {
            coords: [180, 135, 189, 139, 189, 150, 180, 154, 171, 150, 171, 139], color: '#CC6699', offsets: [-65, 171]
        }, {
            coords: [198, 135, 207, 139, 207, 150, 198, 154, 189, 150, 189, 139], color: '#993366', offsets: [-65, 189]
        }, {
            coords: [45, 150, 54, 154, 54, 165, 45, 169, 36, 165, 36, 154], color: '#999966', offsets: [-50, 36]
        }, {
            coords: [63, 150, 72, 154, 72, 165, 63, 169, 54, 165, 54, 154], color: '#CCCC00', offsets: [-50, 54]
        }, {
            coords: [81, 150, 90, 154, 90, 165, 81, 169, 72, 165, 72, 154], color: '#FFFF00', offsets: [-50, 72]
        }, {
            coords: [99, 150, 108, 154, 108, 165, 99, 169, 90, 165, 90, 154], color: '#FFCC00', offsets: [-50, 90]
        }, {
            coords: [117, 150, 126, 154, 126, 165, 117, 169, 108, 165, 108, 154], color: '#FF9933', offsets: [-50, 108]
        }, {
            coords: [135, 150, 144, 154, 144, 165, 135, 169, 126, 165, 126, 154], color: '#FF6600', offsets: [-50, 126]
        }, {
            coords: [153, 150, 162, 154, 162, 165, 153, 169, 144, 165, 144, 154], color: '#FF5050', offsets: [-50, 144]
        }, {
            coords: [171, 150, 180, 154, 180, 165, 171, 169, 162, 165, 162, 154], color: '#CC0066', offsets: [-50, 162]
        }, {
            coords: [189, 150, 198, 154, 198, 165, 189, 169, 180, 165, 180, 154], color: '#660033', offsets: [-50, 180]
        }, {
            coords: [54, 165, 63, 169, 63, 180, 54, 184, 45, 180, 45, 169], color: '#996633', offsets: [-35, 45]
        }, {
            coords: [72, 165, 81, 169, 81, 180, 72, 184, 63, 180, 63, 169], color: '#CC9900', offsets: [-35, 63]
        }, {
            coords: [90, 165, 99, 169, 99, 180, 90, 184, 81, 180, 81, 169], color: '#FF9900', offsets: [-35, 81]
        }, {
            coords: [108, 165, 117, 169, 117, 180, 108, 184, 99, 180, 99, 169], color: '#CC6600', offsets: [-35, 99]
        }, {
            coords: [126, 165, 135, 169, 135, 180, 126, 184, 117, 180, 117, 169], color: '#FF3300', offsets: [-35, 117]
        }, {
            coords: [144, 165, 153, 169, 153, 180, 144, 184, 135, 180, 135, 169], color: '#FF0000', offsets: [-35, 135]
        }, {
            coords: [162, 165, 171, 169, 171, 180, 162, 184, 153, 180, 153, 169], color: '#CC0000', offsets: [-35, 153]
        }, {
            coords: [180, 165, 189, 169, 189, 180, 180, 184, 171, 180, 171, 169], color: '#990033', offsets: [-35, 171]
        }, {
            coords: [63, 180, 72, 184, 72, 195, 63, 199, 54, 195, 54, 184], color: '#663300', offsets: [-20, 54]
        }, {
            coords: [81, 180, 90, 184, 90, 195, 81, 199, 72, 195, 72, 184], color: '#996600', offsets: [-20, 72]
        }, {
            coords: [99, 180, 108, 184, 108, 195, 99, 199, 90, 195, 90, 184], color: '#CC3300', offsets: [-20, 90]
        }, {
            coords: [117, 180, 126, 184, 126, 195, 117, 199, 108, 195, 108, 184], color: '#993300', offsets: [-20, 108]
        }, {
            coords: [135, 180, 144, 184, 144, 195, 135, 199, 126, 195, 126, 184], color: '#990000', offsets: [-20, 126]
        }, {
            coords: [153, 180, 162, 184, 162, 195, 153, 199, 144, 195, 144, 184], color: '#800000', offsets: [-20, 144]
        }, {
            coords: [171, 180, 180, 184, 180, 195, 171, 199, 162, 195, 162, 184], color: '#993333', offsets: [-20, 162]
        }
    ];
}