namespace pages.modeller {

    export class bioproject extends Bootstrap {

        public get appName(): string {
            return "bioproject";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
            $ts("#path").display($ts.location("proj"));

        }

    }
}