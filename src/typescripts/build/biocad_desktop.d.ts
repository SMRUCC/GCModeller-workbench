/// <reference path="linq.d.ts" />
declare namespace apps {
    function run(): void;
}
declare namespace pages {
    class enrichment_database extends Bootstrap {
        readonly appName: string;
        protected init(): void;
    }
}
