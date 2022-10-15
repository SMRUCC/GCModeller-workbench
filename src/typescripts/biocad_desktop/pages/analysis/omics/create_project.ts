namespace pages.analysis_project {

    export class create_project extends Bootstrap {

        public get appName(): string {
            return "create_project";
        };

        protected init(): void {
            this.expr1_onclick();
        }

        public expr1_onclick() {
            $ts("#expr1").addClass("stepper-active");
            $ts("#sample2").removeClass("stepper-active");
            $ts("#create3").removeClass("stepper-active");

            $ts("#panel1").show();
            $ts("#panel2").hide();
            $ts("#panel3").hide();
        }

        public sample2_onclick() {
            $ts("#expr1").removeClass("stepper-active");
            $ts("#sample2").addClass("stepper-active");
            $ts("#create3").removeClass("stepper-active");

            $ts("#panel1").hide();
            $ts("#panel2").show();
            $ts("#panel3").hide();
        }

        public create3_onclick() {
            $ts("#expr1").removeClass("stepper-active");
            $ts("#sample2").removeClass("stepper-active");
            $ts("#create3").addClass("stepper-active");

            $ts("#panel1").hide();
            $ts("#panel2").hide();
            $ts("#panel3").show();
        }
    }
}