///<reference path="echarts_ts.ts" />

namespace js_plot {

    export class lineplot extends echarts_ts {
        public constructor(
            public title: string,
            public subtitle: string,
            public div: string = "Rplot_js") {

            super(div);
        }

        public plot(name: string, data: number[][]) {
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
                series: [
                    {
                        data: data,
                        type: 'line',
                        areaStyle: {}
                    }
                ],
                legend: {
                    orient: 'vertical',
                    show: true
                }
            };

            this.show();
        }
    }
}
