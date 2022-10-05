interface biocad_desktop {
    getUniprotXmlDatabase(): Promise<string>;
    scanDatabase(): Promise<string>;
    openEnrichmentPage(database: string, name: string, note: string): Promise<boolean>;

    // general functions that available
    // for all web app pages
    getFileOpen(filterString: string): Promise<string>;
    sendPost(url: string, json: string): Promise<hostMsg>;
}

interface hostMsg {
    result: boolean;
    data: string;
}
