namespace pages.repository {

    export class uniprot_database extends Bootstrap {

        public get appName(): string {
            return "uniprot_database";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
        }

        public button_open_uniprot_onclick() {
            desktop.winforms.openfileDialog("#uniprot-file", apps.uniprot_assembly);
        }

        public run_onclick() {
            desktop.loading("Build blast database...");

            const textbox = $ts("#uniprot-file").CType<HTMLInputElement>();
            const path: string = textbox.value;
            const json = {
                uniprot: path
            };
            const title: string = "Build enzyme blast+ database";

            if (Strings.Empty(path, true)) {
                desktop.showToastMessage("No uniprot assembly file was provided!", title, "danger");
                return;
            }

            apps.gcmodeller
                .createTask(`Imports Enzyme Database`, $ts.url("@web_invoke_imports"), JSON.stringify(json))
                .then(async function (msg) {
                    const task_id: string = await msg.data;

                    desktop.showTaskAlert();
                    desktop.showToastMessage(`Pending a new task: ${task_id}`, title, "info");
                })
                ;
        }
    }
}