///<reference path="echarts_ts.ts" />

namespace js_plot {

    export class piePlot extends echarts_ts {

        public constructor(public title: string, public subtitle: string, div: string = "Rplot_js") {
            super(div);
        }

        public plot(name: string, data: { name: string, value: number }[]) {
            this.option = {
                title: {
                    text: this.title,
                    subtext: this.subtitle,
                    left: 'center'
                },
                tooltip: {
                    trigger: 'item'
                },
                legend: {
                    orient: 'vertical',
                    left: 'left',
                    show: false
                },
                series: [
                    {
                        name: name,
                        type: 'pie',
                        radius: '50%',
                        data: data,
                        emphasis: {
                            itemStyle: {
                                shadowBlur: 10,
                                shadowOffsetX: 0,
                                shadowColor: 'rgba(0, 0, 0, 0.5)'
                            }
                        }
                    }
                ]
            };

            this.show();
        }
    }
}