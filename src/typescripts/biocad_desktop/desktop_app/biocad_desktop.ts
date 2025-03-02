interface biocad_desktop {
    scanDatabase(): Promise<string>;
    openEnrichmentPage(database: string, name: string, note: string): Promise<boolean>;

    getEnzymeClass(): Promise<string>;
    openLocalBlast(ssid: string);

    getTaskList(): Promise<string[]>;
    checkTaskList(): Promise<string[]>;
    openPage(ssid: string, taskJSON: string);

    getMetabolicCompartments(): Promise<string[]>;
    getMetabolicEnzymes(compartment: string): Promise<string>;

    getProteinIDs(): Promise<string[]>;
    getBlastp(id: string): Promise<string>;

    // general functions that available
    // for all web app pages
    getFileOpen(filterString: string): Promise<string>;
    getFileSave(filterString: string): Promise<string>;
    getFolderOpen(): Promise<string>;
    getNextUniqueId(): Promise<string>;
    sendPost(url: string, json: string): Promise<hostMsg>;
    createTask(title: string, url: string, json: string): Promise<hostMsg>;
    jumptoTaskManager();
}

interface hostMsg {
    result: boolean;
    data: string;
}
