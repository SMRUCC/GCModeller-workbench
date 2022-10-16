/// <reference path="../../../../build/sampleinfo_editor.d.ts" />

namespace pages.analysis_project {

    export class edit_sampleinfo extends Bootstrap {

        public get appName(): string {
            return "edit_sampleinfo";
        };

        protected init(): void {
            app.initSampleEditor();
        }

    }
}