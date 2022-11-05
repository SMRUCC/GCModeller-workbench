/// <reference path="../../../build/viewer.d.ts" />

namespace pages.viewers {

    export class motif_viewer extends Bootstrap {

        public get appName(): string {
            return "motif_viewer";
        };

        private motifLogo: viewer.MotifLogo;

        protected init(): void {
            const data: string = LoadText("pwm");
            const model = new viewer.Pspm(data, null);

            this.motifLogo = new viewer.MotifLogo();
            this.motifLogo.drawLogo("preview_1", model, 2);
        }

    }
}