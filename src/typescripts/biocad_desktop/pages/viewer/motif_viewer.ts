/// <reference path="../../../build/viewer.d.ts" />

namespace pages.viewer {

    export class motif_viewer extends Bootstrap {

        public get appName(): string {
            return "motif_viewer";
        };

        private motifLogo = new globalThis.viewer.MotifLogo();

        protected init(): void {
            const data: string = LoadText("pwm");
            const model = new globalThis.viewer.Pspm(data, null);

            this.motifLogo.drawLogo("preview_1", model, 5);
        }

    }
}