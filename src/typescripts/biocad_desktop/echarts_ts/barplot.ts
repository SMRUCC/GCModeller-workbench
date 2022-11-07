///<reference path="echarts_ts.ts" />

namespace js_plot {

    export class barplot extends echarts_ts {

        public constructor(div: string = "Rplot_js") {
            super(div);
        }

        public plot(data: { name: string, value: number }[] | IEnumerator<{ name: string, value: number }>) {
            this.option = {
                xAxis: {
                    type: 'category',
                    data: $from(data).Select(a => a.name).ToArray(),
                    axisLabel: { rotate: 45 }
                },
                yAxis: {
                    type: 'value'
                },
                tooltip: {
                    trigger: 'item'
                },
                series: [
                    {
                        data: $from(data).Select(a => a.value).ToArray(),
                        type: 'bar'
                    }
                ]
            };

            this.show();
        }
    }
}