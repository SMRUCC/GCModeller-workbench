interface biocad_desktop {
    scanDatabase(): Promise<string>;
    openEnrichmentPage(database: string, name: string, note: string): Promise<boolean>;

    getEnzymeClass(): Promise<string>;

    getTaskList(): Promise<string[]>;
    checkTaskList(): Promise<boolean>;

    // general functions that available
    // for all web app pages
    getFileOpen(filterString: string): Promise<string>;
    getFolderOpen(): Promise<string>;
    sendPost(url: string, json: string): Promise<hostMsg>;
    createTask(title: string, url: string, json: string): Promise<hostMsg>;
}

interface hostMsg {
    result: boolean;
    data: string;
}
