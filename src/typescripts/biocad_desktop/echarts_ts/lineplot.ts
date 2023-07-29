///<reference path="echarts_ts.ts" />

namespace js_plot {

    export class lineplot extends echarts_ts {
        public constructor(
            public title: string,
            public subtitle: string,
            public div: string = "Rplot_js") {

            super(div);
        }

        public plot(name: string, x: number[], y: number[]) {
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
                    type: 'value',
                    data: x
                },
                yAxis: {
                    type: 'value'
                },
                series: [
                    {
                        data: y,
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
