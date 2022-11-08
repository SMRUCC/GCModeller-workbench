namespace js_plot {

    export interface graph {
        categories: { name: string }[];
        nodes: graph_node[];
        links: { source: string, target: string }[];
    }

    export interface graph_node {
        id: string,
        name: string,
        category: number,
        symbolSize: number,
        value: number,
        x: number,
        y: number
    }

    export class graph_plot extends echarts_ts {

        public constructor(div: string = "container") {
            super(div);
        }

        public plot(title: string, graph: graph) {
            console.log("view of the graph data:");
            console.log(graph);

            this.option = {
                title: {
                    text: title,
                    subtext: 'Default layout',
                    top: 'bottom',
                    left: 'right'
                },
                tooltip: {},
                legend: [
                    {
                        // selectedMode: 'single',
                        data: graph.categories.map(function (a) {
                            return a.name;
                        })
                    }
                ],
                series: [
                    {
                        name: title,
                        type: 'graph',
                        layout: 'force',
                        data: graph.nodes,
                        links: graph.links,
                        categories: graph.categories,
                        roam: true,
                        label: {
                            position: 'right'
                        },
                        force: {
                            repulsion: 100
                        },
                        lineStyle: {
                            width: 3
                        }
                    }
                ]
            };

            this.show();
        }
    }
}