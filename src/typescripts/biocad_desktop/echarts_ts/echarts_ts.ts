namespace js_plot {

    export abstract class echarts_ts {

        protected myChart: {
            setOption: (opt: {}) => void,
            resize: () => void
        };
        protected option = {};

        public constructor(div: string = "Rplot_js") {
            const echarts: any = (<any>window).echarts;

            this.myChart = echarts.init(document.getElementById(div), null, {
                renderer: 'canvas',
                useDirtyRect: false
            });
            this.option && this.myChart.setOption(this.option);
        }

        protected hookChartResizeEvt() {
            window.addEventListener('resize', this.myChart.resize);
        }

        /**
         * call this function to show plot after config
         * ``myChart`` and ``option`` these two objects.
        */
        protected show() {
            this.option && this.myChart.setOption(this.option);
        }
    }
}