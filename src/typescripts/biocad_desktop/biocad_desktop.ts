interface biocad_desktop {
    getUniprotXmlDatabase(): string;
    sendPost(url: string, args: any): boolean;
}