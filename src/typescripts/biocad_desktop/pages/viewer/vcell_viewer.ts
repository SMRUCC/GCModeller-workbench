/// <reference path="../../../build/viewer.d.ts" />

namespace pages.viewers {

    export class vcell_viewer extends Bootstrap {

        public get appName(): string {
            return "vcell_viewer";
        }

        protected init(): void {
            $ts.get("@counts", function (result) {
                console.log(result);
            });
        }

    }
}