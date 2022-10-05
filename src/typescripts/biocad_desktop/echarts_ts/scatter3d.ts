namespace js_plot {

    export class scatter3d {

        public plot(
            div: string = "Rplot_js",
            schema = [
                { name: '', index: 0 },
                { name: 'dim1', index: 1 },
                { name: 'dim2', index: 2 },
                { name: 'dim3', index: 3 }
            ]) {

            var app = {};
            var chartDom = document.getElementById(div);
            var myChart = echarts.init(chartDom);
            var option;
            var indices = {
                name: 0,
                group: 1,
                id: 16
            };
            var data;
            var fieldIndices = schema.reduce(function (obj, item) {
                obj[item.name] = item.index;
                return obj;
            }, {});
            var groupCategories = [];
            var groupColors = [];
            var fieldNames = schema.map(item => item.name);
            fieldNames = fieldNames.slice(2, fieldNames.length - 2);
            function getMaxOnExtent(data) {
                var colorMax = -Infinity;
                var symbolSizeMax = -Infinity;
                for (var i = 0; i < data.length; i++) {
                    var item = data[i];
                    var colorVal = item[fieldIndices[config.color]];
                    var symbolSizeVal = item[fieldIndices[config.symbolSize]];
                    colorMax = Math.max(colorVal, colorMax);
                    symbolSizeMax = Math.max(symbolSizeVal, symbolSizeMax);
                }
                return {
                    color: colorMax,
                    symbolSize: symbolSizeMax
                };
            }
            var config = (app.config = {
                xAxis3D: 'protein',
                yAxis3D: 'fiber',
                zAxis3D: 'sodium',
                color: 'fiber',
                symbolSize: 'vitaminc',
                onChange: function () {
                    var max = getMaxOnExtent(data);
                    if (data) {
                        myChart.setOption({
                            visualMap: [
                                {
                                    max: max.color / 2
                                },
                                {
                                    max: max.symbolSize / 2
                                }
                            ],
                            xAxis3D: {
                                name: config.xAxis3D
                            },
                            yAxis3D: {
                                name: config.yAxis3D
                            },
                            zAxis3D: {
                                name: config.zAxis3D
                            },
                            series: {
                                dimensions: [
                                    config.xAxis3D,
                                    config.yAxis3D,
                                    config.yAxis3D,
                                    config.color,
                                    config.symbolSiz
                                ],
                                data: data.map(function (item, idx) {
                                    return [
                                        item[fieldIndices[config.xAxis3D]],
                                        item[fieldIndices[config.yAxis3D]],
                                        item[fieldIndices[config.zAxis3D]],
                                        item[fieldIndices[config.color]],
                                        item[fieldIndices[config.symbolSize]],
                                        idx
                                    ];
                                })
                            }
                        });
                    }
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
            $.getJSON(ROOT_PATH + '/data/asset/data/nutrients.json', function (_data) {
                data = _data;
                var max = getMaxOnExtent(data);
                myChart.setOption({
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
                        name: config.xAxis3D,
                        type: 'value'
                    },
                    yAxis3D: {
                        name: config.yAxis3D,
                        type: 'value'
                    },
                    zAxis3D: {
                        name: config.zAxis3D,
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
                                config.xAxis3D,
                                config.yAxis3D,
                                config.yAxis3D,
                                config.color,
                                config.symbolSiz
                            ],
                            data: data.map(function (item, idx) {
                                return [
                                    item[fieldIndices[config.xAxis3D]],
                                    item[fieldIndices[config.yAxis3D]],
                                    item[fieldIndices[config.zAxis3D]],
                                    item[fieldIndices[config.color]],
                                    item[fieldIndices[config.symbolSize]],
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
            });

            option && myChart.setOption(option);
        }
    }
}