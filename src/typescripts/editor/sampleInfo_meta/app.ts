namespace sampleinfo_editor {

    export interface IsampleMeta {
        sampleInfo: string;
        shape: number;
        color: string;
        color1: string;
        color2: string;
    }

    export interface saveAction { (meta: IsampleMeta[]): void; }
}