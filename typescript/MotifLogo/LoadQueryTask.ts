namespace GCModeller.Workbench {

    /**
     * Draw motif logo from this function
    */
    export class LoadQueryTask {

        public target_id;
        public motifPWM;
        public scaleLogo;

        public constructor(target_id: string, pwm, scale: number) {
            this.target_id = target_id;
            this.motifPWM = pwm;
            this.scaleLogo = scale;
        }

        public run() {
            var alpha = new Alphabet("ACGT");
            var query_pspm = new Pspm(this.motifPWM, null);
            this.replace_logo(logo_1(alpha, "MEME Suite", query_pspm), this.target_id, this.scaleLogo, "Preview Logo", "block");
        }
    }
}

