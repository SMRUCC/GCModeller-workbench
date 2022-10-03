interface biocad_desktop {
    getUniprotXmlDatabase(): Promise<string>;
    sendPost(url: string, json: string): Promise<hostMsg>;
}

interface hostMsg {
    result: boolean;
    data: string;
}
