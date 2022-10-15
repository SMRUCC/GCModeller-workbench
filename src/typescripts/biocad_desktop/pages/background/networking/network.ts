namespace pages.background {

    export class network {

        public constructor(
            /**
             * 进行动画显示的画布对象
            */
            public uCanvas: HTMLCanvasElement = document.createElement("canvas"),
            public uContext: CanvasRenderingContext2D = uCanvas.getContext("2d"),
            public f: dot = <dot>{
                x: null, y: null, max: 20000
            },

            /**
             * ``[width, height]``
            */
            public size: number[] = [0, 0],
            public dots: dot[] = [],
            public setting: CanvasSettings = null,
            public frameRender: (callback: FrameRequestCallback) => number = null) {
        }

        static getTag(tagName: string): Element {
            return document.getElementsByTagName(tagName)[0];
        }

        static getById(id: string): Element {
            return document.getElementById(id);
        }

        /**
         * 当窗口大小发生改变的时候，画布的事件
        */
        canvasResize() {
            this.uCanvas.width = window.innerWidth ||
                document.documentElement.clientWidth ||
                document.body.clientWidth;
            this.uCanvas.height = window.innerHeight ||
                document.documentElement.clientHeight ||
                document.body.clientHeight;

            this.size = [this.uCanvas.width, this.uCanvas.height];
        }

        /**
         * 更新画布上面的一帧动画
        */
        update() {
            let vm = this;
            let w: dot[] = [vm.f].concat(vm.dots);
            let x: dot;
            let v: number, A: number, B: number, z: number, y: number;

            vm.uContext.clearRect(0, 0, vm.size[0], vm.size[1]);

            for (let i of vm.dots) {
                i.x += i.xa;
                i.y += i.ya;
                i.xa *= i.x > vm.size[0] || i.x < 0 ? -1 : 1;
                i.ya *= i.y > vm.size[1] || i.y < 0 ? -1 : 1;

                vm.uContext.fillRect(i.x - 0.5, i.y - 0.5, 1, 1);

                for (v = 0; v < w.length; v++) {
                    x = w[v];

                    if (i !== x && null !== x.x && null !== x.y) {
                        B = i.x - x.x;
                        z = i.y - x.y;
                        y = B * B + z * z;

                        y < x.max && (
                            x === vm.f && y >= x.max / 2 && (i.x -= 0.03 * B, i.y -= 0.03 * z),
                            A = (x.max - y) / x.max,
                            vm.uContext.beginPath(),
                            vm.uContext.lineWidth = A / 2,
                            vm.uContext.strokeStyle = `rgba(${vm.setting.color}, ${A + 0.2})`,
                            vm.uContext.moveTo(i.x, i.y),
                            vm.uContext.lineTo(x.x, x.y),
                            vm.uContext.stroke()
                        )
                    }
                };

                w.splice(w.indexOf(i), 1);
            }

            vm.frameRender(() => vm.update());
        }

        static defaultCallback(callback: FrameRequestCallback): number {
            window.setTimeout(callback, 1000 / 45);
            return 0;
        }

        /**
         * 注册鼠标设备以及画布更新事件
        */
        registerDevice() {
            let vm = this;

            vm.frameRender = window.requestAnimationFrame ||
                window.webkitRequestAnimationFrame ||
                (<any>window).mozRequestAnimationFrame ||
                (<any>window).oRequestAnimationFrame ||
                (<any>window).msRequestAnimationFrame ||
                network.defaultCallback;

            window.onresize = vm.canvasResize;
            window.onmousemove = function (evt: MouseEvent) {
                evt = evt || <MouseEvent>window.event;
                vm.f.x = evt.clientX;
                vm.f.y = evt.clientY;
            };
            window.onmouseout = function () {
                vm.f.x = null;
                vm.f.y = null;
            };
        }
    }

    /**
     * 运行这个网络画布
     * 
     * @param containerId Canvas所进行显示的目标div的id编号，如果这个编号为空值，则默认显示在整个body上面
     * @param settings 配置参数
    */
    export function run(
        containerId: string = null,
        settings: CanvasSettings = <CanvasSettings>{
            canvasId: "canvas-network-display",
            zIndex: -1,
            opacity: 1,
            color: "0,104,183",
            n: 100
        }) {

        const canvas = new network();

        // 初始化画布对象以及鼠标设备
        let setting = settings;

        canvas.setting = setting;
        canvas.uCanvas.id = `canvas_${settings.canvasId}`;
        canvas.uCanvas.style.cssText = `position:fixed; top:0; left:0; z-index: ${settings.zIndex}; opacity: ${settings.opacity}`;

        if (!containerId) {
            network.getTag("body").appendChild(canvas.uCanvas);
        } else {
            network.getById(containerId).appendChild(canvas.uCanvas);
        }

        canvas.canvasResize();
        canvas.registerDevice();

        // 创建指定数量的点对象
        // 位置为随机位置
        for (let p: number = 0; settings.n > p; p++) {
            let w = Math.random() * canvas.size[0];
            let h = Math.random() * canvas.size[1];
            let q = 2 * Math.random() - 1;
            let d = 2 * Math.random() - 1;

            canvas.dots.push(<dot>{
                x: w,
                y: h,
                xa: q,
                ya: d,
                max: 10000
            });
        }

        // 启动动画的更新线程
        setTimeout(() => canvas.update(), 100);
    }
}