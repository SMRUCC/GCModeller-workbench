interface biocad_desktop {
    getUniprotXmlDatabase(): Promise<string>;
    scanDatabase(): Promise<string>;
    openEnrichmentPage(database: string, name: string, note: string): Promise<boolean>;

    sendPost(url: string, json: string): Promise<hostMsg>;
}

interface hostMsg {
    result: boolean;
    data: string;
}
