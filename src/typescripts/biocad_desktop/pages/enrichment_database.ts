namespace pages {

    export class enrichment_database extends Bootstrap {

        public get appName(): string {
            return "enrichment_database";
        }

        protected init(): void {
            // throw new Error("Method not implemented.");
        }

        public open_uniprot_onclick() {
            $ts.get("@web_invoke_openfile", function (result: IMsg<string>) {
                $ts("#formFile").CType<HTMLInputElement>().value = result.info;
            });
        }
    }
}