interface biocad_desktop {
    getUniprotXmlDatabase(): string;
    sendPost(url: string, json: string): boolean;
}