namespace js_plot {

    export abstract class echarts_ts {

        protected myChart: {
            setOption: (opt: {}) => void,
            resize: () => void,
            hideLoading: () => void
        };
        protected option = {};

        public constructor(div: string = "Rplot_js") {
            const echarts: any = (<any>window).echarts;

            $ts(`#${div}`).clear().removeAttribute("_echarts_instance_");

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