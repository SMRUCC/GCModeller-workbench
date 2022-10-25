namespace pages {

    export interface Task {
        appName: string;
        time: string;
        title: string;
        status: "success" | "error" | "pending" | "cancel";
        session_id: string;
        arguments: {};

        /**
         * not empty if the status is ``error``
        */
        error: desktop.RSharpError;
    }

    export class web_task extends Bootstrap {

        public get appName(): string {
            return "web_task";
        };

        protected init(): void {
            const vm = this;

            // throw new Error("Method not implemented.");
            apps.gcmodeller
                .getTaskList()
                .then(async function (list) {
                    const webtasks = await list;
                    vm.loadTaskList(webtasks);
                });
        }

        private loadTaskList(tasklist: Task[]) {
            console.log(tasklist);
        }
    }
}