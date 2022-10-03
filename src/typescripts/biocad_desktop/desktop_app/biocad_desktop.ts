interface biocad_desktop {
    getUniprotXmlDatabase(): Promise<string>;
    sendPost(url: string, json: string): Promise<hostMsg>;
}

interface hostMsg {
    result: boolean;
    data: string;
}

interface RSharpError {
    Message: string | string[];
    Source: string;
    TypeFullName: string;
    StackTrace: {
        File: string;
        Line: string;
        Method: {
            Method: string;
            Module: string;
            Namespace: string;
        }
    }[];
}
