namespace js_plot {

    export class scatter3d {

        private config: {
            zAxis3D: any;
            yAxis3D: any;
            xAxis3D: any; color: any, symbolSize: any
        };
        private data: [];
        private fieldIndices: {};
        private myChart: {};

        public getMaxOnExtent() {
            var colorMax = -Infinity;
            var symbolSizeMax = -Infinity;
            var data = this.data;

            for (var i = 0; i < data.length; i++) {
                var item = data[i];
                var colorVal = item[this.fieldIndices[this.config.color]];
                var symbolSizeVal = item[this.fieldIndices[this.config.symbolSize]];
                colorMax = Math.max(colorVal, colorMax);
                symbolSizeMax = Math.max(symbolSizeVal, symbolSizeMax);
            }
            return {
                color: colorMax,
                symbolSize: symbolSizeMax
            };
        }

        private load(div, schema = [
            { name: '', index: 0 },
            { name: 'dim1', index: 1 },
            { name: 'dim2', index: 2 },
            { name: 'dim3', index: 3 }
        ]) {

            var app = { config: {}, configParameters: {} };
            var chartDom = document.getElementById(div);
            var option;
            var indices = {
                name: 0,
                group: 1,
                id: 16
            };

            this.myChart = echarts.init(chartDom);
            this.fieldIndices = schema.reduce(function (obj, item) {
                obj[item.name] = item.index;
                return obj;
            }, {});

            var groupCategories = [];
            var groupColors = [];
            var fieldNames = schema.map(item => item.name);
            var vm = this;

            fieldNames = $from(fieldNames).Skip(1).ToArray();

            console.log("data field names:");
            console.log(fieldNames);

            this.config = (app.config = {
                xAxis3D: 'dim1',
                yAxis3D: 'dim2',
                zAxis3D: 'dim3',
                color: 'dim1',
                symbolSize: 'dim2',
                onChange: function () {
                    vm.onchange();
                }
            });

            app.configParameters = {};

            ['xAxis3D', 'yAxis3D', 'zAxis3D', 'color', 'symbolSize'].forEach(function (
                fieldName
            ) {
                app.configParameters[fieldName] = {
                    options: fieldNames
                };
            });

            option && vm.myChart.setOption(option);
        }

        private onchange() {
            var vm = this;
            var max = vm.getMaxOnExtent();

            if (vm.data) {
                vm.myChart.setOption({
                    visualMap: [
                        {
                            max: max.color / 2
                        },
                        {
                            max: max.symbolSize / 2
                        }
                    ],
                    xAxis3D: {
                        name: vm.config.xAxis3D
                    },
                    yAxis3D: {
                        name: vm.config.yAxis3D
                    },
                    zAxis3D: {
                        name: vm.config.zAxis3D
                    },
                    series: {
                        dimensions: [
                            vm.config.xAxis3D,
                            vm.config.yAxis3D,
                            vm.config.yAxis3D,
                            vm.config.color,
                            vm.config.symbolSize
                        ],
                        data: vm.data.map(function (item, idx) {
                            return [
                                item[vm.fieldIndices[vm.config.xAxis3D]],
                                item[vm.fieldIndices[vm.config.yAxis3D]],
                                item[vm.fieldIndices[vm.config.zAxis3D]],
                                item[vm.fieldIndices[vm.config.color]],
                                item[vm.fieldIndices[vm.config.symbolSize]],
                                idx
                            ];
                        })
                    }
                });
            }
        }

        /**
         * @param _data a array of js array to set as scatter plot data:
         * 
         *    1. first element should be the point label
         *    2. 2/3/4 element should be the number data to the scatter 3d
        */
        public plot(
            _data,
            div: string = "Rplot_js",
            schema = [
                { name: '', index: 0 },
                { name: 'dim1', index: 1 },
                { name: 'dim2', index: 2 },
                { name: 'dim3', index: 3 }
            ]) {

            this.data = _data;
            this.load(div, schema);

            const max = this.getMaxOnExtent();
            const vm = this;

            vm.myChart.setOption({
                tooltip: {},
                visualMap: [
                    {
                        top: 10,
                        calculable: true,
                        dimension: 3,
                        max: max.color / 2,
                        inRange: {
                            color: [
                                '#1710c0',
                                '#0b9df0',
                                '#00fea8',
                                '#00ff0d',
                                '#f5f811',
                                '#f09a09',
                                '#fe0300'
                            ]
                        },
                        textStyle: {
                            color: '#fff'
                        }
                    },
                    {
                        bottom: 10,
                        calculable: true,
                        dimension: 4,
                        max: max.symbolSize / 2,
                        inRange: {
                            symbolSize: [10, 40]
                        },
                        textStyle: {
                            color: '#fff'
                        }
                    }
                ],
                xAxis3D: {
                    name: vm.config.xAxis3D,
                    type: 'value'
                },
                yAxis3D: {
                    name: vm.config.yAxis3D,
                    type: 'value'
                },
                zAxis3D: {
                    name: vm.config.zAxis3D,
                    type: 'value'
                },
                grid3D: {
                    axisLine: {
                        lineStyle: {
                            color: '#fff'
                        }
                    },
                    axisPointer: {
                        lineStyle: {
                            color: '#ffbd67'
                        }
                    },
                    viewControl: {
                        // autoRotate: true
                        // projection: 'orthographic'
                    }
                },
                series: [
                    {
                        type: 'scatter3D',
                        dimensions: [
                            vm.config.xAxis3D,
                            vm.config.yAxis3D,
                            vm.config.yAxis3D,
                            vm.config.color,
                            vm.config.symbolSize
                        ],
                        data: vm.data.map(function (item, idx) {
                            return [
                                item[vm.fieldIndices[vm.config.xAxis3D]],
                                item[vm.fieldIndices[vm.config.yAxis3D]],
                                item[vm.fieldIndices[vm.config.zAxis3D]],
                                item[vm.fieldIndices[vm.config.color]],
                                item[vm.fieldIndices[vm.config.symbolSize]],
                                idx
                            ];
                        }),
                        symbolSize: 12,
                        // symbol: 'triangle',
                        itemStyle: {
                            borderWidth: 1,
                            borderColor: 'rgba(255,255,255,0.8)'
                        },
                        emphasis: {
                            itemStyle: {
                                color: '#fff'
                            }
                        }
                    }
                ]
            });
        }
    }
}