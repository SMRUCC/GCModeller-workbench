interface biocad_desktop {
    scanDatabase(): Promise<string>;
    openEnrichmentPage(database: string, name: string, note: string): Promise<boolean>;

    getEnzymeClass(): Promise<string>;

    // general functions that available
    // for all web app pages
    getFileOpen(filterString: string): Promise<string>;
    sendPost(url: string, json: string): Promise<hostMsg>;
}

interface hostMsg {
    result: boolean;
    data: string;
}
