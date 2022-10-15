namespace pages.background {

    /**
     * 画布的参数设置
    */
    export interface CanvasSettings {

        /**
         * 所创建的画布对象的id
        */
        canvasId: string;
        zIndex: number;
        opacity: number;
        color: string;

        /**
         * 点的数量
        */
        n: number;
    }

    /**
     * 画布上面的一个移动的点的模型
    */
    export interface dot {

        /**
         * 当前的位置``x``
        */
        x: number;
        /**
         * 当前的位置``y``
        */
        y: number;
        xa: number;
        ya: number;
        max: number;
    }
} 