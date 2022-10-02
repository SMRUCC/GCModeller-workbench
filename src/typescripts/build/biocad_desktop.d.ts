/// <reference path="linq.d.ts" />
declare namespace apps {
    const gcmodeller: biocad_desktop;
    function run(): void;
}
interface biocad_desktop {
    getUniprotXmlDatabase(): string;
}
declare namespace pages {
    class enrichment_database extends Bootstrap {
        readonly appName: string;
        protected init(): void;
        /**
         * method execute on native host side, not R server backend
        */
        open_uniprot_onclick(): void;
        imports_onclick(): void;
    }
}
