namespace pages {

    export interface Task {
        appName: string;
        time: string;
        title: string;
        status: "success" | "error" | "pending" | "running" | "cancel";
        session_id: string;
        arguments: {};

        /**
         * not empty if the status is ``error``
        */
        error: desktop.RSharpError;
        logtext: string;
        url: string;
    }

    const htmlColors = {
        "success": "badge-success",
        "error": "badge-danger",
        "pending": "badge-warning",
        "cancel": "badge-default",
        "running": "badge-success"
    };

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
                    const jsonlist: string[] = await list;

                    vm.showTaskDatalist(jsonlist, function () {
                        desktop.showToastMessage(`Load ${jsonlist.length} web task!`, "Task Manager", "info");
                        setInterval(() => vm.checkList(), 3000);
                    });
                });
        }

        private checkList() {
            const vm = this;

            apps.gcmodeller
                .checkTaskList()
                .then(async function (list) {
                    const check: string[] = await list;
                    const flag: boolean = check.length > 0;

                    if (flag) {
                        // if task list has updates
                        apps.gcmodeller
                            .getTaskList()
                            .then(async function (list) {
                                const jsonlist: string[] = await list;

                                vm.showTaskDatalist(jsonlist, function () {
                                    console.log("task list has been updated!");
                                });
                            });

                        for (let json of check) {
                            var taskObj: Task = JSON.parse(json);

                            if (taskObj.status == "success") {
                                desktop.showToastMessage(`Run [${taskObj.title}] success!`, "Task Manager", "success");
                            } else if (taskObj.status == "error") {
                                desktop.showToastMessage(`Run [${taskObj.title}] failured!`, "Task Manager", "danger");
                            }
                        }
                    }
                });
        }

        private showTaskDatalist(jsonlist: string[], callback: Delegate.Action = null) {
            const webtasks = $from(jsonlist)
                .Select(json => <Task>JSON.parse(json))
                .ToArray()
                ;
            const vm = this;

            vm.loadTaskList(webtasks)
                .then(function (any) {
                    if (!isNullOrUndefined(callback)) {
                        callback();
                    }
                });
        }

        private async loadTaskList(tasklist: Task[]) {
            let list = $ts("#task_manager").clear();
            let html: HTMLElement;

            for (let task of tasklist) {
                // task = await task;
                // get host data
                task = await web_task.getHostObject(task);
                html = web_task.buildTaskHtml(task);
                list.appendElement(html);
            }

            return 0;
        }

        private static async getHostObject(hostObj: Task): Promise<Task> {
            const task = <Task>{
            };

            task.appName = await hostObj.appName;
            task.arguments = await hostObj.arguments;
            task.error = await hostObj.error;
            task.logtext = await hostObj.logtext;
            task.session_id = await hostObj.session_id;
            task.status = await hostObj.status;
            task.time = await hostObj.time;
            task.title = await hostObj.title;
            task.url = await hostObj.url;

            console.log(task);

            return task;
        }

        private static buildTaskHtml(task: Task): HTMLElement {
            return $ts("<tr>").display(`          
            <td>
                <div class="d-flex align-items-center">
                    <img src="/assets/images/dna-image.jpg" alt=""
                        style="width: 45px; height: 45px" class="rounded-circle" />
                    <div class="ms-3">
                        <p class="fw-bold mb-1">${task.appName}</p>
                        <p class="text-muted mb-0">${task.session_id}</p>
                    </div>
                </div>
            </td>
            <td>
                <p class="fw-normal mb-1">${task.title}</p>
                <p class="text-muted mb-0">${task.time}</p>
            </td>
            <td>
                <span class="badge ${htmlColors[task.status]} rounded-pill d-inline">${task.status}</span>
            </td>
            <td>${task.logtext}</td>
            <td>
                <button type="button" class="btn btn-link btn-sm btn-rounded">
                    Cancel
                </button>
                <button type="button" class="btn btn-link btn-sm btn-rounded">
                    Delete
                </button>
            </td>       
            `);
        }
    }
}