namespace desktop {

    export interface configuration {
        BlastBin: string;
        BlastDb: string;
        RepositoryRoot: string;
        Dev2: IDEConfiguration
    }

    export interface IDEConfiguration {
        StartPage: { CloseAfterProjectLoad: boolean, ShowOnStartUp: boolean },
        IDE: IDEWindowConfig,
        Session,
        RememberWindowStatus: boolean
    }

    export interface IDEWindowConfig {
        Location: { Left: number, Top: number };
        Size: { Width: number, Height: number };
        Language: languages
    }

    export enum languages {
        // Following the system default language.
        System,

        // Language in Chinese simplify.
        // (简体中文) 
        "zh-CN",

        // Language in English.
        // (英语语言)
        "en-US",

        // Language in french.
        // (法语语言)   
        "fr-FR"
    }
}