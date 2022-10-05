namespace js_plot {

    export class scatter3d {

        private myChart: {};
        private option = {};

        public constructor(div: string = "Rplot_js") {
            this.myChart = echarts.init(document.getElementById(div));
            this.option && this.myChart.setOption(this.option);
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

            this.myChart.setOption(this.option);
        }
    }
}