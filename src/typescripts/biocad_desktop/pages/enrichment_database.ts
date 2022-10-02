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

        public imports_onclick() {
            const data = {
                file: $ts.value("#formFile"),
                name: $ts.value("#title"),
                note: $ts.value("#description")
            };

            $ts.post("@web_invoke_imports", data, function (result: IMsg<string>) {
                if (result.code != 0) {

                } else {
                    // location.reload();
                }
            });
        }
    }
}