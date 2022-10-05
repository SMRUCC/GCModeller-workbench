namespace pages {

    export class dataEmbedding extends Bootstrap {

        public get appName(): string {
            return "dataEmbedding";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
        }

        public button_open_click() {
            apps.gcmodeller
                .getFileOpen("Excel Matrix(*.csv)|*.csv")
                .then(async function (result) {
                    const filepath: string = await result;

                    if (!Strings.Empty(filepath)) {

                    }
                })
        }
    }
}