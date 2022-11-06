///<reference path="echarts_ts.ts" />

namespace js_plot {

    export class scatter3d extends echarts_ts {

        public constructor(div: string = "Rplot_js") {
            super(div);
        }

        public plot(data, symbolSize = 30) {
            this.option = {
                grid3D: {},
                xAxis3D: {},
                yAxis3D: {},
                zAxis3D: {},
                dataset: {
                    dimensions: [
                        '',
                        'dim1',
                        'dim2',
                        'dim3'
                    ],
                    source: data
                },
                series: [
                    {
                        type: 'scatter3D',
                        symbolSize: symbolSize,
                        encode: {
                            x: 'dim1',
                            y: 'dim2',
                            z: 'dim3',
                            tooltip: [0, 1, 2, 3]
                        }
                    }
                ]
            };

            this.show();
            this.hookChartResizeEvt();
        }
    }
}