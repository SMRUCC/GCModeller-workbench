///<reference path="echarts_ts.ts" />

namespace js_plot {

    export class lineplot extends echarts_ts {

        public constructor(
            public title: string,
            public subtitle: string,
            public div: string = "Rplot_js") {

            super(div);
        }

        public plot(name: string, data: number[][], others: { name: string, data: number[][] }[] = null) {
            const lines = [
                {
                    data: data,
                    type: 'line',
                    areaStyle: {},
                    smooth: true,
                    markPoint: {
                        symbol: 'none',
                        symbolSize: 1
                    },
                    name: name
                }
            ];

            if (others) {
                for (let pin of others) {
                    lines.push({
                        data: pin.data,
                        type: 'line',
                        areaStyle: {},
                        smooth: true,
                        markPoint: {
                            symbol: 'none',
                            symbolSize: 1
                        },
                        name: pin.name
                    });
                }
            }

            this.option = {
                title: {
                    text: this.title,
                    subtext: this.subtitle,
                    left: 'center'
                },
                tooltip: {
                    trigger: 'item'
                },
                xAxis: {
                    type: 'value'
                },
                yAxis: {
                    type: 'value'
                },
                series: lines,
                legend: {
                    orient: 'vertical',
                    show: true
                }
            };

            this.show();
        }
    }
}
